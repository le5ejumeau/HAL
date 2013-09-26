using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.Library.Service
{
    public class MainInfosPI
    {
        public String IP { get; set; }
        public String Name { get; set; }
        public String Temperature { get; set; }

        public MainInfosPI(String xmlFile)
        {

        }
    }
}
