//FILE        : Triangle.cpp
//PROJECT     : PROG2020-19F-Sec1 - Lab 02
//PROGRAMMER  : John Fedoriw
//DATE        : Oct. 09, 2019
//DESCRIPTION : This file contains the test harness to instantiate objects of the Triangle class. 
//              It holds the libraries, constants, and class definitions for the Shape Abstract class.


#pragma once



#include <string>
#include <string.h>
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <new.h>

using namespace std;



class Triangle
{
private:
	string name; ///<Type of shape
	string colour; ///<Colour of shape


	
	int hypotenuse;
	int sideA;
	int sideB;
	int angleA;
	int angleB;
	int angleC;

public:


	Triangle(string newName, string newColour); ///<<b>Constructor,</b>
	~Triangle(void); ///<<b>Destructor</b>
	int GetHypotenuse(void);
	int GetSideA(void);
	int GetSideB(void);
	int GetAngleA(void);
	int GetAngleB(void);
	int GetAngleC(void);
	void SetHypotenuse(int);
	void SetSideA(int);
	void SetSideB(int);
	void SetAngleA(int);
	void SetAngleB(int);
	void SetAngleC(int);
	int CalcHypotenuse(void) = 0;
	int CalcArea(void) = 0;
	int CalcAngle(void) = 0;

	//length of the hypotenuse through a familiar, old equation.a² + b² = c²
	//When this is a right triangle, and sides Aand B are given as above, the area of the triangle should also be reported(area = 0.5 * AB in this case).
	//If the user provides any 2 interior angles of a triangle(does not need to be right - angle), Triangle can provide the missing angle

	/*string GetColour(void) const; ///<<b>Assessor for colour data member</b> 
	void SetColour(string& newColour); ///<<b>Mutator for colour data member</b>
	virtual float Perimeter(void) = 0; ///<<b>Virtual method to display descendant's perimeter</b>
	virtual float Area(void) = 0; ///<<b>Virtual method to display descendant's area</b> 
	virtual float OverallDimension(void) = 0; ///<<b>Virtual method to display descendant's overall dimension</b>*/

};

/*
You must have a class called ‘Triangle’.For our purposes a Triangle needs to know about the lengths of its sides, and its internal angles.You may not need to implement all characteristics of a triangle within this class – what is key is the behaviour we’ll outline next.
2)      An object of class Triangle can be queried for some important details, when the user provides some preliminary information(e.g.through the UI component of your application)
When this is a right triangle, the user can supply the lengths of sides Aand B.Triangle can then be queried to provide the length of the hypotenuse through a familiar, old equation.a² + b² = c²
When this is a right triangle, and sides Aand B are given as above, the area of the triangle should also be reported(area = 0.5 * AB in this case).
If the user provides any 2 interior angles of a triangle(does not need to be right - angle), Triangle can provide the missing angle(as all interior angles of a triangle must sum to 180 degrees).
*/