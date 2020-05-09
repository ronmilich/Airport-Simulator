using ProjectLibrary;
using System;
using System.Threading;

namespace AirportSimulator.ConsoleVersion
{
    /// <summary>
    /// Represent the Flight Simulaitor application class.
    /// </summary>
    class ApplicationManager
    {
        Simulator simulator = Simulator.Instance;

        /// <summary>
        /// Run the application.
        /// </summary>
        public void RunApplication()
        {
            Console.WriteLine("\nAirport Simulator Application - Console Version");
            Console.WriteLine("-----------------------------------------------");
            Configuration.FlightsMovementSpeed = 1500;

            while (true)
            {
                int option = AppMenu();

                if (option == 1)
                    StartSimulation();
                else if (option == 2)
                    ResetSimulation();
                else if (option == 3)
                    break;
            }
        }

        /// <summary>
        /// Reset the simulation flights and stations.
        /// </summary>
        private void ResetSimulation()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            simulator.Removeflights();
            Console.WriteLine("Reseting simulation...");
            Thread.Sleep(3000);
            Console.WriteLine("All the flights deleted and stations returned to their initial state...\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Start the simulator.
        /// </summary>
        private void StartSimulation()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            simulator.LoadAssetsCurrentState();
            Console.WriteLine("TO STOP THE SIMULATOR JUST PRESS ENTER.");
            Console.WriteLine("Loading Stations...");
            Thread.Sleep(500);
            Console.WriteLine("Loadding Flights...\n");
            Thread.Sleep(2500);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            simulator.StartSimulator(5000);
            Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            simulator.StopSimulator();
            Console.WriteLine("Saving Flights...");
            Thread.Sleep(300);
            Console.WriteLine("Exit Simulation...\n");
            Thread.Sleep(2500);
            Console.ResetColor();
        }

        /// <summary>
        /// Menu for activating the application functionallity.
        /// </summary>
        /// <returns>Returns a number that represent a function in the application.</returns>
        private int AppMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Simulation Option Menu - Choose One of the Options :");
                Console.WriteLine("1) Start Simulation\n" + "2) Reset Simulation\n" + "3) Exit Application");

                Console.ResetColor();

                string menuItemNumber = Console.ReadLine();
                if (menuItemNumber == "1" ||
                    menuItemNumber == "2" ||
                    menuItemNumber == "3")
                {
                    return int.Parse(menuItemNumber);
                }
                else
                {
                    Console.WriteLine("This character is not valid, please choose a number from 1-4.\n");
                }
            }
        }
    }
}
