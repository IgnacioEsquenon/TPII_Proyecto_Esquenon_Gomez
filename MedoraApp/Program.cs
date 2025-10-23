using System;
using System.Windows.Forms;
using MedoraApp;

namespace MedoraApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormInicio());
        }
    }
}
