using System.Collections.Generic;

namespace Markov
{
    public class Chain<T>
    {
        Link<T> root = new Link<T>(default(T));
        private int length;

        public Chain(IEnumerable<T> input, int length)
        {
            this.length = length;
            root.Process(input, length);
        }

        public IEnumerable<T> Generate(int max)
        {
            foreach(var next in root.Generate(root.SelectRandomLink().Data,length, max))
            {
                yield return next.Data;
            }
        }

        public IEnumerable<T> Generate(T start, int max)
        {
            foreach (var next in root.Generate(start, length, max))
            {
                yield return next.Data;
            }
        }
    }
}
