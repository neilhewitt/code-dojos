Bowling scorer
==============

The goal of this Kata is to create a scoring system for ten-pin bowling.

The scoring rules of ten-pin are simple in principle but have a few gotchas that might trip you up. Here are the rules in summary:

Each game, or "line" of bowling, includes ten turns, or "frames" for the bowler. 
• In each frame, the bowler gets up to two tries to knock down all the pins. 
• If in two tries, he fails to knock them all down, his score for that frame is the total number of pins knocked down in his two tries. 
• If in two tries he knocks them all down, this is called a "spare" and his score for the frame is ten plus the number of pins knocked down on his next throw (in his next turn). 
• If on his first try in the frame he knocks down all the pins, this is called a "strike". His turn is over, and his score for the frame is ten plus the simple total of the pins knocked down in his next two rolls. 
• If he gets a spare or strike in the last (tenth) frame, the bowler gets to throw one or two more bonus balls, respectively. These bonus throws are taken as part of the same turn. If the bonus throws knock down all the pins, the process does not repeat: the bonus throws are only used to calculate the score of the final frame. 
• The game score is the total of all frame scores. 

Stories
-------

** Story 1 **

As a bowler, when I have bowled a frame, I want to be able to input my score into the program so that I can see my overall score so far.

** Story 2 **

As a bowler, when I realise I have incorrectly entered data for one or more frames, I want to be able to edit the scores for any frame and then see my recalculated score so I can be sure my score is accurate.

** Story 3 **

As a bowler, when I have completed a game, I want to be able to see my scores for each frame listed in a printable format so I can print it out and brag to my friends about how good I am.

