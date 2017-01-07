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
            this.zgStdDev = new ZedGraph.ZedGraphControl();
            this.zgXAxis = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zgStdDev
            // 
            this.zgStdDev.Location = new System.Drawing.Point(12, 12);
            this.zgStdDev.Name = "zgStdDev";
            this.zgStdDev.ScrollGrace = 0D;
            this.zgStdDev.ScrollMaxX = 0D;
            this.zgStdDev.ScrollMaxY = 0D;
            this.zgStdDev.ScrollMaxY2 = 0D;
            this.zgStdDev.ScrollMinX = 0D;
            this.zgStdDev.ScrollMinY = 0D;
            this.zgStdDev.ScrollMinY2 = 0D;
            this.zgStdDev.Size = new System.Drawing.Size(765, 162);
            this.zgStdDev.TabIndex = 0;
            this.zgStdDev.TabStop = false;
            // 
            // zgXAxis
            // 
            this.zgXAxis.Location = new System.Drawing.Point(12, 191);
            this.zgXAxis.Name = "zgXAxis";
            this.zgXAxis.ScrollGrace = 0D;
            this.zgXAxis.ScrollMaxX = 0D;
            this.zgXAxis.ScrollMaxY = 0D;
            this.zgXAxis.ScrollMaxY2 = 0D;
            this.zgXAxis.ScrollMinX = 0D;
            this.zgXAxis.ScrollMinY = 0D;
            this.zgXAxis.ScrollMinY2 = 0D;
            this.zgXAxis.Size = new System.Drawing.Size(765, 162);
            this.zgXAxis.TabIndex = 1;
            this.zgXAxis.TabStop = false;
            // 
            // addGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 367);
            this.Controls.Add(this.zgXAxis);
            this.Controls.Add(this.zgStdDev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "addGraphForm";
            this.Text = "Additional Graphs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.addGraphForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        /**Graph representing standard deviation*/
        public ZedGraph.ZedGraphControl zgStdDev;
        /**Graph representing pelvis accelerometer x axis values*/ 
        public ZedGraph.ZedGraphControl zgXAxis;
    }
}