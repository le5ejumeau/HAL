using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.Library.Voice
{
    public class TypeVoice
    {
        public TypeVoice(String name, String genre, String age)
        {
            this.Name = name;
            this.Genre = genre;
            this.Age = age;
        }

        public String Name { get; set; }
        public String Genre { get; set; }
        public String Age { get; set; }

    }
}
