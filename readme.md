## How To Run

Open Battleships/Battleships.sln in Visual Studio and run the program by pressing F5 or Ctrl+F5.

You may need to install .NET 7 for the program to work.

## Running The Tests

You can run the tests within the BattleshipTests project from within Visual Studio.

## Approach To Challenge

I made a couple of assumptions while writing this:

- The board will always be 10x10 (I could have added support for different sized boards but since this size was specified in the challenge I didn't want to add unnecessary complexity).
- I've written the code like I would a real piece of code (sensibly laid-out, with tests etc), but I have still made context-appropriate decisions (i.e. this is a simple console application where performance will never be a bottleneck or an important consideration).

I've added comments throughout the code explaining reasoning; I wouldn't necessarily put these in actual code, although some I might if I thought it was necessary to make the code clearer.
