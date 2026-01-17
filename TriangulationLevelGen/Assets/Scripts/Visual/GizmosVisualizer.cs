using UnityEngine;

[ExecuteAlways]
public class GizmosVisualizer : MonoBehaviour
{
    public LevelData levelData;
    public float nodeSize = 2f;
    void OnDrawGizmos()
    {
        if (levelData == null) return;

        // Draw room centers
        Gizmos.color = Color.red;
        foreach (Room room in levelData.rooms)
            Gizmos.DrawSphere(room.center, nodeSize);

        // Draw Delaunay triangles
        if (levelData.delaunay != null)
        {
            Gizmos.color = Color.green;
            foreach (Triangle tri in levelData.delaunay.triangles)
            {
                Gizmos.DrawLine(tri.a.pos, tri.b.pos);
                Gizmos.DrawLine(tri.b.pos, tri.c.pos);
                Gizmos.DrawLine(tri.c.pos, tri.a.pos);
            }
        }
    }
}
