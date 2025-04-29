using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerySimulator
{
    internal class Bokforing
    {
        private double _aktiekapital;

        private double _totalInkomst;
        private double _totalUtgifter;

        private List<Kvitto> _totalKvitto ;
        private List<Faktura> _totalFaktura ;

        public Bokforing()
        {
            _aktiekapital = 100000;
            _totalInkomst = 0;
            _totalUtgifter = 0;
            _totalKvitto = new List<Kvitto>();
            _totalFaktura = new List<Faktura>();
        }

        public Bokforing(double[] loadData, List<Kvitto> kvitton, List<Faktura> fakturor)
        {
            _aktiekapital = loadData[0];
            _totalInkomst = loadData[1];
            _totalUtgifter = loadData[2];
            _totalKvitto = kvitton;
            _totalFaktura = fakturor;

        }

        public double GetKontanter()
        {
            double kontanter = _aktiekapital + _totalInkomst - _totalUtgifter;

            return kontanter;
        }

        public void SkrivFaktura(Faktura faktura)
        {
            _totalFaktura.Add(faktura);
            _totalUtgifter += faktura.GetBelopp();

        }

        public void SkrivKvitto(Kvitto kvitto)
        {
            _totalKvitto.Add(kvitto);
            _totalInkomst += kvitto.GetBelopp();
        }

        public double GetTotalInkomst()
        {
            return Math.Round(_totalInkomst, 2, MidpointRounding.AwayFromZero);
        }

        public double GetTotalUtgift()
        {
            return Math.Round(_totalUtgifter, 2, MidpointRounding.AwayFromZero);
        }

        public double[] GetBalans()
        {
            double[] balans = { _aktiekapital, _totalInkomst, _totalUtgifter};
            return balans;
        }

        public List<Kvitto> GetKvitton()
        {
            return _totalKvitto;
        }

        public List<Faktura> GetFakturor()
        {
            return _totalFaktura;
        }

    } 
}
