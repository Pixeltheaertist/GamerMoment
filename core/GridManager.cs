using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float tileSize = 1f;
    public GameObject tilePrefab;
    public Tile[,] grid;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * tileSize, y * tileSize, 0);
                GameObject tileObj = Instantiate(tilePrefab, position, Quaternion.identity);
                Tile tile = tileObj.GetComponent<Tile>();
                tile.position = new Vector2Int(x, y);
                grid[x, y] = tile;
            }
        }
    }

    public Tile GetTileAtPosition(Vector2Int position)
    {
        if (position.x >= 0 && position.x < width && position.y >= 0 && position.y < height)
            return grid[position.x, position.y];
        return null;
    }
}
