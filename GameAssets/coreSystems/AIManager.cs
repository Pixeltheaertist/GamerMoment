using UnityEngine;
// Summary
// This system controls how enemies behave when it is their turn.
// Summary

public class AIManager : MonoBehavior
{
      public GridManager gridManager;
      public CombatManager combatManager;
      public TurnManager turnManager;
      public Character playerCharacter = null;
      
      public void AITurn(Character currentCharacter)
      {
            playerSeen(Character currentCharacter);
            if (playerSeen)
            {
                 CombatAI(currentCharacter); 
            }
            else
            {
                 StandardAI(currentCharacter);
            }
      }

     public void CombatAI(Character currentCharacter)
{
    if (playerCharacter != null)
    {
        int distanceToPlayer = Vector2Int.Distance(currentCharacter.currentTilePosition, playerCharacter.currentTilePosition);

        if (distanceToPlayer <= currentCharacter.attackRange)
        {
            combatManager.AIAttack(currentCharacter, playerCharacter);
        }
        else
        {
            Vector2Int direction = playerCharacter.currentTilePosition - currentCharacter.currentTilePosition;

            Vector2Int moveVector = new Vector2Int(
                Mathf.Clamp(direction.x, -currentCharacter.movementRange, currentCharacter.movementRange),
                Mathf.Clamp(direction.y, -currentCharacter.movementRange, currentCharacter.movementRange)
            );

            Vector2Int targetPosition = currentCharacter.currentTilePosition + moveVector;
            currentCharacter.Move(targetPosition);
        }
    }
}


      public void StandardAI(Character currentCharacter)
{
    Vector2Int[] directions = new Vector2Int[]
    {
        new Vector2Int(0, 1),  // Up
        new Vector2Int(0, -1), // Down
        new Vector2Int(-1, 0), // Left
        new Vector2Int(1, 0)   // Right
    };
    Vector2Int randomDirection = directions[Random.Range(0, directions.Length)];

    Vector2Int targetPosition = currentCharacter.currentTilePosition + randomDirection;
    currentCharacter.Move(targetPosition);

    turnManager.EndTurn();
}


     public bool playerSeen(Character currentCharacter)
{
    int sightRange = currentCharacter.sight;

    Vector2Int currentTileCoords = currentCharacter.currentTilePosition;

    for (int x = -sightRange; x <= sightRange; x++)
    {
        for (int y = -sightRange; y <= sightRange; y++)
        {
            Vector2Int tileCoordsToCheck = new Vector2Int(currentTileCoords.x + x, currentTileCoords.y + y);

            Tile tileToCheck = gridManager.GetTileAtPosition(tileCoordsToCheck);
            if (tileToCheck.isOccupied)
            {
                Character target = tileToCheck.occupiedBy;
                if (target.Player)
                {
                  playerCharacter = target;
                  return true;
                  break;
                }
            }
        }
    }

    return false;
}

}
