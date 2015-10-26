using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Mootit.Users.Service.Host
{
    class Program
    {
        private static ServiceHost accountsHost;

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing service: Users Accounts");

            try
            {
                accountsHost = new ServiceHost(typeof(Accounts));
                accountsHost.Open();

                Console.WriteLine("Running on: {0}", accountsHost.BaseAddresses.FirstOrDefault());
                Console.WriteLine("\nPress any key to stop the service.");

                Console.ReadKey();

                accountsHost.Close();
            }
            finally
            {
                if (accountsHost != null)
                    accountsHost = null;
            }
        }
    }
}
