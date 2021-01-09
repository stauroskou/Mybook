using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgileMethods
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            File.AppendAllText(path, "");
            File.AppendAllText("temp.csv", "");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        public static string tek;
        public static string path = "UserData.csv";
        public static string Username;
        public static string ImagePath = "../../Images/download.png";
    }
}
