namespace FileCopy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;

    using Contract;

    using ErrorEventHandler = Contract.ErrorEventHandler;

    internal class EventException : Exception
    {
        public Exception OriginalException { get; set; }
    }

    public class FileCopier : IFileCopier
    {

        public class FileAlreadyExistsException : Exception
        {
            public FileAlreadyExistsException(string message)
                : base(message)

            {
            }
        }

        private string filename;

        private string destination;

        private CopyStatus status;

        private object statusLocker = new object();

        private readonly BackgroundWorker process;

        private byte[] readBuffer;

        private FileStream inputStream, outputStream;

        public string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                if (Status == CopyStatus.NotInitialized)
                {
                    filename = value;
                    Init();
                }
            }
        }

        public long? FileSize
        {
            get
            {
                if (Status == CopyStatus.NotInitialized)
                    Init();

                switch (Status)
                {
                    case CopyStatus.NotInitialized:
                    case CopyStatus.CheckError:
                        break;
                    default:
                        try
                        {
                            var fi = new FileInfo(FileName);
                            return fi.Length;
                        }
                        catch (Exception ex)
                        {
                            IoError(ex);
                        }

                        break;
                }

                return null;
            }
        }

        public long CurrentBytes { get; private set; }

        public string DestinationFolder
        {
            get
            {
                return destination;
            }
            set
            {
                switch (Status)
                {
                    case CopyStatus.NotInitialized:
                    case CopyStatus.Ready:
                    case CopyStatus.Done:
                    case CopyStatus.Failed:
                    case CopyStatus.Stopped:
                        destination = value;
                        break;
                }
            }
        }

        public CopyStatus Status
        {
            get
            {
                CopyStatus ret;
                lock (statusLocker) ret = status;
                return ret;
            }
            private set
            {
                lock (statusLocker) status = value;
            }
        }

        public DateTime? StartOfCopying { get; private set; }

        public DateTime? EndOfCopying { get; private set; }

        public string ErrorType { get; private set; }

        public string ErrorMessage { get; private set; }

        public FileCopier()
        {
            Status = CopyStatus.NotInitialized;
            FileName = string.Empty;
            DestinationFolder = string.Empty;
            StartOfCopying = EndOfCopying = null;
            ErrorMessage = string.Empty;
            readBuffer = null;
            inputStream = outputStream = null;

            process = new BackgroundWorker()
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
            process.DoWork += CopyFile;
        }

        private void AllocateBuffer()
        {
            const long BufSizeLimit = 20000000;

            var fs = FileSize ?? 0;

            if (fs <= 0)
                return;

            var bs = fs <= BufSizeLimit ? fs : BufSizeLimit;

            readBuffer = new byte[bs];
        }

        private void Init()
        {
            if (FileName == string.Empty)
                return;
            try
            {
                var fi = new FileInfo(FileName);
                if (fi.Exists)
                {
                    Status = CopyStatus.Ready;
                }
            }
            catch (Exception ex)
            {
                IoError(ex);
            }
        }

        private void IoError(Exception exception)
        {
            switch (Status)
            {
                case CopyStatus.NotInitialized:
                case CopyStatus.Ready:
                    Status = CopyStatus.CheckError;
                    break;
            }
            ErrorMessage = exception.Message;
            ErrorType = exception.GetType().Name;

            var args = new ErrorArgs(true);
            OnError(args);
            //if (args.Cancel)
            Status = CopyStatus.Failed;
        }

        public void Start()
        {
            if (Status == CopyStatus.Ready)
            {
                if (!process.IsBusy)
                    process.RunWorkerAsync();
            }
        }

        public void Pause()
        {
            if (Status == CopyStatus.Copying || process.IsBusy)
            {
                Status = CopyStatus.Pause;
            }
        }

        public void Resume()
        {
            if (Status == CopyStatus.Pause)
            {
                if (!process.IsBusy)
                    process.RunWorkerAsync();
            }
        }

        public void Stop()
        {
            if (Status == CopyStatus.Pause
                || Status == CopyStatus.Starting
                || Status == CopyStatus.Copying
                || Status == CopyStatus.ErrorProcessing)
            {
                Status = CopyStatus.Stopping;
                if (!process.IsBusy)
                    process.RunWorkerAsync();
            }
            else
            {
                Status = CopyStatus.Stopped;
            }
        }

        public void Restart()
        {
            if (process.IsBusy)
            {
                process.CancelAsync();
            }
            Init();
            Start();
        }

        private void CloseStreams(string deleteFileName = null)
        {
            inputStream.Close();
            inputStream = null;
            outputStream.Close();
            outputStream = null;
            if (!string.IsNullOrEmpty(deleteFileName))
                File.Delete(deleteFileName);
        }

        private void CopyFile(object sender, DoWorkEventArgs args)
        {
            try
            {
                args.Result = this;

                Status = Status == CopyStatus.Pause ? CopyStatus.Copying : CopyStatus.Starting;

                var outFileName = string.Empty;
                var percents = 0;

                if (readBuffer == null)
                    AllocateBuffer();

                if (inputStream == null)
                {
                    var ifi = new FileInfo(FileName);
                    inputStream = ifi.OpenRead();
                }

                if (outputStream == null)
                {
                    outFileName = Path.Combine(DestinationFolder, Path.GetFileName(FileName));
                    var ofi = new FileInfo(outFileName);
                    if (ofi.Exists)
                        throw new FileAlreadyExistsException(outFileName);
                    outputStream = ofi.Create();
                }

                Status = CopyStatus.Copying;
                StartOfCopying = DateTime.Now;

                while (true)
                {
                    if (Status != CopyStatus.Copying)
                        break;

                    var wasread = inputStream.Read(readBuffer, 0, readBuffer.Length);
                    if (wasread <= 0 || Status != CopyStatus.Copying)
                        break;

                    outputStream.Write(readBuffer, 0, wasread);

                    CurrentBytes = outputStream.Length;
                    percents = (int)Math.Round((double)outputStream.Length / inputStream.Length * 100);
                    process.ReportProgress(percents, this);
                }

                EndOfCopying = DateTime.Now;

                switch (Status)
                {
                    case CopyStatus.Copying:
                        CloseStreams();
                        Status = CopyStatus.Done;
                        break;
                    case CopyStatus.Stopping:
                        CloseStreams(outFileName);
                        Status = CopyStatus.Stopped;
                        break;
                }

                process.ReportProgress(percents, this);
            }
            catch (Exception ex)
            {
                if (ex is EventException)
                    throw (ex as EventException).OriginalException;

                Status = CopyStatus.ErrorProcessing;
                IoError(ex);

                var percents = 0;
                var fs = FileSize ?? 0;
                if (fs > 0)
                    percents = (int)Math.Round((double)CurrentBytes / fs * 100);
                process.ReportProgress(percents, this);
            }
        }

        private void OnError(ErrorArgs args)
        {
            var e = Error;
            if (e != null)
                e(this, args);
        }

        public event ProgressChangedEventHandler Progress
        {
            add { process.ProgressChanged += value; }
            remove { process.ProgressChanged -= value; }
        }

        internal event RunWorkerCompletedEventHandler ProcessCompleted
        {
            add { process.RunWorkerCompleted += value; }
            remove { process.RunWorkerCompleted -= value; }
        }

        public event ErrorEventHandler Error;

    }

    public class FileCopyManager : IFileCopyManager, INotifyPropertyChanged
    {
        private static readonly IFileCopyManager instance = new FileCopyManager();

        private IEnumerable<IFileCopier> files;
        private readonly object fileListLocker = new object();

        private event ProgressChangedEventHandler userProgress;
        private event ErrorEventHandler userError;

        private void fileProgress(object sender, ProgressChangedEventArgs args)
        {
            var p = userProgress;
            if (p != null)
            {
                try
                {
                    p(sender, args);
                }
                catch (Exception ex)
                {
                    var n = new EventException() { OriginalException = ex };
                    throw n;
                }
            }
        }

        private void fileError(object sender, ErrorArgs args)
        {
            var p = userError;
            if (p != null)
            {
                try
                {
                    p(sender, args);
                }
                catch (Exception ex)
                {
                    var n = new EventException() { OriginalException = ex };
                    throw n;
                }
            }
        }

        private void FileCopyCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            var copier = (IFileCopier)args.Result;
            switch (copier.Status)
            {
                case CopyStatus.Stopped:
                case CopyStatus.Done:
                case CopyStatus.CheckError:
                case CopyStatus.Failed:

                    var nextFile = NextReadyFile;

                    if (nextFile == null)
                    {
                        var e = ProcessingEnd;
                        if (e != null)
                            e(this, new FileListEventArgs());
                    }
                    else
                    {
                        nextFile.Start();
                    }
        
                    break;
            }
        }

        private IFileCopier NextReadyFile
        {
            get
            {
                IFileCopier ret;
                lock (fileListLocker)
                    ret = files.FirstOrDefault(f => f.Status == CopyStatus.Ready);
                return ret;
            }
        }

        private int ReadyFileCount
        {
            get
            {
                int ret;
                lock (fileListLocker)
                    ret = files.Count(f => f.Status == CopyStatus.Ready);
                return ret;
            }
        }

        private FileCopyManager()
        {
            Files = null;
        }

        public static IFileCopyManager Instance
        {
            get { return instance; }
        }

        public IEnumerable<IFileCopier> Files
        {
            get
            {
                return files;
            }
            private set
            {
                lock (fileListLocker)
                    files = value;
                OnPropertyChanged("Files");
            }
        }

        public void Start(IEnumerable<string> fileList, string destinationFolder, ProgressChangedEventHandler progressProc, ErrorEventHandler errorProc)
        {
            if (fileList == null || !fileList.Any() || string.IsNullOrEmpty(destinationFolder))
                return;

            var fileCopiers = new List<FileCopier>();

            userProgress = progressProc;
            userError = errorProc;

            lock (fileListLocker)
            {
                foreach (var f in fileList)
                {
                    var c = new FileCopier();
                    c.Progress += fileProgress;
                    c.Error += fileError;
                    c.ProcessCompleted += FileCopyCompleted;
                    c.FileName = f;
                    c.DestinationFolder = destinationFolder;
                    fileCopiers.Add(c);
                }
            }

            if (fileCopiers.Count <= 0)
                return;

            Files = fileCopiers;

            var start = ProcessingStart;
            if (start != null)
            {
                var args = new FileListEventArgs();
                start(this, args);
            }

            var nextFile = NextReadyFile;
            if (nextFile != null)
                nextFile.Start();
        }

        public void Stop()
        {
            foreach (var copier in Files)
                copier.Stop();

            if (ReadyFileCount <= 0)
            {
                var e = ProcessingEnd;
                if (e != null)
                    e(this, new FileListEventArgs());
            }
        }

        public event FileListProcessingHandler ProcessingStart;

        public event FileListProcessingHandler ProcessingEnd;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
