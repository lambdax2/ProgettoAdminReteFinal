namespace ProgettoAdminReteFinal
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.zgAcc = new ZedGraph.ZedGraphControl();
            this.zgGir = new ZedGraph.ZedGraphControl();
            this.zgMag = new ZedGraph.ZedGraphControl();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.bStartStop = new System.Windows.Forms.Button();
            this.bSettings = new System.Windows.Forms.Button();
            this.bExport = new System.Windows.Forms.Button();
            this.bAddGraphs = new System.Windows.Forms.Button();
            this.cbPelvis = new System.Windows.Forms.CheckBox();
            this.cbLeftAnkle = new System.Windows.Forms.CheckBox();
            this.cbRightAnkle = new System.Windows.Forms.CheckBox();
            this.cbLeftWrist = new System.Windows.Forms.CheckBox();
            this.cbRightWrist = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTurnStartStopShow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // zgAcc
            // 
            this.zgAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zgAcc.Location = new System.Drawing.Point(279, 12);
            this.zgAcc.Name = "zgAcc";
            this.zgAcc.ScrollGrace = 0D;
            this.zgAcc.ScrollMaxX = 0D;
            this.zgAcc.ScrollMaxY = 0D;
            this.zgAcc.ScrollMaxY2 = 0D;
            this.zgAcc.ScrollMinX = 0D;
            this.zgAcc.ScrollMinY = 0D;
            this.zgAcc.ScrollMinY2 = 0D;
            this.zgAcc.Size = new System.Drawing.Size(955, 213);
            this.zgAcc.TabIndex = 0;
            this.zgAcc.TabStop = false;
            // 
            // zgGir
            // 
            this.zgGir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zgGir.Location = new System.Drawing.Point(279, 241);
            this.zgGir.Name = "zgGir";
            this.zgGir.ScrollGrace = 0D;
            this.zgGir.ScrollMaxX = 0D;
            this.zgGir.ScrollMaxY = 0D;
            this.zgGir.ScrollMaxY2 = 0D;
            this.zgGir.ScrollMinX = 0D;
            this.zgGir.ScrollMinY = 0D;
            this.zgGir.ScrollMinY2 = 0D;
            this.zgGir.Size = new System.Drawing.Size(955, 213);
            this.zgGir.TabIndex = 1;
            this.zgGir.TabStop = false;
            // 
            // zgMag
            // 
            this.zgMag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zgMag.Location = new System.Drawing.Point(279, 470);
            this.zgMag.Name = "zgMag";
            this.zgMag.ScrollGrace = 0D;
            this.zgMag.ScrollMaxX = 0D;
            this.zgMag.ScrollMaxY = 0D;
            this.zgMag.ScrollMaxY2 = 0D;
            this.zgMag.ScrollMinX = 0D;
            this.zgMag.ScrollMinY = 0D;
            this.zgMag.ScrollMinY2 = 0D;
            this.zgMag.Size = new System.Drawing.Size(955, 213);
            this.zgMag.TabIndex = 2;
            this.zgMag.TabStop = false;
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbLog.Location = new System.Drawing.Point(8, 40);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(265, 640);
            this.tbLog.TabIndex = 4;
            this.tbLog.TabStop = false;
            // 
            // bStartStop
            // 
            this.bStartStop.Location = new System.Drawing.Point(8, 8);
            this.bStartStop.Name = "bStartStop";
            this.bStartStop.Size = new System.Drawing.Size(80, 24);
            this.bStartStop.TabIndex = 0;
            this.bStartStop.Text = "start";
            this.bStartStop.UseVisualStyleBackColor = true;
            // 
            // bSettings
            // 
            this.bSettings.Location = new System.Drawing.Point(8, 688);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(80, 24);
            this.bSettings.TabIndex = 3;
            this.bSettings.Text = "settings";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // bExport
            // 
            this.bExport.Enabled = false;
            this.bExport.Location = new System.Drawing.Point(192, 688);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(80, 24);
            this.bExport.TabIndex = 4;
            this.bExport.Text = "export";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // bAddGraphs
            // 
            this.bAddGraphs.Location = new System.Drawing.Point(100, 8);
            this.bAddGraphs.Name = "bAddGraphs";
            this.bAddGraphs.Size = new System.Drawing.Size(80, 24);
            this.bAddGraphs.TabIndex = 1;
            this.bAddGraphs.Text = "add. graphs";
            this.bAddGraphs.UseVisualStyleBackColor = true;
            this.bAddGraphs.Click += new System.EventHandler(this.bAddGraphs_Click);
            // 
            // cbPelvis
            // 
            this.cbPelvis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPelvis.AutoSize = true;
            this.cbPelvis.Checked = true;
            this.cbPelvis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPelvis.Location = new System.Drawing.Point(362, 696);
            this.cbPelvis.Name = "cbPelvis";
            this.cbPelvis.Size = new System.Drawing.Size(54, 17);
            this.cbPelvis.TabIndex = 6;
            this.cbPelvis.Text = "Pelvis";
            this.cbPelvis.UseVisualStyleBackColor = true;
            // 
            // cbLeftAnkle
            // 
            this.cbLeftAnkle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLeftAnkle.AutoSize = true;
            this.cbLeftAnkle.Checked = true;
            this.cbLeftAnkle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLeftAnkle.Location = new System.Drawing.Point(681, 696);
            this.cbLeftAnkle.Name = "cbLeftAnkle";
            this.cbLeftAnkle.Size = new System.Drawing.Size(74, 17);
            this.cbLeftAnkle.TabIndex = 10;
            this.cbLeftAnkle.Text = "Left Ankle";
            this.cbLeftAnkle.UseVisualStyleBackColor = true;
            // 
            // cbRightAnkle
            // 
            this.cbRightAnkle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRightAnkle.AutoSize = true;
            this.cbRightAnkle.Checked = true;
            this.cbRightAnkle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRightAnkle.Location = new System.Drawing.Point(592, 696);
            this.cbRightAnkle.Name = "cbRightAnkle";
            this.cbRightAnkle.Size = new System.Drawing.Size(81, 17);
            this.cbRightAnkle.TabIndex = 9;
            this.cbRightAnkle.Text = "Right Ankle";
            this.cbRightAnkle.UseVisualStyleBackColor = true;
            // 
            // cbLeftWrist
            // 
            this.cbLeftWrist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLeftWrist.AutoSize = true;
            this.cbLeftWrist.Checked = true;
            this.cbLeftWrist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLeftWrist.Location = new System.Drawing.Point(513, 696);
            this.cbLeftWrist.Name = "cbLeftWrist";
            this.cbLeftWrist.Size = new System.Drawing.Size(71, 17);
            this.cbLeftWrist.TabIndex = 8;
            this.cbLeftWrist.Text = "Left Wrist";
            this.cbLeftWrist.UseVisualStyleBackColor = true;
            // 
            // cbRightWrist
            // 
            this.cbRightWrist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRightWrist.Checked = true;
            this.cbRightWrist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRightWrist.Location = new System.Drawing.Point(424, 696);
            this.cbRightWrist.Name = "cbRightWrist";
            this.cbRightWrist.Size = new System.Drawing.Size(81, 17);
            this.cbRightWrist.TabIndex = 7;
            this.cbRightWrist.Text = "Right Wrist";
            this.cbRightWrist.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 698);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filtering :";
            // 
            // bReset
            // 
            this.bReset.Enabled = false;
            this.bReset.Location = new System.Drawing.Point(192, 8);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(80, 24);
            this.bReset.TabIndex = 2;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1096, 696);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Show turn start/stop";
            // 
            // cbTurnStartStopShow
            // 
            this.cbTurnStartStopShow.AutoSize = true;
            this.cbTurnStartStopShow.Enabled = false;
            this.cbTurnStartStopShow.Location = new System.Drawing.Point(1216, 696);
            this.cbTurnStartStopShow.Name = "cbTurnStartStopShow";
            this.cbTurnStartStopShow.Size = new System.Drawing.Size(15, 14);
            this.cbTurnStartStopShow.TabIndex = 12;
            this.cbTurnStartStopShow.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 725);
            this.Controls.Add(this.cbTurnStartStopShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRightWrist);
            this.Controls.Add(this.cbLeftWrist);
            this.Controls.Add(this.cbRightAnkle);
            this.Controls.Add(this.cbLeftAnkle);
            this.Controls.Add(this.cbPelvis);
            this.Controls.Add(this.bAddGraphs);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.bSettings);
            this.Controls.Add(this.bStartStop);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.zgMag);
            this.Controls.Add(this.zgGir);
            this.Controls.Add(this.zgAcc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Programmazione e amministrazione rete";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /**Graph displaying accelerometer data*/
        public ZedGraph.ZedGraphControl zgAcc;
        /**Graph displaying gyroscope data*/
        public ZedGraph.ZedGraphControl zgGir;
        /**Graph displaying magnetometer data*/
        public ZedGraph.ZedGraphControl zgMag;
        /**Log textbox*/
        public System.Windows.Forms.TextBox tbLog;
        /**Button to start/stop the server*/
        public System.Windows.Forms.Button bStartStop;
        /**Button to open setting form*/
        public System.Windows.Forms.Button bSettings;
        /**Button to open export form*/
        public System.Windows.Forms.Button bExport;
        /**Button to open additional graph form*/
        public System.Windows.Forms.Button bAddGraphs;
        /** @name checkGroup
        *  Checkboxes uset to show/hide lines in graphs.
        */
        ///@{
        private System.Windows.Forms.CheckBox cbPelvis;
        private System.Windows.Forms.CheckBox cbLeftAnkle;
        private System.Windows.Forms.CheckBox cbRightAnkle;
        private System.Windows.Forms.CheckBox cbLeftWrist;
        private System.Windows.Forms.CheckBox cbRightWrist;
        ///@} 
        private System.Windows.Forms.Label label1;
        /**Button to reset the server*/
        public System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Label label2;
        /**Button to show start and stop points of the turns (start is represented by a vertical blueviolet line, stop is represented by a vertical aqua line)*/
        public System.Windows.Forms.CheckBox cbTurnStartStopShow;
    }
}

