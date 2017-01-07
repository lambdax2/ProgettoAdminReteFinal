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
    /// Class dedicated to handle additional graph form.
    /// </summary>
    public partial class addGraphForm : Form
    {
        public addGraphForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// addgraph form closing event handler
        /// </summary>
        private void addGraphForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cancelling event. Don't want to close the form, just hide it
            e.Cancel = true;
            //hiding
            ((addGraphForm)sender).Hide();
            //reenabling addgraph button
            Prog.mainForm.bAddGraphs.Enabled = true;
        }
    }
}
