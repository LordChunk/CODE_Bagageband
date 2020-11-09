using System;
using System.Collections.Generic;
using System.Linq;

namespace DPINT_Wk3_Observer.Model
{
    public class Aankomsthal : IObserver<Bagageband>
    {
        // TODO: Hier een ObservableCollection van maken, dan weten we wanneer er vluchten bij de wachtrij bij komen of afgaan.
        public List<Vlucht> WachtendeVluchten { get; private set; }
        public List<Bagageband> Bagagebanden { get; private set; }

        public Aankomsthal()
        {
            WachtendeVluchten = new List<Vlucht>();
            Bagagebanden = new List<Bagageband>();

            // TODO: Als bagageband Observable is, gaan we subscriben op band 1 zodat we updates binnenkrijgen.
            Bagagebanden.Add(new Bagageband("Band 1", 30));
            // TODO: Als bagageband Observable is, gaan we subscriben op band 2 zodat we updates binnenkrijgen.
            Bagagebanden.Add(new Bagageband("Band 2", 60));
            // TODO: Als bagageband Observable is, gaan we subscriben op band 3 zodat we updates binnenkrijgen.
            Bagagebanden.Add(new Bagageband("Band 3", 90));

            Bagagebanden.ForEach(band => band.Subscribe(this));
        }

        public void NieuweInkomendeVlucht(string vertrokkenVanuit, int aantalKoffers)
        {
            // TODO: Het proces moet straks automatisch gaan, dus als er lege banden zijn moet de vlucht niet in de wachtrij.
            // Dan moet de vlucht meteen naar die band.

            // Denk bijvoorbeeld aan: Bagageband legeBand = Bagagebanden.FirstOrDefault(b => b.AantalKoffers == 0);

            WachtendeVluchten.Add(new Vlucht(vertrokkenVanuit, aantalKoffers));
        }

        public void WachtendeVluchtenNaarBand(Bagageband band)
        {

            var volgendeVlucht = WachtendeVluchten.FirstOrDefault();
            WachtendeVluchten.RemoveAt(0);

            band.HandelNieuweVluchtAf(volgendeVlucht);

        }

        public void OnNext(Bagageband band)
        {
            if (band.AantalKoffers == 0)
            {
                WachtendeVluchtenNaarBand(band);
            }
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
