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
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace A5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //public partial class MainWindow : Window
    public partial class MainWindow : INotifyPropertyChanged

    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            MyTextBlock.Text = "Please Enter a message to send, or a blank line to end:";
            String message = MyTextBlock.Text;
            if (message != "")
            {
                MyTextBlock.Text = message;
                //ConnectClient("127.0.0.1", message);
            }
            else
            {
                //RunIt = false;
            }
        }

        //private int _boundNumber;
        //public int BoundNumber
        //{
        //    get { return _boundNumber; }
        //    set
        //    {
        //        if(_boundNumber != value)
        //        {
        //            _boundNumber = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public TextBlock MyTextBlock
        //{
        //    get { return MyTextBlock; }
        //}
    }
}
