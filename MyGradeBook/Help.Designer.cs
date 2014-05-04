namespace MyGradeBook
{
    partial class Help
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.button5 = new System.Windows.Forms.Button();
            this.btnGettingStarted = new System.Windows.Forms.Button();
            this.btnToPass = new System.Windows.Forms.Button();
            this.btnNamingClasses = new System.Windows.Forms.Button();
            this.btnUsingWeights = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 110);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 24);
            this.button5.TabIndex = 12;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnGettingStarted
            // 
            this.btnGettingStarted.Location = new System.Drawing.Point(0, 18);
            this.btnGettingStarted.Name = "btnGettingStarted";
            this.btnGettingStarted.Size = new System.Drawing.Size(105, 24);
            this.btnGettingStarted.TabIndex = 11;
            this.btnGettingStarted.Text = "Getting Started";
            this.btnGettingStarted.UseVisualStyleBackColor = true;
            this.btnGettingStarted.Click += new System.EventHandler(this.btnGettingStarted_Click);
            // 
            // btnToPass
            // 
            this.btnToPass.Location = new System.Drawing.Point(0, 87);
            this.btnToPass.Name = "btnToPass";
            this.btnToPass.Size = new System.Drawing.Size(105, 24);
            this.btnToPass.TabIndex = 10;
            this.btnToPass.Text = "To Pass";
            this.btnToPass.UseVisualStyleBackColor = true;
            this.btnToPass.Click += new System.EventHandler(this.btnToPass_Click);
            // 
            // btnNamingClasses
            // 
            this.btnNamingClasses.Location = new System.Drawing.Point(0, 41);
            this.btnNamingClasses.Name = "btnNamingClasses";
            this.btnNamingClasses.Size = new System.Drawing.Size(105, 24);
            this.btnNamingClasses.TabIndex = 9;
            this.btnNamingClasses.Text = "Naming Classes";
            this.btnNamingClasses.UseVisualStyleBackColor = true;
            this.btnNamingClasses.Click += new System.EventHandler(this.btnRenamingClasses_Click);
            // 
            // btnUsingWeights
            // 
            this.btnUsingWeights.Location = new System.Drawing.Point(0, 64);
            this.btnUsingWeights.Name = "btnUsingWeights";
            this.btnUsingWeights.Size = new System.Drawing.Size(105, 24);
            this.btnUsingWeights.TabIndex = 8;
            this.btnUsingWeights.Text = "Weights";
            this.btnUsingWeights.UseVisualStyleBackColor = true;
            this.btnUsingWeights.Click += new System.EventHandler(this.btnUsingWeights_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(114, 23);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(435, 322);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "Description";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 354);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnGettingStarted);
            this.Controls.Add(this.btnToPass);
            this.Controls.Add(this.btnNamingClasses);
            this.Controls.Add(this.btnUsingWeights);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Help";
            this.Text = "Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnGettingStarted;
        private System.Windows.Forms.Button btnToPass;
        private System.Windows.Forms.Button btnNamingClasses;
        private System.Windows.Forms.Button btnUsingWeights;
        private System.Windows.Forms.Label lblDescription;
    }
}