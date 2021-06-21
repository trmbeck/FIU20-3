using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFfromScratch
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Nun kommt ein WPF Fenster:");
            Console.ReadKey();

            Window einFenster = new Window();
            einFenster.Title = "Erstes WPF-Fenster";

            Application app = new Application();
            app.Run(einFenster);

            Console.ReadKey();
        }
    }
}
