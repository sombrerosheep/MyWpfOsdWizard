using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWpfOsdWizard.Pages
{
    /// <summary>
    /// Interaction logic for Landing.xaml
    /// </summary>
    public partial class Landing : Page
    {
        public Landing()
        {
            InitializeComponent();
        }

        private void osdComputerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Empty Computer Name
            if (osdComputerName.Text.Length < 1)
            {
                computerNameErrIcon.Visibility = System.Windows.Visibility.Visible;
                computerNameErrIcon.ToolTip = "Please enter a Computer Name!";
                finishButton.IsEnabled = false;
            }
            // Computer Name is Too Long
            else if (osdComputerName.Text.Length > 15)
            {
                computerNameErrIcon.Visibility = System.Windows.Visibility.Visible;
                computerNameErrIcon.ToolTip = "Computer Name cannot exceed 15 characters!";
                finishButton.IsEnabled = false;
            }
            // Computer Name is Good!
            else
            {
                computerNameErrIcon.Visibility = System.Windows.Visibility.Hidden;
                computerNameErrIcon.ToolTip = "";
                finishButton.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Classes.TaskSequenceEnvironment tsEnv = null;

            // Get instance of the Task Sequence environment.
            try
            {
                tsEnv = new Classes.TaskSequenceEnvironment();
            }
            catch
            {
                MessageBox.Show("Unable to locate Task Sequence Environment!", "WinPE .NET Wizard");
                Application.Current.Shutdown(1);
            }

            // Set the Computer Name
            tsEnv.SetTaskSequenceVariable("OSDComputerName", osdComputerName.Text);

            //Set Variable One, if present
            if (osdVarNameOne.Text != "" && osdVarValOne.Text != "")
            {
                tsEnv.SetTaskSequenceVariable(osdVarNameOne.Text, osdVarValOne.Text);
            }

            //Set Variable Two, if present
            if (osdVarNameTwo.Text != "" && osdVarValTwo.Text != "")
            {
                tsEnv.SetTaskSequenceVariable(osdVarNameTwo.Text, osdVarValTwo.Text);
            }

            //Set Variable Three, if present
            if (osdVarNameThree.Text != "" && osdVarValThree.Text != "")
            {
                tsEnv.SetTaskSequenceVariable(osdVarNameThree.Text, osdVarValThree.Text);
            }

            //Set Variable Four, if present
            if (osdVarNameFour.Text != "" && osdVarValFour.Text != "")
            {
                tsEnv.SetTaskSequenceVariable(osdVarNameFour.Text, osdVarValFour.Text);
            }

            //Set Variable Five, if present
            if (osdVarNameFive.Text != "" && osdVarValFive.Text != "")
            {
                tsEnv.SetTaskSequenceVariable(osdVarNameFive.Text, osdVarValFive.Text);
            }

            // Exit the Wizard
            Application.Current.Shutdown(0);
        }
    }
}
