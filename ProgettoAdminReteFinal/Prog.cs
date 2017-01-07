using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProgettoAdminReteFinal
{
    /// <summary>
    /// class containing main
    /// </summary>
    class Prog
    {
        /**main form*/
        public static mainForm mainForm = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            mainForm = new mainForm();
            Application.Run(mainForm);
        }
    }
}