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
    public partial class Main : Form
    {
        //Constants
        const int NUMBER_OF_CLASSES = 6;
        const int NUMBER_OF_ITEMS = 10;

        //Setting status to default for Class naming controls
        int classRenameStatus = 0;

        //Sets class selection to none
        int selection = 0;

        //String for color scheme
        string colorScheme;

        //array for class names (GUI)
        string[] classNames = new string[7];

        //Declaring arrays for class01
        string[] class01ItemNames = new string[21];
        string[] class01ItemStatus = new string[21];

        string[] class01PointsEarnedString = new string[21];
        string[] class01PointsPossibleString = new string[21];
        string[] class01WeightsString = new string[21];

        double[] class01PointsEarned = new double[21];
        double[] class01PointsPossible = new double[21];
        double[] class01Grades = new double[NUMBER_OF_ITEMS+1];
        double[] class01Weights = new double[21];
        double[] class01WeightedGrades = new double[NUMBER_OF_ITEMS+1];

        //Declaring arrays for class02
        string[] class02ItemNames = new string[21];
        string[] class02ItemStatus = new string[21];

        string[] class02PointsEarnedString = new string[21];
        string[] class02PointsPossibleString = new string[21];
        string[] class02WeightsString = new string[21];

        double[] class02PointsEarned = new double[21];
        double[] class02PointsPossible = new double [21];
        double[] class02Grades = new double[NUMBER_OF_ITEMS + 1];
        double[] class02Weights = new double[21];
        double[] class02WeightedGrades = new double[NUMBER_OF_ITEMS + 1];

        //Declaring arrays for class03
        string[] class03ItemNames = new string[21];
        string[] class03ItemStatus = new string[21];

        string[] class03PointsEarnedString = new string[21];
        string[] class03PointsPossibleString = new string[21];
        string[] class03WeightsString = new string[21];

        double[] class03PointsEarned = new double[21];
        double[] class03PointsPossible = new double[21];
        double[] class03Grades = new double[NUMBER_OF_ITEMS + 1];
        double[] class03Weights = new double[21];
        double[] class03WeightedGrades = new double[NUMBER_OF_ITEMS + 1];

        //Declaring arrays for class04
        string[] class04ItemNames = new string[21];
        string[] class04ItemStatus = new string[21];

        string[] class04PointsEarnedString = new string[21];
        string[] class04PointsPossibleString = new string[21];
        string[] class04WeightsString = new string[21];

        double[] class04PointsEarned = new double[21];
        double[] class04PointsPossible = new double[21];
        double[] class04Grades = new double[NUMBER_OF_ITEMS + 1];
        double[] class04Weights = new double[21];
        double[] class04WeightedGrades = new double[NUMBER_OF_ITEMS + 1];

        //Declaring arrays for class05
        string[] class05ItemNames = new string[21];
        string[] class05ItemStatus = new string[21];

        string[] class05PointsEarnedString = new string[21];
        string[] class05PointsPossibleString = new string[21];
        string[] class05WeightsString = new string[21];

        double[] class05PointsEarned = new double[21];
        double[] class05PointsPossible = new double[21];
        double[] class05Grades = new double[NUMBER_OF_ITEMS + 1];
        double[] class05Weights = new double[21];
        double[] class05WeightedGrades = new double[NUMBER_OF_ITEMS + 1];

        //Declaring arrays for class06
        string[] class06ItemNames = new string[21];
        string[] class06ItemStatus = new string[21];

        string[] class06PointsEarnedString = new string[21];
        string[] class06PointsPossibleString = new string[21];
        string[] class06WeightsString = new string[21];

        double[] class06PointsEarned = new double[21];
        double[] class06PointsPossible = new double[21];
        double[] class06Grades = new double[NUMBER_OF_ITEMS + 1];
        double[] class06Weights = new double[21];
        double[] class06WeightedGrades = new double[NUMBER_OF_ITEMS + 1];



        /* @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  INITIALIZATION */

        /* SET STAGE */
        //No data is pulled at this point
        //Just controls of btns and txtboxes
        public Main()
        {
            InitializeComponent();

            //To hide txtbox for class names
            for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
            {
                pnlClassBtns.Controls["txtClassName" + i].Visible = false;
            }

            //Hide buttons used for referncing
            btnClassNotSelected.Visible = false;
            btnClassSelected.Visible = false;
            txtDone.Visible = false;
            txtNotDone.Visible = false;

            //SysMsg
            lblSysMsg.Text = "Class Input text hidden";

            //To show btns for class names
            for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
            {
                pnlClassBtns.Controls["btnClass" + i].Visible = true;
            }

            //SysMsg
            lblSysMsg.Text = "Buttons are loaded";
            lblSysMsg.Text = "GUI Loaded";
        }

        /* LOAD DATA */
        //Data is pulled from txt files and placed into arrays
        //If txtfiles do not exsist they are created
        //For calculated arrays the calculation is performed and stored
        private void Main_Load(object sender, EventArgs e)
        {

    // ########################################DATA########################################

            //colorScheme
            if (File.Exists("colorScheme.txt"))
            {
                colorScheme = File.ReadAllText("colorScheme.txt");
            }
            else File.WriteAllText("colorScheme.txt", colorScheme);

            //Set colorScheme
            cboColorScheme.Text = colorScheme;

            //classNames
            if (File.Exists("classNames.txt"))
            {
                classNames = File.ReadAllLines("classNames.txt");

                for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
                {
                    pnlClassBtns.Controls["btnClass" + i].Text = classNames[i];
                }

                for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
                {
                    pnlClassBtns.Controls["txtClassName" + i].Text = classNames[i];
                }
            }
            else File.WriteAllLines("classNames.txt", classNames);

            lblSysMsg.Text = "classNames have been set";



    //########################################START OF CLASS 1########################################

            //class01ItemNames
            if (File.Exists("class01ItemNames.txt"))
            {
                class01ItemNames = File.ReadAllLines("class01ItemNames.txt");
            }
            else File.WriteAllLines("class01ItemNames.txt", class01ItemNames);

            //class01ItemStatus
            if (File.Exists("class01ItemStatus.txt"))
            {
                class01ItemStatus = File.ReadAllLines("class01ItemStatus.txt");
            }
            else File.WriteAllLines("class01ItemStatus.txt", class01ItemStatus);

            //class01PointsEarned
            if (File.Exists("class01PointsEarned.txt"))
            {
                class01PointsEarnedString = File.ReadAllLines("class01PointsEarned.txt");
                for (int i = 0; i < class01PointsEarnedString.Length; i++)
                {
                    class01PointsEarned[i] = double.Parse(class01PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class01PointsEarnedString.Length; i++)
                {
                    class01PointsEarnedString[i] = Convert.ToString(class01PointsEarned[i]);
                }
                File.WriteAllLines("class01PointsEarned.txt", class01PointsEarnedString);
            }

            //class01PointsPossible
            if (File.Exists("class01PointsPossible.txt"))
            {
                class01PointsPossibleString = File.ReadAllLines("class01PointsPossible.txt");
                for (int i = 0; i < class01PointsPossibleString.Length; i++)
                {
                    class01PointsPossible[i] = double.Parse(class01PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class01PointsPossibleString.Length; i++)
                {
                    class01PointsPossibleString[i] = Convert.ToString(class01PointsPossible[i]);
                }
                File.WriteAllLines("class01PointsPossible.txt", class01PointsPossibleString);
            }

            //class01Grades
            class01Grades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class01PointsPossible[i] == 0)
                    class01Grades[i] = 0;
                else
                    class01Grades[i] = class01PointsEarned[i] / class01PointsPossible[i];
            }

            //class01Weights
            if (File.Exists("class01Weights.txt"))
            {
                class01WeightsString = File.ReadAllLines("class01Weights.txt");
                for (int i = 0; i < class01WeightsString.Length; i++)
                {
                    class01Weights[i] = double.Parse(class01WeightsString[i]);
                }

            }
            else
            {
                for (int i = 0; i < class01WeightsString.Length; i++)
                {
                    class01WeightsString[i] = Convert.ToString(class01Weights[i]);
                }
                File.WriteAllLines("class01Weights.txt", class01WeightsString);
            }

            //class01WeightedGrades
            class01WeightedGrades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class01Weights[i] == 0)
                    class01WeightedGrades[i] = 0;
                else
                    class01WeightedGrades[i] = class01Grades[i] * class01Weights[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 1 initialized";

    //END OF CLASS 1



    //########################################START OF CLASS 2########################################

            //class02ItemNames
            if (File.Exists("class02ItemNames.txt"))
            {
                class02ItemNames = File.ReadAllLines("class02ItemNames.txt");
            }
            else File.WriteAllLines("class02ItemNames.txt", class02ItemNames);

            //class02ItemStatus
            if (File.Exists("class02ItemStatus.txt"))
            {
                class02ItemStatus = File.ReadAllLines("class02ItemStatus.txt");
            }
            else File.WriteAllLines("class02ItemStatus.txt", class02ItemStatus);

            //class02PointsEarned
            if (File.Exists("class02PointsEarned.txt"))
            {
                class02PointsEarnedString = File.ReadAllLines("class02PointsEarned.txt");
                for (int i = 0; i < class02PointsEarnedString.Length; i++)
                {
                    class02PointsEarned[i] = double.Parse(class02PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class02PointsEarnedString.Length; i++)
                {
                    class02PointsEarnedString[i] = Convert.ToString(class02PointsEarned[i]);
                }
                File.WriteAllLines("class01PointsEarned.txt", class02PointsEarnedString);
            }

            //class02PointsPossible
            if (File.Exists("class02PointsPossible.txt"))
            {
                class02PointsPossibleString = File.ReadAllLines("class02PointsPossible.txt");
                for (int i = 0; i < class02PointsPossibleString.Length; i++)
                {
                    class02PointsPossible[i] = double.Parse(class02PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class02PointsPossibleString.Length; i++)
                {
                    class02PointsPossibleString[i] = Convert.ToString(class02PointsPossible[i]);
                }
                File.WriteAllLines("class02PointsPossible.txt", class02PointsPossibleString);
            }

            //class02Grades
            class02Grades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class02PointsPossible[i] == 0)
                    class02Grades[i] = 0;
                else
                    class02Grades[i] = class02PointsEarned[i] / class02PointsPossible[i];
            }

            //class02Weights
            if (File.Exists("class02Weights.txt"))
            {
                class02WeightsString = File.ReadAllLines("class02Weights.txt");
                for (int i = 0; i < class02WeightsString.Length; i++)
                {
                    class02Weights[i] = double.Parse(class02WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class02WeightsString.Length; i++)
                {
                    class02WeightsString[i] = Convert.ToString(class02Weights[i]);
                }
                File.WriteAllLines("class02Weights.txt", class02WeightsString);
            }

            //class02WeightedGrades
            class02WeightedGrades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class02Weights[i] == 0)
                    class02WeightedGrades[i] = 0;
                else
                    class02WeightedGrades[i] = class02Grades[i] / class02Weights[i];
            }
            
            //SysMsg
            lblSysMsg.Text = "Class 2 initialized";

    //END OF CLASS 2



    //########################################START OF CLASS 3########################################

            //class03ItemNames
            if (File.Exists("class03ItemNames.txt"))
            {
                class03ItemNames = File.ReadAllLines("class03ItemNames.txt");
            }
            else File.WriteAllLines("class03ItemNames.txt", class03ItemNames);

            //class03ItemStatus
            if (File.Exists("class03ItemStatus.txt"))
            {
                class03ItemStatus = File.ReadAllLines("class03ItemStatus.txt");
            }
            else File.WriteAllLines("class03ItemStatus.txt", class03ItemStatus);

            //class03PointsEarned
            if (File.Exists("class03PointsEarned.txt"))
            {
                class03PointsEarnedString = File.ReadAllLines("class03PointsEarned.txt");
                for (int i = 0; i < class03PointsEarnedString.Length; i++)
                {
                    class03PointsEarned[i] = double.Parse(class03PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class03PointsEarnedString.Length; i++)
                {
                    class03PointsEarnedString[i] = Convert.ToString(class03PointsEarned[i]);
                }
                File.WriteAllLines("class03PointsEarned.txt", class03PointsEarnedString);
            }

            //class03PointsPossible
            if (File.Exists("class03PointsPossible.txt"))
            {
                class03PointsPossibleString = File.ReadAllLines("class03PointsPossible.txt");
                for (int i = 0; i < class03PointsPossibleString.Length; i++)
                {
                    class03PointsPossible[i] = double.Parse(class03PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class03PointsPossibleString.Length; i++)
                {
                    class03PointsPossibleString[i] = Convert.ToString(class03PointsPossible[i]);
                }
                File.WriteAllLines("class03PointsPossible.txt", class03PointsPossibleString);
            }

            //class03Grades
            class03Grades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class03PointsPossible[i] == 0)
                    class03Grades[i] = 0;
                else
                    class03Grades[i] = class03PointsEarned[i] / class03PointsPossible[i];
            }

            //class03Weights
            if (File.Exists("class03Weights.txt"))
            {
                class03WeightsString = File.ReadAllLines("class03Weights.txt");
                for (int i = 0; i < class03WeightsString.Length; i++)
                {
                    class03Weights[i] = double.Parse(class03WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class03WeightsString.Length; i++)
                {
                    class03WeightsString[i] = Convert.ToString(class03Weights[i]);
                }
                File.WriteAllLines("class03Weights.txt", class03WeightsString);
            }

            //class03WeightedGrades
            class03WeightedGrades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class03Weights[i] == 0)
                    class03WeightedGrades[i] = 0;
                else
                    class03WeightedGrades[i] = class03Grades[i] * class03Weights[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 3 initialized";

    //END OF CLASS 3



    //########################################START OF CLASS 4########################################

            //class04ItemNames
            if (File.Exists("class04ItemNames.txt"))
            {
                class04ItemNames = File.ReadAllLines("class04ItemNames.txt");
            }
            else File.WriteAllLines("class04ItemNames.txt", class04ItemNames);

            //class04ItemStatus
            if (File.Exists("class04ItemStatus.txt"))
            {
                class04ItemStatus = File.ReadAllLines("class04ItemStatus.txt");
            }
            else File.WriteAllLines("class04ItemStatus.txt", class04ItemStatus);

            //class04PointsEarned
            if (File.Exists("class04PointsEarned.txt"))
            {
                class04PointsEarnedString = File.ReadAllLines("class04PointsEarned.txt");
                for (int i = 0; i < class04PointsEarnedString.Length; i++)
                {
                    class04PointsEarned[i] = double.Parse(class04PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class04PointsEarnedString.Length; i++)
                {
                    class04PointsEarnedString[i] = Convert.ToString(class04PointsEarned[i]);
                }
                File.WriteAllLines("class04PointsEarned.txt", class04PointsEarnedString);
            }

            //class04PointsPossible
            if (File.Exists("class04PointsPossible.txt"))
            {
                class04PointsPossibleString = File.ReadAllLines("class04PointsPossible.txt");
                for (int i = 0; i < class04PointsPossibleString.Length; i++)
                {
                    class04PointsPossible[i] = double.Parse(class04PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class04PointsPossibleString.Length; i++)
                {
                    class04PointsPossibleString[i] = Convert.ToString(class04PointsPossible[i]);
                }
                File.WriteAllLines("class04PointsPossible.txt", class04PointsPossibleString);
            }

            //class04Grades
            class04Grades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class04PointsPossible[i] == 0)
                    class04Grades[i] = 0;
                else
                    class04Grades[i] = class04PointsEarned[i] / class04PointsPossible[i];
            }

            //class04Weights
            if (File.Exists("class04Weights.txt"))
            {
                class04WeightsString = File.ReadAllLines("class04Weights.txt");
                for (int i = 0; i < class04WeightsString.Length; i++)
                {
                    class04Weights[i] = double.Parse(class04WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class04WeightsString.Length; i++)
                {
                    class04WeightsString[i] = Convert.ToString(class04Weights[i]);
                }
                File.WriteAllLines("class04Weights.txt", class04WeightsString);
            }

            //class04WeightedGrades
            class04WeightedGrades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class04Weights[i] == 0)
                    class04WeightedGrades[i] = 0;
                else
                    class04WeightedGrades[i] = class04PointsEarned[i] / class04PointsPossible[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 4 initialized";

    //END OF CLASS 4



    //########################################START OF CLASS 5########################################

            //class05ItemNames
            if (File.Exists("class05ItemNames.txt"))
            {
                class05ItemNames = File.ReadAllLines("class05ItemNames.txt");
            }
            else File.WriteAllLines("class05ItemNames.txt", class05ItemNames);

            //class05ItemStatus
            if (File.Exists("class05ItemStatus.txt"))
            {
                class05ItemStatus = File.ReadAllLines("class05ItemStatus.txt");
            }
            else File.WriteAllLines("class05ItemStatus.txt", class05ItemStatus);

            //class05PointsEarned
            if (File.Exists("class05PointsEarned.txt"))
            {
                class05PointsEarnedString = File.ReadAllLines("class05PointsEarned.txt");
                for (int i = 0; i < class05PointsEarnedString.Length; i++)
                {
                    class05PointsEarned[i] = double.Parse(class05PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class05PointsEarnedString.Length; i++)
                {
                    class05PointsEarnedString[i] = Convert.ToString(class05PointsEarned[i]);
                }
                File.WriteAllLines("class05PointsEarned.txt", class05PointsEarnedString);
            }

            //class05PointsPossible
            if (File.Exists("class05PointsPossible.txt"))
            {
                class05PointsPossibleString = File.ReadAllLines("class05PointsPossible.txt");
                for (int i = 0; i < class05PointsPossibleString.Length; i++)
                {
                    class05PointsPossible[i] = double.Parse(class05PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class05PointsPossibleString.Length; i++)
                {
                    class05PointsPossibleString[i] = Convert.ToString(class05PointsPossible[i]);
                }
                File.WriteAllLines("class05PointsPossible.txt", class05PointsPossibleString);
            }

            //class05Grades
            class05Grades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class05PointsPossible[i] == 0)
                    class05Grades[i] = 0;
                else
                    class05Grades[i] = class05PointsEarned[i] / class05PointsPossible[i];
            }

            //class05Weights
            if (File.Exists("class05Weights.txt"))
            {
                class05WeightsString = File.ReadAllLines("class05Weights.txt");
                for (int i = 0; i < class05WeightsString.Length; i++)
                {
                    class05Weights[i] = double.Parse(class05WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class05WeightsString.Length; i++)
                {
                    class05WeightsString[i] = Convert.ToString(class05Weights[i]);
                }
                File.WriteAllLines("class05Weights.txt", class05WeightsString);
            }

            //class05WeightedGrades
            class05WeightedGrades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class05Weights[i] == 0)
                    class05WeightedGrades[i] = 0;
                else
                    class05WeightedGrades[i] = class05Grades[i] * class05Weights[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 5 initialized";

    //END OF CLASS 5


    //########################################START OF CLASS 6########################################

            //class06ItemNames
            if (File.Exists("class06ItemNames.txt"))
            {
                class06ItemNames = File.ReadAllLines("class06ItemNames.txt");
            }
            else File.WriteAllLines("class06ItemNames.txt", class06ItemNames);

            //class06ItemStatus
            if (File.Exists("class06ItemStatus.txt"))
            {
                class06ItemStatus = File.ReadAllLines("class06ItemStatus.txt");
            }
            else File.WriteAllLines("class06ItemStatus.txt", class06ItemStatus);

            //class06PointsEarned
            if (File.Exists("class06PointsEarned.txt"))
            {
                class06PointsEarnedString = File.ReadAllLines("class06PointsEarned.txt");
                for (int i = 0; i < class06PointsEarnedString.Length; i++)
                {
                    class06PointsEarned[i] = double.Parse(class06PointsEarnedString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class06PointsEarnedString.Length; i++)
                {
                    class06PointsEarnedString[i] = Convert.ToString(class06PointsEarned[i]);
                }
                File.WriteAllLines("class06PointsEarned.txt", class06PointsEarnedString);
            }

            //class06PointsPossible
            if (File.Exists("class06PointsPossible.txt"))
            {
                class06PointsPossibleString = File.ReadAllLines("class06PointsPossible.txt");
                for (int i = 0; i < class06PointsPossibleString.Length; i++)
                {
                    class06PointsPossible[i] = double.Parse(class06PointsPossibleString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class06PointsPossibleString.Length; i++)
                {
                    class06PointsPossibleString[i] = Convert.ToString(class06PointsPossible[i]);
                }
                File.WriteAllLines("class06PointsPossible.txt", class06PointsPossibleString);
            }

            //class06Grades
            class06Grades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class06PointsPossible[i] == 0)
                    class06Grades[i] = 0;
                else
                    class06Grades[i] = class06PointsEarned[i] / class06PointsPossible[i];
            }

            //class06Weights
            if (File.Exists("class06Weights.txt"))
            {
                class06WeightsString = File.ReadAllLines("class06Weights.txt");
                for (int i = 0; i < class06WeightsString.Length; i++)
                {
                    class06Weights[i] = double.Parse(class06WeightsString[i]);
                }
            }
            else
            {
                for (int i = 0; i < class06WeightsString.Length; i++)
                {
                    class06WeightsString[i] = Convert.ToString(class06Weights[i]);
                }
                File.WriteAllLines("class06Weights.txt", class06WeightsString);
            }

            //class06WeightedGrades
            class06WeightedGrades[0] = 0;
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class06Weights[i] == 0)
                    class06WeightedGrades[i] = 0;
                else
                    class06WeightedGrades[i] = class06Grades[i] * class06Weights[i];
            }

            //SysMsg
            lblSysMsg.Text = "Class 6 initialized";

    //END OF CLASS 6

            //SysMsg
            lblSysMsg.Text = "Welcome";
        }



        /* @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  COLORING */

        /* COLOR SCHEMES */
        private void cboColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorScheme = cboColorScheme.Text;

            if (colorScheme == "(default)")
            {
                //Set colors
                this.BackColor = default(Color);
                this.ForeColor = default(Color);
                btnClassSelected.BackColor = Color.LightGray;
                btnClassNotSelected.BackColor = default(Color);
                txtDone.BackColor = Color.LightGray;
                txtNotDone.BackColor = Color.White;

                //Set sys btn colors
                btnSave.BackColor = btnClassNotSelected.BackColor;
                btnClassRename.BackColor = btnClassNotSelected.BackColor;

                //Set class btn colors
                for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
                {
                    pnlClassBtns.Controls["btnClass" + i].BackColor = btnClassNotSelected.BackColor;
                }

                //Set selection color
                if (selection == 1)
                    btnClass1.BackColor = btnClassSelected.BackColor;
                else if (selection == 2)
                    btnClass2.BackColor = btnClassSelected.BackColor;
                else if (selection == 3)
                    btnClass3.BackColor = btnClassSelected.BackColor;
                else if (selection == 4)
                    btnClass4.BackColor = btnClassSelected.BackColor;
                else if (selection == 5)
                    btnClass5.BackColor = btnClassSelected.BackColor;
                else if (selection == 6)
                    btnClass6.BackColor = btnClassSelected.BackColor;

            }

            else if (colorScheme == "Cool")
            {
                //Set colors
                this.BackColor = Color.LightSkyBlue;
                this.ForeColor = Color.DarkBlue;
                btnClassSelected.BackColor = Color.Cyan;
                btnClassNotSelected.BackColor = Color.LightCyan;
                txtDone.BackColor = Color.LightGray;
                txtNotDone.BackColor = Color.White;

                //Set sys btn colors
                btnSave.BackColor = btnClassNotSelected.BackColor;
                btnClassRename.BackColor = btnClassNotSelected.BackColor;

                //Set class btn colors
                for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
                {
                    pnlClassBtns.Controls["btnClass" + i].BackColor = btnClassNotSelected.BackColor;
                }

                //Set selection color
                if (selection == 1)
                    btnClass1.BackColor = btnClassSelected.BackColor;
                else if (selection == 2)
                    btnClass2.BackColor = btnClassSelected.BackColor;
                else if (selection == 3)
                    btnClass3.BackColor = btnClassSelected.BackColor;
                else if (selection == 4)
                    btnClass4.BackColor = btnClassSelected.BackColor;
                else if (selection == 5)
                    btnClass5.BackColor = btnClassSelected.BackColor;
                else if (selection == 6)
                    btnClass6.BackColor = btnClassSelected.BackColor;
            }

            else if (colorScheme == "Hello Kitty")
            {
                //Set color
                this.BackColor = Color.LightPink;
                this.ForeColor = Color.DarkRed;
                btnClassSelected.BackColor = Color.HotPink;
                btnClassNotSelected.BackColor = Color.Pink;
                txtDone.BackColor = Color.LightGray;
                txtNotDone.BackColor = Color.White;

                //Set sys btns to colors
                btnSave.BackColor = btnClassNotSelected.BackColor;
                btnClassRename.BackColor = btnClassNotSelected.BackColor;

                //Set class btns to colors
                for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
                {
                    pnlClassBtns.Controls["btnClass" + i].BackColor = btnClassNotSelected.BackColor;
                }

                //Set selection color
                if (selection == 1)
                    btnClass1.BackColor = btnClassSelected.BackColor;
                else if (selection == 2)
                    btnClass2.BackColor = btnClassSelected.BackColor;
                else if (selection == 3)
                    btnClass3.BackColor = btnClassSelected.BackColor;
                else if (selection == 4)
                    btnClass4.BackColor = btnClassSelected.BackColor;
                else if (selection == 5)
                    btnClass5.BackColor = btnClassSelected.BackColor;
                else if (selection == 6)
                    btnClass6.BackColor = btnClassSelected.BackColor;
            }

            else if (colorScheme == "Midnight")
            {
                //Set colors
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                btnClassSelected.BackColor = Color.Black;
                btnClassNotSelected.BackColor = Color.Gray;
                txtDone.BackColor = Color.LightGray;
                txtNotDone.BackColor = Color.White;

                //Set sys btns to colors
                btnSave.BackColor = btnClassNotSelected.BackColor;
                btnClassRename.BackColor = btnClassNotSelected.BackColor;

                //Set colors to btns
                for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
                {
                    pnlClassBtns.Controls["btnClass" + i].BackColor = btnClassNotSelected.BackColor;
                }

                //Set selection color
                if (selection == 1)
                    btnClass1.BackColor = btnClassSelected.BackColor;
                else if (selection == 2)
                    btnClass2.BackColor = btnClassSelected.BackColor;
                else if (selection == 3)
                    btnClass3.BackColor = btnClassSelected.BackColor;
                else if (selection == 4)
                    btnClass4.BackColor = btnClassSelected.BackColor;
                else if (selection == 5)
                    btnClass5.BackColor = btnClassSelected.BackColor;
                else if (selection == 6)
                    btnClass6.BackColor = btnClassSelected.BackColor;
            }

            //Saves color scheme selection to text file
            File.WriteAllText("colorScheme.txt", colorScheme);
        }



        /* @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  GUI BUTTONS */

        /* SAVE & CALCULATE */
        //Save first checks for selection
        //Based on selection it will assign values to variables and perform calculations
        //Those variable are then sent to txt files
        //Sets txtboxes to correct color
        private void btnSave_Click(object sender, EventArgs e)
        {

    //START OF CLASS 1

            if (selection == 1)
            {
                //This assigns values to arrays
                if (chkItemStatus1.Checked)
                    class01ItemStatus[1] = "yes";
                else
                    class01ItemStatus[1] = "no";

                if (chkItemStatus2.Checked)
                    class01ItemStatus[2] = "yes";
                else
                    class01ItemStatus[2] = "no";

                if (chkItemStatus3.Checked)
                    class01ItemStatus[3] = "yes";
                else
                    class01ItemStatus[3] = "no";

                if (chkItemStatus4.Checked)
                    class01ItemStatus[4] = "yes";
                else
                    class01ItemStatus[4] = "no";

                if (chkItemStatus5.Checked)
                    class01ItemStatus[5] = "yes";
                else
                    class01ItemStatus[5] = "no";

                if (chkItemStatus6.Checked)
                    class01ItemStatus[6] = "yes";
                else
                    class01ItemStatus[6] = "no";

                if (chkItemStatus7.Checked)
                    class01ItemStatus[7] = "yes";
                else
                    class01ItemStatus[7] = "no";

                if (chkItemStatus8.Checked)
                    class01ItemStatus[8] = "yes";
                else
                    class01ItemStatus[8] = "no";

                if (chkItemStatus9.Checked)
                    class01ItemStatus[9] = "yes";
                else
                    class01ItemStatus[9] = "no";

                if (chkItemStatus10.Checked)
                    class01ItemStatus[10] = "yes";
                else
                    class01ItemStatus[10] = "no";

                //Item Names to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class01ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                }

                //Points Earned to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class01PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                }

                //Points Possible to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class01PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                }

                //Grade calculate to variables
                for (int i = 0; i < class01Grades.Length; i++)
                {
                    if (class01PointsPossible[i] != 0)
                        class01Grades[i] = class01PointsEarned[i] / class01PointsPossible[i];
                    else
                        class01Grades[i] = 0;
                }
                //Grade to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = class01Grades[i].ToString();
                }

                //Weights to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class01Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                }
                
                //Weighted Grade calculate to variables
                for (int i = 0; i < class01WeightedGrades.Length; i++)
                {
                    class01WeightedGrades[i] = class01Weights[i] * class01Grades[i];
                }
                //Weighted Grade to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = class01WeightedGrades[i].ToString();
                }

                //SysMsg
                lblSysMsg.Text = "Class01 txtboxes assigned to variables";

        //This writes all values to txt files

                //class01ItemNames
			    File.WriteAllLines("class01ItemNames.txt", class01ItemNames);

                //class01ItemStatus
                File.WriteAllLines("class01ItemStatus.txt", class01ItemStatus);

                //class01PointsEarned
                for (int n = 0; n < class01PointsEarnedString.Length; n++)
                {
                    class01PointsEarnedString[n] = Convert.ToString(class01PointsEarned[n]);
                }
                File.WriteAllLines("class01PointsEarned.txt", class01PointsEarnedString);

                //class01PointsPossible
                for (int n = 0; n < class01PointsPossibleString.Length; n++)
                {
                    class01PointsPossibleString[n] = Convert.ToString(class01PointsPossible[n]);
                }
                File.WriteAllLines("class01PointsPossible.txt", class01PointsPossibleString);

                //class01Weights
                for (int n = 0; n < class01WeightsString.Length; n++)
                {
                    class01WeightsString[n] = Convert.ToString(class01Weights[n]);
                }
                File.WriteAllLines("class01Weights.txt", class01WeightsString);

                //SysMsg
                lblSysMsg.Text = "Class01 variables saved to .txt";

    //END OF CLASS 1

            }

    //START OF CLASS 2

            else if (selection == 2)
            {
                //This assigns values to arrays
                if (chkItemStatus1.Checked)
                    class02ItemStatus[1] = "yes";
                else
                    class02ItemStatus[1] = "no";

                if (chkItemStatus2.Checked)
                    class02ItemStatus[2] = "yes";
                else
                    class02ItemStatus[2] = "no";

                if (chkItemStatus3.Checked)
                    class02ItemStatus[3] = "yes";
                else
                    class02ItemStatus[3] = "no";

                if (chkItemStatus4.Checked)
                    class02ItemStatus[4] = "yes";
                else
                    class02ItemStatus[4] = "no";

                if (chkItemStatus5.Checked)
                    class02ItemStatus[5] = "yes";
                else
                    class02ItemStatus[5] = "no";

                if (chkItemStatus6.Checked)
                    class02ItemStatus[6] = "yes";
                else
                    class02ItemStatus[6] = "no";

                if (chkItemStatus7.Checked)
                    class02ItemStatus[7] = "yes";
                else
                    class02ItemStatus[7] = "no";

                if (chkItemStatus8.Checked)
                    class02ItemStatus[8] = "yes";
                else
                    class02ItemStatus[8] = "no";

                if (chkItemStatus9.Checked)
                    class02ItemStatus[9] = "yes";
                else
                    class02ItemStatus[9] = "no";

                if (chkItemStatus10.Checked)
                    class02ItemStatus[10] = "yes";
                else
                    class02ItemStatus[10] = "no";

                //Item Names to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class02ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                }

                //Points Earned to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class02PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                }

                //Points Possible to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class02PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                }

                //Grade to variables
                for (int i = 0; i < class02Grades.Length; i++)
                {
                    if (class02PointsPossible[i] != 0)
                        class02Grades[i] = class02PointsEarned[i] / class02PointsPossible[i];
                    else
                        class02Grades[i] = 0;
                }
                //Grade to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = class02Grades[i].ToString();
                }

                //Weights to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class02Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < class02WeightedGrades.Length; i++)
                {
                    class02WeightedGrades[i] = class02Weights[i] * class02Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class02WeightedGrades[i]);
                }
                
                //SysMsg
                lblSysMsg.Text = "Class02 txtboxes assigned to variables";

        //This writes all values to txt files

                //class02ItemNames
                File.WriteAllLines("class02ItemNames.txt", class02ItemNames);

                //class02ItemStatus
                File.WriteAllLines("class02ItemStatus.txt", class02ItemStatus);

                //class02PointsEarned
                for (int n = 0; n < class02PointsEarnedString.Length; n++)
                {
                    class02PointsEarnedString[n] = Convert.ToString(class02PointsEarned[n]);
                }
                File.WriteAllLines("class02PointsEarned.txt", class02PointsEarnedString);

                //class02PointsPossible
                for (int n = 0; n < class02PointsPossibleString.Length; n++)
                {
                    class02PointsPossibleString[n] = Convert.ToString(class02PointsPossible[n]);
                }
                File.WriteAllLines("class02PointsPossible.txt", class02PointsPossibleString);

                //class02Weights
                for (int n = 0; n < class02WeightsString.Length; n++)
                {
                    class02WeightsString[n] = Convert.ToString(class02Weights[n]);
                }
                File.WriteAllLines("class02Weights.txt", class02WeightsString);

                //SysMsg
                lblSysMsg.Text = "Class02 variables saved to .txt";

    //END OF CLASS 2

            }

    //START OF CLASS 3

            else if (selection == 3)
            {
                //This assigns values to arrays
                if (chkItemStatus1.Checked)
                    class03ItemStatus[1] = "yes";
                else
                    class03ItemStatus[1] = "no";

                if (chkItemStatus2.Checked)
                    class03ItemStatus[2] = "yes";
                else
                    class03ItemStatus[2] = "no";

                if (chkItemStatus3.Checked)
                    class03ItemStatus[3] = "yes";
                else
                    class03ItemStatus[3] = "no";

                if (chkItemStatus4.Checked)
                    class03ItemStatus[4] = "yes";
                else
                    class03ItemStatus[4] = "no";

                if (chkItemStatus5.Checked)
                    class03ItemStatus[5] = "yes";
                else
                    class03ItemStatus[5] = "no";

                if (chkItemStatus6.Checked)
                    class03ItemStatus[6] = "yes";
                else
                    class03ItemStatus[6] = "no";

                if (chkItemStatus7.Checked)
                    class03ItemStatus[7] = "yes";
                else
                    class03ItemStatus[7] = "no";

                if (chkItemStatus8.Checked)
                    class03ItemStatus[8] = "yes";
                else
                    class03ItemStatus[8] = "no";

                if (chkItemStatus9.Checked)
                    class03ItemStatus[9] = "yes";
                else
                    class03ItemStatus[9] = "no";

                if (chkItemStatus10.Checked)
                    class03ItemStatus[10] = "yes";
                else
                    class03ItemStatus[10] = "no";

                //Item Names to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class03ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                }

                //Points Earned to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class03PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                }

                //Points Possible to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class03PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                }

                //Grades calculate to variables
                for (int i = 0; i < class03Grades.Length; i++)
                {
                    if (class03PointsPossible[i] != 0)
                        class03Grades[i] = class03PointsEarned[i] / class03PointsPossible[i];
                    else
                        class03Grades[i] = 0;
                }
                //Grades to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class03Grades[i]);
                }

                //Weights to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class03Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < class03WeightedGrades.Length; i++)
                {
                        class03WeightedGrades[i] = class03Weights[i] * class03Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class03WeightedGrades[i]);
                }

                //SysMsg
                lblSysMsg.Text = "Class03 txtboxes assigned to variables";

        //This writes all values to txt files

                //class03ItemNames
                File.WriteAllLines("class03ItemNames.txt", class03ItemNames);

                //class03ItemStatus
                File.WriteAllLines("class03ItemStatus.txt", class03ItemStatus);

                //class03PointsEarned
                for (int n = 0; n < class03PointsEarnedString.Length; n++)
                {
                    class03PointsEarnedString[n] = Convert.ToString(class03PointsEarned[n]);
                }
                File.WriteAllLines("class03PointsEarned.txt", class03PointsEarnedString);

                //class03PointsPossible
                for (int n = 0; n < class03PointsPossibleString.Length; n++)
                {
                    class03PointsPossibleString[n] = Convert.ToString(class03PointsPossible[n]);
                }
                File.WriteAllLines("class03PointsPossible.txt", class03PointsPossibleString);

                //class03Weights
                for (int n = 0; n < class03WeightsString.Length; n++)
                {
                    class03WeightsString[n] = Convert.ToString(class03Weights[n]);
                }
                File.WriteAllLines("class03Weights.txt", class03WeightsString);

                //SysMsg
                lblSysMsg.Text = "Class03 variables saved to .txt";

    //END OF CLASS 3

            }

    //START OF CLASS 4

            else if (selection == 4)
            {
                //This assigns values to arrays
                if (chkItemStatus1.Checked)
                    class04ItemStatus[1] = "yes";
                else
                    class04ItemStatus[1] = "no";

                if (chkItemStatus2.Checked)
                    class04ItemStatus[2] = "yes";
                else
                    class04ItemStatus[2] = "no";

                if (chkItemStatus3.Checked)
                    class04ItemStatus[3] = "yes";
                else
                    class04ItemStatus[3] = "no";

                if (chkItemStatus4.Checked)
                    class04ItemStatus[4] = "yes";
                else
                    class04ItemStatus[4] = "no";

                if (chkItemStatus5.Checked)
                    class04ItemStatus[5] = "yes";
                else
                    class04ItemStatus[5] = "no";

                if (chkItemStatus6.Checked)
                    class04ItemStatus[6] = "yes";
                else
                    class04ItemStatus[6] = "no";

                if (chkItemStatus7.Checked)
                    class04ItemStatus[7] = "yes";
                else
                    class04ItemStatus[7] = "no";

                if (chkItemStatus8.Checked)
                    class04ItemStatus[8] = "yes";
                else
                    class04ItemStatus[8] = "no";

                if (chkItemStatus9.Checked)
                    class04ItemStatus[9] = "yes";
                else
                    class04ItemStatus[9] = "no";

                if (chkItemStatus10.Checked)
                    class04ItemStatus[10] = "yes";
                else
                    class04ItemStatus[10] = "no";

                //Item Names to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class04ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                }

                //Points Earned to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class04PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                }

                //Points Possible to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class04PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                }

                //Grades calculate to variables
                for (int i = 0; i < class04Grades.Length; i++)
                {
                    if (class04PointsPossible[i] != 0)
                        class04Grades[i] = class04PointsEarned[i] / class04PointsPossible[i];
                    else
                        class04Grades[i] = 0;
                }

                //Grades to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class04Grades[i]);
                }

                //Weights to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class04Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < class04WeightedGrades.Length; i++)
                {
                        class04WeightedGrades[i] = class04Weights[i] * class04Grades[i];
                }

                //Assign new values to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class04WeightedGrades[i]);
                }

                //SysMsg
                lblSysMsg.Text = "Class04 txtboxes assigned to variables";

        //This writes all values to txt files

                //class04ItemNames
                File.WriteAllLines("class04ItemNames.txt", class04ItemNames);

                //class04ItemStatus
                File.WriteAllLines("class04ItemStatus.txt", class04ItemStatus);

                //class04PointsEarned
                for (int n = 0; n < class04PointsEarnedString.Length; n++)
                {
                    class04PointsEarnedString[n] = Convert.ToString(class04PointsEarned[n]);
                }
                File.WriteAllLines("class04PointsEarned.txt", class04PointsEarnedString);

                //class04PointsPossible
                for (int n = 0; n < class04PointsPossibleString.Length; n++)
                {
                    class04PointsPossibleString[n] = Convert.ToString(class04PointsPossible[n]);
                }
                File.WriteAllLines("class04PointsPossible.txt", class04PointsPossibleString);

                //class04Weights
                for (int n = 0; n < class04WeightsString.Length; n++)
                {
                    class04WeightsString[n] = Convert.ToString(class04Weights[n]);
                }
                File.WriteAllLines("class04Weights.txt", class04WeightsString);

                //SysMsg
                lblSysMsg.Text = "Class04 variables saved to .txt";

    //END OF CLASS 4

            }

    //START OF CLASS 5

            else if (selection == 5)
            {
                //This assigns values to arrays
                if (chkItemStatus1.Checked)
                    class05ItemStatus[1] = "yes";
                else
                    class05ItemStatus[1] = "no";

                if (chkItemStatus2.Checked)
                    class05ItemStatus[2] = "yes";
                else
                    class05ItemStatus[2] = "no";

                if (chkItemStatus3.Checked)
                    class05ItemStatus[3] = "yes";
                else
                    class05ItemStatus[3] = "no";

                if (chkItemStatus4.Checked)
                    class05ItemStatus[4] = "yes";
                else
                    class05ItemStatus[4] = "no";

                if (chkItemStatus5.Checked)
                    class05ItemStatus[5] = "yes";
                else
                    class05ItemStatus[5] = "no";

                if (chkItemStatus6.Checked)
                    class05ItemStatus[6] = "yes";
                else
                    class05ItemStatus[6] = "no";

                if (chkItemStatus7.Checked)
                    class05ItemStatus[7] = "yes";
                else
                    class05ItemStatus[7] = "no";

                if (chkItemStatus8.Checked)
                    class05ItemStatus[8] = "yes";
                else
                    class05ItemStatus[8] = "no";

                if (chkItemStatus9.Checked)
                    class05ItemStatus[9] = "yes";
                else
                    class05ItemStatus[9] = "no";

                if (chkItemStatus10.Checked)
                    class05ItemStatus[10] = "yes";
                else
                    class05ItemStatus[10] = "no";

                //Item Names to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class05ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                }

                //Points Earned to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class05PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                }

                //Points Possible to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class05PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                }

                //Grades calculated to variables
                for (int i = 0; i < class05Grades.Length; i++)
                {
                    if (class05PointsPossible[i] != 0)
                        class05Grades[i] = class05PointsEarned[i] / class05PointsPossible[i];
                    else
                        class05Grades[i] = 0;
                }
                //Grades to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class05Grades[i]);
                }

                //Weights to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class05Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < class05WeightedGrades.Length; i++)
                {
                        class05WeightedGrades[i] = class05Weights[i] * class05Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class05WeightedGrades[i]);
                }

                //SysMsg
                lblSysMsg.Text = "Class05 txtboxes assigned to variables";


        //This writes all values to txt files

                //class05ItemNames
                File.WriteAllLines("class05ItemNames.txt", class05ItemNames);

                //class05ItemStatus
                File.WriteAllLines("class05ItemStatus.txt", class05ItemStatus);

                //class05PointsEarned
                for (int n = 0; n < class05PointsEarnedString.Length; n++)
                {
                    class05PointsEarnedString[n] = Convert.ToString(class05PointsEarned[n]);
                }
                File.WriteAllLines("class05PointsEarned.txt", class05PointsEarnedString);

                //class05PointsPossible
                for (int n = 0; n < class05PointsPossibleString.Length; n++)
                {
                    class05PointsPossibleString[n] = Convert.ToString(class05PointsPossible[n]);
                }
                File.WriteAllLines("class05PointsPossible.txt", class05PointsPossibleString);

                //class05Weights
                for (int n = 0; n < class05WeightsString.Length; n++)
                {
                    class05WeightsString[n] = Convert.ToString(class05Weights[n]);
                }
                File.WriteAllLines("class05Weights.txt", class05WeightsString);

                //SysMsg
                lblSysMsg.Text = "Class05 variables saved to .txt";

    //END OF CLASS 5

            }

    //START OF CLASS 6

            else if (selection == 6)
            {
                //This assigns values to arrays
                if (chkItemStatus1.Checked)
                    class06ItemStatus[1] = "yes";
                else
                    class06ItemStatus[1] = "no";

                if (chkItemStatus2.Checked)
                    class06ItemStatus[2] = "yes";
                else
                    class06ItemStatus[2] = "no";

                if (chkItemStatus3.Checked)
                    class06ItemStatus[3] = "yes";
                else
                    class06ItemStatus[3] = "no";

                if (chkItemStatus4.Checked)
                    class06ItemStatus[4] = "yes";
                else
                    class06ItemStatus[4] = "no";

                if (chkItemStatus5.Checked)
                    class06ItemStatus[5] = "yes";
                else
                    class06ItemStatus[5] = "no";

                if (chkItemStatus6.Checked)
                    class06ItemStatus[6] = "yes";
                else
                    class06ItemStatus[6] = "no";

                if (chkItemStatus7.Checked)
                    class06ItemStatus[7] = "yes";
                else
                    class06ItemStatus[7] = "no";

                if (chkItemStatus8.Checked)
                    class06ItemStatus[8] = "yes";
                else
                    class06ItemStatus[8] = "no";

                if (chkItemStatus9.Checked)
                    class06ItemStatus[9] = "yes";
                else
                    class06ItemStatus[9] = "no";

                if (chkItemStatus10.Checked)
                    class06ItemStatus[10] = "yes";
                else
                    class06ItemStatus[10] = "no";

                //Item Names to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class06ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                }

                //Points Earned to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class06PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                }

                //Points Possible to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class06PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                }

                //Grades calculate to variables
                for (int i = 0; i < class06Grades.Length; i++)
                {
                    if (class06PointsPossible[i] != 0)
                        class06Grades[i] = class06PointsEarned[i] / class06PointsPossible[i];
                    else
                        class06Grades[i] = 0;
                }
                //Grades to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class06Grades[i]);
                }

                //Weights to variables
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    class06Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                }

                //Weighted Grades calculate to variables
                for (int i = 0; i < class06WeightedGrades.Length; i++)
                {
                    class06WeightedGrades[i] = class06Weights[i] * class06Grades[i];
                }
                //Weighted Grades to txtboxes
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class06WeightedGrades[i]);
                }

                //SysMsg
                lblSysMsg.Text = "Class06 txtboxes assigned to variables";

                //This writes all values to txt files

                //class06ItemNames
                File.WriteAllLines("class06ItemNames.txt", class06ItemNames);

                //class06ItemStatus
                File.WriteAllLines("class06ItemStatus.txt", class06ItemStatus);

                //class06PointsEarned
                for (int n = 0; n < class06PointsEarnedString.Length; n++)
                {
                    class06PointsEarnedString[n] = Convert.ToString(class06PointsEarned[n]);
                }
                File.WriteAllLines("class06PointsEarned.txt", class06PointsEarnedString);

                //class06PointsPossible
                for (int n = 0; n < class06PointsPossibleString.Length; n++)
                {
                    class06PointsPossibleString[n] = Convert.ToString(class06PointsPossible[n]);
                }
                File.WriteAllLines("class06PointsPossible.txt", class06PointsPossibleString);

                //class06Weights
                for (int n = 0; n < class06WeightsString.Length; n++)
                {
                    class06WeightsString[n] = Convert.ToString(class06Weights[n]);
                }
                File.WriteAllLines("class06Weights.txt", class06WeightsString);

                //SysMsg
                lblSysMsg.Text = "Class06 variables saved to .txt";

    //END OF CLASS 6

            }

    //Txtbox coloring

            //Visuals for finished items
            if (selection == 1)
            {
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    if (class01ItemStatus[i] == "yes")
                    {
                        //IF DONE THEN SET COLOR TO TXTBOXES
                        pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                    }
                    else if (class01ItemStatus[i] == "no")
                    {
                        pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                    }
                }
            }

            else if (selection == 2)
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    if (class02ItemStatus[i] == "yes")
                    {
                        //IF DONE THEN SET COLOR TO TXTBOXES
                        pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                    }
                    else if (class02ItemStatus[i] == "no")
                    {
                        pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                    }
                }

            else if (selection == 3)
            {
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    if (class03ItemStatus[i] == "yes")
                    {
                        //IF DONE THEN SET COLOR TO TXTBOXES
                        pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                    }
                    else if (class03ItemStatus[i] == "no")
                    {
                        pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                    }
                }
            }

            else if (selection == 4)
            {
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    if (class04ItemStatus[i] == "yes")
                    {
                        //IF DONE THEN SET COLOR TO TXTBOXES
                        pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                    }
                    else if (class04ItemStatus[i] == "no")
                    {
                        pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                    }
                }
            }

            else if (selection == 5)
            {
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    if (class05ItemStatus[i] == "yes")
                    {
                        //IF DONE THEN SET COLOR TO TXTBOXES
                        pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                    }
                    else if (class05ItemStatus[i] == "no")
                    {
                        pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                    }
                }
            }

            else if (selection == 6)
            {
                for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
                {
                    if (class06ItemStatus[i] == "yes")
                    {
                        //IF DONE THEN SET COLOR TO TXTBOXES
                        pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                    }
                    else if (class06ItemStatus[i] == "no")
                    {
                        pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                        pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                    }
                }
            }

    //end of txtbox coloring

        }

        /* RENAME CLASSES */
        private void btnClassNames_Click(object sender, EventArgs e)
        {
            //To change class names
            if (classRenameStatus == 0)
            {
                //Hide buttons
                for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
                {
                    //Hide buttons
                    pnlClassBtns.Controls["btnClass" + i].Visible = false;
                    //Bring current names into txtboxes
                    pnlClassBtns.Controls["txtClassName" + i].Text = classNames[i];
                    //Show txtboxes
                    pnlClassBtns.Controls["txtClassName" + i].Visible = true;
                }

                //Change text and color
                btnClassRename.Text = "Done";
                btnClassRename.BackColor = btnClassSelected.BackColor;

                //Set status for next click
                classRenameStatus = 1;

                //SysMsg
                lblSysMsg.Text = "Rename your classes";
            }

            //To save new class names
            else if (classRenameStatus == 1)
            {
                for (int i = 1; i <= NUMBER_OF_CLASSES; i++)
                {
                    //Shows class btns
                    pnlClassBtns.Controls["btnClass" + i].Visible = true;
                    //Hide class txtboxes
                    pnlClassBtns.Controls["txtClassName" + i].Visible = false;
                    //Assign values in txtboxes to btns
                    classNames[1] = pnlClassBtns.Controls["txtClassName" + i].Text;
                    //Assign array values to btns
                    pnlClassBtns.Controls["btnClass" + i].Text = classNames[i];
                }

                //Store array values to text file
                File.WriteAllLines("classNames.txt", classNames);

                //Change text and color
                btnClassRename.Text = "Rename";
                btnClassRename.BackColor = btnClassNotSelected.BackColor;

                //Set status for next click
                classRenameStatus = 0;

                //SysMsg
                lblSysMsg.Text = "Class names saved to .txt";
            }
        }



        /* @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  CLASS BUTTONS */
        // Contains GUI color controls and reads data only, no writing or calculations */

        /* CLASS 1 SELECTION */
        //Pulls all data from variables(arrays)
        //Sets btns colors
        //Assign totals to labels
        //Sets txtbox colors
        //Sets selection value
        private void btnClass01_Click(object sender, EventArgs e)
        {
            //Set btn to selected
            btnClass1.BackColor = btnClassSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;
            btnClass6.BackColor = btnClassNotSelected.BackColor;

            //Setting textbox to values from array
            if (class01ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class01ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class01ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class01ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class01ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class01ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class01ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class01ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class01ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            if (class01ItemStatus[10] == "yes")
                chkItemStatus10.Checked = true;
            else
                chkItemStatus10.Checked = false;

            //Item Names to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class01ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class01PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class01PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class01Grades[i]);
            }

            //Weights to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class01Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class01WeightedGrades[i]);
            }

            //Grade Total
            if (class01PointsPossible.Sum() != 0)
            {
                double gradeTotal = class01PointsEarned.Sum() / class01PointsPossible.Sum();
                lblGrade.Text = String.Format("Grade:  {0}", gradeTotal.ToString("P2"));
            }
            else
                lblGrade.Text = "Grade:  0.00%";

            //Weighted Total
            double weightedGradeTotal = class01WeightedGrades.Sum();
            lblWeightedGrade.Text = String.Format("Weighted Grade:  {0}", weightedGradeTotal.ToString("P2"));

            //Visuals for finished items
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if(class01ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                else if (class01ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }

            //Selection
            selection = 1;

            //SysMsg
            lblSysMsg.Text = "Class01 has been selected";
        }

        /* CLASS 2 SELECTION */
        //Pulls all data from variables(arrays)
        //Sets btns colors
        //Assign totals to labels
        //Sets txtbox colors
        //Sets selection value
        private void btnClass02_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;
            btnClass6.BackColor = btnClassNotSelected.BackColor;

            //UPDATE START
            //Setting textbox to values from array
            if (class02ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class02ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class02ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class02ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class02ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class02ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class02ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class02ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class02ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            if (class02ItemStatus[10] == "yes")
                chkItemStatus10.Checked = true;
            else
                chkItemStatus10.Checked = false;

            //Item Names to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class02ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class02PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class02PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class02Grades[i]);
            }

            //Weights to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class02Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class02WeightedGrades[i]);
            }

            //Grade Total
            if (class02PointsPossible.Sum() != 0)
            {
                double gradeTotal = class02PointsEarned.Sum() / class02PointsPossible.Sum();
                lblGrade.Text = String.Format("Grade:  {0}", gradeTotal.ToString("P2"));
            }
            else
                lblGrade.Text = "Grades:  0.00%";

            //Weighted Total
            double weightedGradeTotal = class02WeightedGrades.Sum();
            lblWeightedGrade.Text = String.Format("Weighted Grade:  {0}", weightedGradeTotal.ToString("P2"));

            //Visuals for finished items
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class02ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                else if (class02ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }

            //Selection
            selection = 2;

            //SysMsg
            lblSysMsg.Text = "Class02 has been selected";
        }

        /* CLASS 3 SELCTION */
        //Pulls all data from variables(arrays)
        //Sets btns colors
        //Assign totals to labels
        //Sets txtbox colors
        //Sets selection value
        private void btnClass03_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;
            btnClass6.BackColor = btnClassNotSelected.BackColor;

            //Setting textbox to values from array
            if (class03ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class03ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class03ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class03ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class03ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class03ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class03ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class03ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class03ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            if (class03ItemStatus[10] == "yes")
                chkItemStatus10.Checked = true;
            else
                chkItemStatus10.Checked = false;

            //Item Names to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class03ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class03PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class03PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class03Grades[i]);
            }

            //Weights to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class03Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class03WeightedGrades[i]);
            }

            //Grade Total
            if (class03PointsPossible.Sum() != 0)
            {
                double gradeTotal = class03PointsEarned.Sum() / class03PointsPossible.Sum();
                lblGrade.Text = String.Format("Grade:  {0}", gradeTotal.ToString("P2"));
            }
            else
                lblWeightedGrade.Text = "Grade:  0.00%";

            //Weighted Total
            double weightedGradeTotal = class03WeightedGrades.Sum();
            lblWeightedGrade.Text = String.Format("Weighted Grade:  {0}", weightedGradeTotal.ToString("P2"));

            //Visuals for finished items
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class03ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                else if (class03ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }

            //Selection
            selection = 3;

            lblSysMsg.Text = "Class03 has been selected";
        }

        /* CLASS 4 SELECTION */
        //Pulls all data from variables(arrays)
        //Sets btns colors
        //Assign totals to labels
        //Sets txtbox colors
        //Sets selection value
        private void btnClass04_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;
            btnClass6.BackColor = btnClassNotSelected.BackColor;

            //Setting textbox to values from array
            if (class04ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class04ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class04ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class04ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class04ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class04ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class04ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class04ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class04ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            if (class04ItemStatus[10] == "yes")
                chkItemStatus10.Checked = true;
            else
                chkItemStatus10.Checked = false;

            //Item Names to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class04ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class04PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class04PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class04Grades[i]);
            }

            //Weights to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class04Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class04WeightedGrades[i]);
            }

            //Grade Total
            if (class04PointsPossible.Sum() != 0)
            {
                double gradeTotal = class04PointsEarned.Sum() / class04PointsPossible.Sum();
                lblGrade.Text = String.Format("Grade:  {0}", gradeTotal.ToString("P2"));
            }
            else
                lblWeightedGrade.Text = "Grade:  0.00%";

            //Weighted Total
            double weightedGradeTotal = class04WeightedGrades.Sum();
            lblWeightedGrade.Text = String.Format("Weighted Grade:  {0}", weightedGradeTotal.ToString("P2"));

            //Visuals for finished items
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class04ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                else if (class04ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }

            //Selection
            selection = 4;

            //SysMsg
            lblSysMsg.Text = "Class04 has been selected";
        }

        /* CLASS 5 SELECTION */
        //Pulls all data from variables(arrays)
        //Sets btns colors
        //Assign totals to labels
        //Sets txtbox colors
        //Sets selection value
        private void btnClass05_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassSelected.BackColor;
            btnClass6.BackColor = btnClassNotSelected.BackColor;

            //Setting textbox to values from array
            if (class05ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class05ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class05ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class05ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class05ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class05ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class05ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class05ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class05ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            if (class05ItemStatus[10] == "yes")
                chkItemStatus10.Checked = true;
            else
                chkItemStatus10.Checked = false;

            //Item Names to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class05ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class05PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class05PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class05Grades[i]);
            }

            //Weights to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class05Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class05WeightedGrades[i]);
            }

            //Grade Total
            if (class05PointsPossible.Sum() != 0)
            {
                double gradeTotal = class05PointsEarned.Sum() / class05PointsPossible.Sum();
                lblGrade.Text = String.Format("Grade:  {0}", gradeTotal.ToString("P2"));
            }
            else
                lblWeightedGrade.Text = "Grade:  0.00%";

            //Weighted Total
            double weightedGradeTotal = class05WeightedGrades.Sum();
            lblWeightedGrade.Text = String.Format("Weighted Grade:  {0}", weightedGradeTotal.ToString("P2"));

            //Visuals for finished items
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class05ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                else if (class05ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }

            //Selection
            selection = 5;

            //SysMsg
            lblSysMsg.Text = "Class04 has been selected";
        }

        /* CLASS 6 SELECTION */
        //Pulls all data from variables(arrays)
        //Sets btns colors
        //Assign totals to labels
        //Sets txtbox colors
        //Sets selection value
        private void btnClass06_Click(object sender, EventArgs e)
        {
            //Visuals
            btnClass1.BackColor = btnClassNotSelected.BackColor;
            btnClass2.BackColor = btnClassNotSelected.BackColor;
            btnClass3.BackColor = btnClassNotSelected.BackColor;
            btnClass4.BackColor = btnClassNotSelected.BackColor;
            btnClass5.BackColor = btnClassNotSelected.BackColor;
            btnClass6.BackColor = btnClassSelected.BackColor;

            //Setting textbox to values from array
            if (class06ItemStatus[1] == "yes")
                chkItemStatus1.Checked = true;
            else
                chkItemStatus1.Checked = false;

            if (class06ItemStatus[2] == "yes")
                chkItemStatus2.Checked = true;
            else
                chkItemStatus2.Checked = false;

            if (class06ItemStatus[3] == "yes")
                chkItemStatus3.Checked = true;
            else
                chkItemStatus3.Checked = false;

            if (class06ItemStatus[4] == "yes")
                chkItemStatus4.Checked = true;
            else
                chkItemStatus4.Checked = false;

            if (class06ItemStatus[5] == "yes")
                chkItemStatus5.Checked = true;
            else
                chkItemStatus5.Checked = false;

            if (class06ItemStatus[6] == "yes")
                chkItemStatus6.Checked = true;
            else
                chkItemStatus6.Checked = false;

            if (class06ItemStatus[7] == "yes")
                chkItemStatus7.Checked = true;
            else
                chkItemStatus7.Checked = false;

            if (class06ItemStatus[8] == "yes")
                chkItemStatus8.Checked = true;
            else
                chkItemStatus8.Checked = false;

            if (class06ItemStatus[9] == "yes")
                chkItemStatus9.Checked = true;
            else
                chkItemStatus9.Checked = false;

            if (class06ItemStatus[10] == "yes")
                chkItemStatus10.Checked = true;
            else
                chkItemStatus10.Checked = false;

            //Item Names to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemName" + i].Text = class06ItemNames[i];
            }

            //Points Earned to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class06PointsEarned[i]);
            }

            //Points Possible to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class06PointsPossible[i]);
            }

            //Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemGrade" + i].Text = Convert.ToString(class06Grades[i]);
            }

            //Weights to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class06Weights[i]);
            }

            //Weighted Grades to txtboxes
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = Convert.ToString(class06WeightedGrades[i]);
            }

            //Grade Total
            if (class06PointsPossible.Sum() != 0)
            {
                double gradeTotal = class06PointsEarned.Sum() / class06PointsPossible.Sum();
                lblGrade.Text = String.Format("Grade:  {0}", gradeTotal.ToString("P2"));
            }
            else
                lblWeightedGrade.Text = "Grade:  0.00%";

            //Weighted Total
            double weightedGradeTotal = class06WeightedGrades.Sum();
            lblWeightedGrade.Text = String.Format("Weighted Grade:  {0}", weightedGradeTotal.ToString("P2"));

            //Visuals for finished items
            for (int i = 1; i <= NUMBER_OF_ITEMS; i++)
            {
                if (class06ItemStatus[i] == "yes")
                {
                    //IF DONE THEN SET COLOR TO TXTBOXES
                    pnlItems.Controls["txtItemName" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtDone.BackColor;
                }
                else if (class06ItemStatus[i] == "no")
                {
                    pnlItems.Controls["txtItemName" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemEarned" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemPossible" + i].BackColor = txtNotDone.BackColor;
                    pnlItems.Controls["txtItemWeight" + i].BackColor = txtNotDone.BackColor;
                }
            }

            //Selection
            selection = 6;

            //SysMsg
            lblSysMsg.Text = "Class06 has been selected";
        }
    }
}
