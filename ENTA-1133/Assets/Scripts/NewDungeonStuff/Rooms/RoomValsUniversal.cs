using UnityEngine;

public class RoomValsUniversal : MonoBehaviour
{
    [SerializeField] internal GameObject northDoor;
    [SerializeField] internal GameObject eastDoor;
    [SerializeField] internal GameObject southDoor;
    [SerializeField] internal GameObject westDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal bool ReturnAllDoorsClosed()
    {
        if (northDoor.activeSelf && eastDoor.activeSelf && southDoor.activeSelf && westDoor.activeSelf)
        {
            return true;
        }
        return false;
    }
}
