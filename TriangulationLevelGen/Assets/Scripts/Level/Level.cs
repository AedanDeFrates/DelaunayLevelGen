using UnityEngine;
using System.Collections.Generic;

public class Level
{
    public List<Room> rooms;
    private int roomCount;
    public Level(int roomCount)
    {
        rooms = new List<Room>();

        this.roomCount = roomCount;
        for (int i = 0; i < roomCount; i++)
        {
            CreateRoom();
        }
        foreach (Room room in rooms)
        {
            bool overlapping;
            do
            {
                overlapping = false;
                room.MoveRoom();
                foreach (Room otherRoom in rooms)
                {
                    if (room != otherRoom && room.IsOverlapping(otherRoom))
                    {
                        overlapping = true;
                        break;
                    }
                }
            } while (overlapping);
        }
    }

    public void CreateRoom()
    {
        Room newRoom = new Room(Random.Range(10, 20), Random.Range(10, 20));
        rooms.Add(newRoom);
    }
}
