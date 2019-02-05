# PROJECT Design Documentation
> Design Documentation

# Team Information
* Team name: B.S. Studios
* Team members
  * Israel Anthony
  * Sadanand Naik
  * Yun Jiang
  * JaJuan Webster
  * Weihao Yan

## Executive Summary

So far we have finalised on most design elements of the game. We plan to get most of the assets from the public domain. We have decided on a basic architecture on how to implement the code for the game.  

### Purpose

Statement: The game aims to appease teenagers and young adults alike by giving an adrenaline pumping fast and furious action racing game.
                     
User group: 
            Teenagers and Young Adults;
            Hardcore racers;
            Fans who like to have interest in action and racing with strategizing their moves;
                       
User goal: Users can play the game that offers players the best of both racing as well as shooting action.

(Like.. what users want to get from our game?)

### Glossary and Acronyms
> Table of terms and acronyms.

| Term | Definition |
|------|------------|
| Rapier	 | Small and light category spaceship |
| Eviscerator		| Medium category spaceship |
| Goliath | Heavy category spaceship|


## Requirements
We would require the following to be able to create the game:
* A game engine.
* Art Assets.
* Sound Assets.
* Animations.8-12 months of development including play testing and debugging.

### Features

> Main features of the game

#### Epic
* Pre-Race Menu: As a player, I would like to select my ship, the map I am racing on, and start the race so that I can play against my opponent.
  * Ship Customization: As a player, I would like to make all necessary customizations to my ship before starting a race so that I am aware of what equipment I have available and so that I can distinguish my ship from others.
    * Visual Ship Customization
    * Ship Class Select
    * Starting Ship Equipment
  * Map Select
  * Race Start

* Environmental Obstacles: As a player, I would like to have different kinds of environmental obstacles that I may use to my benefit or that may hurt me if I am too careless so that the race environment is much more dynamic.
  * Black Holes
  * Asteriods
  * Gamma Burst Storm
  
### Non-functional Requirements
> Key NFRs and technical constraints

* Creating game does pose a technical challenge for the developers.
* The project is also constrained to using Unity’s physics engine as the team lacks the knowledge to create one on their own.
* The game may need a lot more time than anticipated given the lack of technical experience on the team.



## Domain

> Application Domain

![Domain Model](domainanalysis.png)

* _Player_
  * Races through space against other players or AI utilizing space ships.
* _Outer Space_
  * Has a starting point and end point that are manipulated through obstacles.
* _Ships_
  * Has weight that decides the appropriate attributes and equipment to go with it.
* _Weight Classes_
  * Determines the different type of equipment that is attached to the ship. Also holds a certain speed and torque for movement.
* _Equipment_
  * Protects against obstacles that can harm the ship.
  * _Boosts_
    * Increases speed of the ship for a specified amount of time.
  * _Tech_
    * Gives advantage over other ships for a specified amount of time.
* _Obstacles_
  * Impact equipment on ships
  * _Black Holes_
    * Damage ships to the point that they are completely destroyed.
  * _Asteroids_
    * Damage ships not at significantly as black holes, but throw them off balance.
  * _Gamma Bursts_
    * Damage ships at the least amount; they disrupt functionality in the ship for a specific amount of time.

### Core Design:

* Space Blitz, at heart, is a racing game located in outer space and possibly on planets with versatile climates and topography. The key difference in this design is that there is no specific path for the player to run on. There is simply a starting point and an end point to the race. The rest is an interaction between each player and the environment/map and among multiple players themselves. 

* The interaction between environment and the players involves skillful, strategic moves by the player in order to cross the distance in the least amount of time while avoiding potentially catastrophic damage due to obstacles present in the environment.

* The interaction among the players is somewhat inspired by the gameplay of the game called Blur. The player can aim and shoot with the help of a targeting system that will be controlled by the mouse while they race. 

### Plot & Settings:

* The game is located in an outer space environment giving the players a taste of the potential hazards that may befall them in space travel. The theme of the game is fast and furious as well as futuristic. All the tech and ships will be from an era where space travel is common. The sound and music will also support this fast and furious theme coupled with cool futuristic animations. 

* We have  basic plot involving humanity dividing up into and arms race sometime in the 3000’s. Further depth is yet to be given to this narrative.

### Gameplay:

* After entering the game the player will get to the main menu after witnessing a creative splash screen. The player will have 4 options, namely, ‘RACE’, ‘Save Configuration’, ‘Options’ and ‘Exit’.

* The player can use the ‘Exit’ option to exit the game immediately. They may use the options menu to customize the gameplay mechanics, the sound or the graphics of the game.(It should be detailed that what gameplay mechanics.?)

* The Save Configuration option allows players to choose and maintain a specific combination of the ship of their choice and the tech they choose to attach on that ship which can be directly loaded onto the Race menu to move ahead into the game without having to choose and re-attach everything again and again. 

* The Race option brings the player to a menu where they may choose the location where they wish to race and also what type of ship they wish to use for that particular map as well as specify what tech to use on that ship. Additionally, they can also choose what type of game mode to play. From here they can press the “Start Race” Button to move ahead to the actual racing.

![GamePlay](gameplay.png)

* Once the Race has started the players will use their tech and skills with those techs to gain an advantage over their opponents while trying to avoid being damaged from incoming fire from opponents as well as natural obstacles present in the environment like space rocks, gamma bolts etc. All tech uses battery power whose reserves depend on the size of the player’s ship. So the player must be mindful of not overusing the tech and make each application count.

* There are loading stations available for the player to go to and recharge their ship’s battery as well as health. They may also change the tech over at the loading stations at the cost of a small time penalty per tech change. The loading stations will be located a few ways away from the most direct routes to the end point so as to make the player be decisive if the they want to risk losing their ship and save some time or vice versa.



## Architecture

> Application Architecture.

### Summary

The following model shows a high-level view of the software architecture.Since the game offers a lot of options for the player to choose from before beginning the game, the most efficient architecture would involve data driven game logic. However, time constraint is a major issue, at least until the development of a  working prototype, and hence we will be using an unorthodox architecture. Instead of having a single gamelogic with all definitions within this logic, we will be developing individual game logics for each individual map as every map may require a different kind of interactive system. The choice of which game logic to use while running the game-loop depends on which map the player wishes to race on. We might begin with an abstract gamelogic class which will possess a few basic game rules and the common stuff and then have further subclasses for each map defining their different physics and rules of interaction and game-object maintenance. We will also have different types of ship classes to choose from for the player. Based on the player’s choice we will pass in the relevant code for ship class to interact with the game logic as shown below.

![Architecture Overview](architecture-tiers-and-layers.png)

### GameLogic Breakdown:

* The gamelogic will receive data from the input controllers as well as the ship class and will call multiple classes and their methods  to maintain the gamerules and the various logics of a particular map. It will also be responsible for updating and maintaining the gameobjects of the map as well as the relevant statistics of the ship based on its response to the input commands from the user. 

* Of the several classes it will be calling, the Input Response class will be responsible for responding to the data and then calling other relevant class methods to maintain and update the status of the ship (such as the ship manager) as well as detecting triggers using the trigger methods defined in the ‘Triggers’ class.

* The Ship manager class will be responsible for updating the status of the ship on the ship class as well as using the methods related to using the tech of the ship.

* The Map rules class will work with the Game objects class to maintain the rules of the game and so forth.

### User Interface Breakdown:

* The user interface will be a class which will be continuously updating the statistical data on the HUD of the screen view.

* It will also be responsible for maintaining the targeting cursor position on the player screens and playing other targeting related animations if and when needed based on the data it receives from the gamelogic.

* It will also be maintaining the minimap on the HUD constantly based on the data it receives from the gamelogic.

### Visuals BreakDown:

* The visuals will also be a class which will receive commands and data from the gamelogic and will help maintain the feel of environment surrounding the players ship.

* It will primarily be responsible for the creation and destruction of prefab instances of the assets representing various gameobjects.

* It will also be responsible for managing special effects & animations of interactions between the players ship and the environment.

### Ship  BreakDown:

* Ship class will be responsible for providing data relevant to the ship to the gamelogic. It will also allow the gamelogic class to change data as the game progresses.
* Additionally it will also possess the methods related to the techs used by the ship and provide them to the gamelogic to make use of as the player commands.


## Detailed Design

> Project Progression

![DetailedDesign](DetailedDesign.png)

## Issues and Risks

> Open issues, risks, and our plan to address them (or plan to research options)

Risks:

* AI coding is problem.
* Graphics and animations might not potentially be available upto specifications
* Implementing multiplayer might be unsuccessful due to limited networking knowledge
* Hard to test

