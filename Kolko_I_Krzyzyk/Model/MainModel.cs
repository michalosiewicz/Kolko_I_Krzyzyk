using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kolko_I_Krzyzyk.Model
{
    class MainModel
    {
        private char[] pola;
        private char symbol = 'O';
        private string[] kolory;
        private string kolor = "Green";
        private bool koniec_gry = false;
        
        public MainModel()
        {
            pola = new char[9];
            kolory = new string[9];
        }

        public char[] ruch_gracza(int indeks)
        { 
            pola[indeks] = symbol;
            return pola;
        }

        public bool sprawdz_pole(int indeks)
        {
            if (pola[indeks] == 'O' || pola[indeks] == 'X' || koniec_gry)
                return false;
            else
                return true;
        }

        public bool sprawdz_gre()
        {
            int licznik = 0;
            
            for (int j = 0; j < 9; j += 3)
            {
                for (int i = j; i < j + 3; i++)
                {
                    if (pola[i] == symbol)
                        licznik++;
                    else
                    {
                        licznik = 0;
                        break;
                    }
                }
                if (licznik == 3)
                {
                    koniec_gry = true;
                    return true;
                }
            }
            
            for (int j = 0; j < 3; j ++)
            {
                for (int i = j; i < j + 7; i+=3)
                {
                    if (pola[i] == symbol)
                        licznik++;
                    else
                    {
                        licznik = 0;
                        break;
                    }
                }
                if (licznik == 3)
                {
                    koniec_gry = true;
                    return true;
                }
            }
            
            for (int i = 0; i < 9; i += 4)
            {
                if (pola[i] == symbol)
                    licznik++;
                else
                {
                    licznik = 0;
                    break;
                }
            }
            if (licznik == 3)
            {
                koniec_gry = true;
                return true;
            }
            
            for (int i = 2; i < 7; i += 2)
            {
                if (pola[i] == symbol)
                    licznik++;
                else
                {
                    licznik = 0;
                    break;
                }
            }
            if (licznik == 3)
            {
                koniec_gry = true;
                return true;
            }
            return false;
        }
    
        public string[] zmien_Kolor(int indeks)
        {
            kolory[indeks] = kolor;
            if (kolor == "Red")
                kolor = "Green";
            else
                kolor = "Red";
            return kolory;
        }

        public char zmien_ruch()
        {
            if (!koniec_gry)
            {
                if (symbol == 'O')
                    symbol = 'X';
                else
                    symbol = 'O';
            }
            return symbol;
        }

        public string text_kolor()
        {
            if (symbol == 'O')
                return "Green";
            else
                return "Red";
        }

        public bool remis()
        {
            foreach(char s in pola)
            {
                if (s!='X'&&s!='O')
                    return false;
            }
            return true;
        }

        public void new_window()
        {
            var wynik = MessageBox.Show("Czy na pewno chcesz rozpocząć grę od początku?", "Od nowa",
                MessageBoxButton.YesNo);

            if (wynik == MessageBoxResult.Yes)
            {

                Window oldWindow = App.Current.MainWindow;

                App.Current.MainWindow = new MainWindow();
                App.Current.MainWindow.Top = oldWindow.Top;
                App.Current.MainWindow.Left = oldWindow.Left;
                App.Current.MainWindow.Show();
                oldWindow.Close();
            }
        }
        public void exit()
        {
            var wynik = MessageBox.Show("Czy na pewno chcesz zamknąć grę?", "Wyjdź",
                MessageBoxButton.YesNo);
            if (wynik == MessageBoxResult.Yes)
            {
                App.Current.MainWindow.Close();
            }
        }
    }

}
