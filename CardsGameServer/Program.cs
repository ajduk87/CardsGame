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

                Console.WriteLine("Press any key to shutdown the server.");
                Console.ReadLine();
            }
        }
    }
}
