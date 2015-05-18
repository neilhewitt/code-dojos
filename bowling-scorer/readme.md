Bowling scorer
==============

The goal of this Kata is to create a scoring system for ten-pin bowling.

The scoring rules of ten-pin are simple in principle but have a few gotchas that might trip you up. Here are the rules in summary:

Each game, or "line" of bowling, includes ten turns, or "frames" for the bowler.
 
- In each frame, the bowler gets up to two tries to knock down all the pins. 
- If in two tries, he fails to knock them all down, his score for that frame is the total number of pins knocked down in his two tries. 
- If in two tries he knocks them all down, this is called a "spare" and his score for the frame is ten plus the number of pins knocked down on his next throw (in his next turn). 
- If on his first try in the frame he knocks down all the pins, this is called a "strike". His turn is over, and his score for the frame is ten plus the simple total of the pins knocked down in his next two rolls. 
- If he gets a spare or strike in the last (tenth) frame, the bowler gets to throw one or two more bonus balls, respectively. These bonus throws are taken as part of the same turn. If the bonus throws knock down all the pins, the process does not repeat: the bonus throws are only used to calculate the score of the final frame. 
- The game score is the total of all frame scores.

Scores are represented by one or two alphanumeric characters, one for each ball bowled. So knocking down 4 pins followed by another 3 would be represented as '43' and would score 8 points. Knocking down 2 pins followed by
the remaining 8 pins (a spare) would be '2/' (the forward slash represents the spare) and score 10 points plus the value of the next ball bowled. A strike would be represented as 'X'. A ball that brings down no
pins is represented as a dash '-', so 4 pins followed by 0 pins would be '4-'. You should place a pipe / bar character | between each frame. So a complete game could be represented as:

48|3/|X|X|9/|-/|-9|8/|XXX

The tenth and final frame may have up to three characters, because you can potentially throw three balls. So a strike followed by an 8-spare would be 'X8/', or zero-spare plus 8 would be '-/8'.



Stories
-------

** Story 1 **

As a bowler, when I have bowled a frame, I want to be able to input my score into the program so that I can see my overall score so far.

** Story 2 **

As a bowler, when I realise I have incorrectly entered data for one or more frames, I want to be able to edit the scores for any frame and then see my recalculated score so I can be sure my score is accurate.

** Story 3 **

As a bowler, when I have completed a game, I want to be able to see my scores for each frame listed in a printable format so I can print it out and brag to my friends about how good I am.

