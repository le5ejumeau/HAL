using HAL.Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.DAL
{
    /// <summary>
    /// classe abstraite, Doit être la base de tous les repositories. 
    /// </summary>
    public abstract class DataUtils
    {

        #region contructeur
        /// <summary>
        /// Créé un object DataUtils
        /// </summary>
        public DataUtils()
        {
            if (!IsExists) // première appel, on crée la base si elle n'existe pas.
                CreateDataBase();
        }

        #endregion



        //object connexion vers la base de données. Utilisé la propriété GetConnection pour accéder à l'élément. 
        private SQLiteConnection _connection;
        //Chemin vers la base de données. 
        protected const string datasource = @"Data Source=./data.s3db";
        /// <summary>
        /// Retourne une connexion instancié mais non ouverte vers la base de données. 
        /// </summary>
        protected SQLiteConnection GetConnection
        {
            get
            {
                if (_connection == null)
                    _connection = new SQLiteConnection(datasource);
                return _connection;
            }
        }

        /// <summary>
        /// rtourne false si la base de données n'existe pas. 
        /// </summary>
        private Boolean IsExists
        {
            get { return File.Exists("./data.s3db"); }
        }

        #region CreateDataBase
        /// <summary>
        /// Fonction appelé au premier chargement de l'application. 
        /// Création de la base de données. 
        /// </summary>
        private void CreateDataBase()
        {
            SQLiteConnection connexion = GetConnection;
            
                connexion.Open();
                SQLiteCommand command = connexion.CreateCommand();
                command.CommandText = @"CREATE TABLE MACHINE_MAC
                                        (
                                            MAC_ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                                            MAC_IP TEXT,
                                            MAC_NAME TEXT
                                        )";
                command.ExecuteNonQuery();
                connexion.Close();
            
        }

        #endregion


    }
}
