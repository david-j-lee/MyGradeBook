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


/* ********************************* */
/* ********** MyGradeBook ********** */
/* ********************************* */

// QUESTIONS TO PROFESSSOR:

// Using for with checkboxes
// Event procedures for many similar controls
// 


// TO BE COMPLETED:

// What ifs
// Saving sys msgs to txt file with append
// About us
// On enter events for txtboxes
// On leave events for txtboxes without numbers
// 


namespace MyGradeBook
{
    public partial class Main : Form
    {
        //Constants
        const int NUMBER_OF_CLASSES = 6;
        const int NUMBER_OF_ITEMS = 10;

        int classRenameStatus = 0; //Setting status to default for Class naming controls
        int selection = -1;  //Sets class selection to none
        string colorScheme;  //String for color scheme

        //array for class names (GUI)
        string[] classNames = new string[NUMBER_OF_CLASSES];

        //Declaring arrays for class0
        string[] class0ItemNames = new string[NUMBER_OF_ITEMS];
        string[] class0ItemStatus = new string[NUMBER_OF_ITEMS];

        string[] class0PointsEarnedString = new string[NUMBER_OF_ITEMS];
        string[] class0PointsPossibleString = new string[NUMBER_OF_ITEMS];
        string[] class0WeightsString = new string[NUMBER_OF_ITEMS];

        double[] class0PointsEarned = new double[NUMBER_OF_ITEMS];
        double[] class0PointsPossible = new double[NUMBER_OF_ITEMS];
        double[] class0Grades = new double[NUMBER_OF_ITEMS];
        double[] class0Weights = new double[NUMBER_OF_ITEMS];
        double[] class0WeightedGrades = new double[NUMBER_OF_ITEMS];

        //Declaring arrays for class1
        string[] class1ItemNames = new string[NUMBER_OF_ITEMS];
        string[] class1ItemStatus = new string[NUMBER_OF_ITEMS];

        string[] class1PointsEarnedString = new string[NUMBER_OF_ITEMS];
        string[] class1PointsPossibleString = new string[NUMBER_OF_ITEMS];
        string[] class1WeightsString = new string[NUMBER_OF_ITEMS];

        double[] class1PointsEarned = new double[NUMBER_OF_ITEMS];
        double[] class1PointsPossible = new double[NUMBER_OF_ITEMS];
        double[] class1Grades = new double[NUMBER_OF_ITEMS];
        double[] class1Weights = new double[NUMBER_OF_ITEMS];
        double[] class1WeightedGrades = new double[NUMBER_OF_ITEMS];

        //Declaring arrays for class2
        string[] class2ItemNames = new string[NUMBER_OF_ITEMS];
        string[] class2ItemStatus = new string[NUMBER_OF_ITEMS];

        string[] class2PointsEarnedString = new string[NUMBER_OF_ITEMS];
        string[] class2PointsPossibleString = new string[NUMBER_OF_ITEMS];
        string[] class2WeightsString = new string[NUMBER_OF_ITEMS];

        double[] class2PointsEarned = new double[NUMBER_OF_ITEMS];
        double[] class2PointsPossible = new double[NUMBER_OF_ITEMS];
        double[] class2Grades = new double[NUMBER_OF_ITEMS];
        double[] class2Weights = new double[NUMBER_OF_ITEMS];
        double[] class2WeightedGrades = new double[NUMBER_OF_ITEMS];

        //Declaring arrays for class3
        string[] class3ItemNames = new string[NUMBER_OF_ITEMS];
        string[] class3ItemStatus = new string[NUMBER_OF_ITEMS];

        string[] class3PointsEarnedString = new string[NUMBER_OF_ITEMS];
        string[] class3PointsPossibleString = new string[NUMBER_OF_ITEMS];
        string[] class3WeightsString = new string[NUMBER_OF_ITEMS];

        double[] class3PointsEarned = new double[NUMBER_OF_ITEMS];
        double[] class3PointsPossible = new double[NUMBER_OF_ITEMS];
        double[] class3Grades = new double[NUMBER_OF_ITEMS];
        double[] class3Weights = new double[NUMBER_OF_ITEMS];
        double[] class3WeightedGrades = new double[NUMBER_OF_ITEMS];

        //Declaring arrays for class4
        string[] class4ItemNames = new string[NUMBER_OF_ITEMS];
        string[] class4ItemStatus = new string[NUMBER_OF_ITEMS];

        string[] class4PointsEarnedString = new string[NUMBER_OF_ITEMS];
        string[] class4PointsPossibleString = new string[NUMBER_OF_ITEMS];
        string[] class4WeightsString = new string[NUMBER_OF_ITEMS];

        double[] class4PointsEarned = new double[NUMBER_OF_ITEMS];
        double[] class4PointsPossible = new double[NUMBER_OF_ITEMS];
        double[] class4Grades = new double[NUMBER_OF_ITEMS];
        double[] class4Weights = new double[NUMBER_OF_ITEMS];
        double[] class4WeightedGrades = new double[NUMBER_OF_ITEMS];

        //Declaring arrays for class5
        string[] class5ItemNames = new string[NUMBER_OF_ITEMS];
        string[] class5ItemStatus = new string[NUMBER_OF_ITEMS];

        string[] class5PointsEarnedString = new string[NUMBER_OF_ITEMS];
        string[] class5PointsPossibleString = new string[NUMBER_OF_ITEMS];
        string[] class5WeightsString = new string[NUMBER_OF_ITEMS];

        double[] class5PointsEarned = new double[NUMBER_OF_ITEMS];
        double[] class5PointsPossible = new double[NUMBER_OF_ITEMS];
        double[] class5Grades = new double[NUMBER_OF_ITEMS];
        double[] class5Weights = new double[NUMBER_OF_ITEMS];
        double[] class5WeightedGrades = new double[NUMBER_OF_ITEMS];



        //=======================================================================================================
        /* SET STAGE */
        //=======================================================================================================

        public Main()
        {
            InitializeComponent();
        }



        //=======================================================================================================
        /* LOADS DATA */
        //=======================================================================================================

        private void Main_Load(object sender, EventArgs e)
        {
            //To hide txtbox for class names
            for (int i = 0; i < NUMBER_OF_CLASSES; i++)
            {
                pnlClassBtns.Controls["txtClassName" + i].Visible = false;
            }

            //Hide buttons used for referncing
            btnClassNotSelected.Visible = false;
            btnClassSelected.Visible = false;
            txtDone.Visible = false;
            txtNotDone.Visible = false;           

            //Hide settings
            btnClearCurrent.Visible = false;
            btnClearAll.Visible = false;

            //SysMsg
            lblSysMsg.Text = "Class Input text hidden";

            //To show btns for class names
            for (int i = 0; i < NUMBER_OF_CLASSES; i++)
            {
                pnlClassBtns.Controls["btnClass" + i].Visible = true;
            }

            //SysMsg
            lblSysMsg.Text = "Buttons are loaded";
            lblSysMsg.Text = "GUI Loaded";

            //Load from text
            Load_Color_Scheme();
            Load_Class_Names();
            Load_Class_0();
            Load_Class_1();
            Load_Class_2();
            Load_Class_3();
            Load_Class_4();
            Load_Class_5();

            //SysMsg
            lblSysMsg.Text = "Welcome";
        }



        //=======================================================================================================
        /* **** **** METHODS **** **** */
        //=======================================================================================================

        /* LOAD TO VARIABLES */
        //Checks for txt files
        //If none exsists it creates one
        //If one does exsist it reads it
        public void Load_Color_Scheme()
        {
            //Looks for file, creates if does not exsist
            if (File.Exists("colorScheme.txt"))
            {
                colorScheme = File.ReadAllText("colorScheme.txt");
            }
            else
            {
                colorScheme = "(default)";
                File.WriteAllText("colorScheme.txt", colorScheme);
            }

            //Set colorScheme
            cboColorScheme.Text = colorScheme;

            //SysMsg
            lblSysMsg.Text = "colorScheme has been set";
        }
        public void Load_Class_Names()
        {
            //classNames
            if (File.Exists("classNames.txt"))
            {
                classNames = File.ReadAllLines("classNames.txt");

                for (int i = 0; i < NUMBER_OF_CLASSES; i++)
                {
                    pnlClassBtns.Controls["btnClass" + i].Text = classNames[i];
                }

                for (int i = 0; i < NUMBER_OF_CLASSES; i++)
                {
                    pnlClassBtns.Controls["txtClassName" + i].Text = classNames[i];
                }
            }
            else File.WriteAllLines("classNames.txt", classNames);

            //SysMsg
            lblSysMsg.Text = "classNames have been set";
        }
        public void Load_Class_0()
        {
            //Looks for files: if exsists read, if does not exsist create one
            //class0ItemNames
            if (File.Exists("class0ItemNames.txt"))
            {
                class0ItemNames = File.ReadAllLines("class0ItemNames.txt");
            }
            else File.WriteAllLines("class0ItemNames.txt", class0ItemNames);

            //class0ItemStatus
            if (File.Exists("class0ItemStatus.txt"))
            {
                class0ItemStatus = File.ReadAllLines("class0ItemStatus.txt");
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0ItemStatus[i] = "no";
                }
                File.WriteAllLines("class0ItemStatus.txt", class0ItemStatus);
            }

            //class0PointsEarned
            if (File.Exists("class0PointsEarned.txt"))
            {
                class0PointsEarnedString = File.ReadAllLines("class0PointsEarned.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0PointsEarned[i] = double.Parse(class0PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0PointsEarnedString[i] = Convert.ToString(class0PointsEarned[i]);
                }
                File.WriteAllLines("class0PointsEarned.txt", class0PointsEarnedString);
            }

            //class0PointsPossible
            if (File.Exists("class0PointsPossible.txt"))
            {
                class0PointsPossibleString = File.ReadAllLines("class0PointsPossible.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0PointsPossible[i] = double.Parse(class0PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0PointsPossibleString[i] = Convert.ToString(class0PointsPossible[i]);
                }
                File.WriteAllLines("class0PointsPossible.txt", class0PointsPossibleString);
            }

            //class0Grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class0PointsPossible[i] == 0)
                    class0Grades[i] = 0;
                else
                    class0Grades[i] = class0PointsEarned[i] / class0PointsPossible[i];
            }

            //class0Weights
            if (File.Exists("class0Weights.txt"))
            {
                class0WeightsString = File.ReadAllLines("class0Weights.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0Weights[i] = double.Parse(class0WeightsString[i]);
                }

            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0WeightsString[i] = Convert.ToString(class0Weights[i]);
                }
                File.WriteAllLines("class0Weights.txt", class0WeightsString);
            }

            //class0WeightedGrades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class0Weights[i] == 0)
                    class0WeightedGrades[i] = 0;
                else
                    class0WeightedGrades[i] = class0Grades[i] * class0Weights[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 0 initialized";
        }
        public void Load_Class_1()
        {
            //class1ItemNames
            if (File.Exists("class1ItemNames.txt"))
            {
                class1ItemNames = File.ReadAllLines("class1ItemNames.txt");
            }
            else File.WriteAllLines("class1ItemNames.txt", class1ItemNames);

            //class1ItemStatus
            if (File.Exists("class1ItemStatus.txt"))
            {
                class1ItemStatus = File.ReadAllLines("class1ItemStatus.txt");
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1ItemStatus[i] = "no";
                }
                File.WriteAllLines("class1ItemStatus.txt", class1ItemStatus);
            }


            //class1PointsEarned
            if (File.Exists("class1PointsEarned.txt"))
            {
                class1PointsEarnedString = File.ReadAllLines("class1PointsEarned.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1PointsEarned[i] = double.Parse(class1PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1PointsEarnedString[i] = Convert.ToString(class1PointsEarned[i]);
                }
                File.WriteAllLines("class1PointsEarned.txt", class1PointsEarnedString);
            }

            //class1PointsPossible
            if (File.Exists("class1PointsPossible.txt"))
            {
                class1PointsPossibleString = File.ReadAllLines("class1PointsPossible.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1PointsPossible[i] = double.Parse(class1PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1PointsPossibleString[i] = Convert.ToString(class1PointsPossible[i]);
                }
                File.WriteAllLines("class1PointsPossible.txt", class1PointsPossibleString);
            }

            //class1Grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class1PointsPossible[i] == 0)
                    class1Grades[i] = 0;
                else
                    class1Grades[i] = class1PointsEarned[i] / class1PointsPossible[i];
            }

            //class1Weights
            if (File.Exists("class1Weights.txt"))
            {
                class1WeightsString = File.ReadAllLines("class1Weights.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1Weights[i] = double.Parse(class1WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1WeightsString[i] = Convert.ToString(class1Weights[i]);
                }
                File.WriteAllLines("class1Weights.txt", class1WeightsString);
            }

            //class1WeightedGrades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class1Weights[i] == 0)
                    class1WeightedGrades[i] = 0;
                else
                    class1WeightedGrades[i] = class1Grades[i] * class1Weights[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 2 initialized";
        }
        public void Load_Class_2()
        {
            //class2ItemNames
            if (File.Exists("class2ItemNames.txt"))
            {
                class2ItemNames = File.ReadAllLines("class2ItemNames.txt");
            }
            else File.WriteAllLines("class2ItemNames.txt", class2ItemNames);

            //class2ItemStatus
            if (File.Exists("class2ItemStatus.txt"))
            {
                class2ItemStatus = File.ReadAllLines("class2ItemStatus.txt");
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2ItemStatus[i] = "no";
                }
                File.WriteAllLines("class2ItemStatus.txt", class2ItemStatus);
            }


            //class2PointsEarned
            if (File.Exists("class2PointsEarned.txt"))
            {
                class2PointsEarnedString = File.ReadAllLines("class2PointsEarned.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2PointsEarned[i] = double.Parse(class2PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2PointsEarnedString[i] = Convert.ToString(class2PointsEarned[i]);
                }
                File.WriteAllLines("class2PointsEarned.txt", class2PointsEarnedString);
            }

            //class2PointsPossible
            if (File.Exists("class2PointsPossible.txt"))
            {
                class2PointsPossibleString = File.ReadAllLines("class2PointsPossible.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2PointsPossible[i] = double.Parse(class2PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2PointsPossibleString[i] = Convert.ToString(class2PointsPossible[i]);
                }
                File.WriteAllLines("class2PointsPossible.txt", class2PointsPossibleString);
            }

            //class2Grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class2PointsPossible[i] == 0)
                    class2Grades[i] = 0;
                else
                    class2Grades[i] = class2PointsEarned[i] / class2PointsPossible[i];
            }

            //class2Weights
            if (File.Exists("class2Weights.txt"))
            {
                class2WeightsString = File.ReadAllLines("class2Weights.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2Weights[i] = double.Parse(class2WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2WeightsString[i] = Convert.ToString(class2Weights[i]);
                }
                File.WriteAllLines("class2Weights.txt", class2WeightsString);
            }

            //class2WeightedGrades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class2Weights[i] == 0)
                    class2WeightedGrades[i] = 0;
                else
                    class2WeightedGrades[i] = class2Grades[i] * class2Weights[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 3 initialized";
        }
        public void Load_Class_3()
        {
            //class3ItemNames
            if (File.Exists("class3ItemNames.txt"))
            {
                class3ItemNames = File.ReadAllLines("class3ItemNames.txt");
            }
            else File.WriteAllLines("class3ItemNames.txt", class3ItemNames);

            //class3ItemStatus
            if (File.Exists("class3ItemStatus.txt"))
            {
                class3ItemStatus = File.ReadAllLines("class3ItemStatus.txt");
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3ItemStatus[i] = "no";
                }
                File.WriteAllLines("class3ItemStatus.txt", class3ItemStatus);
            }



            //class3PointsEarned
            if (File.Exists("class3PointsEarned.txt"))
            {
                class3PointsEarnedString = File.ReadAllLines("class3PointsEarned.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3PointsEarned[i] = double.Parse(class3PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3PointsEarnedString[i] = Convert.ToString(class3PointsEarned[i]);
                }
                File.WriteAllLines("class3PointsEarned.txt", class3PointsEarnedString);
            }

            //class3PointsPossible
            if (File.Exists("class3PointsPossible.txt"))
            {
                class3PointsPossibleString = File.ReadAllLines("class3PointsPossible.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3PointsPossible[i] = double.Parse(class3PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3PointsPossibleString[i] = Convert.ToString(class3PointsPossible[i]);
                }
                File.WriteAllLines("class3PointsPossible.txt", class3PointsPossibleString);
            }

            //class3Grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class3PointsPossible[i] == 0)
                    class3Grades[i] = 0;
                else
                    class3Grades[i] = class3PointsEarned[i] / class3PointsPossible[i];
            }

            //class3Weights
            if (File.Exists("class3Weights.txt"))
            {
                class3WeightsString = File.ReadAllLines("class3Weights.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3Weights[i] = double.Parse(class3WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3WeightsString[i] = Convert.ToString(class3Weights[i]);
                }
                File.WriteAllLines("class3Weights.txt", class3WeightsString);
            }

            //class3WeightedGrades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class3Weights[i] == 0)
                    class3WeightedGrades[i] = 0;
                else
                    class3WeightedGrades[i] = class3PointsEarned[i] / class3PointsPossible[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 4 initialized";

            //END OF CLASS 4

        }
        public void Load_Class_4()
        {
            //class4ItemNames
            if (File.Exists("class4ItemNames.txt"))
            {
                class4ItemNames = File.ReadAllLines("class4ItemNames.txt");
            }
            else File.WriteAllLines("class4ItemNames.txt", class4ItemNames);

            //class4ItemStatus
            if (File.Exists("class4ItemStatus.txt"))
            {
                class4ItemStatus = File.ReadAllLines("class4ItemStatus.txt");
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4ItemStatus[i] = "no";
                }
                File.WriteAllLines("class4ItemStatus.txt", class4ItemStatus);
            }


            //class4PointsEarned
            if (File.Exists("class4PointsEarned.txt"))
            {
                class4PointsEarnedString = File.ReadAllLines("class4PointsEarned.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4PointsEarned[i] = double.Parse(class4PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4PointsEarnedString[i] = Convert.ToString(class4PointsEarned[i]);
                }
                File.WriteAllLines("class4PointsEarned.txt", class4PointsEarnedString);
            }

            //class4PointsPossible
            if (File.Exists("class4PointsPossible.txt"))
            {
                class4PointsPossibleString = File.ReadAllLines("class4PointsPossible.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4PointsPossible[i] = double.Parse(class4PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4PointsPossibleString[i] = Convert.ToString(class4PointsPossible[i]);
                }
                File.WriteAllLines("class4PointsPossible.txt", class4PointsPossibleString);
            }

            //class4Grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class4PointsPossible[i] == 0)
                    class4Grades[i] = 0;
                else
                    class4Grades[i] = class4PointsEarned[i] / class4PointsPossible[i];
            }

            //class4Weights
            if (File.Exists("class4Weights.txt"))
            {
                class4WeightsString = File.ReadAllLines("class4Weights.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4Weights[i] = double.Parse(class4WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4WeightsString[i] = Convert.ToString(class4Weights[i]);
                }
                File.WriteAllLines("class4Weights.txt", class4WeightsString);
            }

            //class4WeightedGrades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class4Weights[i] == 0)
                    class4WeightedGrades[i] = 0;
                else
                    class4WeightedGrades[i] = class4Grades[i] * class4Weights[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 5 initialized";
        }
        public void Load_Class_5()
        {
            //class5ItemNames
            if (File.Exists("class5ItemNames.txt"))
            {
                class5ItemNames = File.ReadAllLines("class5ItemNames.txt");
            }
            else File.WriteAllLines("class5ItemNames.txt", class5ItemNames);

            //class5ItemStatus
            if (File.Exists("class5ItemStatus.txt"))
            {
                class5ItemStatus = File.ReadAllLines("class5ItemStatus.txt");
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5ItemStatus[i] = "no";
                }
                File.WriteAllLines("class5ItemStatus.txt", class5ItemStatus);
            }


            //class5PointsEarned
            if (File.Exists("class5PointsEarned.txt"))
            {
                class5PointsEarnedString = File.ReadAllLines("class5PointsEarned.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5PointsEarned[i] = double.Parse(class5PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5PointsEarnedString[i] = Convert.ToString(class5PointsEarned[i]);
                }
                File.WriteAllLines("class5PointsEarned.txt", class5PointsEarnedString);
            }

            //class5PointsPossible
            if (File.Exists("class5PointsPossible.txt"))
            {
                class5PointsPossibleString = File.ReadAllLines("class5PointsPossible.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5PointsPossible[i] = double.Parse(class5PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5PointsPossibleString[i] = Convert.ToString(class5PointsPossible[i]);
                }
                File.WriteAllLines("class5PointsPossible.txt", class5PointsPossibleString);
            }

            //class5Grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class5PointsPossible[i] == 0)
                    class5Grades[i] = 0;
                else
                    class5Grades[i] = class5PointsEarned[i] / class5PointsPossible[i];
            }

            //class5Weights
            if (File.Exists("class5Weights.txt"))
            {
                class5WeightsString = File.ReadAllLines("class5Weights.txt");
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5Weights[i] = double.Parse(class5WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5WeightsString[i] = Convert.ToString(class5Weights[i]);
                }
                File.WriteAllLines("class5Weights.txt", class5WeightsString);
            }

            //class5WeightedGrades
            class5WeightedGrades[0] = 0;
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class5Weights[i] == 0)
                    class5WeightedGrades[i] = 0;
                else
                    class5WeightedGrades[i] = class5Grades[i] * class5Weights[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 6 initialized";


        }

        /* SET TEXTBOXES TO VARIABLES */
        public void Set_Txt_ClassCurr()
        {
            if (selection == 0)
            {
                Set_Txt_Class_0();
            }
            if (selection == 1)
            {
                Set_Txt_Class_1();
            }
            if (selection == 2)
            {
                Set_Txt_Class_2();
            }
            if (selection == 3)
            {
                Set_Txt_Class_3();
            }
            if (selection == 4)
            {
                Set_Txt_Class_4();
            }
            if (selection == 5)
            {
                Set_Txt_Class_5();
            }
        }
        public void Set_Txt_Class_0()
        {
            //Setting textbox to values from array
            if (class0ItemStatus[0] == "yes")
                chkItemStatus0.Checked = true;
            else
                chkItemStatus0.Checked = false;

            if (class0ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class0ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class0ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class0ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class0ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class0ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class0ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class0ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class0ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            //Item Names to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class0ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class0PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class0PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class0Grades[i].ToString("P1");
            }

            //Weights to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class0Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class0WeightedGrades[i].ToString("P1");
            }
        }
        public void Set_Txt_Class_1()
        {
            //Setting textbox to values from array                        
            if (class1ItemStatus[0] == "yes")
                chkItemStatus0.Checked = true;
            else
                chkItemStatus0.Checked = false;

            if (class1ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class1ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class1ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class1ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class1ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class1ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class1ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class1ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class1ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            //Item Names to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class1ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class1PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class1PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class1Grades[i].ToString("P1");
            }

            //Weights to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class1Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class1WeightedGrades[i].ToString("P1");
            }
        }
        public void Set_Txt_Class_2()
        {
            //Setting textbox to values from array
            if (class2ItemStatus[0] == "yes")
                chkItemStatus0.Checked = true;
            else
                chkItemStatus0.Checked = false;

            if (class2ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class2ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class2ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class2ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class2ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class2ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class2ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class2ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class2ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            //Item Names to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class2ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class2PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class2PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class2Grades[i].ToString("P1");
            }

            //Weights to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class2Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class2WeightedGrades[i].ToString("P1");
            }
        }
        public void Set_Txt_Class_3()
        {
            //Setting textbox to values from array
            if (class3ItemStatus[0] == "yes")
                chkItemStatus0.Checked = true;
            else
                chkItemStatus0.Checked = false;

            if (class3ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class3ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class3ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class3ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class3ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class3ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class3ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class3ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class3ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            //Item Names to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class3ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class3PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class3PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class3Grades[i].ToString("P1");
            }

            //Weights to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class3Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class3WeightedGrades[i].ToString("P1");
            }
        }
        public void Set_Txt_Class_4()
        {
            //Setting textbox to values from array
            if (class4ItemStatus[0] == "yes")
                chkItemStatus0.Checked = true;
            else
                chkItemStatus0.Checked = false;

            if (class4ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class4ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class4ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class4ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class4ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class4ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class4ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class4ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class4ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;


            //Item Names to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class4ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class4PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class4PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class4Grades[i].ToString("P1");
            }

            //Weights to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class4Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class4WeightedGrades[i].ToString("P1");
            }
        }
        public void Set_Txt_Class_5()
        {
            //Setting textbox to values from array
            if (class5ItemStatus[0] == "yes")
                chkItemStatus0.Checked = true;
            else
                chkItemStatus0.Checked = false;

            if (class5ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class5ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class5ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class5ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class5ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class5ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class5ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class5ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class5ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;


            //Item Names to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class5ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class5PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class5PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class5Grades[i].ToString("P1");
            }

            //Weights to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class5Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class5WeightedGrades[i].ToString("P1");
            }
        }

        /* SAVE TO ARRAYS */
        //Saves txtboxes to arrays 
        //Than arrays to text files
        public void Save_Class_CurrSel()
        {
            if (selection == 0)
            {
                Save_Class_0();
            }

            else if (selection == 1)
            {
                Save_Class_1();
            }

            else if (selection == 2)
            {
                Save_Class_2();
            }

            else if (selection == 3)
            {
                Save_Class_3();
            }

            else if (selection == 4)
            {
                Save_Class_4();
            }

            else if (selection == 5)
            {
                Save_Class_5();
            }
        }
        public void Save_Class_0()
        {
            //This assigns values to arrays                                
            if (chkItemStatus0.Checked)
                class0ItemStatus[0] = "yes";
            else
                class0ItemStatus[0] = "no";

            if (chkItemStatus1.Checked)
                class0ItemStatus[1] = "yes";
            else
                class0ItemStatus[1] = "no";

            if (chkItemStatus2.Checked)
                class0ItemStatus[2] = "yes";
            else
                class0ItemStatus[2] = "no";

            if (chkItemStatus3.Checked)
                class0ItemStatus[3] = "yes";
            else
                class0ItemStatus[3] = "no";

            if (chkItemStatus4.Checked)
                class0ItemStatus[4] = "yes";
            else
                class0ItemStatus[4] = "no";

            if (chkItemStatus5.Checked)
                class0ItemStatus[5] = "yes";
            else
                class0ItemStatus[5] = "no";

            if (chkItemStatus6.Checked)
                class0ItemStatus[6] = "yes";
            else
                class0ItemStatus[6] = "no";

            if (chkItemStatus7.Checked)
                class0ItemStatus[7] = "yes";
            else
                class0ItemStatus[7] = "no";

            if (chkItemStatus8.Checked)
                class0ItemStatus[8] = "yes";
            else
                class0ItemStatus[8] = "no";

            if (chkItemStatus9.Checked)
                class0ItemStatus[9] = "yes";
            else
                class0ItemStatus[9] = "no";

            //Item Names to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class0ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
            }

            //Points Earned to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class0PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
            }

            //Points Possible to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class0PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
            }

            //Grade calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class0PointsPossible[i] != 0)
                    class0Grades[i] = class0PointsEarned[i] / class0PointsPossible[i];
                else
                    class0Grades[i] = 0;
            }
            //Grade to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class0Grades[i].ToString("P1");
            }

            //Weights to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class0Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
            }

            //Weighted Grade calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class0WeightedGrades[i] = class0Weights[i] * class0Grades[i];
            }
            //Weighted Grade to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class0WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Class0 txtboxes assigned to variables";
        }
        public void Save_Class_1()
        {
            //This assigns values to arrays
            if (chkItemStatus0.Checked)
                class1ItemStatus[0] = "yes";
            else
                class1ItemStatus[0] = "no";

            if (chkItemStatus1.Checked)
                class1ItemStatus[1] = "yes";
            else
                class1ItemStatus[1] = "no";

            if (chkItemStatus2.Checked)
                class1ItemStatus[2] = "yes";
            else
                class1ItemStatus[2] = "no";

            if (chkItemStatus3.Checked)
                class1ItemStatus[3] = "yes";
            else
                class1ItemStatus[3] = "no";

            if (chkItemStatus4.Checked)
                class1ItemStatus[4] = "yes";
            else
                class1ItemStatus[4] = "no";

            if (chkItemStatus5.Checked)
                class1ItemStatus[5] = "yes";
            else
                class1ItemStatus[5] = "no";

            if (chkItemStatus6.Checked)
                class1ItemStatus[6] = "yes";
            else
                class1ItemStatus[6] = "no";

            if (chkItemStatus7.Checked)
                class1ItemStatus[7] = "yes";
            else
                class1ItemStatus[7] = "no";

            if (chkItemStatus8.Checked)
                class1ItemStatus[8] = "yes";
            else
                class1ItemStatus[8] = "no";

            if (chkItemStatus9.Checked)
                class1ItemStatus[9] = "yes";
            else
                class1ItemStatus[9] = "no";


            //Item Names to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class1ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
            }

            //Points Earned to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class1PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
            }

            //Points Possible to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class1PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
            }

            //Grade to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class1PointsPossible[i] != 0)
                    class1Grades[i] = class1PointsEarned[i] / class1PointsPossible[i];
                else
                    class1Grades[i] = 0;
            }
            //Grade to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class1Grades[i].ToString("P1");
            }

            //Weights to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class1Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
            }

            //Weighted Grades calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class1WeightedGrades[i] = class1Weights[i] * class1Grades[i];
            }
            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class1WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Class1 txtboxes assigned to variables";
        }
        public void Save_Class_2()
        {
            //This assigns values to arrays            
            if (chkItemStatus0.Checked)
                class2ItemStatus[0] = "yes";
            else
                class2ItemStatus[0] = "no";

            if (chkItemStatus1.Checked)
                class2ItemStatus[1] = "yes";
            else
                class2ItemStatus[1] = "no";

            if (chkItemStatus2.Checked)
                class2ItemStatus[2] = "yes";
            else
                class2ItemStatus[2] = "no";

            if (chkItemStatus3.Checked)
                class2ItemStatus[3] = "yes";
            else
                class2ItemStatus[3] = "no";

            if (chkItemStatus4.Checked)
                class2ItemStatus[4] = "yes";
            else
                class2ItemStatus[4] = "no";

            if (chkItemStatus5.Checked)
                class2ItemStatus[5] = "yes";
            else
                class2ItemStatus[5] = "no";

            if (chkItemStatus6.Checked)
                class2ItemStatus[6] = "yes";
            else
                class2ItemStatus[6] = "no";

            if (chkItemStatus7.Checked)
                class2ItemStatus[7] = "yes";
            else
                class2ItemStatus[7] = "no";

            if (chkItemStatus8.Checked)
                class2ItemStatus[8] = "yes";
            else
                class2ItemStatus[8] = "no";

            if (chkItemStatus9.Checked)
                class2ItemStatus[9] = "yes";
            else
                class2ItemStatus[9] = "no";

            //Item Names to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class2ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
            }

            //Points Earned to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class2PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
            }

            //Points Possible to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class2PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
            }

            //Grades calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class2PointsPossible[i] != 0)
                    class2Grades[i] = class2PointsEarned[i] / class2PointsPossible[i];
                else
                    class2Grades[i] = 0;
            }
            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class2Grades[i].ToString("P1");
            }

            //Weights to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class2Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
            }

            //Weighted Grades calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class2WeightedGrades[i] = class2Weights[i] * class2Grades[i];
            }
            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class2WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Class2 txtboxes assigned to variables";
        }
        public void Save_Class_3()
        {
            //This assigns values to arrays
            if (chkItemStatus0.Checked)
                class3ItemStatus[0] = "yes";
            else
                class3ItemStatus[0] = "no";

            if (chkItemStatus1.Checked)
                class3ItemStatus[1] = "yes";
            else
                class3ItemStatus[1] = "no";

            if (chkItemStatus2.Checked)
                class3ItemStatus[2] = "yes";
            else
                class3ItemStatus[2] = "no";

            if (chkItemStatus3.Checked)
                class3ItemStatus[3] = "yes";
            else
                class3ItemStatus[3] = "no";

            if (chkItemStatus4.Checked)
                class3ItemStatus[4] = "yes";
            else
                class3ItemStatus[4] = "no";

            if (chkItemStatus5.Checked)
                class3ItemStatus[5] = "yes";
            else
                class3ItemStatus[5] = "no";

            if (chkItemStatus6.Checked)
                class3ItemStatus[6] = "yes";
            else
                class3ItemStatus[6] = "no";

            if (chkItemStatus7.Checked)
                class3ItemStatus[7] = "yes";
            else
                class3ItemStatus[7] = "no";

            if (chkItemStatus8.Checked)
                class3ItemStatus[8] = "yes";
            else
                class3ItemStatus[8] = "no";

            if (chkItemStatus9.Checked)
                class3ItemStatus[9] = "yes";
            else
                class3ItemStatus[9] = "no";


            //Item Names to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class3ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
            }

            //Points Earned to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class3PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
            }

            //Points Possible to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class3PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
            }

            //Grades calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class3PointsPossible[i] != 0)
                    class3Grades[i] = class3PointsEarned[i] / class3PointsPossible[i];
                else
                    class3Grades[i] = 0;
            }

            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class3Grades[i].ToString("P1");
            }

            //Weights to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class3Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
            }

            //Weighted Grades calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class3WeightedGrades[i] = class3Weights[i] * class3Grades[i];
            }

            //Assign new values to txtbox
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class3WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Class3 txtboxes assigned to variables";
        }
        public void Save_Class_4()
        {
            //This assigns values to arrays
            if (chkItemStatus0.Checked)
                class4ItemStatus[0] = "yes";
            else
                class4ItemStatus[0] = "no";

            if (chkItemStatus1.Checked)
                class4ItemStatus[1] = "yes";
            else
                class4ItemStatus[1] = "no";

            if (chkItemStatus2.Checked)
                class4ItemStatus[2] = "yes";
            else
                class4ItemStatus[2] = "no";

            if (chkItemStatus3.Checked)
                class4ItemStatus[3] = "yes";
            else
                class4ItemStatus[3] = "no";

            if (chkItemStatus4.Checked)
                class4ItemStatus[4] = "yes";
            else
                class4ItemStatus[4] = "no";

            if (chkItemStatus5.Checked)
                class4ItemStatus[5] = "yes";
            else
                class4ItemStatus[5] = "no";

            if (chkItemStatus6.Checked)
                class4ItemStatus[6] = "yes";
            else
                class4ItemStatus[6] = "no";

            if (chkItemStatus7.Checked)
                class4ItemStatus[7] = "yes";
            else
                class4ItemStatus[7] = "no";

            if (chkItemStatus8.Checked)
                class4ItemStatus[8] = "yes";
            else
                class4ItemStatus[8] = "no";

            if (chkItemStatus9.Checked)
                class4ItemStatus[9] = "yes";
            else
                class4ItemStatus[9] = "no";


            //Item Names to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class4ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
            }

            //Points Earned to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class4PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
            }

            //Points Possible to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class4PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
            }

            //Grades calculated to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class4PointsPossible[i] != 0)
                    class4Grades[i] = class4PointsEarned[i] / class4PointsPossible[i];
                else
                    class4Grades[i] = 0;
            }
            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class4Grades[i].ToString("P1");
            }

            //Weights to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class4Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
            }

            //Weighted Grades calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class4WeightedGrades[i] = class4Weights[i] * class4Grades[i];
            }
            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class4WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Class4 txtboxes assigned to variables";
        }
        public void Save_Class_5()
        {
            //This assigns values to arrays
            if (chkItemStatus0.Checked)
                class5ItemStatus[0] = "yes";
            else
                class5ItemStatus[0] = "no";

            if (chkItemStatus1.Checked)
                class5ItemStatus[1] = "yes";
            else
                class5ItemStatus[1] = "no";

            if (chkItemStatus2.Checked)
                class5ItemStatus[2] = "yes";
            else
                class5ItemStatus[2] = "no";

            if (chkItemStatus3.Checked)
                class5ItemStatus[3] = "yes";
            else
                class5ItemStatus[3] = "no";

            if (chkItemStatus4.Checked)
                class5ItemStatus[4] = "yes";
            else
                class5ItemStatus[4] = "no";

            if (chkItemStatus5.Checked)
                class5ItemStatus[5] = "yes";
            else
                class5ItemStatus[5] = "no";

            if (chkItemStatus6.Checked)
                class5ItemStatus[6] = "yes";
            else
                class5ItemStatus[6] = "no";

            if (chkItemStatus7.Checked)
                class5ItemStatus[7] = "yes";
            else
                class5ItemStatus[7] = "no";

            if (chkItemStatus8.Checked)
                class5ItemStatus[8] = "yes";
            else
                class5ItemStatus[8] = "no";

            if (chkItemStatus9.Checked)
                class5ItemStatus[9] = "yes";
            else
                class5ItemStatus[9] = "no";


            //Item Names to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class5ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
            }

            //Points Earned to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class5PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
            }

            //Points Possible to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class5PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
            }

            //Grades calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class5PointsPossible[i] != 0)
                    class5Grades[i] = class5PointsEarned[i] / class5PointsPossible[i];
                else
                    class5Grades[i] = 0;
            }
            //Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = class5Grades[i].ToString("P1");
            }

            //Weights to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class5Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
            }

            //Weighted Grades calculate to variables
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class5WeightedGrades[i] = class5Weights[i] * class5Grades[i];
            }
            //Weighted Grades to txtboxes
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class5WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Class5 txtboxes assigned to variables";
        }

        /* SAVE TO TEXT FILE */
        public void Save_Classes_To_Text()
        {
            //CLASS 0
            //class0ItemNames
            File.WriteAllLines("class0ItemNames.txt", class0ItemNames);
            //class0ItemStatus
            File.WriteAllLines("class0ItemStatus.txt", class0ItemStatus);
            //class0PointsEarned
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class0PointsEarnedString[i] = Convert.ToString(class0PointsEarned[i]);
            }
            File.WriteAllLines("class0PointsEarned.txt", class0PointsEarnedString);
            //class0PointsPossible
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class0PointsPossibleString[i] = Convert.ToString(class0PointsPossible[i]);
            }
            File.WriteAllLines("class0PointsPossible.txt", class0PointsPossibleString);
            //class0Weights
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class0WeightsString[i] = Convert.ToString(class0Weights[i]);
            }
            File.WriteAllLines("class0Weights.txt", class0WeightsString);
            //SysMsg
            lblSysMsg.Text = "Class0 variables saved to .txt";

            //CLASS 1
            //class1ItemNames
            File.WriteAllLines("class1ItemNames.txt", class1ItemNames);
            //class1ItemStatus
            File.WriteAllLines("class1ItemStatus.txt", class1ItemStatus);
            //class1PointsEarned
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class1PointsEarnedString[i] = Convert.ToString(class1PointsEarned[i]);
            }
            File.WriteAllLines("class1PointsEarned.txt", class1PointsEarnedString);
            //class1PointsPossible
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class1PointsPossibleString[i] = Convert.ToString(class1PointsPossible[i]);
            }
            File.WriteAllLines("class1PointsPossible.txt", class1PointsPossibleString);
            //class1Weights
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class1WeightsString[i] = Convert.ToString(class1Weights[i]);
            }
            File.WriteAllLines("class1Weights.txt", class1WeightsString);
            //SysMsg
            lblSysMsg.Text = "Class1 variables saved to .txt";

            //CLASS 2
            //class2ItemNames
            File.WriteAllLines("class2ItemNames.txt", class2ItemNames);
            //class2ItemStatus
            File.WriteAllLines("class2ItemStatus.txt", class2ItemStatus);
            //class2PointsEarned
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class2PointsEarnedString[i] = Convert.ToString(class2PointsEarned[i]);
            }
            File.WriteAllLines("class2PointsEarned.txt", class2PointsEarnedString);
            //class2PointsPossible
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class2PointsPossibleString[i] = Convert.ToString(class2PointsPossible[i]);
            }
            File.WriteAllLines("class2PointsPossible.txt", class2PointsPossibleString);
            //class2Weights
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class2WeightsString[i] = Convert.ToString(class2Weights[i]);
            }
            File.WriteAllLines("class2Weights.txt", class2WeightsString);
            //SysMsg
            lblSysMsg.Text = "Class2 variables saved to .txt";

            //CLASS 3
            //class3ItemNames
            File.WriteAllLines("class3ItemNames.txt", class3ItemNames);
            //class3ItemStatus
            File.WriteAllLines("class3ItemStatus.txt", class3ItemStatus);
            //class3PointsEarned
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class3PointsEarnedString[i] = Convert.ToString(class3PointsEarned[i]);
            }
            File.WriteAllLines("class3PointsEarned.txt", class3PointsEarnedString);
            //class3PointsPossible
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class3PointsPossibleString[i] = Convert.ToString(class3PointsPossible[i]);
            }
            File.WriteAllLines("class3PointsPossible.txt", class3PointsPossibleString);
            //class3Weights
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class3WeightsString[i] = Convert.ToString(class3Weights[i]);
            }
            File.WriteAllLines("class3Weights.txt", class3WeightsString);
            //SysMsg
            lblSysMsg.Text = "Class3 variables saved to .txt";

            //CLASS 4
            //class4ItemNames
            File.WriteAllLines("class4ItemNames.txt", class4ItemNames);
            //class4ItemStatus
            File.WriteAllLines("class4ItemStatus.txt", class4ItemStatus);
            //class4PointsEarned
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class4PointsEarnedString[i] = Convert.ToString(class4PointsEarned[i]);
            }
            File.WriteAllLines("class4PointsEarned.txt", class4PointsEarnedString);
            //class4PointsPossible
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class4PointsPossibleString[i] = Convert.ToString(class4PointsPossible[i]);
            }
            File.WriteAllLines("class4PointsPossible.txt", class4PointsPossibleString);
            //class4Weights
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class4WeightsString[i] = Convert.ToString(class4Weights[i]);
            }
            File.WriteAllLines("class4Weights.txt", class4WeightsString);
            //SysMsg
            lblSysMsg.Text = "Class4 variables saved to .txt";

            //CLASS 5
            //class5ItemNames
            File.WriteAllLines("class5ItemNames.txt", class5ItemNames);
            //class5ItemStatus
            File.WriteAllLines("class5ItemStatus.txt", class5ItemStatus);
            //class5PointsEarned
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class5PointsEarnedString[i] = Convert.ToString(class5PointsEarned[i]);
            }
            File.WriteAllLines("class5PointsEarned.txt", class5PointsEarnedString);
            //class5PointsPossible
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class5PointsPossibleString[i] = Convert.ToString(class5PointsPossible[i]);
            }
            File.WriteAllLines("class5PointsPossible.txt", class5PointsPossibleString);
            //class5Weights
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                class5WeightsString[i] = Convert.ToString(class5Weights[i]);
            }
            File.WriteAllLines("class5Weights.txt", class5WeightsString);
            //SysMsg
            lblSysMsg.Text = "Class5 variables saved to .txt";
        }

        /* TOTALS */
        public void Totals()
        {
            Grade_Total();
            Weighted_Grade_Total();
            Statistics();
        }
        public void Grade_Total()
        {
            //Class 0
            double gradeTotal = 0;

            if (selection == 0)
            {
                if (class0PointsPossible.Sum() != 0)
                {
                    gradeTotal = class0PointsEarned.Sum() / class0PointsPossible.Sum();
                }                    
                else
                {
                    lblGrade.Text = "Grade:  0.00%";
                }                    
            }
            //Class 1
            if (selection == 1)
            {
                if (class1PointsPossible.Sum() != 0)
                {
                    gradeTotal = class1PointsEarned.Sum() / class1PointsPossible.Sum();
                }                    
                else
                {
                    gradeTotal = 0;
                }                    
            }
            //Class 2
            if (selection == 2)
            {
                if (class2PointsPossible.Sum() != 0)
                {
                    gradeTotal = class2PointsEarned.Sum() / class2PointsPossible.Sum();
                }
                else
                {
                    gradeTotal = 0;
                }
            }
            //Class 3
            if (selection == 3)
            {
                if (class3PointsPossible.Sum() != 0)
                {
                    gradeTotal = class3PointsEarned.Sum() / class3PointsPossible.Sum();
                }
                else
                {
                    gradeTotal = 0;
                }
            }
            //Class 4
            if (selection == 4)
            {
                if (class4PointsPossible.Sum() != 0)
                {
                    gradeTotal = class4PointsEarned.Sum() / class4PointsPossible.Sum();
                }
                else
                {
                    gradeTotal = 0;
                }
            }
            //Class 5
            if (selection == 5)
            {
                if (class5PointsPossible.Sum() != 0)
                {
                    gradeTotal = class5PointsEarned.Sum() / class5PointsPossible.Sum();
                }
                else
                {
                    gradeTotal = 0;
                }
            }

            //Label
            lblGrade.Text = String.Format("Grade:  {0}", gradeTotal.ToString("P2"));
            lblGrade.ForeColor = Color.White;
            if (gradeTotal >= .9)
            {
                lblGrade.BackColor = Color.LimeGreen;
            }
            if (gradeTotal < .9)
            {
                lblGrade.BackColor = Color.Green;
            }
            if (gradeTotal < .8)
            {
                lblGrade.BackColor = Color.Orange;
            }
            if (gradeTotal < .7)
            {
                lblGrade.BackColor = Color.IndianRed;
            }

            //Progress Bar
            prgGrade.Value = 0;
            for (int i = 0; i < gradeTotal*100; i++)
            {
                prgGrade.PerformStep();
            }            
        }
        public void Weighted_Grade_Total()
        {
            double weightedGradeTotal = 0;
            double totalWeights = 0;

            //Class 0
            if (selection == 0)
            {
                weightedGradeTotal = class0WeightedGrades.Sum();
                totalWeights = class0Weights.Sum();
            }                
            //Class 1
            if (selection == 1)
            {
                weightedGradeTotal = class1WeightedGrades.Sum();
                totalWeights = class1Weights.Sum();
            }
            //Class 2
            if (selection == 2)
            {
                weightedGradeTotal = class2WeightedGrades.Sum();
                totalWeights = class2Weights.Sum();
            }
            //Class 3
            if (selection == 3)
            {
                weightedGradeTotal = class3WeightedGrades.Sum();
                totalWeights = class3Weights.Sum();
            }
            //Class 4
            if (selection == 4)
            {
                weightedGradeTotal = class4WeightedGrades.Sum();
                totalWeights = class4Weights.Sum();
            }
            //Class 5
            if (selection == 5)
            {
                weightedGradeTotal = class5WeightedGrades.Sum();
                totalWeights = class5Weights.Sum();
            }

            //Label
            if (totalWeights != 1)
            {
                lblWeightedGrade.Text = String.Format("Total Weight does not equal 100%");
            }
            else
            {
                lblWeightedGrade.Text = String.Format("Weighted Grade:  {0}", weightedGradeTotal.ToString("P2"));
            }
            
            //Color
            lblWeightedGrade.ForeColor = Color.White;
            if (weightedGradeTotal >= .9)
            {
                lblWeightedGrade.BackColor = Color.LimeGreen;
            }
            if (weightedGradeTotal < .9)
            {
                lblWeightedGrade.BackColor = Color.Green;
            }
            if (weightedGradeTotal < .8)
            {
                lblWeightedGrade.BackColor = Color.Orange;
            }
            if (weightedGradeTotal < .7)
            {
                lblWeightedGrade.BackColor = Color.IndianRed;
            }
            if (totalWeights != 1)
            {
                lblWeightedGrade.BackColor = Color.Gray;
            }

            //Progress Bar
            prgWeightedGrade.Value = 0;
            for (int i = 0; i < weightedGradeTotal * 100; i++)
                prgWeightedGrade.PerformStep();

        }

        /* STATISTICS */
        public void Statistics()
        {
            if (selection == 0)
            {
                if (classNames[0] == "")
                {
                    lblStatClassVal.Text = "[0]";
                }
                else
                {
                    lblStatClassVal.Text = classNames[0];
                }
                
                int completed = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++ )
                {
                    if (class0ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                }
                lblStatCompletedVal.Text = completed.ToString();

                int remaining = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++ )
                {
                    if (class0ItemNames[i] != "" && class0ItemStatus[i] == "no")
                    {
                        remaining += 1;
                    }
                }
                lblStatRemainingVal.Text = remaining.ToString();

                int total = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class0ItemNames[i] != "")
                    {
                        total += 1;
                    }
                }
                lblStatTotalVal.Text = total.ToString();

                lblStatEarnedVal.Text = Convert.ToString(class0PointsEarned.Sum());

                lblStatPossibleVal.Text = Convert.ToString(class0PointsPossible.Sum());

                lblStatGradeVal.Text = (class0PointsEarned.Sum()/class0PointsPossible.Sum()).ToString("P1");

                lblStatWeightVal.Text = class0Weights.Sum().ToString("P1");

                lblStatWeightedGradeVal.Text = class0WeightedGrades.Sum().ToString("P1");
            }
            if (selection == 1)
            {
                if (classNames[1] == "")
                {
                    lblStatClassVal.Text = "[1]";
                }
                else
                {
                    lblStatClassVal.Text = classNames[1];
                }

                int completed = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class1ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                }
                lblStatCompletedVal.Text = completed.ToString();

                int remaining = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class1ItemNames[i] != "" && class1ItemStatus[i] == "no")
                    {
                        remaining += 1;
                    }
                }
                lblStatRemainingVal.Text = remaining.ToString();

                int total = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class1ItemNames[i] != "")
                    {
                        total += 1;
                    }
                }
                lblStatTotalVal.Text = total.ToString();

                lblStatEarnedVal.Text = Convert.ToString(class1PointsEarned.Sum());

                lblStatPossibleVal.Text = Convert.ToString(class1PointsPossible.Sum());

                lblStatGradeVal.Text = (class1PointsEarned.Sum() / class1PointsPossible.Sum()).ToString("P1");

                lblStatWeightVal.Text = class1Weights.Sum().ToString("P1");

                lblStatWeightedGradeVal.Text = class1WeightedGrades.Sum().ToString("P1");
            }
            if (selection == 2)
            {
                if (classNames[2] == "")
                {
                    lblStatClassVal.Text = "[2]";
                }
                else
                {
                    lblStatClassVal.Text = classNames[2];
                }

                int completed = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class2ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                }
                lblStatCompletedVal.Text = completed.ToString();

                int remaining = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class2ItemNames[i] != "" && class2ItemStatus[i] == "no")
                    {
                        remaining += 1;
                    }
                }
                lblStatRemainingVal.Text = remaining.ToString();

                int total = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class2ItemNames[i] != "")
                    {
                        total += 1;
                    }
                }
                lblStatTotalVal.Text = total.ToString();

                lblStatEarnedVal.Text = Convert.ToString(class2PointsEarned.Sum());

                lblStatPossibleVal.Text = Convert.ToString(class2PointsPossible.Sum());

                lblStatGradeVal.Text = (class2PointsEarned.Sum() / class2PointsPossible.Sum()).ToString("P1");

                lblStatWeightVal.Text = class2Weights.Sum().ToString("P1");

                lblStatWeightedGradeVal.Text = class2WeightedGrades.Sum().ToString("P1");
            }
            if (selection == 3)
            {
                if (classNames[3] == "")
                {
                    lblStatClassVal.Text = "[3]";
                }
                else
                {
                    lblStatClassVal.Text = classNames[3];
                }

                int completed = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class3ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                }
                lblStatCompletedVal.Text = completed.ToString();

                int remaining = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class3ItemNames[i] != "" && class3ItemStatus[i] == "no")
                    {
                        remaining += 1;
                    }
                }
                lblStatRemainingVal.Text = remaining.ToString();

                int total = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class3ItemNames[i] != "")
                    {
                        total += 1;
                    }
                }
                lblStatTotalVal.Text = total.ToString();

                lblStatEarnedVal.Text = Convert.ToString(class3PointsEarned.Sum());

                lblStatPossibleVal.Text = Convert.ToString(class3PointsPossible.Sum());

                lblStatGradeVal.Text = (class3PointsEarned.Sum() / class3PointsPossible.Sum()).ToString("P1");

                lblStatWeightVal.Text = class3Weights.Sum().ToString("P1");

                lblStatWeightedGradeVal.Text = class3WeightedGrades.Sum().ToString("P1");
            }
            if (selection == 4)
            {
                if (classNames[4] == "")
                {
                    lblStatClassVal.Text = "[4]";
                }
                else
                {
                    lblStatClassVal.Text = classNames[4];
                }

                int completed = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class4ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                }
                lblStatCompletedVal.Text = completed.ToString();

                int remaining = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class4ItemNames[i] != "" && class4ItemStatus[i] == "no")
                    {
                        remaining += 1;
                    }
                }
                lblStatRemainingVal.Text = remaining.ToString();

                int total = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class4ItemNames[i] != "")
                    {
                        total += 1;
                    }
                }
                lblStatTotalVal.Text = total.ToString();

                lblStatEarnedVal.Text = Convert.ToString(class4PointsEarned.Sum());

                lblStatPossibleVal.Text = Convert.ToString(class4PointsPossible.Sum());

                lblStatGradeVal.Text = (class4PointsEarned.Sum() / class4PointsPossible.Sum()).ToString("P1");

                lblStatWeightVal.Text = class4Weights.Sum().ToString("P1");

                lblStatWeightedGradeVal.Text = class4WeightedGrades.Sum().ToString("P1");
            }
            if (selection == 5)
            {
                if (classNames[5] == "")
                {
                    lblStatClassVal.Text = "[5]";
                }
                else
                {
                    lblStatClassVal.Text = classNames[5];
                }

                int completed = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class5ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                }
                lblStatCompletedVal.Text = completed.ToString();

                int remaining = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class5ItemNames[i] != "" && class5ItemStatus[i] == "no")
                    {
                        remaining += 1;
                    }
                }
                lblStatRemainingVal.Text = remaining.ToString();

                int total = 0;
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class5ItemNames[i] != "")
                    {
                        total += 1;
                    }
                }
                lblStatTotalVal.Text = total.ToString();

                lblStatEarnedVal.Text = Convert.ToString(class5PointsEarned.Sum());

                lblStatPossibleVal.Text = Convert.ToString(class5PointsPossible.Sum());

                lblStatGradeVal.Text = (class5PointsEarned.Sum() / class5PointsPossible.Sum()).ToString("P1");

                lblStatWeightVal.Text = class5Weights.Sum().ToString("P1");

                lblStatWeightedGradeVal.Text = class5WeightedGrades.Sum().ToString("P1");
            }
        }



        //=======================================================================================================
        /* **** COLOR **** */
        //=======================================================================================================

        /* ColorScheme drop down box on change event */
        private void cboColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorScheme = cboColorScheme.Text;

            if (colorScheme == "(default)")
            {
                Color_Scheme_Default();
            }

            else if (colorScheme == "Cool")
            {
                Color_Scheme_Cool();
            }

            else if (colorScheme == "Hello Kitty")
            {
                Color_Scheme_HelloKitty();
            }

            else if (colorScheme == "Midnight")
            {
                Color_Scheme_Midnight();
            }

            //Saves color scheme selection to text file
            Color_Scheme_Save();
        }

        /* Color scheme actions */
        public void Color_Scheme_Set()
        {
            //Set sys btn colors
            btnSettings.BackColor = btnClassNotSelected.BackColor;

            //Set class btn colors
            for (int i = 0; i < NUMBER_OF_CLASSES; i++)
            {
                pnlClassBtns.Controls["btnClass" + i].BackColor = btnClassNotSelected.BackColor;
            }

            //Sets class selection color
            if (selection == 0)
                btnClass0.BackColor = btnClassSelected.BackColor;
            else if (selection == 1)
                btnClass1.BackColor = btnClassSelected.BackColor;
            else if (selection == 2)
                btnClass2.BackColor = btnClassSelected.BackColor;
            else if (selection == 3)
                btnClass3.BackColor = btnClassSelected.BackColor;
            else if (selection == 4)
                btnClass4.BackColor = btnClassSelected.BackColor;
            else if (selection == 5)
                btnClass5.BackColor = btnClassSelected.BackColor;

            //Sets what ifs
            btnScenarioToPass.BackColor = btnClassNotSelected.BackColor;
            btnScenarioMostLikely.BackColor = btnClassNotSelected.BackColor;
            btnScenarioA.BackColor = btnClassNotSelected.BackColor;

            //Sets clear and clear all
            btnClearCurrent.BackColor = btnClassNotSelected.BackColor;
            btnClearAll.BackColor = btnClassNotSelected.BackColor;
        }
        public void Color_Scheme_Save()
        {
            File.WriteAllText("colorScheme.txt", colorScheme);
        }

        /* Color schemes */
        public void Color_Scheme_Default()
        {
            //Set colors
            this.BackColor = default(Color);
            this.ForeColor = default(Color);
            btnClassSelected.BackColor = Color.LightGray;
            btnClassNotSelected.BackColor = default(Color);
            txtDone.BackColor = Color.LightGray;
            txtNotDone.BackColor = Color.White;

            //Set
            Color_Scheme_Set();
        }
        public void Color_Scheme_Cool()
        {
            //Set colors
            this.BackColor = Color.LightSkyBlue;
            this.ForeColor = Color.DarkBlue;
            btnClassSelected.BackColor = Color.Cyan;
            btnClassNotSelected.BackColor = Color.LightCyan;
            txtDone.BackColor = Color.LightGray;
            txtNotDone.BackColor = Color.White;

            //Set
            Color_Scheme_Set();
        }
        public void Color_Scheme_HelloKitty()
        {
            //Set color
            this.BackColor = Color.LightPink;
            this.ForeColor = Color.DarkRed;
            btnClassSelected.BackColor = Color.HotPink;
            btnClassNotSelected.BackColor = Color.Pink;
            txtDone.BackColor = Color.LightGray;
            txtNotDone.BackColor = Color.White;

            //Set
            Color_Scheme_Set();
        }
        public void Color_Scheme_Midnight()
        {
            //Set colors
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            btnClassSelected.BackColor = Color.Black;
            btnClassNotSelected.BackColor = Color.Gray;
            txtDone.BackColor = Color.Gray;
            txtNotDone.BackColor = Color.White;

            //Set
            Color_Scheme_Set();
        }

        /* Sets finished item visuals */
        public void Fin_Items_Class_0()
        {
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class0ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                if (class0ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }
        }
        public void Fin_Items_Class_1()
        {
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class1ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                if (class1ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }
        }
        public void Fin_Items_Class_2()
        {
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class2ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                if (class2ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }
        }
        public void Fin_Items_Class_3()
        {
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class3ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                if (class3ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }
        }
        public void Fin_Items_Class_4()
        {
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class4ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                if (class4ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }
        }
        public void Fin_Items_Class_5()
        {
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class5ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                if (class5ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }
        }
        public void Fin_Items_Class_CurrSel()
        {
            //Visuals for finished items
            if (selection == 0)
            {
                Fin_Items_Class_0();
            }

            else if (selection == 1)
            {
                Fin_Items_Class_1();
            }

            else if (selection == 2)
            {
                Fin_Items_Class_2();
            }

            else if (selection == 3)
            {
                Fin_Items_Class_3();
            }

            else if (selection == 4)
            {
                Fin_Items_Class_4();
            }

            else if (selection == 5)
            {
                Fin_Items_Class_5();
            }
        }



        //=======================================================================================================
        /* **** BTNS **** */
        //=======================================================================================================

        /* SETTINGS */
        private void btnSettings_Click(object sender, EventArgs e)
        {
            //To change class names
            if (classRenameStatus == 0)
            {
                //Show class selection
                if (selection == 0)
                {
                    txtClassName0.BackColor = btnClassNotSelected.BackColor;
                }
                if (selection == 1)
                {
                    txtClassName1.BackColor = btnClassNotSelected.BackColor;
                }
                if (selection == 2)
                {
                    txtClassName2.BackColor = btnClassNotSelected.BackColor;
                }
                if (selection == 3)
                {
                    txtClassName3.BackColor = btnClassNotSelected.BackColor;
                }
                if (selection == 4)
                {
                    txtClassName4.BackColor = btnClassNotSelected.BackColor;
                }
                if (selection == 5)
                {
                    txtClassName5.BackColor = btnClassNotSelected.BackColor;
                }

                //Hide buttons
                for (int i = 0; i < NUMBER_OF_CLASSES; i++)
                {
                    //Hide buttons
                    pnlClassBtns.Controls["btnClass" + i].Visible = false;
                    //Bring current names into txtboxes
                    pnlClassBtns.Controls["txtClassName" + i].Text = classNames[i];
                    //Show txtboxes
                    pnlClassBtns.Controls["txtClassName" + i].Visible = true;
                }

                //Change text and color
                btnSettings.Text = "";  //REMOVED WITH IMAGE
                btnSettings.BackColor = btnClassSelected.BackColor;

                //clear and clear all
                btnClearCurrent.Location = btnScenarioToPass.Location;
                btnClearAll.Location = btnScenarioMostLikely.Location;

                btnScenarioToPass.Visible = false;
                btnScenarioMostLikely.Visible = false;
                btnScenarioA.Visible = false;

                btnClearCurrent.Visible = true;
                btnClearAll.Visible = true;

                //Set status for next click
                classRenameStatus = 1;

                //SysMsg
                lblSysMsg.Text = "Rename your classes";
            }

            //To save new class names
            else if (classRenameStatus == 1)
            {
                for (int i = 0; i < NUMBER_OF_CLASSES; i++)
                {
                    //Shows class btns
                    pnlClassBtns.Controls["btnClass" + i].Visible = true;
                    //Hide class txtboxes
                    pnlClassBtns.Controls["txtClassName" + i].Visible = false;
                    //Assign values in txtboxes to btns
                    classNames[i] = pnlClassBtns.Controls["txtClassName" + i].Text;
                    //Assign array values to btns
                    pnlClassBtns.Controls["btnClass" + i].Text = classNames[i];
                }

                //Store array values to text file
                File.WriteAllLines("classNames.txt", classNames);

                //Change text and color
                btnSettings.Text = ""; //REMOVED WITH IMAGE
                btnSettings.BackColor = btnClassNotSelected.BackColor;

                //clear and clear all
                btnClearCurrent.Visible = false;
                btnClearAll.Visible = false;

                //Hide what ifs
                btnScenarioToPass.Visible = true;
                btnScenarioMostLikely.Visible = true;
                btnScenarioA.Visible = true;

                //Set status for next click
                classRenameStatus = 0;

                Statistics();

                //SysMsg
                lblSysMsg.Text = "Class names saved to .txt";
            }
        }

        /* CLASSES */
        private void btnClass0_Click(object sender, EventArgs e)
        {
            //Saves previous selection
            Save_Class_CurrSel();

            //Selection
            selection = 0;

            //Set btn to selected
            btnClass0.BackColor = btnClassSelected.BackColor;
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;

            //Set txtbox
            Set_Txt_Class_0();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[0];
            //SysMsg
            lblSysMsg.Text = "class0 has been selected";
        }
        private void btnClass1_Click(object sender, EventArgs e)
        {
            //Saves previous selection
            Save_Class_CurrSel();

            //Selection
            selection = 1;

            //Visuals
            btnClass0.BackColor = btnClassNotSelected.BackColor;
            btnClass1.BackColor = btnClassSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;

            //txtboxes
            Set_Txt_Class_1();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[1];
            //SysMsg
            lblSysMsg.Text = "class1 has been selected";
        }
        private void btnClass2_Click(object sender, EventArgs e)
        {
            //Save previous selection
            Save_Class_CurrSel();

            //Selection
            selection = 2;

            //Visuals
            btnClass0.BackColor = btnClassNotSelected.BackColor;
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;

            //txtboxes
            Set_Txt_Class_2();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[2];
            //SysMsg
            lblSysMsg.Text = "class2 has been selected";
        }
        private void btnClass3_Click(object sender, EventArgs e)
        {
            //Save previous selection
            Save_Class_CurrSel();

            //Selection
            selection = 3;

            //Visuals
            btnClass0.BackColor = btnClassNotSelected.BackColor;
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;

            //txtboxes
            Set_Txt_Class_3();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[3];
            //SysMsg
            lblSysMsg.Text = "class3 has been selected";
        }
        private void btnClass4_Click(object sender, EventArgs e)
        {
            //Save previous selection
            Save_Class_CurrSel();

            //Selection
            selection = 4;

            //Visuals
            btnClass0.BackColor = btnClassNotSelected.BackColor;
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;

            //txtboxes
            Set_Txt_Class_4();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[4];
            //SysMsg
            lblSysMsg.Text = "class4 has been selected";
        }
        private void btnClass5_Click(object sender, EventArgs e)
        {
            //Save previous selection
            Save_Class_CurrSel();

            //Selection
            selection = 5;

            //Visuals
            btnClass0.BackColor = btnClassNotSelected.BackColor;
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassSelected.BackColor;

            //txtboxes
            Set_Txt_Class_5();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[5];
            //SysMsg
            lblSysMsg.Text = "class5 has been selected";
        }

        /* What If's */
        private void btnScenarioToPass_Click(object sender, EventArgs e)
        {

        }
        private void btnScenarioMostLikely_Click(object sender, EventArgs e)
        {

        }
        private void btnScenarioA_Click(object sender, EventArgs e)
        {

        }

        /* CLEAR */
        private void btnClearCurrent_Click(object sender, EventArgs e)
        {            
            string message = String.Format("Are you sure you want to clear all your data for {0}?",  lblClass.Text.ToString());
            string caption = "Warning";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (selection == 0)
                {
                    txtClassName0.Text = "";
                    classNames[0] = txtClassName0.Text;

                    //Item status = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class0ItemStatus[i] = "no";
                    }

                    //Item Names = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class0ItemNames[i] = "";
                    }

                    //Points Earned = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class0PointsEarned[i] = 0;
                    }

                    //Points Possible = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class0PointsPossible[i] = 0;
                    }

                    //Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class0PointsPossible[i] != 0)
                            class0Grades[i] = class0PointsEarned[i] / class0PointsPossible[i];
                        else
                            class0Grades[i] = 0;
                    }

                    //Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class0Grades[i]);
                    }

                    //Weights to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class0Weights[i] = 0;
                    }

                    //Weighted Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class0WeightedGrades[i] = class0Weights[i] * class0Grades[i];
                    }
                    //Weighted Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class0WeightedGrades[i]);
                    }
                }
                if (selection == 1)
                {
                    txtClassName1.Text = "";
                    classNames[1] = txtClassName1.Text;

                    //Item status = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class1ItemStatus[i] = "no";
                    }

                    //Item Names = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class1ItemNames[i] = "";
                    }

                    //Points Earned = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class1PointsEarned[i] = 0;
                    }

                    //Points Possible = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class1PointsPossible[i] = 0;
                    }

                    //Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1PointsPossible[i] != 0)
                            class1Grades[i] = class1PointsEarned[i] / class1PointsPossible[i];
                        else
                            class1Grades[i] = 0;
                    }

                    //Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class1Grades[i]);
                    }

                    //Weights to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class1Weights[i] = 0;
                    }

                    //Weighted Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class1WeightedGrades[i] = class1Weights[i] * class1Grades[i];
                    }
                    //Weighted Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class1WeightedGrades[i]);
                    }
                }
                if (selection == 2)
                {
                    txtClassName2.Text = "";
                    classNames[2] = txtClassName2.Text;

                    //Item status = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class2ItemStatus[i] = "no";
                    }

                    //Item Names = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class2ItemNames[i] = "";
                    }

                    //Points Earned = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class2PointsEarned[i] = 0;
                    }

                    //Points Possible = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class2PointsPossible[i] = 0;
                    }

                    //Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2PointsPossible[i] != 0)
                            class2Grades[i] = class2PointsEarned[i] / class2PointsPossible[i];
                        else
                            class2Grades[i] = 0;
                    }

                    //Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class2Grades[i]);
                    }

                    //Weights to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class2Weights[i] = 0;
                    }

                    //Weighted Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class2WeightedGrades[i] = class2Weights[i] * class2Grades[i];
                    }
                    //Weighted Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class2WeightedGrades[i]);
                    }
                }
                if (selection == 3)
                {
                    txtClassName3.Text = "";
                    classNames[3] = txtClassName3.Text;

                    //Item status = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class3ItemStatus[i] = "no";
                    }

                    //Item Names = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class3ItemNames[i] = "";
                    }

                    //Points Earned = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class3PointsEarned[i] = 0;
                    }

                    //Points Possible = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class3PointsPossible[i] = 0;
                    }

                    //Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3PointsPossible[i] != 0)
                            class3Grades[i] = class3PointsEarned[i] / class3PointsPossible[i];
                        else
                            class3Grades[i] = 0;
                    }

                    //Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class3Grades[i]);
                    }

                    //Weights to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class3Weights[i] = 0;
                    }

                    //Weighted Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class3WeightedGrades[i] = class3Weights[i] * class3Grades[i];
                    }
                    //Weighted Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class3WeightedGrades[i]);
                    }
                }
                if (selection == 4)
                {
                    txtClassName4.Text = "";
                    classNames[4] = txtClassName4.Text;

                    //Item status = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class4ItemStatus[i] = "no";
                    }

                    //Item Names = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class4ItemNames[i] = "";
                    }

                    //Points Earned = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class4PointsEarned[i] = 0;
                    }

                    //Points Possible = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class4PointsPossible[i] = 0;
                    }

                    //Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4PointsPossible[i] != 0)
                            class4Grades[i] = class4PointsEarned[i] / class4PointsPossible[i];
                        else
                            class4Grades[i] = 0;
                    }

                    //Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class4Grades[i]);
                    }

                    //Weights to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class4Weights[i] = 0;
                    }

                    //Weighted Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class4WeightedGrades[i] = class4Weights[i] * class4Grades[i];
                    }
                    //Weighted Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class4WeightedGrades[i]);
                    }
                }
                if (selection == 5)
                {
                    txtClassName5.Text = "";
                    classNames[5] = txtClassName5.Text;

                    //Item status = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class5ItemStatus[i] = "no";
                    }

                    //Item Names = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class5ItemNames[i] = "";
                    }

                    //Points Earned = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class5PointsEarned[i] = 0;
                    }

                    //Points Possible = blank
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class5PointsPossible[i] = 0;
                    }

                    //Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5PointsPossible[i] != 0)
                            class5Grades[i] = class5PointsEarned[i] / class5PointsPossible[i];
                        else
                            class5Grades[i] = 0;
                    }

                    //Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class5Grades[i]);
                    }

                    //Weights to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class5Weights[i] = 0;
                    }

                    //Weighted Grades calculate to variables
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class5WeightedGrades[i] = class5Weights[i] * class5Grades[i];
                    }
                    //Weighted Grades to txtboxes
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class5WeightedGrades[i]);
                    }                    
                }

                Totals();
            }

            //Set txtboxes so save doesnt pick up old ones
            Set_Txt_ClassCurr();
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            string message = String.Format("Are you sure you want to clear all your data?");
            string caption = "Warning";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //Class names
                for (int i = 0; i < NUMBER_OF_CLASSES; i++)
                {
                    pnlClassBtns.Controls["txtClassName" + i].Text = "";
                }

                //CLASS 0
                //Item status = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0ItemStatus[i] = "";
                }

                //Item Names = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0ItemNames[i] = "";
                }

                //Points Earned = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0PointsEarned[i] = 0;
                }

                //Points Possible = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0PointsPossible[i] = 0;
                }

                //Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class0PointsPossible[i] != 0)
                        class0Grades[i] = class0PointsEarned[i] / class0PointsPossible[i];
                    else
                        class0Grades[i] = 0;
                }

                //Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class0Grades[i]);
                }

                //Weights to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0Weights[i] = 0;
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0WeightedGrades[i] = class0Weights[i] * class0Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class0WeightedGrades[i]);
                }

                //CLASS 1
                //Item status = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1ItemStatus[i] = "";
                }

                //Item Names = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1ItemNames[i] = "";
                }

                //Points Earned = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1PointsEarned[i] = 0;
                }

                //Points Possible = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1PointsPossible[i] = 0;
                }

                //Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class1PointsPossible[i] != 0)
                        class1Grades[i] = class1PointsEarned[i] / class1PointsPossible[i];
                    else
                        class1Grades[i] = 0;
                }

                //Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class1Grades[i]);
                }

                //Weights to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1Weights[i] = 0;
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1WeightedGrades[i] = class1Weights[i] * class1Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class1WeightedGrades[i]);
                }

                //CLASS 2
                //Item status = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2ItemStatus[i] = "";
                }

                //Item Names = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2ItemNames[i] = "";
                }

                //Points Earned = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2PointsEarned[i] = 0;
                }

                //Points Possible = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2PointsPossible[i] = 0;
                }

                //Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class2PointsPossible[i] != 0)
                        class2Grades[i] = class2PointsEarned[i] / class2PointsPossible[i];
                    else
                        class2Grades[i] = 0;
                }

                //Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class2Grades[i]);
                }

                //Weights to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2Weights[i] = 0;
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2WeightedGrades[i] = class2Weights[i] * class2Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class2WeightedGrades[i]);
                }

                //CLASS 3
                //Item status = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3ItemStatus[i] = "";
                }

                //Item Names = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3ItemNames[i] = "";
                }

                //Points Earned = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3PointsEarned[i] = 0;
                }

                //Points Possible = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3PointsPossible[i] = 0;
                }

                //Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class3PointsPossible[i] != 0)
                        class3Grades[i] = class3PointsEarned[i] / class3PointsPossible[i];
                    else
                        class3Grades[i] = 0;
                }

                //Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class3Grades[i]);
                }

                //Weights to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3Weights[i] = 0;
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3WeightedGrades[i] = class3Weights[i] * class3Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class3WeightedGrades[i]);
                }

                //CLASS 4
                //Item status = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4ItemStatus[i] = "";
                }

                //Item Names = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4ItemNames[i] = "";
                }

                //Points Earned = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4PointsEarned[i] = 0;
                }

                //Points Possible = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4PointsPossible[i] = 0;
                }

                //Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class4PointsPossible[i] != 0)
                        class4Grades[i] = class4PointsEarned[i] / class4PointsPossible[i];
                    else
                        class4Grades[i] = 0;
                }

                //Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class4Grades[i]);
                }

                //Weights to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4Weights[i] = 0;
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4WeightedGrades[i] = class4Weights[i] * class4Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class4WeightedGrades[i]);
                }

                //CLASS 5
                //Item status = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5ItemStatus[i] = "";
                }

                //Item Names = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5ItemNames[i] = "";
                }

                //Points Earned = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5PointsEarned[i] = 0;
                }

                //Points Possible = blank
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5PointsPossible[i] = 0;
                }

                //Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class5PointsPossible[i] != 0)
                        class5Grades[i] = class5PointsEarned[i] / class5PointsPossible[i];
                    else
                        class5Grades[i] = 0;
                }

                //Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class5Grades[i]);
                }

                //Weights to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5Weights[i] = 0;
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5WeightedGrades[i] = class5Weights[i] * class5Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class5WeightedGrades[i]);
                }
            }

            Set_Txt_ClassCurr();
            Totals();
        }



        //=======================================================================================================
        /* **** EVENTS **** */
        //=======================================================================================================

        /* Check box change events */
        private void chkItemStatus0_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 0;
            if (selection == 0)
            {
                if (chkItemStatus0.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus0.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus0.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus0.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus0.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus0.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }
        private void chkItemStatus1_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 1;
            if (selection == 0)
            {
                if (chkItemStatus1.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus1.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus1.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus1.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus1.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus1.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }
        private void chkItemStatus2_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 2;
            if (selection == 0)
            {
                if (chkItemStatus2.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus2.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus2.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus2.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus2.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus2.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }
        private void chkItemStatus3_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 3;
            if (selection == 0)
            {
                if (chkItemStatus3.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus3.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus3.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus3.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus3.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus3.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }
        private void chkItemStatus4_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 4;
            if (selection == 0)
            {
                if (chkItemStatus4.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus4.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus4.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus4.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus4.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus4.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }
        private void chkItemStatus5_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 5;
            if (selection == 0)
            {
                if (chkItemStatus5.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus5.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus5.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus5.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus5.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus5.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }
        private void chkItemStatus6_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 6;
            if (selection == 0)
            {
                if (chkItemStatus6.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus6.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus6.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus6.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus6.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus6.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }
        private void chkItemStatus7_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 7;
            if (selection == 0)
            {
                if (chkItemStatus7.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus7.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus7.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus7.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus7.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus7.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }
        private void chkItemStatus8_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 8;
            if (selection == 0)
            {
                if (chkItemStatus8.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus8.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus8.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus8.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus8.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus8.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }
        private void chkItemStatus9_CheckedChanged(object sender, EventArgs e)
        {
            const int ITEM_STATUS_NUM = 9;
            if (selection == 0)
            {
                if (chkItemStatus9.Checked)
                    class0ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class0ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 1)
            {
                if (chkItemStatus9.Checked)
                    class1ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class1ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 2)
            {
                if (chkItemStatus9.Checked)
                    class2ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class2ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 3)
            {
                if (chkItemStatus9.Checked)
                    class3ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class3ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 4)
            {
                if (chkItemStatus9.Checked)
                    class4ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class4ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            if (selection == 5)
            {
                if (chkItemStatus9.Checked)
                    class5ItemStatus[ITEM_STATUS_NUM] = "yes";
                else
                    class5ItemStatus[ITEM_STATUS_NUM] = "no";
            }
            Fin_Items_Class_CurrSel();
            Statistics();
        }

        /* Item Name on Leave */
        private void txtItemName0_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }
        private void txtItemName1_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }
        private void txtItemName2_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }
        private void txtItemName3_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }
        private void txtItemName4_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }
        private void txtItemName5_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }
        private void txtItemName6_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }
        private void txtItemName7_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }
        private void txtItemName8_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }
        private void txtItemName9_Leave(object sender, EventArgs e)
        {
            Save_Class_CurrSel();
            Statistics();
        }

        /* Earned on Enter */
        private void txtItemEarned0_Enter(object sender, EventArgs e)
        {
            txtItemEarned0.SelectAll();
        }
        private void txtItemEarned1_Enter(object sender, EventArgs e)
        {
            txtItemEarned1.SelectAll();
        }
        private void txtItemEarned2_Enter(object sender, EventArgs e)
        {
            txtItemEarned2.SelectAll();
        }
        private void txtItemEarned3_Enter(object sender, EventArgs e)
        {
            txtItemEarned3.SelectAll();
        }
        private void txtItemEarned4_Enter(object sender, EventArgs e)
        {
            txtItemEarned4.SelectAll();
        }
        private void txtItemEarned5_Enter(object sender, EventArgs e)
        {
            txtItemEarned5.SelectAll();
        }
        private void txtItemEarned6_Enter(object sender, EventArgs e)
        {
            txtItemEarned6.SelectAll();
        }
        private void txtItemEarned7_Enter(object sender, EventArgs e)
        {
            txtItemEarned7.SelectAll();
        }
        private void txtItemEarned8_Enter(object sender, EventArgs e)
        {
            txtItemEarned8.SelectAll();
        }
        private void txtItemEarned9_Enter(object sender, EventArgs e)
        {
            txtItemEarned9.SelectAll();
        }

        /* Earned on Leave */
        private void txtItemEarned0_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned0.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned0.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemEarned1_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned1.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned1.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemEarned2_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned2.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned2.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemEarned3_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned3.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned3.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemEarned4_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned4.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned4.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemEarned5_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned5.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned5.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemEarned6_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned6.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned6.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemEarned7_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned7.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned7.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemEarned8_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned8.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned8.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemEarned9_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemEarned9.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemEarned9.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }

        /* Points possible on Enter */
        private void txtItemPossible0_Enter(object sender, EventArgs e)
        {
            txtItemPossible0.SelectAll();
        }
        private void txtItemPossible1_Enter(object sender, EventArgs e)
        {
            txtItemPossible1.SelectAll();
        }
        private void txtItemPossible2_Enter(object sender, EventArgs e)
        {
            txtItemPossible2.SelectAll();
        }
        private void txtItemPossible3_Enter(object sender, EventArgs e)
        {
            txtItemPossible3.SelectAll();
        }
        private void txtItemPossible4_Enter(object sender, EventArgs e)
        {
            txtItemPossible4.SelectAll();
        }
        private void txtItemPossible5_Enter(object sender, EventArgs e)
        {
            txtItemPossible5.SelectAll();
        }
        private void txtItemPossible6_Enter(object sender, EventArgs e)
        {
            txtItemPossible6.SelectAll();
        }
        private void txtItemPossible7_Enter(object sender, EventArgs e)
        {
            txtItemPossible7.SelectAll();
        }
        private void txtItemPossible8_Enter(object sender, EventArgs e)
        {
            txtItemPossible8.SelectAll();
        }
        private void txtItemPossible9_Enter(object sender, EventArgs e)
        {
            txtItemPossible9.SelectAll();
        }

        /* Points possible on Leave */
        private void txtItemPossible0_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible0.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible0.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemPossible1_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible1.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible1.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemPossible2_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible2.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible2.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemPossible3_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible3.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible3.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemPossible4_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible4.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible4.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemPossible5_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible5.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible5.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemPossible6_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible6.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible6.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemPossible7_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible7.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible7.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemPossible8_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible8.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible8.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemPossible9_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemPossible9.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemPossible9.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }

        /* Weight on Enter */
        private void txtItemWeight0_Enter(object sender, EventArgs e)
        {
            txtItemWeight0.SelectAll();
        }
        private void txtItemWeight1_Enter(object sender, EventArgs e)
        {
            txtItemWeight1.SelectAll();
        }
        private void txtItemWeight2_Enter(object sender, EventArgs e)
        {
            txtItemWeight2.SelectAll();
        }
        private void txtItemWeight3_Enter(object sender, EventArgs e)
        {
            txtItemWeight3.SelectAll();
        }
        private void txtItemWeight4_Enter(object sender, EventArgs e)
        {
            txtItemWeight4.SelectAll();
        }
        private void txtItemWeight5_Enter(object sender, EventArgs e)
        {
            txtItemWeight5.SelectAll();
        }
        private void txtItemWeight6_Enter(object sender, EventArgs e)
        {
            txtItemWeight6.SelectAll();
        }
        private void txtItemWeight7_Enter(object sender, EventArgs e)
        {
            txtItemWeight7.SelectAll();
        }
        private void txtItemWeight8_Enter(object sender, EventArgs e)
        {
            txtItemWeight8.SelectAll();
        }
        private void txtItemWeight9_Enter(object sender, EventArgs e)
        {
            txtItemWeight9.SelectAll();
        }

        /* Weight on Leave */
        private void txtItemWeight0_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight0.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight0.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemWeight1_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight1.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight1.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemWeight2_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight2.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight2.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemWeight3_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight3.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight3.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemWeight4_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight4.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight4.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemWeight5_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight5.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight5.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemWeight6_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight6.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight6.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemWeight7_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight7.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight7.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemWeight8_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight8.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight8.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }
        private void txtItemWeight9_Leave(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(txtItemWeight9.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                Set_Txt_ClassCurr();
                txtItemWeight9.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }

        /* On close event */
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save_Class_CurrSel();
            Save_Classes_To_Text();
        }
    }
}
