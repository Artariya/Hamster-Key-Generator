
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
            this.labelKeys = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelRequest = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelProccess = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarMain = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxProccessRandomDelay = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownProccess = new System.Windows.Forms.NumericUpDown();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageDleyas = new System.Windows.Forms.TabPage();
            this.tabPageProxy = new System.Windows.Forms.TabPage();
            this.radioButtonProxy1 = new System.Windows.Forms.RadioButton();
            this.radioButtonProxy2 = new System.Windows.Forms.RadioButton();
            this.radioButtonProxy3 = new System.Windows.Forms.RadioButton();
            this.groupBoxProxy = new System.Windows.Forms.GroupBox();
            this.groupBoxSocks5 = new System.Windows.Forms.GroupBox();
            this.groupBoxHttp = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSocks5Host = new System.Windows.Forms.TextBox();
            this.textBoxSocks5Port = new System.Windows.Forms.TextBox();
            this.textBoxHttpHost = new System.Windows.Forms.TextBox();
            this.textBoxHttpPort = new System.Windows.Forms.TextBox();
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
            this.groupBoxSocks5.SuspendLayout();
            this.groupBoxHttp.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.Location = new System.Drawing.Point(382, 19);
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
            this.comboBoxGames.Size = new System.Drawing.Size(215, 21);
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
            this.numericUpDownCount.Location = new System.Drawing.Point(230, 18);
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
            this.label2.Location = new System.Drawing.Point(227, 2);
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
            this.richTextBoxLogs.Size = new System.Drawing.Size(451, 244);
            this.richTextBoxLogs.TabIndex = 6;
            this.richTextBoxLogs.Text = "";
            this.richTextBoxLogs.WordWrap = false;
            // 
            // buttonCopyAll
            // 
            this.buttonCopyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyAll.Location = new System.Drawing.Point(370, 48);
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
            this.buttonCopy.Location = new System.Drawing.Point(370, 19);
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
            this.listBoxKeys.Size = new System.Drawing.Size(358, 82);
            this.listBoxKeys.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarMain,
            this.labelKeys,
            this.labelRequest,
            this.labelProccess});
            this.statusStrip1.Location = new System.Drawing.Point(0, 437);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(471, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
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
            // toolStripProgressBarMain
            // 
            this.toolStripProgressBarMain.Name = "toolStripProgressBarMain";
            this.toolStripProgressBarMain.Size = new System.Drawing.Size(200, 16);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSettings.Controls.Add(this.listBoxKeys);
            this.groupBoxSettings.Controls.Add(this.buttonCopy);
            this.groupBoxSettings.Controls.Add(this.buttonCopyAll);
            this.groupBoxSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxSettings.Location = new System.Drawing.Point(6, 294);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(451, 111);
            this.groupBoxSettings.TabIndex = 15;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Keys and settings";
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
            this.label4.Location = new System.Drawing.Point(303, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Proccess";
            // 
            // numericUpDownProccess
            // 
            this.numericUpDownProccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownProccess.Location = new System.Drawing.Point(306, 18);
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
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(471, 437);
            this.tabControlMain.TabIndex = 18;
            // 
            // tabPageMain
            // 
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
            this.tabPageMain.Size = new System.Drawing.Size(463, 411);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tabPageDleyas
            // 
            this.tabPageDleyas.Controls.Add(this.checkBoxProccessRandomDelay);
            this.tabPageDleyas.Controls.Add(this.label3);
            this.tabPageDleyas.Controls.Add(this.numericUpDownMinimumDelay);
            this.tabPageDleyas.Location = new System.Drawing.Point(4, 22);
            this.tabPageDleyas.Name = "tabPageDleyas";
            this.tabPageDleyas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDleyas.Size = new System.Drawing.Size(463, 411);
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
            this.tabPageProxy.Size = new System.Drawing.Size(463, 411);
            this.tabPageProxy.TabIndex = 2;
            this.tabPageProxy.Text = "Proxy";
            this.tabPageProxy.UseVisualStyleBackColor = true;
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
            // 
            // radioButtonProxy2
            // 
            this.radioButtonProxy2.AutoSize = true;
            this.radioButtonProxy2.Location = new System.Drawing.Point(6, 42);
            this.radioButtonProxy2.Name = "radioButtonProxy2";
            this.radioButtonProxy2.Size = new System.Drawing.Size(61, 17);
            this.radioButtonProxy2.TabIndex = 1;
            this.radioButtonProxy2.Text = "Socks5";
            this.radioButtonProxy2.UseVisualStyleBackColor = true;
            this.radioButtonProxy2.CheckedChanged += new System.EventHandler(this.radioButtonProxy2_CheckedChanged);
            // 
            // radioButtonProxy3
            // 
            this.radioButtonProxy3.AutoSize = true;
            this.radioButtonProxy3.Location = new System.Drawing.Point(6, 171);
            this.radioButtonProxy3.Name = "radioButtonProxy3";
            this.radioButtonProxy3.Size = new System.Drawing.Size(54, 17);
            this.radioButtonProxy3.TabIndex = 2;
            this.radioButtonProxy3.Text = "HTTP";
            this.radioButtonProxy3.UseVisualStyleBackColor = true;
            this.radioButtonProxy3.CheckedChanged += new System.EventHandler(this.radioButtonProxy3_CheckedChanged);
            // 
            // groupBoxProxy
            // 
            this.groupBoxProxy.Controls.Add(this.groupBoxHttp);
            this.groupBoxProxy.Controls.Add(this.groupBoxSocks5);
            this.groupBoxProxy.Controls.Add(this.radioButtonProxy1);
            this.groupBoxProxy.Controls.Add(this.radioButtonProxy3);
            this.groupBoxProxy.Controls.Add(this.radioButtonProxy2);
            this.groupBoxProxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProxy.Location = new System.Drawing.Point(3, 3);
            this.groupBoxProxy.Name = "groupBoxProxy";
            this.groupBoxProxy.Size = new System.Drawing.Size(457, 405);
            this.groupBoxProxy.TabIndex = 3;
            this.groupBoxProxy.TabStop = false;
            this.groupBoxProxy.Text = "Proxy settings";
            // 
            // groupBoxSocks5
            // 
            this.groupBoxSocks5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSocks5.Controls.Add(this.textBoxSocks5Port);
            this.groupBoxSocks5.Controls.Add(this.textBoxSocks5Host);
            this.groupBoxSocks5.Controls.Add(this.label6);
            this.groupBoxSocks5.Controls.Add(this.label5);
            this.groupBoxSocks5.Enabled = false;
            this.groupBoxSocks5.Location = new System.Drawing.Point(6, 65);
            this.groupBoxSocks5.Name = "groupBoxSocks5";
            this.groupBoxSocks5.Size = new System.Drawing.Size(445, 100);
            this.groupBoxSocks5.TabIndex = 3;
            this.groupBoxSocks5.TabStop = false;
            this.groupBoxSocks5.Text = "Socks5 Settings";
            // 
            // groupBoxHttp
            // 
            this.groupBoxHttp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHttp.Controls.Add(this.textBoxHttpPort);
            this.groupBoxHttp.Controls.Add(this.textBoxHttpHost);
            this.groupBoxHttp.Controls.Add(this.label8);
            this.groupBoxHttp.Controls.Add(this.label7);
            this.groupBoxHttp.Enabled = false;
            this.groupBoxHttp.Location = new System.Drawing.Point(6, 194);
            this.groupBoxHttp.Name = "groupBoxHttp";
            this.groupBoxHttp.Size = new System.Drawing.Size(445, 100);
            this.groupBoxHttp.TabIndex = 4;
            this.groupBoxHttp.TabStop = false;
            this.groupBoxHttp.Text = "HTTP Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Host";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Host";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(188, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Port";
            // 
            // textBoxSocks5Host
            // 
            this.textBoxSocks5Host.Location = new System.Drawing.Point(9, 32);
            this.textBoxSocks5Host.Name = "textBoxSocks5Host";
            this.textBoxSocks5Host.Size = new System.Drawing.Size(176, 20);
            this.textBoxSocks5Host.TabIndex = 2;
            this.textBoxSocks5Host.Text = "127.0.0.1";
            // 
            // textBoxSocks5Port
            // 
            this.textBoxSocks5Port.Location = new System.Drawing.Point(191, 32);
            this.textBoxSocks5Port.Name = "textBoxSocks5Port";
            this.textBoxSocks5Port.Size = new System.Drawing.Size(78, 20);
            this.textBoxSocks5Port.TabIndex = 3;
            this.textBoxSocks5Port.Text = "1080";
            // 
            // textBoxHttpHost
            // 
            this.textBoxHttpHost.Location = new System.Drawing.Point(9, 32);
            this.textBoxHttpHost.Name = "textBoxHttpHost";
            this.textBoxHttpHost.Size = new System.Drawing.Size(176, 20);
            this.textBoxHttpHost.TabIndex = 2;
            this.textBoxHttpHost.Text = "127.0.0.1";
            // 
            // textBoxHttpPort
            // 
            this.textBoxHttpPort.Location = new System.Drawing.Point(191, 32);
            this.textBoxHttpPort.Name = "textBoxHttpPort";
            this.textBoxHttpPort.Size = new System.Drawing.Size(78, 20);
            this.textBoxHttpPort.TabIndex = 3;
            this.textBoxHttpPort.Text = "80";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 459);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Hamster Key Generator v1.2.0";
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
            this.groupBoxSocks5.ResumeLayout(false);
            this.groupBoxSocks5.PerformLayout();
            this.groupBoxHttp.ResumeLayout(false);
            this.groupBoxHttp.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxHttp;
        private System.Windows.Forms.TextBox textBoxHttpPort;
        private System.Windows.Forms.TextBox textBoxHttpHost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxSocks5;
        private System.Windows.Forms.TextBox textBoxSocks5Port;
        private System.Windows.Forms.TextBox textBoxSocks5Host;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonProxy1;
        private System.Windows.Forms.RadioButton radioButtonProxy3;
        private System.Windows.Forms.RadioButton radioButtonProxy2;
    }
}

