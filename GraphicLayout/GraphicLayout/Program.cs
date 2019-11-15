using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphicLayout
{
    public class ProfilRechnerGuiControll
    {
        //Aufrauf des Gui Fensters
        ProfilRechnerGuiControll()
        {
            Window fenster1 = new Window();
            fenster1.Title = "ProfilRechner";
            fenster1.SizeToContent = SizeToContent.WidthAndHeight;
            fenster1.ResizeMode = ResizeMode.NoResize;
            UserControl1 PRGui1 = new UserControl1();

            fenster1.Content = PRGui1;
            fenster1.ShowDialog();

            Console.WriteLine("Taste Drücken zum Beenden");
            Console.ReadKey();

        }

        [STAThread]
        static void Main(string[] args)
        {
            new ProfilRechnerGuiControll();
        }
    }
}
