﻿using System;
using System.Windows;
using INFITF;
using MECMOD;
using PARTITF;
using CATMat;
using System.Reflection;

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
        public void setPartName(String name)
        {
            hsp_catiaProfil.set_Name(name);
           
            hsp_catiaPart.Part.Update();
        }
        public void setMaterial(int Material)
        {
            

            String sFilePath = @"C:\Program Files\Dassault Systemes\B28\win_b64\startup\materials\German\Catalog.CATMaterial";
            MaterialDocument oMaterial_document = (MaterialDocument)hsp_catiaApp.Documents.Open(sFilePath);
            MaterialFamilies cFamilies_list = oMaterial_document.Families;

            foreach (MaterialFamily mf in cFamilies_list)
            {
                Console.WriteLine(mf.get_Name());
            }

            MaterialFamily myMf = cFamilies_list.Item("Metall");
            foreach (Material mat in myMf.Materials)
            {
                Console.WriteLine(mat.get_Name());
            }

            Material myStahl = myMf.Materials.Item("Stahl");
            Material myAlu = myMf.Materials.Item("Aluminium");
            MaterialManager partMatManager = hsp_catiaPart.Part.GetItem("CATMatManagerVBExt") as MaterialManager;

            // brauchen Sie Stahl im Part?
            short linkMode = 0;
            if (Material.Equals(2))
            {
                partMatManager.ApplyMaterialOnPart(hsp_catiaPart.Part, myAlu, linkMode);
            }
            else
            {
                partMatManager.ApplyMaterialOnPart(hsp_catiaPart.Part, myStahl, linkMode);
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

        public void ErzeugeBalken(Double Laenge, String Path, String name)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, Laenge);

            // Block umbenennen
            catPad1.set_Name(name);

            // Part aktualisieren
            hsp_catiaPart.Part.Update();


            //Reframe

            hsp_catiaApp.ActiveWindow.ActiveViewer.Reframe();




            hsp_catiaPart.Part.Update();
            hsp_catiaApp.ActiveWindow.ActiveViewer.CaptureToFile(CatCaptureFormat.catCaptureFormatJPEG, Path);

            hsp_catiaPart.Part.Update();
            

            // Part aktualisieren


        }

        public void ErzeugeRechteckHohlprofil(Double Breite, Double Hoehe, Double Wandstaerke, Double Laenge, String Path)
        {
            // Werte aus Variablen verarbeiten
            Double Breite2 = Breite - Wandstaerke;
            Double Hoehe2 = Hoehe - Wandstaerke;

            // Skizze umbenennen
            hsp_catiaProfil.set_Name("RechteckHohlprofil");

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

            //Reframe
            hsp_catiaApp.ActiveWindow.ActiveViewer.Reframe();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
           
            hsp_catiaApp.ActiveWindow.ActiveViewer.CaptureToFile(CatCaptureFormat.catCaptureFormatJPEG, Path);
           

        }

        public void ErzeugeKreisprofil(Double Durchmesser)
        {
            // Werte aus Variblen verarbeiten
            Double Radius = Durchmesser / 2;

            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Kreisprofil");

            // Kreisprofil in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Kreisprofil erzeugen

            // erst die Punkte
            catFactory2D1.CreateClosedCircle(0.000000, 0.000000, Radius);

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeKreisHohlprofil(Double Durchmesser, Double Wandstaerke, Double Laenge, String Path)
        {
            // Werte aus Variablen verarbeiten
            Double Radius = Durchmesser / 2;

            // Skizze umbenennen
            hsp_catiaProfil.set_Name("KreisHohlprofil");

            // Kreis-Hohlprofil in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Kreis-Hohlprofil erzeugen

            // erst die Punkte
            catFactory2D1.CreateClosedCircle(0.000000, 0.000000, Radius - Wandstaerke);

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

            //Reframe
            hsp_catiaApp.ActiveWindow.ActiveViewer.Reframe();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();

            hsp_catiaApp.ActiveWindow.ActiveViewer.CaptureToFile(CatCaptureFormat.catCaptureFormatJPEG, Path);
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

        public void ErzeugeTProfil(Double Hoehe, Double Breite, Double Wandstaerke)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("T-Profil");

            // T-Profil in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // T-Profil erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, Hoehe);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(0, Hoehe - Wandstaerke);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint((Breite / 2) - (Wandstaerke / 2), Hoehe - Wandstaerke);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint((Breite / 2) - (Wandstaerke / 2), 0);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint((Breite / 2) + (Wandstaerke / 2), 0);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint((Breite / 2) + (Wandstaerke / 2), Hoehe - Wandstaerke);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(Breite, Hoehe - Wandstaerke);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(Breite, Hoehe);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(0, Hoehe, 0, Hoehe - Wandstaerke);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(0, Hoehe - Wandstaerke, (Breite / 2) - (Wandstaerke / 2), Hoehe - Wandstaerke);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine((Breite / 2) - (Wandstaerke / 2), Hoehe - Wandstaerke, (Breite / 2) - (Wandstaerke / 2), 0);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine((Breite / 2) - (Wandstaerke / 2), 0, (Breite / 2) + (Wandstaerke / 2), 0);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine((Breite / 2) + (Wandstaerke / 2), 0, (Breite / 2) + (Wandstaerke / 2), Hoehe - Wandstaerke);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine((Breite / 2) + (Wandstaerke / 2), Hoehe - Wandstaerke, Breite, Hoehe - Wandstaerke);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(Breite, Hoehe - Wandstaerke, Breite, Hoehe);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(Breite, Hoehe, 0, Hoehe);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeUProfil(Double Hoehe, Double Breite, Double Wandstaerke, Double Flanschbreite)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("U-Profil");

            // U-Profil in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // U-Profil erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(Breite, 0);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(Breite, Flanschbreite);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(Wandstaerke, Flanschbreite);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(Wandstaerke, Hoehe - Flanschbreite);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(Breite, Hoehe - Flanschbreite);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(Breite, Hoehe);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(0, Hoehe);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(0, 0, Breite, 0);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(Breite, 0, Breite, Flanschbreite);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(Breite, Flanschbreite, Wandstaerke, Flanschbreite);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(Wandstaerke, Flanschbreite, Wandstaerke, Hoehe - Flanschbreite);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine(Wandstaerke, Hoehe - Flanschbreite, Breite, Hoehe - Flanschbreite);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(Breite, Hoehe - Flanschbreite, Breite, Hoehe);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(Breite, Hoehe, 0, Hoehe);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(0, Hoehe, 0, 0);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeLProfil(Double Hoehe, Double Breite, Double Wandstaerke)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("L-Profil");

            // U-Profil in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // U-Profil erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(Breite, 0);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(Breite, Wandstaerke);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(Wandstaerke, Wandstaerke);
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(Wandstaerke, Hoehe);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(0, Hoehe);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(0, 0, Breite, 0);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(Breite, 0, Breite, Wandstaerke);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(Breite, Wandstaerke, Wandstaerke, Wandstaerke);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(Wandstaerke, Wandstaerke, Wandstaerke, Hoehe);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D5;

            Line2D catLine2D5 = catFactory2D1.CreateLine(Wandstaerke, Hoehe, 0, Hoehe);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(0, Hoehe, 0, 0);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
        public void Save(String PartName)
        {
            String Path;
            Assembly assembly = typeof(Window1).Assembly;
            string Path2 = assembly.Location;



            int index = Path2.LastIndexOf("\\");
            Path2 = Path2.Substring(0, index);
            Path2 += "Parts\\" + PartName +".CATPart";
            Path = Path2.Replace("\\bin\\Debug", "\\");
            hsp_catiaApp.ActiveDocument.SaveAs(Path);

        }
    }
}
