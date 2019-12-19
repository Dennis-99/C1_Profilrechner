using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

namespace Profilrechner
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int x = 1;
        int y;
        int Materialint;
        int Profilint;
        public int CatFail;
        String PartSave;
        int Fehlercode;
        Double HoeheD;
        public Double BreiteD;
        Double LaengeD;
        Double Laenge1;
        Double DichteD;
        Double WandstaerkeD;
        Double DurchmesserD;
        Double StegbreiteD;
        Double FlanschbreiteD;
        Double Querschnitt;
        Double Volumen;
        Double Gewicht;
        Double Festigkeitx;
        Double Festigkeity;
        Double Festigkeitxy;
        Double SchwerpunktxD;
        Double SchwerpunktyD;
        Double Festigkeitu;
        Double Festigkeitv;
        Double AchswinkelRad;
        Double AchswinkelGrad;
        Double TanA;
        String QuerschnittS;
        String VolumenS;

        //Neu
        Double ex; //Maximaler Abstand (Randphasenabstand) von x-x Achse
        Double ey; //Maximaler Abstand (Randphasenabstand) von y-y Achse
        Double Wbx; //Biegewiederstandsmoment um die x-x Achse
        Double Wby; //Biegewiederstandsmoment um die y-y Achse
        Double Ip; // FTM gegen Tordion
        Double Wp; // Torsionswiederstandsmoment

        // Allgemein, .cs Datei

        String MasseS;
        String Grad;
        String Rad;

        String FTMXY;

        String FehlerS;
        String FehlerHoehe0;
        String FehlerHoeheDurch0;
        String FehlerBreite0;
        String FehlerWand0;
        String FehlerLaenge0;
        String FehlerDichte0;
        String FehlerSteg0;
        String FehlerFlansch0;
        String FehlerWandHoehe;
        String FehlerWandBreite;
        String FehlerWandDurch;
        String FehlerStegBerite;
        String FehlerFlanschIUHoehe;
        String FehlerFlanschTLHoehe;

        //lbls zuweisung
        String HoeheS;
        String HoeheDurch;
        String WandstaerkeS;
        String WandIULS;
        String WandTS;
        String IpS;
        String WpS;

        String Partname;

        BitmapImage bitmap_Screenshot = new BitmapImage();

        public Window1()
        {
            InitializeComponent();
            //Hier Breite und weite
        }

        #region Sprache
        private void btn_SpracheD_Click(object sender, RoutedEventArgs e)
        {
            HoeheS = "h: Höhe in mm";                   //
            HoeheDurch = "D: Durchmesser in mm";        //
            WandstaerkeS = "s: Wandstärke in mm";       //
            WandIULS = "s: Stegbreite in mm";           //
            WandTS = "s = t: Stegbreite in mm";               //

            QuerschnittS = "Querschnitt: ";             //
            VolumenS = "Volumen: ";                     //
            MasseS = "Masse: ";                          //
            FTMXY = "Deviationsmoment: ";
            IpS = "Flächenträgheitsmoment gegen Torsion: "; //
            Grad = "Grad: ";
            Rad = "Radiant: ";
            WpS = "Torsionswiderstandsmoment: "; 

            FehlerS = "Fehler!";                                    //
            FehlerHoehe0 = "Keine Höhe eingetragen";                //
            FehlerHoeheDurch0 = "Kein Durchmeser eingetragen";      //
            FehlerBreite0 = "Keine Breite eingetragen";             //
            FehlerWand0 = "Keine Wandstärke eingetragen";           //
            FehlerLaenge0 = "Keine Länge eingetragen";              //
            FehlerDichte0 = "Keine Dichte ausgewählt";              //
            FehlerSteg0 = "Keine Stegbreite eingetragen";           //
            FehlerFlansch0 = "Keine Flanschbreite eingetragen";     //
            FehlerWandHoehe = "Bitte stellen Sie eine Wandstärke ein, die geringer als die halbe Höhe ist.";       //
            FehlerWandBreite = "Bitte stellen Sie eine Wandstärke ein, die geringer als die halbe Breite ist.";     //
            FehlerWandDurch = "Bitte stellen Sie eine Wandstärke ein, die geringer als der Radius ist.";            //
            FehlerStegBerite = "Bitte stellen Sie eine Stegbreite ein, die geringer als die Breite ist.";               //
            FehlerFlanschIUHoehe = "Bitte stellen Sie eine Flanschbreite ein, die geringer als die halbe Höhe ist.";   //
            FehlerFlanschTLHoehe = "Bitte stellen Sie eine Flanschbreite ein, die geringer als die Höhe ist.";         //


            //Xaml Datei
            img_Rechteck.ToolTip = "Rechteck-Vollprofil";
            img_Rechteck_Hohlprofil.ToolTip = "Rechteck-Rohrprofil";
            img_Kreis.ToolTip = "Kreis-Vollprofil";
            img_Kreis_Hohlprofil.ToolTip = "Kreis-Rohrprofil";
            img_I_Profil.ToolTip = "I-Profil";
            img_T_Profil.ToolTip = "T-Profil";
            img_U_Profil.ToolTip = "U-Profil";
            img_L_Profil.ToolTip = "L-Profil";

            lbl_Profilauswahlimg.Content = "Bitte wählen Sie ein Profil aus:";      //
            lbl_Idealisierung.Content = "Bitte beachten Sie, dass die Darstellung der Profile idealisiert ist";
            lbl_Breite.Content = "b: Breite in mm";                                 //
            lbl_Laenge.Content = "Länge in m";                                      //
            lbl_Flanschbreite.Content = "t: Flanschbreite in mm";
            lbl_Dichte.Content = "Dichte in g/cm³";                                 //
            lbl_SWP.Content = "Schwerpunkt:";
            lbl_FTM.Content = "Flächenträgheitsmoment:";
            lbl_Drehwinkel.Content = "Drehwinkel:";
            lbl_HTM.Content = "Hauptträgheitsmomente:";
            lbl_Wbs.Content = "Biegewiederstandsmoment:";
            lbl_Partname.Content = "Partname eingeben";

            tvi_Werkstoffe.Header = "Werkstoffe:";

            btn_weiter.Content = "Weiter";
            btn_Berechnen.Content = "Berechnen";
            btn_Save.Content = "Speichern";
            btn_Wiederholen.Content = "Wiederholen";
            btn_Beenden.Content = "Beenden";
            btn_zurueck.Content = "Zurück";

            grid_Language1.Visibility = Visibility.Hidden;
            grid_Profilauswahlimg.Visibility = Visibility.Visible;
            

            //Ergebnis-lbls unsichtbar machen
            lbl_Querschnitt.Visibility = Visibility.Hidden;
            lbl_Voulumen.Visibility = Visibility.Hidden;
            lbl_Masse.Visibility = Visibility.Hidden;
            lbl_FTM.Visibility = Visibility.Hidden;
            lbl_FTMX.Visibility = Visibility.Hidden;
            lbl_FTMY.Visibility = Visibility.Hidden;
            lbl_SWP.Visibility = Visibility.Hidden;
            lbl_SWPX.Visibility = Visibility.Hidden;
            lbl_SWPY.Visibility = Visibility.Hidden;
            lbl_DeviationsMoment.Visibility = Visibility.Hidden;
            lbl_Drehwinkel.Visibility = Visibility.Hidden;
            lbl_Grad.Visibility = Visibility.Hidden;
            lbl_Rad.Visibility = Visibility.Hidden;
            lbl_TanA.Visibility = Visibility.Hidden;
            lbl_HTM.Visibility = Visibility.Hidden;
            lbl_HTMU.Visibility = Visibility.Hidden;
            lbl_HTMV.Visibility = Visibility.Hidden;
            lbl_Wbs.Visibility = Visibility.Hidden;
            lbl_Wbx.Visibility = Visibility.Hidden;
            lbl_Wby.Visibility = Visibility.Hidden;
        }
        

        private void btn_SpracheE_Click(object sender, RoutedEventArgs e)
        {
            HoeheS = "h: Height in mm";                   //
            HoeheDurch = "D: Diameter in mm";        //
            WandstaerkeS = "s: Wall thickness in mm";       //
            WandIULS = "s: Web width in mm";           //
            WandTS = "s = t: Web width in mm";               //

            QuerschnittS = "Cross-section area: ";             //
            VolumenS = "Volume: ";                     //
            MasseS = "Mass: ";                          //
            FTMXY = "Moment of deviation: ";
            IpS = "Geometrical moment of inertia against torsion: ";//
            Grad = "Degree: ";
            Rad = "Radian: ";
            WpS = "Resistance moment against torsion: ";


            FehlerS = "Error!";                                    //
            FehlerHoehe0 = "No height entered";                //
            FehlerHoeheDurch0 = "No diameter entered";      //
            FehlerBreite0 = "No width entered";             //
            FehlerWand0 = "No wall thickness entered";           //
            FehlerLaenge0 = "No length entered";              //
            FehlerDichte0 = "No density entered";              //
            FehlerSteg0 = "No web width entered";           //
            FehlerFlansch0 = "No flange width entered";     //
            FehlerWandHoehe = "Enter a wall thickness, that is less than half the height.";       //
            FehlerWandBreite = "Enter a wall thickness, that is less than half the witdth.";     //
            FehlerWandDurch = "Enter a wall thickness, that is less than the radius.";            //
            FehlerStegBerite = "Enter a web width, that is less than the witdth.";               //
            FehlerFlanschIUHoehe = "Enter a flange width, that is less than half the height.";   //
            FehlerFlanschTLHoehe = "Enter a flange width, that is less than the height.";         //



            //Xaml Datei
            img_Rechteck.ToolTip = "Rectangle-Solid material";
            img_Rechteck_Hohlprofil.ToolTip = "Rectangle-Pipe";
            img_Kreis.ToolTip = "Circle-Solid material";
            img_Kreis_Hohlprofil.ToolTip = "Circle-Pipe";
            img_I_Profil.ToolTip = "I-Section";
            img_T_Profil.ToolTip = "T-Section";
            img_U_Profil.ToolTip = "U-Section";
            img_L_Profil.ToolTip = "L-Section";

            lbl_Profilauswahlimg.Content = "Select a profile:";      //
            lbl_Idealisierung.Content = "Please note that the representation of the profiles is idealized";
            lbl_Breite.Content = "b: Width in mm";                                 //
            lbl_Laenge.Content = "Length in m";                                      //
            lbl_Flanschbreite.Content = "t: Flange width in mm";
            lbl_Dichte.Content = "Density in g/cm³";                                 //
            lbl_SWP.Content = "Center of mass:";
            lbl_FTM.Content = "Geometrical moment of inertia";
            lbl_Drehwinkel.Content = "Angle of rotation:";
            lbl_HTM.Content = "Principal moment of inertia:";
            lbl_Wbs.Content = "Resistance moment against bending:";       //
            lbl_Partname.Content = "Enter Partname";


            tvi_Werkstoffe.Header = "Materials:";

            btn_weiter.Content = "Continue";
            btn_Berechnen.Content = "Calculate";
            btn_Save.Content = "Save";
            btn_Wiederholen.Content = "Repeat";
            btn_Beenden.Content = "Exit";
            btn_zurueck.Content = "Return";

            grid_Language1.Visibility = Visibility.Hidden;
            grid_Profilauswahlimg.Visibility = Visibility.Visible;
           

            //Ergebnis-lbls unsichtbar machen
            lbl_Querschnitt.Visibility = Visibility.Hidden;
            lbl_Voulumen.Visibility = Visibility.Hidden;
            lbl_Masse.Visibility = Visibility.Hidden;
            lbl_FTM.Visibility = Visibility.Hidden;
            lbl_FTMX.Visibility = Visibility.Hidden;
            lbl_FTMY.Visibility = Visibility.Hidden;
            lbl_SWP.Visibility = Visibility.Hidden;
            lbl_SWPX.Visibility = Visibility.Hidden;
            lbl_SWPY.Visibility = Visibility.Hidden;
            lbl_DeviationsMoment.Visibility = Visibility.Hidden;
            lbl_Drehwinkel.Visibility = Visibility.Hidden;
            lbl_Grad.Visibility = Visibility.Hidden;
            lbl_Rad.Visibility = Visibility.Hidden;
            lbl_TanA.Visibility = Visibility.Hidden;
            lbl_HTM.Visibility = Visibility.Hidden;
            lbl_HTMU.Visibility = Visibility.Hidden;
            lbl_HTMV.Visibility = Visibility.Hidden;
            lbl_Wbs.Visibility = Visibility.Hidden;
            lbl_Wbx.Visibility = Visibility.Hidden;
            lbl_Wby.Visibility = Visibility.Hidden;
        }

        private void btn_SpracheF_Click(object sender, RoutedEventArgs e)
        {
            HoeheS = "h: Hauteur en mm";                   //
            HoeheDurch = "D: Diamètre en mm";        //
            WandstaerkeS = "s: Épaisseur de paroi en mm";       //
            WandIULS = "s: Largeur de bande en mm";           //
            WandTS = "s = t: Largeur de bande en mm";               //

            QuerschnittS = "Section transversale: ";             //
            VolumenS = "Volume: ";                     //
            MasseS = "Masse: ";                          //
            FTMXY = "Moment d'inerte: ";               //
            IpS = "Moment quadratique contre torsion: ";
            Grad = "Degré: ";
            Rad = "Radian: ";
            WpS = "Moment résistant contre torsion: ";

            FehlerS = "Erreur!";                                    //
            FehlerHoehe0 = "Vous n'avez pas entré l'hauteu";                //
            FehlerHoeheDurch0 = "Vous n'avez pas entré le diamètre";      //
            FehlerBreite0 = "Vous n'avez pas entré la largeur";             //
            FehlerWand0 = "Vous n'avez pas entré la épaisseur de paroi";           //
            FehlerLaenge0 = "Vous n'avez pas entré la longueur";              //
            FehlerDichte0 = "Vous n'avez pas entré la densité";              //
            FehlerSteg0 = "Vous n'avez pas entré le largeur de bande";           //
            FehlerFlansch0 = "Vous n'avez pas entré le largeur de bride";     //
            FehlerWandHoehe = "Veuillez seulement entrer des épaisseurs des parois moins que la moitié de la hauteur.";       //
            FehlerWandBreite = "Veuillez seulement entrer des épaisseurs des parois moins que la moitié de la largeur.";     //
            FehlerWandDurch = "Veuillez seulement entrer des épaisseurs des parois moins que le radius.";            //
            FehlerStegBerite = "Veuillez seulement entrer des largeurs des bandes moins que la largeur.";               //
            FehlerFlanschIUHoehe = "Veuillez seulement entrer des largeurs de brides moins que la moitié de la hauteur.";   //
            FehlerFlanschTLHoehe = "Veuillez seulement entrer des largeurs des brides moins que la hauteur";         //



            //Xaml Datei
            img_Rechteck.ToolTip = "Rectangle-Matériel solide";
            img_Rechteck_Hohlprofil.ToolTip = "Rectangle-Tuyau";
            img_Kreis.ToolTip = "Cercle-Matériel solide";
            img_Kreis_Hohlprofil.ToolTip = "Cercle-Tuyau";
            img_I_Profil.ToolTip = "I-Profil";
            img_T_Profil.ToolTip = "T-Profil";
            img_U_Profil.ToolTip = "U-Profil";
            img_L_Profil.ToolTip = "L-Profil";

            lbl_Profilauswahlimg.Content = "Veuillez choisir un profil:";      //
            lbl_Idealisierung.Content = "Veuillez noter que la représentation des profils est idéalisée";
            lbl_Breite.Content = "b: Largeur en mm";                                 //
            lbl_Laenge.Content = "Longueur en m";                                      //
            lbl_Flanschbreite.Content = "t: Largeur de bride in mm";
            lbl_Dichte.Content = "Densité en g/cm³";                                 //
            lbl_SWP.Content = "Centre de masse:";
            lbl_FTM.Content = "Moment quadratique";
            lbl_Drehwinkel.Content = "Angle de rotation:";
            lbl_HTM.Content = "Moment d'inerte principal:";
            lbl_Wbs.Content = "Moment résistant contre virage:";       //
            lbl_Partname.Content = "Veuillez entrer le nom de la part ";


            tvi_Werkstoffe.Header = "Matériaux:";

            btn_weiter.Content = "Continuer";
            btn_Berechnen.Content = "Calculer";
            btn_Save.Content = "Sauvegarder";
            btn_Wiederholen.Content = "Répéter";
            btn_Beenden.Content = "Terminer";
            btn_zurueck.Content = "Retourer";

            grid_Language1.Visibility = Visibility.Hidden;
            grid_Profilauswahlimg.Visibility = Visibility.Visible;
           

            //Ergebnis-lbls unsichtbar machen
            lbl_Querschnitt.Visibility = Visibility.Hidden;
            lbl_Voulumen.Visibility = Visibility.Hidden;
            lbl_Masse.Visibility = Visibility.Hidden;
            lbl_FTM.Visibility = Visibility.Hidden;
            lbl_FTMX.Visibility = Visibility.Hidden;
            lbl_FTMY.Visibility = Visibility.Hidden;
            lbl_SWP.Visibility = Visibility.Hidden;
            lbl_SWPX.Visibility = Visibility.Hidden;
            lbl_SWPY.Visibility = Visibility.Hidden;
            lbl_DeviationsMoment.Visibility = Visibility.Hidden;
            lbl_Drehwinkel.Visibility = Visibility.Hidden;
            lbl_Grad.Visibility = Visibility.Hidden;
            lbl_Rad.Visibility = Visibility.Hidden;
            lbl_TanA.Visibility = Visibility.Hidden;
            lbl_HTM.Visibility = Visibility.Hidden;
            lbl_HTMU.Visibility = Visibility.Hidden;
            lbl_HTMV.Visibility = Visibility.Hidden;
            lbl_Wbs.Visibility = Visibility.Hidden;
            lbl_Wbx.Visibility = Visibility.Hidden;
            lbl_Wby.Visibility = Visibility.Hidden;
        }
        #endregion

        private void btn_Berechnen_Click(object sender, RoutedEventArgs e)
        {
            LaengeD = Laenge1 * 1000;
            Double HoeheH = HoeheD / 2;
            Double BreiteH = BreiteD / 2;
            if (HoeheD.Equals(0))
            {
                if (Profilint.Equals(3) || Profilint.Equals(4))
                {
                    Window MBHG = new Window();
                    MBHG.Content = MessageBox.Show(FehlerHoeheDurch0, FehlerS, MessageBoxButton.OK);
                    MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
                else
                {
                    Window MBHG = new Window();
                    MBHG.Content = MessageBox.Show(FehlerHoehe0, FehlerS, MessageBoxButton.OK);
                    MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
            }
            if (BreiteD.Equals(0))
            {
                if (Profilint.Equals(1) || Profilint.Equals(2) || Profilint.Equals(5) || Profilint.Equals(6) || Profilint.Equals(7) || Profilint.Equals(8))
                {
                    Window MBHG = new Window();
                    MBHG.Content = MessageBox.Show(FehlerBreite0, FehlerS, MessageBoxButton.OK);
                    MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
            }
            if (LaengeD.Equals(0))
            {
                Window MBHG = new Window();
                MBHG.Content = MessageBox.Show(FehlerLaenge0, FehlerS, MessageBoxButton.OK);
                MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                Fehlercode = 1;
            }
            if (DichteD.Equals(0))
            {
                Window MBHG = new Window();
                MBHG.Content = MessageBox.Show(FehlerDichte0, FehlerS, MessageBoxButton.OK);
                MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                Fehlercode = 1;
            }
            if (WandstaerkeD.Equals(0))
            {
                if (Profilint.Equals(5) || Profilint.Equals(6) || Profilint.Equals(7) || Profilint.Equals(8))
                {
                    Window MBHG = new Window();
                    MBHG.Content = MessageBox.Show(FehlerSteg0, FehlerS, MessageBoxButton.OK);
                    MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
                else if (Profilint.Equals(2) || Profilint.Equals(4))
                {
                    Window MBHG = new Window();
                    MBHG.Content = MessageBox.Show(FehlerWand0, FehlerS, MessageBoxButton.OK);
                    MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
            }
            if (FlanschbreiteD.Equals(0))
            {
                if (Profilint.Equals(5) || Profilint.Equals(7))
                {
                    Window MBHG = new Window();
                    MBHG.Content = MessageBox.Show(FehlerFlansch0, FehlerS, MessageBoxButton.OK);
                    MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
            }

            if (WandstaerkeD >= HoeheH)
            {
                if (Profilint.Equals(2))
                {
                    Window MB1 = new Window();
                    MB1.Content = MessageBox.Show(FehlerWandHoehe, FehlerS, MessageBoxButton.OK);
                    MB1.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
                else if (Profilint.Equals(4))
                {
                    Window MB1 = new Window();
                    MB1.Content = MessageBox.Show(FehlerWandDurch, FehlerS, MessageBoxButton.OK);
                    MB1.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }

            }
            if (WandstaerkeD >= HoeheD)
            {
                if (Profilint.Equals(6) || Profilint.Equals(8))
                {
                    Window MB1 = new Window();
                    MB1.Content = MessageBox.Show(FehlerFlanschTLHoehe, FehlerS, MessageBoxButton.OK);
                    MB1.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
            }
            if (WandstaerkeD >= BreiteH)
            {
                if (Profilint.Equals(2))
                {
                    Window MB1 = new Window();
                    MB1.Content = MessageBox.Show(FehlerWandBreite, FehlerS, MessageBoxButton.OK);
                    MB1.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
            }
            if (WandstaerkeD >= BreiteD)
            {
                if (Profilint.Equals(5) || Profilint.Equals(6) || Profilint.Equals(7) || Profilint.Equals(8))
                {
                    Window MB1 = new Window();
                    MB1.Content = MessageBox.Show(FehlerStegBerite, FehlerS, MessageBoxButton.OK);
                    MB1.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
            }
            if (FlanschbreiteD >= HoeheH)
            {
                if (Profilint.Equals(5) || Profilint.Equals(7))
                {
                    Window MB1 = new Window();
                    MB1.Content = MessageBox.Show(FehlerFlanschIUHoehe, FehlerS, MessageBoxButton.OK);
                    MB1.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }

            }


            if (Fehlercode.Equals(1))
            {
                ThisIsYoustATreeView.Visibility = Visibility.Visible;
                tb_hoehe.Text = "";
                tb_Breite.Text = "";
                tb_Laenge.Text = "";
                tb_Wandstaerke.Text = "";
                tb_Flanschbreite.Text = "";
                tb_Dichte.Text = "";
                Fehlercode = 0;
            }
            else
            {
                if (Profilint.Equals(1))
                {
                    //Rechteckvoll

                    Querschnitt = HoeheD * BreiteD;
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = (Volumen * DichteD);
                    Festigkeitx = (BreiteD * Math.Pow(HoeheD, 3)) / 12;
                    Festigkeity = (HoeheD * Math.Pow(BreiteD, 3)) / 12;

                    //Neu
                    //ey, ex - Randphasenabstände
                    ex = HoeheD / 2;
                    ey = BreiteD / 2;
                    //Wbx, Wby - Biegewiederstandamomente
                    Wbx = Festigkeitx / ex;
                    Wby = Festigkeity / ey;

                    lbl_Querschnitt.Content = QuerschnittS + Math.Round((Querschnitt / 100), 3) + "cm²";
                    lbl_Voulumen.Content = VolumenS + Math.Round((Volumen / 1000), 3) + "cm³";
                    lbl_Masse.Content = MasseS + Math.Round((Gewicht / 1000000), 3) + "kg";
                    lbl_FTMX.Content = "x: " + Math.Round((Festigkeitx / 10000), 3) + "cm⁴";
                    lbl_FTMY.Content = "y: " + Math.Round((Festigkeity / 10000), 3) + "cm⁴";

                    //neu Test
                    lbl_Wbx.Content = "x: " + Math.Round(Wbx / 1000, 3) + "cm³";
                    lbl_Wby.Content = "y: " + Math.Round(Wby / 1000, 3) + "cm³";

                    //Ergebniss-lbls Sichtbar machen
                    lbl_Querschnitt.Visibility = Visibility.Visible;
                    lbl_Voulumen.Visibility = Visibility.Visible;
                    lbl_Masse.Visibility = Visibility.Visible;
                    lbl_FTM.Visibility = Visibility.Visible;
                    lbl_FTMX.Visibility = Visibility.Visible;
                    lbl_FTMY.Visibility = Visibility.Visible;
                    lbl_Wbs.Visibility = Visibility.Visible;
                    lbl_Wbx.Visibility = Visibility.Visible;
                    lbl_Wby.Visibility = Visibility.Visible;


                }
                else if (Profilint.Equals(2))
                {
                    //Rechteckrohr

                    Querschnitt = (HoeheD * BreiteD) - ((HoeheD - (2 * WandstaerkeD)) * (BreiteD - (2 * WandstaerkeD)));
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = (Volumen * DichteD);
                    Festigkeitx = ((BreiteD * Math.Pow(HoeheD, 3)) - ((BreiteD - (2 * WandstaerkeD)) * Math.Pow((HoeheD - (2 * WandstaerkeD)), 3))) / 12;
                    Festigkeity = ((HoeheD * Math.Pow(BreiteD, 3)) - ((HoeheD - (2 * WandstaerkeD)) * Math.Pow((BreiteD - (2 * WandstaerkeD)), 3))) / 12;

                    //Neu
                    //ey, ex - Randphasenabstände
                    ex = HoeheD / 2;
                    ey = BreiteD / 2;
                    //Wbx, Wby - Biegewiederstandamomente
                    Wbx = Festigkeitx / ex;
                    Wby = Festigkeity / ey;

                    lbl_Querschnitt.Content = QuerschnittS + Math.Round((Querschnitt / 100), 3) + "cm²";
                    lbl_Voulumen.Content = VolumenS + Math.Round((Volumen / 1000), 3) + "cm³";
                    lbl_Masse.Content = MasseS + Math.Round(Gewicht / 1000000, 3) + "kg";
                    lbl_FTMX.Content = "x: " + Math.Round(Festigkeitx / 10000, 3) + "cm⁴";
                    lbl_FTMY.Content = "y: " + Math.Round(Festigkeity / 10000, 3) + "cm⁴";

                    //neu Test
                    lbl_Wbx.Content = "x: " + Math.Round(Wbx / 1000, 3) + "cm³";
                    lbl_Wby.Content = "y: " + Math.Round(Wby / 1000, 3) + "cm³";

                    //Ergebniss-lbls Sichtbar machen
                    lbl_Querschnitt.Visibility = Visibility.Visible;
                    lbl_Voulumen.Visibility = Visibility.Visible;
                    lbl_Masse.Visibility = Visibility.Visible;
                    lbl_FTM.Visibility = Visibility.Visible;
                    lbl_FTMX.Visibility = Visibility.Visible;
                    lbl_FTMY.Visibility = Visibility.Visible;
                    lbl_Wbs.Visibility = Visibility.Visible;
                    lbl_Wbx.Visibility = Visibility.Visible;
                    lbl_Wby.Visibility = Visibility.Visible;
                }
                else if (Profilint.Equals(3))
                {
                    //Kreisvoll

                    DurchmesserD = HoeheD;
                    Querschnitt = Math.Pow(DurchmesserD, 2) * Math.PI / 4;
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = (Volumen * DichteD) / 1000;
                    Festigkeitx = (Math.PI * (Math.Pow(DurchmesserD, 4))) / 64;
                    Festigkeity = (Math.PI * (Math.Pow(DurchmesserD, 4))) / 64;

                    //Neu
                    //ey, ex - Randphasenabstände
                    ex = DurchmesserD / 2;
                    ey = DurchmesserD / 2;
                    //Wbx, Wby - Biegewiederstandamomente
                    Wbx = Festigkeitx / ex;
                    Wby = Festigkeity / ey;
                    // Ip - FTM Torsion
                    Ip = (Math.PI / 32) * Math.Pow(DurchmesserD, 4);
                    // Wp - Torsionswiederstandsmoment
                    Wp = (Math.PI / 16) * Math.Pow(DurchmesserD, 3);

                    lbl_Querschnitt.Content = QuerschnittS + Math.Round(Querschnitt / 100, 3) + "cm²";
                    lbl_Voulumen.Content = VolumenS + Math.Round(Volumen / 1000, 3) + "cm³";
                    lbl_Masse.Content = MasseS + Math.Round(Gewicht / 1000000, 3) + "kg";
                    lbl_FTMX.Content = "x: " + Math.Round(Festigkeitx / 10000, 3) + "cm⁴";
                    lbl_FTMY.Content = "y: " + Math.Round(Festigkeity / 10000, 3) + "cm⁴";

                    //neu Test
                    lbl_Wbx.Content = "x: " + Math.Round(Wbx / 1000, 3) + "cm³";
                    lbl_Wby.Content = "y: " + Math.Round(Wby / 1000, 3) + "cm³";
                    lbl_Ip.Content = IpS + Math.Round(Ip / 10000, 3) + "cm⁴";
                    lbl_Wp.Content = WpS + Math.Round(Wp / 1000, 3) + "cm³";

                    //Ergebniss-lbls Sichtbar machen
                    lbl_Querschnitt.Visibility = Visibility.Visible;
                    lbl_Voulumen.Visibility = Visibility.Visible;
                    lbl_Masse.Visibility = Visibility.Visible;
                    lbl_FTM.Visibility = Visibility.Visible;
                    lbl_FTMX.Visibility = Visibility.Visible;
                    lbl_FTMY.Visibility = Visibility.Visible;
                    lbl_Wbs.Visibility = Visibility.Visible;
                    lbl_Wbx.Visibility = Visibility.Visible;
                    lbl_Wby.Visibility = Visibility.Visible;
                    lbl_Ip.Visibility = Visibility.Visible;
                    lbl_Wp.Visibility = Visibility.Visible;

                }
                else if (Profilint.Equals(4))
                {
                    //Kreisrohr

                    DurchmesserD = HoeheD;
                    Querschnitt = ((Math.Pow(DurchmesserD, 2) * Math.PI) - (Math.Pow((DurchmesserD - (2 * WandstaerkeD)), 2) * Math.PI)) / 4;
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = (Volumen * DichteD);
                    Festigkeitx = (Math.PI * (Math.Pow(DurchmesserD, 4) - Math.Pow((DurchmesserD - (2 * WandstaerkeD)), 4))) / 64;
                    Festigkeity = (Math.PI * (Math.Pow(DurchmesserD, 4) - Math.Pow((DurchmesserD - (2 * WandstaerkeD)), 4))) / 64;

                    //Neu
                    //ey, ex - Randphasenabstände
                    ex = DurchmesserD / 2;
                    ey = DurchmesserD / 2;
                    //Wbx, Wby - Biegewiederstandamomente
                    Wbx = Festigkeitx / ex;
                    Wby = Festigkeity / ey;
                    // Ip - FTM Torsion
                    Ip = (Math.PI / 32) * (Math.Pow(DurchmesserD, 4) - Math.Pow((DurchmesserD - (2 * WandstaerkeD)), 4));
                    // Wp - Torsionswiederstandsmoment
                    Wp = (Math.PI / 16) * ((Math.Pow(DurchmesserD, 4) - Math.Pow((DurchmesserD - (2 * WandstaerkeD)), 4)) / DurchmesserD);

                    lbl_Querschnitt.Content = QuerschnittS + Math.Round(Querschnitt / 100, 3) + "cm²";
                    lbl_Voulumen.Content = VolumenS + Math.Round(Volumen / 1000, 3) + "cm³";
                    lbl_Masse.Content = MasseS + Math.Round(Gewicht / 1000000, 3) + "kg";
                    lbl_FTMX.Content = "x: " + Math.Round(Festigkeitx / 10000, 3) + "cm⁴";
                    lbl_FTMY.Content = "y: " + Math.Round(Festigkeity / 10000, 3) + "cm⁴";

                    //neu Test
                    lbl_Wbx.Content = "x: " + Math.Round(Wbx / 1000, 3) + "cm³";
                    lbl_Wby.Content = "y: " + Math.Round(Wby / 1000, 3) + "cm³";
                    lbl_Ip.Content = IpS + Math.Round(Ip / 10000, 3) + "cm⁴";
                    lbl_Wp.Content = WpS + Math.Round(Wp / 1000, 3) + "cm³";

                    //Ergebniss-lbls Sichtbar machen
                    lbl_Querschnitt.Visibility = Visibility.Visible;
                    lbl_Voulumen.Visibility = Visibility.Visible;
                    lbl_Masse.Visibility = Visibility.Visible;
                    lbl_FTM.Visibility = Visibility.Visible;
                    lbl_FTMX.Visibility = Visibility.Visible;
                    lbl_FTMY.Visibility = Visibility.Visible;
                    lbl_Wbs.Visibility = Visibility.Visible;
                    lbl_Wbx.Visibility = Visibility.Visible;
                    lbl_Wby.Visibility = Visibility.Visible;
                    lbl_Ip.Visibility = Visibility.Visible;
                    lbl_Wp.Visibility = Visibility.Visible;

                }


                else if (Profilint.Equals(5))
                {
                    // I Profil

                    StegbreiteD = WandstaerkeD;
                    Double Breiteb;
                    Double Hoeheh;
                    //Zwischenrechnung
                    Breiteb = BreiteD - StegbreiteD;
                    Hoeheh = HoeheD - 2 * FlanschbreiteD;

                    Querschnitt = (WandstaerkeD * BreiteD) + (WandstaerkeD * (HoeheD - WandstaerkeD));
                    Volumen = (WandstaerkeD * BreiteD * LaengeD) + ((HoeheD - WandstaerkeD) * WandstaerkeD * LaengeD);
                    Gewicht = (Volumen * DichteD);
                    SchwerpunktyD = HoeheD / 2;
                    SchwerpunktxD = BreiteD / 2;
                    Festigkeitx = (BreiteD * Math.Pow(HoeheD, 3) / 12) - (Breiteb * Math.Pow(Hoeheh, 3) / 12);
                    Festigkeity = 2 * ((FlanschbreiteD * Math.Pow(BreiteD, 3) / 12)) + ((Hoeheh * Math.Pow(StegbreiteD, 3)) / 12);

                    //Neu
                    //ey, ex - Randphasenabstände
                    ex = HoeheD / 2;
                    ey = BreiteD / 2;
                    //Wbx, Wby - Biegewiederstandamomente
                    Wbx = Festigkeitx / ex;
                    Wby = Festigkeity / ey;

                    lbl_Querschnitt.Content = QuerschnittS + Math.Round(Querschnitt / 100, 3) + "cm²";
                    lbl_Voulumen.Content = VolumenS + Math.Round(Volumen / 1000, 3) + "cm³";
                    lbl_Masse.Content = MasseS + Math.Round(Gewicht / 1000000, 3) + "kg";
                    lbl_FTMX.Content = "x: " + Math.Round(Festigkeitx / 10000, 3) + "cm⁴";
                    lbl_FTMY.Content = "y: " + Math.Round(Festigkeity / 10000, 3) + "cm⁴";

                    lbl_SWPX.Content = "x: " + Math.Round(SchwerpunktxD / 10, 3) + "cm";
                    lbl_SWPY.Content = "y: " + Math.Round(SchwerpunktyD / 10, 3) + "cm";

                    //neu Test
                    lbl_Wbx.Content = "x: " + Math.Round(Wbx / 1000, 3) + "cm³";
                    lbl_Wby.Content = "y: " + Math.Round(Wby / 1000, 3) + "cm³";

                    //Ergebniss-lbls Sichtbar machen
                    lbl_Querschnitt.Visibility = Visibility.Visible;
                    lbl_Voulumen.Visibility = Visibility.Visible;
                    lbl_Masse.Visibility = Visibility.Visible;
                    lbl_FTM.Visibility = Visibility.Visible;
                    lbl_FTMX.Visibility = Visibility.Visible;
                    lbl_FTMY.Visibility = Visibility.Visible;
                    lbl_SWP.Visibility = Visibility.Visible;
                    lbl_SWPX.Visibility = Visibility.Visible;
                    lbl_SWPY.Visibility = Visibility.Visible;
                    lbl_Wbs.Visibility = Visibility.Visible;
                    lbl_Wbx.Visibility = Visibility.Visible;
                    lbl_Wby.Visibility = Visibility.Visible;

                }
                else if (Profilint.Equals(6))
                {
                    // T Profil

                    StegbreiteD = WandstaerkeD;
                    Querschnitt = (WandstaerkeD * BreiteD) + (WandstaerkeD * (HoeheD - WandstaerkeD));
                    Volumen = (WandstaerkeD * BreiteD * LaengeD) + ((HoeheD - WandstaerkeD) * WandstaerkeD * LaengeD);
                    Gewicht = (Volumen * DichteD);
                    SchwerpunktyD = ((WandstaerkeD * (HoeheD - WandstaerkeD)) * ((HoeheD - WandstaerkeD) / 2) + ((WandstaerkeD * BreiteD) * (HoeheD - (WandstaerkeD / 2))))
                                          / ((WandstaerkeD * (HoeheD - WandstaerkeD)) + (BreiteD * WandstaerkeD));
                    SchwerpunktxD = BreiteD / 2;
                    Festigkeitx = ((WandstaerkeD * Math.Pow((HoeheD - WandstaerkeD), 3)) / 12) + (WandstaerkeD * (HoeheD - WandstaerkeD)) * Math.Pow((SchwerpunktyD - ((HoeheD - WandstaerkeD) / 2)), 2)
                   //  +                     Ixx2                     +            A2            *                           l2²
                   + ((BreiteD * Math.Pow(WandstaerkeD, 3)) / 12) + (WandstaerkeD * BreiteD) * Math.Pow(((BreiteD - (WandstaerkeD / 2)) - SchwerpunktyD), 2);
                    //                               Iyy1                          +                     Iyy2
                    Festigkeity = (((HoeheD - WandstaerkeD) * Math.Pow(WandstaerkeD, 3)) / 12) + ((WandstaerkeD * Math.Pow(BreiteD, 3)) / 12);

                    //Neu
                    //ey, ex - Randphasenabstände
                    ex = SchwerpunktyD;
                    ey = BreiteD / 2;
                    //Wbx, Wby - Biegewiederstandamomente
                    Wbx = Festigkeitx / ex;
                    Wby = Festigkeity / ey;

                    lbl_Querschnitt.Content = QuerschnittS + Math.Round(Querschnitt / 100, 3) + "cm²";
                    lbl_Voulumen.Content = VolumenS + Math.Round(Volumen / 1000, 3) + "cm³";
                    lbl_Masse.Content = MasseS + Math.Round(Gewicht / 1000000, 3) + "kg";
                    lbl_FTMX.Content = "x: " + Math.Round(Festigkeitx / 10000, 3) + "cm⁴";
                    lbl_FTMY.Content = "y: " + Math.Round(Festigkeity / 10000, 3) + "cm⁴";

                    lbl_SWPX.Content = "x: " + Math.Round(SchwerpunktxD / 10, 3) + "cm";
                    lbl_SWPY.Content = "y: " + Math.Round(SchwerpunktyD / 10, 3) + "cm";

                    //neu Test
                    lbl_Wbx.Content = "x: " + Math.Round(Wbx / 1000, 3) + "cm³";
                    lbl_Wby.Content = "y: " + Math.Round(Wby / 1000, 3) + "cm³";

                    //Ergebniss-lbls Sichtbar machen
                    lbl_Querschnitt.Visibility = Visibility.Visible;
                    lbl_Voulumen.Visibility = Visibility.Visible;
                    lbl_Masse.Visibility = Visibility.Visible;
                    lbl_FTM.Visibility = Visibility.Visible;
                    lbl_FTMX.Visibility = Visibility.Visible;
                    lbl_FTMY.Visibility = Visibility.Visible;
                    lbl_SWP.Visibility = Visibility.Visible;
                    lbl_SWPX.Visibility = Visibility.Visible;
                    lbl_SWPY.Visibility = Visibility.Visible;
                    lbl_Wbs.Visibility = Visibility.Visible;
                    lbl_Wbx.Visibility = Visibility.Visible;
                    lbl_Wby.Visibility = Visibility.Visible;
                }
                else if (Profilint.Equals(7))
                {
                    // U Profil

                    Querschnitt = (BreiteD * HoeheD) - ((BreiteD - StegbreiteD) * (HoeheD - (2 * FlanschbreiteD)));
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = (Volumen * DichteD);
                    SchwerpunktxD = ((BreiteD * HoeheD * (BreiteD / 2)) - ((BreiteD - StegbreiteD) * (HoeheD - (2 * FlanschbreiteD)) * ((BreiteD - StegbreiteD) / 2 + StegbreiteD)))
                                     / ((BreiteD * HoeheD) - ((BreiteD - StegbreiteD) * (HoeheD - (2 * FlanschbreiteD))));
                    SchwerpunktyD = HoeheD / 2;
                    Festigkeitx = ((BreiteD * Math.Pow(HoeheD, 3)) / 12) - (((BreiteD - StegbreiteD) * Math.Pow((HoeheD - (2 * FlanschbreiteD)), 3)) / 12);
                    Festigkeity = ((HoeheD * Math.Pow(BreiteD, 3)) / 12 + ((BreiteD * HoeheD) * Math.Pow(((BreiteD / 2) - SchwerpunktxD), 2)))
                                   - (((HoeheD - (2 * FlanschbreiteD)) * Math.Pow((BreiteD - StegbreiteD), 3)) / 12
                                   + ((BreiteD - StegbreiteD) * (HoeheD - (2 * FlanschbreiteD))) * Math.Pow((((BreiteD - StegbreiteD) / 2 + StegbreiteD) - SchwerpunktxD), 2));

                    //Neu
                    //ey, ex - Randphasenabstände
                    ex = HoeheD / 2;
                    ey = BreiteD - SchwerpunktxD;
                    //Wbx, Wby - Biegewiederstandamomente
                    Wbx = Festigkeitx / ex;
                    Wby = Festigkeity / ey;

                    lbl_Querschnitt.Content = QuerschnittS + Math.Round(Querschnitt / 100, 3) + "cm²";
                    lbl_Voulumen.Content = VolumenS + Math.Round(Volumen / 1000, 3) + "cm³";
                    lbl_Masse.Content = MasseS + Math.Round(Gewicht / 1000000, 3) + "kg";
                    lbl_FTMX.Content = "x: " + Math.Round(Festigkeitx / 10000, 3) + "cm⁴";
                    lbl_FTMY.Content = "y: " + Math.Round(Festigkeity / 10000, 3) + "cm⁴";

                    lbl_SWPX.Content = "x: " + Math.Round(SchwerpunktxD / 10, 3) + "cm";
                    lbl_SWPY.Content = "y: " + Math.Round(SchwerpunktyD / 10, 3) + "cm";

                    //neu Test
                    lbl_Wbx.Content = "x: " + Math.Round(Wbx / 1000, 3) + "cm³";
                    lbl_Wby.Content = "y: " + Math.Round(Wby / 1000, 3) + "cm³";

                    //Ergebniss-lbls Sichtbar machen
                    lbl_Querschnitt.Visibility = Visibility.Visible;
                    lbl_Voulumen.Visibility = Visibility.Visible;
                    lbl_Masse.Visibility = Visibility.Visible;
                    lbl_FTM.Visibility = Visibility.Visible;
                    lbl_FTMX.Visibility = Visibility.Visible;
                    lbl_FTMY.Visibility = Visibility.Visible;
                    lbl_SWP.Visibility = Visibility.Visible;
                    lbl_SWPX.Visibility = Visibility.Visible;
                    lbl_SWPY.Visibility = Visibility.Visible;
                    lbl_Wbs.Visibility = Visibility.Visible;
                    lbl_Wbx.Visibility = Visibility.Visible;
                    lbl_Wby.Visibility = Visibility.Visible;
                }
                else if (Profilint.Equals(8))
                {
                    //L PRofil

                    Querschnitt = BreiteD * WandstaerkeD + (HoeheD - WandstaerkeD) * WandstaerkeD;
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = (Volumen * DichteD);
                    SchwerpunktxD = (BreiteD * HoeheD * (BreiteD / 2) - (BreiteD - WandstaerkeD) * (HoeheD - WandstaerkeD) * ((BreiteD - WandstaerkeD) / 2 + WandstaerkeD)) / ((BreiteD * HoeheD) - ((BreiteD - WandstaerkeD) * (HoeheD - WandstaerkeD)));
                    SchwerpunktyD = (HoeheD * BreiteD * (HoeheD / 2) - (HoeheD - WandstaerkeD) * (BreiteD - WandstaerkeD) * ((HoeheD - WandstaerkeD) / 2 + WandstaerkeD)) / ((HoeheD * BreiteD) - ((HoeheD - WandstaerkeD) * (BreiteD - WandstaerkeD)));
                    Festigkeitx = ((WandstaerkeD * Math.Pow(HoeheD, 3) / 12) + (WandstaerkeD * HoeheD) * Math.Pow((HoeheD / 2 - SchwerpunktyD), 2)) + (((BreiteD - WandstaerkeD) * Math.Pow(WandstaerkeD, 3) / 12) + ((Math.Abs(BreiteD - WandstaerkeD) * WandstaerkeD) * Math.Pow((SchwerpunktyD - (WandstaerkeD / 2)), 2)));                                       //Klappt
                    Festigkeity = ((HoeheD * Math.Pow(WandstaerkeD, 3) / 12) + (WandstaerkeD * HoeheD) * Math.Pow((SchwerpunktxD - (WandstaerkeD / 2)), 2)) + ((WandstaerkeD * Math.Pow((BreiteD - WandstaerkeD), 3) / 12) + (((BreiteD - WandstaerkeD) * WandstaerkeD) * Math.Pow(((BreiteD - WandstaerkeD) / 2 + WandstaerkeD) - SchwerpunktxD, 2)));      //Klappt

                    Festigkeitxy = -Math.Pow((BreiteD * HoeheD), 2) / 4 - (-(Math.Pow((BreiteD * HoeheD), 2) - Math.Pow((HoeheD * WandstaerkeD), 2) - Math.Pow((BreiteD * WandstaerkeD), 2) + Math.Pow(WandstaerkeD, 4)) / 4) + (((BreiteD * HoeheD) - Math.Abs(BreiteD - WandstaerkeD) * Math.Abs(HoeheD - WandstaerkeD)) * SchwerpunktxD * SchwerpunktyD);

                    //Achswinkel = (1 / 2) * Math.Atan((2 * Festigkeitxy) / (Festigkeitxx - Festigkeityy));
                    AchswinkelRad = (Math.Atan((2 * Festigkeitxy) / (Festigkeitx - Festigkeity))) / 2;
                    AchswinkelGrad = AchswinkelRad * 180 / Math.PI;
                    TanA = Math.Tan(AchswinkelRad);

                    Festigkeitu = (Festigkeitx + Festigkeity) / 2 + (((Festigkeitx - Festigkeity) / 2) * Math.Cos(2 * AchswinkelRad)) + Festigkeitxy * Math.Sin(2 * AchswinkelRad);
                    Festigkeitv = (Festigkeitx + Festigkeity) / 2 - (((Festigkeitx - Festigkeity) / 2) * Math.Cos(2 * AchswinkelRad)) - Festigkeitxy * Math.Sin(2 * AchswinkelRad);

                    //Neu
                    //ey, ex - Randphasenabstände
                    ex = HoeheD - SchwerpunktyD;
                    ey = BreiteD - SchwerpunktxD;
                    //Wbx, Wby - Biegewiederstandamomente
                    Wbx = Festigkeitx / ex;
                    Wby = Festigkeity / ey;

                    lbl_Querschnitt.Content = QuerschnittS + Math.Round(Querschnitt / 100, 3) + "cm²";
                    lbl_Voulumen.Content = VolumenS + Math.Round(Volumen / 1000, 3) + "cm³";
                    lbl_Masse.Content = MasseS + Math.Round(Gewicht / 1000000, 3) + "kg";
                    lbl_FTMX.Content = "x: " + Math.Round(Festigkeitx / 10000, 3) + "cm⁴";
                    lbl_FTMY.Content = "y: " + Math.Round(Festigkeity / 10000, 3) + "cm⁴";

                    lbl_SWPX.Content = "x: " + Math.Round(SchwerpunktxD / 10, 3) + "cm";
                    lbl_SWPY.Content = "y: " + Math.Round(SchwerpunktyD / 10, 3) + "cm";

                    lbl_DeviationsMoment.Content = FTMXY + Math.Round(Festigkeitxy / 10000, 3) + "cm⁴";

                    lbl_Grad.Content = Grad + Math.Round(AchswinkelGrad, 2) + "°";
                    lbl_Rad.Content = Rad + Math.Round(AchswinkelRad, 3);
                    lbl_TanA.Content = "tan(α): " + Math.Round(TanA, 3);

                    lbl_HTMU.Content = "u: " + Math.Round(Festigkeitu / 10000, 3) + "cm⁴";
                    lbl_HTMV.Content = "v: " + Math.Round(Festigkeitv / 10000, 3) + "cm⁴";

                    //neu Test
                    lbl_Wbx.Content = "x: " + Math.Round(Wbx / 1000, 3) + "cm³";
                    lbl_Wby.Content = "y: " + Math.Round(Wby / 1000, 3) + "cm³";

                    //Ergebniss-lbls Sichtbar machen
                    lbl_Querschnitt.Visibility = Visibility.Visible;
                    lbl_Voulumen.Visibility = Visibility.Visible;
                    lbl_Masse.Visibility = Visibility.Visible;
                    lbl_FTM.Visibility = Visibility.Visible;
                    lbl_FTMX.Visibility = Visibility.Visible;
                    lbl_FTMY.Visibility = Visibility.Visible;
                    lbl_SWP.Visibility = Visibility.Visible;
                    lbl_SWPX.Visibility = Visibility.Visible;
                    lbl_SWPY.Visibility = Visibility.Visible;
                    lbl_DeviationsMoment.Visibility = Visibility.Visible;
                    lbl_Drehwinkel.Visibility = Visibility.Visible;
                    lbl_Grad.Visibility = Visibility.Visible;
                    lbl_Rad.Visibility = Visibility.Visible;
                    lbl_TanA.Visibility = Visibility.Visible;
                    lbl_HTM.Visibility = Visibility.Visible;
                    lbl_HTMU.Visibility = Visibility.Visible;
                    lbl_HTMV.Visibility = Visibility.Visible;
                    lbl_Wbs.Visibility = Visibility.Visible;
                    lbl_Wbx.Visibility = Visibility.Visible;
                    lbl_Wby.Visibility = Visibility.Visible;
                }

            }
        }

        #region Textboxen
        private void tb_hoehe_TextChanged(object sender, TextChangedEventArgs e)
        {
            string test;
            String Zeichen;
            Zeichen = "0123456789.,";
            //StringBuilder Zugelassen = new StringBuilder();
                if (tb_hoehe.Text.Equals(""))
                {

                }
                else
                {
                    test = tb_hoehe.Text;
                    foreach (char ch in test)
                        if (Zeichen.Contains(ch.ToString()))
                        {
                            HoeheD = Convert.ToDouble(tb_hoehe.Text);
                        }
                        else
                        {
                            tb_hoehe.Text = "";
                        }
                }

        }

        private void tb_Breite_TextChanged(object sender, TextChangedEventArgs e)
        {
            string test;
            String Zeichen;
            Zeichen = "0123456789.,";
            //StringBuilder Zugelassen = new StringBuilder();
                if (tb_Breite.Text.Equals(""))
                {

                }
                else
                {
                    test = tb_Breite.Text;
                    foreach (char ch in test)
                        if (Zeichen.Contains(ch.ToString()))
                        {
                            BreiteD = Convert.ToDouble(tb_Breite.Text);
                        }
                        else
                        {
                            tb_Breite.Text = "";
                        }
                }
        }

        private void tb_Laenge_TextChanged(object sender, TextChangedEventArgs e)
        {
            string test;
            String Zeichen;
            Zeichen = "0123456789.,";
            //StringBuilder Zugelassen = new StringBuilder();
                if (tb_Laenge.Text.Equals(""))
                {

                }
                else
                {
                    test = tb_Laenge.Text;
                    foreach (char ch in test)
                        if (Zeichen.Contains(ch.ToString()))
                        {
                            Laenge1 = Convert.ToDouble(tb_Laenge.Text);
                        }
                        else
                        {
                            tb_Laenge.Text = "";
                        }
                }

        }

        private void tb_Wandstaerke_TextChanged(object sender, TextChangedEventArgs e)
        {
            string test;
            String Zeichen;
            Zeichen = "0123456789.,";
            //StringBuilder Zugelassen = new StringBuilder();
                if (tb_Wandstaerke.Text.Equals(""))
                {

                }
                else
                {
                    test = tb_Wandstaerke.Text;
                    foreach (char ch in test)
                        if (Zeichen.Contains(ch.ToString()))
                        {
                            WandstaerkeD = Convert.ToDouble(tb_Wandstaerke.Text);
                        }
                        else
                        {
                            tb_Wandstaerke.Text = "";
                        }
                }

        }

        private void tb_Dichte_TextChanged(object sender, TextChangedEventArgs e)
        {
            string test;
            String Zeichen;
            Zeichen = "0123456789.,";
            //StringBuilder Zugelassen = new StringBuilder();
                if (tb_Dichte.Text.Equals(""))
                {

                }
                else
                {
                    test = tb_Dichte.Text;
                    foreach (char ch in test)
                        if (Zeichen.Contains(ch.ToString()))
                        {
                            DichteD = Convert.ToDouble(tb_Dichte.Text);
                        }
                        else
                        {
                            tb_Dichte.Text = "";
                        }
                }
        }
    
        private void tb_Flanschbreite_TextChanged(object sender, TextChangedEventArgs e)
        {
            string test;
            String Zeichen;
            Zeichen = "0123456789.,";
            //StringBuilder Zugelassen = new StringBuilder();
                if (tb_Flanschbreite.Text.Equals(""))
                {

                }
                else
                {
                    test = tb_Flanschbreite.Text;
                    foreach (char ch in test)
                        if (Zeichen.Contains(ch.ToString()))
                        {
                            FlanschbreiteD = Convert.ToDouble(tb_Flanschbreite.Text);
                        }
                        else
                        {
                            tb_Flanschbreite.Text = "";
                        }
                }
        }

        private void tb_Partname_TextChanged(object sender, TextChangedEventArgs e)
        {
            

           Partname = tb_Partname.Text;

        }
        #endregion

        #region treeview
        //
        // Treeview zuweisung
        //

        private void Tvi_S235_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DichteD = Convert.ToDouble(7.85);
           
            tb_Dichte.Text = "7,85";
            Materialint = 1;
        }

        private void Tvi_355_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DichteD = Convert.ToDouble(7.85);
            
            tb_Dichte.Text = "7,85";
            Materialint = 1;
        }

        private void Tvi_42CrMo4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DichteD = Convert.ToDouble(7.85);
            
            tb_Dichte.Text = "7,85";
            Materialint = 1;
        }

        private void Tvi_E295_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DichteD = Convert.ToDouble(7.85);
            
            tb_Dichte.Text = "7,85";
            Materialint = 1;
        }

        private void Tvi_E355_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DichteD = Convert.ToDouble(7.85);
            
            tb_Dichte.Text = "7,85";
            Materialint = 1;
        }

        private void Tvi_C45_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DichteD = Convert.ToDouble(7.85);
            
            tb_Dichte.Text = "7,85";
            Materialint = 1;
        }

        private void Tvi_AlMg4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DichteD = Convert.ToDouble(2.66);
            
            tb_Dichte.Text = "2,66";
            Materialint = 2;
        }
        #endregion

        #region img_Auswahl
        //
        // Grid Auswahl Image zuweisung
        //
        private void img_Rechteck_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            lbl_Hoehe.Content = HoeheS;
            lbl_Wandstaerke.Visibility = Visibility.Hidden;
            tb_Wandstaerke.Visibility = Visibility.Hidden;
            Image RechteckDetail = new Image();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("RechteckDetail.jpg", UriKind.Relative);
            bi1.EndInit();
            RechteckDetail.Stretch = Stretch.Fill;
            RechteckDetail.Source = bi1;
            img_DetailAnsicht.Source = bi1;
            Profilint = 1;
            lbl_Flanschbreite.Visibility = Visibility.Hidden;
            tb_Flanschbreite.Visibility = Visibility.Hidden;
            

        }

        private void img_Rechteck_Hohlprofil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            lbl_Hoehe.Content = HoeheS;
            lbl_Wandstaerke.Content = WandstaerkeS;
            Image RechteckHohlDetail = new Image();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("Rechteck-HohlprofilDetail.jpg", UriKind.Relative);
            bi1.EndInit();
            RechteckHohlDetail.Stretch = Stretch.Fill;
            RechteckHohlDetail.Source = bi1;
            img_DetailAnsicht.Source = bi1;
            Profilint = 2;
            lbl_Flanschbreite.Visibility = Visibility.Hidden;
            tb_Flanschbreite.Visibility = Visibility.Hidden;
          
        }

        private void img_Kreis_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            lbl_Wandstaerke.Visibility = Visibility.Hidden;
            tb_Wandstaerke.Visibility = Visibility.Hidden;
            lbl_Hoehe.Content = HoeheDurch;
            lbl_Breite.Visibility = Visibility.Hidden;
            tb_Breite.Visibility = Visibility.Hidden;
            Image KreisDetail = new Image();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("KreisDetail.jpg", UriKind.Relative);
            bi1.EndInit();
            KreisDetail.Stretch = Stretch.Fill;
            KreisDetail.Source = bi1;
            img_DetailAnsicht.Source = bi1;
            Profilint = 3;
            lbl_Flanschbreite.Visibility = Visibility.Hidden;
            tb_Flanschbreite.Visibility = Visibility.Hidden;
           
        }

        private void img_Kreis_Hohlprofil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lbl_Hoehe.Content = HoeheDurch;
            lbl_Breite.Visibility = Visibility.Hidden;
            tb_Breite.Visibility = Visibility.Hidden;
            lbl_Wandstaerke.Content = WandstaerkeS;
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            Image Kreis_HohlprofilDetail = new Image();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("Kreis-HohlprofilDetail.jpg", UriKind.Relative);
            bi1.EndInit();
            Kreis_HohlprofilDetail.Stretch = Stretch.Fill;
            Kreis_HohlprofilDetail.Source = bi1;
            img_DetailAnsicht.Source = bi1;
            Profilint = 4;
            lbl_Flanschbreite.Visibility = Visibility.Hidden;
            tb_Flanschbreite.Visibility = Visibility.Hidden;
           
        }

        private void img_I_Profil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lbl_Hoehe.Content = HoeheS;
            lbl_Wandstaerke.Content = WandIULS;
            lbl_Flanschbreite.Visibility = Visibility.Visible;
            tb_Flanschbreite.Visibility = Visibility.Visible;
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            Image IProfilDetail = new Image();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("I-ProfilDetail.jpg", UriKind.Relative);
            bi1.EndInit();
            IProfilDetail.Stretch = Stretch.Fill;
            IProfilDetail.Source = bi1;
            img_DetailAnsicht.Source = bi1;
            Profilint = 5;
           
        }

        private void img_T_Profil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lbl_Hoehe.Content = HoeheS;
            lbl_Wandstaerke.Content = WandTS;
            
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            Image TProfilDetail = new Image();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("T-ProfilDetail.jpg", UriKind.Relative);
            bi1.EndInit();
            TProfilDetail.Stretch = Stretch.Fill;
            TProfilDetail.Source = bi1;
            img_DetailAnsicht.Source = bi1;
            Profilint = 6;
            lbl_Flanschbreite.Visibility = Visibility.Hidden;
            tb_Flanschbreite.Visibility = Visibility.Hidden;
           
        }

        private void img_U_Profil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            lbl_Hoehe.Content = HoeheS;
            lbl_Flanschbreite.Visibility = Visibility.Visible;
            tb_Flanschbreite.Visibility = Visibility.Visible;
            lbl_Wandstaerke.Content = WandIULS;
            Image UProfilDetail = new Image();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("U-ProfilDetail.jpg", UriKind.Relative);
            bi1.EndInit();
            UProfilDetail.Stretch = Stretch.Fill;
            UProfilDetail.Source = bi1;
            img_DetailAnsicht.Source = bi1;
            Profilint = 7;
           
        }

        private void img_L_Profil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lbl_Hoehe.Content = HoeheS;
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            Image LProfilDetail = new Image();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("L-ProfilDetail.jpg", UriKind.Relative);
            bi1.EndInit();
            LProfilDetail.Stretch = Stretch.Fill;
            LProfilDetail.Source = bi1;
            img_DetailAnsicht.Source = bi1;
            Profilint = 8;
            lbl_Flanschbreite.Visibility = Visibility.Hidden;
            tb_Flanschbreite.Visibility = Visibility.Hidden;
            lbl_Wandstaerke.Content = WandIULS;
           
        }
        #endregion

        #region Buttons
        private void btn_Wiederholen_Click(object sender, RoutedEventArgs e)
        {
            grid_Profilauswahl.Visibility = Visibility.Hidden;
            grid_Profilauswahlimg.Visibility = Visibility.Visible;
            Grid_Endcart.Visibility = Visibility.Hidden;
            ThisIsYoustATreeView.Visibility = Visibility.Visible;
            
            lbl_Hoehe.Visibility = Visibility.Visible;
            tb_hoehe.Visibility = Visibility.Visible;
            lbl_Breite.Visibility = Visibility.Visible;
            tb_Breite.Visibility = Visibility.Visible;
            lbl_Laenge.Visibility = Visibility.Visible;
            tb_Laenge.Visibility = Visibility.Visible;
            lbl_Wandstaerke.Visibility = Visibility.Visible;
            tb_Wandstaerke.Visibility = Visibility.Visible;
            tb_hoehe.Text = "";
            tb_Breite.Text = "";
            tb_Dichte.Text = "";
            tb_Wandstaerke.Text = "";
            tb_Laenge.Text = "";
            tb_Flanschbreite.Text = "";
            tb_Partname.Text = "";
            lbl_Drehwinkel.Visibility = Visibility.Hidden;
            lbl_Flanschbreite.Visibility = Visibility.Hidden;
            lbl_FTM.Visibility = Visibility.Hidden;
            lbl_FTMX.Visibility = Visibility.Hidden;
            lbl_FTMY.Visibility = Visibility.Hidden;
            lbl_Grad.Visibility = Visibility.Hidden;
            lbl_HTM.Visibility = Visibility.Hidden;
            lbl_HTMU.Visibility = Visibility.Hidden;
            lbl_HTMV.Visibility = Visibility.Hidden;
            lbl_Masse.Visibility = Visibility.Hidden;
            lbl_Querschnitt.Visibility = Visibility.Hidden;
            lbl_Rad.Visibility = Visibility.Hidden;
            lbl_SWP.Visibility = Visibility.Hidden;
            lbl_SWPX.Visibility = Visibility.Hidden;
            lbl_SWPY.Visibility = Visibility.Hidden;
            lbl_TanA.Visibility = Visibility.Hidden;
            lbl_Voulumen.Visibility = Visibility.Hidden;
            lbl_DeviationsMoment.Visibility = Visibility.Hidden;
            lbl_Wbs.Visibility = Visibility.Hidden;
            lbl_Wbx.Visibility = Visibility.Hidden;
            lbl_Wby.Visibility = Visibility.Hidden;
            lbl_Ip.Visibility = Visibility.Hidden;
            lbl_Wp.Visibility = Visibility.Hidden;
            btn_Save.Visibility = Visibility.Hidden;

            img_Screenshot.Source = null;
            HoeheD = 0;
            BreiteD = 0;
            DichteD = 0;
            WandstaerkeD = 0;
            LaengeD = 0;
            FlanschbreiteD = 0;
            

        }

        private void btn_Beenden_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_Weiter_Click(object sender, RoutedEventArgs e)
        {
            grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Endcart.Visibility = Visibility.Visible;
        }

        private void Btn_CatiaStart_Click(object sender, RoutedEventArgs e)
        {
            
            String Path;
            
            Assembly assembly = typeof(Window1).Assembly;
            string Path2 = assembly.Location;
                

            int index = Path2.LastIndexOf("\\");
            Path2 = Path2.Substring(0, index);
            Path2 += "screen"+ x + ".jpg";
            Path = Path2.Replace("\\bin\\Debug", "\\");
            
            new CatiaControl(BreiteD, HoeheD, LaengeD, WandstaerkeD, FlanschbreiteD, DurchmesserD, Profilint, Path, Partname, Materialint);
            x +=1;
            CatiaConnection c = new CatiaConnection();
            if (c.CATIALaeuft())
            {
            
                bitmap_Screenshot = new BitmapImage((new Uri(Path, UriKind.Absolute)));
                img_Screenshot.Source = bitmap_Screenshot;
                img_Screenshot.Visibility = Visibility.Visible;

                btn_Save.Visibility = Visibility.Visible;

            }
            else
            {
                    
            }

             
           
                
        }

      
        private void Button_zurueckProfilauswahl_Click(object sender, RoutedEventArgs e)
        {
            grid_Profilauswahl.Visibility = Visibility.Hidden;
            grid_Profilauswahlimg.Visibility = Visibility.Visible;
            img_Screenshot.Visibility = Visibility.Hidden;


            lbl_Hoehe.Visibility = Visibility.Visible;
            tb_hoehe.Visibility = Visibility.Visible;
            lbl_Breite.Visibility = Visibility.Visible;
            tb_Breite.Visibility = Visibility.Visible;
            lbl_Laenge.Visibility = Visibility.Visible;
            tb_Laenge.Visibility = Visibility.Visible;
            lbl_Wandstaerke.Visibility = Visibility.Visible;
            tb_Wandstaerke.Visibility = Visibility.Visible;
            tb_hoehe.Text = "";
            tb_Breite.Text = "";
            tb_Dichte.Text = "";
            tb_Wandstaerke.Text = "";
            tb_Laenge.Text = "";
            tb_Flanschbreite.Text = "";
            tb_Partname.Text = "";
            lbl_Drehwinkel.Visibility = Visibility.Hidden;
            lbl_Flanschbreite.Visibility = Visibility.Hidden;
            lbl_FTM.Visibility = Visibility.Hidden;
            lbl_FTMX.Visibility = Visibility.Hidden;
            lbl_FTMY.Visibility = Visibility.Hidden;
            lbl_Grad.Visibility = Visibility.Hidden;
            lbl_HTM.Visibility = Visibility.Hidden;
            lbl_HTMU.Visibility = Visibility.Hidden;
            lbl_HTMV.Visibility = Visibility.Hidden;
            lbl_Masse.Visibility = Visibility.Hidden;
            lbl_Querschnitt.Visibility = Visibility.Hidden;
            lbl_Rad.Visibility = Visibility.Hidden;
            lbl_SWP.Visibility = Visibility.Hidden;
            lbl_SWPX.Visibility = Visibility.Hidden;
            lbl_SWPY.Visibility = Visibility.Hidden;
            lbl_TanA.Visibility = Visibility.Hidden;
            lbl_Voulumen.Visibility = Visibility.Hidden;
            lbl_DeviationsMoment.Visibility = Visibility.Hidden;
            lbl_Wbs.Visibility = Visibility.Hidden;
            lbl_Wbx.Visibility = Visibility.Hidden;
            lbl_Wby.Visibility = Visibility.Hidden;
            lbl_Ip.Visibility = Visibility.Hidden;
            lbl_Wp.Visibility = Visibility.Hidden;
            btn_Save.Visibility = Visibility.Hidden;

            HoeheD = 0;
            BreiteD = 0;
            DichteD = 0;
            WandstaerkeD = 0;
            LaengeD = 0;
            FlanschbreiteD = 0;
            

            

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (Partname.Equals(""))
            {
                MessageBox.Show("Keinen Namen eingegeben");
            }
            else
            {
                new CatiaSave(Partname);

            }
            
        }

        #endregion


    }
}
