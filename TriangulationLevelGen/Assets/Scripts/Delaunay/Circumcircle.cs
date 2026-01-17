using UnityEngine;
using System;

public class Circumcircle
{
    private Node a;
    private Node b;
    private Node c;

    private float determinate;
    private float Ux;
    private float Uy;
    public Vector2 center;
    public float radius;

    public Circumcircle(Triangle triangle)
    {
        this.a = triangle.a;
        this.b = triangle.b;
        this.c = triangle.c;

        ComputeDeterminate();
        ComputeUxUy();
    }

    private void ComputeDeterminate()
    {
        float d = 2f * (
            a.pos.x * (b.pos.y - c.pos.y) + 
            b.pos.x * (c.pos.y - a.pos.y) + 
            c.pos.x * (a.pos.y - b.pos.y)
        );
        
        if (Math.Abs(d) < 1e-6f)
        {
            return;
        }
        determinate = d;
        return;
    }
    private void ComputeUxUy()
    {
        float a2 = a.pos.sqrMagnitude;
        float b2 = b.pos.sqrMagnitude;
        float c2 = c.pos.sqrMagnitude;

        Ux = (a2 * (b.pos.y - c.pos.y) + b2 * (c.pos.y - a.pos.y) + c2 * (a.pos.y - b.pos.y)) / determinate;
        Uy = (a2 * (c.pos.x - b.pos.x) + b2 * (a.pos.x - c.pos.x) + c2 * (b.pos.x - a.pos.x)) / determinate;
        center = new Vector2(Ux, Uy);
        radius = Vector2.Distance(center, a.pos);
    }

    public bool IsPointInside(Vector2 point)
    {
        float dist = Vector2.Distance(center, point);
        return dist < radius;
    }
}