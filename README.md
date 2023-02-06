# EscapeTheMaze

Gameplay Description:
1. Upon acting on the feedback given to us, we have created a coherent educative game which consists of all the expected game components.
2. Game starts with a dynamic Start Menu UI, where the player is given a quick introduction about how to play the game.
3. The game consists of a maze layout which intelligently renders with an access path always being present to reach the End. We implemented this using a recursive backtracking pathfinding algorithm.
4. Win Condition : Player has to reach the end by simultaneously finding the access path to the end of the maze and by answering questions displayed, all the while maintaining the health of the cannon.
4. Following are the main components of the game:
    1. Cannon : Cannon is the main character of our game. It is fully animated and equipped with shooting functionalities that obey Physics.
    2. Barriers : These are the NPC components that are intelligently placed in the access path that display 'Physics' questions and answers. Player has to answer the question correctly to make the barrier disappear. It will not disappear no matter how many times the player shoots a cannonball toward a wrong answer. These questions are also chosen and displayed at random at every spawn to keep the gameplay exciting, i.e., same maze pattern and same questions will never repeat, which makes the game exciting! Player can only move forward after eliminating any and all barriers that present themselves in the path.
    3. Grenades : Grenades are strategically NPCs placed which when hit with the cannon decrease it's health. Player has to keep in mind of not killing the cannon if they want to win. To do this they cn either shoot the grenades or run away from it so that the cannon is outside the detected radius. There spawn at random positions every time the game starts, which makes it difficult for the player to memorize the positions.
    4. Heal zones : Heal zones are spaces that are strategically places where player can take the cannon to heal. Even these spawn at random positions every time the game starts, and hence there is no way to map out the path to make it easier for the next time.
    5. There are several more components to the game such as intuitive Health bar, perfectly designed audio system to render coherent SFX, a Particle System, and a thematic color palette, which makes the gameplay element wise sophisticated.
    6. Finally, we thank the professor, and the entire teaching staff for giving us valuable feedback and accomodating our requests knowing that there has been a dropout from the team.
