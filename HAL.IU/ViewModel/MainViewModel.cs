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
        private Logs _logs;
        private Serveurs _serveurs;

        public MainViewModel()
        {
            ChargementDesLogs();
            ChargementDesModulesClients();
        }

        private void ChargementDesModulesClients()
        {
            //Chargement des modules clients
            ServeurRepository serveurRepo = new ServeurRepository();
            serveurRepo.LoadAll(out _serveurs);
            Serveurs = new ObservableCollection<Serveur>(_serveurs);
            SelectedServeur = Serveurs.FirstOrDefault();
            _logs.Add(LogStat.Info, "Chargement des modules clients terminé.");
        }

        private void ChargementDesLogs()
        {
            //Chargement des logs
            LogRepository logRepository = new LogRepository();

            logRepository.LoadAll(out _logs, DateTime.Now.AddDays(-1), DateTime.Now);
            _logs.EAddLog += logs_EAddLog;
            Logs = new ObservableCollection<Log>(_logs);
            _logs.Add(LogStat.Info, "Initialisation des logs terminé.");
        }

        private void logs_EAddLog(Log obj)
        {
            Logs.Add(obj);
        }

        public ObservableCollection<Serveur> Serveurs { get; set; }


        public ObservableCollection<Log> Logs { get; set; }

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
