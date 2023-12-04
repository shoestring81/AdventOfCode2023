using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Day3Number
    {
        public string NumberString { get; set; }

        public int Number => int.Parse(NumberString);

        public int Line { get; set; }

        public int StartIndex { get; set; }

        public int EndIndex => StartIndex + NumberString.Length - 1;
    }

    public class Day3Symbol
    {
        public int Line { get; set; }

        public int Index { get; set; }

        public char Symbol { get; set; }
    }
}
