using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilrechner
{
     class  RechteckVoll
    {
        public static String QuerschnittS;
        public static String VolumenS;
        public static String GewichtS;
        public static String SchwerpunktxS;
        public static String SchwerpunktyS;
        public static String FTMS;
        public static String FTMSX;
        public static String FTMSY;
        //Neu
        public static String FTMSXY;
        public static String FTMSU;
        public static String FTMSV;
        public static String DrehungAchsenRad;
        public static String DrehungAchsenGrad;
        public static String DrehungUX;
        public static String DrehungVY;
        public static String Drehsinn;
       
        public static void Rechteck(Double hoeheU, Double breiteU, Double laengeU, Double dichteU, Double Sprache)
        {


            Double querschnitt;
            Double volumen;
            Double gewicht;
            Double festigkeitx;
            Double festigkeity;

            querschnitt = hoeheU * breiteU;
            volumen = querschnitt * laengeU;
            gewicht = volumen * dichteU;
            festigkeitx = (breiteU * Math.Pow(hoeheU, 3)) / 12;
            festigkeity = (hoeheU * Math.Pow(breiteU, 3)) / 12;

            Console.WriteLine(QuerschnittS + Math.Round(querschnitt, 3) + " mm²");
            Console.WriteLine(VolumenS + Math.Round(volumen, 3) + " mm³");
            Console.WriteLine(GewichtS + Math.Round(gewicht, 3) + " g");
            Console.WriteLine(FTMSX + Math.Round(festigkeitx, 3) + " mm⁴");
            Console.WriteLine(FTMSY + Math.Round(festigkeity, 3) + " mm⁴");
        }
    }
}

