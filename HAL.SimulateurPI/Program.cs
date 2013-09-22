using HAL.SimulateurPI.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HAL.SimulateurPI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client())
            {
                proxy.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("net.tcp://localhost:9010/Service"));
                proxy.Endpoint.Binding = new NetTcpBinding();
                proxy.Endpoint.Contract.ContractType = typeof(IService1);
                Console.WriteLine("Net.TCP: 1 + 1 is " + proxy.GetSum(1, 1));
                proxy.Close();
            }

            using (ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client())
            {
                proxy.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("http://localhost:9009/Service"));
                proxy.Endpoint.Binding = new WSHttpBinding();
                proxy.Endpoint.Contract.ContractType = typeof(IService1);
                Console.WriteLine("HTTP: 2 + 2 is " + proxy.GetSum(2, 2));
                proxy.Close();
            }

            Console.ReadLine();
        }
    }
}
