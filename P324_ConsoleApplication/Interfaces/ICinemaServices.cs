using P324_ConsoleApplication.Enum;
using P324_ConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P324_ConsoleApplication.Interfaces
{
    interface ICinemaServices
    {
        public List<Hall> Halls { get; }
        string CreateHall(byte row, byte col, Categories category);
        void EditHall(string oldNo, string newNo);
        void ShowAllHalls();
        void ShowAllSeatsByHall(string no);
        void Reserve(string no, byte row, byte col);
    }
}
