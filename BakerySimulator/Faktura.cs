using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Faktura
    {
        private int _menyVal = 10;

        private string[] _produktNamnArr = {
            "Kakao",
            "Ragmjol",
            "Salt",
            "Smor",
            "Socker",
            "Agg",
            "VaniljSocker",
            "Jast",
            "Vetemjol",
            "Mjolk"
        };

        private double[] _enhetsprisArr =
        {
            0.15,       // "Kakao",
            0.017,      // "Ragmjol",
            0.125,      // "Salt",
            0.12,       // "Smor",
            0.018,      // "Socker",
            3.5,        // "Agg",
            0.078,      // "VaniljSocker",
            0.07,       // "Jast",
            0.0135,     // "Vetemjol",
            0.013       // "Mjolk"
        };


        private double [] _mangdArr;
        private DateTime _datum;

        public Faktura()
        {
            _datum = DateTime.Now;
            _mangdArr = new double[_menyVal];

            for (int i = 0; i < _menyVal; i++)
            {
                _mangdArr[i] = 0;
            }
        }

        public Faktura(double[] orderkvantitet,  DateTime date)
        {
            _datum = date;
            _mangdArr = new double[_menyVal];

            for (int i = 0; i < _menyVal; i++)
            {
                _mangdArr[i] = orderkvantitet[i];
            }
        }

        public string[] GetProduktNamn()
        {
            return _produktNamnArr;
        }

        public double[] GetEnhetsprisArr() 
        { 
            return _enhetsprisArr;
        }

        public double[] GetMangdArr() { 
            return _mangdArr; 
        }

        public double GetBelopp()
        {
            double belopp = 0;

            for (int i = 0; i < _menyVal; i++)
            {
                belopp += _mangdArr[i] * _enhetsprisArr[i];
            }
            

            return Math.Round( belopp, 2, MidpointRounding.AwayFromZero);
        }

        public void VisaFaktura()
        {
            Console.WriteLine("-- Faktura --".PadRight(80, '-'));

            string heading = "Namn".PadRight(15, ' ') + "Pris /g eller sticken".PadLeft(30, ' ') + "Mängd".PadLeft(15, ' ') + "Belopp".PadLeft(15, ' ');

            Console.WriteLine(heading);

            for (int i = 0; i < _produktNamnArr.Length ; i++)
            {
                double beloppPerProdukt = _mangdArr[i] * _enhetsprisArr[i];
                string strBelopp = Math.Round(beloppPerProdukt, 2, MidpointRounding.AwayFromZero).ToString();
                string text = _produktNamnArr[i].PadRight(15, ' ') + _enhetsprisArr[i].ToString().PadLeft(30, ' ') + _mangdArr[i].ToString().PadLeft(15, ' ') + strBelopp.PadLeft(15, ' ');

                Console.WriteLine(text);
            }

            Console.WriteLine("-".PadRight(80, '-'));
            Console.WriteLine("");
        }

        public string GetData()
        {
            string data = "";

            data += _datum.ToString() + ",";

            for (int i = 0; i < _mangdArr.Length; i++)
            {
                data += _mangdArr[i].ToString();
                if (i != _mangdArr.Length - 1)
                {
                    data += " ";
                }
            }

            return data;
        }

    }
}
