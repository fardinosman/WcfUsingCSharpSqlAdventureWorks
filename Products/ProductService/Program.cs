using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(WCFProductService)))
            {
                host.Open();
                Console.WriteLine("Server is Open");
                Console.WriteLine("<Press enter to close server>");
                Console.ReadLine();
            }
        }
    }
}
