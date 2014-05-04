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


// TO BE COMPLETED:
// Saving sys msgs to txt file with append (events only ones left)
// Help
// Export
//


namespace MyGradeBook
{
    public partial class frmMain : Form
    {
        //Constants
        const int NUMBER_OF_CLASSES = 6;
        const int NUMBER_OF_ITEMS = 10;
        const char DELIM = ',';

        //Variables
        int targetGradeStatus = 0; //Setting to default
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

        public frmMain()
        {
            InitializeComponent();
        }       
        
        /*
         */
        //=======================================================================================================
        /* LOAD */
        //=======================================================================================================
        /*
         */

        private void Main_Load(object sender, EventArgs e)
        {
            //start a new section in log
            lblSysMsg.Text = "----------------------------------------------------------------";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "Main_Load started";
            Sys_Msg_Save_Txt();

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
            txtTargetGrade.Visible = false;
            lblTest.Visible = false;
            lblSysMsg.Visible = false;

            //Hide settings
            btnClearCurrent.Visible = false;
            btnClearAll.Visible = false;           

            //Hide input fields and scenario btns
            pnlItems.Visible = false;
            pnlWhatIfs.Visible = false;
            pnlTotals.Visible = false;
            pnlStats.Visible = false;

            //SysMsg
            lblSysMsg.Text = "Objects hidden";
            Sys_Msg_Save_Txt();

            //To show btns for class names
            for (int i = 0; i < NUMBER_OF_CLASSES; i++)
            {
                pnlClassBtns.Controls["btnClass" + i].Visible = true;
            }

            //SysMsg
            lblSysMsg.Text = "Buttons loaded";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "GUI Loaded";
            Sys_Msg_Save_Txt();

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
            lblSysMsg.Text = "Main_Load successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "Welcome";
        }

        /*
         */
        //=======================================================================================================
        /* DATA */
        //=======================================================================================================
        /*
         */

        /* Save SysMsgs */
        public void Sys_Msg_Save_Txt()
        {
            int sysMsgLines = 0;

            //If log file reaches more than 10,000 lines makes a new one
            if (File.Exists("SysMsgs.txt") && sysMsgLines < 10000)
            {
                //Appends to file
                FileStream outFile = new FileStream("SysMsgs.txt", FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                writer.WriteLine("[" + DateTime.Now.ToString() + "]:  " + lblSysMsg.Text);

                writer.Close();
                outFile.Close();                

                sysMsgLines = File.ReadAllLines("SysMsgs.txt").Length;
            }
            else
            {
                //Writes over file
                FileStream outFile = new FileStream("SysMsgs.txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                writer.WriteLine("[" + DateTime.Now.ToString() + "]:  " + lblSysMsg.Text);

                writer.Close();
                outFile.Close();                
            }            
        }

        /* Save Class To Txt Files */
        public void Save_To_Txt_Class_All()
        {
            Save_To_Txt_Class_0();
            Save_To_Txt_Class_1();
            Save_To_Txt_Class_2();
            Save_To_Txt_Class_3();
            Save_To_Txt_Class_4();
            Save_To_Txt_Class_5();
        }
        public void Save_To_Txt_Class_0()
        {
            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_0 started";
            Sys_Msg_Save_Txt();

            //Saving to Comma Delimited
            //Class0
            FileStream outFileClass0 = new FileStream("class0.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writerClass0 = new StreamWriter(outFileClass0);
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                writerClass0.WriteLine(class0ItemStatus[i] + DELIM +
                                        class0ItemNames[i] + DELIM +
                                        class0PointsEarned[i] + DELIM +
                                        class0PointsPossible[i] + DELIM +
                                        class0Weights[i]);
            }
            writerClass0.Close();
            outFileClass0.Close();

            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_0 successful";
            Sys_Msg_Save_Txt();
        }
        public void Save_To_Txt_Class_1()
        {
            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_1 started";
            Sys_Msg_Save_Txt();

            //Saving to Comma Delimited
            //Class1
            FileStream outFileclass1 = new FileStream("class1.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writerclass1 = new StreamWriter(outFileclass1);
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                writerclass1.WriteLine(class1ItemStatus[i] + DELIM +
                                        class1ItemNames[i] + DELIM +
                                        class1PointsEarned[i] + DELIM +
                                        class1PointsPossible[i] + DELIM +
                                        class1Weights[i]);
            }
            writerclass1.Close();
            outFileclass1.Close();

            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_1 successful";
            Sys_Msg_Save_Txt();
        }
        public void Save_To_Txt_Class_2()
        {
            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_2 started";
            Sys_Msg_Save_Txt();

            //Saving to Comma Delimited
            //Class2
            FileStream outFileclass2 = new FileStream("class2.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writerclass2 = new StreamWriter(outFileclass2);
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                writerclass2.WriteLine(class2ItemStatus[i] + DELIM +
                                        class2ItemNames[i] + DELIM +
                                        class2PointsEarned[i] + DELIM +
                                        class2PointsPossible[i] + DELIM +
                                        class2Weights[i]);
            }
            writerclass2.Close();
            outFileclass2.Close();

            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_2 successful";
            Sys_Msg_Save_Txt();
        }
        public void Save_To_Txt_Class_3()
        {
            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_3 started";
            Sys_Msg_Save_Txt();

            //Saving to Comma Delimited
            //Class3
            FileStream outFileclass3 = new FileStream("class3.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writerclass3 = new StreamWriter(outFileclass3);
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                writerclass3.WriteLine(class3ItemStatus[i] + DELIM +
                                        class3ItemNames[i] + DELIM +
                                        class3PointsEarned[i] + DELIM +
                                        class3PointsPossible[i] + DELIM +
                                        class3Weights[i]);
            }
            writerclass3.Close();
            outFileclass3.Close();

            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_3 successful";
            Sys_Msg_Save_Txt();
        }
        public void Save_To_Txt_Class_4()
        {
            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_4 started";
            Sys_Msg_Save_Txt();

            //Saving to Comma Delimited
            //Class4
            FileStream outFileclass4 = new FileStream("class4.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writerclass4 = new StreamWriter(outFileclass4);
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                writerclass4.WriteLine(class4ItemStatus[i] + DELIM +
                                        class4ItemNames[i] + DELIM +
                                        class4PointsEarned[i] + DELIM +
                                        class4PointsPossible[i] + DELIM +
                                        class4Weights[i]);
            }
            writerclass4.Close();
            outFileclass4.Close();

            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_4 successful";
            Sys_Msg_Save_Txt();
        }
        public void Save_To_Txt_Class_5()
        {
            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_5 started";
            Sys_Msg_Save_Txt();

            //Saving to Comma Delimited
            //Class5
            FileStream outFileclass5 = new FileStream("class5.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writerclass5 = new StreamWriter(outFileclass5);
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                writerclass5.WriteLine(class5ItemStatus[i] + DELIM +
                                        class5ItemNames[i] + DELIM +
                                        class5PointsEarned[i] + DELIM +
                                        class5PointsPossible[i] + DELIM +
                                        class5Weights[i]);
            }
            writerclass5.Close();
            outFileclass5.Close();

            //SysMsg
            lblSysMsg.Text = "Save_To_Txt_Class_5 successful";
            Sys_Msg_Save_Txt();
        }

        /* Load From Txt Files */
        //Checks for txt files
        //If none exsists it creates one
        //If one does exsist it reads it
        public void Load_Color_Scheme()
        {
            //SysMsg
            lblSysMsg.Text = "Load_Color_Scheme started";
            Sys_Msg_Save_Txt();

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
            lblSysMsg.Text = "Load_Color_Scheme successful";
            Sys_Msg_Save_Txt();
        }
        public void Load_Class_Names()
        {
            //SysMsg
            lblSysMsg.Text = "Load_Class_Names started";
            Sys_Msg_Save_Txt();

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
            lblSysMsg.Text = "Load_Class_Names successful";
            Sys_Msg_Save_Txt();
        }
        public void Load_Class_0()
        {
            //SysMsg
            lblSysMsg.Text = "Load_Class_0 started";
            Sys_Msg_Save_Txt();

            //Looks for files: if exsists read, if does not exsist create one
            if (File.Exists("class0.txt"))
            {
                //Streams
                FileStream inFile = new FileStream("class0.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                //Variables to read records
                string recordIn;
                string[] fields;
                int line = 0;
                //Reading
                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(DELIM);

                    class0ItemStatus[line] = fields[0];
                    class0ItemNames[line] = fields[1];
                    class0PointsEarned[line] = Convert.ToDouble(fields[2]);
                    class0PointsPossible[line] = Convert.ToDouble(fields[3]);
                    class0Weights[line] = Convert.ToDouble(fields[4]);

                    line += 1;
                    recordIn = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            else
            {
                //Sets all items to unlocked
                for (int i = 0; i < NUMBER_OF_ITEMS; i++ )
                {
                    class0ItemStatus[i] = "no";
                }
                Save_To_Txt_Class_0();
            }

            //To calculate weighted grades on load
            //Fix bug where first selection doesnt bring up weighted grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class0PointsPossible[i] == 0)
                {
                    //Do Nothing
                }
                else
                {
                    class0Grades[i] = class0PointsEarned[i] / class0PointsPossible[i];
                    class0WeightedGrades[i] = class0Grades[i] * class0Weights[i];
                }
            }

            //SysMsg
            lblSysMsg.Text = "Load_Class_0 successful";
            Sys_Msg_Save_Txt();
        }
        public void Load_Class_1()
        {
            //SysMsg
            lblSysMsg.Text = "Load_Class_1 started";
            Sys_Msg_Save_Txt();


            if (File.Exists("class1.txt"))
            {
                //Streams
                FileStream inFile = new FileStream("class1.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                //Variables to read records
                string recordIn;
                string[] fields;
                int line = 0;
                //Reading
                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(DELIM);

                    class1ItemStatus[line] = fields[0];
                    class1ItemNames[line] = fields[1];
                    class1PointsEarned[line] = Convert.ToDouble(fields[2]);
                    class1PointsPossible[line] = Convert.ToDouble(fields[3]);
                    class1Weights[line] = Convert.ToDouble(fields[4]);

                    line += 1;
                    recordIn = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            else
            {
                //Sets all items to unlocked
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class1ItemStatus[i] = "no";
                }
                Save_To_Txt_Class_1();
            }

            //To calculate weighted grades on load
            //Fix bug where first selection doesnt bring up weighted grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class1PointsPossible[i] == 0)
                {
                    //Do Nothing
                }
                else
                {
                    class1Grades[i] = class1PointsEarned[i] / class1PointsPossible[i];
                    class1WeightedGrades[i] = class1Grades[i] * class1Weights[i];
                }
            }

            //SysMsg
            lblSysMsg.Text = "Load_Class_1 successful";
            Sys_Msg_Save_Txt();

        }
        public void Load_Class_2()
        {
            //SysMsg
            lblSysMsg.Text = "Load_Class_2 started";
            Sys_Msg_Save_Txt();

            if (File.Exists("class2.txt"))
            {
                //Streams
                FileStream inFile = new FileStream("class2.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                //Variables to read records
                string recordIn;
                string[] fields;
                int line = 0;
                //Reading
                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(DELIM);

                    class2ItemStatus[line] = fields[0];
                    class2ItemNames[line] = fields[1];
                    class2PointsEarned[line] = Convert.ToDouble(fields[2]);
                    class2PointsPossible[line] = Convert.ToDouble(fields[3]);
                    class2Weights[line] = Convert.ToDouble(fields[4]);

                    line += 1;
                    recordIn = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            else
            {
                //Sets all items to unlocked
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class2ItemStatus[i] = "no";
                }
                Save_To_Txt_Class_2();
            }

            //To calculate weighted grades on load
            //Fix bug where first selection doesnt bring up weighted grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class2PointsPossible[i] == 0)
                {
                    //Do Nothing
                }
                else
                {
                    class2Grades[i] = class2PointsEarned[i] / class2PointsPossible[i];
                    class2WeightedGrades[i] = class2Grades[i] * class2Weights[i];
                }
            }

            //SysMsg
            lblSysMsg.Text = "Load_Class_2 successful";
            Sys_Msg_Save_Txt();
        }
        public void Load_Class_3()
        {
            //SysMsg
            lblSysMsg.Text = "Load_Class_3 started";
            Sys_Msg_Save_Txt();

            if (File.Exists("class3.txt"))
            {
                //Streams
                FileStream inFile = new FileStream("class3.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                //Variables to read records
                string recordIn;
                string[] fields;
                int line = 0;
                //Reading
                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(DELIM);

                    class3ItemStatus[line] = fields[0];
                    class3ItemNames[line] = fields[1];
                    class3PointsEarned[line] = Convert.ToDouble(fields[2]);
                    class3PointsPossible[line] = Convert.ToDouble(fields[3]);
                    class3Weights[line] = Convert.ToDouble(fields[4]);

                    line += 1;
                    recordIn = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            else
            {
                //Sets all items to unlocked
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class3ItemStatus[i] = "no";
                }
                Save_To_Txt_Class_3();
            }

            //To calculate weighted grades on load
            //Fix bug where first selection doesnt bring up weighted grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class3PointsPossible[i] == 0)
                {
                    //Do Nothing
                }
                else
                {
                    class3Grades[i] = class3PointsEarned[i] / class3PointsPossible[i];
                    class3WeightedGrades[i] = class3Grades[i] * class3Weights[i];
                }
            }

            //SysMsg
            lblSysMsg.Text = "Load_Class_3 successful";
            Sys_Msg_Save_Txt();
        }
        public void Load_Class_4()
        {
            //SysMsg
            lblSysMsg.Text = "Load_Class_4 started";
            Sys_Msg_Save_Txt();

            if (File.Exists("class4.txt"))
            {
                //Streams
                FileStream inFile = new FileStream("class4.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                //Variables to read records
                string recordIn;
                string[] fields;
                int line = 0;
                //Reading
                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(DELIM);

                    class4ItemStatus[line] = fields[0];
                    class4ItemNames[line] = fields[1];
                    class4PointsEarned[line] = Convert.ToDouble(fields[2]);
                    class4PointsPossible[line] = Convert.ToDouble(fields[3]);
                    class4Weights[line] = Convert.ToDouble(fields[4]);

                    line += 1;
                    recordIn = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            else
            {
                //Sets all items to unlocked
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class4ItemStatus[i] = "no";
                }
                Save_To_Txt_Class_4();
            }

            //To calculate weighted grades on load
            //Fix bug where first selection doesnt bring up weighted grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class4PointsPossible[i] == 0)
                {
                    //Do Nothing
                }
                else
                {
                    class4Grades[i] = class4PointsEarned[i] / class4PointsPossible[i];
                    class4WeightedGrades[i] = class4Grades[i] * class4Weights[i];
                }
            }

            //SysMsg
            lblSysMsg.Text = "Load_Class_4 successful";
            Sys_Msg_Save_Txt();
        }
        public void Load_Class_5()
        {
            //SysMsg
            lblSysMsg.Text = "Load_Class_5 started";
            Sys_Msg_Save_Txt();

            if (File.Exists("class5.txt"))
            {
                //Streams
                FileStream inFile = new FileStream("class5.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                //Variables to read records
                string recordIn;
                string[] fields;
                int line = 0;
                //Reading
                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(DELIM);

                    class5ItemStatus[line] = fields[0];
                    class5ItemNames[line] = fields[1];
                    class5PointsEarned[line] = Convert.ToDouble(fields[2]);
                    class5PointsPossible[line] = Convert.ToDouble(fields[3]);
                    class5Weights[line] = Convert.ToDouble(fields[4]);

                    line += 1;
                    recordIn = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            else
            {
                //Sets all items to unlocked
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class5ItemStatus[i] = "no";
                }
                Save_To_Txt_Class_5();
            }

            //To calculate weighted grades on load
            //Fix bug where first selection doesnt bring up weighted grades
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (class5PointsPossible[i] == 0)
                {
                    //Do Nothing
                }
                else
                {
                    class5Grades[i] = class5PointsEarned[i] / class5PointsPossible[i];
                    class5WeightedGrades[i] = class5Grades[i] * class5Weights[i];
                }
            }

            //SysMsg
            lblSysMsg.Text = "Load_Class_5 successful";
            Sys_Msg_Save_Txt();
        }

        /* Set txtbox to Arrays values */
        public void Set_Txt_Class_CurrSel()
        {
            //SysMsg
            lblSysMsg.Text = "Set_Txt_ClassCurr started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "Set_Txt_ClassCurr successful";
            Sys_Msg_Save_Txt();
        }
        public void Set_Txt_Class_0()
        {
            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_0 started";
            Sys_Msg_Save_Txt();

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
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class0PointsEarned[i]);
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class0PointsPossible[i]);
                pnlItems.Controls["txtItemGrade" + i].Text = class0Grades[i].ToString("P1");
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class0Weights[i]);
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class0WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_0 successful";
            Sys_Msg_Save_Txt();
        }
        public void Set_Txt_Class_1()
        {
            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_1 started";
            Sys_Msg_Save_Txt();

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
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class1PointsEarned[i]);
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class1PointsPossible[i]);
                pnlItems.Controls["txtItemGrade" + i].Text = class1Grades[i].ToString("P1");
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class1Weights[i]);
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class1WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_1 successful";
            Sys_Msg_Save_Txt();
        }
        public void Set_Txt_Class_2()
        {
            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_2 started";
            Sys_Msg_Save_Txt();

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
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class2PointsEarned[i]);
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class2PointsPossible[i]);
                pnlItems.Controls["txtItemGrade" + i].Text = class2Grades[i].ToString("P1");
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class2Weights[i]);
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class2WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_2 successful";
            Sys_Msg_Save_Txt();
        }
        public void Set_Txt_Class_3()
        {
            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_3 started";
            Sys_Msg_Save_Txt();

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
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class3PointsEarned[i]);
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class3PointsPossible[i]);
                pnlItems.Controls["txtItemGrade" + i].Text = class3Grades[i].ToString("P1");
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class3Weights[i]);
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class3WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_3 successful";
            Sys_Msg_Save_Txt();
        }
        public void Set_Txt_Class_4()
        {
            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_4 started";
            Sys_Msg_Save_Txt();

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
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class4PointsEarned[i]);
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class4PointsPossible[i]);
                pnlItems.Controls["txtItemGrade" + i].Text = class4Grades[i].ToString("P1");
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class4Weights[i]);
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class4WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_4 successful";
            Sys_Msg_Save_Txt();
        }
        public void Set_Txt_Class_5()
        {
            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_5 started";
            Sys_Msg_Save_Txt();

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
                pnlItems.Controls["txtItemEarned" + i].Text = Convert.ToString(class5PointsEarned[i]);
                pnlItems.Controls["txtItemPossible" + i].Text = Convert.ToString(class5PointsPossible[i]);
                pnlItems.Controls["txtItemGrade" + i].Text = class5Grades[i].ToString("P1");
                pnlItems.Controls["txtItemWeight" + i].Text = Convert.ToString(class5Weights[i]);
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class5WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Set_Txt_Class_5 successful";
            Sys_Msg_Save_Txt();
        }

        /* Save Arrays to txtbox values */
        public void Save_Class_CurrSel()
        {
            //SysMsg
            lblSysMsg.Text = "Save_Class_CurrSel started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "Save_Class_CurrSel successful";
            Sys_Msg_Save_Txt();
        }
        public void Save_Class_0()
        {
            //SysMsg
            lblSysMsg.Text = "Save_Class_0 started";
            Sys_Msg_Save_Txt();

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

            //For statement to assign values to arrays
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                //Item Names
                class0ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                //Points earned
                class0PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                //Points Possible
                class0PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                //Grades
                if (class0PointsPossible[i] != 0)
                    class0Grades[i] = class0PointsEarned[i] / class0PointsPossible[i];
                else
                    class0Grades[i] = 0;
                //Grades to txtbox
                pnlItems.Controls["txtItemGrade" + i].Text = class0Grades[i].ToString("P1");
                //Weights
                class0Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                //Weighted Grade
                class0WeightedGrades[i] = class0Weights[i] * class0Grades[i];
                //Weighted Grade to txtbox
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class0WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Save_Class_0 successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "Class0 txtboxes assigned to variables";
        }
        public void Save_Class_1()
        {
            //SysMsg
            lblSysMsg.Text = "Save_Class_1 started";
            Sys_Msg_Save_Txt();

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

            //For statement to assign values to arrays
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                //Item Names
                class1ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                //Points Earned
                class1PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                //Points Possible
                class1PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                //Grades
                if (class1PointsPossible[i] != 0)
                    class1Grades[i] = class1PointsEarned[i] / class1PointsPossible[i];
                else
                    class1Grades[i] = 0;
                //Grades to txtbox
                pnlItems.Controls["txtItemGrade" + i].Text = class1Grades[i].ToString("P1");
                //Weights
                class1Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                //Weighted Grade
                class1WeightedGrades[i] = class1Weights[i] * class1Grades[i];
                //Weighted Grade to txtbox
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class1WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Save_Class_1 successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "Class1 txtboxes assigned to variables";
        }
        public void Save_Class_2()
        {
            //SysMsg
            lblSysMsg.Text = "Save_Class_2 started";
            Sys_Msg_Save_Txt();

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

            //For statement to assign values to arrays
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                //Item Names
                class2ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                //Points Earned
                class2PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                //Points Possible
                class2PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                //Grades
                if (class2PointsPossible[i] != 0)
                    class2Grades[i] = class2PointsEarned[i] / class2PointsPossible[i];
                else
                    class2Grades[i] = 0;
                //Grade to txtbox
                pnlItems.Controls["txtItemGrade" + i].Text = class2Grades[i].ToString("P1");
                //Weight
                class2Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                //Weighted Grade
                class2WeightedGrades[i] = class2Weights[i] * class2Grades[i];
                //Weighted Grade to txtbox
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class2WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Save_Class_2 successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "Class2 txtboxes assigned to variables";
        }
        public void Save_Class_3()
        {
            //SysMsg
            lblSysMsg.Text = "Save_Class_3 started";
            Sys_Msg_Save_Txt();

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


            //For statement to assign values to arrays
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                //Item Name
                class3ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                //Points Earned
                class3PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                //Point Possible
                class3PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                //Grades
                if (class3PointsPossible[i] != 0)
                    class3Grades[i] = class3PointsEarned[i] / class3PointsPossible[i];
                else
                    class3Grades[i] = 0;
                //Grades to txtbox
                pnlItems.Controls["txtItemGrade" + i].Text = class3Grades[i].ToString("P1");
                //Weights
                class3Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                //Weighted Grade
                class3WeightedGrades[i] = class3Weights[i] * class3Grades[i];
                //Weighted Grade to txt
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class3WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Save_Class_3 successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "Class3 txtboxes assigned to variables";
        }
        public void Save_Class_4()
        {
            //SysMsg
            lblSysMsg.Text = "Save_Class_4";
            Sys_Msg_Save_Txt();

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

            //For statement to assign values to arrays
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                //Item Names
                class4ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                //Points Earned
                class4PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                //Points Possible
                class4PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                //Grades
                if (class4PointsPossible[i] != 0)
                    class4Grades[i] = class4PointsEarned[i] / class4PointsPossible[i];
                else
                    class4Grades[i] = 0;
                //Grades to txtbox
                pnlItems.Controls["txtItemGrade" + i].Text = class4Grades[i].ToString("P1");
                //Weights
                class4Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                //Weighted Grades
                class4WeightedGrades[i] = class4Weights[i] * class4Grades[i];
                //Weighted Grades to txt
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class4WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Save_Class_4";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "Class4 txtboxes assigned to variables";
        }
        public void Save_Class_5()
        {
            //SysMsg
            lblSysMsg.Text = "Save_Class_5 started";
            Sys_Msg_Save_Txt();

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


            //For statement to assign values to arrays
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                //Item Names
                class5ItemNames[i] = Convert.ToString(pnlItems.Controls["txtItemName" + i].Text);
                //Points Eanred
                class5PointsEarned[i] = Convert.ToDouble(pnlItems.Controls["txtItemEarned" + i].Text);
                //Points Possible
                class5PointsPossible[i] = Convert.ToDouble(pnlItems.Controls["txtItemPossible" + i].Text);
                //Grades
                if (class5PointsPossible[i] != 0)
                    class5Grades[i] = class5PointsEarned[i] / class5PointsPossible[i];
                else
                    class5Grades[i] = 0;
                //Grades to txtbox
                pnlItems.Controls["txtItemGrade" + i].Text = class5Grades[i].ToString("P1");
                //Weights
                class5Weights[i] = Convert.ToDouble(pnlItems.Controls["txtItemWeight" + i].Text);
                //Weighted Grades
                class5WeightedGrades[i] = class5Weights[i] * class5Grades[i];
                //Weighted Grades to txtbox
                pnlItems.Controls["txtItemWeightedGrade" + i].Text = class5WeightedGrades[i].ToString("P1");
            }

            //SysMsg
            lblSysMsg.Text = "Save_Class_5 successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "Class5 txtboxes assigned to variables";
        }

        /* Totals */
        public void Totals()
        {
            //SysMsg
            lblSysMsg.Text = "Totals started";
            Sys_Msg_Save_Txt();

            Grade_Total();
            Weighted_Grade_Total();
            Statistics();

            //SysMsg
            lblSysMsg.Text = "Totals successful";
            Sys_Msg_Save_Txt();
        }
        public void Grade_Total()
        {
            //SysMsg
            lblSysMsg.Text = "Grade_Total started";
            Sys_Msg_Save_Txt();

            double totalWeights = 0;
            double gradeTotal = 0;

            //Set values to variables
            //Class 0            
            if (selection == 0)
            {
                totalWeights = class0Weights.Sum();
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
                totalWeights = class1Weights.Sum();
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
                totalWeights = class2Weights.Sum();
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
                totalWeights = class3Weights.Sum();
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
                totalWeights = class4Weights.Sum();
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
                totalWeights = class5Weights.Sum();
                if (class5PointsPossible.Sum() != 0)
                {
                    gradeTotal = class5PointsEarned.Sum() / class5PointsPossible.Sum();
                }
                else
                {
                    gradeTotal = 0;
                }
            }

            //Coloring
            lblGrade.ForeColor = Color.White;
            if (gradeTotal >= .9)
            {
                lblGrade.BackColor = Color.LimeGreen;
            }
            if (gradeTotal < .89999)
            {
                lblGrade.BackColor = Color.Green;
            }
            if (gradeTotal < .79999)
            {
                lblGrade.BackColor = Color.Orange;
            }
            if (gradeTotal < .69999)
            {
                lblGrade.BackColor = Color.IndianRed;
            }

            //Label to show wether or not to use weighted grade
            if (totalWeights != 1)
            {
                lblGrade.Text = String.Format("Grade:  {0}", gradeTotal.ToString("P2"));
            }

            if (totalWeights == 1)
            {
                lblGrade.Text = String.Format("Use Weighted Grade");
                lblGrade.BackColor = Color.Gray;
            }

            if (gradeTotal <= 0)
            {
                lblGrade.Text = String.Format("Input a Grade");
                lblGrade.BackColor = Color.Gray;
            }

            //Progress Bar
            prgGrade.Value = 0;
            for (int i = 0; i < gradeTotal * 100; i++)
            {
                prgGrade.PerformStep();
            }

            //SysMsg
            lblSysMsg.Text = "Grade_Total successful";
            Sys_Msg_Save_Txt();
        }
        public void Weighted_Grade_Total()
        {
            //SysMsg
            lblSysMsg.Text = "Weighted_Grade_Total started";
            Sys_Msg_Save_Txt();

            double weightedGradeTotal = 0;
            double totalWeights = 0;

            //Setting values to double variables
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

            //Color
            lblWeightedGrade.ForeColor = Color.White;
            if (weightedGradeTotal >= .9)
            {
                lblWeightedGrade.BackColor = Color.LimeGreen;
            }
            if (weightedGradeTotal < .89999)
            {
                lblWeightedGrade.BackColor = Color.Green;
            }
            if (weightedGradeTotal < .79999)
            {
                lblWeightedGrade.BackColor = Color.Orange;
            }
            if (weightedGradeTotal < .69999)
            {
                lblWeightedGrade.BackColor = Color.IndianRed;
            }

            //Label to show whether or not you will be using the weighted grade
            if (totalWeights != 1)
            {
                lblWeightedGrade.Text = String.Format("Total Weight does not equal 100%");
                lblWeightedGrade.BackColor = Color.Gray;
            }
            else
            {
                lblWeightedGrade.Text = String.Format("Weighted Grade:  {0}", weightedGradeTotal.ToString("P2"));
            }

            //Progress Bar
            prgWeightedGrade.Value = 0;
            for (int i = 0; i < weightedGradeTotal * 100; i++)
                prgWeightedGrade.PerformStep();

            //SysMsg
            lblSysMsg.Text = "Weighted_Grade_Total successful";
            Sys_Msg_Save_Txt();
        }

        /* Statistics */
        public void Statistics()
        {
            //SysMsg
            lblSysMsg.Text = "Statistics started";
            Sys_Msg_Save_Txt();

            int completed = 0;
            int remaining = 0;
            int total = 0;

            if (selection == 0)
            {
                //If class names is blank show the number if not show name
                if (classNames[0] == "")
                {
                    lblStatClassVal.Text = "[0]";
                }
                else
                {
                    lblStatClassVal.Text = classNames[0];
                }

                //For statement
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class0ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                    if (class0ItemNames[i] != "" || class0PointsEarned[i] > 0 || class0PointsPossible[i] > 0)
                    {
                        total += 1;
                    }
                }
                remaining = total - completed;
                lblStatCompletedVal.Text = completed.ToString();
                lblStatRemainingVal.Text = remaining.ToString();
                lblStatTotalVal.Text = total.ToString();
                lblStatEarnedVal.Text = Convert.ToString(class0PointsEarned.Sum());
                lblStatPossibleVal.Text = Convert.ToString(class0PointsPossible.Sum());
                lblStatGradeVal.Text = (class0PointsEarned.Sum() / class0PointsPossible.Sum()).ToString("P1");
                lblStatWeightVal.Text = class0Weights.Sum().ToString("P1");
                lblStatWeightedGradeVal.Text = class0WeightedGrades.Sum().ToString("P1");
            }
            if (selection == 1)
            {
                //If for item display
                if (classNames[1] == "")
                {
                    lblStatClassVal.Text = "[1]";
                }
                else
                {
                    lblStatClassVal.Text = classNames[1];
                }
                //For statement
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class1ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                    if (class1ItemNames[i] != "" || class1PointsEarned[i] > 0 || class1PointsPossible[i] > 0)
                    {
                        total += 1;
                    }
                }
                remaining = total - completed;
                lblStatCompletedVal.Text = completed.ToString();
                lblStatRemainingVal.Text = remaining.ToString();
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

                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class2ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                    if (class2ItemNames[i] != "" || class2PointsEarned[i] > 0 || class2PointsPossible[i] > 0)
                    {
                        total += 1;
                    }
                }
                remaining = total - completed;
                lblStatCompletedVal.Text = completed.ToString();
                lblStatRemainingVal.Text = remaining.ToString();
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

                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class3ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                    if (class3ItemNames[i] != "" || class3PointsEarned[i] > 0 || class3PointsPossible[i] > 0)
                    {
                        total += 1;
                    }
                }
                remaining = total - completed;
                lblStatCompletedVal.Text = completed.ToString();
                lblStatRemainingVal.Text = remaining.ToString();
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

                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class4ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                    if (class4ItemNames[i] != "" || class4PointsEarned[i] > 0 || class4PointsPossible[i] > 0)
                    {
                        total += 1;
                    }
                }
                remaining = total - completed;
                lblStatCompletedVal.Text = completed.ToString();
                lblStatRemainingVal.Text = remaining.ToString();
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

                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    if (class5ItemStatus[i] == "yes")
                    {
                        completed += 1;
                    }
                    if (class5ItemNames[i] != "" || class5PointsEarned[i] > 0 || class5PointsPossible[i] > 0)
                    {
                        total += 1;
                    }
                }
                remaining = total - completed;
                lblStatCompletedVal.Text = completed.ToString();
                lblStatRemainingVal.Text = remaining.ToString();
                lblStatTotalVal.Text = total.ToString();
                lblStatEarnedVal.Text = Convert.ToString(class5PointsEarned.Sum());
                lblStatPossibleVal.Text = Convert.ToString(class5PointsPossible.Sum());
                lblStatGradeVal.Text = (class5PointsEarned.Sum() / class5PointsPossible.Sum()).ToString("P1");
                lblStatWeightVal.Text = class5Weights.Sum().ToString("P1");
                lblStatWeightedGradeVal.Text = class5WeightedGrades.Sum().ToString("P1");
            }

            lblSysMsg.Text = "Statistics successful";
            Sys_Msg_Save_Txt();
        }

        /*
         */        
        //=======================================================================================================
        /* COLORS */
        //=======================================================================================================
        /*
         */ 

        /* Scheme Change */
        private void cboColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "cboColorScheme_SelectedIndexChanged started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "cboColorScheme_SelectedIndexChanged successful";
            Sys_Msg_Save_Txt();
        }

        /* Actions */
        public void Color_Scheme_Set()
        {
            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Set started";
            Sys_Msg_Save_Txt();

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
            btnScenarioTarget.BackColor = btnClassNotSelected.BackColor;

            //Sets clear and clear all
            btnClearCurrent.BackColor = btnClassNotSelected.BackColor;
            btnClearAll.BackColor = btnClassNotSelected.BackColor;

            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Set successful";
            Sys_Msg_Save_Txt();
        }
        public void Color_Scheme_Save()
        {
            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Save started";
            Sys_Msg_Save_Txt();

            File.WriteAllText("colorScheme.txt", colorScheme);

            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Save successful";
            Sys_Msg_Save_Txt();
        }

        /* Color Schemes */
        public void Color_Scheme_Default()
        {
            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Default started";
            Sys_Msg_Save_Txt();

            //Set colors
            this.BackColor = default(Color);
            this.ForeColor = default(Color);
            btnClassSelected.BackColor = Color.LightGray;
            btnClassNotSelected.BackColor = default(Color);
            txtDone.BackColor = Color.LightGray;
            txtNotDone.BackColor = Color.White;

            //Set
            Color_Scheme_Set();

            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Default successful";
            Sys_Msg_Save_Txt();
        }
        public void Color_Scheme_Cool()
        {
            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Cool started";
            Sys_Msg_Save_Txt();

            //Set colors
            this.BackColor = Color.LightSkyBlue;
            this.ForeColor = Color.DarkBlue;
            btnClassSelected.BackColor = Color.Cyan;
            btnClassNotSelected.BackColor = Color.LightCyan;
            txtDone.BackColor = Color.LightGray;
            txtNotDone.BackColor = Color.White;

            //Set
            Color_Scheme_Set();

            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Cool successful";
        }
        public void Color_Scheme_HelloKitty()
        {
            //SysMsg
            lblSysMsg.Text = "Color_Scheme_HelloKitty started";
            Sys_Msg_Save_Txt();

            //Set color
            this.BackColor = Color.LightPink;
            this.ForeColor = Color.DarkRed;
            btnClassSelected.BackColor = Color.HotPink;
            btnClassNotSelected.BackColor = Color.Pink;
            txtDone.BackColor = Color.LightGray;
            txtNotDone.BackColor = Color.White;

            //Set
            Color_Scheme_Set();

            //SysMsg
            lblSysMsg.Text = "Color_Scheme_HelloKitty successful";
            Sys_Msg_Save_Txt();
        }
        public void Color_Scheme_Midnight()
        {
            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Midnight started";
            Sys_Msg_Save_Txt();

            //Set colors
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            btnClassSelected.BackColor = Color.Black;
            btnClassNotSelected.BackColor = Color.Gray;
            txtDone.BackColor = Color.Gray;
            txtNotDone.BackColor = Color.White;

            //Set
            Color_Scheme_Set();

            //SysMsg
            lblSysMsg.Text = "Color_Scheme_Midnight successful";
            Sys_Msg_Save_Txt();
        }

        /* Finished Items */
        public void Fin_Items_Class_0()
        {
            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_0 started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_0 successful";
            Sys_Msg_Save_Txt();
        }
        public void Fin_Items_Class_1()
        {
            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_1 started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_1 successful";
            Sys_Msg_Save_Txt();
        }
        public void Fin_Items_Class_2()
        {
            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_2 started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_2 successful";
            Sys_Msg_Save_Txt();
        }
        public void Fin_Items_Class_3()
        {
            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_3 started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_3 successful";
            Sys_Msg_Save_Txt();
        }
        public void Fin_Items_Class_4()
        {
            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_4 started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_4 successful";
            Sys_Msg_Save_Txt();
        }
        public void Fin_Items_Class_5()
        {
            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_5 started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_5 successful";
            Sys_Msg_Save_Txt();
        }
        public void Fin_Items_Class_CurrSel()
        {
            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_CurrSel started";
            Sys_Msg_Save_Txt();

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

            //SysMsg
            lblSysMsg.Text = "Fin_Items_Class_CurrSel successful";
            Sys_Msg_Save_Txt();
        }

        /*
         */
        //=======================================================================================================
        /* LBL CLICK EVENTS */
        //=======================================================================================================
        /*
         */

        /* Help */
        private void lblHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp();
            help.Show();
        }

        /* About */
        private void lblAboutUs_Click(object sender, EventArgs e)
        {
            frmAboutUs aboutUs = new frmAboutUs();
            aboutUs.Show();

        }

        /*
         */
        //=======================================================================================================
        /* BTN CLICK EVENTS */
        //=======================================================================================================
        /*
         */

        /* Settings */
        private void btnSettings_Click(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "btnSettings_Click started";
            Sys_Msg_Save_Txt();

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
                btnClearCurrent.Location = btnScenarioMostLikely.Location;
                btnClearAll.Location = btnScenarioToPass.Location;

                btnScenarioToPass.Visible = false;
                btnScenarioMostLikely.Visible = false;
                btnScenarioA.Visible = false;
                btnScenarioTarget.Visible = false;
                txtTargetGrade.Visible = false;

                btnClearCurrent.Visible = true;
                btnClearAll.Visible = true;

                //Set status for next click
                classRenameStatus = 1;

                //SysMsg
                lblSysMsg.Text = "Settings activated";
                Sys_Msg_Save_Txt();
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
                btnScenarioTarget.Visible = true;

                //So txtTargetGrade doesnt show when changing classes
                if (btnScenarioTarget.Text == "Target")
                {
                    txtTargetGrade.Visible = false;
                }
                else
                {
                    txtTargetGrade.Visible = true;
                }
                
                //Set status for next click
                classRenameStatus = 0;

                Statistics();

                //SysMsg
                lblSysMsg.Text = "Settings deactivated";
                Sys_Msg_Save_Txt();
                lblSysMsg.Text = "Class names saved to .txt";
            }
        }

        /* Classes */
        private void btnClass0_Click(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "btnClass0_Click started";
            Sys_Msg_Save_Txt();

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

            //Show input fields and scenario btns
            if (lblWelcome.Visible == true)
            {
                lblWelcome.Visible = false;
                pnlItems.Visible = true;
                pnlWhatIfs.Visible = true;
                pnlTotals.Visible = true;
                pnlStats.Visible = true;
            }

            //Set txtbox
            Set_Txt_Class_0();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[0];

            //SysMsg
            lblSysMsg.Text = "btnClass0_Click successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "class0 has been selected";
        }
        private void btnClass1_Click(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "btnClass1_Click started";
            Sys_Msg_Save_Txt();

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

            //Show input fields and scenario btns
            if (lblWelcome.Visible == true)
            {
                lblWelcome.Visible = false;
                pnlItems.Visible = true;
                pnlWhatIfs.Visible = true;
                pnlTotals.Visible = true;
                pnlStats.Visible = true;
            }

            //txtboxes
            Set_Txt_Class_1();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[1];

            //SysMsg
            lblSysMsg.Text = "btnClass1_Click successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "class1 has been selected";
        }
        private void btnClass2_Click(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "btnClass2_Click";
            Sys_Msg_Save_Txt();

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

            //Show input fields and scenario btns
            if (lblWelcome.Visible == true)
            {
                lblWelcome.Visible = false;
                pnlItems.Visible = true;
                pnlWhatIfs.Visible = true;
                pnlTotals.Visible = true;
                pnlStats.Visible = true;
            }

            //txtboxes
            Set_Txt_Class_2();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[2];

            //SysMsg
            lblSysMsg.Text = "btnClass2_Click successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "class2 has been selected";
        }
        private void btnClass3_Click(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "btnClass3_Click started";
            Sys_Msg_Save_Txt();

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

            //Show input fields and scenario btns
            if (lblWelcome.Visible == true)
            {
                lblWelcome.Visible = false;
                pnlItems.Visible = true;
                pnlWhatIfs.Visible = true;
                pnlTotals.Visible = true;
                pnlStats.Visible = true;
            }

            //txtboxes
            Set_Txt_Class_3();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[3];

            //SysMsg
            lblSysMsg.Text = "btnClass3_Click successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "class3 has been selected";
        }
        private void btnClass4_Click(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "btnClass4_Click started";
            Sys_Msg_Save_Txt();

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

            //Show input fields and scenario btns
            if (lblWelcome.Visible == true)
            {
                lblWelcome.Visible = false;
                pnlItems.Visible = true;
                pnlWhatIfs.Visible = true;
                pnlTotals.Visible = true;
                pnlStats.Visible = true;
            }

            //txtboxes
            Set_Txt_Class_4();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[4];

            //SysMsg
            lblSysMsg.Text = "btnClass4_Click successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "class4 has been selected";
        }
        private void btnClass5_Click(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "btnClass5_Click started";
            Sys_Msg_Save_Txt();

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

            //Show input fields and scenario btns
            if (lblWelcome.Visible == true)
            {
                lblWelcome.Visible = false;
                pnlItems.Visible = true;
                pnlWhatIfs.Visible = true;
                pnlTotals.Visible = true;
                pnlStats.Visible = true;
            }

            //txtboxes
            Set_Txt_Class_5();

            //Totals
            Totals();

            //Visuals for finished items
            Fin_Items_Class_CurrSel();

            lblClass.Text = classNames[5];

            //SysMsg
            lblSysMsg.Text = "btnClass5_Click successful";
            Sys_Msg_Save_Txt();
            lblSysMsg.Text = "class5 has been selected";
        }

        /* Scenarios */
        private void btnScenarioMostLikely_Click(object sender, EventArgs e)
        {
            //sysmsg
            lblSysMsg.Text = "btnScenarioMostLikely successful";
            Sys_Msg_Save_Txt();

            //Declaring array for temp weights
            double[] class0TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class1TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class2TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class3TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class4TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class5TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class0TempEarnedWeights = new double[NUMBER_OF_ITEMS];
            double[] class1TempEarnedWeights = new double[NUMBER_OF_ITEMS];
            double[] class2TempEarnedWeights = new double[NUMBER_OF_ITEMS];
            double[] class3TempEarnedWeights = new double[NUMBER_OF_ITEMS];
            double[] class4TempEarnedWeights = new double[NUMBER_OF_ITEMS];
            double[] class5TempEarnedWeights = new double[NUMBER_OF_ITEMS];

            //Declaring variables needed for classes with weights
            double weightsEarned = 0;
            double weightedGradeEarned = 0;

            //For class0
            if (selection == 0)
            {
                //If class does not have weights
                if (class0Weights.Sum() != 1)
                {
                    //For statement to calculate weights on points possible
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //For divides by 0
                        if (class0PointsPossible.Sum() == 0)
                        {
                            //do nothing
                        }
                        else
                        {
                            //Get weights
                            class0TempWeights[i] = class0PointsPossible[i] / class0PointsPossible.Sum();
                        }
                    }

                    //To find total weight from locked items
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //So only locked items are selected
                        if (class0ItemStatus[i] == "yes")
                        {
                            //Total for earned weights
                            weightsEarned += class0TempWeights[i];
                        }
                    }

                    //To find locked items new weights
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class0ItemStatus[i] == "yes")
                        {
                            class0TempEarnedWeights[i] = class0TempWeights[i] / weightsEarned;
                            class0Grades[i] = class0PointsEarned[i] / class0PointsPossible[i];
                            weightedGradeEarned += class0TempEarnedWeights[i] * class0Grades[i];
                        }
                    }

                    //Display results
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //So only unlocked items are affected
                        if (class0ItemStatus[i] == "no")
                        {
                            //For divide by 0
                            if (class0PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class0PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }

                //If class has weights
                if (class0Weights.Sum() == 1)
                {
                    //To find total weight from locked items
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //So only locked items are selected
                        if (class0ItemStatus[i] == "yes")
                        {
                            //Total for earned weights
                            weightsEarned += class0Weights[i];
                        }
                    }

                    //To find locked items new weights
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class0ItemStatus[i] == "yes")
                        {
                            class0TempWeights[i] = class0Weights[i] / weightsEarned;
                            class0Grades[i] = class0PointsEarned[i] / class0PointsPossible[i];
                            weightedGradeEarned += class0TempWeights[i] * class0Grades[i];
                        }
                    }

                    //Display results
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //So only unlocked items are affected
                        if (class0ItemStatus[i] == "no")
                        {
                            //For divide by 0
                            if (class0PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class0PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class1
            if (selection == 1)
            {
                if (class1Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1PointsPossible.Sum() == 0)
                        {
                            //do nothing
                        }
                        else
                        {
                            class1TempWeights[i] = class1PointsPossible[i] / class1PointsPossible.Sum();
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "yes")
                        {
                            weightsEarned += class1TempWeights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "yes")
                        {
                            class1TempEarnedWeights[i] = class1TempWeights[i] / weightsEarned;
                            class1Grades[i] = class1PointsEarned[i] / class1PointsPossible[i];
                            weightedGradeEarned += class1TempEarnedWeights[i] * class1Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "no")
                        {
                            if (class1PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class1PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
                if (class1Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "yes")
                        {
                            weightsEarned += class1Weights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "yes")
                        {
                            class1TempWeights[i] = class1Weights[i] / weightsEarned;
                            class1Grades[i] = class1PointsEarned[i] / class1PointsPossible[i];
                            weightedGradeEarned += class1TempWeights[i] * class1Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "no")
                        {
                            if (class1PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class1PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class2
            if (selection == 2)
            {
                if (class2Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2PointsPossible.Sum() == 0)
                        {
                            //do nothing
                        }
                        else
                        {
                            class2TempWeights[i] = class2PointsPossible[i] / class2PointsPossible.Sum();
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "yes")
                        {
                            weightsEarned += class2TempWeights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "yes")
                        {
                            class2TempEarnedWeights[i] = class2TempWeights[i] / weightsEarned;
                            class2Grades[i] = class2PointsEarned[i] / class2PointsPossible[i];
                            weightedGradeEarned += class2TempEarnedWeights[i] * class2Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "no")
                        {
                            if (class2PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class2PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
                if (class2Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "yes")
                        {
                            weightsEarned += class2Weights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "yes")
                        {
                            class2TempWeights[i] = class2Weights[i] / weightsEarned;
                            class2Grades[i] = class2PointsEarned[i] / class2PointsPossible[i];
                            weightedGradeEarned += class2TempWeights[i] * class2Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "no")
                        {
                            if (class2PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class2PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
            }
            if (selection == 3)
            {
                if (class3Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3PointsPossible.Sum() == 0)
                        {
                            //do nothing
                        }
                        else
                        {
                            class3TempWeights[i] = class3PointsPossible[i] / class3PointsPossible.Sum();
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "yes")
                        {
                            weightsEarned += class3TempWeights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "yes")
                        {
                            class3TempEarnedWeights[i] = class3TempWeights[i] / weightsEarned;
                            class3Grades[i] = class3PointsEarned[i] / class3PointsPossible[i];
                            weightedGradeEarned += class3TempEarnedWeights[i] * class3Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "no")
                        {
                            if (class3PointsPossible[i] == 0)
                            {
                                //Do Nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class3PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
                if (class3Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "yes")
                        {
                            weightsEarned += class3Weights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "yes")
                        {
                            class3TempWeights[i] = class3Weights[i] / weightsEarned;
                            class3Grades[i] = class3PointsEarned[i] / class3PointsPossible[i];
                            weightedGradeEarned += class3TempWeights[i] * class3Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "no")
                        {
                            if (class3PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class3PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class4
            if (selection == 4)
            {
                if (class4Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4PointsPossible.Sum() == 0)
                        {
                            //do nothing
                        }
                        else
                        {
                            class4TempWeights[i] = class4PointsPossible[i] / class4PointsPossible.Sum();
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "yes")
                        {
                            weightsEarned += class4TempWeights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "yes")
                        {
                            class4TempEarnedWeights[i] = class4TempWeights[i] / weightsEarned;
                            class4Grades[i] = class4PointsEarned[i] / class4PointsPossible[i];
                            weightedGradeEarned += class4TempEarnedWeights[i] * class4Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "no")
                        {
                            if (class4PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class4PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
                if (class4Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "yes")
                        {
                            weightsEarned += class4Weights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "yes")
                        {
                            class4TempWeights[i] = class4Weights[i] / weightsEarned;
                            class4Grades[i] = class4PointsEarned[i] / class4PointsPossible[i];
                            weightedGradeEarned += class4TempWeights[i] * class4Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "no")
                        {
                            if (class4PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class4PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class5
            if (selection == 5)
            {
                if (class5Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5PointsPossible.Sum() == 0)
                        {
                            //do nothing
                        }
                        else
                        {
                            class5TempWeights[i] = class5PointsPossible[i] / class5PointsPossible.Sum();
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "yes")
                        {
                            weightsEarned += class5TempWeights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "yes")
                        {
                            class5TempEarnedWeights[i] = class5TempWeights[i] / weightsEarned;
                            class5Grades[i] = class5PointsEarned[i] / class5PointsPossible[i];
                            weightedGradeEarned += class5TempEarnedWeights[i] * class5Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "no")
                        {
                            if (class5PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class5PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
                if (class5Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "yes")
                        {
                            weightsEarned += class5Weights[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "yes")
                        {
                            class5TempWeights[i] = class5Weights[i] / weightsEarned;
                            class5Grades[i] = class5PointsEarned[i] / class5PointsPossible[i];
                            weightedGradeEarned += class5TempWeights[i] * class5Grades[i];
                        }
                    }
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "no")
                        {
                            if (class5PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class5PointsPossible[i] * weightedGradeEarned).ToString("F2");
                            }
                        }
                    }
                }
            }

            Save_Class_CurrSel();
            Totals();

            //sysmsg
            lblSysMsg.Text = "btnScenarioMostLikely successful";
            Sys_Msg_Save_Txt();

        }
        private void btnScenarioToPass_Click(object sender, EventArgs e)
        {
            //sysmsg
            lblSysMsg.Text = "btnScenarioToPass_Click started";
            Sys_Msg_Save_Txt();

            //Declaring constant as target grade
            const double targetGrade = .70;

            //Declaring array for temp weights
            double[] class0TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class1TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class2TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class3TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class4TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class5TempWeights = new double[NUMBER_OF_ITEMS];

            //Declaring variables needed for classes without weights
            double pointsEarned = 0;
            double pointsNeeded = 0;
            double pointsRemaining = 0;
            double pointsLocked = 0;

            //Declaring variables needed for classes with weights
            double weightEarned = 0;
            double weightNeeded = 0;
            double weightRemaining = 0;
            double weightedGradeEarned = 0;

            //For class0
            if (selection == 0)
            {
                //If class does not have weights
                if (class0Weights.Sum() != 1)
                {
                    //For statement to sum up total points earned
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //If is needed to only sum up items that are finished
                        if (class0ItemStatus[i] == "yes")
                        {
                            pointsEarned += class0PointsEarned[i];
                            pointsLocked += class0PointsPossible[i];
                        }
                    }

                    pointsNeeded = class0PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class0PointsPossible.Sum() - pointsLocked;

                    //For statement to calculate needed points per item and display results
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //If is needed so only items that are not done receive new values
                        if (class0ItemStatus[i] == "no")
                        {
                            //to find weight so grades are even for all items that are not done
                            class0TempWeights[i] = class0PointsPossible[i] / pointsRemaining;
                            //Calculates points needed and displays result
                            if (class0PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class0TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                //If class has weights
                if (class0Weights.Sum() == 1)
                {
                    //For statement to find total earnedWeight
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class0ItemStatus[i] == "yes")
                        {
                            weightEarned += class0Weights[i];
                            weightedGradeEarned += class0WeightedGrades[i];
                        }
                    }

                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class0Weights.Sum() - weightEarned;

                    //For statement to calculate needed points per item and display results
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //If is needed so only items that are not done receive new values
                        if (class0ItemStatus[i] == "no")
                        {
                            class0TempWeights[i] = class0Weights[i] / weightRemaining * weightNeeded;

                            //For dividing by 0
                            if (class0Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {                                
                                //Calculates points needed and displays result
                                pnlItems.Controls["txtItemEarned" + i].Text = (class0TempWeights[i] / class0Weights[i] * class0PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class1
            if (selection == 1)
            {
                if (class1Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "yes")
                        {
                            pointsEarned += class1PointsEarned[i];
                            pointsLocked += class1PointsPossible[i];
                        }
                    }
                    pointsNeeded = class1PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class1PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "no")
                        {
                            class1TempWeights[i] = class1PointsPossible[i] / pointsRemaining;
                            if (class1PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class1TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class1Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "yes")
                        {
                            weightEarned += class1Weights[i];
                            weightedGradeEarned += class1WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class1Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "no")
                        {
                            class1TempWeights[i] = class1Weights[i] / weightRemaining * weightNeeded;
                            if (class1Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class1TempWeights[i] / class1Weights[i] * class1PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class2
            if (selection == 2)
            {
                if (class2Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "yes")
                        {
                            pointsEarned += class2PointsEarned[i];
                            pointsLocked += class2PointsPossible[i];
                        }
                    }
                    pointsNeeded = class2PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class2PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "no")
                        {
                            class2TempWeights[i] = class2PointsPossible[i] / pointsRemaining;
                            if (class2PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class2TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class2Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "yes")
                        {
                            weightEarned += class2Weights[i];
                            weightedGradeEarned += class2WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class2Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "no")
                        {
                            class2TempWeights[i] = class2Weights[i] / weightRemaining * weightNeeded;
                            if (class2Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class2TempWeights[i] / class2Weights[i] * class2PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }


            //For class3
            if (selection == 3)
            {
                if (class3Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "yes")
                        {
                            pointsEarned += class3PointsEarned[i];
                            pointsLocked += class3PointsPossible[i];
                        }
                    }
                    pointsNeeded = class3PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class3PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "no")
                        {
                            class3TempWeights[i] = class3PointsPossible[i] / pointsRemaining;
                            if (class3PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class3TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class3Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "yes")
                        {
                            weightEarned += class3Weights[i];
                            weightedGradeEarned += class3WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class3Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "no")
                        {
                            class3TempWeights[i] = class3Weights[i] / weightRemaining * weightNeeded;
                            if (class3Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class3TempWeights[i] / class3Weights[i] * class3PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }


            //For class4
            if (selection == 4)
            {
                if (class4Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "yes")
                        {
                            pointsEarned += class4PointsEarned[i];
                            pointsLocked += class4PointsPossible[i];
                        }
                    }
                    pointsNeeded = class4PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class4PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "no")
                        {
                            class4TempWeights[i] = class4PointsPossible[i] / pointsRemaining;
                            if (class4PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class4TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class4Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "yes")
                        {
                            weightEarned += class4Weights[i];
                            weightedGradeEarned += class4WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class4Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "no")
                        {
                            class4TempWeights[i] = class4Weights[i] / weightRemaining * weightNeeded;
                            if (class4Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class4TempWeights[i] / class4Weights[i] * class4PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class5
            if (selection == 5)
            {
                if (class5Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "yes")
                        {
                            pointsEarned += class5PointsEarned[i];
                            pointsLocked += class5PointsPossible[i];
                        }
                    }
                    pointsNeeded = class5PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class5PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "no")
                        {
                            class5TempWeights[i] = class5PointsPossible[i] / pointsRemaining;
                            if (class5PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class5TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class5Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "yes")
                        {
                            weightEarned += class5Weights[i];
                            weightedGradeEarned += class5WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class5Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "no")
                        {
                            class5TempWeights[i] = class5Weights[i] / weightRemaining * weightNeeded;
                            if (class5Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class5TempWeights[i] / class5Weights[i] * class5PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }

            Save_Class_CurrSel();
            Totals();

            //sysmsg
            lblSysMsg.Text = "btnScenarioToPass successful";
            Sys_Msg_Save_Txt();
        }
        private void btnScenarioA_Click(object sender, EventArgs e)
        {
            //sysmsg
            lblSysMsg.Text = "btnScenarioA successful";
            Sys_Msg_Save_Txt();

            //Declaring constant as target grade
            const double targetGrade = .90;

            //Declaring array for temp weights
            double[] class0TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class1TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class2TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class3TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class4TempWeights = new double[NUMBER_OF_ITEMS];
            double[] class5TempWeights = new double[NUMBER_OF_ITEMS];

            //Declaring variables needed for classes without weights
            double pointsEarned = 0;
            double pointsNeeded = 0;
            double pointsRemaining = 0;
            double pointsLocked = 0;

            //Declaring variables needed for classes with weights
            double weightEarned = 0;
            double weightNeeded = 0;
            double weightRemaining = 0;
            double weightedGradeEarned = 0;

            //For class0
            if (selection == 0)
            {
                //If class does not have weights
                if (class0Weights.Sum() != 1)
                {
                    //For statement to sum up total points earned
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //If is needed to only sum up items that are finished
                        if (class0ItemStatus[i] == "yes")
                        {
                            pointsEarned += class0PointsEarned[i];
                            pointsLocked += class0PointsPossible[i];
                        }
                    }

                    pointsNeeded = class0PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class0PointsPossible.Sum() - pointsLocked;

                    //For statement to calculate needed points per item and display results
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //If is needed so only items that are not done receive new values
                        if (class0ItemStatus[i] == "no")
                        {
                            //to find weight so grades are even for all items that are not done
                            class0TempWeights[i] = class0PointsPossible[i] / pointsRemaining;
                            //Calculates points needed and displays result
                            if (class0PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class0TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                //If class has weights
                if (class0Weights.Sum() == 1)
                {
                    //For statement to find total earnedWeight
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class0ItemStatus[i] == "yes")
                        {
                            weightEarned += class0Weights[i];
                            weightedGradeEarned += class0WeightedGrades[i];
                        }
                    }

                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class0Weights.Sum() - weightEarned;

                    //For statement to calculate needed points per item and display results
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        //If is needed so only items that are not done receive new values
                        if (class0ItemStatus[i] == "no")
                        {
                            class0TempWeights[i] = class0Weights[i] / weightRemaining * weightNeeded;

                            //For dividing by 0
                            if (class0Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                //Calculates points needed and displays result
                                pnlItems.Controls["txtItemEarned" + i].Text = (class0TempWeights[i] / class0Weights[i] * class0PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class1
            if (selection == 1)
            {
                if (class1Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "yes")
                        {
                            pointsEarned += class1PointsEarned[i];
                            pointsLocked += class1PointsPossible[i];
                        }
                    }
                    pointsNeeded = class1PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class1PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "no")
                        {
                            class1TempWeights[i] = class1PointsPossible[i] / pointsRemaining;
                            if (class1PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class1TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class1Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "yes")
                        {
                            weightEarned += class1Weights[i];
                            weightedGradeEarned += class1WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class1Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class1ItemStatus[i] == "no")
                        {
                            class1TempWeights[i] = class1Weights[i] / weightRemaining * weightNeeded;
                            if (class1Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class1TempWeights[i] / class1Weights[i] * class1PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class2
            if (selection == 2)
            {
                if (class2Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "yes")
                        {
                            pointsEarned += class2PointsEarned[i];
                            pointsLocked += class2PointsPossible[i];
                        }
                    }
                    pointsNeeded = class2PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class2PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "no")
                        {
                            class2TempWeights[i] = class2PointsPossible[i] / pointsRemaining;
                            if (class2PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class2TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class2Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "yes")
                        {
                            weightEarned += class2Weights[i];
                            weightedGradeEarned += class2WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class2Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class2ItemStatus[i] == "no")
                        {
                            class2TempWeights[i] = class2Weights[i] / weightRemaining * weightNeeded;
                            if (class2Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class2TempWeights[i] / class2Weights[i] * class2PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }


            //For class3
            if (selection == 3)
            {
                if (class3Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "yes")
                        {
                            pointsEarned += class3PointsEarned[i];
                            pointsLocked += class3PointsPossible[i];
                        }
                    }
                    pointsNeeded = class3PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class3PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "no")
                        {
                            class3TempWeights[i] = class3PointsPossible[i] / pointsRemaining;
                            if (class3PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class3TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class3Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "yes")
                        {
                            weightEarned += class3Weights[i];
                            weightedGradeEarned += class3WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class3Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class3ItemStatus[i] == "no")
                        {
                            class3TempWeights[i] = class3Weights[i] / weightRemaining * weightNeeded;
                            if (class3Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class3TempWeights[i] / class3Weights[i] * class3PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }


            //For class4
            if (selection == 4)
            {
                if (class4Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "yes")
                        {
                            pointsEarned += class4PointsEarned[i];
                            pointsLocked += class4PointsPossible[i];
                        }
                    }
                    pointsNeeded = class4PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class4PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "no")
                        {
                            class4TempWeights[i] = class4PointsPossible[i] / pointsRemaining;
                            if (class4PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class4TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class4Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "yes")
                        {
                            weightEarned += class4Weights[i];
                            weightedGradeEarned += class4WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class4Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class4ItemStatus[i] == "no")
                        {
                            class4TempWeights[i] = class4Weights[i] / weightRemaining * weightNeeded;
                            if (class4Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class4TempWeights[i] / class4Weights[i] * class4PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }

            //For class5
            if (selection == 5)
            {
                if (class5Weights.Sum() != 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "yes")
                        {
                            pointsEarned += class5PointsEarned[i];
                            pointsLocked += class5PointsPossible[i];
                        }
                    }
                    pointsNeeded = class5PointsPossible.Sum() * targetGrade - pointsEarned;
                    pointsRemaining = class5PointsPossible.Sum() - pointsLocked;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "no")
                        {
                            class5TempWeights[i] = class5PointsPossible[i] / pointsRemaining;
                            if (class5PointsPossible[i] == 0)
                            {
                                //leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class5TempWeights[i] * pointsNeeded).ToString("F2");
                            }
                        }
                    }
                }

                if (class5Weights.Sum() == 1)
                {
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "yes")
                        {
                            weightEarned += class5Weights[i];
                            weightedGradeEarned += class5WeightedGrades[i];
                        }
                    }
                    weightNeeded = targetGrade - weightedGradeEarned;
                    weightRemaining = class5Weights.Sum() - weightEarned;
                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        if (class5ItemStatus[i] == "no")
                        {
                            class5TempWeights[i] = class5Weights[i] / weightRemaining * weightNeeded;
                            if (class5Weights[i] == 0)
                            {
                                //Leave blank so program does nothing
                            }
                            else
                            {
                                pnlItems.Controls["txtItemEarned" + i].Text = (class5TempWeights[i] / class5Weights[i] * class5PointsPossible[i]).ToString("F2");
                            }
                        }
                    }
                }
            }

            Save_Class_CurrSel();
            Totals();

            //sysmsg
            lblSysMsg.Text = "btnScenarioA successful";
            Sys_Msg_Save_Txt();
        }
        private void btnScenarioTarget_Click(object sender, EventArgs e)
        {
            //sysmsg
            lblSysMsg.Text = "btnScenarioTarget successful";
            Sys_Msg_Save_Txt();

            if (targetGradeStatus == 0)
            {
                txtTargetGrade.Visible = true;
                btnScenarioTarget.Text = "Run";
                txtTargetGrade.Focus();
                txtTargetGrade.SelectAll();
                targetGradeStatus = 1;
            }
            else if (targetGradeStatus == 1) //Input code to run target grade here
            {
                double parsedValue;
                if (!double.TryParse(txtTargetGrade.Text, out parsedValue))
                {
                    MessageBox.Show("Only numbers are allowed, if blank input 0");
                    txtTargetGrade.Text = "0";
                    txtTargetGrade.Focus();
                }
                else
                {
                    //Declaring constant as target grade
                    double targetGrade = Convert.ToDouble(txtTargetGrade.Text);

                    //Declaring array for temp weights
                    double[] class0TempWeights = new double[NUMBER_OF_ITEMS];
                    double[] class1TempWeights = new double[NUMBER_OF_ITEMS];
                    double[] class2TempWeights = new double[NUMBER_OF_ITEMS];
                    double[] class3TempWeights = new double[NUMBER_OF_ITEMS];
                    double[] class4TempWeights = new double[NUMBER_OF_ITEMS];
                    double[] class5TempWeights = new double[NUMBER_OF_ITEMS];

                    //Declaring variables needed for classes without weights
                    double pointsEarned = 0;
                    double pointsNeeded = 0;
                    double pointsRemaining = 0;
                    double pointsLocked = 0;

                    //Declaring variables needed for classes with weights
                    double weightEarned = 0;
                    double weightNeeded = 0;
                    double weightRemaining = 0;
                    double weightedGradeEarned = 0;

                    //For class0
                    if (selection == 0)
                    {
                        //If class does not have weights
                        if (class0Weights.Sum() != 1)
                        {
                            //For statement to sum up total points earned
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                //If is needed to only sum up items that are finished
                                if (class0ItemStatus[i] == "yes")
                                {
                                    pointsEarned += class0PointsEarned[i];
                                    pointsLocked += class0PointsPossible[i];
                                }
                            }

                            pointsNeeded = class0PointsPossible.Sum() * targetGrade - pointsEarned;
                            pointsRemaining = class0PointsPossible.Sum() - pointsLocked;

                            //For statement to calculate needed points per item and display results
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                //If is needed so only items that are not done receive new values
                                if (class0ItemStatus[i] == "no")
                                {
                                    //to find weight so grades are even for all items that are not done
                                    class0TempWeights[i] = class0PointsPossible[i] / pointsRemaining;
                                    //Calculates points needed and displays result
                                    if (class0PointsPossible[i] == 0)
                                    {
                                        //leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class0TempWeights[i] * pointsNeeded).ToString("F2");
                                    }
                                }
                            }
                        }

                        //If class has weights
                        if (class0Weights.Sum() == 1)
                        {
                            //For statement to find total earnedWeight
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class0ItemStatus[i] == "yes")
                                {
                                    weightEarned += class0Weights[i];
                                    weightedGradeEarned += class0WeightedGrades[i];
                                }
                            }

                            weightNeeded = targetGrade - weightedGradeEarned;
                            weightRemaining = class0Weights.Sum() - weightEarned;

                            //For statement to calculate needed points per item and display results
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                //If is needed so only items that are not done receive new values
                                if (class0ItemStatus[i] == "no")
                                {
                                    class0TempWeights[i] = class0Weights[i] / weightRemaining * weightNeeded;

                                    //For dividing by 0
                                    if (class0Weights[i] == 0)
                                    {
                                        //Leave blank so program does nothing
                                    }
                                    else
                                    {
                                        //Calculates points needed and displays result
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class0TempWeights[i] / class0Weights[i] * class0PointsPossible[i]).ToString("F2");
                                    }
                                }
                            }
                        }
                    }

                    //For class1
                    if (selection == 1)
                    {
                        if (class1Weights.Sum() != 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class1ItemStatus[i] == "yes")
                                {
                                    pointsEarned += class1PointsEarned[i];
                                    pointsLocked += class1PointsPossible[i];
                                }
                            }
                            pointsNeeded = class1PointsPossible.Sum() * targetGrade - pointsEarned;
                            pointsRemaining = class1PointsPossible.Sum() - pointsLocked;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class1ItemStatus[i] == "no")
                                {
                                    class1TempWeights[i] = class1PointsPossible[i] / pointsRemaining;
                                    if (class1PointsPossible[i] == 0)
                                    {
                                        //leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class1TempWeights[i] * pointsNeeded).ToString("F2");
                                    }
                                }
                            }
                        }

                        if (class1Weights.Sum() == 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class1ItemStatus[i] == "yes")
                                {
                                    weightEarned += class1Weights[i];
                                    weightedGradeEarned += class1WeightedGrades[i];
                                }
                            }
                            weightNeeded = targetGrade - weightedGradeEarned;
                            weightRemaining = class1Weights.Sum() - weightEarned;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class1ItemStatus[i] == "no")
                                {
                                    class1TempWeights[i] = class1Weights[i] / weightRemaining * weightNeeded;
                                    if (class1Weights[i] == 0)
                                    {
                                        //Leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class1TempWeights[i] / class1Weights[i] * class1PointsPossible[i]).ToString("F2");
                                    }
                                }
                            }
                        }
                    }

                    //For class2
                    if (selection == 2)
                    {
                        if (class2Weights.Sum() != 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class2ItemStatus[i] == "yes")
                                {
                                    pointsEarned += class2PointsEarned[i];
                                    pointsLocked += class2PointsPossible[i];
                                }
                            }
                            pointsNeeded = class2PointsPossible.Sum() * targetGrade - pointsEarned;
                            pointsRemaining = class2PointsPossible.Sum() - pointsLocked;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class2ItemStatus[i] == "no")
                                {
                                    class2TempWeights[i] = class2PointsPossible[i] / pointsRemaining;
                                    if (class2PointsPossible[i] == 0)
                                    {
                                        //leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class2TempWeights[i] * pointsNeeded).ToString("F2");
                                    }
                                }
                            }
                        }

                        if (class2Weights.Sum() == 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class2ItemStatus[i] == "yes")
                                {
                                    weightEarned += class2Weights[i];
                                    weightedGradeEarned += class2WeightedGrades[i];
                                }
                            }
                            weightNeeded = targetGrade - weightedGradeEarned;
                            weightRemaining = class2Weights.Sum() - weightEarned;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class2ItemStatus[i] == "no")
                                {
                                    class2TempWeights[i] = class2Weights[i] / weightRemaining * weightNeeded;
                                    if (class2Weights[i] == 0)
                                    {
                                        //Leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class2TempWeights[i] / class2Weights[i] * class2PointsPossible[i]).ToString("F2");
                                    }
                                }
                            }
                        }
                    }


                    //For class3
                    if (selection == 3)
                    {
                        if (class3Weights.Sum() != 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class3ItemStatus[i] == "yes")
                                {
                                    pointsEarned += class3PointsEarned[i];
                                    pointsLocked += class3PointsPossible[i];
                                }
                            }
                            pointsNeeded = class3PointsPossible.Sum() * targetGrade - pointsEarned;
                            pointsRemaining = class3PointsPossible.Sum() - pointsLocked;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class3ItemStatus[i] == "no")
                                {
                                    class3TempWeights[i] = class3PointsPossible[i] / pointsRemaining;
                                    if (class3PointsPossible[i] == 0)
                                    {
                                        //leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class3TempWeights[i] * pointsNeeded).ToString("F2");
                                    }
                                }
                            }
                        }

                        if (class3Weights.Sum() == 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class3ItemStatus[i] == "yes")
                                {
                                    weightEarned += class3Weights[i];
                                    weightedGradeEarned += class3WeightedGrades[i];
                                }
                            }
                            weightNeeded = targetGrade - weightedGradeEarned;
                            weightRemaining = class3Weights.Sum() - weightEarned;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class3ItemStatus[i] == "no")
                                {
                                    class3TempWeights[i] = class3Weights[i] / weightRemaining * weightNeeded;
                                    if (class3Weights[i] == 0)
                                    {
                                        //Leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class3TempWeights[i] / class3Weights[i] * class3PointsPossible[i]).ToString("F2");
                                    }
                                }
                            }
                        }
                    }


                    //For class4
                    if (selection == 4)
                    {
                        if (class4Weights.Sum() != 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class4ItemStatus[i] == "yes")
                                {
                                    pointsEarned += class4PointsEarned[i];
                                    pointsLocked += class4PointsPossible[i];
                                }
                            }
                            pointsNeeded = class4PointsPossible.Sum() * targetGrade - pointsEarned;
                            pointsRemaining = class4PointsPossible.Sum() - pointsLocked;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class4ItemStatus[i] == "no")
                                {
                                    class4TempWeights[i] = class4PointsPossible[i] / pointsRemaining;
                                    if (class4PointsPossible[i] == 0)
                                    {
                                        //leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class4TempWeights[i] * pointsNeeded).ToString("F2");
                                    }
                                }
                            }
                        }

                        if (class4Weights.Sum() == 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class4ItemStatus[i] == "yes")
                                {
                                    weightEarned += class4Weights[i];
                                    weightedGradeEarned += class4WeightedGrades[i];
                                }
                            }
                            weightNeeded = targetGrade - weightedGradeEarned;
                            weightRemaining = class4Weights.Sum() - weightEarned;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class4ItemStatus[i] == "no")
                                {
                                    class4TempWeights[i] = class4Weights[i] / weightRemaining * weightNeeded;
                                    if (class4Weights[i] == 0)
                                    {
                                        //Leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class4TempWeights[i] / class4Weights[i] * class4PointsPossible[i]).ToString("F2");
                                    }
                                }
                            }
                        }
                    }

                    //For class5
                    if (selection == 5)
                    {
                        if (class5Weights.Sum() != 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class5ItemStatus[i] == "yes")
                                {
                                    pointsEarned += class5PointsEarned[i];
                                    pointsLocked += class5PointsPossible[i];
                                }
                            }
                            pointsNeeded = class5PointsPossible.Sum() * targetGrade - pointsEarned;
                            pointsRemaining = class5PointsPossible.Sum() - pointsLocked;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class5ItemStatus[i] == "no")
                                {
                                    class5TempWeights[i] = class5PointsPossible[i] / pointsRemaining;
                                    if (class5PointsPossible[i] == 0)
                                    {
                                        //leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class5TempWeights[i] * pointsNeeded).ToString("F2");
                                    }
                                }
                            }
                        }

                        if (class5Weights.Sum() == 1)
                        {
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class5ItemStatus[i] == "yes")
                                {
                                    weightEarned += class5Weights[i];
                                    weightedGradeEarned += class5WeightedGrades[i];
                                }
                            }
                            weightNeeded = targetGrade - weightedGradeEarned;
                            weightRemaining = class5Weights.Sum() - weightEarned;
                            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                            {
                                if (class5ItemStatus[i] == "no")
                                {
                                    class5TempWeights[i] = class5Weights[i] / weightRemaining * weightNeeded;
                                    if (class5Weights[i] == 0)
                                    {
                                        //Leave blank so program does nothing
                                    }
                                    else
                                    {
                                        pnlItems.Controls["txtItemEarned" + i].Text = (class5TempWeights[i] / class5Weights[i] * class5PointsPossible[i]).ToString("F2");
                                    }
                                }
                            }
                        }
                    }

                    Save_Class_CurrSel();
                    Totals();

                    txtTargetGrade.Visible = false;
                    btnScenarioTarget.Text = "Target";
                    targetGradeStatus = 0;
                }
            }

            //sysmsg
            lblSysMsg.Text = "btnScenarioTarget successful";
            Sys_Msg_Save_Txt();
        }

        /* Clear */
        private void btnClearCurrent_Click(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "btnClearCurrent_Click started";
            Sys_Msg_Save_Txt();

            //Msgbox
            string message = String.Format("Are you sure you want to clear all your data for {0}?", lblClass.Text.ToString());
            string caption = "Warning";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If yes on msgbox
            if (result == DialogResult.Yes)
            {
                if (selection == 0)
                {
                    txtClassName0.Text = "";
                    classNames[0] = txtClassName0.Text;

                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class0ItemStatus[i] = "no";
                        class0ItemNames[i] = "";
                        class0PointsEarned[i] = 0;
                        class0PointsPossible[i] = 0;
                        class0Grades[i] = 0;
                        class0Weights[i] = 0;
                        class0WeightedGrades[i] = 0;
                    }
                }
                if (selection == 1)
                {
                    txtClassName1.Text = "";
                    classNames[1] = txtClassName1.Text;

                    for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                    {
                        class1ItemStatus[i] = "no";
                        class1ItemNames[i] = "";
                        class1PointsEarned[i] = 0;
                        class1PointsPossible[i] = 0;
                        class1Grades[i] = 0;
                        class1Weights[i] = 0;
                        class1WeightedGrades[i] = 0;
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
                        class2ItemNames[i] = "";
                        class2PointsEarned[i] = 0;
                        class2PointsPossible[i] = 0;
                        class2Grades[i] = 0;
                        class2Weights[i] = 0;
                        class2WeightedGrades[i] = 0;
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
                        class3ItemNames[i] = "";
                        class3PointsEarned[i] = 0;
                        class3PointsPossible[i] = 0;
                        class3Grades[i] = 0;
                        class3Weights[i] = 0;
                        class3WeightedGrades[i] = 0;
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
                        class4ItemNames[i] = "";
                        class4PointsEarned[i] = 0;
                        class4PointsPossible[i] = 0;
                        class4Grades[i] = 0;
                        class4Weights[i] = 0;
                        class4WeightedGrades[i] = 0;
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
                        class5ItemNames[i] = "";
                        class5PointsEarned[i] = 0;
                        class5PointsPossible[i] = 0;
                        class5Grades[i] = 0;
                        class5Weights[i] = 0;
                        class5WeightedGrades[i] = 0;
                    }
                }

                //Set txtboxes so save doesnt pick up old ones
                Set_Txt_Class_CurrSel();
                Totals();

                //SysMsg
                lblSysMsg.Text = "A class has been cleared";
                Sys_Msg_Save_Txt();
            }

            lblSysMsg.Text = "btnClearCurrent_Click successful";
            Sys_Msg_Save_Txt();
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "btnClearAll_Click started";
            Sys_Msg_Save_Txt();

            string message = String.Format("Are you sure you want to clear all your data?");
            string caption = "Warning";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //Class names
                for (int i = 0; i < NUMBER_OF_CLASSES; i++)
                {                    
                    pnlClassBtns.Controls["txtClassName" + i].Text = "";
                    classNames[i] = pnlClassBtns.Controls["txtClassName" + i].Text; 
                }
                 
                //Items
                for (int i = 0; i < NUMBER_OF_ITEMS; i++)
                {
                    class0ItemStatus[i] = "no";
                    class0ItemNames[i] = "";
                    class0PointsEarned[i] = 0;
                    class0PointsPossible[i] = 0;
                    class0Grades[i] = 0;
                    class0Weights[i] = 0;
                    class0WeightedGrades[i] = 0;

                    class1ItemStatus[i] = "no";
                    class1ItemNames[i] = "";
                    class1PointsEarned[i] = 0;
                    class1PointsPossible[i] = 0;
                    class1Grades[i] = 0;
                    class1Weights[i] = 0;
                    class1WeightedGrades[i] = 0;

                    class2ItemStatus[i] = "no";
                    class2ItemNames[i] = "";
                    class2PointsEarned[i] = 0;
                    class2PointsPossible[i] = 0;
                    class2Grades[i] = 0;
                    class2Weights[i] = 0;
                    class2WeightedGrades[i] = 0;

                    class3ItemStatus[i] = "no";
                    class3ItemNames[i] = "";
                    class3PointsEarned[i] = 0;
                    class3PointsPossible[i] = 0;
                    class3Grades[i] = 0;
                    class3Weights[i] = 0;
                    class3WeightedGrades[i] = 0;

                    class4ItemStatus[i] = "no";
                    class4ItemNames[i] = "";
                    class4PointsEarned[i] = 0;
                    class4PointsPossible[i] = 0;
                    class4Grades[i] = 0;
                    class4Weights[i] = 0;
                    class4WeightedGrades[i] = 0;

                    class5ItemStatus[i] = "no";
                    class5ItemNames[i] = "";
                    class5PointsEarned[i] = 0;
                    class5PointsPossible[i] = 0;
                    class5Grades[i] = 0;
                    class5Weights[i] = 0;
                    class5WeightedGrades[i] = 0;
                }
            }

            Set_Txt_Class_CurrSel();
            Totals();

            //SysMsg
            lblSysMsg.Text = "btnClearAll_Click successful";
            Sys_Msg_Save_Txt();
        }

        /*
         */
        //=======================================================================================================
        /* CHANGE EVENTS */
        //=======================================================================================================
        /*
         */

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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
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
                MessageBox.Show("Only numbers are allowed, if blank input 0");
                Set_Txt_Class_CurrSel();
                txtItemWeight9.Focus();
            }
            Save_Class_CurrSel();
            Totals();
        }

        /* On close event */
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SysMsg
            lblSysMsg.Text = "Main_FormClosing started";
            Sys_Msg_Save_Txt();

            Save_Class_CurrSel();
            Save_To_Txt_Class_All();

            //SysMsg
            lblSysMsg.Text = "Main_FormClosing sucessful";
            Sys_Msg_Save_Txt();
        }
    }

    //START NEW SECTION HERE

}