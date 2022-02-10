# gp21-22-0126-unity-game-mechanics-team-4-1
TeamMembers:
* Jesper Danielsson (GrapplingHook)
* Felix Kjellberg (Explosions)
* Nadia Dahlberg (Dash)

# Diffrent mechanics and how/where they are implemented
## GrapplingHook
Created 2 very simple AIs. In level 1 the AI will hook the player to the ground if the player comes to close to the AI. In level two the AI will use an invisible grapple to try and chase down the player when the player grapples away.
### Pull towards
The first implementation of grapplinghook is the pull towards, in level 1. With this implementation leftclick sets a grapplingpoint. Once a point has been set you can press the right shift button to drag to that position, letting go of shift then lets the normal gravity take over again.
### Swing rope
The second implementation of grapplinghook is the swingrope, in level 2. With this implementation leftclick shoots out a grapplinghook that sticks to the first collider it hits. the player can then swing in the rope that has been created between the player and the hook.
## Explosions
### Exploding mine
When the player gets in the colider the mine checks the direction to the player if it can find it and then adds force to the player in that direction sending the player flying.
### Imploding mine
When the player gets in the colider the mine is set of and a black hole appears and starts rising and pulling the player in for a couple of seconds and then releases the player.
## Dash
### Instant dash
The first dash implementation is used by pressing the LEFT shift key. You can dash in any direction. Player needs to touch the ground before using this implementation again.
### Dash pad
write shit here
