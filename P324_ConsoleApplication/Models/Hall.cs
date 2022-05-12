using P324_ConsoleApplication.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace P324_ConsoleApplication.Models
{
    class Hall
    {
        public string No;
        public Categories Category;
        public Seat[,] Seats;
        public static int count;

        static Hall()
        {
            count = 100;
        }

        public Hall(byte row, byte col, Categories category)
        {
            switch (category)
            {
                case Categories.Sci_Fi:
                    No = $"SF-" + count;
                    break;
                case Categories.Action:
                    No = $"A-" + count;
                    break;
                case Categories.Horror:
                    No = $"H-" + count;
                    break;
                case Categories.Comedy:
                    No = $"C-" + count;
                    break;
                case Categories.Mystery:
                    No = $"M-" + count;
                    break;
                case Categories.Thriller:
                    No = $"T-" + count;
                    break;
                default:
                    break;
            }
            count++;
            Category = category;
            Seats = new Seat[row, col];

            for (byte i = 0; i < row; i++)
            {
                for (byte j = 0; j < col;  j++)
                {
                    Seat seat = new Seat((byte)(i + 1),(byte)(j + 1));
                    Seats[i, j] = seat;
                }
            }
        }
        public override string ToString()
        {
            return $"Hall No: {No}, Category: {Category}";
        }
    }
}
