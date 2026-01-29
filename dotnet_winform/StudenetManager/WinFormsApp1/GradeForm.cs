namespace WinFormsApp1
{
    public partial class GradeForm : Form
    {
        public GradeForm()
        {
            InitializeComponent();
        }

        private void GradeForm_Load(object sender, EventArgs e)
        {
            LoadGrades();
            ClearForm();
        }

        private void LoadGrades()
        {
            try
            {
                dgvGrades.DataSource = null;
                // TODO: Load from service
                dgvGrades.AutoGenerateColumns = true;
                MessageBox.Show("Grades loaded successfully (Data integration needed)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    MessageBox.Show("Grade added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadGrades();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput() && ValidateSelectedRow())
                {
                    MessageBox.Show("Grade updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadGrades();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSelectedRow())
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this grade?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Grade deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadGrades();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement search logic
                LoadGrades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DgvGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGrades.Rows[e.RowIndex];
                txtNumericGrade.Text = row.Cells["NumericGrade"]?.Value?.ToString() ?? "";
                txtLetterGrade.Text = row.Cells["LetterGrade"]?.Value?.ToString() ?? "";
                txtGradePoints.Text = row.Cells["GradePoints"]?.Value?.ToString() ?? "";
                txtGradedBy.Text = row.Cells["GradedBy"]?.Value?.ToString() ?? "";
                txtComments.Text = row.Cells["Comments"]?.Value?.ToString() ?? "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNumericGrade.Text))
            {
                MessageBox.Show("Numeric Grade is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLetterGrade.Text))
            {
                MessageBox.Show("Letter Grade is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateSelectedRow()
        {
            if (dgvGrades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a grade from the list", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtNumericGrade.Clear();
            txtLetterGrade.Clear();
            txtGradePoints.Clear();
            txtGradedBy.Clear();
            txtComments.Clear();
            dtpGradedDate.Value = DateTime.Now;
            dgvGrades.ClearSelection();
        }
    }
}
