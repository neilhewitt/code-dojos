Battleships
===========

The goal of this Kata is to create a simple version of the game 'Battleships'

The game takes place on a 10x10 grid. Each player (traditionally only 2 are allowed) has his own grid. On their grid, the player places their ships. Different ship types take a different number of grid squares: for example, a battleship requires 4x1 squares. Ships can be placed horizontally and vertically, but not diagonally. No part of a ship may occupy the same space as another ship.

The ship classes are as follows (one of each type is allowed per player, players must place *all* ships for each game)

Aircraft Carrier - 5x1 squares

Battleship - 4x1 squares

Submarine - 3x1 squares

Destroyer - 3x1 squares

Patrol Boat - 2x1 squares


Stories
-------

** Story 1 **

As a player, I want to position each of my ships on the board using a coordinate system, so that I can play battleships.

** Story 2 **

As a player, I want to see a representation of the board showing where my ships are positioned, so that I can track my progress.

** Story 3 **

As a player, I want to be able to input my opponent's chosen square and be told if that is a hit or not, and see the square marked accordingly with an X or a O, so that I know which ships have been hit and 
where my opponent has already been.

** Story 4 **

As a player, I want to see a separate representation of the board showing the squares I have played and whether they were a hit or a miss, so I can track whether I have sunk any of my
opponent's ships.

** Story 5 **

As a player, when all of the squares of one of my ships have been hit by my opponent, I want to be told that the ship has been sunk, so I can tell my opponent.

** Story 6 **

As a player, when all of the squares of all of my ships have been hit by my opponent, I want to be told that I have lost the game, so I can tell my opponent they have won.




