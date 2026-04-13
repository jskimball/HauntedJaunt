# CS480 Assignment 2
Project Members:
* Jasmine Kimball
* Tyler Sellin

## Dot Product Implementation
#### Implemented by Jasmine Kimball

To use dot product in this game, I created a distance vector to find the distance between the player and the game's end point. The magnitude of this vector is displayed at all times as a UI element, and aids the player by helping them find the general direction to go. The UI element disappears upon the game ending, and will reappear if the game restarts itself.

## Linear Interpolation Implementation
#### Implemented by Tyler Sellin

I utilized a linear interpolation to find out how far you were from the objective and convert it into a number between zero and one, and used that to blend the color from white to red as you approach the objective.

## Particle Effect Implementation
#### Implemented by Tyler Sellin

I added particles that create a trail behind the player's footsteps, so you can briefly see where they have been. The particles fade out over a few seconds, and appear under where the player is currently standing.

## Sound Effect Implementation
#### Implemented by Jasmine Kimball

I added a dynamic heartbeat sound effect that plays in the background of the game. The heartbeat sound increases in pitch the nearer you are to an enemy, and will return to a baseline pitch upon gaining distance from the nearest enemy. The sound is terminated upon the game ending, and will restart if the game restarts itself.
