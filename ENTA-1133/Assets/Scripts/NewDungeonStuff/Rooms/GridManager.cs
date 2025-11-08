using DiceGame.Scripts.DungeonThing.Rooms;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject[] roomPrefabs;
    [SerializeField] GameObject enterRoomPrefab;
    [SerializeField] GameObject exitRoomPrefab;
    //[SerializeField] GameObject player;
    [SerializeField] float distanceBetweenRooms;
    [SerializeField] int sizeX = 10;
    [SerializeField] int sizeZ = 10;
    internal Vector3 enterRoomPos { get; private set; }
    float distancePast;
    Dictionary<Vector2Int, GameObject> rooms = new Dictionary<Vector2Int, GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    internal void GenerateGrid()
    {
        distancePast = distanceBetweenRooms;
        for (int z = 0; z < sizeZ; z++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                CreateRoomAt(z, x);
            }
        }
        foreach(KeyValuePair<Vector2Int, GameObject> pair in rooms)
        {
            HandleRoomDoors(pair.Key.x, pair.Key.y);
        }
        int enterRandomX = Random.Range(0, sizeX - 1);
        int enterRandomZ = Random.Range(0, sizeZ - 1);
        Debug.Log($"{enterRandomX}, {enterRandomZ}");
        enterRoomPos = CreateRoomAt(enterRandomX, enterRandomZ, enterRoomPrefab).transform.position;
        int exitRandomX = Random.Range(0, sizeX - 1);
        int exitRandomZ = Random.Range(0, sizeZ - 1);
        while(exitRandomX == enterRandomX)
        {
            exitRandomX = Random.Range(0, sizeX - 1);
        }
        while(exitRandomZ == enterRandomZ)
        {
            exitRandomZ = Random.Range(0, sizeZ - 1);
        }
        //player.transform.position = new Vector3(randomX * distanceBetweenRooms + transform.position.x, 1 + transform.position.y, randomZ * distanceBetweenRooms + transform.position.z);
    }

    private GameObject CreateRoomAt(int z, int x, GameObject roomPrefab = null)
    {
        GameObject room;
        if (roomPrefab == null)
        {
            room = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], transform);
        }
        else
        {
            room = Instantiate(roomPrefab, transform);
        }
        Vector3 roomPos = new Vector3(x * distanceBetweenRooms, transform.position.y, z * distanceBetweenRooms);
        room.transform.position = roomPos;
        if (rooms.TryGetValue(new Vector2Int(x, z), out GameObject outObject))
        {
            Destroy(outObject);
            rooms[new Vector2Int(x, z)] = room;
            HandleRoomDoors(x, z);
        }
        else
        {
            rooms.Add(new Vector2Int(x, z), room);
        }
        return room;
    }

    private void HandleRoomDoors(int x, int z)
    {
        Room ignore;
        if(!rooms.TryGetValue(new Vector2Int(x, z), out GameObject outObject))
        {
            return;
        }
        RoomValsUniversal roomVals = outObject.GetComponent<RoomValsUniversal>();
        roomVals.eastWall.ChangeDoorState(!TryReturnRoomOnCoords(x + 1, z, out ignore));
        roomVals.northWall.ChangeDoorState(!TryReturnRoomOnCoords(x, z + 1, out ignore));
        roomVals.westWall.ChangeDoorState(!TryReturnRoomOnCoords(x - 1, z, out ignore));
        roomVals.southWall.ChangeDoorState(!TryReturnRoomOnCoords(x, z - 1, out ignore));
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
    internal Vector3 GetEntranceRoomPos()
    {
        return enterRoomPos;
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
