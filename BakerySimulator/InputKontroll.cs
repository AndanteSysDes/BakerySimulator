using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class InputKontroll
    {
        private string _saveDirectory = "savadata";
        private string _butikHyllaFil = "butikHylla.txt";
        private string _bokforingFil = "bokforing.txt";
        private string _kvittoFil = "kvitto.txt";
        private string _fakturaFil = "faktura.txt";


        public int[] InputPlan(Varor[] meny)
        {
            int[] bakPlan = new int[meny.Length];

            for (int i = 0; i < meny.Length; i++)
            {
                Console.WriteLine($"Skriv hur många du ska sälja {meny[i].GetBrodTyp()}  :");
                string plan = Console.ReadLine();
                int planNummer;
                int.TryParse(plan, out planNummer);
                bakPlan[i] = planNummer;
            }

            return bakPlan;

        }

        public int ValjaMeny()
        {
            // Ta emot indata
            string menyVal = Console.ReadLine();
            int menyNum;
            Int32.TryParse(menyVal, out menyNum);

            return menyNum;
        }

        public Butik LoadButik(Varor[] meny)
        {
            Butik butik;
            Bokforing bokforing;
            List<Varor> butiksHylla = new List<Varor>();
            

            if (!Directory.Exists(_saveDirectory) || Directory.GetFiles(_saveDirectory).Length == 0)
            {
                Console.WriteLine(" --- Du har ingen sparad data. \n");
                butik = new Butik(meny);
                return butik;
            }

            Console.WriteLine(" --- Sparad data laddas. \n");

            List<string> balans = LasaData(_bokforingFil);
            List<string> kvittoData = LasaData(_kvittoFil);
            List<string> fakturaData = LasaData(_fakturaFil);
            List<string> hyllanData = LasaData(_butikHyllaFil);

            bokforing = LasaBokforing(balans, kvittoData, fakturaData);

            butiksHylla = ParseVaror(hyllanData);

            butik = new Butik(meny, bokforing, butiksHylla);

            return butik;
        }


        public void Save(Butik butik)
        {
            List<Varor> hyllan = butik.GetAllHyllan();
            Bokforing bokforing = butik.GetBokforing();
            List<Kvitto> kvitton = bokforing.GetKvitton();
            List<Faktura> fakturor = bokforing.GetFakturor();

            // Skapa SAVEDATA
            string[] hyllanData = new string[hyllan.Count];
            string[] kvittoData = new string[kvitton.Count];
            string[] fakturaData = new string[fakturor.Count];
            double[] balans = bokforing.GetBalans();


            // hyllan data
            for (int i = 0; i < hyllan.Count; i++)
            {
                hyllanData[i] = hyllan[i].GetData(" ");
            }

            // kvitton data
            for (int i = 0;i < kvitton.Count; i++)
            {
                kvittoData[i] = kvitton[i].GetData();
            }

            // fakturor data
            for(int i = 0; i < fakturor.Count; i++)
            {
                fakturaData[i] = fakturor[i].GetData();
            }

            SkrivData(_bokforingFil, balans);
            SkrivData(_butikHyllaFil, hyllanData);
            SkrivData(_kvittoFil, kvittoData);
            SkrivData(_fakturaFil, fakturaData);

        }

        // Returnerar TRUE om någon av filerna raderas.
        public bool Radera()
        {
            if( DeleteData(_bokforingFil) || DeleteData(_kvittoFil) || DeleteData(_fakturaFil) || DeleteData(_butikHyllaFil))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        void SkrivData(string filNamn, string[] data)
        {
            if (!Directory.Exists(_saveDirectory))
            {
                Directory.CreateDirectory(_saveDirectory);
            }

            string filpath = Path.Combine(_saveDirectory, filNamn);


            if (File.Exists(filpath))
            {
                File.Copy(filpath, "_tmp_" + filNamn, false);
                File.Delete(filpath);
            }

            using (StreamWriter sw = File.CreateText(filpath))
            {
                foreach (string d in data)
                {
                    sw.WriteLine(d);

                }
            }

            if (File.Exists("_tmp_" + filNamn))
            {
                File.Delete("_tmp_" + filNamn);
            }

        }

        void SkrivData(string filNamn, double[] data)
        {
            if (!Directory.Exists(_saveDirectory))
            {
                Directory.CreateDirectory(_saveDirectory);
            }

            string filpath = Path.Combine(_saveDirectory, filNamn);

            if (File.Exists(filpath))
            {
                File.Copy(filpath, "_tmp_" + filNamn, false);
                File.Delete(filpath);
            }

            using (StreamWriter sw = File.CreateText(filpath))
            {
                foreach (double d in data)
                {
                    sw.WriteLine(d);

                }
            }

            if (File.Exists("_tmp_" + filNamn))
            {
                File.Delete("_tmp_" + filNamn);
            }

        }

        bool DeleteData(string filNamn)
        {
            if (!Directory.Exists(_saveDirectory))
            {
                Console.WriteLine($"Katalogen {_saveDirectory} finns inte.");
                return false;
            }

            string filpath = Path.Combine(_saveDirectory, filNamn);

            if (!File.Exists(filpath))
            {
                Console.WriteLine($"Filen {filNamn} finns inte.");
                return false;
            }

            Console.WriteLine($"Filen {filNamn} raderad.");
            File.Delete(filpath);
            return true;
        }

        List<string> LasaData(string filNamn)
        {
            List<string> strings = new List<string>();

            string filPath = Path.Combine(_saveDirectory, filNamn);

            if (!File.Exists(filPath))
            {
                return strings;
            }

            using (StreamReader sr = File.OpenText(filPath))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    strings.Add(filtext);

                }

            }
            return strings;
        }

        Bokforing LasaBokforing(List<string> balans, List<string> kvittoData, List<string> fakturaData)
        {
            Bokforing bokforing;

            double[] loadData = new double[3];
            List<Kvitto> kvitton = new List<Kvitto>();
            List<Faktura> fakturor = new List<Faktura>();

            // Ordna balans data
            double.TryParse(balans[0], out loadData[0]);
            double.TryParse(balans[1], out loadData[1]);
            double.TryParse(balans[2], out loadData[2]);

            // Ordna kvitto data
            foreach (string data in kvittoData)
            {
                Kvitto kvitto;
                string[] kvittoArr = data.Split(',');
                string[] varorList = new string[kvittoArr.Length - 1];
                DateTime datum;
                List<Varor> varors;


                DateTime.TryParse(kvittoArr[0], out datum);

                Array.Copy(kvittoArr, 1, varorList, 0, kvittoArr.Length - 1);

                varors = ParseVaror(varorList);

                kvitto = new Kvitto(varors, datum);
                kvitton.Add(kvitto);
            }

            // Ordna faktura data
            foreach (string data in fakturaData)
            {
                Faktura faktura;
                string[] fakturaArr = data.Split(",");
                string[] produktList = fakturaArr[1].Split(" ");
                double[] mangdArr = new double[produktList.Length];
                DateTime datum;

                DateTime.TryParse(fakturaArr[0], out datum);

                for (int i = 0; i < produktList.Length; i++)
                {
                    double.TryParse(produktList[i], out mangdArr[i]);
                }

                faktura = new Faktura(mangdArr, datum);
                fakturor.Add(faktura);
            }


            bokforing = new Bokforing(loadData, kvitton, fakturor);

            return bokforing;
        }

        List<Varor> ParseVaror(string[] varorList)
        {
            List<Varor> varors = new List<Varor>();


            foreach (string data in varorList)
            {
                string[] varorData = data.Split(' ');
                string brodTyp = varorData[0];
                int restDagar;
                int.TryParse(varorData[1], out restDagar);

                switch (brodTyp)
                {
                    case "Limpabröd":
                        Limpabrod limpabrod = new Limpabrod(restDagar);
                        varors.Add(limpabrod);
                        break;

                    case "Lantbröd":
                        Lantbrod lantbrod = new Lantbrod(restDagar);
                        varors.Add(lantbrod);
                        break;

                    case "Kladdkaka":
                        Kaka kaka = new Kaka(restDagar);
                        varors.Add(kaka);
                        break;

                }

            }
            return varors;
        }

        List<Varor> ParseVaror(List<string> varorList)
        {
            List<Varor> varors = new List<Varor>();


            foreach (string data in varorList)
            {
                string[] varorData = data.Split(' ');
                string brodTyp = varorData[0];
                int restDagar;
                int.TryParse(varorData[1], out restDagar);

                switch (brodTyp)
                {
                    case "Limpabröd":
                        Limpabrod limpabrod = new Limpabrod(restDagar);
                        varors.Add(limpabrod);
                        break;

                    case "Lantbröd":
                        Lantbrod lantbrod = new Lantbrod(restDagar);
                        varors.Add(lantbrod);
                        break;

                    case "Kladdkaka":
                        Kaka kaka = new Kaka(restDagar);
                        varors.Add(kaka);
                        break;

                }

            }
            return varors;
        }
    }
}
