using System;
using System.Collections.Generic;
using System.Text;

namespace P324_ConsoleApplication.Models
{
    class Seat
    {
        public byte Row;
        public byte Column;
        public bool IsFull;

        public Seat(byte row, byte column)
        {
            Row = row;
            Column = column;
            IsFull = false;
        }

        public override string ToString()
        {
            return $"Row: {Row}, Column: {Column}, Status: {(IsFull ? "Reserved" : "Empty")}";
        }
    }
}
