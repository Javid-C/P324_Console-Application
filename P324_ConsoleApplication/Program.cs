using P324_ConsoleApplication.Enum;
using P324_ConsoleApplication.Services;
using System;

namespace P324_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cinema application");
            int selection;
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("1. Create Hall");
                Console.WriteLine("2. Edit Hall");
                Console.WriteLine("3. Show halls");
                Console.WriteLine("4. Show seats by hall no");
                Console.WriteLine("5. Reservation");
                Console.WriteLine("0. Exit");
                bool result = int.TryParse(Console.ReadLine(), out selection);
                Console.Clear();

                    switch (selection)
                    {
                        case 1:
                            MenuServices.CreateHallMenu();
                            break;
                        case 2:
                            MenuServices.EditHallMenu();
                            break;
                        case 3:
                            MenuServices.ShowHallsMenu();
                            break;
                        case 4:
                            MenuServices.ShowAllSeatsByHall();
                            break;
                        case 5:
                            MenuServices.ReservationMenu();
                            break;
                        default:
                            Console.WriteLine("Something went wrong");
                            break;
                }
            } while (selection != 0);
        }
    }
}
