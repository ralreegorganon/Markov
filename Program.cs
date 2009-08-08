using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Markov
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"c:\users\jj\desktop\architecture.txt");
            var seed = input.Tokenize();
            var chain = new Chain<string>(seed, 3);
            chain.Generate("I", 2000).ForEach(Console.Write);
        }
    }

    public static class JExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source) action(element);
            return source;
        }

        public static IEnumerable<string> Tokenize(this string source)
        {
            var regex = new Regex(@"(\W+)");
            return new List<string>(regex.Split(source));
        }
    }
}
