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
using Color = System.Windows.Media.Color;

namespace Sticks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //private int sliderValue = 0;                                //Stores the value of the UI's slider
        public ArrayList threadList = new ArrayList();             //Stores all running threads
        public static List<Line> lineList = new List<Line>();

        volatile bool linesMove;

        volatile bool runState;     //to check if the program is not paused

        public MainWindow()
        {
            InitializeComponent();
            //    this.Window = new System.Drawing.Size(800, 450);
            //    //this.Paint += new System.Drawing.PaintEventHandler(this.Form1_Paint);
            runState = true;

        }

        void btnPause_Click(object sender, RoutedEventArgs e)
        {
            runState = false;
        }

        //[STAThread]
        void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (runState)
            {
                linesMove = true;
                runState = true;

                //Thread t1 = new Thread(new ThreadStart(DrawLine));
                ThreadStart tStart = new ThreadStart(Go);
                Thread t1 = new Thread(new ThreadStart(tStart));
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();

                Stick newStick = new Stick(this.StickArea.ActualWidth, this.StickArea.ActualHeight);
                Line canvasLine = new Line();
                canvasLine = newStick.CreateLine();
                this.StickArea.Children.Add(canvasLine);

                LineMover(canvasLine);


                //Thread move = new Thread(new ParameterizedThreadStart(newStick.MoveLine));
                ////move.Start(canvasLine);
                //LineMover(canvasLine);


                //lineList.Add(canvasLine);      //LineList keeps track of all Lines added to the Canvas
                //threadList.Add(t1); //threadList keeps track of all the started threads
                ////Thread.Sleep(10);

                //Line canvasLine = new Line();
                //canvasLine = newStick.CreateLine(x1, x2, y1, y2);
                //this.StickArea.Children.Add(canvasLine);
                //lineList.Add(canvasLine);      //LineList keeps track of all Lines added to the Canvas

                //Thread move = new Thread(new ParameterizedThreadStart(LineMover));
            }
        }

        void btnResume_Click(object sender, RoutedEventArgs e)
        {
           
        }

        void btnStop_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < threadList.Count; i++)
            {
                StickArea.Children.Remove(lineList[i]);
            }
        }

        
        void sldrDelay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }


        void DrawLine()
        {
            Stick newStick = new Stick(this.StickArea.ActualWidth, this.StickArea.ActualHeight);
            this.Dispatcher.Invoke(() =>
            {
                Line canvasLine = new Line();
                canvasLine = newStick.CreateLine();
                this.StickArea.Children.Add(canvasLine);
                lineList.Add(canvasLine);      //LineList keeps track of all Lines added to the Canvas

            });
        }


        void Go()
        {
            ;
        }

        void LineMover(object myObject)
        {
            //    Stick newStick = new Stick(this.StickArea.ActualWidth, this.StickArea.ActualHeight);

            Line canvasLine = (Line) myObject;

            //    double x1 = 0.0;
            //    double x2 = 0.0;
            //    double y1 = 0.0;
            //    double y2 = 0.0;

            //    x1 = newStick.X1;
            //    x2 = newStick.X2;
            //    y1 = newStick.Y1;
            //    y2 = newStick.Y2;

            //    int direction = 0;


            //    //Initalize random number generator
            //    Random randNum = new Random();

            //    //Generate random direction for the stick
            //    direction = randNum.Next(1, 4);

            while (linesMove)
            {
                //        //foreach (Thread thread in threadList)
                //        //{
                //        //if (!runState)
                //        //{
                //        //    try
                //        //    {
                //        //        Thread.Sleep(Timeout.Infinite);
                //        //    }
                //        //    catch (ThreadInterruptedException e)
                //        //    {
                //        //        // handling this exception is still WIP
                //        //    }
                //        //}
                //        //else
                //        //{
                //        ////to update the UI from the other thread then we must need Dispatcher.
                //        ////only Dispatcher can update the objects in the UI from non-UI thread.
                //        //this.Dispatcher.Invoke(() =>
                //        //{

                //        if (direction == 1)
                //        {
                //            x1++;
                //            x2++;
                //        }
                //        else if (direction == 2)
                //        {
                //            x1--;
                //            x2--;
                //        }
                //        else if (direction == 3)
                //        {
                //            y1++;
                //            y2++;
                //        }
                //        else
                //        {
                //            y1--;
                //            y2--;
                //        }

                this.Dispatcher.Invoke(() =>
                        {
                            RotateTransform myRotate = new RotateTransform();
                            //myRotate.DependencyObjectType(Stick);
                            Thread.Sleep(10);
                            //Line canvasLine = new Line();
                            //canvasLine = newStick.CreateLine(x1, x2, y1, y2);
                            ////this.StickArea.Children.Add(canvasLine);
                            //lineList.Add(canvasLine);      //LineList keeps track of all Lines added to the Canvas
                            //this.StickArea.Children.Add(newStick.CreateLine(x1, x2, y1, y2));
                            //                    ///
                            canvasLine.X1 += 1;
                            canvasLine.Y2 += 1;
                            //                });

                            //Thread.Sleep(10);
                        });
                //}
            }
        }
    }
}

   
