using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private List<Character> characters = new List<Character>();
    private int currentCharacterIndex = 0;
    private bool isPlayerTurn = true;
	public DeathController deathController;

    public void AddCharacter(Character character)
    {
        characters.Add(character);
    }

    void Start()
    {
        AddCharacter(GameObject.Find("PlayerCharacter").GetComponent<Character>());
        // Add other characters like enemies, etc.
	
	if (deathController != null)
        {
            deathController.characters = characters; // populate DeathController's list with our list here, so it can be used when Game Over is forced.
        }
    }

    void Update()
    {
        if (isPlayerTurn)
        {
            HandlePlayerInput(); // Player turn! YIPPEE
        }
        else
        {
            HandleAI(); // AI's turn
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
    }

    void HandleAI()
    {
        // Logic for the AIs, which i'll code later. For now, just skips the turn.
	// AI should randomly choose between defending, moving or attacking the player (if the player is within notice range, otherwise just move)
        EndTurn();
    }

    void EndTurn()
    {
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Count;
        isPlayerTurn = !isPlayerTurn; // Switch turns
    }
}
