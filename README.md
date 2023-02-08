# DotNetMinefield
DotNetMinefield

## Requirements
In the game a player navigates from one side of a chessboard grid to the other whilst trying to avoid hidden mines. The player has a number of lives, losing one each time a mine is hit, and the final score is the number of moves taken in order to reach the other side of the board.  The command line / console interface should be simple, allowing the player to input move direction (up, down, left, right) and the game to show the resulting position (e.g. C2 in chess board terminology) along with number of lives left and number of moves taken.

## Assumptions
That we are working with a two dimensional grid / array of fixed size. This is fixed when a new game is created.

It's a fixed size so that you know in code if a user is at the outer bounds of the grid / array and cannot move any further up / down / left or right

## Requirements
When a move is made a global move counter must be incremented
While the game is in play we must track the players current position
A square / panel may have a mine or not
When a mine is hit the player lives number is decremented by one
When the number of players lives = 0 do we do anything?
Command Line application - no UI
Command Line application must allow input of up, down, left, right
Command line application must tell the player which square / panel they are currently on
