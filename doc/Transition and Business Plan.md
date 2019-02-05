# Transition & Business Plan
> Assess the project’s readiness tomove into production

# Milestones
> Details for each milestone

## Milestone 1

To have a prototype that shows everything possible within the game from a single user standpoint which so far only includes movement and shooting. 
This is necessary so that the game can be pitched to publishers/studios for funding.

Feature List for this Milestone:
* Should have fixed all the open issues until that point. 
* Should have proper distinction between various ship classes, with significant differences among their respective PROs and CONs.
* Menu system should be polished.
* Should have basic tech attachments with passable art, animation and SFX.
* Should have shields and batteries as resources apart from ship health.
* Should have at least one reasonably large level with a just-manageable physics system to get a proper feel of the environment.
* Should have a more polished shooting system compared to the currently implemented system.
* Should have a little more polished in-game UI.

## Milestone 2

To be able to demo active gameplay during some of the consumer game conventions, with AI as well as with multiplayer. The demo should have a few different maps and a few different game modes to display its potential for limitless fun. 
The milestone is within reason since now the project should have proper funding to get good artists, designers, programmers and testers.

Feature List for this Milestone:
* Should have fixed all the open issues until that point. 
* Should have proper distinction between various ship classes, with significant differences among their respective PROs and CONs.
* Menu system should be polished.
* Should have basic tech attachments with passable art, animation and SFX.
* Should have shields and batteries as resources apart from ship health.
* Should have at least one reasonably large level with a just-manageable physics system to get a proper feel of the environment.
* Should have a more polished shooting system compared to the currently implemented system.
* Should have a little more polished in-game UI.

## Milestone 3

To have a fully deployable game with proper servers to support online play as well as localization support for play in multiple languages. 
This milestone is achievable given that the demo went as expected and pleased the stakeholders/publisher of the project so that they continue to fund and support the project.


Feature List for this Milestone:
* At this point, the game should be completely feature ready at least from a single player standpoint.
* The game should have an accounts features which allows people to create unique IDs to play with in multiplayer mode.
* The game should allow for multiplayer competition with proper server allocation and match finding.
* The game should have undergone thorough closed/open beta testing followed by proper regression testing in order to be fully deployable as a mass multiplayer online game.
* The game should be available in multiple languages based on the popular markets for this type of game.
* The game should have a marketing campaign based on the available funds.
* The game should be on sale by the planned release date.

## Milestone 4

To port the game onto next-generation console platforms and possibly into VR.
This milestone is only possible if the game achieves significant success after its release on the PC platform.

Feature List for this Milestone:
* The game should be playable on major consoles, like Xbox and PlayStation (and possibly Nintendo, if they want it).
* The game should at least be able to allow a single level in VR mode.
  
# Schedule
> Rough schedule for our overall production

## Milestone 1

8 Week Timeline (End of January 2019)

## Milestone 2

16 Week Timeline (End of May 2019)

## Milestone 3

16 Week Timeline (End of September 2019)

## Milestone 4

30 Week Timeline (End of May 2020)

# Risks and Open Issues
> Open issues, risks, and our plan to address them

* AI Balancing can be difficult
  * We don’t have fixed paths in our game, so how to design the movement of AI can be difficult. We can’t use the path-finding algorithm which Unity3D has so we must find a suitable algorithm for path-finding. And we need to balance the difficulty of AI to challenge the players, which can keep players engaged.
  * Potential solution
    * Waypoints
* Physics Engine
  * We want to imitate the environment of the space, so there will be moving asteroids, black holes and other heavenly bodies. We need an astronomy specialist to help us build physics engine to make the environment more real.
* Networking for multiplayer mode
  * We are a team lacking the experience in server development. So it can be hard for us to make a networking which can accommodate thousands or millions of players. Also we need more people to do the testing on networking.