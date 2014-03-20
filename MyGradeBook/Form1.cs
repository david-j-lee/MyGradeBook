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
    public partial class Form1 : Form
    {
        int selection = 0;

        string[] class01ItemNames = new string[3];
        double[] class01PointsEarned = new double[3];
        double[] class01PointsPossible = new double[3];

        string[] class02ItemNames = new string[3];
        double[] class02PointsEarned = new double[3];
        double[] class02PointsPossible = new double [3];

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selection == 1)
            {
                class01ItemNames[0] = Convert.ToString(txtItem01Name.Text);
                class01ItemNames[1] = Convert.ToString(txtItem02Name.Text);
                class01ItemNames[2] = Convert.ToString(txtItem03Name.Text);

                class01PointsEarned[0] = Convert.ToDouble(txtItem01Earned.Text);
                class01PointsEarned[1] = Convert.ToDouble(txtItem02Earned.Text);
                class01PointsEarned[2] = Convert.ToDouble(txtItem03Earned.Text);

                class01PointsPossible[0] = Convert.ToDouble(txtItem01Earned.Text);
                class01PointsPossible[1] = Convert.ToDouble(txtItem02Earned.Text);
                class01PointsPossible[2] = Convert.ToDouble(txtItem03Earned.Text);
            }
            else if (selection == 2)
            {
                class02ItemNames[0] = Convert.ToString(txtItem01Name.Text);
                class02ItemNames[1] = Convert.ToString(txtItem02Name.Text);
                class02ItemNames[2] = Convert.ToString(txtItem03Name.Text);

                class02PointsEarned[0] = Convert.ToDouble(txtItem01Earned.Text);
                class02PointsEarned[1] = Convert.ToDouble(txtItem02Earned.Text);
                class02PointsEarned[2] = Convert.ToDouble(txtItem03Earned.Text);

                class02PointsPossible[0] = Convert.ToDouble(txtItem01Earned.Text);
                class02PointsPossible[1] = Convert.ToDouble(txtItem02Earned.Text);
                class02PointsPossible[2] = Convert.ToDouble(txtItem03Earned.Text);
            }
        }

        private void btnClass01_Click(object sender, EventArgs e)
        {
            selection = 1;
            txtItem01Name.Text = class01ItemNames[0];
            txtItem02Name.Text = class01ItemNames[1];
            txtItem03Name.Text = class01ItemNames[2];

            txtItem01Earned.Text = Convert.ToString(class01PointsEarned[0]);
            txtItem02Earned.Text = Convert.ToString(class01PointsEarned[1]);
            txtItem03Earned.Text = Convert.ToString(class01PointsEarned[2]);

            txtItem01Possible.Text = Convert.ToString(class01PointsPossible[0]);
            txtItem02Possible.Text = Convert.ToString(class01PointsPossible[1]);
            txtItem03Possible.Text = Convert.ToString(class01PointsPossible[2]);
        }

        private void btnClass02_Click(object sender, EventArgs e)
        {
            selection = 2;
            txtItem01Name.Text = class02ItemNames[0];
            txtItem02Name.Text = class02ItemNames[1];
            txtItem03Name.Text = class02ItemNames[2];

            txtItem01Earned.Text = Convert.ToString(class02PointsEarned[0]);
            txtItem02Earned.Text = Convert.ToString(class02PointsEarned[1]);
            txtItem03Earned.Text = Convert.ToString(class02PointsEarned[2]);

            txtItem01Possible.Text = Convert.ToString(class02PointsPossible[0]);
            txtItem02Possible.Text = Convert.ToString(class02PointsPossible[1]);
            txtItem03Possible.Text = Convert.ToString(class02PointsPossible[2]);
        }
    }
}
