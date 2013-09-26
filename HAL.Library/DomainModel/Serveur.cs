using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.Library.DomainModel
{

    public class Serveurs : List<Serveur>
    {
        public void Save()
        {
            foreach (var item in this)
            {
                
            }
        }

       
    }

    public class Serveur
    {
        public Serveur(Int32 id, String ip, String name)
        {
            IP = ip;
            ID = id;
        }

        public Serveur(String ip)
        {
            IP = ip;
            ID = -1;
        }

        public Serveur(Int32 id, String ip)
        {
            IP = ip;
            ID = id;
        }

        public String IP { get; set; }

        public string Name { get; set; }

        public Int32 ID { get; set; }

        


    }
}
