using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Profilrechner
{
    public class CatiaSave
    {

        public CatiaSave(String PartSave)
        {
           
                CatiaConnection c = new CatiaConnection();
                if (c.CATIALaeuft())
                {
                    c.Save(PartSave);
                }

                else
                {
                    MessageBox.Show("Catia läuft nicht!");
                }
            
           

        }
    }
}
