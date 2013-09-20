using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAL.Library;
using HAL.Library.Voice;

namespace HAL.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            VoiceSynthesis v = new VoiceSynthesis();

            foreach (var item in v.GetVoices())
            {

            }

            v.Speak("bonjour ceci est un test");
        }
    }
}
