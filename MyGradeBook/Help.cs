using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGradeBook
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
            lblDescription.Text = ("Click an item to see a description.");
        }

        private void btnGettingStarted_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Try changing your color scheme by selecting a new one in the top left corner. \n\n" +
                                    "Rename your classes and select one. \n\n" +
                                    "Begin inputting items. \n\n" +
                                    "Now try running some scenarios. \n\n" +
                                    "For more information, select other topics to the left. \n\n");
        }


        private void btnUsingWeights_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("All weights must be in decimal form (30% weight is entered as '.30'). \n\n" +
                                    "Using weights can give you a more accurate result when trying to calculate the grade you need to pass. \n\n" +
                                    "Weights are not necessary for the program to run. \n\n" +
                                    "If your class does not have weights input 0.  \n\n");
        }

        private void btnRenamingClasses_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("The top bar holds class names entered by the user. \n\n" +
                                    "You enter names by clicking the gear, and save by clicking the gear again. \n\n" +
                                    "These names remain even after the program is closed until you clear the program's data. \n\n");
        }

        private void btnToPass_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("To pass calculates the grade you need on your remaining assignments to get a 70%. \n\n" +
                                    "Enter the assignment's (that are not completed) points possible and the weights (If available). \n\n" +
                                    "Marking the 'Lock' checkbox for each assignment tells the program to use all items after in its calculation. \n\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("This program will take your locked items and calculate a grade based on the weights or points.  \n\n" +
                                    "The items that are not locked will be changed to make the cacluated grade");
        }
    }
}
