using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Vy
    {
        private const int _linjeLangd = 80;

        public void Instruktion(double startPengar)
        {
            string pengar = Math.Round(startPengar, 2, MidpointRounding.AwayFromZero).ToString();
            string text = "Välkommen till Bageri simulator. \n" +
                "Här kan du driva en butik som ägare av ett bageri. \n" +
                "Ingredienser kan köpas och bröd bakas innan butikens öppning. \n" +
                "Om du sparar dina data kommer de att laddas automatiskt nästa gång du startar upp systemet.\n" +
                "\n" +
                "Du kan baka och sälja följande varor: \n" +
                " * Limpabröd --- KOSTNAD: 22.06 SEK,  PRIS: 31.92 SEK, Dagar Till Utgangs: 4 \n" +
                " * Lantbröd  --- KOSTNAD: 11.91 SEK,  PRIS: 27.94 SEK, Dagar Till Utgangs: 6 \n" +
                " * Kladdkaka --- KOSTNAD: 32.37 SEK,  PRIS: 48.10 SEK, Dagar Till Utgangs: 2 \n" +
                "\n" +
                "0 - 9 Kunder kommer varje dag. De väljer olika varor.\n" +
                "\n" +
                "Du börjar med " + pengar +"SEK. Lycka till!";


            Console.WriteLine("*".PadLeft(_linjeLangd, '*'));
            Console.WriteLine(text);
            Console.WriteLine("*".PadLeft(_linjeLangd, '*'));
        }

        public void VisaHuvudMeny(bool forbereda)
        {
            Console.WriteLine("\n");

            Console.WriteLine("-".PadLeft(_linjeLangd, '-'));
            Console.WriteLine("Nu börja dagens rutiner!\n");
            if (!forbereda)
            {
                Console.WriteLine("-- Du har inte fyllt på lagret än.");
            }
            else
            {
                Console.WriteLine("-- Butiken är redo för öppning !!");
            }
            Console.WriteLine("-".PadLeft(_linjeLangd, '-'));
            Console.WriteLine("Välj förjande nummer:");
            Console.WriteLine("  1. Förbereda butiken.");
            Console.WriteLine("  2. Öppna butiken.");
            Console.WriteLine("  3. Visa result");
            Console.WriteLine("  4. Se butiks hylla");
            Console.WriteLine("  5. Spara data");
            Console.WriteLine("  6. Återställ data");
            Console.WriteLine(" ");
            Console.WriteLine("  9. Avsluta program");
            Console.WriteLine("-".PadLeft(_linjeLangd, '-'));

        }

        public void Plan(Varor[] meny,int[] baksPlan)
        {
            Console.WriteLine("** Idag ska du baka ...");

            for(int i = 0; i < meny.Length; i++)
            {
                Console.WriteLine($"{meny[i].GetBrodTyp()} : {baksPlan[i].ToString()} st.".PadLeft(_linjeLangd, ' '));
            }
            Console.WriteLine();

        }

        public void Inkopning()
        {
            Console.WriteLine("** Du köper ingredienser som krävs.");
            Console.WriteLine();
        }

        public void VisaFaktura(Faktura faktura)
        {
            string[] produktNamnArr = faktura.GetProduktNamn();
            double[] enhetsprisArr = faktura.GetEnhetsprisArr();
            double[] mangdArr = faktura.GetMangdArr();
            string strTotalBelopp = Math.Round(faktura.GetBelopp(), 2, MidpointRounding.AwayFromZero).ToString();


            Console.WriteLine("-- Faktura --".PadRight(_linjeLangd, '-'));

            string heading = "Namn".PadRight(15, ' ') + "Pris /g eller sticken".PadLeft(30, ' ') + "Mängd".PadLeft(15, ' ') + "Belopp".PadLeft(20, ' ');

            Console.WriteLine(heading);

            for (int i = 0; i < produktNamnArr.Length; i++)
            {
                double beloppPerProdukt = mangdArr[i] *enhetsprisArr[i];
                string strBelopp = Math.Round(beloppPerProdukt, 2, MidpointRounding.AwayFromZero).ToString();
                string text = produktNamnArr[i].PadRight(15, ' ') +enhetsprisArr[i].ToString().PadLeft(30, ' ') + mangdArr[i].ToString().PadLeft(15, ' ') + strBelopp.PadLeft(20, ' ');

                Console.WriteLine(text);
            }

            Console.WriteLine("=".PadRight(_linjeLangd, '='));
            Console.WriteLine("Total belopp".PadRight(60, ' ') + strTotalBelopp.PadLeft(20, ' '));

            Console.WriteLine("-".PadRight(_linjeLangd, '-'));
            Console.WriteLine("");

        }

        public void Bakning()
        {
            Console.WriteLine("** Nu bakar du varor...");
            
            for(int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine(" .");
            }

            Console.WriteLine("");
            Console.WriteLine("** Bakad!");
            Console.WriteLine("");

        }

        public void VisaHyllan(string[] hyllan)
        {
            Console.WriteLine("-- Butiks hylla --".PadRight(_linjeLangd, '-'));

            foreach(string text in hyllan)
            {
                Console.WriteLine(text.PadLeft(_linjeLangd, ' '));
            }

            Console.WriteLine("-".PadRight(_linjeLangd, '-'));
            Console.WriteLine("");
        }

        public void Oppen()
        {
            Console.WriteLine("** Du Öppnar butiken.");
        }

        public void Stang()
        {
            Console.WriteLine("** Du stänger butiken. Bra jobbat!!");
            Console.WriteLine(" . ");
            Console.WriteLine("** Du kasserar utgångna varor.");
        }

        public void VisaVinst(double[] vinst)
        {
            string inkomst = "Inkomst : ".PadRight(60, ' ') + vinst[0].ToString().PadLeft(20, ' ');
            string utgift = "Utgifter : ".PadRight(60, ' ') + vinst[1].ToString().PadLeft(20, ' ');
            string result = "Vinst : ".PadRight(60, ' ') + vinst[2].ToString().PadLeft(20, ' ');

            Console.WriteLine("res".PadLeft(_linjeLangd/2, '*') + "ult".PadRight(_linjeLangd / 2, '*'));
            Console.WriteLine("-".PadLeft(_linjeLangd, '-'));
            Console.WriteLine(inkomst);
            Console.WriteLine(utgift);
            Console.WriteLine("=".PadLeft(_linjeLangd, '='));
            Console.WriteLine(result);
            Console.WriteLine("-".PadLeft(_linjeLangd, '-'));
        }

        public void Save()
        {
            Console.WriteLine("** Du sparade data. Nästa gång kan du fortsätta med denna sparade data.");
        }

        public void Radera(bool raderas)
        {
            if (raderas)
            {
                Console.WriteLine("** Du har raderat gamla data. Avsluta och starta om programet för att initiera simulatorn.");
            }
            else
            {
                Console.WriteLine("** Du har ingen sparad data.");
            }
        }
    }
}
