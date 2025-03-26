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
   	public TurnManager turnManager;
   	public int baseChargeRate = 10;
   	public int chargeRate = 10;
    	public bool weaponMode = true;
     	public Character player = turnManager.playerCharacter;
    
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
    	if (LastBracerMode != BracerMode && player.isFlying)
     	{
      	   	player.isFlying = false;
	   	chargeRate = baseChargeRate;
	}
     	if (LastBracerMode != BracerMode && player.isHealing)
     	{
      	   	player.isHealing = false;
	   	chargeRate = baseChargeRate;
	}
 
    	if (BracerMode == 1 && BracerEnergy>= 5) // Standard Attack, Sword
     	{
      		player.attackDamage = 10;
		player.attackRange = 2;
  		BracerEnergy -= 10;
    		weaponMode = true;
      	}
    	if (BracerMode == 2 && BracerEnergy >= 15) // Standard Ranged Attack, Rifle
     	{
      		player.attackDamage = 8;
		player.attackRange = 4;
  		BracerEnergy -= 15;
    		weaponMode = true;
      	}
    	if (BracerMode == 3 && BracerEnergy >= 20) // Standard Splash Attack, War Hammer
     	{
      		player.attackDamage = 18;
		player.attackRange = 1;
  		player.attackSplash = true;
  		BracerEnergy -= 20;
    		weaponMode = true;
      	}
	if (BracerMode == 8 && !player.isHealing && BracerEnergy >= 15) //Regen of 15
	{
 		player.isHealing = true;
   		player.currentHealth += 15;
     		chargeRate = -15;
       		weaponMode = false;
	}
 	if (BracerMode == 8 && player.isHealing || player.currentHealth >= player.baseHealth)
  	{
   		player.isHealing = false;
     		chargeRate = baseChargeRate;
	}
 	if (BracerMode == 10 && BracerEnergy >= 1) //Heals Equal to Energy
  	{
   		player.currentHealth += BracerEnergy;
     		if (player.currentHealth >= player.baseHealth)
	        {
		        player.currentHealth = player.baseHealth;
	        }
     		BracerEnergy = 0;
       		weaponMode = false;
	}
	if (BracerMode == 16 && !player.isFlying && BracerEnergy >= 10) //Flight
     	{
      		player.isFlying = true;
		chargeRate = -10;
  		weaponMode = false;
  	}
  	if (BracerMode == 16 && player.isFlying)
    	{
      		player.isFlying = false;
		chargeRate = baseChargeRate;
  		weaponMode = false;
      	}
       	if (BracerMode == 20 && BracerEnergy >= 5) //Movement buff, maybe it also disables dangerous terrain?
     	{
		player.movementRange = 4;
		BracerEnergy -= 5;
  		weaponMode = false;
      	}
    	if (BracerMode == 21 && BracerEnergy >= 50) //Bomb, Splash Attack, any tile it hits gets set on fire
     	{
      		player.attackDamage = 45;
		player.attackRange = 3;
  		player.attackSplash = true;
  		BracerEnergy -= 50;
		weaponMode = true;
      	}
        if (BracerMode == 26) // 3-3-3 combo, perhaps shield or a random TP. Neither of those are set up code wise yet.
	{
 		//code goes here
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
