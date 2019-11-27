using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilRechnerMitWerkstoffauswahl
{
   
    public static class ProfilRechner
    {
        public static String EndProgramm;
        public static String ProfilAuswahl;
        public static String UngenauigkeitErklaerung;
        //Rechteck
        public static String RechteckRohrAuswahl;
        public static String GewaehltRohr;
        public static String GewaehltVoll;
        public static String RechteckHoehe;
        public static String RechteckBreite;
        public static String ProfilLaenge;
        public static String ProfilWandstaerke;
        public static String Wandstaerke;
        public static String FehlerWandHoehe;
        public static String FehlerWandBreite;
        //Kreis
        public static String KreisRohrAuswahl;
        public static String RohrDurchmesser;
        public static String FehlerDurchmesserWand;
        //Profile
        public static String IProfilHoehe;
        public static String TProfilHoehe;
        public static String UProfilHoehe;
        public static String LProfilHoehe;
        
        public static String ProfilStegBreite;
        public static String ProfilFlanschBreite;
        //Werkstoffe
        public static String EinleitungWerkstoffe;
        public static String Werkstoffe;
        public static String Error;
        public static String ManuelleDichte ;
        //Helpers
        public static String n = Environment.NewLine;
        static public void Main(string[] args)
        {
            //Grundprogramm zum testen der Variablen und zum Programmieren seines teil programmes.<3

            String RohrAuswahl;
            String Hoehe;
            String Laenge;
            String Breite;
            String Dichte;
            String Wandstaerke;
            String AuswahlProfil;
            String Durchmesser;
            String AuswahlDichte;
            String AuswahlSprache;
            String Stegbreite;
            String Flanschbreite;

            Double RohrAuswahlD;
            Double HoeheD;
            Double BreiteD;
            Double LaengeD;
            Double DichteD;
            Double WandstaerkeD;
            Double DurchmesserD;
            Double AuswahlProfilD;
            Double AuswahlDichteD;
            Double AuswahlSpracheD;
            Double StegbreiteD;
            Double FlanschbreiteD;




            Console.WriteLine("Please select a language" + n + "(1) English" + n + "(2) Français" + n + "(3) Deutsch");

            AuswahlSprache = Console.ReadLine();
            AuswahlSpracheD = Convert.ToDouble(AuswahlSprache);

            if (AuswahlSpracheD.Equals(3.0))
            {
                ProfilAuswahl = "Bitte die Art des Profiles Auswaehlen" + n + "Bitte Nur ganze Zahlen Eingeben" + n + n + "(1) Rechteck"
                                + n + "(2) Kreis" + n + "(3) I - Profil" + n + "(4) T - Profil" + n + "(5) U - Profil" + n + "(6) L - Profil";
                UngenauigkeitErklaerung = "Bitte beachten Sie, dass wir die Kantenverrundungen der I, T, U, L und der Rechteckprofile,"
                                          + n + "Sowie die Steigung der Stege der T - Profile und die Strigung der Flansche der L - Profile nicht beruecksichtigen koennen."
                                          + n + "So kommt es dazu, das wir bei genormten Profilen kleinere Abweichungen von den tatsächlichen Werten erhalten.";
                RechteckRohrAuswahl = "Rechteck Profil" + n + "Die Berechnung beginnt" + n + "Wollen Sie" + n + "(1) ein Rohr oder"
                                      + n + "(2) Vollmaterial erstellen?";
                GewaehltRohr = "Rohrprofil";
                GewaehltVoll = "Vollmaterial";
                RechteckHoehe = "Bitte die Gewuenschte Hoehe in mm eingeben";
                RechteckBreite = "Bitte die Gewuenschte Breite in mm eingeben";
                ProfilLaenge = "Bitte die Gewuenschte Laenge in mm eingeben";
                ProfilWandstaerke = "Bitte die Gewuenschte Wandstaerke in mm eingeben";
                ProfilFlanschBreite = "Bitte die Gewuenschte Flanschbreite in mm eingeben";
                ProfilStegBreite = "Bitte die Gewuenschte Stegbreite in mm eingeben";
                FehlerWandHoehe = "Falsche Eingabe" + n + "Wandstärke muss kleiner als Höhe sein!";
                FehlerWandBreite = "Falsche Eingabe" + n + "Wandstärke muss kleiner als Breite sein!";
                EinleitungWerkstoffe = "(1) Werkstoff auswahl" + n + "(2) Manuelle Eingabe der Dichte";
                Werkstoffe = "Werkstoffe";
                Error = "Falsche Eingabe";
                ManuelleDichte = "Bitte die Gewuenschte Dichte in g / cm³ eingeben";
                KreisRohrAuswahl = "Kreis Profil" + n + "Die Berechnung beginnt" + n + "Wollen Sie" + n + "(1) ein Rohr oder" + n + "(2) Vollmaterial erstellen?";
                RohrDurchmesser = "Bitte den Gewünschten Durchmesser in mm eingeben";
                FehlerDurchmesserWand = "Wandstärke muss kleiner als Durchmesser sein!";
                IProfilHoehe = "I - Profil" + n + "Die Berechnung beginnt" + n + "Bitte die Gewuenschte Hoehe in mm eingeben";
                TProfilHoehe = "T - Profil" + n + "Die Berechnung beginnt" + n + "Bitte die Gewuenschte Hoehe in mm eingeben";
                UProfilHoehe = "U - Profil" + n + "Die Berechnung beginnt" + n + "Bitte die Gewuenschte Hoehe in mm eingeben";
                LProfilHoehe = "L - Profil" + n + "Die Berechnung beginnt" + n + "Bitte die Gewuenschte Hoehe in mm eingeben";
                EndProgramm = "Belibige Taste drücken zum beenden";
            }

            else if (AuswahlSpracheD.Equals(1.0))
            {
                ProfilAuswahl = "Choose the profile" + n + "Only enter whole numbers" + n + n + "(1) Rectangle"
                + n + "(2) Circle" + n + "(3) I-Section" + n + "(4) T-Section" + n + "(5) U-Section" + n + "(6) L-Section";
                UngenauigkeitErklaerung = "Please beware, that we cannot consider the edge roundings of the I, T, U, L and rectangle profiles,"
                                          + n + "As well as the incline of the web of T-profiles and the incline of the flanges of L-profiles."
                                          + n + "That is why we will get slightly different results from the standard patterns.";
                RechteckRohrAuswahl = "Rectangle profile" + n + "Calculation started" + n + "Do you want to create" + n + "(1) a pipe or "
                + n + "(2) solid material?";
                GewaehltRohr = "Pipe";
                GewaehltVoll = "Solid material";
                RechteckHoehe = "Enter hight in mm";
                RechteckBreite = "Enter width in mm";
                ProfilLaenge = "Enter lenght in mm";
                ProfilWandstaerke = "Enter wall thickness in mm";
                ProfilFlanschBreite = "Enter flange width in mm";
                ProfilStegBreite = "Enter web width in mm";
                FehlerWandHoehe = "Error" + n + "Wall thickness must be lower then hight!";
                FehlerWandBreite = "Error" + n + "Wall thickness must be lower then width!";
                EinleitungWerkstoffe = "(1) Choose material" + n + "(2) Manually enter density";
                Error = "Error";
                Werkstoffe = "Materials";
                ManuelleDichte = "Enter density in g/cm³";
                KreisRohrAuswahl = "Circle profile" + n + "Calculation started" + n + "Do you want to create" + n + "(1) a pipe or " + n + "(2) solid material?";
                RohrDurchmesser = "Enter diameter in mm";
                FehlerDurchmesserWand = "Error" + n + "Wall thickness must be lower then diameter";
                IProfilHoehe = "I-profile" + n + "Calculation started" + n + "Enter hight in mm";
                TProfilHoehe = "T-profile" + n + "Calculation started" + n + "Enter hight in mm";
                UProfilHoehe = "U-profile" + n + "Calculation started" + n + "Enter hight in mm";
                LProfilHoehe = "L-profile" + n + "Calculation started" + n + "Enter hight in mm";
                EndProgramm = "Press any key to end";

            }

            else if (AuswahlSpracheD.Equals(2.0))
            {
                ProfilAuswahl = "Veuillez choisir le profil" + n + "Veuillez seulement entrer nombres entiers" + n + n + "(1) Rectangle"
                + n + "(2) Cercle" + n + "(3) I-Profil" + n + "(4) T-Profil" + n + "(5) U-Profil" + n + "(6) L-Profil";
                UngenauigkeitErklaerung = "Veuillez noter, que nous ne pouvons pas considérer des arrondoi edge de les profils I, T, U, L et les profils rectangles,"
                                          + n + "ainsi que les inclines des bandes desprofils T et les inclines des brides des profiles L."
                                          + n + "Comme ça ce viens, que nous recevons des résultats différents sur des profils standardisés.";
                RechteckRohrAuswahl = "Profil rectangle" + n + "La calculation a commancée" + n + "Voullez vouz créer" + n + "(1) un tuyau ou "
                + n + "(2) du matériau solide?";
                GewaehltRohr = "Tuyau";
                GewaehltVoll = "Matériau solide";
                RechteckHoehe = "Veuillez enter la hauteur en mm";
                RechteckBreite = "Veuillez enter la largeur en mm";
                ProfilLaenge = "Veuillez enter la longueur en mm";
                ProfilWandstaerke = "Veuillez enter la épaisseur de paroi en mm";
                ProfilFlanschBreite = "Veuillez enter le largeur de bride en mm";
                ProfilStegBreite = "Veuillez enter le largeur de bande en mm";
                FehlerWandHoehe = "Erreur" + n + "La épaisseur de paroi droit être moins que la hauter!";
                FehlerWandBreite = "Erreur" + n + "La épaisseur de paroi droit être moins que la largeur!";
                EinleitungWerkstoffe = "(1) Choisir le matériel d'une liste" + n + "(2) Entrer la densité manuellement";
                Error = "Erreur";
                Werkstoffe = "Les matériels:";
                ManuelleDichte = "Veuillez enter la densité en g/cm³";
                KreisRohrAuswahl = "Profil cercle" + n + "La calculation a commancée" + n + "Voullez vouz créer" + n + "(1) un tuyau ou " + n + "(2) du matériau solide?";
                RohrDurchmesser = "Veuillez enter la diamètre en mm";
                FehlerDurchmesserWand = "Error" + n + "La épaisseur de paroi droit être moins que le diamètre";
                IProfilHoehe = "I - profil" + n + "La calculation a commancée" + n + "Enter la hauteur en mm";
                TProfilHoehe = "T - profil" + n + "La calculation a commancée" + n + "Enter la hauteur en mm";
                UProfilHoehe = "U - profil" + n + "La calculation a commancée" + n + "Enter la hauteur en mm";
                LProfilHoehe = "L - profil" + n + "La calculation a commancée" + n + "Enter la hauteur en mm";
                EndProgramm = "Veuillez entrer acun clé pour finir";
            }

            else
            {
                Console.WriteLine(Error);
            }

            Console.WriteLine(ProfilAuswahl);

            AuswahlProfil = Console.ReadLine();

            AuswahlProfilD = Convert.ToDouble(AuswahlProfil);


            if (AuswahlProfilD.Equals(1.0))
            {
                Console.WriteLine(UngenauigkeitErklaerung);

                Console.WriteLine(RechteckRohrAuswahl);
                RohrAuswahl = Console.ReadLine();
                RohrAuswahlD = Convert.ToDouble(RohrAuswahl);

                if (RohrAuswahlD.Equals(1.0))
                {

                    Console.WriteLine(GewaehltRohr);

                    Console.WriteLine(RechteckHoehe);
                    Hoehe = Console.ReadLine();
                    HoeheD = Convert.ToDouble(Hoehe);

                    Console.WriteLine(RechteckBreite);
                    Breite = Console.ReadLine();
                    BreiteD = Convert.ToDouble(Breite);

                    Console.WriteLine(ProfilWandstaerke);
                    Wandstaerke = Console.ReadLine();
                    WandstaerkeD = Convert.ToDouble(Wandstaerke);

                    Console.WriteLine(ProfilLaenge);
                    Laenge = Console.ReadLine();
                    LaengeD = Convert.ToDouble(Laenge);
                    Console.WriteLine();


                    if (WandstaerkeD.Equals(HoeheD))
                    {
                        Console.WriteLine(FehlerWandHoehe);
                    }
                    else if (WandstaerkeD.Equals(BreiteD))
                    {
                        Console.WriteLine(FehlerWandBreite);
                    }
                    else
                    {
                        Console.WriteLine(EinleitungWerkstoffe);
                        AuswahlDichte = Console.ReadLine();
                        AuswahlDichteD = Convert.ToDouble(AuswahlDichte);

                        if (AuswahlDichteD.Equals(1.0))
                        {
                            String WerkstoffAuswahl;
                            Double WerkstoffAuswahlD;
                            Console.WriteLine(Werkstoffe);
                            Console.WriteLine();
                            Console.WriteLine("(1) S235");
                            Console.WriteLine("(2) AlMg4");
                            Console.WriteLine("(3) S355");
                            Console.WriteLine("(4) 42CrMo4");
                            Console.WriteLine("(5) E295");
                            Console.WriteLine("(6) E355");
                            Console.WriteLine("(7) C45");
                            WerkstoffAuswahl = Console.ReadLine();

                            WerkstoffAuswahlD = Convert.ToDouble(WerkstoffAuswahl);

                            DichteD = WerkstoffSammlung.Werkstoffe(WerkstoffAuswahlD, AuswahlSpracheD);

                            Berechnungen.RechteckRohr(HoeheD, BreiteD, WandstaerkeD, LaengeD, DichteD, AuswahlSpracheD);



                        }
                        else if (AuswahlDichteD.Equals(2.0))
                        {
                            Console.WriteLine(ManuelleDichte);
                            Dichte = Console.ReadLine();

                            DichteD = Convert.ToDouble(Dichte);
                            HoeheD = Convert.ToDouble(Hoehe);
                            BreiteD = Convert.ToDouble(Breite);
                            LaengeD = Convert.ToDouble(Laenge);
                            WandstaerkeD = Convert.ToDouble(Wandstaerke);

                            Berechnungen.RechteckRohr(HoeheD, BreiteD, WandstaerkeD, LaengeD, DichteD, AuswahlSpracheD);
                        }
                        else if (true)
                        {
                            Console.WriteLine(Error);
                        }
                    }
                }

                else if (RohrAuswahlD.Equals(2.0))
                {
                    Console.WriteLine(GewaehltVoll);

                    Console.WriteLine(RechteckHoehe);
                    Hoehe = Console.ReadLine();
                    HoeheD = Convert.ToDouble(Hoehe);

                    Console.WriteLine(RechteckBreite);
                    Breite = Console.ReadLine();
                    BreiteD = Convert.ToDouble(Breite);

                    Console.WriteLine(ProfilLaenge);
                    Laenge = Console.ReadLine();
                    LaengeD = Convert.ToDouble(Laenge);

                    Console.WriteLine();



                    Console.WriteLine(EinleitungWerkstoffe);
                    AuswahlDichte = Console.ReadLine();
                    AuswahlDichteD = Convert.ToDouble(AuswahlDichte);

                    if (AuswahlDichteD.Equals(1.0))
                    {
                        String WerkstoffAuswahl;
                        Double WerkstoffAuswahlD;
                        Console.WriteLine(Werkstoffe);
                        Console.WriteLine();
                        Console.WriteLine("(1) S235");
                        Console.WriteLine("(2) AlMg4");
                        Console.WriteLine("(3) S355");
                        Console.WriteLine("(4) 42CrMo4");
                        Console.WriteLine("(5) E295");
                        Console.WriteLine("(6) E355");
                        Console.WriteLine("(7) C45");
                        WerkstoffAuswahl = Console.ReadLine();

                        WerkstoffAuswahlD = Convert.ToDouble(WerkstoffAuswahl);

                        DichteD = WerkstoffSammlung.Werkstoffe(WerkstoffAuswahlD, AuswahlSpracheD);

                        Berechnungen.RechteckVoll(HoeheD, BreiteD, LaengeD, DichteD, AuswahlSpracheD);




                    }
                    else if (AuswahlDichteD.Equals(2.0))
                    {
                        Console.WriteLine(ManuelleDichte);
                        Dichte = Console.ReadLine();

                        DichteD = Convert.ToDouble(Dichte);
                        HoeheD = Convert.ToDouble(Hoehe);
                        BreiteD = Convert.ToDouble(Breite);
                        LaengeD = Convert.ToDouble(Laenge);

                        Berechnungen.RechteckVoll(HoeheD, BreiteD, LaengeD, DichteD, AuswahlSpracheD);
                    }
                    else if (true)
                    {
                        Console.WriteLine(Error);
                    }

                }

                else
                {
                    Console.WriteLine(Error);
                }

            }

            else if (AuswahlProfilD.Equals(2.0))
            {
                Console.WriteLine(KreisRohrAuswahl);
                RohrAuswahl = Console.ReadLine();
                RohrAuswahlD = Convert.ToDouble(RohrAuswahl);

                if (RohrAuswahlD.Equals(1.0))
                {
                    Console.WriteLine(GewaehltRohr);

                    Console.WriteLine(RohrDurchmesser);
                    Durchmesser = Console.ReadLine();
                    DurchmesserD = Convert.ToDouble(Durchmesser);

                    Console.WriteLine(ProfilWandstaerke);
                    Wandstaerke = Console.ReadLine();
                    WandstaerkeD = Convert.ToDouble(Wandstaerke);

                    Console.WriteLine(ProfilLaenge);
                    Laenge = Console.ReadLine();
                    LaengeD = Convert.ToDouble(Laenge);
                    Console.WriteLine();


                    if (WandstaerkeD.Equals(DurchmesserD))
                    {
                        Console.WriteLine(FehlerDurchmesserWand);
                    }

                    else
                    {

                        Console.WriteLine(EinleitungWerkstoffe);
                        AuswahlDichte = Console.ReadLine();

                        AuswahlDichteD = Convert.ToDouble(AuswahlDichte);

                        if (AuswahlDichteD.Equals(1.0))
                        {
                            String WerkstoffAuswahl;
                            Double WerkstoffAuswahlD;
                            Console.WriteLine(Werkstoffe);
                            Console.WriteLine();
                            Console.WriteLine("(1) S235");
                            Console.WriteLine("(2) AlMg4");
                            Console.WriteLine("(3) S355");
                            Console.WriteLine("(4) 42CrMo4");
                            Console.WriteLine("(5) E295");
                            Console.WriteLine("(6) E355");
                            Console.WriteLine("(7) C45");
                            WerkstoffAuswahl = Console.ReadLine();

                            WerkstoffAuswahlD = Convert.ToDouble(WerkstoffAuswahl);

                            DichteD = WerkstoffSammlung.Werkstoffe(WerkstoffAuswahlD, AuswahlSpracheD);

                            Berechnungen.KreisRohr(DurchmesserD, WandstaerkeD, LaengeD, DichteD, AuswahlSpracheD);
                        }

                        else if (AuswahlDichteD.Equals(2.0))
                        {
                            Console.WriteLine(ManuelleDichte);
                            Dichte = Console.ReadLine();

                            DichteD = Convert.ToDouble(Dichte);

                            Berechnungen.KreisRohr(DurchmesserD, WandstaerkeD, LaengeD, DichteD, AuswahlSpracheD);
                        }

                        else
                        {
                            Console.WriteLine(Error);
                        }
                    }
                }

                else if (RohrAuswahlD.Equals(2.0))
                {
                    Console.WriteLine(GewaehltVoll);

                    Console.WriteLine(RohrDurchmesser);
                    Durchmesser = Console.ReadLine();
                    DurchmesserD = Convert.ToDouble(Durchmesser);

                    Console.WriteLine(ProfilLaenge);
                    Laenge = Console.ReadLine();
                    LaengeD = Convert.ToDouble(Laenge);
                    Console.WriteLine();


                    Console.WriteLine(EinleitungWerkstoffe);
                    AuswahlDichte = Console.ReadLine();

                    AuswahlDichteD = Convert.ToDouble(AuswahlDichte);

                    if (AuswahlDichteD.Equals(1.0))
                    {
                        String WerkstoffAuswahl;
                        Double WerkstoffAuswahlD;
                        Console.WriteLine(Werkstoffe);
                        Console.WriteLine();
                        Console.WriteLine("(1) S235");
                        Console.WriteLine("(2) AlMg4");
                        Console.WriteLine("(3) S355");
                        Console.WriteLine("(4) 42CrMo4");
                        Console.WriteLine("(5) E295");
                        Console.WriteLine("(6) E355");
                        Console.WriteLine("(7) C45");
                        WerkstoffAuswahl = Console.ReadLine();

                        WerkstoffAuswahlD = Convert.ToDouble(WerkstoffAuswahl);

                        DichteD = WerkstoffSammlung.Werkstoffe(WerkstoffAuswahlD, AuswahlSpracheD);

                        Berechnungen.KreisVoll(DurchmesserD, LaengeD, DichteD, AuswahlSpracheD);
                    }
                    else if (AuswahlDichteD.Equals(2.0))
                    {
                        Console.WriteLine(ManuelleDichte);
                        Dichte = Console.ReadLine();

                        DichteD = Convert.ToDouble(Dichte);

                        Berechnungen.KreisVoll(DurchmesserD, LaengeD, DichteD, AuswahlSpracheD);
                    }
                    else
                    {
                        Console.WriteLine(Error);

                    }
                }

                else
                {
                    Console.WriteLine(Error);
                }
            }

            else if (AuswahlProfilD.Equals(6.0))
            {
                Console.WriteLine(UngenauigkeitErklaerung);

                Console.WriteLine(LProfilHoehe);
                Hoehe = Console.ReadLine();
                HoeheD = Convert.ToDouble(Hoehe);

                Console.WriteLine(RechteckBreite);
                Breite = Console.ReadLine();
                BreiteD = Convert.ToDouble(Breite);

                Console.WriteLine(ProfilWandstaerke);
                Wandstaerke = Console.ReadLine();
                WandstaerkeD = Convert.ToDouble(Wandstaerke);

                Console.WriteLine(ProfilLaenge);
                Laenge = Console.ReadLine();
                LaengeD = Convert.ToDouble(Laenge);
                Console.WriteLine();


                if (WandstaerkeD.Equals(HoeheD))
                {
                    Console.WriteLine(FehlerWandHoehe);
                }
                else if (WandstaerkeD.Equals(BreiteD))
                {
                    Console.WriteLine(FehlerWandBreite);
                }
                else
                {
                    Console.WriteLine(EinleitungWerkstoffe);
                    AuswahlDichte = Console.ReadLine();
                    AuswahlDichteD = Convert.ToDouble(AuswahlDichte);

                    if (AuswahlDichteD.Equals(1.0))
                    {
                        String WerkstoffAuswahl;
                        Double WerkstoffAuswahlD;
                        Console.WriteLine(Werkstoffe);
                        Console.WriteLine();
                        Console.WriteLine("(1) S235");
                        Console.WriteLine("(2) AlMg4");
                        Console.WriteLine("(3) S355");
                        Console.WriteLine("(4) 42CrMo4");
                        Console.WriteLine("(5) E295");
                        Console.WriteLine("(6) E355");
                        Console.WriteLine("(7) C45");
                        WerkstoffAuswahl = Console.ReadLine();

                        WerkstoffAuswahlD = Convert.ToDouble(WerkstoffAuswahl);

                        DichteD = WerkstoffSammlung.Werkstoffe(WerkstoffAuswahlD, AuswahlSpracheD);

                        Berechnungen.LProfil(HoeheD, BreiteD, LaengeD, WandstaerkeD, DichteD, AuswahlSpracheD);



                    }
                    else if (AuswahlDichteD.Equals(2.0))
                    {
                        Console.WriteLine(ManuelleDichte);
                        Dichte = Console.ReadLine();

                        DichteD = Convert.ToDouble(Dichte);
                        HoeheD = Convert.ToDouble(Hoehe);
                        BreiteD = Convert.ToDouble(Breite);
                        LaengeD = Convert.ToDouble(Laenge);
                        WandstaerkeD = Convert.ToDouble(Wandstaerke);

                        Berechnungen.LProfil(HoeheD, BreiteD, LaengeD, WandstaerkeD, DichteD, AuswahlSpracheD);
                    }
                    else if (true)
                    {
                        Console.WriteLine(Error);
                    }
                }

            }

            else if (AuswahlProfilD.Equals(4.0))
            {
                Console.WriteLine(UngenauigkeitErklaerung);

                Console.WriteLine(TProfilHoehe);
                Hoehe = Console.ReadLine();
                HoeheD = Convert.ToDouble(Hoehe);

                Console.WriteLine(RechteckBreite);
                Breite = Console.ReadLine();
                BreiteD = Convert.ToDouble(Breite);

                Console.WriteLine(ProfilWandstaerke);
                Wandstaerke = Console.ReadLine();
                WandstaerkeD = Convert.ToDouble(Wandstaerke);

                Console.WriteLine(ProfilLaenge);
                Laenge = Console.ReadLine();
                LaengeD = Convert.ToDouble(Laenge);
                Console.WriteLine();


                Console.WriteLine(EinleitungWerkstoffe);
                AuswahlDichte = Console.ReadLine();

                AuswahlDichteD = Convert.ToDouble(AuswahlDichte);

                if (AuswahlDichteD.Equals(1.0))
                {
                    String WerkstoffAuswahl;
                    Double WerkstoffAuswahlD;
                    Console.WriteLine(Werkstoffe);
                    Console.WriteLine();
                    Console.WriteLine("(1) S235");
                    Console.WriteLine("(2) AlMg4");
                    Console.WriteLine("(3) S355");
                    Console.WriteLine("(4) 42CrMo4");
                    Console.WriteLine("(5) E295");
                    Console.WriteLine("(6) E355");
                    Console.WriteLine("(7) C45");
                    WerkstoffAuswahl = Console.ReadLine();

                    WerkstoffAuswahlD = Convert.ToDouble(WerkstoffAuswahl);

                    DichteD = WerkstoffSammlung.Werkstoffe(WerkstoffAuswahlD, AuswahlSpracheD);

                    Berechnungen.TProfil(HoeheD, BreiteD, LaengeD, WandstaerkeD, DichteD, AuswahlSpracheD);
                }
                else if (AuswahlDichteD.Equals(2.0))
                {
                    Console.WriteLine(ManuelleDichte);
                    Dichte = Console.ReadLine();

                    DichteD = Convert.ToDouble(Dichte);

                    Berechnungen.TProfil(HoeheD, BreiteD, LaengeD, WandstaerkeD, DichteD, AuswahlSpracheD);
                }

            }

            else if (AuswahlProfilD.Equals(3.0))
            {
                Console.WriteLine(UngenauigkeitErklaerung);

                Console.WriteLine(IProfilHoehe);
                Hoehe = Console.ReadLine();
                HoeheD = Convert.ToDouble(Hoehe);

                Console.WriteLine(RechteckBreite);
                Breite = Console.ReadLine();
                BreiteD = Convert.ToDouble(Breite);

                Console.WriteLine(ProfilStegBreite);
                Stegbreite = Console.ReadLine();
                StegbreiteD = Convert.ToDouble(Stegbreite);

                Console.WriteLine(ProfilFlanschBreite);
                Flanschbreite = Console.ReadLine();
                FlanschbreiteD = Convert.ToDouble(Flanschbreite);

                Console.WriteLine(ProfilLaenge);
                Laenge = Console.ReadLine();
                LaengeD = Convert.ToDouble(Laenge);
                Console.WriteLine();

                Console.WriteLine(EinleitungWerkstoffe);
                AuswahlDichte = Console.ReadLine();

                AuswahlDichteD = Convert.ToDouble(AuswahlDichte);

                if (AuswahlDichteD.Equals(1.0))
                {
                    String WerkstoffAuswahl;
                    Double WerkstoffAuswahlD;
                    Console.WriteLine(Werkstoffe);
                    Console.WriteLine();
                    Console.WriteLine("(1) S235");
                    Console.WriteLine("(2) AlMg4");
                    Console.WriteLine("(3) S355");
                    Console.WriteLine("(4) 42CrMo4");
                    Console.WriteLine("(5) E295");
                    Console.WriteLine("(6) E355");
                    Console.WriteLine("(7) C45");
                    WerkstoffAuswahl = Console.ReadLine();

                    WerkstoffAuswahlD = Convert.ToDouble(WerkstoffAuswahl);

                    DichteD = WerkstoffSammlung.Werkstoffe(WerkstoffAuswahlD, AuswahlSpracheD);

                    Berechnungen.IProfil(HoeheD, BreiteD, StegbreiteD, FlanschbreiteD, LaengeD, DichteD, AuswahlSpracheD);
                }
                else if (AuswahlDichteD.Equals(2.0))
                {
                    Console.WriteLine(ManuelleDichte);
                    Dichte = Console.ReadLine();

                    DichteD = Convert.ToDouble(Dichte);

                    Berechnungen.IProfil(HoeheD, BreiteD, StegbreiteD, FlanschbreiteD, LaengeD, DichteD, AuswahlSpracheD);
                }
            }

            else if (AuswahlProfilD.Equals(5.0))
            {
                Console.WriteLine(UngenauigkeitErklaerung);

                Console.WriteLine(UProfilHoehe);
                Hoehe = Console.ReadLine();
                HoeheD = Convert.ToDouble(Hoehe);

                Console.WriteLine(RechteckBreite);
                Breite = Console.ReadLine();
                BreiteD = Convert.ToDouble(Breite);
                                
                Console.WriteLine(ProfilStegBreite);
                Stegbreite = Console.ReadLine();
                StegbreiteD = Convert.ToDouble(Stegbreite);

                Console.WriteLine(ProfilFlanschBreite);
                Flanschbreite = Console.ReadLine();
                FlanschbreiteD = Convert.ToDouble(Flanschbreite);


                Console.WriteLine(ProfilLaenge);
                Laenge = Console.ReadLine();
                LaengeD = Convert.ToDouble(Laenge);
                Console.WriteLine();


                if (FlanschbreiteD.Equals(HoeheD / 2))
                {
                    Console.WriteLine(FehlerWandHoehe);
                }
                else if (StegbreiteD.Equals(BreiteD))
                {
                    Console.WriteLine(FehlerWandBreite);
                }
                else
                {
                    Console.WriteLine(EinleitungWerkstoffe);
                    AuswahlDichte = Console.ReadLine();
                    AuswahlDichteD = Convert.ToDouble(AuswahlDichte);

                    if (AuswahlDichteD.Equals(1.0))
                    {
                        String WerkstoffAuswahl;
                        Double WerkstoffAuswahlD;
                        Console.WriteLine(Werkstoffe);
                        Console.WriteLine();
                        Console.WriteLine("(1) S235");
                        Console.WriteLine("(2) AlMg4");
                        Console.WriteLine("(3) S355");
                        Console.WriteLine("(4) 42CrMo4");
                        Console.WriteLine("(5) E295");
                        Console.WriteLine("(6) E355");
                        Console.WriteLine("(7) C45");
                        WerkstoffAuswahl = Console.ReadLine();

                        WerkstoffAuswahlD = Convert.ToDouble(WerkstoffAuswahl);

                        DichteD = WerkstoffSammlung.Werkstoffe(WerkstoffAuswahlD, AuswahlSpracheD);

                        Berechnungen.UProfil(HoeheD, BreiteD, LaengeD, StegbreiteD, FlanschbreiteD, DichteD, AuswahlSpracheD);



                    }
                    else if (AuswahlDichteD.Equals(2.0))
                    {
                        Console.WriteLine(ManuelleDichte);
                        Dichte = Console.ReadLine();

                        DichteD = Convert.ToDouble(Dichte);
                        HoeheD = Convert.ToDouble(Hoehe);
                        BreiteD = Convert.ToDouble(Breite);
                        LaengeD = Convert.ToDouble(Laenge);
                        StegbreiteD = Convert.ToDouble(Stegbreite);
                        FlanschbreiteD = Convert.ToDouble(Flanschbreite);

                        Berechnungen.UProfil(HoeheD, BreiteD, LaengeD, StegbreiteD, FlanschbreiteD, DichteD, AuswahlSpracheD);


                    }
                }
            }

            Console.WriteLine(EndProgramm);
            Console.ReadKey();
        }
    }
}
    

