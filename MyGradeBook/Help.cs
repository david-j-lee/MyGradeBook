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
            label1.Text = ("Click an item to see a description.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = ("All weights must be in decimal form (30% weight is entered as '.30').");
            label2.Text = ("Using weights can give you a more accurate result when trying to calculate the grade you need to pass.");
            label3.Text = ("Weights are not necessary for the program to run.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = ("The top bar holds class names entered by the user.");
            label2.Text = ("You enter names by clicking the gear, and save by clicking the gear again.");
            label3.Text = ("These names remain even after the program is closed until you clear the program's data.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = ("To pass calculates the grade you need on your remaining assignments to get a 70%.");
            label2.Text = ("Enter the assignment's (that are not completed) points possible and the weights (If available).");
            label3.Text = ("Marking the 'Lock' checkbox for each assignment tells the program to use all items after in its calculation.");
        }
    }
}
