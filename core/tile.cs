using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int position;  // Tile position in the grid
	
    public bool isWalkable = true;  // Whether this tile can be walked on
	public bool hasCorpse = false; // Whether this tile has a corpse on it for looting
	public bool isDeadly = false; // Whether this tile will kill you once stepped on
	public bool difficultTerrain = false; // Whether this tile is harder to traverse
	public bool isPit = false; // Whether this tile will only allow flying creatures to safely cross
}
