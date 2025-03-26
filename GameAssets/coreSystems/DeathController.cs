using UnityEngine;
using System.Collections.Generic;

//Summary
// This controls the death screen, and deletes all characters from the screen upon PLAYER death.
//Summary

public class DeathController : MonoBehaviour
{
	public List<Character> characters;
	
	public void Death()
	{
		foreach (Character target in characters)
		{
			Destroy(target); // Removes all characters from the screen
		}
		
		// Fade in a GAME OVER screen
	}
}
