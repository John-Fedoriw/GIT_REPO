// FILE        : Stick.cs
// DESCRIPTION : This file creates a stick at a random position on the screen
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Collections;

namespace Sticks
{
    class Stick
    {
        private double x1;
        private double x2;
        private double y1;
        private double y2;

        private double windowWidth = 0;
        private double windowHeight = 0;

        public double X1
        {
            get { return this.x1; }
            set { this.x1 = value; }
        }

        public double Y1
        {
            get { return this.y1; }
            set { this.y1 = value; }
        }

        public double X2
        {
            get { return this.x2; }
            set { this.x2 = value; }
        }

        public double Y2
        {
            get { return this.y2; }
            set { this.y2 = value; }
        }

        public Stick(double windowWidthIn, double windowHeightIn)
        {
            //Set the window height and window width data members to the values provided
            this.windowWidth = windowWidthIn;
            this.windowHeight = windowHeightIn;
        }

        /*
        * NAME :    CreateLine
        * PURPOSE : Creates a line at a random location
        * INPUTS :
        *   NONE
        * OUTPUTS :
        *   NONE
        * RETURNS :
        *   void
        */
        public Line CreateLine()
        {
            //Generate the two random x and y co-ordinates
            this.GenerateRandom();
            //Draw a line to the co-ordinates specified in randomNumbers [0] - [3]
            Line canvasLine = new Line();
            //Random myRandom = new Random();
            //float red = 0;
            //float green = 0;
            //float blue = 0;
            //red = myRandom.Next(0, 255);
            //green = myRandom.Next(0, 255);
            //blue = myRandom.Next(0, 255);
            //a = myRandom.Next(0, 255);
            //canvasLine.Stroke = new Pen(Color.FromRgb(red, green, blue), 2)
            canvasLine.Stroke = Brushes.Red;
            canvasLine.X1 = this.x1;
            canvasLine.Y1 = this.y1;
            canvasLine.X2 = this.x2;
            canvasLine.Y2 = this.y2;


            canvasLine.StrokeThickness = 1;

           return canvasLine;
        }

        /*
        * NAME :    CreateLine
        * PURPOSE : Creates a line at a specified location
        * INPUTS :
        *   double x1 - The X1 value of the line to draw
        *   double y1 - The Y1 value of the line to draw
        *   double x2 - The X2 value of the line to draw
        *   double Y2 - The Y2 value of the line to draw
        * OUTPUTS :
        *   NONE
        * RETURNS :
        *   void
        */
        public Line CreateLine(double x1, double y1, double x2, double y2)
        {
            //Draw a line to the co-ordinates provided
            Line canvasLine = new Line();
            canvasLine.Stroke = Brushes.Red;
            canvasLine.X1 = x1;
            canvasLine.Y1 = y1;
            canvasLine.X2 = x2;
            canvasLine.Y2 = y2;


            canvasLine.StrokeThickness = 1;
            return canvasLine;
        }

        /*
        * NAME :    GenerateRandom
        * PURPOSE : Generates two random X and Y co-ordinates for the stick which are greater than 0 and less than the width/height of the canvas
        *           
        * INPUTS :
        *   NONE
        * OUTPUTS :
        *   NONE
        * RETURNS :
        *   VOID
        */
        public void GenerateRandom()
        {
            //Initalize random number generator
            Random randNum = new Random();
            //Generate random numbers for each co-ordinate of the stick

            this.x1 = randNum.Next(0, (int)this.windowWidth);
            this.x2 = randNum.Next(0, (int)this.windowWidth);
            this.y1 = randNum.Next(0, (int)this.windowHeight);
            this.y2 = randNum.Next(0, (int)this.windowHeight);
        }

        public Line MoveLine(double x1, double y1, double x2, double y2)
        {
            //Draw a line to the co-ordinates provided
            Line canvasLine = new Line();
            canvasLine.Stroke = Brushes.Red;
            canvasLine.X1 = x1;
            canvasLine.Y1 = y1;
            canvasLine.X2 = x2;
            canvasLine.Y2 = y2;


            canvasLine.StrokeThickness = 1;
            return canvasLine;
        }

    }
}
