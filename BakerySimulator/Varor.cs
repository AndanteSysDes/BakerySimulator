using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Varor
    {
        private const double _momsProcent = 0.12;

        protected double _enhetspris;
        protected double _forsaljningsbelopp;
        protected int _dagarTillUtgangsdatum;

        protected Stock _ingrediens;

        protected string _brodtyp;

        public Varor()
        {
            _enhetspris = 100.0;
            _forsaljningsbelopp = Math.Round( _enhetspris + _enhetspris * _momsProcent, 2, MidpointRounding.AwayFromZero);
            _dagarTillUtgangsdatum = 3;
            _ingrediens = new Stock();
            _brodtyp = "Varor";
        }

        public Varor(double enhatspris, int utgangsdatum)
        {
            _enhetspris = enhatspris;
            _forsaljningsbelopp = Math.Round(_enhetspris + _enhetspris * _momsProcent, 2, MidpointRounding.AwayFromZero);
            _dagarTillUtgangsdatum = utgangsdatum;
            _ingrediens = new Stock();
            _brodtyp = "Varor";
        }

        public Stock BakRecipt()
        {
            return _ingrediens;
        }
        public Stock BakRecept(int antal)
        {
            Stock antalStock = new Stock(_ingrediens, antal);
            return antalStock;
        }

        public double GetPris()
        {
            return _forsaljningsbelopp;
        }

        public int GetDagar()
        {
            return _dagarTillUtgangsdatum;
        }

        public void forsamring()
        {
            -- _dagarTillUtgangsdatum;
        }
        public string GetBrodTyp()
        {
            return _brodtyp;
        }

        public string GetData(string divider)
        {
            string data = GetBrodTyp()+ divider + GetDagar().ToString();

            return data;
        }
    }
}
