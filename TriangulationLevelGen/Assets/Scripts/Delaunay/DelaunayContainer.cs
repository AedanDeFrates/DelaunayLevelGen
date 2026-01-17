using UnityEngine;
using System.Collections.Generic;

public class DelaunayContainer
{
    public List<Triangle> triangles;
    public List<Node> nodes;
    private Node superA = new Node(new Vector2(-500, -250));
    private Node superB = new Node(new Vector2(0f, 1000f));
    private Node superC = new Node(new Vector2(500f, -250f));

    public Triangle superTriangle;

    public DelaunayContainer(Level level)
    {
        triangles = new List<Triangle>();
        superTriangle = new Triangle(superA, superB, superC);

        triangles.Add(superTriangle);

        nodes = new List<Node>();

        nodes.Add(superA);
        nodes.Add(superB);
        nodes.Add(superC);

        foreach(Room room in level.rooms)
        {
            nodes.Add(new Node(room.center));
        }
    }

    public void GenerateDelaunay()
    {
        foreach (Node node in nodes)
        {
            List<Triangle> badTriangles = new List<Triangle>();
            foreach (Triangle triangle in triangles)
            {
                Circumcircle circumcircle = new Circumcircle(triangle);
                if (circumcircle.IsPointInside(node.pos))
                {
                    badTriangles.Add(triangle);
                    triangle.MarkAsBad();
                }
            }

            List<Edge> polygon = new List<Edge>();
            foreach (Triangle badTriangle in badTriangles)
            {
                Edge ab = new Edge(badTriangle.a, badTriangle.b);
                Edge bc = new Edge(badTriangle.b, badTriangle.c);
                Edge ca = new Edge(badTriangle.c, badTriangle.a);

                AddEdgeIfNotShared(polygon, ab);
                AddEdgeIfNotShared(polygon, bc);
                AddEdgeIfNotShared(polygon, ca);
            }

            triangles.RemoveAll(t => t.isBad);

            foreach (Edge edge in polygon)
            {
                Triangle newTriangle = new Triangle(edge.a, edge.b, node);
                triangles.Add(newTriangle);
            }
        }
    }
    private void AddEdgeIfNotShared(List<Edge> polygon, Edge edge)
    {
        if (polygon.Contains(edge)) polygon.Remove(edge); // internal edge, remove
        else polygon.Add(edge);    // boundary edge, keep
    }
}