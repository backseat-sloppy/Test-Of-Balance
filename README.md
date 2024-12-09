Mini-Project
Project Name: Test of Balance
Name: Mads Benjamin Dalsgaard Krusager
Student number: 20235588
Link to Project: https://github.com/backseat-sloppy/Test-Of-Balance
Overview of the Game
This project is inspired by the small custom map from Warcraft ||| the Frozen Throne called Test of Balance. However, this project’s scope was much smaller. The player finds themselves in the middle of nowhere surrounded by blue glowing rocks, then after acquiring a fireball-spell the player must defend against an infinite onslaught of angry bear-men! The goal of this game is survival, as the game progresses more and more bears spawn, making it much harder to stay alive.
This project was made in Unity and is entirely happening in a singular scene and utilizes multiple key features for 3D game development. These include:
-	An interactive camera that follows the player when they are traversing around the scene
-	Enemies that can be interacted with either by shooting or letting them hit you with their weapon or colliding with their colliders
-	The playable character, which can walk, run, jump and shoot fireballs aimed with mouse input
-	Materials with properties such as emission further enhanced by post-processing
-	Point-lights moving dynamically across the scene 
-	Multiple animation blend trees made with inverse Kinematics 
-	VFX graph package to make more complex particle systems.
Important workings
The CameraBehavior is a simple class which fetch the playable character’s transform and ensures it always hovers a fixed offset point from this point. This ensures the camera never loses focus of the player. The fireball spell casting happening in this project stems from a more complex series of classes with a SpellManager SpellSlotManager and a SpellFactory. The player is able to cast spells from the SpellManager class, and it is slotted to the first slot trought the SpellSlotManager, this class knows what spell (only the fireball so far) to slot based on a dictionary created in the SpellFactory class. This script serves as a storage of all spells the player can acquire throughout the game. Each spell has a separate class namely Fireball01, which is a child of an abstract Spell class, to inherit and override a cast method and an integer ID, which serves as the Value and key for the dictionary in SpellFactory. The Fireball01 contains logic for creating the Fireball prefab within its cast method. 
This Fireball has a different FireballProjectile script which handles the trajectory of the fireball trough a raycast of where the mouse is currently, afterwards a fixed Y axis transform is applied to avoid shoot fireballs at the ground. The fireball prefab has a point-light as well as a particle system which in combination with each other creates a beautiful fireball. The fireball also has a collider and a rigidbody this is needed for the fireball to explode once it hits terrain or a mad bear. The particle system creates particles with random life times as well as random rotations, this is done to reach a more imperfect and realistic result.

The blend trees and logic behind them is however done for the purpose of this project. Most important of these is the enemy bear mad man blend tree. The following is the blend tree:
  
Note that all transitions are triggers, this decision was made because most of the behavior from the enemies stem from IEnumerators, listed as: Strike, Moving, Spawning, Hurt and Death. Making it easy to set the trigger for each of these events for the corresponding animation in their respective IEnums. 
To give everything a more attractive look post-processing was enabled, and used to create bloom around lights further enhancing the look of the fireballs, this bloom is tinted the same hexa color-code as the center of the fireball. Furthermore, postprocessing was used to apply a slight tint to the camera, this is done to achieve a more uniform color pallet for the entire scene.
More time
Have I had more time with this project I would have wanted to do more with the landscaping, and creating a GUI is necessary however it seems to be only viable if the game contains something put in a GUI, example is I have health right now as a stat that decreases when hit, and therefore a health bar should be considered however, a GUI for what skills to cast is not relevant as only 1 exist as of this moment.
Time schedule
Spell casting infrastructure	The inner workings of adding and removing spells from hotkeys as well as storing them in dictionaries, enabling the possibility of enemies to use the same spells. 	10 hours
Player behavior	The player stats, used for health and some for cooldown for spells and health regeneration logic as well as unused mana regeneration. 
logic for moving the player and rotating the player model to always look at the curser using raycast.	1 hour
Enemy behavior and controller 	Controlling the enemy spawns and designing their behavior. 	3 hours
Animation	Creating the blend trees for moving the characters, specifically the enemies.
The animations for the two characters in this project is not developed in house, and can be found at: https://assetstore.unity.com/packages/3d/characters/humanoids/character-pack-free-animal-people-sample-204568
https://assetstore.unity.com/packages/3d/characters/creatures/monster-bear-free-296564
	1 hour
Camera behavior	Creating the interactive camera that follows the player	10 minutes
VFX particle system	I had a template from: https://assetstore.unity.com/packages/vfx/particles/fire-explosions/free-asset-vfx-particles-fireball-pack-263814
which I modified to better fit my needs and wants
	1 hour
Environment building	Making a plane and cubes and scattering them around the area, as well as creating materials with and without emissions 	1 hour
Post processing	Adding bloom as and a yellow tint to the camera	10 minutes
Bug fixing	Fixing the bugs as they come when integrating new code to the already existing code	2 hours

