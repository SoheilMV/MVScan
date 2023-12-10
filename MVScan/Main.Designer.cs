namespace MVScan
{
    partial class Main
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
            this.btnIpRanges = new System.Windows.Forms.Button();
            this.btnPortRanges = new System.Windows.Forms.Button();
            this.listIpRanges = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.listPortRanges = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numBot = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblChecked = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblGood = new System.Windows.Forms.Label();
            this.lblBad = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCpm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIpRanges
            // 
            this.btnIpRanges.Location = new System.Drawing.Point(12, 27);
            this.btnIpRanges.Name = "btnIpRanges";
            this.btnIpRanges.Size = new System.Drawing.Size(118, 23);
            this.btnIpRanges.TabIndex = 0;
            this.btnIpRanges.Text = "Load IPs";
            this.btnIpRanges.UseVisualStyleBackColor = true;
            this.btnIpRanges.Click += new System.EventHandler(this.btnIpRanges_Click);
            // 
            // btnPortRanges
            // 
            this.btnPortRanges.Location = new System.Drawing.Point(12, 56);
            this.btnPortRanges.Name = "btnPortRanges";
            this.btnPortRanges.Size = new System.Drawing.Size(118, 23);
            this.btnPortRanges.TabIndex = 1;
            this.btnPortRanges.Text = "Load Ports";
            this.btnPortRanges.UseVisualStyleBackColor = true;
            this.btnPortRanges.Click += new System.EventHandler(this.btnPortRanges_Click);
            // 
            // listIpRanges
            // 
            this.listIpRanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listIpRanges.FullRowSelect = true;
            this.listIpRanges.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listIpRanges.Location = new System.Drawing.Point(136, 27);
            this.listIpRanges.MultiSelect = false;
            this.listIpRanges.Name = "listIpRanges";
            this.listIpRanges.Size = new System.Drawing.Size(359, 209);
            this.listIpRanges.TabIndex = 8;
            this.listIpRanges.UseCompatibleStateImageBehavior = false;
            this.listIpRanges.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "From";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "To";
            this.columnHeader2.Width = 160;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Ranges :";
            // 
            // listPortRanges
            // 
            this.listPortRanges.FormattingEnabled = true;
            this.listPortRanges.ItemHeight = 15;
            this.listPortRanges.Location = new System.Drawing.Point(136, 257);
            this.listPortRanges.Name = "listPortRanges";
            this.listPortRanges.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listPortRanges.Size = new System.Drawing.Size(359, 199);
            this.listPortRanges.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port Ranges :";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 85);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 114);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(118, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bot :";
            // 
            // numBot
            // 
            this.numBot.Location = new System.Drawing.Point(12, 162);
            this.numBot.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numBot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBot.Name = "numBot";
            this.numBot.Size = new System.Drawing.Size(118, 23);
            this.numBot.TabIndex = 5;
            this.numBot.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Timeout(ms) :";
            // 
            // numTimeout
            // 
            this.numTimeout.Location = new System.Drawing.Point(12, 206);
            this.numTimeout.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(118, 23);
            this.numTimeout.TabIndex = 6;
            this.numTimeout.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Change IP",
            "Change Port"});
            this.cboType.Location = new System.Drawing.Point(12, 250);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(118, 23);
            this.cboType.TabIndex = 7;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Type :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "IP :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Port :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Count :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(501, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Checked :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(501, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Good :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(501, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "Bad :";
            // 
            // lblChecked
            // 
            this.lblChecked.Location = new System.Drawing.Point(566, 113);
            this.lblChecked.Name = "lblChecked";
            this.lblChecked.Size = new System.Drawing.Size(97, 19);
            this.lblChecked.TabIndex = 10;
            this.lblChecked.Text = "0";
            this.lblChecked.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIp
            // 
            this.lblIp.Location = new System.Drawing.Point(530, 26);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(133, 19);
            this.lblIp.TabIndex = 10;
            this.lblIp.Text = "0";
            this.lblIp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(542, 55);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(121, 19);
            this.lblPort.TabIndex = 10;
            this.lblPort.Text = "0";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(553, 84);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(110, 19);
            this.lblCount.TabIndex = 10;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGood
            // 
            this.lblGood.Location = new System.Drawing.Point(549, 143);
            this.lblGood.Name = "lblGood";
            this.lblGood.Size = new System.Drawing.Size(114, 19);
            this.lblGood.TabIndex = 10;
            this.lblGood.Text = "0";
            this.lblGood.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBad
            // 
            this.lblBad.Location = new System.Drawing.Point(540, 172);
            this.lblBad.Name = "lblBad";
            this.lblBad.Size = new System.Drawing.Size(123, 19);
            this.lblBad.TabIndex = 10;
            this.lblBad.Text = "0";
            this.lblBad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(501, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "Elapsed :";
            // 
            // lblElapsed
            // 
            this.lblElapsed.Location = new System.Drawing.Point(560, 231);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(103, 19);
            this.lblElapsed.TabIndex = 10;
            this.lblElapsed.Text = "0";
            this.lblElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.pbProgress,
            this.lblProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(675, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 17);
            this.lblStatus.Text = "Status : -";
            // 
            // pbProgress
            // 
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // lblProgress
            // 
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(23, 17);
            this.lblProgress.Text = "0%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(501, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "CPM :";
            // 
            // lblCpm
            // 
            this.lblCpm.Location = new System.Drawing.Point(546, 203);
            this.lblCpm.Name = "lblCpm";
            this.lblCpm.Size = new System.Drawing.Size(117, 19);
            this.lblCpm.TabIndex = 10;
            this.lblCpm.Text = "0";
            this.lblCpm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 481);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblCpm);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.lblBad);
            this.Controls.Add(this.lblGood);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblChecked);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.numTimeout);
            this.Controls.Add(this.numBot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.listPortRanges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listIpRanges);
            this.Controls.Add(this.btnPortRanges);
            this.Controls.Add(this.btnIpRanges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MVScan | Port Scanner";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnIpRanges;
        private Button btnPortRanges;
        private ListView listIpRanges;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label label1;
        private ListBox listPortRanges;
        private Label label2;
        private Button btnStart;
        private Button btnStop;
        private Label label3;
        private NumericUpDown numBot;
        private Label label4;
        private NumericUpDown numTimeout;
        private ComboBox cboType;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label lblChecked;
        private Label lblIp;
        private Label lblPort;
        private Label lblCount;
        private Label lblGood;
        private Label lblBad;
        private System.Windows.Forms.Timer timer;
        private Label label12;
        private Label lblElapsed;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar pbProgress;
        private ToolStripStatusLabel lblProgress;
        private Label label13;
        private Label lblCpm;
    }
}