using DiceGame.Scripts.DungeonThing.Rooms;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject[] roomPrefabs;
    [SerializeField] float distanceBetweenRooms;
    [SerializeField] int sizeX = 10;
    [SerializeField] int sizeZ = 10;
    float distancePast;
    Dictionary<Vector2Int, GameObject> rooms = new Dictionary<Vector2Int, GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distancePast = distanceBetweenRooms;
        for (int z = 0; z < sizeZ; z++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                GameObject room = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], transform);
                Vector3 roomPos = new Vector3(x * distanceBetweenRooms, transform.position.y, z * distanceBetweenRooms);
                room.transform.position = roomPos;
                rooms.Add(new Vector2Int(x, z), room);
            }
        }
        foreach(KeyValuePair<Vector2Int, GameObject> pair in rooms)
        {
            HandeRoomDoors(pair.Value.GetComponent<RoomValsUniversal>(), pair.Key.x, pair.Key.y);
        }
    }
    private void HandeRoomDoors(RoomValsUniversal roomVals, int x, int z)
    {
        Room ignore;
        roomVals.eastDoor.SetActive(!TryReturnRoomOnCoords(x + 1, z, out ignore));
        roomVals.northDoor.SetActive(!TryReturnRoomOnCoords(x, z + 1, out ignore));
        roomVals.westDoor.SetActive(!TryReturnRoomOnCoords(x - 1, z, out ignore));
        roomVals.southDoor.SetActive(!TryReturnRoomOnCoords(x, z - 1, out ignore));
    }
    internal bool TryReturnRoomOnCoords(int x, int z, out Room outRoom)
    {
        Room roomFound = null;
        if(rooms.TryGetValue(new Vector2Int(x, z), out GameObject outObject) && outObject.GetComponent<Room>())
        {
            roomFound = outObject.GetComponent<Room>();
            outRoom = roomFound;
            return true;
        }
        outRoom = roomFound;
        return false;
    }
    private void UpdateRoomPositions()
    {
        foreach(KeyValuePair<Vector2Int, GameObject> pairs in rooms)
        {
            Vector3 roomPos = new Vector3(pairs.Key.x * distanceBetweenRooms, transform.position.y, pairs.Key.y * distanceBetweenRooms);
            pairs.Value.transform.position = roomPos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (distanceBetweenRooms != distancePast)
        {
            UpdateRoomPositions();
        }
        distancePast = distanceBetweenRooms;
    }
}
