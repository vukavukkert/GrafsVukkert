using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixGraphs
{
    public class Edge
    {
        public List<Point> Points
        {
            get
            {
                return new List<Point> { P1, P2 };
            }
        }
        public Point? P1 { get; }
        public Point? P2 { get; }
        public int Weight { get; set; }
        public Edge(Point? p1 = null, Point? p2 = null, int weight = 0)
        {
            P1 = p1;
            P2 = p2;
            Weight = weight;
        }
        public byte Binary()
        {
            if (P1 == null || P2 == null) return 0;
            return 1;
        }
        public string Info()
        {
            return $"Rebro iz {P1} v {P2} s vesom {Weight}";
        }
    }
}