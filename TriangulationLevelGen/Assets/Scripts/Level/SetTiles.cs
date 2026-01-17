using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class SetTiles : MonoBehaviour
{
    public LevelData levelData;
    public Level level;
    public DelaunayContainer delaunay;

    public Tilemap floorTilemap;
    public Tilemap wallTilemap;
    public Tile wall;
    public Tile floor;

    public int tileCount = default;

    public void GenerateLevel()
    {
        level = new Level(20);
        
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();

        tileCount = 0;

        foreach(Room room in level.rooms)
        {
            CycleThroughRooms(room);
        }

        delaunay = new DelaunayContainer(level);
        delaunay.GenerateDelaunay();

        levelData.delaunay = delaunay;
        levelData.rooms = level.rooms;

        #if UNITY_EDITOR
        UnityEditor.SceneView.RepaintAll();
        #endif
    }
    private void CycleThroughRooms(Room room)
    {
        Vector3Int initialTile = new Vector3Int((int)room.pos.x, (int)room.pos.y, 0);

        for (int i = 0; i < room.layout.GetLength(0); i++)
        {
            for (int j = 0; j < room.layout.GetLength(1); j++)
            {
                Vector3Int tilePlacer = new Vector3Int((int)initialTile.x + i, (int)initialTile.y + j, 0);

                if (room.layout[i,j] == Room.Grid.FLOOR)
                {
                    floorTilemap.SetTile(tilePlacer, floor);
                    tileCount++;
                }
                else if (room.layout[i,j] == Room.Grid.WALL)
                {
                    wallTilemap.SetTile(tilePlacer, wall);
                }
            }
        }
    }
}