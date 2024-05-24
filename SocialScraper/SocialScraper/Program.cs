using Krypton.Toolkit;
using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace SocialScraper
{
    static class Program
    {
  
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmWelcome());
        }

       
    }
}
