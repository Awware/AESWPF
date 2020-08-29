using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AESWPF.Model
{
    public class MainVM : BaseViewModel
    {
        public MainVM()
        {
            AesImpl = new AES();
            WindowTitle = "AES ENCRYPTER | MVVM | v1.0";
        }
        private AES AesImpl;
        private string windowTitle;
        public string WindowTitle
        {
            get => windowTitle;
            set
            {
                windowTitle = value;
                OnPropertyChanged("WindowTitle");
            }
        }
        private string toEncryptText;
        public string ToEncryptText
        {
            get => toEncryptText;
            set
            {
                toEncryptText = value;
                OnPropertyChanged("ToEncryptText");
            }
        }
        private string toDecryptText;
        public string ToDecryptText
        {
            get => toDecryptText;
            set
            {
                toDecryptText = value;
                OnPropertyChanged("ToDecryptText");
            }
        }
        private string keyText;
        public string KeyText
        {
            get => keyText;
            set
            {
                keyText = value;
                OnPropertyChanged("KeyText");
            }
        }
        private RelayCommand exit;
        public RelayCommand Exit
        {
            get
            {
                return exit ?? (exit = new RelayCommand(obj => { Application.Current.Shutdown(); }));
            }
        }
        private RelayCommand encryptDecrypt;
        public RelayCommand EncryptDecrypt
        {
            get
            {
                return encryptDecrypt ?? (encryptDecrypt = new RelayCommand(obj =>
                {
                    if (string.IsNullOrEmpty(ToEncryptText))
                        ToDecryptText = AesImpl.AESDecryption(ToDecryptText, KeyText);
                    else
                        ToEncryptText = AesImpl.AESEncryption(ToEncryptText, KeyText);
                }));
            }
        }
    }
}
