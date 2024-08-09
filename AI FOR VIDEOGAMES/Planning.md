
### COMBINED STATES IN STATE MACHINES


In order to be able to have different states combined stored in the same variable, we can use a bitmask. 

For example if we have a 32 bits integer, its equal to 32 boolean. 
In this case, each position that a 1 is placed means a different state

```c#
public enum WorldState  
{  
  WORLD_STATE_NONE                    =   0,  // 0000000000000000  
  WORLD_STATE_ENEMY_DEAD              =   1,  // 0000000000000001  
  WORLD_STATE_GUN_OWNED               =   2,  // 0000000000000010  
  WORLD_STATE_GUN_LOADED              =   4,  // 0000000000000100  
  WORLD_STATE_KNIFE_OWNED             =   8,  // 0000000000001000  
  WORLD_STATE_CLOSE_TO_ENEMY          =  16,  // 0000000000010000  
  WORLD_STATE_CLOSE_TO_GUN            =  32,  // 0000000000100000  
  WORLD_STATE_CLOSE_TO_KNIFE          =  64,  // 0000000001000000  
  WORLD_STATE_LINE_OF_SIGHT_TO_ENEMY  = 128   // 0000000010000000  
}
```

In the previous image, can be seen that each state is a numerical value of a binary number. 

By doing an AND operation of a state with the combination of states, we can extract if the state is currently activated or not. 

```
currentStates = | 0 0 1 1 0 |
condition     = | 0 0 0 1 0 |
AND -------------------------
result =        | 0 0 0 1 0 
```

Also by doing an OR operation we can combine actions: 

```c#
WorldState currentStates = WorldState.WORLD_STATE_ENEMY_DEAD | WorldState.WORLD_STATE_KNIFE_OWNED; 
/*
WORLD_STATE_ENEMY_DEAD        = | 0 1 0 0 0 |
WORLD_STATE_KNIFE_OWNED       = | 0 0 0 1 0 |
OR ------------------------------------------
currentStates                 = | 0 1 0 1 0 | 
*/
```

Meaning that currentStates would now be 10 \[ 01010 ], but in reality is storing the two bits assigned to `WORLD_STATE_CLOSE_TO_ENEMY` and `WORLD_STATE_KNIFE_OWNED` states. 
### EFFECT  MASK

An action is composed of: 
* preconditions
* effects

If an action is done, we check the preconditions if are correct, apply the effects. 

If we evaluate: 

```
currentStates = | 0 0 1 1 0 |
pre-condition = | 0 0 0 1 0 |
AND -------------------------
result        = | 0 0 0 1 0 |

// If result == pre-condition means that we can execute the action
```

Then, once the pre-condition is evaluated we can apply the effects. Once we apply the effects, this would change the states activated by using an OR operation between the current states and the new states: 

```
currentStates = | 0 0 1 1 0 |
effect        = | 0 0 0 0 1 |
AND -------------------------
result        = | 0 0 1 1 1 |

```

