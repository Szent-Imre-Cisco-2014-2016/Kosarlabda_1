using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosarlabdacsharp
{
    class Menu
    {
        public int menuk_szama = 6;
        string[] menuk = new string[6];
        public int menu_szama = 0;
        public void DeclareMenu() // Menük deklarálása függvény.
        {
            menuk[0] = "Összes játékos";
            menuk[1] = "Összes játékos névsorban";
            menuk[2] = "190 cm-nél magasabb játékosok";
            menuk[3] = "Azok a játékosok, akik minden csapatban játszanak";
            menuk[4] = "Van kovács?";
            menuk[5] = "Kilépés";
        }

        public void WriteMenu() // Menük kiiratása függvény.
        {
            for (int i = 0; i < this.menuk_szama; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + menuk[i]);
            }
        }

    }
}
