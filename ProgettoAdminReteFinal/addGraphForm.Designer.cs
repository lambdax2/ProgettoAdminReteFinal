namespace ProgettoAdminReteFinal
{
    partial class addGraphForm
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
            this.zedgraphStandardDeviation = new ZedGraph.ZedGraphControl();
            this.zedgraphAccelerometerXaxis = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zgStdDev
            // 
            this.zedgraphStandardDeviation.Location = new System.Drawing.Point(12, 12);
            this.zedgraphStandardDeviation.Name = "zgStdDev";
            this.zedgraphStandardDeviation.ScrollGrace = 0D;
            this.zedgraphStandardDeviation.ScrollMaxX = 0D;
            this.zedgraphStandardDeviation.ScrollMaxY = 0D;
            this.zedgraphStandardDeviation.ScrollMaxY2 = 0D;
            this.zedgraphStandardDeviation.ScrollMinX = 0D;
            this.zedgraphStandardDeviation.ScrollMinY = 0D;
            this.zedgraphStandardDeviation.ScrollMinY2 = 0D;
            this.zedgraphStandardDeviation.Size = new System.Drawing.Size(765, 162);
            this.zedgraphStandardDeviation.TabIndex = 0;
            this.zedgraphStandardDeviation.TabStop = false;
            // 
            // zgXAxis
            // 
            this.zedgraphAccelerometerXaxis.Location = new System.Drawing.Point(12, 191);
            this.zedgraphAccelerometerXaxis.Name = "zgXAxis";
            this.zedgraphAccelerometerXaxis.ScrollGrace = 0D;
            this.zedgraphAccelerometerXaxis.ScrollMaxX = 0D;
            this.zedgraphAccelerometerXaxis.ScrollMaxY = 0D;
            this.zedgraphAccelerometerXaxis.ScrollMaxY2 = 0D;
            this.zedgraphAccelerometerXaxis.ScrollMinX = 0D;
            this.zedgraphAccelerometerXaxis.ScrollMinY = 0D;
            this.zedgraphAccelerometerXaxis.ScrollMinY2 = 0D;
            this.zedgraphAccelerometerXaxis.Size = new System.Drawing.Size(765, 162);
            this.zedgraphAccelerometerXaxis.TabIndex = 1;
            this.zedgraphAccelerometerXaxis.TabStop = false;
            // 
            // addGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 367);
            this.Controls.Add(this.zedgraphAccelerometerXaxis);
            this.Controls.Add(this.zedgraphStandardDeviation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "addGraphForm";
            this.Text = "Additional Graphs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.addGraphForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        /**Graph representing standard deviation*/
        public ZedGraph.ZedGraphControl zedgraphStandardDeviation;
        /**Graph representing pelvis accelerometer x axis values*/ 
        public ZedGraph.ZedGraphControl zedgraphAccelerometerXaxis;
    }
}