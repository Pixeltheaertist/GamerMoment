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
      	public CombatManager combat;
      	public int drainAmount = 0;
    
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
	if (LastBracerMode != BracerMode && player.movementRange ~= player.baseMovementRange)
 	{
  		player.movementRange = player.baseMovementRange;
	}
 
    	if (BracerMode == 1 && BracerEnergy>= 5) // 1-1-1, Standard Attack, Sword
     	{
      		player.attackDamage = 10;
		player.attackRange = 2;
  		drainAmount = 10;
    		weaponMode = true;
      	}
    	if (BracerMode == 2 && BracerEnergy >= 15) // Standard Ranged Attack, Rifle
     	{
      		player.attackDamage = 8;
		player.attackRange = 4;
  		drainAmount = 15;
    		weaponMode = true;
      	}
    	if (BracerMode == 3 && BracerEnergy >= 20) // Standard Splash Attack, War Hammer
     	{
      		player.attackDamage = 18;
		player.attackRange = 1;
  		player.attackSplash = true;
  		drainAmount = 20;
    		weaponMode = true;
      	}
       	if (BracerMode == 4) // Harms the player significantly
	{
 		player.currentHealth -= 90
   		weaponMode = false;
	}
	if (BracerMode == 6 && Bracer Energy >= 25) // Knife that applies poison
 	{
  		player.attackDamage = 12;
		player.attackRange = 1;
  		drainAmount = 25;
    		combat.targetCharacter.isPoisoned = true;
    		weaponMode = true;
	}
	if (BracerMode == 8 && !player.isHealing && BracerEnergy >= 15) //Regen of 15
	{
 		player.isHealing = true;
   		player.currentHealth += 15;
     		chargeRate -= 15;
       		weaponMode = false;
	}
 	if (BracerMode == 8 && player.isHealing || player.currentHealth >= player.baseHealth)
  	{
   		player.isHealing = false;
     		chargeRate = baseChargeRate;
       		weaponMode = false;
	}
 	if (BracerMode == 10 && BracerEnergy >= 1) // 2-2-2, Heals Equal to Energy
  	{
   		player.currentHealth += BracerEnergy;
     		if (player.currentHealth >= player.baseHealth)
	        {
		        player.currentHealth = player.baseHealth;
	        }
     		BracerEnergy = 0;
       		weaponMode = false;
	}
 	if (BracerMode == 13 && BracerEnergy >= 40) //Teleports player back to spawn
  	{
   		player.targetPosition = new Vector2Int(0, 0);
     		player.currentTilePosition = targetPosition;
            	player.targetTile.isOccupied = true;
            	player.targetTile.occupiedBy = this;
            	player.currentTile.isOccupied = false;
            	player.currentTile.occupiedBy = null;
	     	BracerEnergy -= 40;
       		weaponMode = false;
	}
 	if (BracerMode == 15) //Deals 55 damage, Increases base charge rate by 5
  	{
   		player.currentHealth -= 55;
     		baseChargeRate += 5;
       		weaponMode = false;
	}
 	if (BracerMode == 15 && baseChargeRate == 15) //Greed system
  	{
   		player.currentHealth -= 80;
     		baseChargeRate += 5;
       		weaponMode = false;
	}
 	if (BracerMode == 15 && baseChargeRate == 20)
  	{	
    		player.currentHealth -= 110;
      		baseChargeRate += 5;
		weaponMode = false;
    	}
     	if (BracerMode == 15 && baseChargeRate == 25) //If they manage to survive the last one
	{
       		player.currentHealth -= 300;
	}
	if (BracerMode == 16 && !player.isFlying && BracerEnergy >= 10) //Flight
     	{
      		player.isFlying = true;
		chargeRate -= 10;
  		weaponMode = false;
  	}
  	if (BracerMode == 16 && player.isFlying)
    	{
      		player.isFlying = false;
		chargeRate = baseChargeRate;
  		weaponMode = false;
      	}
       	if (BracerMode == 18 && BracerEnergy >= 75) //Huge laser in all directions, weapon mode is false to circumvent aiming
	{
		player.attackDamage = 75;
		player.attackRange = 20;
  		BracerEnergy -= 75;
    		combat.TryAttack(Vector2Int.up, player.attackRange);
      		combat.TryAttack(Vector2Int.down, player.attackRange);
		combat.TryAttack(Vector2Int.left, player.attackRange);
  		combat.TryAttack(Vector2Int.right, player.attackRange);
    		weaponMode = false;
    	}
     	if (BracerMode == 19 && player.isPoisoned == false) //Poisons the player, but also allows you to cure yourself
      	{
       		player.isPoisoned == true;
	 	weaponMode = false;
	}
 	if (BracerMode == 19 && player.isPoisoned == true)
  	{
   		player.isPoisoned == false;
     		weaponMode = false;
	}
       	if (BracerMode == 20 && BracerEnergy >= 5) //Movement buff, maybe it also disables dangerous terrain?
     	{
		player.movementRange = 4;
		BracerEnergy -= 5;
  		weaponMode = false;
      	}
    	if (BracerMode == 21 && BracerEnergy >= 40) //Bomb, Splash Attack, any tile it hits gets set on fire
     	{
      		player.attackDamage = 30;
		player.attackRange = 3;
  		player.attackSplash = true;
  		drainAmount = 40;
		weaponMode = true;
      	}
 	if (BracerMode == 23 && BracerEnergy >= 1) //Laser pistol, sets it's damage to current energy (cap of 25)
  	{
   		player.attackDamage = BracerEnergy;
     		player.attackRange = 4;
       		drainAmount = BracerEnergy;
	 	weaponMode = true;
   		if (BracerEnergy > 25)
     		{
       			player.attackDamage = 25;
	  		drainAmount = 25;
		}
	}
        if (BracerMode == 26 && BracerEnergy >= 30) // 3-3-3 combo, Sets shield to super high but can't move
	{
 		player.shield = 6;
		player.movementRange = 1;
		chargeRate -= 20;
  		weaponMode = false;
	}
 	if (BracerMode == 26 && BraceryEnergy <= 0 || player.shield = 6)
  	{
   		player.shield = 0;
     		chargeRate = baseChargeRate;
       		weaponMode = false;
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
