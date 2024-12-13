using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotifierManager.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string appDataPath = Path.Combine(Application.StartupPath, "App_Data");
            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);

            AppDomain.CurrentDomain.SetData("DataDirectory", appDataPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
