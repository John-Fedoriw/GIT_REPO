using System;
using System.Windows;
using System.Windows.Media;
using System.Drawing;



namespace Sticks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

      // public event PaintEventArgs OnButtonClick;///Event for the odometer change 

       
    {
        public MainWindow()
        {
           InitializeComponent();

          
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Graphics g = btnStart.CreateGraphics();
          
            //myPictureBox.Paint
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Paint_Stick(object sender, EventArgs e)
        {
            Random myRandom = new Random();
            int red = 0;
            int green = 0;
            int blue = 0;
            red = myRandom.Next(0,255);
            green = myRandom.Next(0,255);
            blue = myRandom.Next(0,255);
            // GDI+ surface (to use graphics)
            Graphics x = control.CreateGraphics();

            //Pen object
            Pen myPen = new Pen(Color.FromArgb(red, green, blue), 2);
            //connecting the points specified by the coordinate pairs
            x.DrawLine(p, 40, 40, 150, 170);
            //release resources
            l.Dispose();
        }

        private void InitializeComponent()
        {


            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            this.SuspendLayout();
           // 
           // Form1
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(800, 450);
           this.Name = "Form1";
           this.Text = "Basic line drawing demo";
           this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
           this.ResumeLayout(false);

        }

    }

}

   
