using UnityEngine;

public class Triangle
{
    public bool isBad = false;
    public Node a;
    public Node b;
    public Node c;

    public Triangle(Node a, Node b, Node c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void MarkAsBad()
    {
        isBad = true;
    }
}
