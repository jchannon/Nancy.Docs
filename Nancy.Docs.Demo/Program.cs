using System;
using Nancy.Hosting.Self;

namespace Nancy.Docs.Demo
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Listening on http://localhost:1234");
                Console.ReadLine();
            }
        }
    }
}
