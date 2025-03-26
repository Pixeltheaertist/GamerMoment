using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public float tileSize = 1f;  // Tile size in world space
    public Tile[] tilesInScene;  // All tiles in the scene
    private Dictionary<Vector2Int, Tile> tileDictionary = new Dictionary<Vector2Int, Tile>();

    // This method runs when the game starts
    void Start()
    {
        // Get all the Tile objects in the scene
        tilesInScene = FindObjectsOfType<Tile>();

        // Sort tiles by their position to make sure they are aligned (can be helpful for snapping)
        List<Tile> sortedTiles = new List<Tile>(tilesInScene);
        sortedTiles.Sort((a, b) => a.position.x == b.position.x ? a.position.y.CompareTo(b.position.y) : a.position.x.CompareTo(b.position.x));

        // Now, snap all tiles to their correct positions and set neighbors
        SetUpTiles(sortedTiles);
    }

    // Set up tiles by snapping them and connecting adjacent tiles
    void SetUpTiles(List<Tile> sortedTiles)
    {
        foreach (Tile tile in sortedTiles)
        {
            // Snap the tile to its position based on its world position
            Vector2Int gridPosition = new Vector2Int(Mathf.RoundToInt(tile.transform.position.x / tileSize), Mathf.RoundToInt(tile.transform.position.y / tileSize));
            tile.SnapToGrid(gridPosition, tileSize);

            // Add the tile to the dictionary for easy lookup
            if (!tileDictionary.ContainsKey(gridPosition))
            {
                tileDictionary.Add(gridPosition, tile);
            }
        }

        // Now that we have snapped all tiles, set the adjacent tiles
        SetAdjacentTilesForAll(sortedTiles);
    }

    // Get the tile at a specific grid position
    public Tile GetTileAtPosition(Vector2Int position)
    {
        if (tileDictionary.ContainsKey(position))
        {
            return tileDictionary[position];
        }
        return null;  // Return null if no tile is found at that position
    }

    // Set adjacent tiles for all tiles
    void SetAdjacentTilesForAll(List<Tile> sortedTiles)
    {
        foreach (Tile tile in sortedTiles)
        {
            List<Tile> neighbors = new List<Tile>();

            // Get adjacent positions
            Vector2Int[] directions = new Vector2Int[]
            {
                new Vector2Int(0, 1),   // Top
                new Vector2Int(0, -1),  // Bottom
                new Vector2Int(-1, 0),  // Left
                new Vector2Int(1, 0),   // Right
            };

            // Check neighbors
            foreach (Vector2Int direction in directions)
            {
                Vector2Int neighborPos = tile.position + direction;

                // Find the neighbor tile based on its position
                Tile neighborTile = sortedTiles.Find(t => t.position == neighborPos);
                if (neighborTile != null)
                {
                    neighbors.Add(neighborTile);
                }
            }

            // Set the adjacent tiles for the current tile
            tile.SetAdjacentTiles(neighbors.ToArray());
        }
    }
}
