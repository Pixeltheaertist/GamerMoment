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

            if (Input.GetKeyDown(KeyCode.W)) // Aim Up (North)
            {
                Debug.Log("Attacking up");
                EndTurn();  // End turn after attack
            }

            if (Input.GetKeyDown(KeyCode.S)) // Aim Down (South)
            {
                Debug.Log("Attacking down");
                EndTurn();  // End turn after attack
            }

            if (Input.GetKeyDown(KeyCode.A)) // Aim Left (West)
            {
                Debug.Log("Attacking left");
                EndTurn();  // End turn after attack
            }

            if (Input.GetKeyDown(KeyCode.D)) // Aim Right (East)
            {
                Debug.Log("Attacking right");
                EndTurn();  // End turn after attack
            }
        }
    }

    // End combat and call EndTurn on TurnManager
    private void EndTurn()
    {
        combatPhase = false;  // End combat phase
        Debug.Log("Ending combat, turning over...");
        turnManager.EndTurn();  // End the player's turn
    }
}
