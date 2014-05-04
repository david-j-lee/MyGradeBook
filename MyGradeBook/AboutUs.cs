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
    public partial class frmAboutUs : Form
    {
        public frmAboutUs()
        {
            InitializeComponent();
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
            lblDevelopers.Text = "Developers From A-Z: \n\n" + 
                                    "John Giblin \n" +
                                    "David Lee \n" + 
                                    "Sean Mottles \n" +
                                    "Ivan Vu \n";

            lblInfo.Text = "This program was created for a project in our ISDS309 class. \n" +
                            "We hoped to create something useful for a college student. \n" +
                            "Please report any bugs to csufmygradebook@gmail.com, thanks. \n";
        }
    }
}
