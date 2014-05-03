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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            lblDescription.Text = ("Click an item to see a description.");
        }

        private void btnUsingWeights_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("All weights must be in decimal form (30% weight is entered as '.30'). \n\n" +
                                    "Using weights can give you a more accurate result when trying to calculate the grade you need to pass. \n\n" +
                                    "Weights are not necessary for the program to run. \n\n");
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

        private void button4_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("WIP");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("WIP");
        }
    }
}
