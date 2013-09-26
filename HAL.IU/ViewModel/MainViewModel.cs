using HAL.DAL;
using HAL.Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.IU.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public MainViewModel()
        {
            ChargementDesModulesClients();
        }

        private void ChargementDesModulesClients()
        {
            //Chargement des modules clients
            ServeurRepository serveurRepo = new ServeurRepository();
            Serveurs serveurs;
            serveurRepo.LoadAll(out serveurs);
            Serveurs = new ObservableCollection<Serveur>(serveurs);
            SelectedServeur = Serveurs.FirstOrDefault();
        }

        public ObservableCollection<Serveur> Serveurs { get; set; }

        private Serveur _selectedServeur;
        public Serveur SelectedServeur
        {
            get { return _selectedServeur; }
            set
            {
                _selectedServeur = value;
                OnPropertyChanged("SelectedServeur");
            }
        }
    }
}
