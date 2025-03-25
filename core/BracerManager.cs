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
	// Bracer modes range from 1-26, depending on the current combination.

 	private Dictionary<string, int> bracerCombinationModes = new Dictionary<string, int>();

    void Start()
    {
        bracerCombinationModes.Add("1-1-1", 1);
        bracerCombinationModes.Add("2-1-1", 2);
        bracerCombinationModes.Add("3-1-1", 3);
        bracerCombinationModes.Add("1-2-1", 4);
        bracerCombinationModes.Add("1-3-1", 5);
        bracerCombinationModes.Add("1-1-2", 6);
        bracerCombinationModes.Add("1-1-3", 7);
        bracerCombinationModes.Add("2-2-1", 8);
        bracerCombinationModes.Add("3-3-1", 9);
        bracerCombinationModes.Add("2-2-2", 10);
        bracerCombinationModes.Add("1-2-2", 11);
        bracerCombinationModes.Add("1-3-2", 12);
        bracerCombinationModes.Add("1-2-3", 13);
        bracerCombinationModes.Add("1-3-3", 14);
        bracerCombinationModes.Add("2-3-1", 15);
        bracerCombinationModes.Add("2-3-2", 16);
        bracerCombinationModes.Add("2-3-3", 17);
        bracerCombinationModes.Add("3-2-1", 18);
        bracerCombinationModes.Add("3-2-2", 19);
        bracerCombinationModes.Add("2-1-2", 20);
        bracerCombinationModes.Add("3-1-2", 21);
        bracerCombinationModes.Add("3-1-3", 22);
        bracerCombinationModes.Add("2-2-3", 23);
        bracerCombinationModes.Add("3-2-3", 24);
        bracerCombinationModes.Add("3-3-2", 25);
        bracerCombinationModes.Add("3-3-3", 26);
    }
    
    public void BraceChange1()
	{
		Brace1 += 1;
		if (Brace1 > 3)
		{
			Brace1 = 1;
		}
		Debug.Log("Bracer ring 1 changed to state: " + Brace1);
  		UpdateBracer();
	}
	
	public void BraceChange2()
	{
		Brace2 += 1;
		if (Brace2 > 3)
		{
			Brace2 = 1;
		}
		Debug.Log("Bracer ring 2 changed to state: " + Brace2);
  		UpdateBracer();
	}
	
	public void BraceChange3()
	{
		Brace3 += 1;
		if (Brace3 > 3)
		{
			Brace3 = 1;
		}
		Debug.Log("Bracer ring 3 changed to state: " + Brace3);
  		UpdateBracer();
	}
	
	// This will store combinations that the bracer is in, or it's "mode"

 	public void UpdateBracer()
    {
        string combinationKey = $"{Brace1}-{Brace2}-{Brace3}";

        if (bracerCombinationModes.ContainsKey(combinationKey))
        {
            BracerMode = bracerCombinationModes[combinationKey];
            Debug.Log("BracerMode updated to: " + BracerMode);
        }
        else
        {
            Debug.LogWarning("Bracer combination not found. Current combination: " + combinationKey);
        }
    }
}
