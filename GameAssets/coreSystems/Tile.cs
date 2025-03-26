using UnityEngine;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    public Vector2Int position;  // Tile position in the grid
	
    public bool isWalkable = true;  // Whether this tile can be walked on
    public bool hasCorpse = false; // Whether this tile has a corpse on it for looting
    public bool isDeadly = false; // Whether this tile will kill you once stepped on
    public bool difficultTerrain = false; // Whether this tile is harder to traverse
    public bool isPit = false; // Whether this tile will only allow flying creatures to safely cross
    public bool isOccupied = false; // Is there a character on this tile?
    public Character occupiedBy = null;
    public bool onFire = false; // Is the tile on fire?

    private Tile[] adjacentTiles; // To store adjacent tiles

    // Method to snap the tile to the grid position
    public void SnapToGrid(Vector2Int gridPosition, float tileSize)
    {
        // Calculate the world position based on grid position
        Vector3 snappedPosition = new Vector3(gridPosition.x * tileSize, gridPosition.y * tileSize, 0f);
        transform.position = snappedPosition;
        position = gridPosition; // Update the position property to match grid position
    }

    // Method to set adjacent tiles
    public void SetAdjacentTiles(Tile[] adjacent)
    {
        adjacentTiles = adjacent; // Set the list of adjacent tiles
    }

    // Optional: Method to get adjacent tiles (if needed)
    public Tile[] GetAdjacentTiles()
    {
        return adjacentTiles;
    }
}