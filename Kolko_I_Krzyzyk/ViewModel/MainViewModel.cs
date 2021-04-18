using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kolko_I_Krzyzyk.ViewModel
{
    using BaseClass;
    using System.Windows;

    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Model.MainModel mainModel=new Model.MainModel();

        private char[] symbol;
        public char[] Symbol
        {
            get { return symbol; }

            private set
            {
                symbol = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Symbol)));

            }
        }

        private string[] kolor;
        public string[] Kolor
        {
            get{ return kolor; }

            private set
            {
                kolor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Kolor)));
                
                char winner = mainModel.sprawdz_gre();
                if (winner == 'O' || winner == 'X')
                {
                    MessageBox.Show($"Wygrał gracz {winner}!", "Zwycięzca");
                    Application.Current.Shutdown();
                }
            }
        }

        private char kogo_ruch='O';

        public char Kogo_ruch
        {
            get { return kogo_ruch; }
            
            set
            {
                kogo_ruch = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Kogo_ruch)));
            }
        }

        private string kolor_text="Green";

        public string Kolor_Text
        {
            get { return kolor_text; }

            set
            {
                kolor_text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Kolor_Text)));
            }
        }

        private ICommand wpisz;
        public ICommand Wpisz
        {
            
            get
            {
                return wpisz ?? (wpisz = new RelayCommand(
                    p => { ruch(p); },
                    p =>  mainModel.sprawdz_pole(int.Parse(p.ToString()))
                    ));
            }
        }

        private void ruch(object p)
        {
            Symbol = mainModel.ruch_gracza(int.Parse(p.ToString()));
            Kolor = mainModel.zmien_Kolor(int.Parse(p.ToString()));
            Kogo_ruch = mainModel.zmien_ruch();
            Kolor_Text = mainModel.text_kolor();

        }

    }
}
