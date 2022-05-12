using P324_ConsoleApplication.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace P324_ConsoleApplication.Services
{
    static class MenuServices
    {
        public static CinemaServices cinemaServices = new CinemaServices();
        public static void CreateHallMenu()
        {
            Console.WriteLine("Please enter row");
            byte row;
            bool rowResult = byte.TryParse(Console.ReadLine(), out row);
            Console.WriteLine("Please enter column");
            byte col;
            bool colResult = byte.TryParse(Console.ReadLine(), out col);
            if (rowResult && colResult)
            {
                foreach (var item in System.Enum.GetValues(typeof(Categories)))
                {
                    Console.WriteLine($"{(int)item}. {item}");
                }
                object category;
                bool categoryResult = System.Enum.TryParse(typeof(Categories), Console.ReadLine(), out category);
                if (categoryResult)
                {

                    Console.WriteLine(cinemaServices.CreateHall(row, col, (Categories)category));
                }
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public static void EditHallMenu()
        {
            Console.WriteLine("Please enter hall no");
            string no = Console.ReadLine();

            Console.WriteLine("Please enter new hall no");
            string newNo = Console.ReadLine();

            cinemaServices.EditHall(no, newNo);
        }

        public static void ShowHallsMenu()
        {
            cinemaServices.ShowAllHalls();
        }

        public static void ShowAllSeatsByHall()
        {
            Console.WriteLine("Please enter hall no");
            string no = Console.ReadLine();

            cinemaServices.ShowAllSeatsByHall(no);
        }

        public static void ReservationMenu()
        {
            Console.WriteLine("Please enter hall no");
            string no = Console.ReadLine();

            Console.WriteLine("Please enter row");
            byte row;
            bool rowResult = byte.TryParse(Console.ReadLine(), out row);

            Console.WriteLine("Please enter column");
            byte col;
            bool colResult = byte.TryParse(Console.ReadLine(), out col);
            if(rowResult && colResult)
            {
                cinemaServices.Reserve(no,row,col);
            }
        }
    }
}
