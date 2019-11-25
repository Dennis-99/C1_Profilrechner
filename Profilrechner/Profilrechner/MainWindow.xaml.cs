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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestGui
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        int Profilint;
        String Hoehe;
        String Breite;
        String Laenge;
        String Dichte;
        String Wandstaerke;
        String Durchmesser;
        String Stegbreite;
        String Flanschbreite;
        int Fehlercode;
        Double HoeheD;
        Double BreiteD;
        Double LaengeD;
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
        String GewichtS;
        String SchwerpunktxS;
        String SchwerpunktyS;
        String FTMS;
        String FTMSX;
        String FTMSY;

        String FTMSXY;
        String FTMSU;
        String FTMSV;
        String DrehungAchsenRad;
        String DrehungAchsenGrad;
        String TanAS;
        String DrehungUX;
        String DrehungVY;
        String Drehsinn;






        public UserControl1()
        {
            InitializeComponent();
            //Hier Breite und weite
            
            
        }

        private void btn_SpracheD_Click(object sender, RoutedEventArgs e)
        {
            grid_Language1.Visibility = Visibility.Hidden;
            grid_Profilauswahlimg.Visibility = Visibility.Visible;
            tb_Dichte.Visibility = Visibility.Hidden;
            lbl_Dichte.Visibility = Visibility.Hidden;
        }

       

        private void btn_SpracheE_Click(object sender, RoutedEventArgs e)
        {
            String test = Convert.ToString(e);
        }

        private void btn_SpracheF_Click(object sender, RoutedEventArgs e)
        {
            String test = Convert.ToString(e);
        }

        private void btn_exit2_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
       

        private void btn_Berechnen_Click(object sender, RoutedEventArgs e)
        {
            
            BreiteD = Convert.ToDouble(Breite);
            LaengeD = Convert.ToDouble(Laenge);
            DichteD = Convert.ToDouble(Dichte);
            Double HoeheH = HoeheD / 2;
            Double BreiteH = BreiteD / 2;
            
            if (WandstaerkeD > HoeheD) 
            {
                if (tb_hoehe.Visibility.Equals(Visibility.Visible))
                {
                    Window MBHG = new Window();
                    MBHG.Content = MessageBox.Show("Wandstärke darf nicht größer als Höhe sein!", "Fehler!", MessageBoxButton.OK);
                    MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
                
            }
             else if (WandstaerkeD > BreiteD)
            {
                if (tb_Breite.Visibility.Equals(Visibility.Visible))
                {
                    Window MBHG = new Window();
                    MBHG.Content = MessageBox.Show("Wandstärke darf nicht größer als Breite sein!", "Fehler!", MessageBoxButton.OK);
                    MBHG.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
                
            }

            else if (tb_Wandstaerke.Text.Equals(tb_hoehe.Text))
            {
                if (WandstaerkeD > 0)
                {
                    Window MB1 = new Window();
                    MB1.Content = MessageBox.Show("Wandstärke muss kleiner als Höhe sein.", "Fehler!", MessageBoxButton.OK);
                    MB1.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
                
              
            }
            else  if (tb_Wandstaerke.Text.Equals(tb_Breite.Text))
            {

                if (WandstaerkeD > 0)
                {

                    Window MB1 = new Window();
                    MB1.Content = MessageBox.Show("Wandstärke muss kleiner als breite sein.", "Fehler!", MessageBoxButton.OK);
                    MB1.SizeToContent = SizeToContent.WidthAndHeight;
                    Fehlercode = 1;
                }
               
                

            }
            else if (WandstaerkeD >= HoeheH)
            {
                Window MB1 = new Window();
                MB1.Content = MessageBox.Show("Wandstärke muss kleiner als die halbe Höhe sein.", "Fehler!", MessageBoxButton.OK);
                MB1.SizeToContent = SizeToContent.WidthAndHeight;
                Fehlercode = 1;
            }
            else if (WandstaerkeD >= BreiteH)
            {
                Window MB1 = new Window();
                MB1.Content = MessageBox.Show("Wandstärke muss kleiner als die halbe breite sein.", "Fehler!", MessageBoxButton.OK);
                MB1.SizeToContent = SizeToContent.WidthAndHeight;
                Fehlercode = 1;
            }

            if (Fehlercode.Equals(1))
            {
                ThisIsYoustATreeView.Visibility = Visibility.Visible;
                lbl_Dichte.Visibility = Visibility.Hidden;
                tb_Dichte.Visibility = Visibility.Hidden;
                tb_hoehe.Text = "0";
                tb_Breite.Text = "0";
                tb_Dichte.Text = "0";
                tb_Wandstaerke.Text = "0";
                Fehlercode = 0;
            }
            else
            {
                if (Profilint.Equals(1))
                {
                    Querschnitt = HoeheD * BreiteD;
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = Volumen * DichteD;
                    Festigkeitx = (BreiteD * Math.Pow(HoeheD, 3)) / 12;
                    Festigkeity = (HoeheD * Math.Pow(BreiteD, 3)) / 12;

                    lbl_Querschnitt.Content = "Querschnitt: " + Math.Round(Querschnitt, 3) + "mm";
                    lbl_Voulumen.Content = "Volumen: " + Math.Round(Volumen, 3);
                    lbl_Masse.Content = "Masse: " + Math.Round(Gewicht, 3);
                    lbl_FTMX.Content = Math.Round(Festigkeitx, 3);
                    lbl_FTMY.Content = Math.Round(Festigkeity, 3);
                    lbl_FTM.Content = "FTM";

                }
                else if (Profilint.Equals(2))
                {
                    Querschnitt = (HoeheD * BreiteD) - ((HoeheD - (2 * WandstaerkeD)) * (BreiteD - (2 * WandstaerkeD)));
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = Volumen * DichteD;
                    Festigkeitx = ((BreiteD * Math.Pow(HoeheD, 3)) - ((BreiteD - (2 * WandstaerkeD)) * Math.Pow((HoeheD - (2 * WandstaerkeD)), 3))) / 12;
                    Festigkeity = ((HoeheD * Math.Pow(BreiteD, 3)) - ((HoeheD - (2 * WandstaerkeD)) * Math.Pow((BreiteD - (2 * WandstaerkeD)), 3))) / 12;

                    lbl_Querschnitt.Content = "Querschnitt: " + Math.Round(Querschnitt, 3) + "mm";
                    lbl_Voulumen.Content = "Volumen: " + Math.Round(Volumen, 3);
                    lbl_Masse.Content = "Masse: " + Math.Round(Gewicht, 3);
                    lbl_FTMX.Content = Math.Round(Festigkeitx, 3);
                    lbl_FTMY.Content = Math.Round(Festigkeity, 3);
                    lbl_FTM.Content = "FTM";
                }
                else if (Profilint.Equals(3))
                {
                    DurchmesserD = HoeheD;
                    Querschnitt = Math.Pow(DurchmesserD, 2) * Math.PI / 4;
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = Volumen * DichteD;
                    Festigkeitx = (Math.PI * (Math.Pow(DurchmesserD, 4))) / 64;
                    Festigkeity = (Math.PI * (Math.Pow(DurchmesserD, 4))) / 64;

                    lbl_Querschnitt.Content = "Querschnitt: " + Math.Round(Querschnitt, 3) + "mm";
                    lbl_Voulumen.Content = "Volumen: " + Math.Round(Volumen, 3);
                    lbl_Masse.Content = "Masse: " + Math.Round(Gewicht, 3);
                    lbl_FTMX.Content = Math.Round(Festigkeitx, 3);
                    lbl_FTMY.Content = Math.Round(Festigkeity, 3);
                    lbl_FTM.Content = "FTM";


                }
                else if (Profilint.Equals(4))
                {
                    DurchmesserD = HoeheD;
                    Querschnitt = ((Math.Pow(DurchmesserD, 2) * Math.PI) - (Math.Pow((DurchmesserD - (2 * WandstaerkeD)), 2) * Math.PI)) / 4;
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = Volumen * DichteD;
                    Festigkeitx = (Math.PI * (Math.Pow(DurchmesserD, 4) - Math.Pow((DurchmesserD - (2 * WandstaerkeD)), 4))) / 64;
                    Festigkeity = (Math.PI * (Math.Pow(DurchmesserD, 4) - Math.Pow((DurchmesserD - (2 * WandstaerkeD)), 4))) / 64;

                    lbl_Querschnitt.Content = "Querschnitt: " + Math.Round(Querschnitt, 3) + "mm";
                    lbl_Voulumen.Content = "Volumen: " + Math.Round(Volumen, 3);
                    lbl_Masse.Content = "Masse: " + Math.Round(Gewicht, 3);
                    lbl_FTMX.Content = Math.Round(Festigkeitx, 3);
                    lbl_FTMY.Content = Math.Round(Festigkeity, 3);
                    lbl_FTM.Content = "FTM";

                }


                else if (Profilint.Equals(5))
                {
                    StegbreiteD = WandstaerkeD;
                    Double Breiteb;
                    Double Hoeheh;
                    //Zwischenrechnung
                    Breiteb = BreiteD - StegbreiteD;
                    Hoeheh = HoeheD - 2 * FlanschbreiteD;

                    Querschnitt = (WandstaerkeD * BreiteD) + (WandstaerkeD * (HoeheD - WandstaerkeD));
                    Volumen = (WandstaerkeD * BreiteD * LaengeD) + ((HoeheD - WandstaerkeD) * WandstaerkeD * LaengeD);
                    Gewicht = Volumen * DichteD;
                    SchwerpunktyD = HoeheD / 2;
                    SchwerpunktxD = BreiteD / 2;
                    Festigkeitx = (BreiteD * Math.Pow(HoeheD, 3) / 12) - (Breiteb * Math.Pow(Hoeheh, 3) / 12);
                    Festigkeity = 2 * ((FlanschbreiteD * Math.Pow(BreiteD, 3) / 12)) + ((Hoeheh * Math.Pow(StegbreiteD, 3)) / 12);

                    lbl_Querschnitt.Content = "Querschnitt: " + Math.Round(Querschnitt, 3) + "mm";
                    lbl_Voulumen.Content = "Volumen: " + Math.Round(Volumen, 3);
                    lbl_Masse.Content = "Masse: " + Math.Round(Gewicht, 3);
                    lbl_FTMX.Content = Math.Round(Festigkeitx, 3);
                    lbl_FTMY.Content = Math.Round(Festigkeity, 3);
                    lbl_FTM.Content = "FTM";
                    lbl_SWPX.Content = Math.Round(SchwerpunktxD, 3);
                    lbl_SWPY.Content = Math.Round(SchwerpunktyD, 3);
                    lbl_SWP.Content = "Schwerpunkt";

                }
                else if (Profilint.Equals(6))
                {
                    StegbreiteD = WandstaerkeD;
                    Querschnitt = (WandstaerkeD * BreiteD) + (WandstaerkeD * (HoeheD - WandstaerkeD));
                    Volumen = (WandstaerkeD * BreiteD * LaengeD) + ((HoeheD - WandstaerkeD) * WandstaerkeD * LaengeD);
                    Gewicht = Volumen * DichteD;
                    SchwerpunktyD = ((WandstaerkeD * (HoeheD - WandstaerkeD)) * ((HoeheD - WandstaerkeD) / 2) + ((WandstaerkeD * BreiteD) * (BreiteD - (WandstaerkeD / 2))))
                                          / ((WandstaerkeD * (HoeheD - WandstaerkeD)) + (BreiteD * WandstaerkeD));
                    SchwerpunktxD = BreiteD / 2;
                    Festigkeitx = ((WandstaerkeD * Math.Pow((HoeheD - WandstaerkeD), 3)) / 12) + (WandstaerkeD * (HoeheD - WandstaerkeD)) * Math.Pow((SchwerpunktyD - ((HoeheD - WandstaerkeD) / 2)), 2)
                   //  +                     Ixx2                     +            A2            *                           l2²
                   + ((BreiteD * Math.Pow(WandstaerkeD, 3)) / 12) + (WandstaerkeD * BreiteD) * Math.Pow(((BreiteD - (WandstaerkeD / 2)) - SchwerpunktyD), 2);
                    //                               Iyy1                          +                     Iyy2
                    Festigkeity = (((HoeheD - WandstaerkeD) * Math.Pow(WandstaerkeD, 3)) / 12) + ((WandstaerkeD * Math.Pow(BreiteD, 3)) / 12);

                    lbl_Querschnitt.Content = "Querschnitt: " + Math.Round(Querschnitt, 3) + "mm";
                    lbl_Voulumen.Content = "Volumen: " + Math.Round(Volumen, 3);
                    lbl_Masse.Content = "Masse: " + Math.Round(Gewicht, 3);
                    lbl_FTMX.Content = Math.Round(Festigkeitx, 3);
                    lbl_FTMY.Content = Math.Round(Festigkeity, 3);
                    lbl_FTM.Content = "FTM";
                    lbl_SWPX.Content = Math.Round(SchwerpunktxD, 3);
                    lbl_SWPY.Content = Math.Round(SchwerpunktyD, 3);
                    lbl_SWP.Content = "Schwerpunkt";
                }
                else if (Profilint.Equals(7))
                {
                    Querschnitt = (BreiteD * HoeheD) - ((BreiteD - StegbreiteD) * (HoeheD - (2 * FlanschbreiteD)));
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = Volumen * DichteD;
                    SchwerpunktxD = ((BreiteD * HoeheD * (BreiteD / 2)) - ((BreiteD - StegbreiteD) * (HoeheD - (2 * FlanschbreiteD)) * ((BreiteD - StegbreiteD) / 2 + StegbreiteD)))
                                     / ((BreiteD * HoeheD) - ((BreiteD - StegbreiteD) * (HoeheD - (2 * FlanschbreiteD))));
                    SchwerpunktyD = HoeheD / 2;
                    Festigkeitx = ((BreiteD * Math.Pow(HoeheD, 3)) / 12) - (((BreiteD - StegbreiteD) * Math.Pow((HoeheD - (2 * FlanschbreiteD)), 3)) / 12);
                    Festigkeity = ((HoeheD * Math.Pow(BreiteD, 3)) / 12 + ((BreiteD * HoeheD) * Math.Pow(((BreiteD / 2) - SchwerpunktxD), 2)))
                                   - (((HoeheD - (2 * FlanschbreiteD)) * Math.Pow((BreiteD - StegbreiteD), 3)) / 12
                                   + ((BreiteD - StegbreiteD) * (HoeheD - (2 * FlanschbreiteD))) * Math.Pow((((BreiteD - StegbreiteD) / 2 + StegbreiteD) - SchwerpunktxD), 2));
                    lbl_Querschnitt.Content = "Querschnitt: " + Math.Round(Querschnitt, 3) + "mm";
                    lbl_Voulumen.Content = "Volumen: " + Math.Round(Volumen, 3);
                    lbl_Masse.Content = "Masse: " + Math.Round(Gewicht, 3);
                    lbl_FTMX.Content = Math.Round(Festigkeitx, 3);
                    lbl_FTMY.Content = Math.Round(Festigkeity, 3);
                    lbl_FTM.Content = "FTM";
                    lbl_SWPX.Content = Math.Round(SchwerpunktxD, 3);
                    lbl_SWPY.Content = Math.Round(SchwerpunktyD, 3);
                    lbl_SWP.Content = "Schwerpunkt";
                }
                else if (Profilint.Equals(8))
                {

                    Querschnitt = BreiteD * WandstaerkeD + (HoeheD - WandstaerkeD) * WandstaerkeD;
                    Volumen = Querschnitt * LaengeD;
                    Gewicht = Volumen * DichteD;
                    SchwerpunktxD = (BreiteD * HoeheD * (BreiteD / 2) - (BreiteD - WandstaerkeD) * (HoeheD - WandstaerkeD) * ((BreiteD - WandstaerkeD) / 2 + WandstaerkeD)) / ((BreiteD * HoeheD) - ((BreiteD - WandstaerkeD) * (HoeheD - WandstaerkeD)));
                    SchwerpunktyD = (HoeheD * BreiteD * (HoeheD / 2) - (HoeheD - WandstaerkeD) * (BreiteD - WandstaerkeD) * ((HoeheD - WandstaerkeD) / 2 + WandstaerkeD)) / ((HoeheD * BreiteD) - ((HoeheD - WandstaerkeD) * (BreiteD - WandstaerkeD)));
                    Festigkeitx = ((WandstaerkeD * Math.Pow(HoeheD, 3) / 12) + (WandstaerkeD * HoeheD) * Math.Pow((HoeheD / 2 - SchwerpunktyD), 2)) + (((BreiteD - WandstaerkeD) * Math.Pow(WandstaerkeD, 3) / 12) + (((BreiteD - WandstaerkeD) * WandstaerkeD) * Math.Pow((SchwerpunktyD - (WandstaerkeD / 2)), 2)));                                       //Klappt
                    Festigkeity = ((HoeheD * Math.Pow(WandstaerkeD, 3) / 12) + (WandstaerkeD * HoeheD) * Math.Pow((SchwerpunktxD - (WandstaerkeD / 2)), 2)) + ((WandstaerkeD * Math.Pow((BreiteD - WandstaerkeD), 3) / 12) + (((BreiteD - WandstaerkeD) * WandstaerkeD) * Math.Pow(((BreiteD - WandstaerkeD) / 2 + WandstaerkeD) - SchwerpunktxD, 2)));      //Klappt

                    Festigkeitxy = -Math.Pow((BreiteD * HoeheD), 2) / 4 - (-(Math.Pow((BreiteD * HoeheD), 2) - Math.Pow((HoeheD * WandstaerkeD), 2) - Math.Pow((BreiteD * WandstaerkeD), 2) + Math.Pow(WandstaerkeD, 4)) / 4) + (((BreiteD * HoeheD) - (BreiteD - WandstaerkeD) * (HoeheD - WandstaerkeD)) * SchwerpunktxD * SchwerpunktyD);

                    //Achswinkel = (1 / 2) * Math.Atan((2 * Festigkeitxy) / (Festigkeitxx - Festigkeityy));
                    AchswinkelRad = (Math.Atan((2 * Festigkeitxy) / (Festigkeitx - Festigkeity))) / 2;
                    AchswinkelGrad = AchswinkelRad * 180 / Math.PI;
                    TanA = Math.Tan(AchswinkelGrad);

                    Festigkeitu = (Festigkeitx + Festigkeity) / 2 + (((Festigkeitx - Festigkeity) / 2) * Math.Cos(2 * AchswinkelRad)) + Festigkeitxy * Math.Sin(2 * AchswinkelRad);
                    Festigkeitv = (Festigkeitx + Festigkeity) / 2 - (((Festigkeitx - Festigkeity) / 2) * Math.Cos(2 * AchswinkelRad)) - Festigkeitxy * Math.Sin(2 * AchswinkelRad);

                    lbl_Querschnitt.Content = "Querschnitt: " + Math.Round(Querschnitt, 3) + "mm";
                    lbl_Voulumen.Content = "Volumen: " + Math.Round(Volumen, 3);
                    lbl_Masse.Content = "Masse: " + Math.Round(Gewicht, 3);
                    lbl_FTMX.Content = Math.Round(Festigkeitx, 3);
                    lbl_FTMY.Content = Math.Round(Festigkeity, 3);
                    lbl_FTM.Content = "FTM";
                    lbl_SWPX.Content = Math.Round(SchwerpunktxD, 3);
                    lbl_SWPY.Content = Math.Round(SchwerpunktyD, 3);
                    lbl_SWP.Content = "Schwerpunkt";
                    lbl_DeviationsMoment.Content = "Deviationmoment" + Math.Round(Festigkeitxy, 3);
                    lbl_Drehwinkel.Content = "Drehwinkel";
                    lbl_Grad.Content = Math.Round(AchswinkelGrad, 2);
                    lbl_Rad.Content = Math.Round(AchswinkelRad, 2);
                    lbl_TanA.Content = Math.Round(TanA, 3);
                    lbl_HTM.Content = "Hauptträgheitsmoment";
                    lbl_HTMU.Content = Math.Round(Festigkeitu, 3);
                    lbl_HTMV.Content = Math.Round(Festigkeitv, 3);
                }










            }
        }
           

        private void tb_hoehe_TextChanged(object sender, TextChangedEventArgs e)
        {
              HoeheD = Convert.ToDouble(tb_hoehe.Text);

        }

        private void tb_Breite_TextChanged(object sender, TextChangedEventArgs e)
        {
            Breite = Convert.ToString(tb_Breite.Text);
        }

        private void tb_Laenge_TextChanged(object sender, TextChangedEventArgs e)
        {
            Laenge = Convert.ToString(tb_Laenge.Text);
        }


       

       

       //
       // Treeview zuweisung
       //

        private void Tvi_ManuelleEingabe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tb_Dichte.Visibility = Visibility.Visible;
            lbl_Dichte.Visibility = Visibility.Visible;
            ThisIsYoustATreeView.Visibility = Visibility.Hidden;
        }

        private void Tvi_S235_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Dichte =Convert.ToString(7.85);
            lbl_DichteTest.Content = Dichte;
        }

        private void Tvi_355_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Dichte = Convert.ToString(7.85);
            lbl_DichteTest.Content = Dichte;
        }

        private void Tvi_42CrMo4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Dichte = Convert.ToString(7.85);
            lbl_DichteTest.Content = Dichte;
        }

        private void Tvi_E295_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Dichte = Convert.ToString(7.85);
            lbl_DichteTest.Content = Dichte;
        }

        private void Tvi_E355_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Dichte = Convert.ToString(7.85);
            lbl_DichteTest.Content = Dichte;
        }

        private void Tvi_C45_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Dichte = Convert.ToString(7.85);
            lbl_DichteTest.Content = Dichte;
        }

        private void Tvi_AlMg4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Dichte = Convert.ToString(2.66);
            lbl_DichteTest.Content = Dichte;
        }
        //
        // Grid Auswahl Image zuweisung
        //
        private void img_Rechteck_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
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

        }

        private void img_Rechteck_Hohlprofil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            Image RechteckHohlDetail = new Image();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("Rechteck-HohlprofilDetail.jpg", UriKind.Relative);
            bi1.EndInit();
            RechteckHohlDetail.Stretch = Stretch.Fill;
            RechteckHohlDetail.Source = bi1;
            img_DetailAnsicht.Source = bi1;
            Profilint = 2;
        }

        private void img_Kreis_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
            lbl_Wandstaerke.Visibility = Visibility.Hidden;
            tb_Wandstaerke.Visibility = Visibility.Hidden;
            lbl_Hoehe.Content = " D: Durchmesser";
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
        }

        private void img_Kreis_Hohlprofil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lbl_Hoehe.Content = " D: Durchmesser";
            lbl_Breite.Visibility = Visibility.Hidden;
            tb_Breite.Visibility = Visibility.Hidden;
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
        }

        private void img_I_Profil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lbl_Hoehe.Content = " h: Höhe";
            lbl_Breite.Content = "b: Breite";
            lbl_Wandstaerke.Content = "s: Stegbreite";
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
            lbl_Hoehe.Content = " h: Höhe";
            lbl_Breite.Content = "b: Breite";
            lbl_Wandstaerke.Content = "s: Stegbreite";
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
        }

        private void img_U_Profil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grid_Profilauswahlimg.Visibility = Visibility.Hidden;
            grid_Profilauswahl.Visibility = Visibility.Visible;
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
            lbl_Hoehe.Content = " h: Höhe";
            lbl_Breite.Content = "b: Breite";
            lbl_Wandstaerke.Content = "s: Stegbreite";
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
        }

        private void tb_Wandstaerke_TextChanged(object sender, TextChangedEventArgs e)
        {
            WandstaerkeD = Convert.ToDouble(tb_Wandstaerke.Text);
        }

       

        private void btn_Wiederholen_Click(object sender, RoutedEventArgs e)
        {
            grid_Profilauswahl.Visibility = Visibility.Hidden;
            grid_Profilauswahlimg.Visibility = Visibility.Visible;
            Grid_Endcart.Visibility = Visibility.Hidden;
            ThisIsYoustATreeView.Visibility = Visibility.Visible;
            lbl_Dichte.Visibility = Visibility.Hidden;
            tb_Dichte.Visibility = Visibility.Hidden;
            tb_hoehe.Text = "0";
            tb_Breite.Text = "0";
            tb_Dichte.Text = "0";
            tb_Wandstaerke.Text = "0";
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

        
    }
}
