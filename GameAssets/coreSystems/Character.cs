using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector2Int currentTilePosition;  // The current position of the character on the grid
    public GridManager gridManager;  // Reference to the GridManager to get tile data
    public DeathController deathController;  // Reference to the death controller to handle death
    public int baseMovementRange = 3;  // Base unmodifiable movement range
    public int movementRange = 3;  // How many tiles the character can move per turn
    public bool isFlying = false;  // Is this character flying?
    public bool Player = false;  // Is this YOU? (Player character)
    public int baseHealth = 100;  // Base unmodifiable health
    public int currentHealth = 100;  // Current health
    public bool isHealing = false;  // If regen is active
    public int attackDamage = 1;  // Damage, set to 1 so everything does at least some damage
    public int attackRange = 1;  // How far away the attack can reach, 1 is melee range
    public bool attackSplash = false;  // If an attack splashes to all tiles around it
    public bool isPoisoned = false;  // Is this character poisoned?
    public bool aiming = false;

    void Start()
    {
        SnapToNearestTile();
        
        if (currentTilePosition == Vector2Int.zero)
        {
            Debug.LogWarning("currentTilePosition is not initialized, setting default value.");
            currentTilePosition = new Vector2Int(0, 0);
        }
    }

    // Snaps the character to the nearest tile
    void SnapToNearestTile()
    {
        Tile nearestTile = GetNearestTile(transform.position);
        if (nearestTile != null)
        {
            currentTilePosition = nearestTile.position;
            transform.position = new Vector3(nearestTile.position.x * gridManager.tileSize, nearestTile.position.y * gridManager.tileSize, 0);
        }
    }

    // Finds the nearest tile to the character's position
    Tile GetNearestTile(Vector3 position)
    {
        Tile nearestTile = null;
        float minDistance = Mathf.Infinity;

        // Loop through all the tiles in the grid
        foreach (Tile tile in gridManager.tilesInScene)
        {
            float distance = Vector3.Distance(position, tile.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTile = tile;
            }
        }
        return nearestTile;
    }

    // Move the character to the new position
    public void Move(Vector2Int targetPosition)
    {
        Tile targetTile = gridManager.GetTileAtPosition(targetPosition);
        Tile currentTile = gridManager.GetTileAtPosition(currentTilePosition);

        if (targetTile == null)
        {
            Debug.LogWarning("Target tile is null. Cannot move.");
            return;
        }

        // Check if the tile is walkable and not occupied
        if (targetTile.isWalkable && !targetTile.isOccupied && movementRange > 0)
        {
            currentTilePosition = targetPosition;
            targetTile.isOccupied = true;
            if (targetTile.difficultTerrain)
            {
                movementRange -= 1;
            }
            currentTile.isOccupied = false;
            
            transform.position = new Vector3(targetPosition.x * gridManager.tileSize, targetPosition.y * gridManager.tileSize, 0);
            movementRange--;  // Decrease movement range after moving
        }
        else
        {
            Debug.LogWarning("Target tile is either not walkable or already occupied, or movement range exhausted.");
        }
    }

    // Check if the target tile is within the movement range
    public bool CanMoveTo(Vector2Int targetPosition)
    {
        Tile targetTile = gridManager.GetTileAtPosition(targetPosition);

        if (targetTile != null && targetTile.isWalkable && !targetTile.isOccupied)
        {
            if (Vector2Int.Distance(currentTilePosition, targetPosition) <= movementRange)
            {
                return true;
            }
        }
        return false;
    }

    // Reset movement range at the start of the next turn
    public void ResetMovementRange()
    {
        movementRange = baseMovementRange;
    }
}
