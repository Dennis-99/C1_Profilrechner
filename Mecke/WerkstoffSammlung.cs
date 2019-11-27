using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilRechnerMitWerkstoffauswahl
{
    public static class  WerkstoffSammlung
    {
        public static String Error;
        public static String ManuelleDichte;
        public static Double Werkstoffe(Double WerkstoffNummer, Double Sprache)
        {
            Double WerkstoffDichte;

            if (Sprache.Equals(3.0))
            {
                Error = "Falsche Eingabe";
                ManuelleDichte = "Bitte die Gewuenschte Dichte in g / cm³ eingeben";
            }
            else if (Sprache.Equals(1.0))
            {
                Error = "Error";
                ManuelleDichte = "Enter density in g/cm³";
            }
            else if (Sprache.Equals(2.0))
            {
                Error = "Erreur";
                ManuelleDichte = "Veuillez enter la densité en g/cm³";
            }
            else
            {
                Console.WriteLine("Error");
            }
            if (WerkstoffNummer.Equals(1.0))
            {
                //S253
                WerkstoffDichte = 7.84;
                return WerkstoffDichte;
            }
            else if (WerkstoffNummer.Equals(2.0))
            {
                //AlMg4
                WerkstoffDichte = 2.66;
                return WerkstoffDichte;

            }
            else if (WerkstoffNummer.Equals(3.0))
            {
                //S355
                WerkstoffDichte = 7.84;
                return WerkstoffDichte;
            }
            else if (WerkstoffNummer.Equals(4.0))
            {
                //42CrMo4
                WerkstoffDichte = 7.72;
                return WerkstoffDichte;
            }
            else if (WerkstoffNummer.Equals(5.0))
            {
                //E295
                WerkstoffDichte = 7.85;
                return WerkstoffDichte;
            }
            else if (WerkstoffNummer.Equals(6.0))
            {
                //E355
                WerkstoffDichte = 7.85;
                return WerkstoffDichte;
            }
            else if (WerkstoffNummer.Equals(7.0))
            {
                //C45
                WerkstoffDichte = 7.85;
                return WerkstoffDichte;
            }
            else if (true)
            {
                Console.WriteLine(Error);
                Console.WriteLine(ManuelleDichte);
                String Dichte = Console.ReadLine();
                WerkstoffDichte = Convert.ToDouble(Dichte);
                return WerkstoffDichte;
            }

        }
    }
}
