using UnityEngine;

public class RoomValsUniversal : MonoBehaviour
{
    [SerializeField] internal Wall northWall;
    [SerializeField] internal Wall eastWall;
    [SerializeField] internal Wall southWall;
    [SerializeField] internal Wall westWall;
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
        if (northWall.doorObject.activeSelf && eastWall.doorObject.activeSelf && southWall.doorObject.activeSelf && westWall.doorObject.activeSelf)
        {
            return true;
        }
        return false;
    }
}
