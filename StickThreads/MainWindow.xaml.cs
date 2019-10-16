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

        private static List<Thread> threadList = new List<Thread>();
        private static List<Line> lineList = new List<Line>();

        volatile bool linesMove;

        volatile bool runState;     //to check if the program is not paused
        
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

                Line newLine = new Line
                {
                    Stroke = Brushes.IndianRed,
                    StrokeThickness = 1,
                    X1 = newX1,
                    Y1 = newY1,
                    X2 = newX2,
                    Y2 = newY2
                };
           
                StickArea.Children.Add(newLine);

                Thread move = new Thread(new ParameterizedThreadStart(LineMover));

                move.Start(newLine);
                lineList.Add(newLine);      // LineList keeps track of all Lines added to the Canvas
                threadList.Add(move);       // ThreadList keeps track of all the started threads
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


        public void LineMover(object l)
        {

            double XV1 = 1.0;
            double XV2 = 1.0;
            double YV1 = 1.0;
            double YV2 = 1.0;

            Line newLine = (Line)l;

            //this.Dispatcher.Invoke(() =>
            //{
            //    newLine.X1 += 1;
            //    newLine.Y2 += 1;
            //});
            //Thread.Sleep(10);

            while (linesMove)
            {
                if (!runState)
                {
                    try
                    {
                        Thread.Sleep(Timeout.Infinite);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        // handling this exception is still WIP
                    }
                }
                else
                {
                    //to update the UI from the other thread then we must need Dispatcher.
                    //only Dispatcher can update the objects in the UI from non-UI thread.
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
                        
                    });
                    Thread.Sleep(10);
                }
            }
        }

        void sldrDelay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }


        void DrawLine()
        {
           
        }


    }
}
