using UnityEngine;
using System.Collections.Generic;

//Summary
// This system controls the Bracer system, or the player's main way of interacting with the environment.
//Summary

public class BracerManager : MonoBehaviour
{
	public int Brace1 = 1;
	public int Brace2 = 1;
	public int Brace3 = 1;
 	public int LastBracerMode = 1;
	public int BracerMode = 1;
 	public int BracerEnergy = 100;
  	public Character character;
   	public int baseChargeRate = 10;
   	public int chargeRate = 10;
    public bool weaponMode = true;
    
	// Bracer modes range from 1-27, depending on the current combination.

 	private Dictionary<string, int> bracerCombinationModes = new Dictionary<string, int>();
  	// Dictionary turns a "string" into an "int", so that BracerMode can be properly updated depending on the combination.

    void Start()
    {	
    	// Adds all possible Bracer combinations to the dictionary "bracerCombinationModes", so it can be translated to BracerMode.
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
	bracerCombinationModes.Add("2-1-3", 27);
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

 	public void UpdateBracer() // Turns the current Brace# variables into a string, and then references it to the dictionary. 
    {
        string combinationKey = $"{Brace1}-{Brace2}-{Brace3}";

        if (bracerCombinationModes.ContainsKey(combinationKey))
        {
            BracerMode = bracerCombinationModes[combinationKey]; // Turns the BracerMode into the proper integer by translating it with the dictionary
            Debug.Log("BracerMode updated to: " + BracerMode);
        }
        else
        {
            Debug.LogWarning("Bracer combination not found. Current combination: " + combinationKey);
        }
    }

     public void UseBracer() // Do bracer actions, depending on mode.
    {
    	if (LastBracerMode != BracerMode && character.isFlying)
     	{
      	   	character.isFlying = false;
	   	chargeRate = baseChargeRate;
	}
     	if (LastBracerMode != BracerMode && character.isHealing)
     	{
      	   	character.isHealing = false;
	   	chargeRate = baseChargeRate;
	}
 
    	if (BracerMode == 1 && BracerEnergy>= 5) // Standard Attack, Sword
     	{
      		character.attackDamage = 10;
		character.attackRange = 2;
  		BracerEnergy -= 10;
    		weaponMode = true;
      	}
    	if (BracerMode == 2 && BracerEnergy >= 15) // Standard Ranged Attack, Rifle
     	{
      		character.attackDamage = 8;
		character.attackRange = 4;
  		BracerEnergy -= 15;
    		weaponMode = true;
      	}
    	if (BracerMode == 3 && BracerEnergy >= 20) // Standard Splash Attack, War Hammer
     	{
      		character.attackDamage = 18;
		character.attackRange = 1;
  		character.attackSplash = true;
  		BracerEnergy -= 20;
    		weaponMode = true;
      	}
	if (BracerMode == 8 && !character.isHealing && BracerEnergy >= 15) //Regen of 15
	{
 		character.isHealing = true;
   		character.currentHealth += 15;
     		chargeRate = -15;
       		weaponMode = false;
	}
 	if (BracerMode == 8 && character.isHealing || character.currentHealth >= character.baseHealth)
  	{
   		character.isHealing = false;
     		chargeRate = baseChargeRate;
	}
 	if (BracerMode == 10 && BracerEnergy >= 1) //Heals Equal to Energy
  	{
   		character.currentHealth += BracerEnergy;
     		if (character.currentHealth >= character.baseHealth)
	        {
		        character.currentHealth = character.baseHealth;
	        }
     		BracerEnergy = 0;
       		weaponMode = false;
	}
	if (BracerMode == 16 && !character.isFlying && BracerEnergy >= 10) //Flight
     	{
      		character.isFlying = true;
		chargeRate = -10;
  		weaponMode = false;
  	}
  	if (BracerMode == 16 && character.isFlying)
    	{
      		character.isFlying = false;
		chargeRate = baseChargeRate;
  		weaponMode = false;
      	}
       	if (BracerMode == 20 && BracerEnergy >= 5) //Movement buff, maybe it also disables dangerous terrain?
     	{
		character.movementRange = 4;
		BracerEnergy -= 5;
  		weaponMode = false;
      	}
    	if (BracerMode == 21 && BracerEnergy >= 50) //Bomb, Splash Attack, any tile it hits gets set on fire
     	{
      		character.attackDamage = 45;
		character.attackRange = 3;
  		character.attackSplash = true;
  		BracerEnergy -= 50;
		weaponMode = true;
      	}
       if (BracerMode == 27) // Confetti!
       {
       		BracerEnergy += 1;
	 	weaponMode = false;
       }
     	Debug.Log("Bracer has been used in mode: " + BracerMode);
      	LastBracerMode = BracerMode;
    }
}
