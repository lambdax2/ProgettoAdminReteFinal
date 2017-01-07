using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ProgettoAdminReteFinal
{
    /// <summary>
    /// Class dedicated to handle export related events and export operations
    /// </summary>
    public partial class exportForm : Form
    {
        public exportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allow user to chose the folder where we are going to export
        /// </summary>
        private void bBrowse_Click(object sender, EventArgs e)
        {
            //if user selects a new folder, update the save path
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.tbSavePath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Export log, graphs and a csv file of values into the folder chosen by the user with the bBrowse_Click method, by default C:\
        /// and add the subfolder named \\export_day_month_year_hour_minute\\
        /// </summary>
        private void bExport_Click(object sender, EventArgs e)
        {
            //savepath -> path to user selected folder(dafault C:\) + export folder name -> (\export_day_month_year_hour_minute)
            string _exportFolderName = "export_" + DateTime.Now.Date.Day + "_" + DateTime.Now.Date.Month + "_" + DateTime.Now.Date.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute;
            string _exportFolderPath = System.IO.Path.Combine(tbSavePath.Text , _exportFolderName);

            try
            {
                //check if directory already exist
                if (!Directory.Exists(_exportFolderPath))
                {
                    //if doesn't exist, create it!
                    Directory.CreateDirectory(_exportFolderPath);

                    //saving graphs as jpegs
                    Prog.mainForm.zedgraphAccelerometer.GraphPane.GetImage().Save(System.IO.Path.Combine(_exportFolderPath, "Acc.jpg"), ImageFormat.Jpeg);
                    Prog.mainForm.zedgraphGyroscope.GraphPane.GetImage().Save(System.IO.Path.Combine(_exportFolderPath, "Gir.jpg"), ImageFormat.Jpeg);
                    Prog.mainForm.zedgraphMagnetometer.GraphPane.GetImage().Save(System.IO.Path.Combine(_exportFolderPath, "Mag.jpg"), ImageFormat.Jpeg);
                    Prog.mainForm.agf.zedgraphStandardDeviation.GraphPane.GetImage().Save(System.IO.Path.Combine(_exportFolderPath, "AtdDev.jpg"), ImageFormat.Jpeg);
                    Prog.mainForm.agf.zedgraphAccelerometerXaxis.GraphPane.GetImage().Save(System.IO.Path.Combine(_exportFolderPath, "XAxis.jpg"), ImageFormat.Jpeg);
                    
                    //writing log to text file
                    using (StreamWriter sw = new StreamWriter(System.IO.Path.Combine(_exportFolderPath, "Log.txt"), true))
                        sw.Write(Prog.mainForm.tbLog.Text);

                    //save path for the csv
                    string _csvFileFullPath = System.IO.Path.Combine(_exportFolderPath, "Values.csv");
                    
                    //create values file
                    File.Create(_csvFileFullPath).Close();
                    
                    //setting var that will be used to write values to file
                    List<string[]> _output = new List<string[]>();
                    
                    //setting delimiter
                    string _delimiter = ";";

                    //data to be written is stored into a list containing arrays of strings: each array = 1 row of the csv
                    for (int k = 0; k < comHandler.nSensors; k++)
                    {
                        for (int i = 0; i < comHandler.rawAccelerometer[0].Count(); i++)
                        {
                            _output.Add(new string[]{comHandler.rawAccelerometer[k][i].X.ToString(),comHandler.rawAccelerometer[k][i].Y.ToString(),comHandler.rawAccelerometer[k][i].Z.ToString(),"",
                                                     comHandler.rawGyrometer[k][i].X.ToString(),comHandler.rawGyrometer[k][i].Y.ToString(),comHandler.rawGyrometer[k][i].Z.ToString(),"",
                                                     comHandler.rawMagnetometer[k][i].X.ToString(),comHandler.rawMagnetometer[k][i].Y.ToString(),comHandler.rawMagnetometer[k][i].Z.ToString(),"",
                                                     comHandler.accelerometer[k][i].Y.ToString(),comHandler.gyrometer[k][i].Y.ToString(),comHandler.magnetometer[k][i].Y.ToString(),
                                                     Environment.NewLine});
                        }
                    }

                    //writing output to file
                    using (System.IO.TextWriter writer = File.CreateText(_csvFileFullPath))
                    {
                        //header line
                        string[] _header = new string[] { "", "Raw acc", "", "", "", "Raw gyr", "", "", "", "Raw mag", "", "", "smoothed+moduled acc", "smoothed+moduled gyr", "smoothed+moduled mag", Environment.NewLine };
                        writer.WriteLine(string.Join(_delimiter, _header));

                        //write other data
                        for (int index = 0; index < _output.Count; index++)
                        {
                            writer.WriteLine(string.Join(_delimiter, _output[index]));
                        }
                    }

                    //export complete mesagebox
                    MessageBox.Show("Export completed", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DialogResult.Yes == MessageBox.Show("Open export folder?", "", MessageBoxButtons.YesNo))
                    {
                        System.Diagnostics.Process.Start(_exportFolderPath);
                    }
                }
                else {
                    //if folder already exists
                    MessageBox.Show("Folder already exists, please choose another folder", "failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Close();
            }
            catch (Exception except)
            {
                //exception raised
                MessageBox.Show("Failed to export : \r\n" + except.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// button cancel click event handler.
        /// </summary>
        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}