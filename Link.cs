using System;
using System.Collections.Generic;
using System.Linq;

namespace Markov
{
    internal class Link<T>
    {
        static readonly Random random = new Random();

        private Dictionary<T, Link<T>> links;

        internal int Occurances { get; private set; }
        internal T Data { get; private set; }
        internal int ChildOccurances
        {
            get
            {
                return links.Sum(link => link.Value.Occurances);
            }
        }

        internal Link(T data)
        {
            Data = data;
            Occurances = 0;
            links = new Dictionary<T, Link<T>>();
        }

        internal void Process(IEnumerable<T> input, int length)
        {
            var window = new Queue<T>(length);

            input.ForEach(part =>
            {
                if (window.Count == length) window.Dequeue();
                window.Enqueue(part);

                ProcessWindow(window);
            });
        }

        internal IEnumerable<Link<T>> Generate(T start, int length, int max)
        {
            var window = new Queue<T>(length);
            window.Enqueue(start);
            for (Link<T> link = Find(window); link != null && max != 0; link = Find(window), max--)
            {
                var next = link.SelectRandomLink();
                yield return link;

                if (window.Count == length - 1)
                    window.Dequeue();
                if (next != null)
                    window.Enqueue(next.Data);
            }
        }

        internal Link<T> SelectRandomLink()
        {
            Link<T> link = null;
            int rnd = random.Next(1, ChildOccurances + 1);

            int total = 0;
            foreach (var child in links.Values)
            {
                total += child.Occurances;
                if (total >= rnd)
                {
                    link = child;
                    break;
                }
            }

            return link;
        }

        private Link<T> Process(T part)
        {
            Link<T> link = Find(part);
            if(link == null)
            {
                link = new Link<T>(part);
                links.Add(part, link);
            }
            link.Seen();
            return link;
        }

        private void Seen()
        {
            Occurances++;
        }

        private void ProcessWindow(Queue<T> window)
        {
            Link<T> link = this;

            window.ForEach(part =>
            {
                link = link.Process(part);
            });
        }

        private Link<T> Find(T follower)
        {
            Link<T> link = null;
            if (links.ContainsKey(follower)) link = links[follower];
            return link;
        }

        private Link<T> Find(Queue<T> window)
        {
            Link<T> link = this;
            foreach(T part in window)
            {
                link = link.Find(part);
                if(link == null)
                    break;
            }
            return link;
        }
    }
}