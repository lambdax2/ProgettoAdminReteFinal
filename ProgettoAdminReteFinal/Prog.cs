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
        public static mainForm mf = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            mf = new mainForm();
            Application.Run(mf);
        }
    }
}