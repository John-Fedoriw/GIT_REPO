<!DOCTYPE html>

<!--  
FILE        : hilo.asp
PROJECT     : a04.html Assignment 4 Hi-Lo
PROGRAMMER  : John Fedoriw
DATE        : Oct 30th, 2019
DESCRIPTION : This page is the server side page for a typical Hi-Lo game, where the 
              player guesses values in a specific range until the correct number is found. 
              It is written using only asp and HTML and does the logic for the game play.
-->

<html>
<head>
<style>

/* creates container box for form */

    .container {

  border-radius: 50px;
  
  padding: 80px;

  background-color: #ffcc99;

  font-family:Arial,Helvetica,sans-serif;
  
  font-size:large
  
}

/* change style of text box */



input[type=text], select, textarea {

  width: 25%;

  padding: 16px;

  border: 2px solid #ccc;

  border-radius: 4px;

  border-style: solid;

  border-color: #ff3300;

  resize: vertical;

  background-color: #f2f2f2;
  
  font-family:Arial,Helvetica,sans-serif;
  
  font-size:large

}


/* stylizes buttons used in the form*/

input[type=button], input[type=submit] {

  background-color: #ff9900;

  border: none;

  color: white;

  padding: 16px 32px;

  text-decoration: none;

  margin: 4px 2px;

  cursor: pointer;

  font-size:large


}


  </style>
    <title>Hi-Lo Game</title>

    <script>
                //----------------------------------------------------------------------------------
        // NAME:    validateNumber
        // PURPOSE: This function is called when the "myButton" button is clicked to submit
        //          a number. Its main purpose is to determine if the input data is a valid
        //          number type and to pass it to the next applicable function.
        // INPUTS:  None.
        // RETURNS:
        //----------------------------------------------------------------------------------

        function validateNumber()
        {
        	var inputNum = myPrompt.value;
        	feedback.innerHTML = "";

        	//verify input is numbers using regex
        	var VerifyNum = /^\d+$/;

        	if (inputNum.match(VerifyNum))
        	{
        		if (inputNum < 1)//entries < 1 are invalid
        		{
        			feedback.innerHTML = "0 is an invalid entry";
        			myPrompt.value = "";
        		}
        		else if ((promptFlag == 1) && (inputNum == 1))//entries of 1 are invalid for the maximum number
        		{
        			feedback.innerHTML = "Please enter a number > 1";
        			myPrompt.value = "";
        		}
        		else if ((promptFlag == 1) && (inputNum >= 1))//set the maximum number and create a randomn one
        		{
       	 			maxNum = inputNum;
        			randNum = generateRandomNum(maxNum)

        			//change the user display
        			feedback.innerHTML = "Your allowable guessing range is any value between 1 and " + maxNum;
       			 	promptLine.innerHTML = name + ", please guess a number."
        			myPrompt.value = "";
        			promptFlag = 2;
        			mySubmit.value = "Make this Guess"

        		}
        		else if (promptFlag <= 2)//we pass a number to check for the guess
        		{
        		checkGuess(inputNum);
        		}
        	}
        	else//input is invalid
        	{
        		feedback.innerHTML = "Please enter an integer > 1";
        		myPrompt.value = "";
        	}
        }


        //----------------------------------------------------------------------------------
        // NAME:    generateRandomNum
        // PURPOSE: This function is called by the validateNumber function to create a
        //          random number which is the number the player must guess. It must be >
        //          1 and < the maximum number chosen by the player.
        // INPUTS:  The maximum number chosen by the player.
        // RETURNS: A randomly generated number.
        //----------------------------------------------------------------------------------

        function generateRandomNum(maxNum)
        {
        	var minNum = 1;
        	// generate random number between 1 &  maxNum
       	 	let myRandNum = Math.floor(Math.random() * (maxNum - minNum)) + minNum;
        	return myRandNum;
        }

        //----------------------------------------------------------------------------------
        // NAME:    checkGuess
        // PURPOSE: This function is called whem the "myButton" button is clicked to submit
        //          a guessed number. Its main purpose is to check the number against the
        //          maximum number and display the new number range or inform the player they
        //          won.
        // INPUTS:  The guesss number chosen by the player.
        // RETURNS: None.
        //----------------------------------------------------------------------------------

        function checkGuess(inputNum)
        {
        	guessNum = inputNum;

        	if (guessNum == randNum)//the player guess equals the random number
        	{
        		feedback.innerHTML = "You win!! You guessed the number!!";
        		promptFlag = 3;
       		 	mySubmit.value = "Play Again";
        		myPrompt.value = "";
        		promptLine.innerHTML = "";
        		document.body.style.backgroundColor = "orange";
        	}
        	else if (guessNum < randNum) //the player guess is lower than the random number
       	 	{

        	if (guessNum < minNum)//the player selects an invalid number (too low)
        	{
        		feedback.innerHTML = "Your allowable guessing range is any value between " + minNum + " and " + maxNum + ", " + guessNum + " is too low";
        	}
        	else//the player selects a valid number
        	{
        		minNum = parseInt(guessNum);
        		minNum++;
        	
			if (minNum == maxNum)//the number range is only 1 number
        		{
        			feedback.innerHTML = "Your allowable guessing range is " + maxNum;
       		 	}
        		else
        		{
        			feedback.innerHTML = "Your allowable guessing range is any value between " + minNum + " and " + maxNum;
        		}
        	}
        	
		myPrompt.value = "";

        	}
        	else if (guessNum > randNum)//the player guess is greater than the random number
        	{
        		if (guessNum > maxNum)//the player selects an invalid number (too high)
        		{
       			 	feedback.innerHTML = "Your allowable guessing range is any value between " + minNum + " and " + maxNum + ", " + guessNum + " is too high";
        		}
        		else//the player selects a valid number
        		{		
        		maxNum = parseInt(guessNum);
        		maxNum--;


        		if (minNum == maxNum)//the number range is only 1 number
        		{
        			feedback.innerHTML = "Your allowable guessing range is " + maxNum;
        		}
        		else
        		{
        			feedback.innerHTML = "Your allowable guessing range is any value between " + minNum + " and " + maxNum;
        		}
        	}

        	myPrompt.value = "";
        	}
        }
    </script>

<body>
    

    <center><h1 align="center" style="font-family:Arial,Helvetica,sans-serif">Hi-Lo Game</h1></center>

   <%
	  ' get the Request.QueryString object 

       formX = Request.Form("prompt")
	   

   <div class="container" id="input" name="Input">

   <!-- Some general information to prompt user -->
    <p class="a">
        <center>
            <div id="promptLine">Please enter your name :</div>
            <div id="myBox"><input id="myPrompt" type="text" placeholder="John or John Doe" name="prompt" required /></div>
            <div id="myButton"><input id="mySubmit" input type="button" value="Submit" onclick="submitInput(myPrompt.value)" /></div>
        </center>
    </p>
    <p>
        <center><div id="feedback"></div></center>
    </p>

  </div>
</body>
</html>