namespace WinFormsApp1
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            ClearForm();
        }

        private void LoadStudents()
        {
            try
            {
                dgvStudents.DataSource = null;
                // TODO: Load from service
                dgvStudents.AutoGenerateColumns = true;
                MessageBox.Show("Students loaded successfully (Data integration needed)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput() && ValidateSelectedRow())
                {
                    MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSelectedRow())
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadStudents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement search logic
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                txtStudentId.Text = row.Cells["StudentId"]?.Value?.ToString() ?? "";
                txtFullName.Text = row.Cells["FullName"]?.Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"]?.Value?.ToString() ?? "";
                txtPhoneNumber.Text = row.Cells["PhoneNumber"]?.Value?.ToString() ?? "";
                txtMajor.Text = row.Cells["Major"]?.Value?.ToString() ?? "";
                txtStatus.Text = row.Cells["Status"]?.Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Student ID is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateSelectedRow()
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student from the list", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtMajor.Clear();
            txtStatus.Text = "Active";
            txtAddress.Clear();
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
            dtpEnrollmentDate.Value = DateTime.Now;
            dgvStudents.ClearSelection();
        }
    }
}
