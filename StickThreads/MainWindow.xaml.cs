// FILE          :	StickThreads.cs
// PROJECT       :	PROG SENG2121-19F-Sec1 - Assignment #4  
// PROGRAMMER    :	John Fedoriw
// Date          :	Oct. 17/, 2019
// DESCRIPTION   :	This program allows the user to generate sticks that may be spawned
//                  by the user. These sticks spin and resize randomly. 
//                  They can be paused and shut down by the user.
//                  They should have some persistance (a trail) controlled by the user via a slider.
//                  The last requirements (the trail and slider) are not working.
//
//                  Code for the btnPause_Click(), btnStart_Click(), btnResume_Click(), btnStop_Click and 
//                  LineMover() were repurposed (with major modification) from "WinProg-M06-A04-Threads-and-Tasks"
//                  by A. Stoltchnev (Professor), Oct 12, 2019 [Online]. 
//                  Available at: https://www.youtube.com/watch?v=s8YcbwVl-HI

//                  Code to get a random brush color from Stackoverflow    
//                  Available at: https://stackoverflow.com/questions/24832604/random-colour-in-c-sharp-wpf





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StickThreads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ThreadList keeps track of all the started threads
        private static List<Thread> threadList = new List<Thread>();
        // LineList keeps track of all Lines added to the Canvas
        private static List<Line> lineList = new List<Line>();
        //to enable lines to move
        volatile bool linesMove;
        //to check if the program is not paused
        volatile bool runState; 
        
        public MainWindow()
        {
            InitializeComponent();
        }



        //NAME    : btnPause_Click
        //PURPOSE : An event handler for the UI's Pause button. 
        //          Calls the method which pauses the stick's movement on the screen.
        //INPUTS  : object sender : The triggering object (btnPause). 
        //        : RoutedEventArgs e   - Any event trigger arguments.
        //RETURNS : void
        public void btnPause_Click(object sender, RoutedEventArgs e)
        {
            runState = false;
        }



        //NAME    : btnStart_Click
        //PURPOSE : An event handler for the UI's Start button. 
        //          Calls the method which starts a stick (and its trail) on the screen.
        //INPUTS  : object sender : The triggering object (btnStart).
        //        : RoutedEventArgs e   - Any event trigger arguments.
        //RETURNS : void
        
        public void btnStart_Click(object sender, RoutedEventArgs e)
        {
            linesMove = true;
            runState = true;

            // New Lines can only be added if the program is not paused
            if (runState)
            { 
                double newX1 = 0;
                double newX2 = 0;
                double newY1 = 0;
                double newY2 = 0;


                //Initalize random number generator
                Random randNum = new Random();

                //Generate random numbers for each co-ordinate of the stick
                newX1 = (double)randNum.Next(0, (int)StickArea.ActualWidth);
                newY1 = (double)randNum.Next(0, (int)StickArea.ActualHeight);
                newX2 = (double)randNum.Next(0, (int)StickArea.ActualWidth);
                newY2 = (double)randNum.Next(0, (int)StickArea.ActualHeight);

                //get a random brush color
                Brush rndColor = new SolidColorBrush(Color.FromRgb((byte)randNum.Next(1, 255),
                (byte)randNum.Next(1, 255), (byte)randNum.Next(1, 255)));

                //make the trail
                int TrailValue = 50;
                
                for (int x = 0; x < TrailValue; x++)
                {
                    //make a new line
                    Line newLine = new Line
                    {
                        Stroke = rndColor,
                        StrokeThickness = 1,
                        X1 = newX1 + (x * 2),
                        Y1 = newY1 + (x * 2),
                        X2 = newX2 + (x * 2),
                        Y2 = newY2 + (x * 2)
                    };

                    Thread move = new Thread(new ParameterizedThreadStart(LineMover));

                    StickArea.Children.Add(newLine);

                    move.Start(newLine);
                    lineList.Add(newLine);
                    threadList.Add(move);
                }
            }
        }



        //NAME    : btnResume_Click
        //PURPOSE : An event handler for the UI's Resume button. 
        //          Calls the method which resumes movement of paused sticks (and their trails) on the screen.
        //INPUTS  : object sender : The triggering object (btnResume).
        //        : RoutedEventArgs e   - Any event trigger arguments.
        //RETURNS : void
        public void btnResume_Click(object sender, RoutedEventArgs e)
        {
            if (!runState)
            {
                foreach (Thread t in threadList)
                {
                    t.Interrupt();
                }
            }
            runState = true;
        }



        //NAME    : btnStop_Click
        //PURPOSE : An event handler for the UI's Resume button. 
        //          Calls the method which clears all sticks (and their trails) from the screen.
        //INPUTS  : object sender : The triggering object (btnStop).
        //        : RoutedEventArgs e   - Any event trigger arguments.
        //RETURNS : void
        public void btnStop_Click(object sender, RoutedEventArgs e)
        {
            linesMove = false;
            for (int i = 0; i < lineList.Count; i++)
            {
                StickArea.Children.Remove(lineList[i]);
            }
        }



        //NAME    : LineMover
        //PURPOSE : An function which  determines the random direction of movement and moves the inputted stick
        //          across the screen.
        //INPUTS  : object inputThread : The stick (a line) created by btnStart.
        //RETURNS : void
        public void LineMover(object inputThread)
        {
            //intialize direction controllers

            double XV1 = 1.0;

            double XV2 = 1.0;

            double YV1 = 1.0;

            double YV2 = 1.0;

            Line newLine = (Line)inputThread;

            while (linesMove)

            {

                if (runState)

                {

                    this.Dispatcher.Invoke(() =>

                    {

                        newLine.X1 += XV1;

                        newLine.Y2 += YV2;



                        if (newLine.X1 < 0 || newLine.X1 > StickArea.ActualWidth)

                        {

                            XV1 *= -1;

                        }



                        if (newLine.X2 < 0 || newLine.X2 > StickArea.ActualWidth)

                        {

                            XV2 *= -1;

                        }



                        if (newLine.Y1 < 0 || newLine.Y1 > StickArea.ActualHeight)

                        {

                            YV1 *= -1;

                        }

                         if (newLine.Y2 < 0 || newLine.Y2 > StickArea.ActualHeight)
                         {
                             YV2 *= -1;
                         }

                    });

                     Thread.Sleep(10);
                }
            }
        }



        //This was to control the trail length. It does not work.
        public void sldrDelay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}


                    