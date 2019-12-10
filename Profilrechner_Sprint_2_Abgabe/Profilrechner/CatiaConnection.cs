using System;
using System.Windows;
using INFITF;
using MECMOD;
using PARTITF;


namespace Profilrechner
{
    public class CatiaConnection
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;

       
       

        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject(
                    "CATIA.Application");
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            return true;
        }

        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }

        public void ErzeugeProfilRechteck(Double Breite, Double Hoehe , Double Laenge)
        {
           

            // Werte aus Variblen verarbeiten
            Double HalbeBreite = Breite / 2;
            Double HalbeHöhe = Hoehe / 2;

            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Rechteck");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(- HalbeBreite, HalbeHöhe);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(HalbeBreite, HalbeHöhe);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(HalbeBreite, - HalbeHöhe);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(- HalbeBreite, - HalbeHöhe);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-HalbeBreite, HalbeHöhe, HalbeBreite, HalbeHöhe);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(HalbeBreite, HalbeHöhe, HalbeBreite, - HalbeHöhe);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(HalbeBreite, - HalbeHöhe, -HalbeBreite, -HalbeHöhe);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-HalbeBreite, -HalbeHöhe, -HalbeBreite, HalbeHöhe);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeBalken(Double Laenge)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, Laenge);

            // Block umbenennen
            catPad1.set_Name("Balken");

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeRechteckHohlprofil(Double Breite, Double Hoehe, Double Wandstaerke, Double Laenge)
        {
            // Werte aus Variablen verarbeiten
            Double Breite2 = Breite - Wandstaerke;
            Double Hoehe2 = Hoehe - Wandstaerke;

            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Rechteck-Hohlprofil");

            // Rechteck-Hohlprofil in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck-Hohlprofil erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-Breite2, Hoehe2);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(Breite2, Hoehe2);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(Breite2, -Hoehe2);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-Breite2, -Hoehe2);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-Breite2, Hoehe2, Breite2, Hoehe2);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(Breite2, Hoehe2, Breite2, -Hoehe2);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(Breite2, -Hoehe2, -Breite2, -Hoehe2);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-Breite2, -Hoehe2, -Breite2, Hoehe2);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();

            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pocket catPocket1 = catShapeFactory1.AddNewPocket(hsp_catiaProfil, Laenge);

            // Block umbenennen
            catPocket1.set_Name("Tasche");

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeTProfil(Double Hoehe, Double Breite, Double Wandstaerke, Double Laenge)
        {
            // Werte aus Variablen verarbeiten
            Double Breite2 = Breite - Wandstaerke;
            Double Hoehe2 = Hoehe - Wandstaerke;

            // Skizze umbenennen
            hsp_catiaProfil.set_Name("T-Profil");

            // T-Profil in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // T-Profil erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-Breite2, Hoehe2);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(Breite2, Hoehe2);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(Breite2, -Hoehe2);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-Breite2, -Hoehe2);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-Breite2, Hoehe2, Breite2, Hoehe2);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(Breite2, Hoehe2, Breite2, -Hoehe2);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(Breite2, -Hoehe2, -Breite2, -Hoehe2);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-Breite2, -Hoehe2, -Breite2, Hoehe2);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
        public void ErzeugeIProfil(Double Breite, Double Hoehe, Double Wandstaerke, Double Flanschbreite)
        {
            Double Stegbreite = Wandstaerke;

            // Werte aus Variablen verarbeiten
            Double HalbeBreite = Breite / 2;
            Double HalbeHoehe = Hoehe / 2;
            Double Steghoehe = (Hoehe - (Flanschbreite * 2)) / 2;
            Double HalbeStegbreite = Stegbreite / 2;


            // Skizze umbenennen
            hsp_catiaProfil.set_Name("I-Profil");

            // I-Profil in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // I-Profil erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-HalbeBreite, HalbeHoehe);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(HalbeBreite, HalbeHoehe);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(HalbeBreite, Steghoehe);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(HalbeStegbreite, Steghoehe);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(HalbeStegbreite, -Steghoehe);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(HalbeBreite, -Steghoehe);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(HalbeBreite, -HalbeHoehe);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(-HalbeBreite, -HalbeHoehe);
            Point2D catPoint2D9 = catFactory2D1.CreatePoint(-HalbeBreite, -Steghoehe);
            Point2D catPoint2D10 = catFactory2D1.CreatePoint(-HalbeStegbreite, -Steghoehe);
            Point2D catPoint2D11 = catFactory2D1.CreatePoint(-HalbeStegbreite, Steghoehe);
            Point2D catPoint2D12 = catFactory2D1.CreatePoint(-HalbeBreite, Steghoehe);


            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-HalbeBreite, HalbeHoehe, HalbeBreite, HalbeHoehe);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(HalbeBreite, HalbeHoehe, HalbeBreite, Steghoehe);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(HalbeBreite, Steghoehe, HalbeStegbreite, Steghoehe);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(HalbeStegbreite, Steghoehe, HalbeStegbreite, -Steghoehe);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine(HalbeStegbreite, -Steghoehe, HalbeBreite, -Steghoehe);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(HalbeBreite, -Steghoehe, HalbeBreite, -HalbeHoehe);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(HalbeBreite, -HalbeHoehe, -HalbeBreite, -HalbeHoehe);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(-HalbeBreite, -HalbeHoehe, -HalbeBreite, -Steghoehe);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D9;

            Line2D catLine2D9 = catFactory2D1.CreateLine(-HalbeBreite, -Steghoehe, -HalbeStegbreite, -Steghoehe);
            catLine2D9.StartPoint = catPoint2D9;
            catLine2D9.EndPoint = catPoint2D10;

            Line2D catLine2D10 = catFactory2D1.CreateLine(-HalbeStegbreite, -Steghoehe, -HalbeStegbreite, Steghoehe);
            catLine2D10.StartPoint = catPoint2D10;
            catLine2D10.EndPoint = catPoint2D11;

            Line2D catLine2D11 = catFactory2D1.CreateLine(-HalbeStegbreite, Steghoehe, -HalbeBreite, Steghoehe);
            catLine2D11.StartPoint = catPoint2D11;
            catLine2D11.EndPoint = catPoint2D12;

            Line2D catLine2D12 = catFactory2D1.CreateLine(-HalbeBreite, Steghoehe, -HalbeBreite, HalbeHoehe);
            catLine2D12.StartPoint = catPoint2D12;
            catLine2D12.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

    }
}
