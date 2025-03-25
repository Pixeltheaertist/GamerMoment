using UnityEngine;

public class DeathController : MonoBehaviour
{
	public void Death()
	{
		foreach (Character target in characters)
		{
			Destroy(target) // Removes all characters from the screen
		}
		
		// Fade in a GAME OVER screen
	}
}
