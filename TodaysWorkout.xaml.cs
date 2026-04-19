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
using System.Windows.Shapes;

namespace gymTracker
{
    /// <summary>
    /// Interaction logic for TodaysWorkout.xaml
    /// </summary>
    public partial class TodaysWorkout : Window
    {
        public TodaysWorkout()
        {
            InitializeComponent();
        }

        private void todaysWorkoutBackBtn_Click(object sender, RoutedEventArgs e)
        {
            // open main menu window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = this; // set the owner of the main window to today's workout window
            mainWindow.Show();
            // close today's workout window
            this.Hide();
        }
    }
}
