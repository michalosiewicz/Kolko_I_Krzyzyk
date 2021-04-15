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
        private char symbol = 'X';
        
        public MainModel()
        {
            pola = new char[9];
        }

        public char[] ruch_gracza(int indeks)
        {
            if (symbol == 'O')
                symbol = 'X';
            else
                symbol = 'O';
            pola[indeks] = symbol;
            return pola;
        }

        public bool sprawdz_pole(int indeks)
        {
            if (pola[indeks] == 'O' || pola[indeks] == 'X')
                return false;
            else
                return true;
        }

        public char sprawdz_gre()
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
                    return symbol;
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
                    return symbol;
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
                return symbol;
            
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
                return symbol;
            return '0';
        }
    }
}
