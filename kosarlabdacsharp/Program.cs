using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace kosarlabdacsharp
{
    
    class Program
    {
        static string URL_lekerdezes(string url) // Az API-tól kapott adatok feldolgozása.
        {
            string sURL;
            string szoveg = "";
            sURL = url;
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);


            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string sor = "";
            int i = 0;

            while (sor != null)
            {
                i++;
                sor = objReader.ReadLine(); // Sorokat olvasunk be, de igazából csak 1 sor van mindig.
                if (sor != null)
                {
                    szoveg = sor; // Ha nem csak 1 sor lenne, akkor ez rossz lenne, de tudom, hogy csak 1 lesz mindig.
                }
            }
            return szoveg;

        }


        static int MainMenu() // A főmenü, mindig ide tér vissza a program.
        {
            Menu menu = new Menu();
            menu.DeclareMenu();
            bool isNum = false;
            while (isNum == false) { // Levédés
                menu.WriteMenu();
                Console.Write("Kérem adja meg a menü számát (1-" + menu.menuk_szama + "): ");
                isNum = Int32.TryParse(Console.ReadLine(), out menu.menu_szama); // Levédés

             if (isNum == false) // Levédés
             {
                 Console.Clear();
                 Console.WriteLine("Hibás menüpont.");
             }
             else
             {
                 if (menu.menu_szama < 1 || menu.menu_szama > menu.menuk_szama) // Levédés
                 {
                     isNum = false;
                     Console.Clear();
                     Console.WriteLine("Hibás menüpont.");
                 }
             }
            }

            return menu.menu_szama;

        }

        static void Main(string[] args)
        {

            string api_url = "http://localhost/kosarlabda_1/kosarlabdaphp/"; // Itt található a PHP API
            string api_key = "8Rj3W4nsBN"; // PHP API kulcsa (index.php-ban megtalálható)

            while (true) // Örökké megy, kivéve ha kilépés menüpontot választja a felhasználó.
            {
                double menu_szama = MainMenu();

                //<<<<<<<<<<<<<<<<<<< 1. MENÜPONT >>>>>>>>>>>>>>>>>>>
                // összes kosárlabdázó játékos neve
                if (menu_szama == 1)
                {
                    Console.Clear();
                    string szoveg = URL_lekerdezes(api_url+"?key="+api_key+"&parancs=osszes_lista&asc=0"); // ASC=0 (sorbarendezés nélkül)

                    if (szoveg != "ERROR:1")
                    {
                        string[] valasztas = szoveg.Split(":".ToCharArray());
                        Console.WriteLine("Az összes játékos listája: ");
                        for (int i = 0; i < valasztas.Length; i++)
                        {
                            Console.WriteLine(valasztas[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Üres adatbázis.");
                    }

                }



                //<<<<<<<<<<<<<<<<<<< 2. MENÜPONT >>>>>>>>>>>>>>>>>>>
                // játékosok nevei névsorban
                if (menu_szama == 2)
                {
                    Console.Clear();
                    string szoveg = URL_lekerdezes(api_url + "?key=" + api_key + "&parancs=osszes_lista&asc=1"); // ASC=1 (sorbarendezés)

                    if (szoveg != "ERROR:1")
                    {
                        string[] valasztas = szoveg.Split(":".ToCharArray());
                        Console.WriteLine("Az összes játékos listája névsorban: ");
                        for (int i = 0; i < valasztas.Length; i++)
                        {
                            Console.WriteLine(valasztas[i]);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Üres adatbázis.");
                    }

                }


                //<<<<<<<<<<<<<<<<<<< 3. MENÜPONT >>>>>>>>>>>>>>>>>>>
                // válogassuk ki egy !csapat! 190 cm-nél magasabb játékosait
                if (menu_szama == 3)
                {
                    Console.Clear();

                    string szoveg_csapatok = URL_lekerdezes(api_url + "?key=" + api_key + "&parancs=csapatok");
                    // Példa |  Potato,1:Krumpli,2

                    string[] szo = szoveg_csapatok.Split(":".ToCharArray()); // Csapatok szétválasztása
                    string[][] csapatok = new string[szo.Length][]; // Csapatok neve és ID-je
                    int[] szo_szam = szo_szam = new int[szo.Length]; // Csapatok ID-je Int-ben
                    if (szoveg_csapatok != "ERROR:1")
                    {

                      for (int i = 0; i < szo.Length; i++)
                      {
                         csapatok[i] = szo[i].Split(",".ToCharArray());
                         szo_szam[i] = Convert.ToInt16(csapatok[i][1]);
                      }

                    }
                    else
                    {
                        Console.WriteLine("Üres adatbázis.");
                    }

                    int csapat = 0;
                    bool vanilyen = false;
                    bool isNum = false;
                    Console.Clear();

                    while (isNum == false)
                    {
                       

                        for (int i = 0; i < szo.Length; i++)
                        {
  
                            Console.WriteLine("[" + szo_szam[i] + "] " + csapatok[i][0]);
                        }

                        Console.Write("Kérem adja meg a csapat számát: ");
                        isNum = Int32.TryParse(Console.ReadLine(), out csapat);

                        if (isNum == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Hibás csapat!");
                        }
                        else
                        {
                            for (int i = 0; i < szo_szam.Length; i++)
                            {
                                if (szo_szam[i] == csapat)
                                {
                                    vanilyen = true;
                                }
                            }

                            if (vanilyen == false)
                            {
                                isNum = false;
                                Console.Clear();
                                Console.WriteLine("Hibás csapat!");
                            }

                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("A csapat 190 cm-nél magasabb játékosai: ");

                    string szoveg = URL_lekerdezes(api_url + "?key=" + api_key + "&parancs=magas&csapat=" + csapat);

                    if (szoveg != "ERROR:1")
                    {
                      string[] valasztas = szoveg.Split(":".ToCharArray());

                      for (int i = 0; i < valasztas.Length; i++)
                      {
                          Console.WriteLine(valasztas[i]);
                      }
                    }
                    else
                    {
                        Console.WriteLine("Üres adatbázis vagy nincs a kérésnek megfelelő játékos.");
                    }
                    
                }



                //<<<<<<<<<<<<<<<<<<< 4. MENÜPONT >>>>>>>>>>>>>>>>>>>
                // játékosok nevei amelyik mindegyik csapatban játszanak
                if (menu_szama == 4)
                {
                    Console.Clear();
                    string szoveg = URL_lekerdezes(api_url + "?key=" + api_key + "&parancs=hiperaktiv");

                    if (szoveg != "ERROR:1")
                    {
                        string[] valasztas = szoveg.Split(":".ToCharArray());
                        Console.WriteLine("Azok a játékosok, akik minden csapatban szerepelnek: ");
                        for (int i = 0; i < valasztas.Length; i++)
                        {
                            Console.WriteLine(valasztas[i]);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Üres adatbázis vagy nincs a kérésnek megfelelő játékos.");
                    }

                }



                //<<<<<<<<<<<<<<<<<<< 5. MENÜPONT >>>>>>>>>>>>>>>>>>>
                // kovács vezetéknevű játékos van-e?
                if (menu_szama == 5)
                {
                    Console.Clear();
                    string szoveg = URL_lekerdezes(api_url + "?key=" + api_key + "&parancs=kovacs");

                    if (szoveg != "ERROR:1")
                    {
                        string[] valasztas = szoveg.Split(":".ToCharArray());
                        Console.WriteLine("Azok a játékosok akiknek Kovács a nevük: ");
                        for (int i = 0; i < valasztas.Length; i++)
                        {
                            Console.WriteLine(valasztas[i]);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Nincs Kovács.");
                    }

                }

                //<<<<<<<<<<<<<<<<<<< 6. MENÜPONT >>>>>>>>>>>>>>>>>>>
                if (menu_szama == 6)
                {
                    Environment.Exit(0); // Kilépés
                }

                
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
