using DPINT_Wk3_Observer.Model;
using GalaSoft.MvvmLight;

namespace DPINT_Wk3_Observer.Presentation.ViewModel
{
    public class VluchtViewModel : ViewModelBase
    {
        private string _vertrokkenVanuit;
        public string VertrokkenVanuit
        {
            get { return _vertrokkenVanuit; }
            set { _vertrokkenVanuit = value; RaisePropertyChanged("VertrokkenVanuit"); }
        }

        private int _aantalKoffers;
        public int AantalKoffers
        {
            get { return _aantalKoffers; }
            set { _aantalKoffers = value; RaisePropertyChanged("AantalKoffers"); }
        }

        public VluchtViewModel(Vlucht vlucht)
        {
            Update(vlucht);
            // TODO: Vlucht is straks observable, kunnen we daar niet op abonneren?
        }

        public void Update(Vlucht vlucht)
        {
            // TODO: Dit mag natuurlijk naar de OnNext methode toe.
            VertrokkenVanuit = vlucht.VertrokkenVanuit;
            AantalKoffers = vlucht.AantalKoffers;
        }
    }
}
