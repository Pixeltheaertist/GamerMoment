using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public Character character;
    public TurnManager turnManager;
    private bool combatPhase = false;

    public void StartCombat()
    {
        combatPhase = true;
        Debug.Log("Combat phase started.");
    }

    // Handle combat input (WASD keys)
    public void CombatPrompt()
    {
        if (combatPhase)
        {
            Debug.Log("Combat prompt active, awaiting input.");

            // Check for directional input (WASD keys)
            if (Input.GetKeyDown(KeyCode.W)) // Aim Up (North)
            {
                Debug.Log("Attacking up");
                TryAttack(Vector2Int.up, turnManager.playerCharacter.attackRange);  // Check tile and attack
            }

            if (Input.GetKeyDown(KeyCode.S)) // Aim Down (South)
            {
                Debug.Log("Attacking down");
                TryAttack(Vector2Int.down, turnManager.playerCharacter.attackRange);  // Check tile and attack
            }

            if (Input.GetKeyDown(KeyCode.A)) // Aim Left (West)
            {
                Debug.Log("Attacking left");
                TryAttack(Vector2Int.left, turnManager.playerCharacter.attackRange);  // Check tile and attack
            }

            if (Input.GetKeyDown(KeyCode.D)) // Aim Right (East)
            {
                Debug.Log("Attacking right");
                TryAttack(Vector2Int.right, turnManager.playerCharacter.attackRange);  // Check tile and attack
            }
        }
    }

    private void TryAttack(Vector2Int direction, int range)
    {
    
        for (int i = 1; i <= range; i++)
        {
            // Get the tile at the current step in the direction
            Tile targetTile = GetTileInDirection(direction * i);

            if (targetTile == null)
            {
                Debug.Log("No tile in this direction.");
                continue;
            }

            // If the tile is occupied by a target character, perform the attack
            if (targetTile.isOccupied)
            {
                Character targetCharacter = targetTile.occupiedBy;
                Debug.Log($"Found target at distance {i}. Attacking {targetCharacter.name}");
                DoWalkCombat(targetCharacter);
                return; // End the loop once an attack is made
            }
        }

        // If no target is found in the range, end the turn
        Debug.Log("No targets within range.");
        EndTurn();
    }

    // Get the tile in the given direction from the character's current position
    private Tile GetTileInDirection(Vector2Int direction)
    {
        Vector2Int targetPosition = turnManager.playerCharacter.currentTilePosition + direction;
        Tile targetTile = turnManager.gridManager.GetTileAtPosition(targetPosition);

        return targetTile;
    }

    // Perform the combat with the target character
    public void DoWalkCombat(Character targetCharacter)
    {
        Character playerCharacter = turnManager.playerCharacter;
        targetCharacter.currentHealth -= playerCharacter.attackDamage;

        Debug.Log($"Dealt {playerCharacter.attackDamage} damage to {targetCharacter.name}, current health: {targetCharacter.currentHealth}");

        if (targetCharacter.currentHealth <= 0)
        {
            Destroy(targetCharacter.gameObject);
            Debug.Log($"Killed {targetCharacter.name}");
        }

        EndTurn();
    }

    // End combat and call EndTurn on TurnManager
    private void EndTurn()
    {
        combatPhase = false;  // End combat phase
        Debug.Log("Ending combat and turn.");
        turnManager.EndTurn();
    }
}
