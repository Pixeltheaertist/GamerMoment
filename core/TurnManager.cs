using System.Collections.Generic;
using UnityEngine;

// CONTROL LAYOUT:
// W: Move up
// S: Move down
// A: Move left
// D: Move right
// Enter: Skip turn
// 1: Rotate Bracer slot one
// 2: Rotate Bracer slot two
// 3: Rotate Bracer slot three

public class TurnManager : MonoBehaviour
{
    private List<Character> characters = new List<Character>();
    private int currentCharacterIndex = 0;
    private bool isPlayerTurn = true;
    public DeathController deathController;
    public BracerManager bracerManager;

    public void AddCharacter(Character character)
    {
        characters.Add(character);
    }

    void Start()
    {
        AddCharacter(GameObject.Find("PlayerCharacter").GetComponent<Character>());
	
	if (deathController != null)
        {
            deathController.characters = characters;
        }
    }

    void Update()
    {
        if (isPlayerTurn)
        {
            HandlePlayerInput();
        }
        else
        {
            HandleAI();
        }
    }

    void HandlePlayerInput()
    {
        // Input handling for the player's turn, e.g., moving character
        Character currentCharacter = characters[currentCharacterIndex];

        if (Input.GetKeyDown(KeyCode.W)) // Move Up (North)
        {
            Vector2Int targetPosition = currentCharacter.currentTilePosition + Vector2Int.up;
            if (currentCharacter.CanMoveTo(targetPosition))
            {
                currentCharacter.Move(targetPosition);
                EndTurn();
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) // Move Down (South)
        {
            Vector2Int targetPosition = currentCharacter.currentTilePosition + Vector2Int.down;
            if (currentCharacter.CanMoveTo(targetPosition))
            {
                currentCharacter.Move(targetPosition);
                EndTurn();
            }
        }

        if (Input.GetKeyDown(KeyCode.A)) // Move Left (West)
        {
            Vector2Int targetPosition = currentCharacter.currentTilePosition + Vector2Int.left;
            if (currentCharacter.CanMoveTo(targetPosition))
            {
                currentCharacter.Move(targetPosition);
                EndTurn();
            }
        }

        if (Input.GetKeyDown(KeyCode.D)) // Move Right (East)
        {
            Vector2Int targetPosition = currentCharacter.currentTilePosition + Vector2Int.right;
            if (currentCharacter.CanMoveTo(targetPosition))
            {
                currentCharacter.Move(targetPosition);
                EndTurn();
            }
        }
		
	if (Input.GetKeyDown(KeyCode.Alpha1)) // Change bracer segment 1
        {
            bracerManager.BraceChange1();
        }
		
	if (Input.GetKeyDown(KeyCode.Alpha2)) // Change bracer segment 2
        {
            bracerManager.BraceChange2();
        }
		
	if (Input.GetKeyDown(KeyCode.Alpha3)) // Change bracer segment 3
        {
            bracerManager.BraceChange3();
        }
	
	if (Input.GetKeyDown(KeyCode.Return)) // Skip your turn
        {
            EndTurn();
        }

 	if (Input.GetKeyDown(KeyCode.Space)) // Use your Bracer in it's current mode
        {
	    bracerManager.UseBracer();
            EndTurn();
        }
 
    }

    void HandleAI()
    {
        // AI logic for other characters (e.g., move randomly, or attack, etc.)
        // For now, just a placeholder for the AI logic
        EndTurn();
    }

    void EndTurn()
    {
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Count;
	bracerManager.UpdateBracer();
        isPlayerTurn = !isPlayerTurn; // Switch turns
    }
}
