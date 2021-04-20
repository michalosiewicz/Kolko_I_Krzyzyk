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

        private string text = "Ruch gracza:";
        public string Text 
        {
            get { return text; }
            set
            {
                text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }

        private string ukryj = "Visible";
        public string Ukryj
        {
            get { return ukryj; }
            
            set
            {
                ukryj = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ukryj)));

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

        private ICommand end;
        public ICommand End
        {

            get
            {
                return end ?? (end = new RelayCommand(
                    p => { mainModel.exit(); },
                    p => true
                    ));
            }
        }

        private ICommand reset;
        public ICommand Reset
        {

            get
            {
                return reset ?? (reset = new RelayCommand(
                    p => { mainModel.new_window(); },
                    p => true
                    ));
            }
        }

        private void ruch(object p)
        {
            Symbol = mainModel.ruch_gracza(int.Parse(p.ToString()));
            Kolor = mainModel.zmien_Kolor(int.Parse(p.ToString()));
            
            if (mainModel.sprawdz_gre())
            {
                Text = "Zwycięzca:";
            }
            else if (mainModel.remis())
            {
                Text = "Remis";
                Ukryj = "Collapsed";
            }
            Kogo_ruch = mainModel.zmien_ruch();
            Kolor_Text = mainModel.text_kolor();
            

        }
        
    }
}
