using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector2Int currentTilePosition;
    public GridManager gridManager;
	public int baseMovementRange = 3; // Base unmodifiable movement range
    public int movementRange = 3;  // How many tiles the character can move per turn
	public bool isFlying = false; // Is this character flying?
	public bool Player = true; // Is this YOU?

    // This method is responsible for moving the character on the grid.
    public void Move(Vector2Int targetPosition)
    {
        Tile targetTile = gridManager.GetTileAtPosition(targetPosition);
		
		if (targetTile.isPit && !isFlying && Player)
		{
			DeathController.Death(); // Removes all characters from the screen and calls the Death block
		}
		
		if (targetTile.difficultTerrain)
		{
			movementRange = movementRange - 1; // Reduce movement range by one
		}

        if (targetTile != null && targetTile.isWalkable)
        {
            currentTilePosition = targetPosition;
            transform.position = new Vector3(targetPosition.x * gridManager.tileSize, targetPosition.y * gridManager.tileSize, 0);
			movementRange = baseMovementRange; // Restore movement range after difficult terrain
        }
    }

    // Checks if the target tile is within the movement range
    public bool CanMoveTo(Vector2Int targetPosition)
    {
        return Vector2Int.Distance(currentTilePosition, targetPosition) <= movementRange;
    }
}
