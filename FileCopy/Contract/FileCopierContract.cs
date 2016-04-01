namespace Contract
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public enum CopyStatus
    {
        /// <summary>
        /// Начальное состояние
        /// </summary>
        NotInitialized,
        /// <summary>
        /// Файл готов к копированию
        /// </summary>
        Ready,
        /// <summary>
        /// Ошибка проверки: файл не существует, недостаточно места на получателе, не хватает прав и т.п
        /// </summary>
        CheckError,
        /// <summary>
        /// Начало копирования: открытие файла, определение размера и т. п.
        /// </summary>
        Starting,
        /// <summary>
        /// Копирование в процессе
        /// </summary>
        Copying,
        /// <summary>
        /// Идёт прерывание копирования
        /// </summary>
        Stopping,
        /// <summary>
        /// Идёт попытка повтора после ошибки
        /// </summary>
        Retrying,
        /// <summary>
        /// Копирование приостановлено
        /// </summary>
        Pause,
        /// <summary>
        /// Идёт обработка ошибки
        /// </summary>
        ErrorProcessing,
        /// <summary>
        /// Копирование завершено успешно
        /// </summary>
        Done,
        /// <summary>
        /// Копирование не завершено из-за отмены
        /// </summary>
        Stopped,
        /// <summary>
        /// Копирование не завершено из-за ошибки
        /// </summary>
        Failed
    }

    public delegate void ErrorEventHandler(object sender, ErrorArgs args);

    public class ErrorArgs : CancelEventArgs
    {
        public ErrorArgs(bool cancel) : base(cancel) { }
    }

    public interface IFileCopier
    {
        string FileName { get; set; }
        long? FileSize { get; }
        long CurrentBytes { get; }
        string DestinationFolder { get; set; }
        CopyStatus Status { get; }
        DateTime? StartOfCopying { get; }
        DateTime? EndOfCopying { get; }
        string ErrorType { get; }
        string ErrorMessage { get; }

        void Start();
        void Pause();
        void Resume();
        void Stop();
        void Restart();

        event ProgressChangedEventHandler Progress;
        event ErrorEventHandler Error;
    }

    public delegate void FileListProcessingHandler(object sender, FileListEventArgs args);

    public class FileListEventArgs : EventArgs
    {

    }

    public interface IFileCopyManager
    {
        IEnumerable<IFileCopier> Files { get; }

        void Start(IEnumerable<string> fileList, string destinationFolder, ProgressChangedEventHandler progressProc, ErrorEventHandler errorProc);
        void Stop();

        event FileListProcessingHandler ProcessingStart;
        event FileListProcessingHandler ProcessingEnd;

    }
}
