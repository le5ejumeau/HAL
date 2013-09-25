using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAL.Library;
using HAL.Library.Voice;
using System.ServiceModel;
using HAL.ServiceWeb;
using System.ServiceModel.Description;
using HAL.DAL;
using HAL.Library.DomainModel;

namespace HAL.Test
{
    class Program
    {

        private static Service1 s = new Service1();
        
        static void Main(string[] args)
        {

            //ServeurRepository b = new ServeurRepository();
            //Serveurs serveurs = new Serveurs();
            //serveurs.Add(new Serveur("192.168.1.5"));
            //serveurs.Add(new Serveur("192.168.1.10"));
            //b.Save(serveurs);

            //b.LoadAll(out serveurs);
          
            



            ////Creating a new ServiceHost instance with two base addresses: one for the http and second for the net.tcp
            //using (ServiceHost sh = new ServiceHost(s, new Uri("http://192.168.1.28:9009/Service"), new Uri("net.tcp://127.0.0.1:9010/Service")))
            //{
            //    //Adding the endpoints to the ServiceHost
            //    sh.AddServiceEndpoint(typeof(IService1), new NetTcpBinding(SecurityMode.None), "");
            //    sh.AddServiceEndpoint(typeof(IService1), new BasicHttpBinding(), "");

            //    //Creating a new Service Behavior
            //    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            //    smb.HttpGetEnabled = true;
            //    sh.Description.Behaviors.Add(smb);
            //    s.EDataString += s_EDataString;
            //    // Opening the ServiceHost for incoming connections
            //    sh.Open();
                
            //    System.Console.WriteLine("Waiting for connections...");

            //    while (true)
            //    {
            //        Console.ReadLine();
            //    }

            //    //Close opened ServiceHost object
            //    sh.Close();
            //}


            //VoiceSynthesis v = new VoiceSynthesis();
            //v.SetVoice("ScanSoft Virginie_Dri40_16kHz");
            //foreach (var item in v.GetVoices())
            //{

            //}
          

            //SpeechRecognition s = new SpeechRecognition();
            //s.Recognition(new List<string>(new String []{"Test"}));

          

            //v.Speak("bonjour ceci est un test", VoiceSynthesisType.Slow);
            //v.Speak("bonjour ceci est un test", VoiceSynthesisType.Angry);
            //v.Speak("bonjour ceci est un test", VoiceSynthesisType.Sad);
            //v.Speak("bonjour ceci est un test", VoiceSynthesisType.Normal);
        }

        static void s_EDataString(string arg1, string arg2)
        {
            Console.Write("SUPER SUPER : " + arg1.ToString());
        }

        
    }
}
