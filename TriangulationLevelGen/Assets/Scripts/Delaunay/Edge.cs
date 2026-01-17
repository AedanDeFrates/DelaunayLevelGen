using UnityEngine;
using System.Collections.Generic;

public class Edge
{
     public Node a;
    public Node b;

    public Edge(Node a, Node b)
    {
        this.a = a;
        this.b = b;
    }

    // Treat Edge(a,b) same as Edge(b,a)
    public override bool Equals(object obj)
    {
        if (!(obj is Edge)) return false;
        Edge other = (Edge)obj;
        return (a == other.a && b == other.b) || (a == other.b && b == other.a);
    }

    public override int GetHashCode()
    {
        // Order-independent hash
        int hash1 = a.GetHashCode() ^ b.GetHashCode();
        int hash2 = b.GetHashCode() ^ a.GetHashCode();
        return hash1 ^ hash2;
    }
}
