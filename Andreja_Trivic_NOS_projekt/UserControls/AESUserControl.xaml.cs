using Andreja_Trivic_NOS_projekt.Services;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace Andreja_Trivic_NOS_projekt.UserControls
{
    public partial class AESUserControl : UserControl
    {
        KeyService _keyService = new KeyService();
        FileService _fileService = new FileService();
        AESService _aESService = new AESService();
        HashService _hashService = new HashService();

        public static string obicniTekstTextFile = "obicni_tekst.txt";
        public static string AESKriptiraniFile = "simetricni_kriptirani_tekst.txt";
        public static string sazetakFilePath = "sazetak.txt";
        public static string orginalnaDatotekaFile = "orginalna_datoteka.txt";

        public static string errorDecrypted = "Tekst je dekriptiran.";
        public static string errorKeyChanged = "Ključ koji se koristio za enkripciju se promjenio.";

        public static string fileNameConst = "File name";        

        public AESUserControl()
        {
            InitializeComponent();
            btnGenerateHash.IsEnabled = false;
        }

        private void btnGenerateSecretKey_Click(object sender, RoutedEventArgs e)
        {
            _keyService.GenerateKeyAndIV();
        }

        private void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            var fileName = _fileService.UploadFile();

            var fileText = _fileService.ReadTextFromFile(fileName);

            btnGenerateHash.IsEnabled = true;

            txtFileText.Text = fileText;
            txtFileName.Text = Path.GetFileName(fileName);
        }

        private void btnEncryptAES_Click(object sender, RoutedEventArgs e)
        {
            var textToEncrypt = txtFileText.Text;
            var encryptedText = _aESService.Encrypt(textToEncrypt);

            txtErrorMessage.Text = "";
            txtFileText.Text = encryptedText;   
        }

        private void btnDecryptAES_Click(object sender, RoutedEventArgs e)
        {
            var textToDecrypt = _fileService.ReadTextFromFile(AESKriptiraniFile);
            var decryptedText = "";

            try
            {
                decryptedText = _aESService.Decrypt(textToDecrypt);
                txtFileText.Text = decryptedText;
                txtErrorMessage.Text = "";
            }
            catch (FormatException ex)
            {
                txtErrorMessage.Text = errorDecrypted;
            }
            catch (CryptographicException ex)
            {
                txtErrorMessage.Text = errorKeyChanged;
            }
        }

        private void btnGenerateHash_Click(object sender, RoutedEventArgs e)
        {
            txtHash.Clear();

            var textToHash = txtFileText.Text;
            var hash = _hashService.GenerateHash(textToHash);

            txtHash.Text = hash;
        }

        private void txtFileText_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var fileName = txtFileName.Text;
            var text = txtFileText.Text;

            btnGenerateHash.IsEnabled = true;
            if (fileName == fileNameConst)
            {
                txtFileName.Text = orginalnaDatotekaFile;
                _fileService.WriteTextIntoFile(orginalnaDatotekaFile, text);
            }
            else
            {
                _fileService.WriteTextIntoFile(fileName, text);
            }
        }
    }
} 
