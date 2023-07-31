using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_RAW_.BL;
using EMS_RAW_.DL;

namespace EMS_RAW_
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string Adminpath = "AdminData.txt";
            string Userpath = "UserData.txt";
            EmployeeDL.loaddata(ref Userpath);
            AdminDL.readData(ref Adminpath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Starting());
        }
    }
}
