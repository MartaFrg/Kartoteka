using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartoteka
{
    internal class Program
    {

        static string cesta = @"C:\Ctechitas\";
        static void Main(string[] args)
        {
            if (!Directory.Exists(cesta)) Directory.CreateDirectory(cesta);
            VyberMenu();
        }
        static void VyberMenu()
        {
            int volba;
            Console.WriteLine("Vyber číselnou volbu: \n 1) Vypsat všechny uložené údaje \n 2) Přidání uživatele \n 3) Ukonči \n");
            while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > 3)) Console.WriteLine("Zadej číslo od 1 do 3.");
            Console.Write("Tvoje volba je ");
            switch (volba)
            {
                case 1:
                    Console.WriteLine("vypsat všechny uložené údaje.\n");
                    VypsaniSouboru();
                    break;
                case 2:
                    Console.WriteLine("přidat uživatele.\n");
                    ZapisdoSouboru();
                    break;
                case 3:
                    Console.WriteLine("ukončit.\n");
                    break;
            }
        }
        static void ZapisdoSouboru()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Zadej nového uživatele do kartotéky:");
            Console.Write("Jméno: ");
            sb.Append(Console.ReadLine() + ",");
            Console.Write("Příjmení: ");
            sb.Append(Console.ReadLine() + ",");
            Console.Write("Rok narození: ");
            int rokNarozeni;
            while (!int.TryParse(Console.ReadLine(), out rokNarozeni)||rokNarozeni> DateTime.Now.Year|| rokNarozeni < DateTime.Now.Year-110) Console.WriteLine("Zadej platný rok narození uživatele.");
            sb.Append(rokNarozeni + ",\n");
            Console.WriteLine();
            //string text;

            File.AppendAllText(cesta + "Kartotéka.txt", sb.ToString());
            VyberMenu();
        }
        static void VypsaniSouboru()
        {
            string[] dataOUzivatelich;
            if (File.Exists(cesta + "Kartotéka.txt"))
            {
                dataOUzivatelich = File.ReadAllText(cesta + "Kartotéka.txt").Split(',');
                Console.WriteLine("Uložené údaje o uživatelích:\n");
                Console.WriteLine("jméno".PadRight(15) + "příjmení".PadRight(15) + "rok narození".PadRight(15));
                for (int i = 0; i < dataOUzivatelich.Length; i++) 
                {
                    Console.Write(dataOUzivatelich[i].PadRight(15));
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nejsou uložena žádná data.\n");
                ZapisdoSouboru();
            }
            VyberMenu();
        }
    }
}
