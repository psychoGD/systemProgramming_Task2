using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SystemProgramming_Task2
{
    public class MainViewModel:BaseViewModel
    {
        public RelayCommand<EventArgs> EnterKeyCommand { get; set; }

        public RelayCommand PlayCommand { get; set; }
        public RelayCommand PauseCommand { get; set; }
        public RelayCommand ResumeCommand { get; set; }
        public RelayCommand StopCommand { get; set; }


        private string word;

        public string Word
        {
            get { return word; }
            set { word = value;OnPropertyChanged(); }
        }


        private ObservableCollection<string> datas;

        public ObservableCollection<string> Datas
        {
            get { return datas; }
            set { datas = value;OnPropertyChanged(); }
        }


        private ObservableCollection<string> encryptedDatas;

        public ObservableCollection<string> EncryptedDatas
        {
            get { return encryptedDatas; }
            set { encryptedDatas = value;OnPropertyChanged(); }
        }

        private List<string> datasTest;

        public List<string> DatasTest
        {
            get { return datasTest; }
            set { datasTest = value;OnPropertyChanged(); }
        }

        

        public void EnterKeyCommandFunc(EventArgs e)
        {
            var pressedKey = (KeyEventArgs)e;

            if (pressedKey.Key==Key.Enter)
            {
                Thread enterKeyThread = new Thread(() =>
                {
                    Datas.Add(word);
                });
                enterKeyThread.Start();
            }
            
        }

        public MainViewModel()
        {
            EncryptedDatas= new ObservableCollection<string>();
            Datas= new ObservableCollection<string>();
                       
            EnterKeyCommand = new RelayCommand<EventArgs>(EnterKeyCommandFunc);

        }
    }
}
