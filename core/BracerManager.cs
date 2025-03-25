using UnityEngine;
//Summary
// This system controls the Bracer system, or the player's main way of interacting with the environment.
//Summary

public class BracerManager : MonoBehaviour
{
	public int Brace1 = 1;
	public int Brace2 = 1;
	public int Brace3 = 1;
	public int BracerMode = 1;
	// Bracer modes range from 1-18, depending on the current combination.
	
    public void BraceChange1()
	{
		Brace1 += 1;
		if (Brace1 > 3)
		{
			Brace1 = 1;
		}
		Debug.Log("Bracer ring 1 changed to state: " + Brace1);
	}
	
	public void BraceChange2()
	{
		Brace2 += 1;
		if (Brace2 > 3)
		{
			Brace2 = 1;
		}
		Debug.Log("Bracer ring 2 changed to state: " + Brace2);
	}
	
	public void BraceChange3()
	{
		Brace3 += 1;
		if (Brace3 > 3)
		{
			Brace3 = 1;
		}
		Debug.Log("Bracer ring 3 changed to state: " + Brace3);
	}
	
	// This will store combinations that the bracer is in, or it's "mode"
}
