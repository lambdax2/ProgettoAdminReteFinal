namespace ProgettoAdminReteFinal
{
    partial class exportForm
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
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.bExport = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSavePath
            // 
            this.tbSavePath.Location = new System.Drawing.Point(8, 16);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(300, 20);
            this.tbSavePath.TabIndex = 0;
            this.tbSavePath.Text = "C:\\";
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(316, 16);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(23, 20);
            this.bBrowse.TabIndex = 1;
            this.bBrowse.Text = "...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(192, 48);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(80, 24);
            this.bExport.TabIndex = 2;
            this.bExport.Text = "Export";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(91, 48);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(80, 24);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // exportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 78);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.tbSavePath);
            this.MaximizeBox = false;
            this.Name = "exportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Export Path";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /**Path where images of graphs, log and file with values will be exported*/
        private System.Windows.Forms.TextBox tbSavePath;
        /**Button to open folder browser*/
        private System.Windows.Forms.Button bBrowse;
        /**Button to start the export process*/
        private System.Windows.Forms.Button bExport;
        /**Dialog used to select the export folder*/
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        /**Button to cancel the export*/
        private System.Windows.Forms.Button bCancel;
    }
}