
namespace Hamster_Key_Generator
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.comboBoxGames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.buttonCopyAll = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDownMinimumDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxKeys = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarMain = new System.Windows.Forms.ToolStripProgressBar();
            this.labelKeys = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelRequest = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelProccess = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.buttonExportKeys = new System.Windows.Forms.Button();
            this.checkBoxProccessRandomDelay = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownProccess = new System.Windows.Forms.NumericUpDown();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.tabPageDleyas = new System.Windows.Forms.TabPage();
            this.tabPageProxy = new System.Windows.Forms.TabPage();
            this.groupBoxProxy = new System.Windows.Forms.GroupBox();
            this.checkBoxRemoveBadProxy = new System.Windows.Forms.CheckBox();
            this.numericUpDownTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxProxies = new System.Windows.Forms.GroupBox();
            this.buttonProxyRemove = new System.Windows.Forms.Button();
            this.buttonProxyAdd = new System.Windows.Forms.Button();
            this.comboBoxProxyType = new System.Windows.Forms.ComboBox();
            this.textBoxProxyPort = new System.Windows.Forms.TextBox();
            this.textBoxProxyHost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxProxies = new System.Windows.Forms.ListBox();
            this.radioButtonProxy1 = new System.Windows.Forms.RadioButton();
            this.radioButtonProxy2 = new System.Windows.Forms.RadioButton();
            this.tabPageDataBase = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.buttonGithub = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinimumDelay)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProccess)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageDleyas.SuspendLayout();
            this.tabPageProxy.SuspendLayout();
            this.groupBoxProxy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeOut)).BeginInit();
            this.groupBoxProxies.SuspendLayout();
            this.tabPageDataBase.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.Location = new System.Drawing.Point(371, 17);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // comboBoxGames
            // 
            this.comboBoxGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGames.FormattingEnabled = true;
            this.comboBoxGames.Location = new System.Drawing.Point(9, 19);
            this.comboBoxGames.Name = "comboBoxGames";
            this.comboBoxGames.Size = new System.Drawing.Size(123, 21);
            this.comboBoxGames.TabIndex = 1;
            this.comboBoxGames.SelectedIndexChanged += new System.EventHandler(this.comboBoxGames_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Game";
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCount.Location = new System.Drawing.Point(219, 20);
            this.numericUpDownCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownCount.TabIndex = 4;
            this.numericUpDownCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Count";
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLogs.BackColor = System.Drawing.Color.Black;
            this.richTextBoxLogs.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLogs.ForeColor = System.Drawing.Color.White;
            this.richTextBoxLogs.Location = new System.Drawing.Point(6, 44);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.ReadOnly = true;
            this.richTextBoxLogs.Size = new System.Drawing.Size(440, 294);
            this.richTextBoxLogs.TabIndex = 6;
            this.richTextBoxLogs.Text = "";
            this.richTextBoxLogs.WordWrap = false;
            // 
            // buttonCopyAll
            // 
            this.buttonCopyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyAll.Location = new System.Drawing.Point(359, 48);
            this.buttonCopyAll.Name = "buttonCopyAll";
            this.buttonCopyAll.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyAll.TabIndex = 8;
            this.buttonCopyAll.Text = "Copy All";
            this.buttonCopyAll.UseVisualStyleBackColor = true;
            this.buttonCopyAll.Click += new System.EventHandler(this.buttonCopyAll_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopy.Location = new System.Drawing.Point(359, 19);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 9;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDownMinimumDelay
            // 
            this.numericUpDownMinimumDelay.Location = new System.Drawing.Point(9, 19);
            this.numericUpDownMinimumDelay.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownMinimumDelay.Name = "numericUpDownMinimumDelay";
            this.numericUpDownMinimumDelay.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMinimumDelay.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "MinimumDelay";
            // 
            // listBoxKeys
            // 
            this.listBoxKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxKeys.BackColor = System.Drawing.Color.Black;
            this.listBoxKeys.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxKeys.ForeColor = System.Drawing.Color.Lime;
            this.listBoxKeys.FormattingEnabled = true;
            this.listBoxKeys.Location = new System.Drawing.Point(6, 19);
            this.listBoxKeys.Name = "listBoxKeys";
            this.listBoxKeys.Size = new System.Drawing.Size(347, 82);
            this.listBoxKeys.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarMain,
            this.labelKeys,
            this.labelRequest,
            this.labelProccess});
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(460, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBarMain
            // 
            this.toolStripProgressBarMain.Name = "toolStripProgressBarMain";
            this.toolStripProgressBarMain.Size = new System.Drawing.Size(200, 16);
            // 
            // labelKeys
            // 
            this.labelKeys.Name = "labelKeys";
            this.labelKeys.Size = new System.Drawing.Size(10, 17);
            this.labelKeys.Text = " ";
            // 
            // labelRequest
            // 
            this.labelRequest.Name = "labelRequest";
            this.labelRequest.Size = new System.Drawing.Size(10, 17);
            this.labelRequest.Text = " ";
            // 
            // labelProccess
            // 
            this.labelProccess.Name = "labelProccess";
            this.labelProccess.Size = new System.Drawing.Size(10, 17);
            this.labelProccess.Text = " ";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSettings.Controls.Add(this.buttonExportKeys);
            this.groupBoxSettings.Controls.Add(this.listBoxKeys);
            this.groupBoxSettings.Controls.Add(this.buttonCopy);
            this.groupBoxSettings.Controls.Add(this.buttonCopyAll);
            this.groupBoxSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxSettings.Location = new System.Drawing.Point(6, 344);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(440, 111);
            this.groupBoxSettings.TabIndex = 15;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Keys and settings";
            // 
            // buttonExportKeys
            // 
            this.buttonExportKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportKeys.Location = new System.Drawing.Point(359, 77);
            this.buttonExportKeys.Name = "buttonExportKeys";
            this.buttonExportKeys.Size = new System.Drawing.Size(75, 23);
            this.buttonExportKeys.TabIndex = 10;
            this.buttonExportKeys.Text = "Export";
            this.buttonExportKeys.UseVisualStyleBackColor = true;
            this.buttonExportKeys.Click += new System.EventHandler(this.buttonExportKeys_Click);
            // 
            // checkBoxProccessRandomDelay
            // 
            this.checkBoxProccessRandomDelay.AutoSize = true;
            this.checkBoxProccessRandomDelay.Location = new System.Drawing.Point(135, 20);
            this.checkBoxProccessRandomDelay.Name = "checkBoxProccessRandomDelay";
            this.checkBoxProccessRandomDelay.Size = new System.Drawing.Size(182, 17);
            this.checkBoxProccessRandomDelay.TabIndex = 12;
            this.checkBoxProccessRandomDelay.Text = "Start proccess with random delay";
            this.checkBoxProccessRandomDelay.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Proccess";
            // 
            // numericUpDownProccess
            // 
            this.numericUpDownProccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownProccess.Location = new System.Drawing.Point(295, 20);
            this.numericUpDownProccess.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownProccess.Name = "numericUpDownProccess";
            this.numericUpDownProccess.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownProccess.TabIndex = 16;
            this.numericUpDownProccess.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageMain);
            this.tabControlMain.Controls.Add(this.tabPageDleyas);
            this.tabControlMain.Controls.Add(this.tabPageProxy);
            this.tabControlMain.Controls.Add(this.tabPageDataBase);
            this.tabControlMain.Controls.Add(this.tabPageInfo);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(460, 487);
            this.tabControlMain.TabIndex = 18;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.buttonUpdate);
            this.tabPageMain.Controls.Add(this.groupBoxSettings);
            this.tabPageMain.Controls.Add(this.label4);
            this.tabPageMain.Controls.Add(this.richTextBoxLogs);
            this.tabPageMain.Controls.Add(this.numericUpDownProccess);
            this.tabPageMain.Controls.Add(this.label1);
            this.tabPageMain.Controls.Add(this.buttonGenerate);
            this.tabPageMain.Controls.Add(this.label2);
            this.tabPageMain.Controls.Add(this.comboBoxGames);
            this.tabPageMain.Controls.Add(this.numericUpDownCount);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(452, 461);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.Location = new System.Drawing.Point(138, 17);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 18;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // tabPageDleyas
            // 
            this.tabPageDleyas.Controls.Add(this.checkBoxProccessRandomDelay);
            this.tabPageDleyas.Controls.Add(this.label3);
            this.tabPageDleyas.Controls.Add(this.numericUpDownMinimumDelay);
            this.tabPageDleyas.Location = new System.Drawing.Point(4, 22);
            this.tabPageDleyas.Name = "tabPageDleyas";
            this.tabPageDleyas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDleyas.Size = new System.Drawing.Size(452, 461);
            this.tabPageDleyas.TabIndex = 1;
            this.tabPageDleyas.Text = "Delays";
            this.tabPageDleyas.UseVisualStyleBackColor = true;
            // 
            // tabPageProxy
            // 
            this.tabPageProxy.Controls.Add(this.groupBoxProxy);
            this.tabPageProxy.Location = new System.Drawing.Point(4, 22);
            this.tabPageProxy.Name = "tabPageProxy";
            this.tabPageProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProxy.Size = new System.Drawing.Size(452, 461);
            this.tabPageProxy.TabIndex = 2;
            this.tabPageProxy.Text = "Proxy";
            this.tabPageProxy.UseVisualStyleBackColor = true;
            // 
            // groupBoxProxy
            // 
            this.groupBoxProxy.Controls.Add(this.checkBoxRemoveBadProxy);
            this.groupBoxProxy.Controls.Add(this.numericUpDownTimeOut);
            this.groupBoxProxy.Controls.Add(this.label8);
            this.groupBoxProxy.Controls.Add(this.groupBoxProxies);
            this.groupBoxProxy.Controls.Add(this.radioButtonProxy1);
            this.groupBoxProxy.Controls.Add(this.radioButtonProxy2);
            this.groupBoxProxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProxy.Location = new System.Drawing.Point(3, 3);
            this.groupBoxProxy.Name = "groupBoxProxy";
            this.groupBoxProxy.Size = new System.Drawing.Size(446, 455);
            this.groupBoxProxy.TabIndex = 3;
            this.groupBoxProxy.TabStop = false;
            this.groupBoxProxy.Text = "Proxy settings";
            // 
            // checkBoxRemoveBadProxy
            // 
            this.checkBoxRemoveBadProxy.AutoSize = true;
            this.checkBoxRemoveBadProxy.Checked = true;
            this.checkBoxRemoveBadProxy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRemoveBadProxy.Location = new System.Drawing.Point(176, 58);
            this.checkBoxRemoveBadProxy.Name = "checkBoxRemoveBadProxy";
            this.checkBoxRemoveBadProxy.Size = new System.Drawing.Size(123, 17);
            this.checkBoxRemoveBadProxy.TabIndex = 7;
            this.checkBoxRemoveBadProxy.Text = "Remove bad proxies";
            this.checkBoxRemoveBadProxy.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTimeOut
            // 
            this.numericUpDownTimeOut.Location = new System.Drawing.Point(176, 32);
            this.numericUpDownTimeOut.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDownTimeOut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimeOut.Name = "numericUpDownTimeOut";
            this.numericUpDownTimeOut.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTimeOut.TabIndex = 6;
            this.numericUpDownTimeOut.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Timeout limit (sec)";
            // 
            // groupBoxProxies
            // 
            this.groupBoxProxies.Controls.Add(this.buttonProxyRemove);
            this.groupBoxProxies.Controls.Add(this.buttonProxyAdd);
            this.groupBoxProxies.Controls.Add(this.comboBoxProxyType);
            this.groupBoxProxies.Controls.Add(this.textBoxProxyPort);
            this.groupBoxProxies.Controls.Add(this.textBoxProxyHost);
            this.groupBoxProxies.Controls.Add(this.label7);
            this.groupBoxProxies.Controls.Add(this.label6);
            this.groupBoxProxies.Controls.Add(this.label5);
            this.groupBoxProxies.Controls.Add(this.listBoxProxies);
            this.groupBoxProxies.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxProxies.Location = new System.Drawing.Point(3, 80);
            this.groupBoxProxies.Name = "groupBoxProxies";
            this.groupBoxProxies.Size = new System.Drawing.Size(440, 372);
            this.groupBoxProxies.TabIndex = 4;
            this.groupBoxProxies.TabStop = false;
            this.groupBoxProxies.Text = "Proxies";
            // 
            // buttonProxyRemove
            // 
            this.buttonProxyRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProxyRemove.Location = new System.Drawing.Point(359, 59);
            this.buttonProxyRemove.Name = "buttonProxyRemove";
            this.buttonProxyRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonProxyRemove.TabIndex = 9;
            this.buttonProxyRemove.Text = "Remove";
            this.buttonProxyRemove.UseVisualStyleBackColor = true;
            this.buttonProxyRemove.Click += new System.EventHandler(this.buttonProxyRemove_Click);
            // 
            // buttonProxyAdd
            // 
            this.buttonProxyAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProxyAdd.Location = new System.Drawing.Point(359, 30);
            this.buttonProxyAdd.Name = "buttonProxyAdd";
            this.buttonProxyAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonProxyAdd.TabIndex = 7;
            this.buttonProxyAdd.Text = "Add";
            this.buttonProxyAdd.UseVisualStyleBackColor = true;
            this.buttonProxyAdd.Click += new System.EventHandler(this.buttonProxyAdd_Click);
            // 
            // comboBoxProxyType
            // 
            this.comboBoxProxyType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProxyType.FormattingEnabled = true;
            this.comboBoxProxyType.Items.AddRange(new object[] {
            "Socks5",
            "Http"});
            this.comboBoxProxyType.Location = new System.Drawing.Point(245, 32);
            this.comboBoxProxyType.Name = "comboBoxProxyType";
            this.comboBoxProxyType.Size = new System.Drawing.Size(108, 21);
            this.comboBoxProxyType.TabIndex = 6;
            // 
            // textBoxProxyPort
            // 
            this.textBoxProxyPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProxyPort.Location = new System.Drawing.Point(173, 32);
            this.textBoxProxyPort.Name = "textBoxProxyPort";
            this.textBoxProxyPort.Size = new System.Drawing.Size(66, 20);
            this.textBoxProxyPort.TabIndex = 5;
            // 
            // textBoxProxyHost
            // 
            this.textBoxProxyHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProxyHost.Location = new System.Drawing.Point(6, 32);
            this.textBoxProxyHost.Name = "textBoxProxyHost";
            this.textBoxProxyHost.Size = new System.Drawing.Size(161, 20);
            this.textBoxProxyHost.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Type";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Host";
            // 
            // listBoxProxies
            // 
            this.listBoxProxies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxProxies.FormattingEnabled = true;
            this.listBoxProxies.Location = new System.Drawing.Point(6, 58);
            this.listBoxProxies.Name = "listBoxProxies";
            this.listBoxProxies.Size = new System.Drawing.Size(347, 290);
            this.listBoxProxies.TabIndex = 0;
            // 
            // radioButtonProxy1
            // 
            this.radioButtonProxy1.AutoSize = true;
            this.radioButtonProxy1.Checked = true;
            this.radioButtonProxy1.Location = new System.Drawing.Point(6, 19);
            this.radioButtonProxy1.Name = "radioButtonProxy1";
            this.radioButtonProxy1.Size = new System.Drawing.Size(67, 17);
            this.radioButtonProxy1.TabIndex = 0;
            this.radioButtonProxy1.TabStop = true;
            this.radioButtonProxy1.Text = "No proxy";
            this.radioButtonProxy1.UseVisualStyleBackColor = true;
            this.radioButtonProxy1.CheckedChanged += new System.EventHandler(this.radioButtonProxy1_CheckedChanged);
            // 
            // radioButtonProxy2
            // 
            this.radioButtonProxy2.AutoSize = true;
            this.radioButtonProxy2.Location = new System.Drawing.Point(6, 42);
            this.radioButtonProxy2.Name = "radioButtonProxy2";
            this.radioButtonProxy2.Size = new System.Drawing.Size(80, 17);
            this.radioButtonProxy2.TabIndex = 1;
            this.radioButtonProxy2.Text = "Auto switch";
            this.radioButtonProxy2.UseVisualStyleBackColor = true;
            this.radioButtonProxy2.CheckedChanged += new System.EventHandler(this.radioButtonProxy2_CheckedChanged);
            // 
            // tabPageDataBase
            // 
            this.tabPageDataBase.Controls.Add(this.label9);
            this.tabPageDataBase.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataBase.Name = "tabPageDataBase";
            this.tabPageDataBase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataBase.Size = new System.Drawing.Size(452, 461);
            this.tabPageDataBase.TabIndex = 3;
            this.tabPageDataBase.Text = "DataBase";
            this.tabPageDataBase.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Consolas", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(446, 455);
            this.label9.TabIndex = 0;
            this.label9.Text = "Coming soon";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.buttonGithub);
            this.tabPageInfo.Controls.Add(this.label10);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(452, 461);
            this.tabPageInfo.TabIndex = 4;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // buttonGithub
            // 
            this.buttonGithub.Location = new System.Drawing.Point(10, 26);
            this.buttonGithub.Name = "buttonGithub";
            this.buttonGithub.Size = new System.Drawing.Size(75, 23);
            this.buttonGithub.TabIndex = 1;
            this.buttonGithub.Text = "Github";
            this.buttonGithub.UseVisualStyleBackColor = true;
            this.buttonGithub.Click += new System.EventHandler(this.buttonGithub_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Created by Artaryia";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Hamster Key Generator";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.BalloonTipClicked += new System.EventHandler(this.notifyIconMain_BalloonTipClicked);
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseDoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 509);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Hamster Key Generator v1.4.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinimumDelay)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProccess)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageDleyas.ResumeLayout(false);
            this.tabPageDleyas.PerformLayout();
            this.tabPageProxy.ResumeLayout(false);
            this.groupBoxProxy.ResumeLayout(false);
            this.groupBoxProxy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeOut)).EndInit();
            this.groupBoxProxies.ResumeLayout(false);
            this.groupBoxProxies.PerformLayout();
            this.tabPageDataBase.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarMain;

        private System.Windows.Forms.TabPage tabPageProxy;

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageDleyas;

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.ComboBox comboBoxGames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxLogs;
        private System.Windows.Forms.Button buttonCopyAll;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDownMinimumDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxKeys;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelKeys;
        private System.Windows.Forms.ToolStripStatusLabel labelRequest;
        private System.Windows.Forms.ToolStripStatusLabel labelProccess;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownProccess;
        private System.Windows.Forms.CheckBox checkBoxProccessRandomDelay;
        private System.Windows.Forms.GroupBox groupBoxProxy;
        private System.Windows.Forms.RadioButton radioButtonProxy1;
        private System.Windows.Forms.RadioButton radioButtonProxy2;
        private System.Windows.Forms.Button buttonExportKeys;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.TabPage tabPageDataBase;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonGithub;
        private System.Windows.Forms.GroupBox groupBoxProxies;
        private System.Windows.Forms.Button buttonProxyRemove;
        private System.Windows.Forms.Button buttonProxyAdd;
        private System.Windows.Forms.ComboBox comboBoxProxyType;
        private System.Windows.Forms.TextBox textBoxProxyPort;
        private System.Windows.Forms.TextBox textBoxProxyHost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxProxies;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.CheckBox checkBoxRemoveBadProxy;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeOut;
        private System.Windows.Forms.Label label8;
    }
}

