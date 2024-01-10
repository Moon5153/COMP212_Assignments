using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public static class Program
    {
        public static int numOfWords(this StringBuilder sb)
        {
            return sb.ToString().Split(' ').Length;
        }
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("This is a good book");
            Console.WriteLine($"Number of words in \"{sb}\" is {sb.numOfWords()}");
        }
    }
}
