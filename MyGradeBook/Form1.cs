using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/* ******************************** */
/* MyGradeBook                      */
/* ******************************** */


namespace MyGradeBook
{
    public partial class Form1 : Form
    {
        //Setting status to default for Class naming controls
        int classRenameStatus = 0;
        //array for names
        string[] classNames = new string[7];

        //Sets class selection to none
        int selection = 0;

        //Declaring arrays for class01
        string[] class01ItemNames = new string[21];
        double[] class01PointsEarned = new double[21];
        double[] class01PointsPossible = new double[21];

        //Declaring arrays for class02
        string[] class02ItemNames = new string[21];
        double[] class02PointsEarned = new double[21];
        double[] class02PointsPossible = new double [21];

        //Declaring arrays for class03
        string[] class03ItemNames = new string[21];
        double[] class03PointsEarned = new double[21];
        double[] class03PointsPossible = new double[21];

        //Declaring arrays for class04
        string[] class04ItemNames = new string[21];
        double[] class04PointsEarned = new double[21];
        double[] class04PointsPossible = new double[21];

        //Declaring arrays for class05
        string[] class05ItemNames = new string[21];
        double[] class05PointsEarned = new double[21];
        double[] class05PointsPossible = new double[21];

        //Declaring arrays for class06
        string[] class06ItemNames = new string[21];
        double[] class06PointsEarned = new double[21];
        double[] class06PointsPossible = new double[21];

        public Form1()
        {
            InitializeComponent();

            //Default buttons
            txtClass01Name.Visible = false;
            txtClass02Name.Visible = false;
            txtClass03Name.Visible = false;
            txtClass04Name.Visible = false;
            txtClass05Name.Visible = false;
            txtClass06Name.Visible = false;
            btnClass01.Visible = true;
            btnClass02.Visible = true;
            btnClass03.Visible = true;
            btnClass04.Visible = true;
            btnClass05.Visible = true;
            btnClass06.Visible = true;
            btnClass01.BackColor = System.Drawing.Color.LightCyan;
            btnClass02.BackColor = System.Drawing.Color.LightCyan;
            btnClass03.BackColor = System.Drawing.Color.LightCyan;
            btnClass04.BackColor = System.Drawing.Color.LightCyan;
            btnClass05.BackColor = System.Drawing.Color.LightCyan;
            btnClass06.BackColor = System.Drawing.Color.LightCyan;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //Save if class01 is selected
            if (selection == 1)
            {
                class01ItemNames[1] = Convert.ToString(txtItem01Name.Text);
                class01ItemNames[2] = Convert.ToString(txtItem02Name.Text);
                class01ItemNames[3] = Convert.ToString(txtItem03Name.Text);
                class01ItemNames[4] = Convert.ToString(txtItem04Name.Text);
                class01ItemNames[5] = Convert.ToString(txtItem05Name.Text);

                class01PointsEarned[1] = Convert.ToDouble(txtItem01Earned.Text);
                class01PointsEarned[2] = Convert.ToDouble(txtItem02Earned.Text);
                class01PointsEarned[3] = Convert.ToDouble(txtItem03Earned.Text);
                class01PointsEarned[4] = Convert.ToDouble(txtItem04Earned.Text);
                class01PointsEarned[5] = Convert.ToDouble(txtItem05Earned.Text);

                class01PointsPossible[1] = Convert.ToDouble(txtItem01Earned.Text);
                class01PointsPossible[2] = Convert.ToDouble(txtItem02Earned.Text);
                class01PointsPossible[3] = Convert.ToDouble(txtItem03Earned.Text);
                class01PointsPossible[4] = Convert.ToDouble(txtItem04Earned.Text);
                class01PointsPossible[5] = Convert.ToDouble(txtItem05Earned.Text);
            }

            //Save if class 2 is selected
            else if (selection == 2)
            {
                class02ItemNames[1] = Convert.ToString(txtItem01Name.Text);
                class02ItemNames[2] = Convert.ToString(txtItem02Name.Text);
                class02ItemNames[3] = Convert.ToString(txtItem03Name.Text);
                class02ItemNames[4] = Convert.ToString(txtItem04Name.Text);
                class02ItemNames[5] = Convert.ToString(txtItem05Name.Text);

                class02PointsEarned[1] = Convert.ToDouble(txtItem01Earned.Text);
                class02PointsEarned[2] = Convert.ToDouble(txtItem02Earned.Text);
                class02PointsEarned[3] = Convert.ToDouble(txtItem03Earned.Text);
                class02PointsEarned[4] = Convert.ToDouble(txtItem04Earned.Text);
                class02PointsEarned[5] = Convert.ToDouble(txtItem05Earned.Text);

                class02PointsPossible[1] = Convert.ToDouble(txtItem01Earned.Text);
                class02PointsPossible[2] = Convert.ToDouble(txtItem02Earned.Text);
                class02PointsPossible[3] = Convert.ToDouble(txtItem03Earned.Text);
                class02PointsPossible[4] = Convert.ToDouble(txtItem04Earned.Text);
                class02PointsPossible[5] = Convert.ToDouble(txtItem05Earned.Text);
            }

            else if (selection == 3)
            {
                class03ItemNames[1] = Convert.ToString(txtItem01Name.Text);
                class03ItemNames[2] = Convert.ToString(txtItem02Name.Text);
                class03ItemNames[3] = Convert.ToString(txtItem03Name.Text);
                class03ItemNames[4] = Convert.ToString(txtItem04Name.Text);
                class03ItemNames[5] = Convert.ToString(txtItem05Name.Text);

                class03PointsEarned[1] = Convert.ToDouble(txtItem01Earned.Text);
                class03PointsEarned[2] = Convert.ToDouble(txtItem02Earned.Text);
                class03PointsEarned[3] = Convert.ToDouble(txtItem03Earned.Text);
                class03PointsEarned[4] = Convert.ToDouble(txtItem04Earned.Text);
                class03PointsEarned[5] = Convert.ToDouble(txtItem05Earned.Text);

                class03PointsPossible[1] = Convert.ToDouble(txtItem01Earned.Text);
                class03PointsPossible[2] = Convert.ToDouble(txtItem02Earned.Text);
                class03PointsPossible[3] = Convert.ToDouble(txtItem03Earned.Text);
                class03PointsPossible[4] = Convert.ToDouble(txtItem04Earned.Text);
                class03PointsPossible[5] = Convert.ToDouble(txtItem05Earned.Text);
            }

            else if (selection == 4)
            {
                class04ItemNames[1] = Convert.ToString(txtItem01Name.Text);
                class04ItemNames[2] = Convert.ToString(txtItem02Name.Text);
                class04ItemNames[3] = Convert.ToString(txtItem03Name.Text);
                class04ItemNames[4] = Convert.ToString(txtItem04Name.Text);
                class04ItemNames[5] = Convert.ToString(txtItem05Name.Text);

                class04PointsEarned[1] = Convert.ToDouble(txtItem01Earned.Text);
                class04PointsEarned[2] = Convert.ToDouble(txtItem02Earned.Text);
                class04PointsEarned[3] = Convert.ToDouble(txtItem03Earned.Text);
                class04PointsEarned[4] = Convert.ToDouble(txtItem04Earned.Text);
                class04PointsEarned[5] = Convert.ToDouble(txtItem05Earned.Text);

                class04PointsPossible[1] = Convert.ToDouble(txtItem01Earned.Text);
                class04PointsPossible[2] = Convert.ToDouble(txtItem02Earned.Text);
                class04PointsPossible[3] = Convert.ToDouble(txtItem03Earned.Text);
                class04PointsPossible[4] = Convert.ToDouble(txtItem04Earned.Text);
                class04PointsPossible[5] = Convert.ToDouble(txtItem05Earned.Text);
            }

            else if (selection == 5)
            {
                class05ItemNames[1] = Convert.ToString(txtItem01Name.Text);
                class05ItemNames[2] = Convert.ToString(txtItem02Name.Text);
                class05ItemNames[3] = Convert.ToString(txtItem03Name.Text);
                class05ItemNames[4] = Convert.ToString(txtItem04Name.Text);
                class05ItemNames[5] = Convert.ToString(txtItem05Name.Text);

                class05PointsEarned[1] = Convert.ToDouble(txtItem01Earned.Text);
                class05PointsEarned[2] = Convert.ToDouble(txtItem02Earned.Text);
                class05PointsEarned[3] = Convert.ToDouble(txtItem03Earned.Text);
                class05PointsEarned[4] = Convert.ToDouble(txtItem04Earned.Text);
                class05PointsEarned[5] = Convert.ToDouble(txtItem05Earned.Text);

                class05PointsPossible[1] = Convert.ToDouble(txtItem01Earned.Text);
                class05PointsPossible[2] = Convert.ToDouble(txtItem02Earned.Text);
                class05PointsPossible[3] = Convert.ToDouble(txtItem03Earned.Text);
                class05PointsPossible[4] = Convert.ToDouble(txtItem04Earned.Text);
                class05PointsPossible[5] = Convert.ToDouble(txtItem05Earned.Text);
            }

            else if (selection == 6)
            {
                class06ItemNames[1] = Convert.ToString(txtItem01Name.Text);
                class06ItemNames[2] = Convert.ToString(txtItem02Name.Text);
                class06ItemNames[3] = Convert.ToString(txtItem03Name.Text);
                class06ItemNames[4] = Convert.ToString(txtItem04Name.Text);
                class06ItemNames[5] = Convert.ToString(txtItem05Name.Text);

                class06PointsEarned[1] = Convert.ToDouble(txtItem01Earned.Text);
                class06PointsEarned[2] = Convert.ToDouble(txtItem02Earned.Text);
                class06PointsEarned[3] = Convert.ToDouble(txtItem03Earned.Text);
                class06PointsEarned[4] = Convert.ToDouble(txtItem04Earned.Text);
                class06PointsEarned[5] = Convert.ToDouble(txtItem05Earned.Text);

                class06PointsPossible[1] = Convert.ToDouble(txtItem01Earned.Text);
                class06PointsPossible[2] = Convert.ToDouble(txtItem02Earned.Text);
                class06PointsPossible[3] = Convert.ToDouble(txtItem03Earned.Text);
                class06PointsPossible[4] = Convert.ToDouble(txtItem04Earned.Text);
                class06PointsPossible[5] = Convert.ToDouble(txtItem05Earned.Text);
            }
        }

        private void btnClassNames_Click(object sender, EventArgs e)
        {
            if (classRenameStatus == 0)
            {
                //Hide buttons
                btnClass01.Visible = false;
                btnClass02.Visible = false;
                btnClass03.Visible = false;
                btnClass04.Visible = false;
                btnClass05.Visible = false;
                btnClass06.Visible = false;
                //Show textboxes
                txtClass01Name.Visible = true;
                txtClass02Name.Visible = true;
                txtClass03Name.Visible = true;
                txtClass04Name.Visible = true;
                txtClass05Name.Visible = true;
                txtClass06Name.Visible = true;
                //Set status for next click
                classRenameStatus = 1;
            }
            else if (classRenameStatus == 1)
            {
                //Show buttons
                btnClass01.Visible = true;
                btnClass02.Visible = true;
                btnClass03.Visible = true;
                btnClass04.Visible = true;
                btnClass05.Visible = true;
                btnClass06.Visible = true;
                //Hide textboxes
                txtClass01Name.Visible = false;
                txtClass02Name.Visible = false;
                txtClass03Name.Visible = false;
                txtClass04Name.Visible = false;
                txtClass05Name.Visible = false;
                txtClass06Name.Visible = false;
                //Set status for next click
                classRenameStatus = 0;
                //Assign values to array
                classNames[1] = txtClass01Name.Text;
                classNames[2] = txtClass02Name.Text;
                classNames[3] = txtClass03Name.Text;
                classNames[4] = txtClass04Name.Text;
                classNames[5] = txtClass05Name.Text;
                classNames[6] = txtClass06Name.Text;
                //Assign array values to buttons
                btnClass01.Text = Convert.ToString(classNames[1]);
                btnClass02.Text = Convert.ToString(classNames[2]);
                btnClass03.Text = Convert.ToString(classNames[3]);
                btnClass04.Text = Convert.ToString(classNames[4]);
                btnClass05.Text = Convert.ToString(classNames[5]);
                btnClass06.Text = Convert.ToString(classNames[6]);
            }
        }

        /* START OF CLASS BUTTONS */

        private void btnClass01_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass01.BackColor = System.Drawing.Color.LightGreen;
            btnClass02.BackColor = System.Drawing.Color.LightCyan;
            btnClass03.BackColor = System.Drawing.Color.LightCyan;
            btnClass04.BackColor = System.Drawing.Color.LightCyan;
            btnClass05.BackColor = System.Drawing.Color.LightCyan;
            btnClass06.BackColor = System.Drawing.Color.LightCyan;
            //Setting textbox to values from array
            selection = 1;
            txtItem01Name.Text = class01ItemNames[1];
            txtItem02Name.Text = class01ItemNames[2];
            txtItem03Name.Text = class01ItemNames[3];
            txtItem04Name.Text = class01ItemNames[4];
            txtItem05Name.Text = class01ItemNames[5];

            txtItem01Earned.Text = Convert.ToString(class01PointsEarned[1]);
            txtItem02Earned.Text = Convert.ToString(class01PointsEarned[2]);
            txtItem03Earned.Text = Convert.ToString(class01PointsEarned[3]);
            txtItem04Earned.Text = Convert.ToString(class01PointsEarned[4]);
            txtItem05Earned.Text = Convert.ToString(class01PointsEarned[5]);

            txtItem01Possible.Text = Convert.ToString(class01PointsPossible[1]);
            txtItem02Possible.Text = Convert.ToString(class01PointsPossible[2]);
            txtItem03Possible.Text = Convert.ToString(class01PointsPossible[3]);
            txtItem04Possible.Text = Convert.ToString(class01PointsPossible[4]);
            txtItem05Possible.Text = Convert.ToString(class01PointsPossible[5]);
        }

        private void btnClass02_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass01.BackColor = System.Drawing.Color.LightCyan;
            btnClass02.BackColor = System.Drawing.Color.LightGreen;
            btnClass03.BackColor = System.Drawing.Color.LightCyan;
            btnClass04.BackColor = System.Drawing.Color.LightCyan;
            btnClass05.BackColor = System.Drawing.Color.LightCyan;
            btnClass06.BackColor = System.Drawing.Color.LightCyan;
            //Setting textbox to values from array
            selection = 2;
            txtItem01Name.Text = class02ItemNames[1];
            txtItem02Name.Text = class02ItemNames[2];
            txtItem03Name.Text = class02ItemNames[3];
            txtItem04Name.Text = class02ItemNames[4];
            txtItem05Name.Text = class02ItemNames[5];

            txtItem01Earned.Text = Convert.ToString(class02PointsEarned[1]);
            txtItem02Earned.Text = Convert.ToString(class02PointsEarned[2]);
            txtItem03Earned.Text = Convert.ToString(class02PointsEarned[3]);
            txtItem04Earned.Text = Convert.ToString(class02PointsEarned[4]);
            txtItem05Earned.Text = Convert.ToString(class02PointsEarned[5]);

            txtItem01Possible.Text = Convert.ToString(class02PointsPossible[1]);
            txtItem02Possible.Text = Convert.ToString(class02PointsPossible[2]);
            txtItem03Possible.Text = Convert.ToString(class02PointsPossible[3]);
            txtItem04Possible.Text = Convert.ToString(class02PointsPossible[4]);
            txtItem05Possible.Text = Convert.ToString(class02PointsPossible[5]);
        }

        private void btnClass03_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass01.BackColor = System.Drawing.Color.LightCyan;
            btnClass02.BackColor = System.Drawing.Color.LightCyan;
            btnClass03.BackColor = System.Drawing.Color.LightGreen;
            btnClass04.BackColor = System.Drawing.Color.LightCyan;
            btnClass05.BackColor = System.Drawing.Color.LightCyan;
            btnClass06.BackColor = System.Drawing.Color.LightCyan;
            //Setting textbox to values from array
            selection = 3;
            txtItem01Name.Text = class03ItemNames[1];
            txtItem02Name.Text = class03ItemNames[2];
            txtItem03Name.Text = class03ItemNames[3];
            txtItem04Name.Text = class03ItemNames[4];
            txtItem05Name.Text = class03ItemNames[5];

            txtItem01Earned.Text = Convert.ToString(class03PointsEarned[1]);
            txtItem02Earned.Text = Convert.ToString(class03PointsEarned[2]);
            txtItem03Earned.Text = Convert.ToString(class03PointsEarned[3]);
            txtItem04Earned.Text = Convert.ToString(class03PointsEarned[4]);
            txtItem05Earned.Text = Convert.ToString(class03PointsEarned[5]);

            txtItem01Possible.Text = Convert.ToString(class03PointsPossible[1]);
            txtItem02Possible.Text = Convert.ToString(class03PointsPossible[2]);
            txtItem03Possible.Text = Convert.ToString(class03PointsPossible[3]);
            txtItem04Possible.Text = Convert.ToString(class03PointsPossible[4]);
            txtItem05Possible.Text = Convert.ToString(class03PointsPossible[5]);
        }

        private void btnClass04_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass01.BackColor = System.Drawing.Color.LightCyan;
            btnClass02.BackColor = System.Drawing.Color.LightCyan;
            btnClass03.BackColor = System.Drawing.Color.LightCyan;
            btnClass04.BackColor = System.Drawing.Color.LightGreen;
            btnClass05.BackColor = System.Drawing.Color.LightCyan;
            btnClass06.BackColor = System.Drawing.Color.LightCyan;
            //Setting textbox to values from array
            selection = 4;
            txtItem01Name.Text = class04ItemNames[1];
            txtItem02Name.Text = class04ItemNames[2];
            txtItem03Name.Text = class04ItemNames[3];
            txtItem04Name.Text = class04ItemNames[4];
            txtItem05Name.Text = class04ItemNames[5];

            txtItem01Earned.Text = Convert.ToString(class04PointsEarned[1]);
            txtItem02Earned.Text = Convert.ToString(class04PointsEarned[2]);
            txtItem03Earned.Text = Convert.ToString(class04PointsEarned[3]);
            txtItem04Earned.Text = Convert.ToString(class04PointsEarned[4]);
            txtItem05Earned.Text = Convert.ToString(class04PointsEarned[5]);

            txtItem01Possible.Text = Convert.ToString(class04PointsPossible[1]);
            txtItem02Possible.Text = Convert.ToString(class04PointsPossible[2]);
            txtItem03Possible.Text = Convert.ToString(class04PointsPossible[3]);
            txtItem04Possible.Text = Convert.ToString(class04PointsPossible[4]);
            txtItem05Possible.Text = Convert.ToString(class04PointsPossible[5]);
        }

        private void btnClass05_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass01.BackColor = System.Drawing.Color.LightCyan;
            btnClass02.BackColor = System.Drawing.Color.LightCyan;
            btnClass03.BackColor = System.Drawing.Color.LightCyan;
            btnClass04.BackColor = System.Drawing.Color.LightCyan;
            btnClass05.BackColor = System.Drawing.Color.LightGreen;
            btnClass06.BackColor = System.Drawing.Color.LightCyan;
            //Setting textbox to values from array
            selection = 5;
            txtItem01Name.Text = class05ItemNames[1];
            txtItem02Name.Text = class05ItemNames[2];
            txtItem03Name.Text = class05ItemNames[3];
            txtItem04Name.Text = class05ItemNames[4];
            txtItem05Name.Text = class05ItemNames[5];

            txtItem01Earned.Text = Convert.ToString(class05PointsEarned[1]);
            txtItem02Earned.Text = Convert.ToString(class05PointsEarned[2]);
            txtItem03Earned.Text = Convert.ToString(class05PointsEarned[3]);
            txtItem04Earned.Text = Convert.ToString(class05PointsEarned[4]);
            txtItem05Earned.Text = Convert.ToString(class05PointsEarned[5]);

            txtItem01Possible.Text = Convert.ToString(class05PointsPossible[1]);
            txtItem02Possible.Text = Convert.ToString(class05PointsPossible[2]);
            txtItem03Possible.Text = Convert.ToString(class05PointsPossible[3]);
            txtItem04Possible.Text = Convert.ToString(class05PointsPossible[4]);
            txtItem05Possible.Text = Convert.ToString(class05PointsPossible[5]);
        }

        private void btnClass06_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass01.BackColor = System.Drawing.Color.LightCyan;
            btnClass02.BackColor = System.Drawing.Color.LightCyan;
            btnClass03.BackColor = System.Drawing.Color.LightCyan;
            btnClass04.BackColor = System.Drawing.Color.LightCyan;
            btnClass05.BackColor = System.Drawing.Color.LightCyan;
            btnClass06.BackColor = System.Drawing.Color.LightGreen;
            //Setting textbox to values from array
            selection = 6;
            txtItem01Name.Text = class06ItemNames[1];
            txtItem02Name.Text = class06ItemNames[2];
            txtItem03Name.Text = class06ItemNames[3];
            txtItem04Name.Text = class06ItemNames[4];
            txtItem05Name.Text = class06ItemNames[5];

            txtItem01Earned.Text = Convert.ToString(class06PointsEarned[1]);
            txtItem02Earned.Text = Convert.ToString(class06PointsEarned[2]);
            txtItem03Earned.Text = Convert.ToString(class06PointsEarned[3]);
            txtItem04Earned.Text = Convert.ToString(class06PointsEarned[4]);
            txtItem05Earned.Text = Convert.ToString(class06PointsEarned[5]);

            txtItem01Possible.Text = Convert.ToString(class06PointsPossible[1]);
            txtItem02Possible.Text = Convert.ToString(class06PointsPossible[2]);
            txtItem03Possible.Text = Convert.ToString(class06PointsPossible[3]);
            txtItem04Possible.Text = Convert.ToString(class06PointsPossible[4]);
            txtItem05Possible.Text = Convert.ToString(class06PointsPossible[5]);
        }
    }
}
