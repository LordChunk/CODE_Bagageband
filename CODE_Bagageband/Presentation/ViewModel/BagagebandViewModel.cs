using System;
using DPINT_Wk3_Observer.Model;
using GalaSoft.MvvmLight;

namespace DPINT_Wk3_Observer.Presentation.ViewModel
{
    public class BagagebandViewModel : ViewModelBase, IObserver<Bagageband>
    {
        private string _vluchtVertrokkenVanuit;
        public string VluchtVertrokkenVanuit
        {
            get { return _vluchtVertrokkenVanuit; }
            set { _vluchtVertrokkenVanuit = value; RaisePropertyChanged("VluchtVertrokkenVanuit"); }
        }

        private int _aantalKoffers;
        public int AantalKoffers
        {
            get { return _aantalKoffers; }
            set { _aantalKoffers = value; RaisePropertyChanged("AantalKoffers"); }
        }

        private string _naam;
        public string Naam
        {
            get { return _naam; }
            set { _naam = value; RaisePropertyChanged("Naam"); }
        }

        public BagagebandViewModel(Bagageband band)
        {
            Update(band);
            band.Subscribe(this);
        }

        public void Update(Bagageband value)
        {
            VluchtVertrokkenVanuit = value.VluchtVertrokkenVanuit;
            AantalKoffers = value.AantalKoffers;
            Naam = value.Naam;
        }

        /// <summary>
        /// Deze gaan we niet gebruiken
        /// </summary>
        public void OnCompleted() {}
        /// <summary>
        /// Deze gaan we niet gebruiken
        /// </summary>
        /// <param name="error"></param>
        public void OnError(Exception error) {}

        /// <summary>
        /// Als er een update is wordt deze aangeroepen, je krijgt hier heel het object
        /// </summary>
        /// <param name="value"></param>
        public void OnNext(Bagageband value) => Update(value);
    }
}
