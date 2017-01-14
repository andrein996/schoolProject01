using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laborator1.Domain;

namespace Lab10.domain
{
    public delegate bool filter<T>(T p);
    public class CompareByID : IComparer<Post>
    {
        public int Compare(Post x, Post y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
    public delegate int comparator<T>(T p1, T p2);
}
