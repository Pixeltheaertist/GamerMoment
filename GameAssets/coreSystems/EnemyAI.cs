using UnityEngine;
// Summary
// This system controls how enemies behave when it is their turn.
// Summary

public class EnemyAI : MonoBehavior
{
      // This is where I would put my variables. IF I HAD ANY
      
      // Public callable function for idling
            //Randomly generate a number from 1 to 4 with each number representing a direction
            //If chosen direction not wall and not hazard, move one tile in that direction.
      //Public callable function for attacking
            //Check if enemy type is ranged or melee
                  //If melee, check if player is out of range
                        //If out of range, move towards player
                        //If in range, attack player
                  //If ranged 
                        //check if player is in melee range
                              // If in melee, move away
                        //Check if enemy has line of sight with player
                              // If false, use movement to move laterally
                              //if true, attack.
      
}
