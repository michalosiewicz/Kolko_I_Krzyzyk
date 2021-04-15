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

                char winner=mainModel.sprawdz_gre();
                if (winner == 'O' || winner == 'X')
                {
                    MessageBox.Show($"Wygrał gracz {winner}!", "Zwycięzca");
                    Application.Current.Shutdown();
                }

            }
        }


        private ICommand wpisz;
        public ICommand Wpisz
        {
            
            get
            {
                return wpisz ?? (wpisz = new RelayCommand(
                    p => { Symbol = mainModel.ruch_gracza(int.Parse(p.ToString())); },
                    p =>  mainModel.sprawdz_pole(int.Parse(p.ToString()))
                    ));
            }
        }

    }
}
