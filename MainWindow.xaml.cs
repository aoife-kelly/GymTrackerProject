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

namespace gymTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuBackBtn_Click(object sender, RoutedEventArgs e)
        {
            // open LoginScreen window
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Owner = this; // set the owner of the login screen to this main window
            loginScreen.Show();
            // hide this main window
            this.Hide();
        }

        private void createWorkoutBtn_Click(object sender, RoutedEventArgs e)
        {
            // open CreateWorkout window
            CreateWorkout createWorkout = new CreateWorkout();
            createWorkout.Owner = this; // set the owner of the create workout window to this main window
            createWorkout.Show();
            this.Hide();

        }

        private void todaysWorkout_Click(object sender, RoutedEventArgs e)
        {
            // open TodaysWorkout window, which will show the workout for the day based on the date of stored workouts
            TodaysWorkout todaysWorkout = new TodaysWorkout();
            todaysWorkout.Owner = this; // set the owner of the today's workout window to this main window
            todaysWorkout.Show();
            this.Hide();
        }
    }
}
