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
            Console.Write("Jméno:");
            string text;
            while (!String.IsNullOrEmpty(text = Console.ReadLine())) sb.Append(text);//s tím něco provést
            File.WriteAllText(cesta + "Kartotéka.txt", sb.ToString());
            VyberMenu();
        }
        static void VypsaniSouboru()
        {
            if (File.Exists(cesta + "Kartotéka.txt"))
            {
                string[] DataOUzivatelich = File.ReadAllText(cesta + "Kartotéka.txt").Split(',');
            }
            else
            {
                Console.WriteLine("Nejsou uložena žádná data.\n");
                ZapisdoSouboru();
            }
            Console.WriteLine("Uložené údaje o uživatelích:\n");
            Console.WriteLine("jméno".PadRight(15)+ "příjmení".PadRight(20)+"rok narození".PadLeft(15));



            VyberMenu();
        }
    }
}
