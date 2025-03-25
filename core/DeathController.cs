using UnityEngine;

public class DeathController : MonoBehaviour
{
	public List<Character> characters;
	
	public void Death()
	{
		foreach (Character target in characters)
		{
			Destroy(target.GameObject); // Removes all characters from the screen
		}
		
		// Fade in a GAME OVER screen
	}
}
