namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateStatus("Application loaded successfully");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenStudentForm();
        }

        private void CoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCourseForm();
        }

        private void GradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGradeForm();
        }

        private void EnrollmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEnrollmentForm();
        }

        private void ToolStripAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Student Manager System v1.0\n\n" +
                "A comprehensive system for managing student information,\n" +
                "courses, grades, and enrollments.\n\n" +
                "© 2026 All Rights Reserved",
                "About Student Manager",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            OpenStudentForm();
        }

        private void BtnCourses_Click(object sender, EventArgs e)
        {
            OpenCourseForm();
        }

        private void BtnGrades_Click(object sender, EventArgs e)
        {
            OpenGradeForm();
        }

        private void BtnEnrollments_Click(object sender, EventArgs e)
        {
            OpenEnrollmentForm();
        }

        private void OpenStudentForm()
        {
            StudentForm form = new StudentForm();
            form.ShowDialog(this);
            UpdateStatus("Student form opened");
        }

        private void OpenCourseForm()
        {
            CourseForm form = new CourseForm();
            form.ShowDialog(this);
            UpdateStatus("Course form opened");
        }

        private void OpenGradeForm()
        {
            GradeForm form = new GradeForm();
            form.ShowDialog(this);
            UpdateStatus("Grade form opened");
        }

        private void OpenEnrollmentForm()
        {
            EnrollmentForm form = new EnrollmentForm();
            form.ShowDialog(this);
            UpdateStatus("Enrollment form opened");
        }

        private void UpdateStatus(string message)
        {
            statusLabel.Text = message;
        }
    }
}
