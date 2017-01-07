using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using System.IO;

namespace ProgettoAdminReteFinal
{
    /// <summary>
    /// Class dedicated to handle main form events
    /// </summary>
    public partial class mainForm : Form
    {
        /**addGraphForm: form where user can find standard deviation and accelerometer x axis graphs*/
        public addGraphForm agf;

        public mainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When loading the main form we add all event handlers, create a new addgraphform and initialize graphs
        /// </summary>
        private void mainForm_Load(object sender, EventArgs e)
        {
            agf = new addGraphForm();

            //adding handler of startstop button click event
            buttonStartStop.Click += new EventHandler(comHandler.bStart_Click);
            //adding handlers of check boxes that allow the user to show/hide lines in graphs
            cbLeftAnkle.Click += new EventHandler(graphHandler.stateChanged);
            cbLeftWrist.Click += new EventHandler(graphHandler.stateChanged);
            cbPelvis.Click += new EventHandler(graphHandler.stateChanged);
            cbRightAnkle.Click += new EventHandler(graphHandler.stateChanged);
            cbRightWrist.Click += new EventHandler(graphHandler.stateChanged);
            //adding handler to check box used to show/hide turn start/stop recognition points
            comboboxTurnStartStopShow.Click += new EventHandler(graphHandler.cbTurnStartStopShow_stateChanged);

            //graphs init(multiple-line graphs)   control, title, xlabel, ylabel
            new graphHandler(zedgraphAccelerometer, "Accelerometer", "", "module");
            new graphHandler(zedgraphGyroscope, "Gyroscope"    , "", "module");
            new graphHandler(zedgraphMagnetometer, "Magnetometer" , "", "arctan");
            //graph init(single-line graphs)     control, title, xlabel, ylabel, curvename
            new graphHandler(agf.zedgraphStandardDeviation, "Standard Deviation",  "", "Dev Std", "devstd");
            new graphHandler(agf.zedgraphAccelerometerXaxis,  "Accelerometer X Axis","", "X",       "xaxis");
        }

        /// <summary>
        /// settings button click event handler
        /// </summary>
        private void bSettings_Click(object sender, EventArgs e)
        {
            //create new setting form
            settingForm _settings = new settingForm();
            //adding event handler form closing
            _settings.FormClosing += new FormClosingEventHandler(settingForm.serverSettings_OnClose);
            //showing setting form & disabling mainform
            _settings.Show();
            this.Enabled = false; //disabling main form, will be reenabled by onclose event of settingsform
        }

        /// <summary>
        /// Export button click event handler
        /// </summary>
        private void bExport_Click(object sender, EventArgs e)
        {
            //create export form & showing it
            exportForm _ef = new exportForm();
            _ef.Show();
        }

        /// <summary>
        /// Additional graphs click event handler
        /// </summary>
        private void bAddGraphs_Click(object sender, EventArgs e)
        {
            //disabling button & showing addgraphform
            ((Button)sender).Enabled = false;
            agf.Show();
        }

        /// <summary>
        /// Addtext method. Method used to add text into log box
        /// </summary>
        /// <param name="s">String to add into log</param>
        /// <param name="code">Integer that indicates how to format the string</param>
        public void addText(string s,int code)
        {
            //string format
            s = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s;

            if (code == 2)
                s = "\r\n" + s;
            if (code == 1)
                s += "[" + comHandler.count.ToString() + "]";
            s += "\r\n";

            if (tbLog.InvokeRequired)
                tbLog.Invoke((MethodInvoker)delegate() { tbLog.AppendText(s); });
            else
                tbLog.AppendText(s);
        }

        /// <summary>
        /// Reset button click event handler, starts a new application and kills the current one
        /// </summary>
        private void bReset_Click(object sender, EventArgs e)
        {
            //confirm request
            if (MessageBox.Show("Please confirm reset, are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Environment.Exit(0);
            }
        }
    }
}