using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixGraphs
{
    public class Graph
    {
        public List<Point> Points;
        public Edge[,] Edges;
        public Graph()
        {
            Points = new List<Point>();
        }
        public void AddPoint(char ch)
        {
            Point newPoint = new Point(ch);
            Points.Add(newPoint);
        }
        public Point GetPoint(char ch)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                if (Points[i].Name == ch) return Points[i];
            }
            return null;
        }
        public void CreateMatrix()
        {
            int n = Points.Count;
            Edge[,] _edges = new Edge[n, n]; //новый экземпляр матрицы каждый раз

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Edges == null || i > Edges.GetLength(0) || j > Edges.GetLength(1))
                    {
                        _edges[i, j] = new Edge();
                    }
                    else
                    {
                        _edges[i, j] = InsertOldData(i, j);
                    }
                }
            }
            Edges = _edges;
        }
        public Edge InsertOldData(int i, int j)
        {
            if (Edges[i, j].Binary() == 1) return Edges[i, j];
            return new Edge();
        }
        public void AddEdgeInMatrix(Edge edge)
        {
            for (int i = 0; i < Edges.GetLength(0); i++)
            {
                for (int j = 0; j < Edges.GetLength(1); j++)
                {
                    if (Points[i] == edge.P1 && Points[j] == edge.P2)
                    {
                        Edges[i, j] = edge;
                        Console.WriteLine($"i: {i}  j: {j} Binary: {Edges[i, j].Weight} Points: {edge.P1.Name}, {edge.P2.Name}");
                    }
                    if (Points[i] == edge.P2 && Points[j] == edge.P1)
                    {
                        Edges[i, j] = edge;

                    }
                }
            }

        }
        public void AddEdge(Point p1, Point p2, int weight)
        {
            Edge newEdge = new Edge(p1, p2, weight);
            p1.Edges.Add(newEdge);
            p2.Edges.Add(new Edge(p2, p1, weight));
            CreateMatrix();
            AddEdgeInMatrix(newEdge);

        }
        public void DrawMatrix()
        {
            if (Edges != null)
            {
                Console.Write("  ");
                for (int l = 0; l < Points.Count; l++)
                {
                    Console.Write(Points[l].Name + " ");
                }
                Console.WriteLine();
                for (int i = 0; i < Edges.GetLength(0); i++)
                {
                    Console.Write(Points[i].Name + " ");
                    for (int j = 0; j < Edges.GetLength(1); j++)
                    {
                        Console.Write(Edges[i, j].Weight + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void FindShortestPath(Point start, Point finish)
        {
            Dictionary<Point, int> distances = new Dictionary<Point, int>(); // Расстояния от начальной точки до остальных точек
            Dictionary<Point, Point> parents = new Dictionary<Point, Point>(); // Словарь для отслеживания родительских точек

            // Инициализация расстояний значением "бесконечность", кроме начальной точки, которая имеет расстояние 0
            foreach (var point in Points)
            {
                distances[point] = int.MaxValue;
            }
            distances[start] = 0;

            // Очередь с приоритетом для выбора точек с наименьшим расстоянием
            PriorityQueue<Point> queue = new PriorityQueue<Point>();

            queue.Enqueue(start, 0);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == finish)
                {
                    break;
                }

                foreach (var edge in current.Edges)
                {
                    Point neighbor = edge.P2;

                    int distance = distances[current] + edge.Weight;

                    if (distance < distances[neighbor])
                    {
                        distances[neighbor] = distance;
                        parents[neighbor] = current;
                        queue.Enqueue(neighbor, distance);
                    }
                }
            }

            if (!parents.ContainsKey(finish))
            {
                Console.WriteLine("Shortest path from " + start.Name + " to " + finish.Name + " not found.");
                return;
            }

            var shortestPath = new List<Point>();
            var node = finish;

            while (node != null)
            {
                shortestPath.Insert(0, node);
                node = parents.ContainsKey(node) ? parents[node] : null;
            }

            Console.Write("Shortest path from " + start.Name + " to " + finish.Name + ": ");
            foreach (var point in shortestPath)
            {
                Console.Write(point.Name + " ");
            }
            Console.WriteLine();
        }
    }
}