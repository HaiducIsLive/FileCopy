namespace FileCopy
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.btnSelectDestination = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gridFileList = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.prgTotalFiles = new System.Windows.Forms.ProgressBar();
            this.lblFilesCount = new System.Windows.Forms.Label();
            this.lblTotalFilesPercents = new System.Windows.Forms.Label();
            this.lblCurrentFilePercents = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.lblTotalTimeCap = new System.Windows.Forms.Label();
            this.lblTotalProgressCap = new System.Windows.Forms.Label();
            this.lblDestinationCap = new System.Windows.Forms.Label();
            this.lblCurrentFileName = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.btnAbort = new System.Windows.Forms.Button();
            this.prgCurrentFile = new System.Windows.Forms.ProgressBar();
            this.timProgress = new System.Windows.Forms.Timer(this.components);
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pagFileListToCopy = new System.Windows.Forms.TabPage();
            this.lblFilesToCopyCap = new System.Windows.Forms.Label();
            this.lblDestination1 = new System.Windows.Forms.Label();
            this.lblDestinationCap1 = new System.Windows.Forms.Label();
            this.lbFilesToCopy = new System.Windows.Forms.ListBox();
            this.pagCopyResult = new System.Windows.Forms.TabPage();
            this.lblCopyResultCap = new System.Windows.Forms.Label();
            this.pagDbOpAnimation = new System.Windows.Forms.TabPage();
            this.picDbAnimation = new System.Windows.Forms.PictureBox();
            this.lblAniDbConnection = new System.Windows.Forms.Label();
            this.pagCopyProgress = new System.Windows.Forms.TabPage();
            this.pagDbCredentials = new System.Windows.Forms.TabPage();
            this.edtDbPassword = new System.Windows.Forms.TextBox();
            this.edtDbCatalog = new System.Windows.Forms.TextBox();
            this.lblDbCatalogCap = new System.Windows.Forms.Label();
            this.lblDbPasswordCap = new System.Windows.Forms.Label();
            this.edtDbUser = new System.Windows.Forms.TextBox();
            this.lblDbUserCap = new System.Windows.Forms.Label();
            this.edtDbServer = new System.Windows.Forms.TextBox();
            this.lblDbServerCap = new System.Windows.Forms.Label();
            this.imlDBAnimation = new System.Windows.Forms.ImageList(this.components);
            this.timDbAnimation = new System.Windows.Forms.Timer(this.components);
            this.panTop = new System.Windows.Forms.Panel();
            this.btnSetDbCredentials = new System.Windows.Forms.Button();
            this.btnDbApplySettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridFileList)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pagFileListToCopy.SuspendLayout();
            this.pagCopyResult.SuspendLayout();
            this.pagDbOpAnimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDbAnimation)).BeginInit();
            this.pagCopyProgress.SuspendLayout();
            this.pagDbCredentials.SuspendLayout();
            this.panTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(3, 2);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(114, 23);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "Выбор файлов";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // btnSelectDestination
            // 
            this.btnSelectDestination.Location = new System.Drawing.Point(123, 2);
            this.btnSelectDestination.Name = "btnSelectDestination";
            this.btnSelectDestination.Size = new System.Drawing.Size(114, 23);
            this.btnSelectDestination.TabIndex = 1;
            this.btnSelectDestination.Text = "Выбор папки";
            this.btnSelectDestination.UseVisualStyleBackColor = true;
            this.btnSelectDestination.Click += new System.EventHandler(this.btnSelectDestination_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(507, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Пуск";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gridFileList
            // 
            this.gridFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFileName,
            this.colFileSize,
            this.colDestination,
            this.colStartTime,
            this.colEndTime,
            this.colCopyTime});
            this.gridFileList.Location = new System.Drawing.Point(0, 37);
            this.gridFileList.Margin = new System.Windows.Forms.Padding(0);
            this.gridFileList.Name = "gridFileList";
            this.gridFileList.Size = new System.Drawing.Size(624, 315);
            this.gridFileList.TabIndex = 4;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            dataGridViewCellStyle5.NullValue = null;
            this.colId.DefaultCellStyle = dataGridViewCellStyle5;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colFileName
            // 
            this.colFileName.DataPropertyName = "FileName";
            this.colFileName.HeaderText = "Исходный файл";
            this.colFileName.Name = "colFileName";
            this.colFileName.Width = 200;
            // 
            // colFileSize
            // 
            this.colFileSize.DataPropertyName = "FileSize";
            this.colFileSize.HeaderText = "Размер";
            this.colFileSize.Name = "colFileSize";
            // 
            // colDestination
            // 
            this.colDestination.DataPropertyName = "Destination";
            this.colDestination.HeaderText = "Папка назначения";
            this.colDestination.Name = "colDestination";
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "StartTime";
            this.colStartTime.HeaderText = "Начало";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = false;
            // 
            // colEndTime
            // 
            this.colEndTime.DataPropertyName = "EndTime";
            this.colEndTime.HeaderText = "Окончание";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = false;
            // 
            // colCopyTime
            // 
            this.colCopyTime.DataPropertyName = "CopyTime";
            dataGridViewCellStyle6.Format = "hh\\:mm\\:ss\\.fff";
            this.colCopyTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCopyTime.HeaderText = "Время копирования";
            this.colCopyTime.Name = "colCopyTime";
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.Filter = "Все файлы|*.*";
            this.dlgOpenFile.Multiselect = true;
            this.dlgOpenFile.Title = "Выбор файлов для копирования";
            // 
            // prgTotalFiles
            // 
            this.prgTotalFiles.Location = new System.Drawing.Point(9, 90);
            this.prgTotalFiles.Name = "prgTotalFiles";
            this.prgTotalFiles.Size = new System.Drawing.Size(556, 24);
            this.prgTotalFiles.TabIndex = 0;
            // 
            // lblFilesCount
            // 
            this.lblFilesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilesCount.Location = new System.Drawing.Point(380, 74);
            this.lblFilesCount.Name = "lblFilesCount";
            this.lblFilesCount.Size = new System.Drawing.Size(185, 13);
            this.lblFilesCount.TabIndex = 11;
            this.lblFilesCount.Text = "total / current";
            this.lblFilesCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalFilesPercents
            // 
            this.lblTotalFilesPercents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalFilesPercents.AutoSize = true;
            this.lblTotalFilesPercents.Location = new System.Drawing.Point(573, 102);
            this.lblTotalFilesPercents.Name = "lblTotalFilesPercents";
            this.lblTotalFilesPercents.Size = new System.Drawing.Size(16, 13);
            this.lblTotalFilesPercents.TabIndex = 10;
            this.lblTotalFilesPercents.Text = "...";
            // 
            // lblCurrentFilePercents
            // 
            this.lblCurrentFilePercents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentFilePercents.AutoSize = true;
            this.lblCurrentFilePercents.Location = new System.Drawing.Point(570, 163);
            this.lblCurrentFilePercents.Name = "lblCurrentFilePercents";
            this.lblCurrentFilePercents.Size = new System.Drawing.Size(16, 13);
            this.lblCurrentFilePercents.TabIndex = 9;
            this.lblCurrentFilePercents.Text = "...";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Location = new System.Drawing.Point(6, 219);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(16, 13);
            this.lblTotalTime.TabIndex = 8;
            this.lblTotalTime.Text = "...";
            // 
            // lblTotalTimeCap
            // 
            this.lblTotalTimeCap.AutoSize = true;
            this.lblTotalTimeCap.Location = new System.Drawing.Point(6, 203);
            this.lblTotalTimeCap.Name = "lblTotalTimeCap";
            this.lblTotalTimeCap.Size = new System.Drawing.Size(97, 13);
            this.lblTotalTimeCap.TabIndex = 7;
            this.lblTotalTimeCap.Text = "Прошло времени:";
            // 
            // lblTotalProgressCap
            // 
            this.lblTotalProgressCap.AutoSize = true;
            this.lblTotalProgressCap.Location = new System.Drawing.Point(6, 74);
            this.lblTotalProgressCap.Name = "lblTotalProgressCap";
            this.lblTotalProgressCap.Size = new System.Drawing.Size(130, 13);
            this.lblTotalProgressCap.TabIndex = 6;
            this.lblTotalProgressCap.Text = "Состояние копирования";
            // 
            // lblDestinationCap
            // 
            this.lblDestinationCap.AutoSize = true;
            this.lblDestinationCap.Location = new System.Drawing.Point(6, 12);
            this.lblDestinationCap.Name = "lblDestinationCap";
            this.lblDestinationCap.Size = new System.Drawing.Size(104, 13);
            this.lblDestinationCap.TabIndex = 5;
            this.lblDestinationCap.Text = "Папка назначения:";
            // 
            // lblCurrentFileName
            // 
            this.lblCurrentFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentFileName.AutoEllipsis = true;
            this.lblCurrentFileName.Location = new System.Drawing.Point(9, 127);
            this.lblCurrentFileName.Name = "lblCurrentFileName";
            this.lblCurrentFileName.Size = new System.Drawing.Size(556, 22);
            this.lblCurrentFileName.TabIndex = 4;
            this.lblCurrentFileName.Text = "...";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(6, 25);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(16, 13);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "...";
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(451, 209);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(114, 23);
            this.btnAbort.TabIndex = 2;
            this.btnAbort.Text = "Прервать";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // prgCurrentFile
            // 
            this.prgCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgCurrentFile.Location = new System.Drawing.Point(9, 152);
            this.prgCurrentFile.Name = "prgCurrentFile";
            this.prgCurrentFile.Size = new System.Drawing.Size(556, 24);
            this.prgCurrentFile.TabIndex = 1;
            // 
            // timProgress
            // 
            this.timProgress.Interval = 500;
            this.timProgress.Tick += new System.EventHandler(this.timProgress_Tick);
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMain.Controls.Add(this.pagFileListToCopy);
            this.tabMain.Controls.Add(this.pagCopyResult);
            this.tabMain.Controls.Add(this.pagDbOpAnimation);
            this.tabMain.Controls.Add(this.pagCopyProgress);
            this.tabMain.Controls.Add(this.pagDbCredentials);
            this.tabMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tabMain.Location = new System.Drawing.Point(15, 60);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(632, 342);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 6;
            this.tabMain.TabStop = false;
            this.tabMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabMain_Selected);
            // 
            // pagFileListToCopy
            // 
            this.pagFileListToCopy.Controls.Add(this.lblFilesToCopyCap);
            this.pagFileListToCopy.Controls.Add(this.lblDestination1);
            this.pagFileListToCopy.Controls.Add(this.lblDestinationCap1);
            this.pagFileListToCopy.Controls.Add(this.lbFilesToCopy);
            this.pagFileListToCopy.Location = new System.Drawing.Point(4, 5);
            this.pagFileListToCopy.Name = "pagFileListToCopy";
            this.pagFileListToCopy.Padding = new System.Windows.Forms.Padding(3);
            this.pagFileListToCopy.Size = new System.Drawing.Size(624, 333);
            this.pagFileListToCopy.TabIndex = 2;
            this.pagFileListToCopy.Text = "tabPage1";
            this.pagFileListToCopy.UseVisualStyleBackColor = true;
            // 
            // lblFilesToCopyCap
            // 
            this.lblFilesToCopyCap.AutoSize = true;
            this.lblFilesToCopyCap.Location = new System.Drawing.Point(6, 55);
            this.lblFilesToCopyCap.Name = "lblFilesToCopyCap";
            this.lblFilesToCopyCap.Size = new System.Drawing.Size(137, 13);
            this.lblFilesToCopyCap.TabIndex = 3;
            this.lblFilesToCopyCap.Text = "Файлы для копирования:";
            // 
            // lblDestination1
            // 
            this.lblDestination1.AutoSize = true;
            this.lblDestination1.Location = new System.Drawing.Point(6, 25);
            this.lblDestination1.Name = "lblDestination1";
            this.lblDestination1.Size = new System.Drawing.Size(16, 13);
            this.lblDestination1.TabIndex = 2;
            this.lblDestination1.Text = "...";
            // 
            // lblDestinationCap1
            // 
            this.lblDestinationCap1.AutoSize = true;
            this.lblDestinationCap1.Location = new System.Drawing.Point(6, 12);
            this.lblDestinationCap1.Name = "lblDestinationCap1";
            this.lblDestinationCap1.Size = new System.Drawing.Size(104, 13);
            this.lblDestinationCap1.TabIndex = 1;
            this.lblDestinationCap1.Text = "Папка назначения:";
            // 
            // lbFilesToCopy
            // 
            this.lbFilesToCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFilesToCopy.FormattingEnabled = true;
            this.lbFilesToCopy.Location = new System.Drawing.Point(9, 71);
            this.lbFilesToCopy.Name = "lbFilesToCopy";
            this.lbFilesToCopy.Size = new System.Drawing.Size(609, 251);
            this.lbFilesToCopy.TabIndex = 0;
            // 
            // pagCopyResult
            // 
            this.pagCopyResult.Controls.Add(this.lblCopyResultCap);
            this.pagCopyResult.Controls.Add(this.gridFileList);
            this.pagCopyResult.Location = new System.Drawing.Point(4, 5);
            this.pagCopyResult.Margin = new System.Windows.Forms.Padding(0);
            this.pagCopyResult.Name = "pagCopyResult";
            this.pagCopyResult.Size = new System.Drawing.Size(624, 333);
            this.pagCopyResult.TabIndex = 0;
            this.pagCopyResult.Text = "tabPage1";
            this.pagCopyResult.UseVisualStyleBackColor = true;
            // 
            // lblCopyResultCap
            // 
            this.lblCopyResultCap.AutoSize = true;
            this.lblCopyResultCap.Location = new System.Drawing.Point(6, 12);
            this.lblCopyResultCap.Name = "lblCopyResultCap";
            this.lblCopyResultCap.Size = new System.Drawing.Size(176, 13);
            this.lblCopyResultCap.TabIndex = 5;
            this.lblCopyResultCap.Text = "Успешно скопированные файлы:";
            // 
            // pagDbOpAnimation
            // 
            this.pagDbOpAnimation.Controls.Add(this.picDbAnimation);
            this.pagDbOpAnimation.Controls.Add(this.lblAniDbConnection);
            this.pagDbOpAnimation.Location = new System.Drawing.Point(4, 5);
            this.pagDbOpAnimation.Name = "pagDbOpAnimation";
            this.pagDbOpAnimation.Padding = new System.Windows.Forms.Padding(3);
            this.pagDbOpAnimation.Size = new System.Drawing.Size(624, 333);
            this.pagDbOpAnimation.TabIndex = 1;
            this.pagDbOpAnimation.Text = "tabPage2";
            this.pagDbOpAnimation.UseVisualStyleBackColor = true;
            // 
            // picDbAnimation
            // 
            this.picDbAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picDbAnimation.Location = new System.Drawing.Point(16, 42);
            this.picDbAnimation.Name = "picDbAnimation";
            this.picDbAnimation.Size = new System.Drawing.Size(590, 46);
            this.picDbAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDbAnimation.TabIndex = 1;
            this.picDbAnimation.TabStop = false;
            // 
            // lblAniDbConnection
            // 
            this.lblAniDbConnection.AutoSize = true;
            this.lblAniDbConnection.Location = new System.Drawing.Point(13, 14);
            this.lblAniDbConnection.Name = "lblAniDbConnection";
            this.lblAniDbConnection.Size = new System.Drawing.Size(94, 13);
            this.lblAniDbConnection.TabIndex = 0;
            this.lblAniDbConnection.Text = "Операции с БД...";
            // 
            // pagCopyProgress
            // 
            this.pagCopyProgress.Controls.Add(this.lblFilesCount);
            this.pagCopyProgress.Controls.Add(this.prgTotalFiles);
            this.pagCopyProgress.Controls.Add(this.lblTotalFilesPercents);
            this.pagCopyProgress.Controls.Add(this.prgCurrentFile);
            this.pagCopyProgress.Controls.Add(this.lblCurrentFilePercents);
            this.pagCopyProgress.Controls.Add(this.btnAbort);
            this.pagCopyProgress.Controls.Add(this.lblTotalTime);
            this.pagCopyProgress.Controls.Add(this.lblDestination);
            this.pagCopyProgress.Controls.Add(this.lblTotalTimeCap);
            this.pagCopyProgress.Controls.Add(this.lblCurrentFileName);
            this.pagCopyProgress.Controls.Add(this.lblTotalProgressCap);
            this.pagCopyProgress.Controls.Add(this.lblDestinationCap);
            this.pagCopyProgress.Location = new System.Drawing.Point(4, 5);
            this.pagCopyProgress.Name = "pagCopyProgress";
            this.pagCopyProgress.Padding = new System.Windows.Forms.Padding(3);
            this.pagCopyProgress.Size = new System.Drawing.Size(624, 333);
            this.pagCopyProgress.TabIndex = 3;
            this.pagCopyProgress.Text = "tabPage1";
            this.pagCopyProgress.UseVisualStyleBackColor = true;
            // 
            // pagDbCredentials
            // 
            this.pagDbCredentials.Controls.Add(this.btnDbApplySettings);
            this.pagDbCredentials.Controls.Add(this.edtDbPassword);
            this.pagDbCredentials.Controls.Add(this.edtDbCatalog);
            this.pagDbCredentials.Controls.Add(this.lblDbCatalogCap);
            this.pagDbCredentials.Controls.Add(this.lblDbPasswordCap);
            this.pagDbCredentials.Controls.Add(this.edtDbUser);
            this.pagDbCredentials.Controls.Add(this.lblDbUserCap);
            this.pagDbCredentials.Controls.Add(this.edtDbServer);
            this.pagDbCredentials.Controls.Add(this.lblDbServerCap);
            this.pagDbCredentials.Location = new System.Drawing.Point(4, 5);
            this.pagDbCredentials.Name = "pagDbCredentials";
            this.pagDbCredentials.Padding = new System.Windows.Forms.Padding(3);
            this.pagDbCredentials.Size = new System.Drawing.Size(624, 333);
            this.pagDbCredentials.TabIndex = 4;
            this.pagDbCredentials.Text = "tabPage1";
            this.pagDbCredentials.UseVisualStyleBackColor = true;
            // 
            // edtDbPassword
            // 
            this.edtDbPassword.Location = new System.Drawing.Point(29, 139);
            this.edtDbPassword.Name = "edtDbPassword";
            this.edtDbPassword.PasswordChar = '░';
            this.edtDbPassword.Size = new System.Drawing.Size(233, 20);
            this.edtDbPassword.TabIndex = 2;
            // 
            // edtDbCatalog
            // 
            this.edtDbCatalog.Location = new System.Drawing.Point(29, 190);
            this.edtDbCatalog.Name = "edtDbCatalog";
            this.edtDbCatalog.Size = new System.Drawing.Size(233, 20);
            this.edtDbCatalog.TabIndex = 3;
            // 
            // lblDbCatalogCap
            // 
            this.lblDbCatalogCap.AutoSize = true;
            this.lblDbCatalogCap.Location = new System.Drawing.Point(26, 174);
            this.lblDbCatalogCap.Name = "lblDbCatalogCap";
            this.lblDbCatalogCap.Size = new System.Drawing.Size(75, 13);
            this.lblDbCatalogCap.TabIndex = 6;
            this.lblDbCatalogCap.Text = "База данных:";
            // 
            // lblDbPasswordCap
            // 
            this.lblDbPasswordCap.AutoSize = true;
            this.lblDbPasswordCap.Location = new System.Drawing.Point(26, 123);
            this.lblDbPasswordCap.Name = "lblDbPasswordCap";
            this.lblDbPasswordCap.Size = new System.Drawing.Size(48, 13);
            this.lblDbPasswordCap.TabIndex = 4;
            this.lblDbPasswordCap.Text = "Пароль:";
            // 
            // edtDbUser
            // 
            this.edtDbUser.Location = new System.Drawing.Point(29, 90);
            this.edtDbUser.Name = "edtDbUser";
            this.edtDbUser.Size = new System.Drawing.Size(233, 20);
            this.edtDbUser.TabIndex = 1;
            // 
            // lblDbUserCap
            // 
            this.lblDbUserCap.AutoSize = true;
            this.lblDbUserCap.Location = new System.Drawing.Point(26, 74);
            this.lblDbUserCap.Name = "lblDbUserCap";
            this.lblDbUserCap.Size = new System.Drawing.Size(83, 13);
            this.lblDbUserCap.TabIndex = 2;
            this.lblDbUserCap.Text = "Пользователь:";
            // 
            // edtDbServer
            // 
            this.edtDbServer.Location = new System.Drawing.Point(29, 42);
            this.edtDbServer.Name = "edtDbServer";
            this.edtDbServer.Size = new System.Drawing.Size(233, 20);
            this.edtDbServer.TabIndex = 0;
            // 
            // lblDbServerCap
            // 
            this.lblDbServerCap.AutoSize = true;
            this.lblDbServerCap.Location = new System.Drawing.Point(26, 26);
            this.lblDbServerCap.Name = "lblDbServerCap";
            this.lblDbServerCap.Size = new System.Drawing.Size(66, 13);
            this.lblDbServerCap.TabIndex = 0;
            this.lblDbServerCap.Text = "Сервер БД:";
            // 
            // imlDBAnimation
            // 
            this.imlDBAnimation.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlDBAnimation.ImageStream")));
            this.imlDBAnimation.TransparentColor = System.Drawing.Color.Transparent;
            this.imlDBAnimation.Images.SetKeyName(0, "линия в движении01.png");
            this.imlDBAnimation.Images.SetKeyName(1, "линия в движении02.png");
            this.imlDBAnimation.Images.SetKeyName(2, "линия в движении03.png");
            this.imlDBAnimation.Images.SetKeyName(3, "линия в движении04.png");
            this.imlDBAnimation.Images.SetKeyName(4, "линия в движении05.png");
            this.imlDBAnimation.Images.SetKeyName(5, "линия в движении06.png");
            this.imlDBAnimation.Images.SetKeyName(6, "линия в движении07.png");
            this.imlDBAnimation.Images.SetKeyName(7, "линия в движении08.png");
            this.imlDBAnimation.Images.SetKeyName(8, "линия в движении09.png");
            this.imlDBAnimation.Images.SetKeyName(9, "линия в движении10.png");
            this.imlDBAnimation.Images.SetKeyName(10, "линия в движении11.png");
            this.imlDBAnimation.Images.SetKeyName(11, "линия в движении12.png");
            // 
            // timDbAnimation
            // 
            this.timDbAnimation.Tick += new System.EventHandler(this.timDbAnimation_Tick);
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnSetDbCredentials);
            this.panTop.Controls.Add(this.btnSelectDestination);
            this.panTop.Controls.Add(this.btnSelectFiles);
            this.panTop.Controls.Add(this.btnStart);
            this.panTop.Location = new System.Drawing.Point(19, 26);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(624, 28);
            this.panTop.TabIndex = 7;
            // 
            // btnSetDbCredentials
            // 
            this.btnSetDbCredentials.Location = new System.Drawing.Point(243, 2);
            this.btnSetDbCredentials.Name = "btnSetDbCredentials";
            this.btnSetDbCredentials.Size = new System.Drawing.Size(114, 23);
            this.btnSetDbCredentials.TabIndex = 3;
            this.btnSetDbCredentials.Text = "Параметры БД";
            this.btnSetDbCredentials.UseVisualStyleBackColor = true;
            this.btnSetDbCredentials.Click += new System.EventHandler(this.btnSetDbCredentials_Click);
            // 
            // btnDbApplySettings
            // 
            this.btnDbApplySettings.Location = new System.Drawing.Point(29, 244);
            this.btnDbApplySettings.Name = "btnDbApplySettings";
            this.btnDbApplySettings.Size = new System.Drawing.Size(114, 23);
            this.btnDbApplySettings.TabIndex = 4;
            this.btnDbApplySettings.Text = "Применить";
            this.btnDbApplySettings.UseVisualStyleBackColor = true;
            this.btnDbApplySettings.Click += new System.EventHandler(this.btnDbApplySettings_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 414);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.tabMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Копировщик файлов";
            ((System.ComponentModel.ISupportInitialize)(this.gridFileList)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pagFileListToCopy.ResumeLayout(false);
            this.pagFileListToCopy.PerformLayout();
            this.pagCopyResult.ResumeLayout(false);
            this.pagCopyResult.PerformLayout();
            this.pagDbOpAnimation.ResumeLayout(false);
            this.pagDbOpAnimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDbAnimation)).EndInit();
            this.pagCopyProgress.ResumeLayout(false);
            this.pagCopyProgress.PerformLayout();
            this.pagDbCredentials.ResumeLayout(false);
            this.pagDbCredentials.PerformLayout();
            this.panTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.Button btnSelectDestination;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView gridFileList;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.ProgressBar prgTotalFiles;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.ProgressBar prgCurrentFile;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblCurrentFileName;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblTotalTimeCap;
        private System.Windows.Forms.Label lblTotalProgressCap;
        private System.Windows.Forms.Label lblDestinationCap;
        private System.Windows.Forms.Timer timProgress;
        private System.Windows.Forms.Label lblCurrentFilePercents;
        private System.Windows.Forms.Label lblTotalFilesPercents;
        private System.Windows.Forms.Label lblFilesCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopyTime;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pagCopyResult;
        private System.Windows.Forms.TabPage pagDbOpAnimation;
        private System.Windows.Forms.TabPage pagFileListToCopy;
        private System.Windows.Forms.ListBox lbFilesToCopy;
        private System.Windows.Forms.PictureBox picDbAnimation;
        private System.Windows.Forms.Label lblAniDbConnection;
        private System.Windows.Forms.TabPage pagCopyProgress;
        private System.Windows.Forms.ImageList imlDBAnimation;
        private System.Windows.Forms.Timer timDbAnimation;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Label lblDestination1;
        private System.Windows.Forms.Label lblDestinationCap1;
        private System.Windows.Forms.Label lblFilesToCopyCap;
        private System.Windows.Forms.Label lblCopyResultCap;
        private System.Windows.Forms.TabPage pagDbCredentials;
        private System.Windows.Forms.TextBox edtDbPassword;
        private System.Windows.Forms.TextBox edtDbCatalog;
        private System.Windows.Forms.Label lblDbCatalogCap;
        private System.Windows.Forms.Label lblDbPasswordCap;
        private System.Windows.Forms.TextBox edtDbUser;
        private System.Windows.Forms.Label lblDbUserCap;
        private System.Windows.Forms.TextBox edtDbServer;
        private System.Windows.Forms.Label lblDbServerCap;
        private System.Windows.Forms.Button btnSetDbCredentials;
        private System.Windows.Forms.Button btnDbApplySettings;

    }
}

