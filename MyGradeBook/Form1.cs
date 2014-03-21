using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


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
        string[] class01PointsEarnedString = new string[21];
        string[] class01PointsPossibleString = new string[21];
        string[] class01GradesString = new string[21];
        string[] class01WeightsString = new string[21];
        string[] class01WeightedGradesString = new string[21];
        double[] class01PointsEarned = new double[21];
        double[] class01PointsPossible = new double[21];
        double[] class01Grades = new double[21];
        double[] class01Weights = new double[21];
        double[] class01WeightedGrades = new double[21];

        //Declaring arrays for class02
        string[] class02ItemNames = new string[21];
        string[] class02PointsEarnedString = new string[21];
        string[] class02PointsPossibleString = new string[21];
        string[] class02GradesString = new string[21];
        string[] class02WeightsString = new string[21];
        string[] class02WeightedGradesString = new string[21];
        double[] class02PointsEarned = new double[21];
        double[] class02PointsPossible = new double [21];
        double[] class02Grades = new double[21];
        double[] class02Weights = new double[21];
        double[] class02WeightedGrades = new double[21];

        //Declaring arrays for class03
        string[] class03ItemNames = new string[21];
        string[] class03PointsEarnedString = new string[21];
        string[] class03PointsPossibleString = new string[21];
        string[] class03GradesString = new string[21];
        string[] class03WeightsString = new string[21];
        string[] class03WeightedGradesString = new string[21];
        double[] class03PointsEarned = new double[21];
        double[] class03PointsPossible = new double[21];
        double[] class03Grades = new double[21];
        double[] class03Weights = new double[21];
        double[] class03WeightedGrades = new double[21];

        //Declaring arrays for class04
        string[] class04ItemNames = new string[21];
        string[] class04PointsEarnedString = new string[21];
        string[] class04PointsPossibleString = new string[21];
        string[] class04GradesString = new string[21];
        string[] class04WeightsString = new string[21];
        string[] class04WeightedGradesString = new string[21];
        double[] class04PointsEarned = new double[21];
        double[] class04PointsPossible = new double[21];
        double[] class04Grades = new double[21];
        double[] class04Weights = new double[21];
        double[] class04WeightedGrades = new double[21];

        //Declaring arrays for class05
        string[] class05ItemNames = new string[21];
        string[] class05PointsEarnedString = new string[21];
        string[] class05PointsPossibleString = new string[21];
        string[] class05GradesString = new string[21];
        string[] class05WeightsString = new string[21];
        string[] class05WeightedGradesString = new string[21];
        double[] class05PointsEarned = new double[21];
        double[] class05PointsPossible = new double[21];
        double[] class05Grades = new double[21];
        double[] class05Weights = new double[21];
        double[] class05WeightedGrades = new double[21];

        //Declaring arrays for class06
        string[] class06ItemNames = new string[21];
        string[] class06PointsEarnedString = new string[21];
        string[] class06PointsPossibleString = new string[21];
        string[] class06GradesString = new string[21];
        string[] class06WeightsString = new string[21];
        string[] class06WeightedGradesString = new string[21];
        double[] class06PointsEarned = new double[21];
        double[] class06PointsPossible = new double[21];
        double[] class06Grades = new double[21];
        double[] class06Weights = new double[21];
        double[] class06WeightedGrades = new double[21];

        

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
            
            //DATA
            //class names
            if (File.Exists("classNames.txt"))
            {
                classNames = File.ReadAllLines("classNames.txt");
                btnClass01.Text = classNames[1];
                btnClass02.Text = classNames[2];
                btnClass03.Text = classNames[3];
                btnClass04.Text = classNames[4];
                btnClass05.Text = classNames[5];
                btnClass06.Text = classNames[6];
                txtClass01Name.Text = classNames[1];
                txtClass02Name.Text = classNames[2];
                txtClass03Name.Text = classNames[3];
                txtClass04Name.Text = classNames[4];
                txtClass05Name.Text = classNames[5];
                txtClass06Name.Text = classNames[6];
            }
            else File.WriteAllLines("classNames.txt", classNames);

            //class01ItemNames
            if (File.Exists("class01ItemNames.txt"))
            {
                class01ItemNames = File.ReadAllLines("class01ItemNames.txt");
            }
            else File.WriteAllLines("class01ItemNames.txt", class01ItemNames);

            //class01PointsEarned
            if (File.Exists("class01PointsEarned.txt"))
            {
                class01PointsEarnedString = File.ReadAllLines("class01PointsEarned.txt");
                for (int n = 0; n < class01PointsEarnedString.Length; n++)
                {
                    class01PointsEarned[n] = double.Parse(class01PointsEarnedString[n]);
                }
            }
            else
            {
                for (int n = 0; n < class01PointsEarnedString.Length; n++)
                {
                    class01PointsEarnedString[n] = Convert.ToString(class01PointsEarned[n]);
                }
                File.WriteAllLines("class01PointsEarned.txt", class01PointsEarnedString);
            }

            //class01PointsPossible
            if (File.Exists("class01PointsPossible.txt"))
            {
                class01PointsPossibleString = File.ReadAllLines("class01PointsPossible.txt");
                for (int n = 0; n < class01PointsPossibleString.Length; n++)
                {
                    class01PointsPossible[n] = double.Parse(class01PointsPossibleString[n]);
                }
            }
            else
            {
                for (int n = 0; n < class01PointsPossibleString.Length; n++)
                {
                    class01PointsPossibleString[n] = Convert.ToString(class01PointsPossible[n]);
                }
                File.WriteAllLines("class01PointsPossible.txt", class01PointsPossibleString);
            }

            //class01Grades
            if (File.Exists("class01Grades.txt"))
            {
                class01GradesString = File.ReadAllLines("class01Grades.txt");
                for (int n = 0; n < class01GradesString.Length; n++)
                {
                    class01Grades[n] = double.Parse(class01GradesString[n]);
                }
            }
            else
            {
                for (int n = 0; n < class01GradesString.Length; n++)
                {
                    class01GradesString[n] = Convert.ToString(class01Grades[n]);
                }
                File.WriteAllLines("class01Grades.txt", class01GradesString);
            }

            //class01Weights
            if (File.Exists("class01Weights.txt"))
            {
                class01WeightsString = File.ReadAllLines("class01Weights.txt");
                for (int n = 0; n < class01WeightsString.Length; n++)
                {
                    class01Weights[n] = double.Parse(class01WeightsString[n]);
                }
            }
            else
            {
                for (int n = 0; n < class01WeightsString.Length; n++)
                {
                    class01WeightsString[n] = Convert.ToString(class01Weights[n]);
                }
                File.WriteAllLines("class01Weights.txt", class01WeightsString);
            }

            //class01WeightedGrades
            if (File.Exists("class01WeightedGrades.txt"))
            {
                class01WeightedGradesString = File.ReadAllLines("class01WeightedGrades.txt");
                for (int n = 0; n < class01WeightedGradesString.Length; n++)
                {
                    class01WeightedGrades[n] = double.Parse(class01WeightedGradesString[n]);
                }
            }
            else
            {
                for (int n = 0; n < class01WeightedGradesString.Length; n++)
                {
                    class01WeightedGradesString[n] = Convert.ToString(class01WeightedGrades[n]);
                }
                File.WriteAllLines("class01WeightedGrades.txt", class01WeightsString);
            } 
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

                class01PointsPossible[1] = Convert.ToDouble(txtItem01Possible.Text);
                class01PointsPossible[2] = Convert.ToDouble(txtItem02Possible.Text);
                class01PointsPossible[3] = Convert.ToDouble(txtItem03Possible.Text);
                class01PointsPossible[4] = Convert.ToDouble(txtItem04Possible.Text);
                class01PointsPossible[5] = Convert.ToDouble(txtItem05Possible.Text);

                class01Grades[1] = Convert.ToDouble(txtItem01Grade.Text);
                class01Grades[2] = Convert.ToDouble(txtItem02Grade.Text);
                class01Grades[3] = Convert.ToDouble(txtItem03Grade.Text);
                class01Grades[4] = Convert.ToDouble(txtItem04Grade.Text);
                class01Grades[5] = Convert.ToDouble(txtItem05Grade.Text);

                class01Weights[1] = Convert.ToDouble(txtItem01Weight.Text);
                class01Weights[2] = Convert.ToDouble(txtItem02Weight.Text);
                class01Weights[3] = Convert.ToDouble(txtItem03Weight.Text);
                class01Weights[4] = Convert.ToDouble(txtItem04Weight.Text);
                class01Weights[5] = Convert.ToDouble(txtItem05Weight.Text);

                class01WeightedGrades[1] = Convert.ToDouble(txtItem01WeightedGrade.Text);
                class01WeightedGrades[2] = Convert.ToDouble(txtItem02WeightedGrade.Text);
                class01WeightedGrades[3] = Convert.ToDouble(txtItem03WeightedGrade.Text);
                class01WeightedGrades[4] = Convert.ToDouble(txtItem04WeightedGrade.Text);
                class01WeightedGrades[5] = Convert.ToDouble(txtItem05WeightedGrade.Text);
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

                class02PointsPossible[1] = Convert.ToDouble(txtItem01Possible.Text);
                class02PointsPossible[2] = Convert.ToDouble(txtItem03Possible.Text);
                class02PointsPossible[3] = Convert.ToDouble(txtItem03Possible.Text);
                class02PointsPossible[4] = Convert.ToDouble(txtItem04Possible.Text);
                class02PointsPossible[5] = Convert.ToDouble(txtItem05Possible.Text);
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

                class03PointsPossible[1] = Convert.ToDouble(txtItem01Possible.Text);
                class03PointsPossible[2] = Convert.ToDouble(txtItem02Possible.Text);
                class03PointsPossible[3] = Convert.ToDouble(txtItem03Possible.Text);
                class03PointsPossible[4] = Convert.ToDouble(txtItem04Possible.Text);
                class03PointsPossible[5] = Convert.ToDouble(txtItem05Possible.Text);
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

                class04PointsPossible[1] = Convert.ToDouble(txtItem01Possible.Text);
                class04PointsPossible[2] = Convert.ToDouble(txtItem02Possible.Text);
                class04PointsPossible[3] = Convert.ToDouble(txtItem03Possible.Text);
                class04PointsPossible[4] = Convert.ToDouble(txtItem04Possible.Text);
                class04PointsPossible[5] = Convert.ToDouble(txtItem05Possible.Text);
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

                class05PointsPossible[1] = Convert.ToDouble(txtItem01Possible.Text);
                class05PointsPossible[2] = Convert.ToDouble(txtItem02Possible.Text);
                class05PointsPossible[3] = Convert.ToDouble(txtItem03Possible.Text);
                class05PointsPossible[4] = Convert.ToDouble(txtItem04Possible.Text);
                class05PointsPossible[5] = Convert.ToDouble(txtItem05Possible.Text);
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

                class06PointsPossible[1] = Convert.ToDouble(txtItem01Possible.Text);
                class06PointsPossible[2] = Convert.ToDouble(txtItem02Possible.Text);
                class06PointsPossible[3] = Convert.ToDouble(txtItem03Possible.Text);
                class06PointsPossible[4] = Convert.ToDouble(txtItem04Possible.Text);
                class06PointsPossible[5] = Convert.ToDouble(txtItem05Possible.Text);
            }
        }

        private void btnClassNames_Click(object sender, EventArgs e)
        {
            if (classRenameStatus == 0)//to change class names
            {
                //Hide buttons
                btnClass01.Visible = false;
                btnClass02.Visible = false;
                btnClass03.Visible = false;
                btnClass04.Visible = false;
                btnClass05.Visible = false;
                btnClass06.Visible = false;
                //Bring current names into textboxes
                txtClass01Name.Text = classNames[1];
                txtClass02Name.Text = classNames[2];
                txtClass03Name.Text = classNames[3];
                txtClass04Name.Text = classNames[4];
                txtClass05Name.Text = classNames[5];
                txtClass06Name.Text = classNames[6];
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
            else if (classRenameStatus == 1) //to change back to buttons
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
                //Store array values to text file
                File.WriteAllLines("classNames.txt", classNames);
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

            txtItem01Grade.Text = Convert.ToString(class01Grades[1]);
            txtItem02Grade.Text = Convert.ToString(class01Grades[2]);
            txtItem03Grade.Text = Convert.ToString(class01Grades[3]);
            txtItem04Grade.Text = Convert.ToString(class01Grades[4]);
            txtItem05Grade.Text = Convert.ToString(class01Grades[5]);

            txtItem01Weight.Text = Convert.ToString(class01Weights[1]);
            txtItem02Weight.Text = Convert.ToString(class01Weights[2]);
            txtItem03Weight.Text = Convert.ToString(class01Weights[3]);
            txtItem04Weight.Text = Convert.ToString(class01Weights[4]);
            txtItem05Weight.Text = Convert.ToString(class01Weights[5]);

            txtItem01WeightedGrade.Text = Convert.ToString(class01WeightedGrades[1]);
            txtItem02WeightedGrade.Text = Convert.ToString(class01WeightedGrades[2]);
            txtItem03WeightedGrade.Text = Convert.ToString(class01WeightedGrades[3]);
            txtItem04WeightedGrade.Text = Convert.ToString(class01WeightedGrades[4]);
            txtItem05WeightedGrade.Text = Convert.ToString(class01WeightedGrades[5]);
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

            txtItem01Grade.Text = Convert.ToString(class02Grades[1]);
            txtItem02Grade.Text = Convert.ToString(class02Grades[2]);
            txtItem03Grade.Text = Convert.ToString(class02Grades[3]);
            txtItem04Grade.Text = Convert.ToString(class02Grades[4]);
            txtItem05Grade.Text = Convert.ToString(class02Grades[5]);

            txtItem01Weight.Text = Convert.ToString(class02Weights[1]);
            txtItem02Weight.Text = Convert.ToString(class02Weights[2]);
            txtItem03Weight.Text = Convert.ToString(class02Weights[3]);
            txtItem04Weight.Text = Convert.ToString(class02Weights[4]);
            txtItem05Weight.Text = Convert.ToString(class02Weights[5]);

            txtItem01WeightedGrade.Text = Convert.ToString(class02WeightedGrades[1]);
            txtItem02WeightedGrade.Text = Convert.ToString(class02WeightedGrades[2]);
            txtItem03WeightedGrade.Text = Convert.ToString(class02WeightedGrades[3]);
            txtItem04WeightedGrade.Text = Convert.ToString(class02WeightedGrades[4]);
            txtItem05WeightedGrade.Text = Convert.ToString(class02WeightedGrades[5]);
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

            txtItem01Grade.Text = Convert.ToString(class03Grades[1]);
            txtItem02Grade.Text = Convert.ToString(class03Grades[2]);
            txtItem03Grade.Text = Convert.ToString(class03Grades[3]);
            txtItem04Grade.Text = Convert.ToString(class03Grades[4]);
            txtItem05Grade.Text = Convert.ToString(class03Grades[5]);

            txtItem01Weight.Text = Convert.ToString(class03Weights[1]);
            txtItem02Weight.Text = Convert.ToString(class03Weights[2]);
            txtItem03Weight.Text = Convert.ToString(class03Weights[3]);
            txtItem04Weight.Text = Convert.ToString(class03Weights[4]);
            txtItem05Weight.Text = Convert.ToString(class03Weights[5]);

            txtItem01WeightedGrade.Text = Convert.ToString(class03WeightedGrades[1]);
            txtItem02WeightedGrade.Text = Convert.ToString(class03WeightedGrades[2]);
            txtItem03WeightedGrade.Text = Convert.ToString(class03WeightedGrades[3]);
            txtItem04WeightedGrade.Text = Convert.ToString(class03WeightedGrades[4]);
            txtItem05WeightedGrade.Text = Convert.ToString(class03WeightedGrades[5]);
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

            txtItem01Grade.Text = Convert.ToString(class04Grades[1]);
            txtItem02Grade.Text = Convert.ToString(class04Grades[2]);
            txtItem03Grade.Text = Convert.ToString(class04Grades[3]);
            txtItem04Grade.Text = Convert.ToString(class04Grades[4]);
            txtItem05Grade.Text = Convert.ToString(class04Grades[5]);

            txtItem01Weight.Text = Convert.ToString(class04Weights[1]);
            txtItem02Weight.Text = Convert.ToString(class04Weights[2]);
            txtItem03Weight.Text = Convert.ToString(class04Weights[3]);
            txtItem04Weight.Text = Convert.ToString(class04Weights[4]);
            txtItem05Weight.Text = Convert.ToString(class04Weights[5]);

            txtItem01WeightedGrade.Text = Convert.ToString(class04WeightedGrades[1]);
            txtItem02WeightedGrade.Text = Convert.ToString(class04WeightedGrades[2]);
            txtItem03WeightedGrade.Text = Convert.ToString(class04WeightedGrades[3]);
            txtItem04WeightedGrade.Text = Convert.ToString(class04WeightedGrades[4]);
            txtItem05WeightedGrade.Text = Convert.ToString(class04WeightedGrades[5]);
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

            txtItem01Grade.Text = Convert.ToString(class05Grades[1]);
            txtItem02Grade.Text = Convert.ToString(class05Grades[2]);
            txtItem03Grade.Text = Convert.ToString(class05Grades[3]);
            txtItem04Grade.Text = Convert.ToString(class05Grades[4]);
            txtItem05Grade.Text = Convert.ToString(class05Grades[5]);

            txtItem01Weight.Text = Convert.ToString(class05Weights[1]);
            txtItem02Weight.Text = Convert.ToString(class05Weights[2]);
            txtItem03Weight.Text = Convert.ToString(class05Weights[3]);
            txtItem04Weight.Text = Convert.ToString(class05Weights[4]);
            txtItem05Weight.Text = Convert.ToString(class05Weights[5]);

            txtItem01WeightedGrade.Text = Convert.ToString(class05WeightedGrades[1]);
            txtItem02WeightedGrade.Text = Convert.ToString(class05WeightedGrades[2]);
            txtItem03WeightedGrade.Text = Convert.ToString(class05WeightedGrades[3]);
            txtItem04WeightedGrade.Text = Convert.ToString(class05WeightedGrades[4]);
            txtItem05WeightedGrade.Text = Convert.ToString(class05WeightedGrades[5]);


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

            txtItem01Grade.Text = Convert.ToString(class06Grades[1]);
            txtItem02Grade.Text = Convert.ToString(class06Grades[2]);
            txtItem03Grade.Text = Convert.ToString(class06Grades[3]);
            txtItem04Grade.Text = Convert.ToString(class06Grades[4]);
            txtItem05Grade.Text = Convert.ToString(class06Grades[5]);

            txtItem01Weight.Text = Convert.ToString(class06Weights[1]);
            txtItem02Weight.Text = Convert.ToString(class06Weights[2]);
            txtItem03Weight.Text = Convert.ToString(class06Weights[3]);
            txtItem04Weight.Text = Convert.ToString(class06Weights[4]);
            txtItem05Weight.Text = Convert.ToString(class06Weights[5]);

            txtItem01WeightedGrade.Text = Convert.ToString(class06WeightedGrades[1]);
            txtItem02WeightedGrade.Text = Convert.ToString(class06WeightedGrades[2]);
            txtItem03WeightedGrade.Text = Convert.ToString(class06WeightedGrades[3]);
            txtItem04WeightedGrade.Text = Convert.ToString(class06WeightedGrades[4]);
            txtItem05WeightedGrade.Text = Convert.ToString(class06WeightedGrades[5]);
        }
    }
}
