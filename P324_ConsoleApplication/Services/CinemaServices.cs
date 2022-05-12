using P324_ConsoleApplication.Enum;
using P324_ConsoleApplication.Interfaces;
using P324_ConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P324_ConsoleApplication.Services
{
    class CinemaServices : ICinemaServices
    {
        List<Hall> _halls = new List<Hall>();
        public List<Hall> Halls => _halls;

        public string CreateHall(byte row, byte col, Categories category)
        {
            if (row <= 0 || col <= 0)
            {
                return "Please choose valid row or column value";
            }
            Hall hall = new Hall(row, col, category);

            if(Halls.Count == 0)
            {
                _halls.Add(hall);
                return $"{hall.No} successfully created";
            }

            foreach (Hall existedHall in Halls)
            {
                if (hall.No.ToLower().Trim() != existedHall.No.ToLower().Trim())
                {
                    _halls.Add(hall);
                    return $"{hall.No} successfully created";
                }
            }
            return "Hall can not create";
        }

        public void EditHall(string oldNo,string newNo)
        {
            if (FindHall(newNo) == null)
            {
                Hall hall = FindHall(oldNo);

                if (hall != null)
                {
                    hall.No = newNo.ToUpper().Trim();
                    Console.WriteLine($"{hall.No} successfully edited");
                }
                else
                {
                    Console.WriteLine($"There is no hall => {oldNo.ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine($"There is hall => {newNo.ToUpper()}");
            }     
        }

        public Hall FindHall(string no)
        {
            foreach (Hall hall in Halls)
            {
                if (hall.No.ToLower().Trim() == no.ToLower().Trim())
                {
                    return hall;
                }
            }
            return null;
        }        

        public void ShowAllHalls()
        {
            if(Halls.Count > 0)
            {
                foreach (Hall hall in Halls)
                {
                    Console.WriteLine(hall);
                }
            }
            else
            {
                Console.WriteLine("There is no hall");
            }
        }

        public void ShowAllSeatsByHall(string no)
        {
            Hall hall = FindHall(no);
            if(hall != null)
            {
                foreach (Seat seat in hall.Seats)
                {
                    Console.WriteLine(seat);
                }
            }
            else
            {
                Console.WriteLine("Please enter valid hall no");
            }
        }

        public void Reserve(string no, byte row, byte col)
        {
            if(string.IsNullOrEmpty(no) || string.IsNullOrWhiteSpace(no))
            {
                Console.WriteLine("Please enter valid hall no");
                return;
            }

            if(row<=0 || col <= 0)
            {
                Console.WriteLine("Please enter valid row or column value");
                return;
            }

            Hall hall = FindHall(no);

            if(hall == null)
            {
                Console.WriteLine($"There is no hall => {no.ToUpper()}");
                return;
            }

            if(row > hall.Seats.GetLength(0) || col> hall.Seats.GetLength(1))
            {
                Console.WriteLine("Please enter valid hall no");
                return;
            }

            if (!hall.Seats[row-1, col-1].IsFull)
            {
                hall.Seats[row-1, col-1].IsFull = true;
                Console.WriteLine("This seat has been succesfully reserved");
            }
            else
            {
                Console.WriteLine("This seat has been already reserved\nPlease choose another seat");
                ShowAllSeatsByHall(no);
            }

        }
    }
}
