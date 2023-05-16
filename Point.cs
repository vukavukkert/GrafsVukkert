using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixGraphs
{
    public class Point
    {
        public char Name { get; }
        public List<Edge>? Edges;
        public Point(char name)
        {
            Name = name;
            Edges = new List<Edge>();
        }
    }
}