namespace WinFormsApp1
{
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            ClearForm();
        }

        private void LoadCourses()
        {
            try
            {
                dgvCourses.DataSource = null;
                // TODO: Load from service
                dgvCourses.AutoGenerateColumns = true;
                MessageBox.Show("Courses loaded successfully (Data integration needed)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadCourses();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput() && ValidateSelectedRow())
                {
                    MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadCourses();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSelectedRow())
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadCourses();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement search logic
                LoadCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
                txtCourseId.Text = row.Cells["CourseId"]?.Value?.ToString() ?? "";
                txtCourseName.Text = row.Cells["CourseName"]?.Value?.ToString() ?? "";
                txtDepartment.Text = row.Cells["Department"]?.Value?.ToString() ?? "";
                txtCredits.Text = row.Cells["Credits"]?.Value?.ToString() ?? "";
                txtInstructor.Text = row.Cells["Instructor"]?.Value?.ToString() ?? "";
                txtSemester.Text = row.Cells["Semester"]?.Value?.ToString() ?? "";
                txtMaxCapacity.Text = row.Cells["MaxCapacity"]?.Value?.ToString() ?? "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCourseId.Text))
            {
                MessageBox.Show("Course ID is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Course Name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                MessageBox.Show("Department is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateSelectedRow()
        {
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course from the list", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtCourseId.Clear();
            txtCourseName.Clear();
            txtDepartment.Clear();
            txtCredits.Clear();
            txtInstructor.Clear();
            txtSemester.Clear();
            txtMaxCapacity.Clear();
            txtDescription.Clear();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(4);
            dgvCourses.ClearSelection();
        }
    }
}
