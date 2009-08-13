using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Markov
{
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
