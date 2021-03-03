# maze-blast-game
A simple dungeon maze game in C#. A Windows Forms app using GDI+. This is a work in progress- improvements on the way!

## Introduction
This little game started as a final assignment to my second-year OOP course, but it has bloomed into an ongoing project.

## Technologies
* Microsoft Visual Studio Community 2019 Version 16.7.3
* Microsoft .NET Framework Version 4.8.04.084
* MedallionRandom v1.1.0 via NuGet

## Setup
NOTE: There appears to be an issue with the Medallion package that is preventing program function - this might not occur for all users.

## Gameplay
The player must traverse the maze and reach the door without being stopped by the monsters.

![screenshot of maze](/Images/MazeBlast2.PNG)

Watch out! The monsters have two ways to win - they can catch the player, or make it to the door first.
The monsters can also teleport!

![screenshot of maze](/Images/MazeBlast3.PNG)

When the player moves in one direction, the monsters move in the opposite direction - so watch the whole maze, or you'll walk a monster straight to the door!

![screenshot of maze](/Images/MazeBlast7.PNG)


## Planned Changes / Bug Fixes
* Fix maze sizing issue
* Improved monster movement and distribution - fix overlapping monster issue 
* Higher-quality sprites
* Randomized mazes
* New kinds of monsters with different motion patterns
* Animation / sounds for win / lose scenarios
