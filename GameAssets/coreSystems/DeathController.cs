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

 	public void AIDeath()
	{
		// This will hold what occurrs when an AI character dies. It will spawn a corpse that can be walked on to regain health and energy in your Bracer.
  		// Do this by giving the tile they die on the "hasCorpse" bool.
	}
}
