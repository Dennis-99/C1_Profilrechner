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

        Double HoeheD;
        Double BreiteD;
        Double LaengeD;
        Double DichteD;
        Double WandstaerkeD;
        Double Querschnitt;
        Double Volumen;
        Double Gewicht;
        Double Festigkeitx;
        Double Festigkeity;
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

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
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
            HoeheD = Convert.ToDouble(Hoehe);
            BreiteD = Convert.ToDouble(Breite);
            LaengeD = Convert.ToDouble(Laenge);
            DichteD = Convert.ToDouble(Dichte);
            WandstaerkeD = Convert.ToDouble(Wandstaerke);


            if (Profilint.Equals(1))
            {
                Querschnitt = HoeheD * BreiteD;
                Volumen = Querschnitt * LaengeD;
                Gewicht = Volumen * DichteD;
                Festigkeitx = (BreiteD * Math.Pow(HoeheD, 3)) / 12;
                Festigkeity = (HoeheD * Math.Pow(BreiteD, 3)) / 12;

                lbl_Querschnitt.Content = "Querschnitt: " + Math.Round(Querschnitt, 3) + "mm";
                lbl_Voulumen.Content = "Volumen: " + Math.Round(Volumen, 3);
                lbl_Masse.Content = "Masse: " + Math.Round(Gewicht,3);
                lbl_FTMX.Content = Math.Round(Festigkeitx, 3);
                lbl_FTMY.Content = Math.Round(Festigkeity, 3);
                lbl_FTM.Content = "FTM";
            }
            else if (Profilint.Equals(2))
            {

            }
            else if (Profilint.Equals(3))
            {

            }
            else if (Profilint.Equals(4))
            {

            }
            else if (Profilint.Equals(5))
            {

            }
            else if (Profilint.Equals(6))
            {

            }
            else if (Profilint.Equals(7))
            {

            }
            else if (Profilint.Equals(8))
            {

            }


        }

        private void tb_hoehe_TextChanged(object sender, TextChangedEventArgs e)
        {
            Hoehe = Convert.ToString(tb_hoehe.Text);

        }

        private void tb_Breite_TextChanged(object sender, TextChangedEventArgs e)
        {
            Breite = Convert.ToString(tb_Breite.Text);
        }

        private void tb_Laenge_TextChanged(object sender, TextChangedEventArgs e)
        {
            Laenge = Convert.ToString(tb_Laenge.Text);
        }


       

        private void tb_Wandstaerke_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wandstaerke = Convert.ToString(tb_Wandstaerke.Text);
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

      
    }
}
