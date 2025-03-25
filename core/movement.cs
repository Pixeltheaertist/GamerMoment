using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private List<Character> characters = new List<Character>();
    private int currentCharacterIndex = 0;
    private bool isPlayerTurn = true;

    public void AddCharacter(Character character)
    {
        characters.Add(character);
    }

    void Start()
    {
        // Example: Add characters (can be done dynamically in your game)
        AddCharacter(GameObject.Find("PlayerCharacter").GetComponent<Character>());
        // Add other characters like enemies, etc.
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
        isPlayerTurn = !isPlayerTurn; // Switch turns
    }
}
