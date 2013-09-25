﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.Library.DomainModel
{

    public class Serveurs : List<Serveur>
    {
          
    }

    public class Serveur
    {

        public Serveur(Int32 id, String ip)
        {
            IP = ip;
            ID = id;
        }

        public Serveur(Int32 id, String ip, String name)
        {
            IP = ip;
            ID = id;
            Name = name;
        }

        public Serveur(String ip)
        {
            IP = ip;
            ID = -1;
        }

        public String IP { get; set; }

        public string Name { get; set; }

        public Int32 ID { get; set; }

        


    }
}
