using Microsoft.Owin.Hosting;
using System;

namespace CardsGameConfigService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12348"))
            {
                Console.WriteLine("Cards Game Config Service is running.");

                Console.WriteLine("Press any key to shutdown the server.");
                Console.ReadLine();
            }
        }
    }
}
