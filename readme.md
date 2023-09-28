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

## Feedback I Recevied

I received the following feedback on this code:

>Pros:
>- Good readme
>- There are tests and they pass
>- It handles invalid coordinates properly
>- Code easy to read and follow
>- Good use of random

I also received the following feedback. For fairness I'm going to add some of my own comments (I didn't actually say/send any of this to them):

>Game is not to spec. The candidate wrote a two sided game. Test specification asks for a simpler one-sided game.

I have to respectfully disagree with this. The task stated: _Create an application to allow a single human player to play a one-sided game of Battleships against ships placed by the computer._ I don't think the program I wrote is a two-sided game; it is a one-sided game against the computer (I interpreted "one-sided" as meaning "one player").

Perhaps they meant that it was supposed to be a game where the player doesn't have any ships (only the computer does), but if so then I think their task description was a bit vague. In the task they linked a copy of the official rules of the game Battleships, so this suggested to me that what they wanted was a full version of the game Battleships.

>Binaries pushed to the repo. No ignore file.

This is true, and this would obviously not be good in a commercial environment, but this was a deliberate choice I made; this is just a demo, so it's a bit unnecessary. I have written plenty of .gitignore files in the past. It didn't ask for this in the task description.

>Exception driven flow with "catch all" try: (InputController.ParseVector2String, Vector2Int.ParseVector2Int)

This is a valid point. I have refactored the program so as not to use exceptions in this part. It actually even made the code a bit simpler probably.

>Several tests like TryAddShip_MustBeWithinBoard that could use different test cases to cover all scenarios instead of repeating the code again and again.

This is technically true although I think it's a bit picky. Maybe iterating over a test table with a loop would have worked _slightly_ better here. But I think the test as it is does a good job of testing most of the scenarios, and no doubt I was influenced by the fact that this is not a serious application. Moreover, I don't think it's good practice to spend ages writing tests covering every imaginable scenario for every function in the codebase (Unless you're programming something that can never afford to fail like a bank API or a nuclear bomb!). I think you should focus most of your efforts on the critical parts. 

Also, given that it is a game, one has to realise that at least some of the testing is done via playtesting, not just unit tests, so again, there is no point just writing huge unit tests. The test is only 25 lines long so I think to say 'repeating the code again and again' is exaggerating a bit. Other tests like ToVector2Int_Works do use test tables.

>It does not detect coordinates already used.

This was a deliberate design choice. If a player attacks the same place twice, then it's a miss (the player can see the board, so they only have themselves to blame for this). It didn't say in the specification that the game had to detect coordinates already used.

When the AI takes their turn, it purposely avoids coordinates already used.
