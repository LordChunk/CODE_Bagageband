using System.Collections.Generic;
using System.Linq;

namespace DPINT_Wk3_Observer.Model
{
    public class Aankomsthal
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
        }

        public void NieuweInkomendeVlucht(string vertrokkenVanuit, int aantalKoffers)
        {
            // TODO: Het proces moet straks automatisch gaan, dus als er lege banden zijn moet de vlucht niet in de wachtrij.
            // Dan moet de vlucht meteen naar die band.

            // Denk bijvoorbeeld aan: Bagageband legeBand = Bagagebanden.FirstOrDefault(b => b.AantalKoffers == 0);

            WachtendeVluchten.Add(new Vlucht(vertrokkenVanuit, aantalKoffers));
        }

        public void WachtendeVluchtenNaarBand()
        {
            while(Bagagebanden.Any(bb => bb.AantalKoffers == 0) && WachtendeVluchten.Any())
            {
                // TODO: Straks krijgen we een update van een bagageband. Dan hoeven we alleen maar te kijken of hij leeg is.
                // Als dat zo is kunnen we vrijwel de hele onderstaande code hergebruiken en hebben we geen while meer nodig.
                
                Bagageband legeBand = Bagagebanden.FirstOrDefault(bb => bb.AantalKoffers == 0);
                Vlucht volgendeVlucht = WachtendeVluchten.FirstOrDefault();
                WachtendeVluchten.RemoveAt(0);

                legeBand.HandelNieuweVluchtAf(volgendeVlucht);
            }
        }
    }
}
