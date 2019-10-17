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

        volatile bool linesMove; //to enable lines to move

        volatile bool runState; //to check if the program is not paused
        
        public MainWindow()
        {
            InitializeComponent();
        }

        void btnPause_Click(object sender, RoutedEventArgs e)
        {
            runState = false;
        }

        
        void btnStart_Click(object sender, RoutedEventArgs e)
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

                //https://stackoverflow.com/questions/24832604/random-colour-in-c-sharp-wpf
                Brush rndColor = new SolidColorBrush(Color.FromRgb((byte)randNum.Next(1, 255),
                (byte)randNum.Next(1, 255), (byte)randNum.Next(1, 255)));

                ////make a starting line
                Line startingLine = new Line
                {
                    Stroke = rndColor,
                    StrokeThickness = 1,
                    X1 = newX1,
                    Y1 = newY1,
                    X2 = newX2,
                    Y2 = newY2,
                };

                StickArea.Children.Add(startingLine);


                Thread move = new Thread(new ParameterizedThreadStart(LineMover));
                move.Start(startingLine);
                lineList.Add(startingLine);
                threadList.Add(move);

                ////////make the trail
                //int TrailValue = 50;

                //////insert initial line delay 
                //int delay = 5;

                //for (int x = 0; x < TrailValue; x++)
                //{
                //    //make a new line
                //    Line newLine = new Line
                //    {
                //        Stroke = rndColor,
                //        StrokeThickness = 1,
                //        X1 = newX1 + delay,
                //        Y1 = newY1 + delay,
                //        X2 = newX2 + delay,
                //        Y2 = newY2 + delay,
                //    };

                //    Thread nextMove = new Thread(new ParameterizedThreadStart(LineMover));

                //    StickArea.Children.Add(newLine);

                //    nextMove.Start(startingLine);
                //    lineList.Add(newLine);
                //    threadList.Add(nextMove);
                //}

            }
        }

        void btnResume_Click(object sender, RoutedEventArgs e)
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

        void btnStop_Click(object sender, RoutedEventArgs e)
        {
            linesMove = false;
            for (int i = 0; i < lineList.Count; i++)
            {
                StickArea.Children.Remove(lineList[i]);
            }
        }


        public void LineMover(object inputThread)
        {
            //intialize direction controllers
            double XV1 = 1.0;
            double XV2 = 1.0;
            double YV1 = 1.0;
            double YV2 = 1.0;

            //determine new stick direction
            int dir = 0;

            //Initalize random number generator
            Random randNum = new Random();

            dir = randNum.Next(1, 4);


            //determine direction
            if (dir == 1)
            {
                XV1 = 1.0;
                YV2 = 1.0;
            }
            else if (dir == 2)
            {
                XV1 = 1.0;
                YV2 = -1.0;
            }
            else if (dir == 3)
            {
                XV1 = -1.0;
                YV2 = 1.0;
            }
            else
            {
                XV1 = -1.0;
                YV2 = -1.0;
            }

            Line newLine = (Line)inputThread;

            while (linesMove)
            {
                if (runState)
                {
                 this.Dispatcher.Invoke(() =>
                    {
                        newLine.X1 += XV1;
                        newLine.Y2 += YV2;

                        if (newLine.X1 < 0 ||newLine.X1 > StickArea.ActualWidth)
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

                        //Thread.Sleep(10);

                        //Thread trail = new Thread(new ParameterizedThreadStart(Go));

                        //Line trailLine = new Line
                        //{
                        //    Stroke = newLine.Stroke,
                        //    StrokeThickness = 1,
                        //    X1 = newLine.X1,
                        //    Y1 = newLine.Y1,
                        //    X2 = newLine.X2,
                        //    Y2 = newLine.Y2,
                        //};

                        //StickArea.Children.Add(trailLine);

                        ////trail.Start(trailLine);
                        //lineList.Add(trailLine);
                        //threadList.Add(trail);
                        //threadList.
                    });

                    Thread.Sleep(10);
                }
            }
        }

        //void Go(object inputThread)
        //{
        //    Line newLine = (Line)inputThread;
        //    Line trailLine = new Line
        //    {
        //        Stroke = newLine.Stroke,
        //        StrokeThickness = 1,
        //        X1 = newLine.X1,
        //        Y1 = newLine.Y1,
        //        X2 = newLine.X2,
        //        Y2 = newLine.Y2,
        //    };
        //}

        //This was to control the trail length. It does not work.
        void sldrDelay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}


                    