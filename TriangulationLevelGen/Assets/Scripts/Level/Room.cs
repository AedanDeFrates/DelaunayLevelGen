using UnityEngine;

public class Room
{
    public enum Grid { FLOOR, WALL, EMPTY };

    public Grid[,] layout;
    private int width;
    private int height;
    public Vector2 center;

    public Vector2Int pos;

    public Room(int width, int height)
    {
        this.width = width;
        this.height = height;

        pos = new Vector2Int(0, 0);

        layout = new Grid[width, height];

        InitializeLayout();
    }

    private void InitializeLayout()
    {
        for (int i = 0; i < layout.GetLength(0); i++)
        {
            for (int j = 0; j < layout.GetLength(1); j++)
            {
                if (i == 0 || i == layout.GetLength(0) - 1 || j == 0 || j == layout.GetLength(1) - 1)
                {
                  layout[i,j] = Grid.WALL;
                }
                else
                {
                    layout[i,j] = Grid.FLOOR;
                }
            }
        }
    }
    public bool IsOverlapping(Room otherRoom)
    {
        // Simple AABB overlap check
        return !(pos.x + width <= otherRoom.pos.x ||
                 pos.x >= otherRoom.pos.x + otherRoom.width ||
                 pos.y + height <= otherRoom.pos.y ||
                 pos.y >= otherRoom.pos.y + otherRoom.height);
    }
    public void MoveRoom()
    {   
        pos = new Vector2Int(Random.Range(-200, 200), Random.Range(-200, 200));
        center = new Vector2(pos.x + width / 2f, pos.y + height / 2f);
    }
}