using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Day1
{
    public static class DayOneFunctions
    {
        public static string DoNumberThing(string line)
        {
            var result = line;
            var indexes = new List<NumberIndex>();

            result.GetIndexesOf(indexes, "one", "1");
            result.GetIndexesOf(indexes, "two", "2");
            result.GetIndexesOf(indexes, "three", "3");
            result.GetIndexesOf(indexes, "four", "4");
            result.GetIndexesOf(indexes, "five", "5");
            result.GetIndexesOf(indexes, "six", "6");
            result.GetIndexesOf(indexes, "seven", "7");
            result.GetIndexesOf(indexes, "eight", "8");
            result.GetIndexesOf(indexes, "nine", "9");

            indexes = indexes.OrderBy(x => x.Index).ToList();

            for (var i = 0; i < indexes.Count; i++)
            {
                result = result.Insert(indexes[i].Index + i, indexes[i].Number);
            }

            return result;
        }

        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        public static void GetIndexesOf(this string str, List<NumberIndex> indexes, string numberText, string numberChar)
        {
            var idxs = str.AllIndexesOf(numberText);

            foreach (var idx in idxs)
            {
                indexes.Add(new NumberIndex() { Index = idx, Number = numberChar });
            }
        }
    }

    public class NumberIndex
    {
        public int Index { get; set; }

        public string Number { get; set; }
    }
}
