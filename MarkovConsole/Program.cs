using System;
using System.IO;
using Markov;

namespace MarkovConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(args[3]);
            var seed = input.Tokenize();
            var chain = new Chain<string>(seed, Convert.ToInt32(args[1]));
            chain.Generate(args[0], Convert.ToInt32(args[2])).ForEach(Console.Write);
        }
    }
}