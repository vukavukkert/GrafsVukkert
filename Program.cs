using MatrixGraphs;


Graph graph = new Graph();
graph.AddPoint('A');
graph.AddPoint('B');
graph.AddPoint('C');
graph.AddPoint('D');
graph.AddPoint('E');


graph.AddEdge(graph.GetPoint('A'), graph.GetPoint('B'), 1);
graph.AddEdge(graph.GetPoint('B'), graph.GetPoint('D'), 1);
graph.AddEdge(graph.GetPoint('C'), graph.GetPoint('E'), 1);
graph.AddEdge(graph.GetPoint('D'), graph.GetPoint('A'), 3);
graph.AddEdge(graph.GetPoint('E'), graph.GetPoint('D'), 2);
graph.AddEdge(graph.GetPoint('C'), graph.GetPoint('B'), 5);

graph.DrawMatrix();


graph.FindShortestPath(graph.GetPoint('A'), graph.GetPoint('C'));
// graph.FindPath(graph.GetPoint('A'), graph.GetPoint('C'));