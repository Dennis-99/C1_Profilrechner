using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilRechnerMitWerkstoffauswahl
{
    public static class Berechnungen
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
        //Helpers
        public static String n = Environment.NewLine;

        public static void Sprache(Double Sprache)
        {
            if (Sprache.Equals(1.0))
            {
                QuerschnittS = "The cross-section area of the profile is: ";
                VolumenS = "The Volume of the profile is: ";
                GewichtS = "The weight of the profile is: ";
                SchwerpunktxS = "The origin is at the bottom left, at the corner of the profile" + n + "Shift of emphasis in x";
                SchwerpunktyS = "Shift of emphasis in y";
                FTMS = "The geometrical moment of inertia of the profile is: ";
                FTMSX = "The geometrical moment of inertia of the profile along the x-axis is: ";
                FTMSY = "The geometrical moment of inertia of the profile along the y-axis is: ";
                FTMSXY = "The moment of deviation Ixy of the profile is: ";
                DrehungAchsenRad = "The Rotation of the mass centroid axis to the priority axis is:";
                DrehungAchsenGrad = "This is: ";
                DrehungUX = "The u-axis corresponds to the x-axis + ";
                Drehsinn = "°." + n + "Positive values ​​turn counterclockwise";
                DrehungVY = "The v-axis corresponds to the y-axis + ";
                FTMSU = "The geometrical moment of inertia of the profile along the u-axis is: ";
                FTMSV = "The geometrical moment of inertia of the profile along the v-axis is: ";



            }

            else if (Sprache.Equals(2.0))
            {
                QuerschnittS = "La section transverdale du profil est: ";
                VolumenS = "Le volume du profil est: ";
                GewichtS = "Le poids du profil est: ";
                SchwerpunktxS = "L'origine du système de coorodnées est situé en bas à gauche, au bord du profil" + n + "Le déplacement du centre de masse vers l'axe x est: ";
                SchwerpunktyS = "Le déplacement du centre de masse vers l'axe x est: ";
                FTMS = "Le moment quadratique du profil est: ";
                FTMSX = "Le moment quadratique de l'axe x est: ";
                FTMSY = "Le moment quadratique se l'axe y est: ";
                FTMSXY = "Le moment d'inerte est: ";
                DrehungAchsenRad = "La rotation de les axes principaux aux axes prioritaires est: ";
                DrehungAchsenGrad = "Ce sont: ";
                DrehungUX = "L'axe u est correspendant à l'axe x + ";
                Drehsinn = "°" + n + "Des Valeurs positives tuornent dans le sens contraire des aiguilles d'une montre.";
                DrehungVY = "L'axe v est correspendant à l'axe y + ";
                FTMSU = "Le moment quadratique de l'axe u est: ";
                FTMSV = "Le moment quadratique de l'axe v est: ";
            }

            else if (Sprache.Equals(3.0))
            {
                QuerschnittS = "Der Querschnitt des Profils betraegt: ";
                VolumenS = "Das Volumen des Profils betraegt: ";
                GewichtS = "Das Gewicht des Profils betraegt: ";
                SchwerpunktxS = "Der Koordinatenursprung liegt unten links, an der Ecke des Profils" + n + "Die Schwerpunktverschiebiung in x-Richtung betraegt: ";
                SchwerpunktyS = "Schwerpunktverschiebiung in y-Richtung betraegt: ";
                FTMS = "Das Flaechentraegheitsmoment des Profils betraegt: ";
                FTMSX = "Das Flaechentraegheitsmoment des Profils um die x-Achse betraegt: ";
                FTMSY = "Das Flaechentraegheitsmoment des Profils um die y-Achse betraegt: ";
                FTMSXY = "Das Deviationsmoment Ixy des Profils beträgt: ";
                DrehungAchsenRad = "Die Verdrehung der Haupttraegheitsachsen zu den Schwerpunktachsen betraegt: ";
                DrehungAchsenGrad = "Dies entspricht: ";
                DrehungUX = "Die U Achse entspricht der X Achse + ";
                Drehsinn = "°" + n + "Positive Werte drehen gegen den Uhrzeigersinn";
                DrehungVY = "Die v-Achse entspricht der y-Achse + ";
                FTMSU = "Das Flaechentraegheitsmoment des Profils um die u-Achse beträgt: ";
                FTMSV = "Das Flaechentraegheitsmoment des Profils um die v-Achse beträgt: ";
            }


        }
        
        public static void KreisRohr(Double durchmesserU, Double wandstaerkeU, Double laengeU, Double dichteU, Double Sprache)
        {
            Berechnungen.Sprache(Sprache);

            Double querschnitt;
            Double volumen;
            Double gewicht;
            Double festigkeit;

            querschnitt = ((Math.Pow(durchmesserU, 2) * Math.PI) - (Math.Pow((durchmesserU - (2 * wandstaerkeU)), 2) * Math.PI)) / 4;
            volumen = querschnitt * laengeU;
            gewicht = volumen * dichteU;
            festigkeit = (Math.PI * (Math.Pow(durchmesserU, 4) - Math.Pow((durchmesserU - ( 2 * wandstaerkeU)), 4))) / 64;

            Console.WriteLine(QuerschnittS + Math.Round(querschnitt, 3) + " mm²");
            Console.WriteLine(VolumenS + Math.Round(volumen,3) + " mm³");
            Console.WriteLine(GewichtS + Math.Round(gewicht, 3) + " g");
            Console.WriteLine(FTMS + Math.Round(festigkeit, 3)+ " mm⁴");
        }

        public static void KreisVoll(Double durchmesserU, Double laengeU, Double dichteU, Double Sprache)
        {
            Berechnungen.Sprache(Sprache);

            Double querschnitt;
            Double volumen;
            Double gewicht;
            Double festigkeit;

            querschnitt = Math.Pow(durchmesserU, 2) * Math.PI / 4;
            volumen = querschnitt * laengeU;
            gewicht = volumen * dichteU;
            festigkeit = (Math.PI * (Math.Pow(durchmesserU, 4))) / 64;

            Console.WriteLine(QuerschnittS + Math.Round(querschnitt, 3) + " mm²");
            Console.WriteLine(VolumenS + Math.Round(volumen, 3) + " mm³");
            Console.WriteLine(GewichtS + Math.Round(gewicht, 3) + " g");
            Console.WriteLine(FTMS + Math.Round(festigkeit, 3) + " mm⁴");
        }

        public static void RechteckRohr(Double hoeheU, Double breiteU, Double wandstaerkeU, Double laengeU, Double dichteU, Double Sprache)
        {
            Berechnungen.Sprache(Sprache);

            Double querschnitt;
            Double volumen;
            Double gewicht;
            Double festigkeitx;
            Double festigkeity;

            querschnitt = (hoeheU * breiteU) - ((hoeheU - (2 * wandstaerkeU)) * (breiteU - (2 * wandstaerkeU)));
            volumen = querschnitt * laengeU;
            gewicht = volumen * dichteU;
            festigkeitx = ((breiteU * Math.Pow(hoeheU, 3)) - ((breiteU - (2 * wandstaerkeU)) * Math.Pow((hoeheU - (2 * wandstaerkeU)), 3))) / 12;
            festigkeity = ((hoeheU * Math.Pow(breiteU, 3)) - ((hoeheU - (2 * wandstaerkeU)) * Math.Pow((breiteU - (2 * wandstaerkeU)), 3))) / 12;

            Console.WriteLine(QuerschnittS + Math.Round(querschnitt, 3) + " mm²");
            Console.WriteLine(VolumenS + Math.Round(volumen, 3) + " mm³");
            Console.WriteLine(GewichtS + Math.Round(gewicht, 3) + " g");
            Console.WriteLine(FTMSX + Math.Round(festigkeitx, 3) + " mm⁴");
            Console.WriteLine(FTMSY + Math.Round(festigkeity, 3) + " mm⁴");
        }

        public static void RechteckVoll(Double hoeheU, Double breiteU, Double laengeU, Double dichteU, Double Sprache)
        {
            Berechnungen.Sprache(Sprache);

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

        public static void LProfil(Double HoeheL, Double BreiteL, Double LaengeL, Double WandstaerkeL, Double DichteL, Double Sprache)
        {
            Berechnungen.Sprache(Sprache);

            Double Volumen;
            Double Querschnitt;
            Double Gewicht;
            Double Schwerpunktx;                //Abstand des Schwerpunktes zum Ursprungskoordinatensystem, welches auf der linken Profilkante liegt
            Double Schwerpunkty;                //Abstand des Schwerpunktes zum Ursprungskoordinatensystem, welches auf der unteren Profilkante liegt
            Double Festigkeitxx;
            Double Festigkeityy;
            Double Festigkeitxy;                //Deviationsmoment, da keine der Schwerpunktachsen Symetrieachse ist --- um Vredrehwinkel der hauptträgheitsachsen auszurechnen
            Double AchswinkelRad;                  //Verdrehung der Hauptträgheitsachsen zu den Schwerpunktachsen in Radiant
            Double AchswinkelGrad;                  //Verdrehung der Hauptträgheitsachsen zu den Schwerpunktachsen in Grad
            Double Festigkeitu;
            Double Festigkeitv;

            //Querschnitt
            Querschnitt = BreiteL * WandstaerkeL + (HoeheL - WandstaerkeL) * WandstaerkeL;

           
            //Voulumen
            Volumen = Querschnitt * LaengeL;

            

            //Gewicht
            Gewicht = Volumen * DichteL;

            Console.WriteLine(QuerschnittS + Math.Round(Querschnitt, 3) + " mm²");
            Console.WriteLine(VolumenS + Math.Round(Volumen, 3) + " mm³");
            Console.WriteLine(GewichtS + Math.Round(Gewicht, 3) + " g");

            //Schwerpunkte: (b * h * b/2--Schwerpunkt auf halber Höhe/Breite, ganze Fläche-- - (b - w) * (h - w)--Ausgeschnittene Fläche-- * ((b - w)/2 + w)--Schwerpunkt der Fläche, da Ursprungs KS auf linker Profilkante--) / (b * h - (b - w) * (h - w))--Querschnitt--
            Schwerpunktx = (BreiteL * HoeheL * (BreiteL / 2) - (BreiteL - WandstaerkeL) * (HoeheL - WandstaerkeL) * ((BreiteL - WandstaerkeL) / 2 + WandstaerkeL)) / ((BreiteL * HoeheL) - ((BreiteL - WandstaerkeL) * (HoeheL - WandstaerkeL)));
            Schwerpunkty = (HoeheL * BreiteL * (HoeheL / 2) - (HoeheL - WandstaerkeL) * (BreiteL - WandstaerkeL) * ((HoeheL - WandstaerkeL) / 2 + WandstaerkeL)) / ((HoeheL * BreiteL) - ((HoeheL - WandstaerkeL) * (BreiteL - WandstaerkeL)));



            //              -       Flächenträgheitsmomente         -Steiner Anteil: -Fläche  -;  -Abstand² des Teilschwerpkt. vom Gesamtschwerpkt, mit Ursprungs KS auf linker Profilkante
            //                                                                                                                               -     -         Flächenträgheitsmoment                           -      -           Fläche                    -    -Abstand² von Teilschw. zu Gesamtschw. mit KS auf Unterkante
            Festigkeitxx = ((WandstaerkeL * Math.Pow(HoeheL, 3) / 12) + (WandstaerkeL * HoeheL) * Math.Pow((HoeheL / 2 - Schwerpunkty), 2)) + (((BreiteL - WandstaerkeL) * Math.Pow(WandstaerkeL, 3) / 12) + (((BreiteL - WandstaerkeL) * WandstaerkeL) * Math.Pow((Schwerpunkty - (WandstaerkeL / 2)), 2)));                                       //Klappt
            Festigkeityy = ((HoeheL * Math.Pow(WandstaerkeL, 3) / 12) + (WandstaerkeL * HoeheL) * Math.Pow((Schwerpunktx - (WandstaerkeL / 2)), 2)) + ((WandstaerkeL * Math.Pow((BreiteL - WandstaerkeL), 3) / 12) + (((BreiteL - WandstaerkeL) * WandstaerkeL) * Math.Pow(((BreiteL - WandstaerkeL) / 2 + WandstaerkeL) - Schwerpunktx, 2)));      //Klappt

            Festigkeitxy = -Math.Pow((BreiteL * HoeheL), 2) / 4 - (-(Math.Pow((BreiteL * HoeheL), 2) - Math.Pow((HoeheL * WandstaerkeL), 2) - Math.Pow((BreiteL * WandstaerkeL), 2) + Math.Pow(WandstaerkeL, 4)) / 4) + (((BreiteL * HoeheL) - (BreiteL - WandstaerkeL) * (HoeheL - WandstaerkeL)) * Schwerpunktx * Schwerpunkty);

            //Achswinkel = (1 / 2) * Math.Atan((2 * Festigkeitxy) / (Festigkeitxx - Festigkeityy));
            AchswinkelRad = (Math.Atan((2 * Festigkeitxy) / (Festigkeitxx - Festigkeityy))) / 2;
            AchswinkelGrad = AchswinkelRad * 180 / Math.PI;

            Festigkeitu = (Festigkeitxx + Festigkeityy) / 2 + (((Festigkeitxx - Festigkeityy) / 2) * Math.Cos(2 * AchswinkelRad)) + Festigkeitxy * Math.Sin(2 * AchswinkelRad);
            Festigkeitv = (Festigkeitxx + Festigkeityy) / 2 - (((Festigkeitxx - Festigkeityy) / 2) * Math.Cos(2 * AchswinkelRad)) - Festigkeitxy * Math.Sin(2 * AchswinkelRad);


            Console.WriteLine(SchwerpunktxS + Schwerpunktx + " mm");
            Console.WriteLine(SchwerpunktyS + Schwerpunkty + " mm");
            Console.WriteLine(FTMSX + Festigkeitxx + " mm⁴");
            Console.WriteLine(FTMSY + Festigkeityy + " mm⁴");
            Console.WriteLine(FTMSXY + Festigkeitxy + " mm⁴");
            Console.WriteLine(DrehungAchsenRad + AchswinkelRad + ".");
            Console.WriteLine(DrehungAchsenGrad + AchswinkelGrad + "°.");
            Console.WriteLine(DrehungUX + AchswinkelGrad + Drehsinn);
            Console.WriteLine(DrehungVY + AchswinkelGrad + "°.");
            Console.WriteLine(FTMSU + Festigkeitu + " mm⁴");
            Console.WriteLine(FTMSV + Festigkeitv + " mm⁴");
        }

        static public void TProfil(Double Hoehe1, Double Breite1, Double Laenge1, Double Wandstaerke1, Double Dichte1, Double Sprache)
        {
            Berechnungen.Sprache(Sprache);

            Double Querschnitt;
            Double Volumen;
            Double Gewicht;
            Double Schwerpunkt;
            Double FTMx;
            Double FTMy;

            //Querschnitt
            Querschnitt = (Wandstaerke1 * Breite1) + (Wandstaerke1 * (Hoehe1 - Wandstaerke1));

           
            //Voulumen
            Volumen = (Wandstaerke1 * Breite1 * Laenge1) + ((Hoehe1 - Wandstaerke1) * Wandstaerke1 * Laenge1);

           
            //Gewicht
            Gewicht = Volumen * Dichte1;

            Console.WriteLine(QuerschnittS + Math.Round(Querschnitt, 3) + " mm²");
            Console.WriteLine(VolumenS + Math.Round(Volumen, 3) + " mm³");
            Console.WriteLine(GewichtS + Math.Round(Gewicht, 3) + " g");

            //Schwerpunkt
            //                             A1                       *               y1              +              A2           *                 y2              
            Schwerpunkt = ((Wandstaerke1 * (Hoehe1 - Wandstaerke1)) * ((Hoehe1 - Wandstaerke1) / 2) + ((Wandstaerke1 * Breite1) * (Breite1 - (Wandstaerke1 / 2))))
            //            /                    A1                     +            A2
                          / ((Wandstaerke1 * (Hoehe1 - Wandstaerke1)) + (Breite1 * Wandstaerke1));

            Console.WriteLine(SchwerpunktxS + (Breite1 / 2) + " mm");

            Console.WriteLine(SchwerpunktyS + Schwerpunkt + " mm");

            //Flächenträgheitsmoment
            //                               Ixx1                               +                  A1                      *                              l1²                          
            FTMx = ((Wandstaerke1 * Math.Pow((Hoehe1 - Wandstaerke1), 3)) / 12) + (Wandstaerke1 * (Hoehe1 - Wandstaerke1)) * Math.Pow((Schwerpunkt - ((Hoehe1 - Wandstaerke1) / 2)), 2)
            //  +                     Ixx2                     +            A2            *                           l2²
                + ((Breite1 * Math.Pow(Wandstaerke1, 3)) / 12) + (Wandstaerke1 * Breite1) * Math.Pow(((Breite1 - (Wandstaerke1 / 2)) - Schwerpunkt), 2);

            Console.WriteLine(FTMSX + FTMx + " mm⁴");

            //                               Iyy1                          +                     Iyy2
            FTMy = (((Hoehe1 - Wandstaerke1) * Math.Pow(Wandstaerke1, 3)) / 12) + ((Wandstaerke1 * Math.Pow(Breite1, 3)) / 12);

            Console.WriteLine(FTMSX + FTMy + " mm⁴");

        }

        public static void IProfil(Double Hoehe1, Double Breite1, Double Stegbreite1, Double Flanschbreite1, Double Laenge1, Double Dichte1, Double Sprache)
        {
            Berechnungen.Sprache(Sprache);

            //Ergebnis Variablen
            Double Breiteb;
            Double Hoeheh;
            Double Querschnitt;
            Double Volumen;
            Double Gewicht;
            Double Schwerpunktx;
            Double Schwerpunkty;
            Double FTMx;
            Double FTMy;

            //Zwischenrechnungen
            Breiteb = Breite1 - Stegbreite1;
            Hoeheh = Hoehe1 - 2 * Flanschbreite1;


            //Berechnung Querschnitt
            Querschnitt = (2 * Breite1 * Flanschbreite1) + ((Hoehe1 - 2 * Flanschbreite1) * Stegbreite1);

            

            //Berechnung Volumen
            Volumen = Querschnitt * Laenge1;


            //Berechnung Gewicht 
            Gewicht = Dichte1 * Volumen;

            Console.WriteLine(QuerschnittS + Math.Round(Querschnitt, 3) + " mm²");
            Console.WriteLine(VolumenS + Math.Round(Volumen, 3) + " mm³");
            Console.WriteLine(GewichtS + Math.Round(Gewicht, 3) + " g");

            //Berechnung Schwerpunkte
            Schwerpunktx = Breite1 / 2;
            Schwerpunkty = Hoehe1 / 2;

            Console.WriteLine(SchwerpunktxS + Schwerpunktx + " mm");
            Console.WriteLine(SchwerpunktyS + Schwerpunkty + " mm");

            //Berechnung FTM

            FTMx = ((Breite1 * Math.Pow(Hoehe1, 3) / 12) - (Breiteb * Math.Pow(Hoeheh, 3) / 12));

            Console.WriteLine(FTMSX + FTMx + " mm⁴");

            FTMy = 2 * ((Flanschbreite1 * Math.Pow(Breite1, 3) / 12)) + ((Hoeheh * Math.Pow(Stegbreite1, 3)) / 12);

            Console.WriteLine(FTMSY + FTMy + " mm⁴");


        }

        public static void UProfil(Double HoeheU, Double BreiteU, Double LaengeU, Double StegBreiteU, Double FlanschbreiteU, Double DichteU, Double Sprache)
        {
            Berechnungen.Sprache(Sprache);

            Double Volumen;
            Double Querschnitt;
            Double Gewicht;
            Double Schwerpunktx;                //Abstand des Schwerpunktes zum Ursprungskoordinatensystem, welches auf der linken Profilkante liegt
            Double Schwerpunkty;                //Abstand des Schwerpunktes zum Ursprungskoordinatensystem, welches auf der unteren Profilkante liegt
            Double Festigkeitx;
            Double Festigkeity;

            //Querschnitt
            Querschnitt = (BreiteU * HoeheU) - ((BreiteU - StegBreiteU) * (HoeheU - (2 * FlanschbreiteU)));

            Console.WriteLine(QuerschnittS + Querschnitt + " mm²");

            //Voulumen
            Volumen = Querschnitt * LaengeU;

            Console.WriteLine(VolumenS + Volumen + " mm³");

            //Gewicht
            Gewicht = Volumen * DichteU;

            Console.WriteLine(GewichtS + Gewicht + " kg");

            //Schwerpunkt
            //             '        (B * U * B/2)            ' - '                                           (b * u * b/2)                                                '
            Schwerpunktx = ((BreiteU * HoeheU * (BreiteU / 2)) - ((BreiteU - StegBreiteU) * (HoeheU - (2 * FlanschbreiteU)) * ((BreiteU - StegBreiteU) / 2 + StegBreiteU)))
            //             / '    (B * H)      ' - '                        (b * h)                           '
                           / ((BreiteU * HoeheU) - ((BreiteU - StegBreiteU) * (HoeheU - (2 * FlanschbreiteU))));
            Schwerpunkty = HoeheU / 2;

            Console.WriteLine(SchwerpunktxS + Schwerpunktx + " mm");
            Console.WriteLine(SchwerpunktyS + Schwerpunkty + " mm");

            //            '                 FTM Groß           ' - '                                  FTM Klein                                  '
            Festigkeitx = ((BreiteU * Math.Pow(HoeheU, 3)) / 12) - (((BreiteU - StegBreiteU) * Math.Pow((HoeheU - (2 * FlanschbreiteU)), 3)) / 12);
            //            '             FTM groß              ' + '   Fläche groß   ' * '     Abstand² zum Schwerpunkt groß         '
            Festigkeity = ((HoeheU * Math.Pow(BreiteU, 3)) / 12 + ((BreiteU * HoeheU) * Math.Pow(((BreiteU / 2) - Schwerpunktx), 2)))
            //            - '                           FTM klein                                        '
                          - (((HoeheU - (2 * FlanschbreiteU)) * Math.Pow((BreiteU - StegBreiteU), 3)) / 12
            //            + '                     Fläche klein                        ' * '                         Abstand² zum Schwerpunkt klein                 '
                          + ((BreiteU - StegBreiteU) * (HoeheU - (2 * FlanschbreiteU))) * Math.Pow((((BreiteU - StegBreiteU) / 2 + StegBreiteU) - Schwerpunktx), 2));

            Console.WriteLine(FTMSX + Festigkeitx + " mm⁴");
            Console.WriteLine(FTMSY + Festigkeity + " mm⁴");
        }
    }
}