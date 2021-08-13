using ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IWCFProductService> channelfactory = new ChannelFactory<IWCFProductService>("ProductServiceEndPoint");

            IWCFProductService proxy = channelfactory.CreateChannel();

            Console.WriteLine("Enter go to get data from server");
            string input = Console.ReadLine();
            if (input == "go")
            {
                //calls ther server
                List<string> products = proxy.ListProducts();

                foreach (var p in products)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine("Enter a product to get info about");
                string pNumber = Console.ReadLine();
                ProductData data = proxy.GetProduct(pNumber);

                Console.WriteLine(data.Color);
                Console.WriteLine(data.Name );
                Console.WriteLine(data.ProductNumber);
                Console.WriteLine(data.ListPrice);

                Console.ReadLine();
            }
            
        
        
        }

    }
}
