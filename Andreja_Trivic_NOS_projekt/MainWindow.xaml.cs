using Andreja_Trivic_NOS_projekt.UserControls;
using System.IO;
using System.Runtime;
using System.Windows;
using System.Windows.Media;

namespace Andreja_Trivic_NOS_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var baseDirectory = Directory.GetCurrentDirectory();
            var projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
            var folderPath = Path.Combine(projectDirectory, "TextFiles");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var sazetakFilePath = Path.Combine(folderPath, "sazetak.txt");
            var tajniKljucFilePath = Path.Combine(folderPath, "tajni_kljuc.txt");
            var AESKriptiraniFilePath = Path.Combine(folderPath, "simetricni_kriptirani_tekst.txt");
            var AESDekriptiraniFilePath = Path.Combine(folderPath, "simetricni_dekriptirani_tekst.txt");

            var privatniKljucFilePath = Path.Combine(folderPath, "privatni_kljuc.txt");
            var javniKljucFilePath = Path.Combine(folderPath, "javni_kljuc.txt");
            var RSAKriptiraniFilePath = Path.Combine(folderPath, "asimetricni_kriptirani_tekst.txt");
            var RSADekriptiraniFilePath = Path.Combine(folderPath, "asimetricni_dekriptirani_tekst.txt");

            var digitalniPotpisFilePath = Path.Combine(folderPath, "digitalni_potpis.txt");
            var orginalnaDatotekaFilePath = Path.Combine(folderPath, "orginalna_datoteka.txt");

            CheckIfFileExists(sazetakFilePath);
            CheckIfFileExists(tajniKljucFilePath);
            CheckIfFileExists(AESKriptiraniFilePath);
            CheckIfFileExists(AESDekriptiraniFilePath);

            CheckIfFileExists(privatniKljucFilePath);
            CheckIfFileExists(javniKljucFilePath);
            CheckIfFileExists(RSAKriptiraniFilePath);
            CheckIfFileExists(RSADekriptiraniFilePath);

            CheckIfFileExists(digitalniPotpisFilePath);
            CheckIfFileExists(orginalnaDatotekaFilePath);
        }

        private void CheckIfFileExists(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private void btnAES_Click(object sender, RoutedEventArgs e)
        {
            btnAES.Background = Brushes.IndianRed;
            btnRSA.Background = Brushes.Gray;
            btnDS.Background = Brushes.Gray;
            ShowAESUserControl();
        }

        private void btnRSA_Click(object sender, RoutedEventArgs e)
        {
            btnRSA.Background = Brushes.IndianRed;
            btnAES.Background = Brushes.Gray;
            btnDS.Background = Brushes.Gray;
            ShowRSAUserControl();
        }

        private void btnDS_Click(object sender, RoutedEventArgs e)
        {
            btnDS.Background = Brushes.IndianRed;
            btnAES.Background = Brushes.Gray;
            btnRSA.Background = Brushes.Gray;
            ShowDSUserControl();
        }

        private void ShowAESUserControl()
        {
            AESUserControl control = new AESUserControl();
            UserControlStackPanel.Children.Clear();
            UserControlStackPanel.Children.Add(control);
        }

        private void ShowRSAUserControl()
        {
            RSAUserControl control = new RSAUserControl();
            UserControlStackPanel.Children.Clear();
            UserControlStackPanel.Children.Add(control);
        }

        private void ShowDSUserControl()
        {
            DSUserControl control = new DSUserControl();
            UserControlStackPanel.Children.Clear();
            UserControlStackPanel.Children.Add(control);
        }
    }
}
