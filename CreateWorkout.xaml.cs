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
    /// Interaction logic for CreateWorkout.xaml
    /// </summary>
    public partial class CreateWorkout : Window
    {
        private System.Threading.CancellationTokenSource _cts; // declare a CancellationTokenSource to manage cancellation of the API call
        private List<string> currentWorkoutExercises = new List<string>();
        public CreateWorkout()
        {
            InitializeComponent();
        }

        private void menuBackBtn_Click(object sender, RoutedEventArgs e)
        {
            // open MainWindow window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = this; // set the owner of the main window to this create workout window
            mainWindow.Show();
            // close this create workout window
            this.Hide();
        }

        private void exerciseSearchTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            {
                exerciseSearchTbx.Tag = "";
            }
        }
        // show placeholder text when username textbox loses focus and is empty
        private void exerciseSearchTbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(exerciseSearchTbx.Text))
            {
                exerciseSearchTbx.Tag = "Search...";
            }
        }

        private void workoutNameTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            workoutNameTbx.Tag = "";
        }

        private void workoutNameTbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(workoutNameTbx.Text))
            {
                workoutNameTbx.Tag = "Enter workout name...";
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            // save workout to database
            new customMbx("Workout saved successfully!").ShowDialog();
        }

        private async void exerciseSearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            _cts?.Cancel();
            _cts = new System.Threading.CancellationTokenSource();

            try
            {
                await Task.Delay(500, _cts.Token);

                string query = exerciseSearchTbx.Text;

                if (string.IsNullOrWhiteSpace(query))
                {
                    exercisesLBx.ItemsSource = null;
                    exercisesLBx.Visibility = Visibility.Collapsed; // hide results if search box is empty
                    return;
                }

                var results = await API.SearchExercises(query);

                if (results.Any())
                {
                    exercisesLBx.ItemsSource = results.Select(r => r.name).ToList();
                    exercisesLBx.Visibility = Visibility.Visible; // show results if there are any
                }
                else
                {
                    exercisesLBx.Visibility = Visibility.Collapsed;
                }
            }
            catch (TaskCanceledException) { }
        }
        private void addExerciseBtn_Click(object sender, RoutedEventArgs e)
        {
            // get the selected item from the search results (exercisesLBx)
            var selectedExercise = exercisesLBx.SelectedItem as string;

            if (selectedExercise != null)
            {
                // add to our list
                currentWorkoutExercises.Add(selectedExercise);

                // refresh the display ListBox (addedExercisesLBx)
                addedExercisesLBx.ItemsSource = null;
                addedExercisesLBx.ItemsSource = currentWorkoutExercises;
                // clear the search box and hide the search results
                exerciseSearchTbx.Text = "";
                exercisesLBx.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Please select an exercise from the search results list first!");
            }

        }
    }
}
