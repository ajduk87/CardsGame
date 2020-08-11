using Microsoft.Owin.Hosting;
using System;

namespace CardsGameServerQuery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12347"))
            {
                Console.WriteLine("Cards Game Server Query is running.");

                Console.WriteLine("Repositories is creating... ");

                RepositoryFactory.Factory.Initialize(new RepositoryFactory.DbFactory(RepositoryFactory.Finder.FindRepositoryTypes("CardsGameServerQuery")));

                Console.WriteLine("Repositories was created... ");

                Console.WriteLine("Press any key to shutdown the server.");
                Console.ReadLine();
            }
        }
    }
}