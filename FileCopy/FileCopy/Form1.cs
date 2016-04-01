namespace FileCopy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Contract;

    public partial class frmMain : Form, INotifyPropertyChanged
    {

        private List<string> fileNames;

        private string destionationFolder;

        [Bindable(true)]
        public string DestinationFolder
        {
            get
            {
                return destionationFolder;
            }
            private set
            {
                destionationFolder = value;
                OnPropertyChanged("DestinationFolder");
            }
        }

        private int fileCount;
        private int fileCurrentNum;
        private long filesTotalBytes;
        private long filesCurrentBytes;

        private void fileListStart(object sender, FileListEventArgs args)
        {
            var m = (IFileCopyManager)sender;
            fileCount = m.Files.Count();
            fileCurrentNum = 1;
            filesTotalBytes = m.Files.Sum(f => f.FileSize).GetValueOrDefault(0);
            filesCurrentBytes = 0;
            panTop.Enabled = false;
            tabMain.SelectedTab = pagCopyProgress;
            StartTimer();
        }

        private void fileListEnd(object sender, FileListEventArgs args)
        {
            StopTimer();
            prgTotalFiles.Value = 0;
            lblTotalFilesPercents.Text = "0%";
            lblFilesCount.Text = "0 / 0";
            panTop.Enabled = true;
            Application.DoEvents();
            ShowFileList();
        }

        private void Progress(object sender, ProgressChangedEventArgs args)
        {
            var f = (IFileCopier)args.UserState;
            if (f == null)
                return;

            if (f.Status == CopyStatus.Copying)
            {
                prgTotalFiles.Value =
                    (int)Math.Floor((double)(filesCurrentBytes + f.CurrentBytes) / filesTotalBytes * 100);
                lblFilesCount.Text = string.Format("{0} / {1}", fileCurrentNum, fileCount);
                lblTotalFilesPercents.Text = prgTotalFiles.Value.ToString("D") + "%";
                lblCurrentFileName.Text = f.FileName;
                lblCurrentFilePercents.Text = args.ProgressPercentage.ToString("D") + "%";
                prgCurrentFile.Value = args.ProgressPercentage;
            }
            else
            {
                if (f.Status == CopyStatus.Done || f.Status == CopyStatus.Failed)
                {
                    filesCurrentBytes += f.FileSize ?? 0;
                    fileCurrentNum++;
                }
                lblCurrentFileName.Text = "...";
                lblCurrentFilePercents.Text = "0%";
                prgCurrentFile.Value = 0;
            }
        }

        private void Error(object sender, ErrorArgs args)
        {
            var c = (IFileCopier)sender;
            MessageBox.Show(c.ErrorType + ": " + c.ErrorMessage, "Ошибка", MessageBoxButtons.OK);
        }

        private void ShowFileList()
        {
            tabMain.SelectedTab = pagDbOpAnimation;
            Task.Factory.StartNew(() =>
                {
                    tFiles[] ret;

                    using (var db = new DbModel())
                    {
                        try
                        {
                            foreach (var fileEntry in FileCopyManager.Instance.Files
                            .Where(f => f.Status == CopyStatus.Done)
                            .Select(f => new tFiles()
                                {
                                    FileName = f.FileName,
                                    FileSize = f.FileSize ?? 0,
                                    Destination = f.DestinationFolder,
                                    EndTime = f.EndOfCopying ?? DateTime.MinValue,
                                    StartTime = f.StartOfCopying ?? DateTime.MinValue
                                }))
                                db.tFiles.Add(fileEntry);

                            db.SaveChanges();
                            ret = db.tFiles.Local.ToArray();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка БД");
                            ret = null;
                        }
                    }
                    return ret;
                })
                .ContinueWith(t =>
                {
                    gridFileList.DataSource = t.Result;
                    tabMain.SelectedTab = pagCopyResult;
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public frmMain()
        {
            InitializeComponent();
            lblDestination.DataBindings.Add("Text", this, "DestinationFolder", true, DataSourceUpdateMode.Never, "<Не задано>");
            lblDestination1.DataBindings.Add("Text", this, "DestinationFolder", true, DataSourceUpdateMode.Never, "<Не задано>");

            fileNames = null;

            var manager = FileCopyManager.Instance;
            manager.ProcessingStart += fileListStart;
            manager.ProcessingEnd += fileListEnd;

            // Test values
            destionationFolder = @"G:\! Музыка\test";
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                fileNames = dlgOpenFile.FileNames.ToList();
                lbFilesToCopy.DataSource = fileNames;
                tabMain.SelectedTab = pagFileListToCopy;
            }
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            dlgFolderBrowser.SelectedPath = destionationFolder;
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                DestinationFolder = dlgFolderBrowser.SelectedPath;
                tabMain.SelectedTab = pagFileListToCopy;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FileCopyManager.Instance.Start(fileNames, DestinationFolder, Progress, Error);
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            FileCopyManager.Instance.Stop();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void timProgress_Tick(object sender, EventArgs e)
        {
            lblTotalTime.Text =
                (DateTime.Now - (DateTime)timProgress.Tag).ToString(@"hh\:mm\:ss");
        }

        private void StartTimer()
        {
            lblTotalTime.Text = TimeSpan.Zero.ToString(@"hh\:mm\:ss");
            timProgress.Tag = DateTime.Now;
            timProgress.Start();
        }

        private void StopTimer()
        {
            timProgress.Stop();
        }

        private void timDbAnimation_Tick(object sender, EventArgs e)
        {
            var ndx = (int)timDbAnimation.Tag;
            if (ndx >= imlDBAnimation.Images.Count)
                ndx = 0;
            picDbAnimation.Image = imlDBAnimation.Images[ndx++];
            timDbAnimation.Tag = ndx;
        }

        private void tabMain_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == pagDbOpAnimation)
            {
                timDbAnimation.Tag = 0;
                timDbAnimation.Start();
            }
            else
                timDbAnimation.Stop();
        }

        private void btnSetDbCredentials_Click(object sender, EventArgs e)
        {
            tabMain.SelectedTab = pagDbCredentials;

            var csb = new SqlConnectionStringBuilder();
            csb.ConnectionString = DbModel.ConnectionString;

            edtDbServer.Text = csb.DataSource;
            edtDbUser.Text = csb.UserID;
            edtDbPassword.Text = csb.Password;
            edtDbCatalog.Text = csb.InitialCatalog;
        }

        private void btnDbApplySettings_Click(object sender, EventArgs e)
        {
            var csb = new SqlConnectionStringBuilder();
            csb.ConnectionString = DbModel.ConnectionString;

            csb.DataSource = edtDbServer.Text;
            csb.UserID = edtDbUser.Text;
            csb.Password = edtDbPassword.Text;
            csb.InitialCatalog = edtDbCatalog.Text;

            DbModel.ConnectionString = csb.ConnectionString;
        }

    }
}
