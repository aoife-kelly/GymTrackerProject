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
        
    }
}
