using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace Mootit.Pizzeria.Service.Host
{
    class Program
    {
        private static ServiceHost storeHost;

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing service: Pizzeria Store");

            try
            {
                storeHost = new ServiceHost(typeof(Store));
                storeHost.Open();

                Console.WriteLine("Running on: {0}", storeHost.BaseAddresses.FirstOrDefault());
                Console.WriteLine("\nPress any key to stop the service.");

                Console.ReadKey();

                storeHost.Close();
            }
            finally
            {
                if (storeHost != null)
                    storeHost = null;
            }

        }
    }
}
