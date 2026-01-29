namespace WinFormsApp1
{
    public partial class EnrollmentForm : Form
    {
        public EnrollmentForm()
        {
            InitializeComponent();
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            LoadEnrollments();
            ClearForm();
        }

        private void LoadEnrollments()
        {
            try
            {
                dgvEnrollments.DataSource = null;
                // TODO: Load from service
                dgvEnrollments.AutoGenerateColumns = true;
                MessageBox.Show("Enrollments loaded successfully (Data integration needed)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading enrollments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    MessageBox.Show("Enrollment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadEnrollments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput() && ValidateSelectedRow())
                {
                    MessageBox.Show("Enrollment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadEnrollments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSelectedRow())
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this enrollment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Enrollment deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadEnrollments();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement search logic
                LoadEnrollments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching enrollments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DgvEnrollments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEnrollments.Rows[e.RowIndex];
                txtStudentId.Text = row.Cells["StudentId"]?.Value?.ToString() ?? "";
                txtCourseId.Text = row.Cells["CourseId"]?.Value?.ToString() ?? "";
                txtStatus.Text = row.Cells["Status"]?.Value?.ToString() ?? "";
                txtDropReason.Text = row.Cells["DropReason"]?.Value?.ToString() ?? "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Student ID is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCourseId.Text))
            {
                MessageBox.Show("Course ID is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateSelectedRow()
        {
            if (dgvEnrollments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an enrollment from the list", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtStudentId.Clear();
            txtCourseId.Clear();
            txtStatus.Text = "Enrolled";
            txtDropReason.Clear();
            dtpEnrollmentDate.Value = DateTime.Now;
            dgvEnrollments.ClearSelection();
        }
    }
}
