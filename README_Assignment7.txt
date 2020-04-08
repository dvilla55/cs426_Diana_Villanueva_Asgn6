Project 151 by Diana, Abram, and Latrell
--------------------------------------------------------

Explain your design and its rationale, and how your components come together with respect to gameplay and theme:

A tower climbing game where the goal is to rescue villagers and defeat bad guys on your way up to the top where the boss awaits.

The tower has  multiple floors and what awaits you on each floor is either treasure or more enemies. 
	- To ascend to a higher floor you must encounter an opening in the higher floor then jump through said opening. 
	- To descend to a lower floor you must encounter an opening in the lower floor then fall through said opening. 

Floors with enemies contains villagers you must interact with in order to save.

Shooting enemies with healthbars will inflict damage to them. Upon their health depletion they will disappear.

3 forms of 3D physics:
-----------------------
Gravity - we want players to be able to fall and jump to different areas.

Enemy collision - we don't want players to just walk through enemies. The goal is for the players to clear each floor.

Wall bouncing - If a player accidentally jumps and runs into the above floor we want them to immediately fall to the ground. This may also result in speedrunning tactics.

three lights:
--------------
Enemy glows and flashes red when shot at by player. - We want a visually appealing indication that the player has damage the opponent.

Bullets - this gives bullets a cool visual effect to show the bullet's path.

pips - pips are a special item that boosts your weapon in different ways. We want to signify that it's important by providing a light to show that the pip is an item.

three sounds:
-------------
Condor Screech: A condor roams the area and screechs ocassionally. This adds to the level design by showing that not only villians exist on the tower, but so do condors.

Villager thank you: We want to provide audio to indicate that the villager is grateful for you saving them.

Pips: We want pips to provide audio indications that they have been picked up. New moon and full moon pips play the same sound in different pitches. This is useful to distinguish between the two pip  types.

three textures: these texture adds to the overall theme of the game. Giving it a cartoon feel.
----------------
Pio: The black and white protagonist.
Condor
The female villager

The “puzzle” and navigation: We want multiple AI and for them to operate in different ways so that interacting with the player doesn't seem linear.
----------------------------
FSM: The condor follows a set amount of commands (Abram)

Pathfinding: The default enemy follows a path around the floor looking for the enemy. (Diana)

A*: A special kind of enemy  that does not go in a random direction and knows the goal is to stay on top of the player. (Latrell)

The project must use at least three (or two) examples of Mecanim, one of which must be for a rigged character model:
---------------------------------------------------------------------------------------------------------------------
Condor: flaps its' wings up and down as it travels (Abram)

Pio: turns left and right when switching directions (Diana)

Female villager: stands slanted then switches to a prayer because she's scared (Latrell)

We added these to make sure the player gets a sense of Pio and the things he will be interacting with on multiple floors.
