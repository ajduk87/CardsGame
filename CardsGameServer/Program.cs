using System;
using Microsoft.Owin.Hosting;

namespace CardsGameServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12346"))
            {
                Console.WriteLine("Cards Game Server is running.");

                Console.WriteLine("Repositories is creating... ");

                RepositoryFactory.Factory.Initialize(new RepositoryFactory.DbFactory(RepositoryFactory.Finder.FindRepositoryTypes("CardsGameServer")));

                Console.WriteLine("Repositories was created... ");

                Console.WriteLine("Press any key to shutdown the server.");
                Console.ReadLine();
            }
        }
    }
}
