using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GridManager gridPrefab;
    [SerializeField] List<GridManager> grids = new List<GridManager>();
    [SerializeField] float distanceBetweenGrids;
    internal int gridCount { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GridManager grid = CreateGrid();
        Instantiate(playerPrefab, new Vector3(grid.enterRoomPos.x, 1, grid.enterRoomPos.z), transform.rotation);
    }

    private GridManager CreateGrid(GridManager gridPrefabToUse = null)
    {
        if (gridPrefabToUse == null)
        {
            gridPrefabToUse = gridPrefab;
        }
        GridManager grid = Instantiate(gridPrefabToUse);
        grids.Add(grid);
        grid.GenerateGrid();
        gridCount = grids.Count;
        return grid;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
