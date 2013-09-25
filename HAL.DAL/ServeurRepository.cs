using HAL.Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAL.DAL.Extentions;
using HAL.DAL.Utils;

namespace HAL.DAL
{
    public class ServeurRepository : DataUtils
    {
        public void Save(Serveurs serveurs)
        {
            SQLiteConnection connexion = GetConnection;
            connexion.Open();

            foreach (var serveur in serveurs)
            {
                SQLiteCommand command =
                connexion.CreateCommand(@"INSERT INTO MACHINE_MAC (MAC_IP, MAC_NAME) VALUES (@MAC_IP,@MAC_NAME);SELECT last_insert_rowid();",
                                        new SQLiteParameter("@MAC_IP", serveur.IP),
                                        new SQLiteParameter("@MAC_NAME", serveur.Name));
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    serveur.ID = reader.GetInt32(0);
                reader.Close();
            }

            connexion.Close();

        }

        public void LoadAll(out Serveurs serveurs)
        {
            serveurs = new Serveurs();
            SQLiteConnection connexion = GetConnection;

            connexion.Open();
            SQLiteCommand command =
                    connexion.CreateCommand(@"SELECT MAC_ID, MAC_IP, MAC_NAME FROM MACHINE_MAC;");
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                serveurs.Add(new Serveur(SqlConvertion.GetInt32(reader["MAC_ID"]),
                                        SqlConvertion.GetString(reader["MAC_IP"]),
                                        SqlConvertion.GetString(reader["MAC_NAME"])));
            reader.Close();
            connexion.Close();


        }


    }
}
