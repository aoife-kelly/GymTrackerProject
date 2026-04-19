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
    /// Interaction logic for SavedRoutines.xaml
    /// </summary>
    public partial class SavedRoutines : Window
    {
        public SavedRoutines()
        {
            InitializeComponent();
        }
        private void savedRoutinesBackBtn_Click(object sender, RoutedEventArgs e)
        {
            // open main menu window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = this; // set the owner of the main window to this saved routines window
            mainWindow.Show();
            // close this saved routines window
            this.Hide();
        }
    }
}
