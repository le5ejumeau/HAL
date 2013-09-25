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
    public abstract class DataUtils
    {
        private SQLiteConnection _connection;
        protected const string datasource = @"Data Source=./data.s3db";

        protected SQLiteConnection GetConnection
        {
            get
            {
                if (_connection == null)
                    _connection = new SQLiteConnection(datasource);
                return _connection;
            }
        }

        public DataUtils()
        {
            if (!IsExists) // première appel, on crée la base si elle n'existe pas.
                CreateDataBase();
        }

        private Boolean IsExists
        {
            get { return File.Exists("./data.s3db"); }
        }

        #region CreateDataBase

        private void CreateDataBase()
        {
            using (SQLiteConnection connexion = GetConnection)
            {
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
        }

        #endregion


    }
}
