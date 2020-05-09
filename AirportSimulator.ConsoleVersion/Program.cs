using ProjectLibrary;
using System;

namespace AirportSimulator.ConsoleVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationManager applicationManager = new ApplicationManager();
            Console.WriteLine("Press any key to start the application");
            Console.ReadKey();
            applicationManager.RunApplication();
        }
    }
}
