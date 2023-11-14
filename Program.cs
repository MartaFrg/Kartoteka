using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartoteka
{
    internal class Program
    {

        static string cesta = @"C:\Ctechitas\";
        static List<String[]> ListPolozek = new List<String[]>();

        static void Main(string[] args)
        {
            if (!Directory.Exists(cesta)) Directory.CreateDirectory(cesta);
            VyberMenu();
        }
        static void VyberMenu()
        {
            int volba;
            Console.WriteLine();
            Console.WriteLine("Vyber číselnou volbu: \n 1) Vypsat všechny načtené údaje \n 2) Přidání uživatele \n 3) Načti ze souboru \n 4) Ulož do souboru \n 5) Ukonči \n");
            while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > 5)) Console.WriteLine("Zadej číslo od 1 do 5.");
            Console.Write("Tvoje volba je ");
            switch (volba)
            {
                case 1:
                    Console.WriteLine("vypsat všechny načtené údaje.\n");
                    VypisPolozky();
                    break;
                case 2:
                    Console.WriteLine("přidat uživatele.\n");
                    PridatUzivatele();
                    break;
                case 3:
                    Console.WriteLine("načíst uložený soubor.\n");
                    NacistSoubor();
                    break;
                case 4:
                    Console.WriteLine("přepsat uložený soubor.\n");
                    ZapisDoSouboru();
                    break;
                case 5:
                    Console.WriteLine("ukončit.\n");
                    break;
            }
        }

        static void PridatUzivatele()
        {
            string jmeno;
            string prijmeni;
            int rokNarozeni;
            Console.WriteLine("Zadej nového uživatele do kartotéky:");
            Console.Write("Jméno: ");
            jmeno = Console.ReadLine();
            Console.Write("Příjmení: ");
            prijmeni = Console.ReadLine();
            Console.Write("Rok narození: ");
            while (!int.TryParse(Console.ReadLine(), out rokNarozeni) || rokNarozeni > DateTime.Now.Year || rokNarozeni < DateTime.Now.Year - 110) Console.WriteLine("Zadej platný rok narození uživatele.");
            ListPolozek.Add(new string[] { jmeno, prijmeni, rokNarozeni.ToString() });
            VyberMenu();
        }
        static void VypisPolozky()
        {
            Console.WriteLine("jméno".PadRight(15) + "příjmení".PadRight(16) + "rok narození".PadRight(16));
            foreach (string[] item in ListPolozek) 
            { Console.WriteLine(item[0].PadRight(15) + " "+item[1].PadRight(15) + " "+item[2]); }
            VyberMenu();
        }
        static void NacistSoubor()
        {
            if (File.Exists(cesta + "Kartotéka.txt"))
            {
                string[] seznamPolozek = File.ReadAllLines(cesta + "Kartotéka.txt");
                foreach(string s in seznamPolozek)
                {
                    ListPolozek.Add(s.Split(' ')); 
                }
            }
            else
            {
                Console.WriteLine("Nejsou uložena žádná data.\n");
            }
            VyberMenu();
        }
        static void ZapisDoSouboru()
        {
            File.WriteAllText(cesta + "Kartotéka.txt", string.Empty);
            foreach (string[] item in ListPolozek)
            {
                File.AppendAllText(cesta + "Kartotéka.txt", String.Join(" ", item)+"\n");
            }
            VyberMenu();
        }
        /*static void ZapisdoSouboru()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Zadej nového uživatele do kartotéky:");
            Console.Write("Jméno: ");
            sb.Append("\n"+Console.ReadLine() + ",");
            Console.Write("Příjmení: ");
            sb.Append(Console.ReadLine() + ",");
            Console.Write("Rok narození: ");
            int rokNarozeni;
            while (!int.TryParse(Console.ReadLine(), out rokNarozeni)||rokNarozeni> DateTime.Now.Year|| rokNarozeni < DateTime.Now.Year-110) Console.WriteLine("Zadej platný rok narození uživatele.");
            sb.Append(rokNarozeni + ",");
            Console.WriteLine();
            //string text;

            File.AppendAllText(cesta + "Kartotéka.txt", sb.ToString());
            VyberMenu();
        }*/
        /*static void VypsaniSouboru()
        {
            string[] dataOUzivatelich;
            if (File.Exists(cesta + "Kartotéka.txt"))
            {
                dataOUzivatelich = File.ReadAllText(cesta + "Kartotéka.txt").Split(',');
                Console.WriteLine("Uložené údaje o uživatelích:\n");
                Console.WriteLine("jméno".PadRight(14) + "příjmení".PadRight(15) + "rok narození".PadRight(15));
                for (int i = 0; i < dataOUzivatelich.Length; i++) 
                {
                    Console.Write(dataOUzivatelich[i].PadRight(15));
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nejsou uložena žádná data.\n");
                ZapisdoSouboru();
            }
            VyberMenu();
        }*/
    }
}
