using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Kvitto
    {
        private List<Varor> _varors;
        private double _belopp;
        private DateTime _datum;

        public Kvitto()
        {
            _varors = new List<Varor>();
            _belopp = 0;
            _datum = new DateTime();
        }
        public Kvitto(List<Varor> varors, DateTime date)
        {
            _varors = varors;
            _datum = date;
            double belopp = 0;

            foreach (var varor in varors)
            {
                belopp += varor.GetPris();
            }
            _belopp = Math.Round(belopp, 2, MidpointRounding.AwayFromZero);
        }

        public double GetBelopp()
        {
            return Math.Round(_belopp, 2, MidpointRounding.AwayFromZero);
        }

        public string GetData()
        {
            // [ datum, varor("brodtyp dagar"),varor("brodtyp dagar")...]

            string varorData = "";
            string data = "";

            data += _datum.ToString() + ",";

            for (int i = 0; i < _varors.Count; i++)
            {
                varorData += _varors[i].GetData(" ");
                if(i != _varors.Count - 1)
                {
                    varorData += ",";
                }
            }

            data += varorData;

            return data;
        }
    }
}
