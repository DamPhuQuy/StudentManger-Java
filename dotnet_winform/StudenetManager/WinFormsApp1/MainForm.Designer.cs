namespace WinFormsApp1
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            manageToolStripMenuItem = new ToolStripMenuItem();
            studentsToolStripMenuItem = new ToolStripMenuItem();
            coursesToolStripMenuItem = new ToolStripMenuItem();
            gradesToolStripMenuItem = new ToolStripMenuItem();
            enrollmentsToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            toolStripAbout = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            panel1 = new Panel();
            lblWelcome = new Label();
            btnStudents = new Button();
            btnCourses = new Button();
            btnGrades = new Button();
            btnEnrollments = new Button();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, manageToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";

            // fileToolStripMenuItem
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";

            // exitToolStripMenuItem
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;

            // manageToolStripMenuItem
            manageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                studentsToolStripMenuItem,
                coursesToolStripMenuItem,
                gradesToolStripMenuItem,
                enrollmentsToolStripMenuItem
            });
            manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            manageToolStripMenuItem.Size = new Size(62, 20);
            manageToolStripMenuItem.Text = "Manage";

            // studentsToolStripMenuItem
            studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            studentsToolStripMenuItem.Size = new Size(137, 22);
            studentsToolStripMenuItem.Text = "Students";
            studentsToolStripMenuItem.Click += StudentsToolStripMenuItem_Click;

            // coursesToolStripMenuItem
            coursesToolStripMenuItem.Name = "coursesToolStripMenuItem";
            coursesToolStripMenuItem.Size = new Size(137, 22);
            coursesToolStripMenuItem.Text = "Courses";
            coursesToolStripMenuItem.Click += CoursesToolStripMenuItem_Click;

            // gradesToolStripMenuItem
            gradesToolStripMenuItem.Name = "gradesToolStripMenuItem";
            gradesToolStripMenuItem.Size = new Size(137, 22);
            gradesToolStripMenuItem.Text = "Grades";
            gradesToolStripMenuItem.Click += GradesToolStripMenuItem_Click;

            // enrollmentsToolStripMenuItem
            enrollmentsToolStripMenuItem.Name = "enrollmentsToolStripMenuItem";
            enrollmentsToolStripMenuItem.Size = new Size(137, 22);
            enrollmentsToolStripMenuItem.Text = "Enrollments";
            enrollmentsToolStripMenuItem.Click += EnrollmentsToolStripMenuItem_Click;

            // aboutToolStripMenuItem
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripAbout });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(44, 20);
            aboutToolStripMenuItem.Text = "Help";

            // toolStripAbout
            toolStripAbout.Name = "toolStripAbout";
            toolStripAbout.Size = new Size(107, 22);
            toolStripAbout.Text = "About";
            toolStripAbout.Click += ToolStripAbout_Click;

            // statusStrip1
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";

            // statusLabel
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 17);
            statusLabel.Text = "Ready";

            // panel1
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(btnEnrollments);
            panel1.Controls.Add(btnGrades);
            panel1.Controls.Add(btnCourses);
            panel1.Controls.Add(btnStudents);
            panel1.Controls.Add(lblWelcome);
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 400);
            panel1.TabIndex = 2;

            // lblWelcome
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.Location = new Point(200, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(400, 41);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to Student Manager";
            lblWelcome.TextAlign = ContentAlignment.TopCenter;

            // btnStudents
            btnStudents.BackColor = Color.RoyalBlue;
            btnStudents.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStudents.ForeColor = Color.White;
            btnStudents.Location = new Point(100, 120);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(300, 50);
            btnStudents.TabIndex = 1;
            btnStudents.Text = "Manage Students";
            btnStudents.UseVisualStyleBackColor = false;
            btnStudents.Click += BtnStudents_Click;

            // btnCourses
            btnCourses.BackColor = Color.ForestGreen;
            btnCourses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCourses.ForeColor = Color.White;
            btnCourses.Location = new Point(400, 120);
            btnCourses.Name = "btnCourses";
            btnCourses.Size = new Size(300, 50);
            btnCourses.TabIndex = 2;
            btnCourses.Text = "Manage Courses";
            btnCourses.UseVisualStyleBackColor = false;
            btnCourses.Click += BtnCourses_Click;

            // btnGrades
            btnGrades.BackColor = Color.DarkOrange;
            btnGrades.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGrades.ForeColor = Color.White;
            btnGrades.Location = new Point(100, 220);
            btnGrades.Name = "btnGrades";
            btnGrades.Size = new Size(300, 50);
            btnGrades.TabIndex = 3;
            btnGrades.Text = "Manage Grades";
            btnGrades.UseVisualStyleBackColor = false;
            btnGrades.Click += BtnGrades_Click;

            // btnEnrollments
            btnEnrollments.BackColor = Color.Crimson;
            btnEnrollments.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEnrollments.ForeColor = Color.White;
            btnEnrollments.Location = new Point(400, 220);
            btnEnrollments.Name = "btnEnrollments";
            btnEnrollments.Size = new Size(300, 50);
            btnEnrollments.TabIndex = 4;
            btnEnrollments.Text = "Manage Enrollments";
            btnEnrollments.UseVisualStyleBackColor = false;
            btnEnrollments.Click += BtnEnrollments_Click;

            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Student Manager System";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem manageToolStripMenuItem;
        private ToolStripMenuItem studentsToolStripMenuItem;
        private ToolStripMenuItem coursesToolStripMenuItem;
        private ToolStripMenuItem gradesToolStripMenuItem;
        private ToolStripMenuItem enrollmentsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem toolStripAbout;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private Panel panel1;
        private Label lblWelcome;
        private Button btnStudents;
        private Button btnCourses;
        private Button btnGrades;
        private Button btnEnrollments;
    }
}
