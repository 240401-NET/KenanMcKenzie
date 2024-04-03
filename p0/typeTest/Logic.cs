namespace typeTest;

class Logic
{
  //set game state 
  //make separate class for reading and splitting json or do it here

  //Methods
  //display instructions - start, quit, leaderboard, pause?
  //startGame -> new Game(), sets time to 60 - Api.getQuotes(), new StopWatch(), score to 0, initials to empty string, displayText(), isActive to true
  //displayText -> deserialize from saved json, split into senetences, display 1 unused sentence (maybe split into more methods)
  //endOfSentence -> when input == split sentence.length..reset displayText and what the user has typed so far. (maybe don't display user text like typemonkey)
  //checkInput -> if inputPosition == sentence.charAt(inputPosition + 1?) rightKey() else wrongKey()
  //rightKey -> score += 1, char to green
  //wrongKey -> score -= 1, char to red
  //endGame -> prompts for initials, shows spot in leaderboard, isActive false
}