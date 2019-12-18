using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Profilrechner
{
    public class CatiaControl
    {

        public CatiaControl(Double Breite, Double Hoehe, Double Laenge, Double Wandstaerke, Double Flanschbreite, Double Durchmesser, int Profil, String Path, String name, int Material, int Speiern)
        {
            try
            {

                CatiaConnection cc = new CatiaConnection();

                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {
                    if (Profil.Equals(1))
                    {
                        //RechteckProfil

                        // Öffne ein neues Part
                        cc.ErzeugePart();
                        

                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();


                        // Generiere ein Profil
                        cc.ErzeugeProfilRechteck(Breite, Hoehe, Laenge);


                        // Extrudiere Balken
                        cc.ErzeugeBalken(Laenge, Path);
                        cc.setMaterial(Material);

                        // Speichern
                        if (Speiern == 1)
                        {
                        cc.Save();
                        }
                    }
                    else if (Profil.Equals(2))
                    {
                        //Rechteck-Hohlprofil

                        // Öffne ein neues Part
                        cc.ErzeugePart();
                        

                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();


                        // Generiere ein Profil
                        cc.ErzeugeProfilRechteck(Breite, Hoehe, Laenge);


                        // Extrudiere Balken
                        cc.ErzeugeBalken(Laenge, Path);

                        // Generieren der Tasche
                        cc.ErzeugeRechteckHohlprofil(Breite, Hoehe, Wandstaerke, Laenge, Path);

                        // Speichern
                        if (Speiern == 1)
                        {
                            cc.Save();
                        }

                    }
                    else if (Profil.Equals(3))
                    {
                        //KreisProfil
                        // Öffne ein neues Part
                        cc.ErzeugePart();
                        
                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        // Generiere ein Profil
                        cc.ErzeugeKreisprofil(Durchmesser);

                        // Extrudiere Balken
                        cc.ErzeugeBalken(Laenge, Path);

                        // Speichern
                        if (Speiern == 1)
                        {
                            cc.Save();
                        }
                    }
                    else if (Profil.Equals(4))
                    {
                        //Kreis-Hohlprofil
                        // Öffne ein neues Part
                        cc.ErzeugePart();
                        
                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        // Generiere ein Profil
                        cc.ErzeugeKreisprofil(Durchmesser);

                        // Extrudiere Balken
                        cc.ErzeugeBalken(Laenge, Path);

                        // Generieren der Tasche
                        cc.ErzeugeKreisHohlprofil(Durchmesser, Wandstaerke, Laenge, Path);

                        // Speichern
                        if (Speiern == 1)
                        {
                            cc.Save();
                        }
                    }
                    else if (Profil.Equals(5))
                    {
                        //I-Profil
                        // Öffne ein neues Part
                        cc.ErzeugePart();
                        

                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        // Generiere ein Profil
                        cc.ErzeugeIProfil(Breite, Hoehe, Wandstaerke, Flanschbreite);


                        // Extrudiere Balken
                        cc.ErzeugeBalken(Laenge, Path);

                        // Speichern
                        if (Speiern == 1)
                        {
                            cc.Save();
                        }
                    }
                    else if (Profil.Equals(6))
                    {
                        //T-Profil
                        // Öffne ein neues Part
                        cc.ErzeugePart();
                        

                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        // Generiere ein Profil
                        cc.ErzeugeTProfil(Hoehe, Breite, Wandstaerke);

                        // Extrudiere Balken
                        cc.ErzeugeBalken(Laenge, Path);

                        // Speichern
                        if (Speiern == 1)
                        {
                            cc.Save();
                        }
                    }
                    else if (Profil.Equals(7))
                    {
                        //U-Profil
                        // Öffne ein neues Part
                        cc.ErzeugePart();
                        
                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        // Generiere ein Profil
                        cc.ErzeugeUProfil(Hoehe, Breite, Wandstaerke, Flanschbreite);

                        // Extrudiere Balken
                        cc.ErzeugeBalken(Laenge, Path);

                        // Speichern
                        if (Speiern == 1)
                        {
                            cc.Save();
                        }
                    }
                    else if (Profil.Equals(8))
                    {
                        //L-Profil
                        // Öffne ein neues Part
                        cc.ErzeugePart();
                        
                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        // Generiere ein Profil
                        cc.ErzeugeLProfil(Hoehe, Breite, Wandstaerke);

                        // Extrudiere Balken
                        cc.ErzeugeBalken(Laenge, Path);

                        // Speichern
                        if (Speiern == 1)
                        {
                            cc.Save();
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Catia läuft nicht!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception aufgetreten");
            }


        }


    }
}

