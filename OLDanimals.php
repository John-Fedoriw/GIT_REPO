<!DOCTYPE HTML>

<!--  
FILE        : animals.php
PROJECT     : a03.Animal-Serve – website developed in CGI and PHP
PROGRAMMERS : John Fedoriw, Nick Iden
DATE        : Oct. 10th, 2019
DESCRIPTION : This HTML page will display the user selected animal from php-zoo.html.
              It will then display a picture of the selected animal and 
              provide some pertinent facts regarding it.
-->

<html>
<head>
<meta charset ="UTF-8">
<title>Animal-Serve</title>

<script type="text/javascript">

	// define variables
	$userName = $_POST["name"];
	$userAnimal = $_POST["userAnimal"];
	$picture = "";
	$file = "";
//----------------------------------------------------------------------------------
// NAME:    determineOutput()
// PURPOSE: Parses the txt file and  
//          Form button is clicked.
// INPUTS:  None.
// RETURNS: None.
//----------------------------------------------------------------------------------
<?php
function determineOutput() 
{
    $animalPic = "";
    $animalTxt = "";
    $userAnimal = $_POST["userAnimal"];

    if ($userAnimal == "Cat")
	{
		$animalPic = "cat.PNG";
		$animalTxt = "cat.Txt";
	}
	elseif ($userAnimal == "Dog")
	{
		$animalPic = "dog.PNG";
		$animalTxt = "dogTxt";
	}
	elseif ($userAnimal == "Gorilla")
	{
		$animalPic = "gorilla.PNG";
		$animalTxt = "gorilla.Txt";
	}
	elseif ($userAnimal == "Horse")
	{
		$animalPic = "horse.PNG";
		$animalTxt = "horse.Txt";
	}
	elseif ($userAnimal == "Mouse")
	{
		$animalPic = "mouse.PNG";
		$animalTxt = "mouse.Txt";
	}
	else
	{
		$animalPic = "Snake";
		$animalTxt = "snake.Txt";
	}
}
?>

</script>
</head>

<body>
	<h1 align="center"><b>The Zoo</b></h1>

	
	
	<p align="center">>Welcome <?php echo $_POST["userName"]; ?>!!</p><br>

		<?php determineOutput()?>
		<table id="inputTable" valign="top">
				<col width="300">
				<col width="300">
        			<tr>	
            				<td><img src="the Zoo/".$animalPic alt="The animal is asleep"width="500" height="333"></td>
					<td> <!-- 
<?php
					$myfile = fopen("theZoo/".$animalTxt, "r") 
					or die("Unable to open file!");
					echo fread($file,filesize("theZoo/".$animalTxt));
					fclose($file);
					?> -->
</div></td>
                                        <br/>
				</tr>
					

</body>
</html> 

