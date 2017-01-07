using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgettoAdminReteFinal
{
    /// <summary>
    /// Class dedicated to the management of application settings.
    /// </summary>
    public partial class settingForm : Form
    {
        /// <summary>
        /// constructor
        /// </summary>
        public settingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setting form loading event handler.
        /// </summary>
        private void settingForm_Load(object sender, EventArgs e)
        {
            //load stored settings and fill controls
            tbIP1.Text = Properties.Settings.Default.IP1.ToString();
            tbIP2.Text = Properties.Settings.Default.IP2.ToString();
            tbIP3.Text = Properties.Settings.Default.IP3.ToString();
            tbIP4.Text = Properties.Settings.Default.IP4.ToString();
            tbPort.Text = Properties.Settings.Default.Port.ToString();

            cbFrequency.SelectedIndex = Properties.Settings.Default.Frequency;
            nudActivityWindow.Value = Properties.Settings.Default.ActivityWindow;
            nudSmoothWindow.Value = Properties.Settings.Default.SmoothingWindow;
            nudMinTurn.Value = Convert.ToDecimal(Properties.Settings.Default.MinTurnValue);
            nudTurnLimit.Value = Convert.ToDecimal(Properties.Settings.Default.TurnLimit90_180);
            nudTurnWindow.Value = Properties.Settings.Default.TurnWindow;

            //Adding handlers to filter user insertions in ip and port textboxes.
            tbIP1.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            tbIP2.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            tbIP3.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            tbIP4.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            tbPort.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        /// <summary>
        /// Setting form closing event handler. P.S. exiting without applying settings will result in a loss of changes made.
        /// </summary>
        public static void serverSettings_OnClose(object sender, EventArgs e)
        {
                Prog.mainForm.Enabled = true;
        }

        /// <summary>
        /// Apply button click event handler.
        /// </summary>
        private void bApply_Click(object sender, EventArgs e)
        {
            //Validate ip + port (out of range:  ip over 127 and less than 0 port less then 0 and over 65535).
            bool _validate = true;
            int _ip1, _ip2, _ip3, _ip4, _port;

            _ip1 = Convert.ToInt32(tbIP1.Text);
            _ip2 = Convert.ToInt32(tbIP2.Text);
            _ip3 = Convert.ToInt32(tbIP3.Text);
            _ip4 = Convert.ToInt32(tbIP4.Text);
            _port = Convert.ToInt32(tbPort.Text);

            //oly validating ip and port textboxes
            if (_validate && _ip1 > 255)
                _validate = false;
            if (_validate && _ip2 > 255)
                _validate = false;
            if (_validate && _ip3 > 255)
                _validate = false;
            if (_validate && _ip4 > 255)
                _validate = false;
            if (_validate && _port > 65535)
                _validate = false;

            //Save validated settings into properties. If any setting fails the validation, no settings will be saved.
            #region save validated settings into properties
            if (_validate)
            {
                Properties.Settings.Default.IP1 =  _ip1;
                Properties.Settings.Default.IP2 =  _ip2;
                Properties.Settings.Default.IP3 =  _ip3;
                Properties.Settings.Default.IP4 =  _ip4;
                Properties.Settings.Default.Port = _port;

                Properties.Settings.Default.Frequency = cbFrequency.SelectedIndex;
                Properties.Settings.Default.ActivityWindow = Convert.ToInt32(nudActivityWindow.Value);
                Properties.Settings.Default.SmoothingWindow = Convert.ToInt32(nudSmoothWindow.Value);
                Properties.Settings.Default.stationingRound = Convert.ToDouble(1 + nudStationingRound.Value);
                Properties.Settings.Default.TurnWindow = Convert.ToInt32(nudTurnWindow.Value);
                Properties.Settings.Default.TurnLimit90_180 = Convert.ToDouble(nudTurnLimit.Value);
                Properties.Settings.Default.MinTurnValue = Convert.ToDouble(nudMinTurn.Value);

                //saving settings trought sessions
                Properties.Settings.Default.Save();

                //save complete message
                MessageBox.Show("Save complete", "Save settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Could not complete settings save", "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        /// <summary>
        /// Cancel button click event handler.
        /// </summary>
        private void bCancel_Click(object sender, EventArgs e)
        {
            //button cancel pressed = discard changed settings + close setting form
            this.Close();
            Prog.mainForm.Enabled = true;
        }

        /// <summary>
        /// key press event handler.
        /// discard anything that isn't a number or backspace.
        /// </summary>
        public static void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permits the insertion of numbers and backspace only. Discards everything else. e.handled prevents the insert of undesidered keys
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true; 
        }
 
    }
}
