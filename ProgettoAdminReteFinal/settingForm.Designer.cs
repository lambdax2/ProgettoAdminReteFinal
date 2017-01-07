namespace ProgettoAdminReteFinal
{
    partial class settingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbIP1 = new System.Windows.Forms.TextBox();
            this.tbIP2 = new System.Windows.Forms.TextBox();
            this.tbIP3 = new System.Windows.Forms.TextBox();
            this.tbIP4 = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.cbFrequency = new System.Windows.Forms.ComboBox();
            this.nudSmoothWindow = new System.Windows.Forms.NumericUpDown();
            this.nudActivityWindow = new System.Windows.Forms.NumericUpDown();
            this.nudTurnWindow = new System.Windows.Forms.NumericUpDown();
            this.nudMinTurn = new System.Windows.Forms.NumericUpDown();
            this.nudTurnLimit = new System.Windows.Forms.NumericUpDown();
            this.gbConnectionSettings = new System.Windows.Forms.GroupBox();
            this.gbDataSettings = new System.Windows.Forms.GroupBox();
            this.nudStationingRound = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gbTurnSettings = new System.Windows.Forms.GroupBox();
            this.bApply = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmoothWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActivityWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurnWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurnLimit)).BeginInit();
            this.gbConnectionSettings.SuspendLayout();
            this.gbDataSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStationingRound)).BeginInit();
            this.gbTurnSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "frequency (Hz)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "smoothing data window";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "activity identification window";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "turn window";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "min turn value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "90°/180° turn limit";
            // 
            // tbIP1
            // 
            this.tbIP1.Location = new System.Drawing.Point(104, 27);
            this.tbIP1.Name = "tbIP1";
            this.tbIP1.Size = new System.Drawing.Size(33, 20);
            this.tbIP1.TabIndex = 1;
            this.tbIP1.Text = "127";
            this.tbIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIP2
            // 
            this.tbIP2.Location = new System.Drawing.Point(147, 27);
            this.tbIP2.Name = "tbIP2";
            this.tbIP2.Size = new System.Drawing.Size(33, 20);
            this.tbIP2.TabIndex = 2;
            this.tbIP2.Text = "0";
            this.tbIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIP3
            // 
            this.tbIP3.Location = new System.Drawing.Point(190, 27);
            this.tbIP3.Name = "tbIP3";
            this.tbIP3.Size = new System.Drawing.Size(33, 20);
            this.tbIP3.TabIndex = 3;
            this.tbIP3.Text = "0";
            this.tbIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIP4
            // 
            this.tbIP4.Location = new System.Drawing.Point(233, 27);
            this.tbIP4.Name = "tbIP4";
            this.tbIP4.Size = new System.Drawing.Size(33, 20);
            this.tbIP4.TabIndex = 4;
            this.tbIP4.Text = "1";
            this.tbIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(137, 34);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(10, 13);
            this.label.TabIndex = 12;
            this.label.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = ".";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(223, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = ".";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(104, 53);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(75, 20);
            this.tbPort.TabIndex = 5;
            this.tbPort.Text = "45555";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbFrequency
            // 
            this.cbFrequency.FormattingEnabled = true;
            this.cbFrequency.Items.AddRange(new object[] {
            "50",
            "100",
            "200"});
            this.cbFrequency.Location = new System.Drawing.Point(104, 80);
            this.cbFrequency.Name = "cbFrequency";
            this.cbFrequency.Size = new System.Drawing.Size(75, 21);
            this.cbFrequency.TabIndex = 6;
            this.cbFrequency.Text = "50";
            // 
            // nudSmoothWindow
            // 
            this.nudSmoothWindow.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSmoothWindow.Location = new System.Drawing.Point(183, 22);
            this.nudSmoothWindow.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudSmoothWindow.Name = "nudSmoothWindow";
            this.nudSmoothWindow.Size = new System.Drawing.Size(58, 20);
            this.nudSmoothWindow.TabIndex = 7;
            this.nudSmoothWindow.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // nudActivityWindow
            // 
            this.nudActivityWindow.Location = new System.Drawing.Point(183, 48);
            this.nudActivityWindow.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudActivityWindow.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudActivityWindow.Name = "nudActivityWindow";
            this.nudActivityWindow.Size = new System.Drawing.Size(58, 20);
            this.nudActivityWindow.TabIndex = 8;
            this.nudActivityWindow.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudTurnWindow
            // 
            this.nudTurnWindow.Location = new System.Drawing.Point(185, 25);
            this.nudTurnWindow.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTurnWindow.Name = "nudTurnWindow";
            this.nudTurnWindow.Size = new System.Drawing.Size(58, 20);
            this.nudTurnWindow.TabIndex = 10;
            this.nudTurnWindow.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // nudMinTurn
            // 
            this.nudMinTurn.DecimalPlaces = 2;
            this.nudMinTurn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMinTurn.Location = new System.Drawing.Point(185, 51);
            this.nudMinTurn.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMinTurn.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMinTurn.Name = "nudMinTurn";
            this.nudMinTurn.Size = new System.Drawing.Size(58, 20);
            this.nudMinTurn.TabIndex = 11;
            this.nudMinTurn.Value = new decimal(new int[] {
            170,
            0,
            0,
            131072});
            // 
            // nudTurnLimit
            // 
            this.nudTurnLimit.DecimalPlaces = 2;
            this.nudTurnLimit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudTurnLimit.Location = new System.Drawing.Point(185, 77);
            this.nudTurnLimit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTurnLimit.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudTurnLimit.Name = "nudTurnLimit";
            this.nudTurnLimit.Size = new System.Drawing.Size(58, 20);
            this.nudTurnLimit.TabIndex = 12;
            this.nudTurnLimit.Value = new decimal(new int[] {
            200,
            0,
            0,
            131072});
            // 
            // gbConnectionSettings
            // 
            this.gbConnectionSettings.Controls.Add(this.cbFrequency);
            this.gbConnectionSettings.Controls.Add(this.tbPort);
            this.gbConnectionSettings.Controls.Add(this.label1);
            this.gbConnectionSettings.Controls.Add(this.label2);
            this.gbConnectionSettings.Controls.Add(this.label3);
            this.gbConnectionSettings.Controls.Add(this.label10);
            this.gbConnectionSettings.Controls.Add(this.tbIP1);
            this.gbConnectionSettings.Controls.Add(this.tbIP2);
            this.gbConnectionSettings.Controls.Add(this.label9);
            this.gbConnectionSettings.Controls.Add(this.tbIP3);
            this.gbConnectionSettings.Controls.Add(this.tbIP4);
            this.gbConnectionSettings.Controls.Add(this.label);
            this.gbConnectionSettings.Location = new System.Drawing.Point(9, 12);
            this.gbConnectionSettings.Name = "gbConnectionSettings";
            this.gbConnectionSettings.Size = new System.Drawing.Size(278, 116);
            this.gbConnectionSettings.TabIndex = 22;
            this.gbConnectionSettings.TabStop = false;
            this.gbConnectionSettings.Text = "Connection Settings";
            // 
            // gbDataSettings
            // 
            this.gbDataSettings.Controls.Add(this.nudStationingRound);
            this.gbDataSettings.Controls.Add(this.label12);
            this.gbDataSettings.Controls.Add(this.label11);
            this.gbDataSettings.Controls.Add(this.nudActivityWindow);
            this.gbDataSettings.Controls.Add(this.nudSmoothWindow);
            this.gbDataSettings.Controls.Add(this.label5);
            this.gbDataSettings.Controls.Add(this.label4);
            this.gbDataSettings.Location = new System.Drawing.Point(9, 134);
            this.gbDataSettings.Name = "gbDataSettings";
            this.gbDataSettings.Size = new System.Drawing.Size(278, 109);
            this.gbDataSettings.TabIndex = 23;
            this.gbDataSettings.TabStop = false;
            this.gbDataSettings.Text = "Data Settings";
            // 
            // nudStationingRound
            // 
            this.nudStationingRound.DecimalPlaces = 2;
            this.nudStationingRound.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudStationingRound.Location = new System.Drawing.Point(183, 75);
            this.nudStationingRound.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudStationingRound.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147418112});
            this.nudStationingRound.Name = "nudStationingRound";
            this.nudStationingRound.Size = new System.Drawing.Size(58, 20);
            this.nudStationingRound.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(155, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "1 +";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "stationing round";
            // 
            // gbTurnSettings
            // 
            this.gbTurnSettings.Controls.Add(this.nudTurnLimit);
            this.gbTurnSettings.Controls.Add(this.nudMinTurn);
            this.gbTurnSettings.Controls.Add(this.nudTurnWindow);
            this.gbTurnSettings.Controls.Add(this.label8);
            this.gbTurnSettings.Controls.Add(this.label7);
            this.gbTurnSettings.Controls.Add(this.label6);
            this.gbTurnSettings.Location = new System.Drawing.Point(7, 249);
            this.gbTurnSettings.Name = "gbTurnSettings";
            this.gbTurnSettings.Size = new System.Drawing.Size(278, 111);
            this.gbTurnSettings.TabIndex = 24;
            this.gbTurnSettings.TabStop = false;
            this.gbTurnSettings.Text = "Turn Settings";
            // 
            // bApply
            // 
            this.bApply.Location = new System.Drawing.Point(163, 372);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(80, 24);
            this.bApply.TabIndex = 13;
            this.bApply.Text = "Apply";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(31, 372);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(80, 24);
            this.bCancel.TabIndex = 14;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // settingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 404);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.gbTurnSettings);
            this.Controls.Add(this.gbDataSettings);
            this.Controls.Add(this.gbConnectionSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "settingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSmoothWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActivityWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurnWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurnLimit)).EndInit();
            this.gbConnectionSettings.ResumeLayout(false);
            this.gbConnectionSettings.PerformLayout();
            this.gbDataSettings.ResumeLayout(false);
            this.gbDataSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStationingRound)).EndInit();
            this.gbTurnSettings.ResumeLayout(false);
            this.gbTurnSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbConnectionSettings;
        private System.Windows.Forms.GroupBox gbDataSettings;
        private System.Windows.Forms.GroupBox gbTurnSettings;

        /** @name ipGroup
        *  Ip textboxes.
        */
        ///@{
        private System.Windows.Forms.TextBox tbIP1;
        private System.Windows.Forms.TextBox tbIP2;
        private System.Windows.Forms.TextBox tbIP3;
        private System.Windows.Forms.TextBox tbIP4;
        ///@}
        /**Port textbox*/
        private System.Windows.Forms.TextBox tbPort;
        /**Combobox to chose frequency*/
        private System.Windows.Forms.ComboBox cbFrequency;
        /**Numeric up-down to increase/decrease smoothing window*/
        private System.Windows.Forms.NumericUpDown nudSmoothWindow;
        /**Numeric up-down to increase/decrease activity detection window*/
        private System.Windows.Forms.NumericUpDown nudActivityWindow;
        /**Numeric up-down to increase/decrease turn detection window*/ 
        private System.Windows.Forms.NumericUpDown nudTurnWindow;
        /**Numeric up-down to increase/decrease min turn value*/
        private System.Windows.Forms.NumericUpDown nudMinTurn;
        /**Numeric up-down to increase/decrease turn limit that divide under 90° turns from over 90° turns*/
        private System.Windows.Forms.NumericUpDown nudTurnLimit;
        /**Button to save settings*/
        private System.Windows.Forms.Button bApply;
        /**Button to cancel changes done*/
        private System.Windows.Forms.Button bCancel;
        /**Numeric up-down to increase/decrease the stationing round*/
        private System.Windows.Forms.NumericUpDown nudStationingRound;
    }
}