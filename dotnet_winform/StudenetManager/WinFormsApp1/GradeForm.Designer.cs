namespace WinFormsApp1
{
    partial class GradeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            lblTitle = new Label();
            panel2 = new Panel();
            btnClose = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panel3 = new Panel();
            dgvGrades = new DataGridView();
            panel4 = new Panel();
            label7 = new Label();
            txtComments = new TextBox();
            label6 = new Label();
            txtGradedBy = new TextBox();
            label5 = new Label();
            dtpGradedDate = new DateTimePicker();
            label4 = new Label();
            txtGradePoints = new TextBox();
            label3 = new Label();
            txtLetterGrade = new TextBox();
            label2 = new Label();
            txtNumericGrade = new TextBox();
            label1 = new Label();
            lblNote = new Label();

            panel1.BackColor = Color.DarkOrange;
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 50);
            panel1.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(10, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(147, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Grade Management";

            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(lblNote);
            panel2.Controls.Add(btnClose);
            panel2.Controls.Add(btnClear);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnUpdate);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(lblSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(1000, 80);
            panel2.TabIndex = 1;

            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(77, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search (ID):";

            txtSearch.Location = new Point(90, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 1;
            txtSearch.PlaceholderText = "Student or Course ID";

            btnSearch.Location = new Point(300, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;

            btnAdd.BackColor = Color.Green;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(10, 45);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;

            btnUpdate.BackColor = Color.Orange;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(95, 45);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete.BackColor = Color.Red;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(180, 45);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;

            btnClear.Location = new Point(270, 45);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;

            btnClose.Location = new Point(905, 45);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;

            lblNote.AutoSize = true;
            lblNote.Location = new Point(420, 55);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(350, 15);
            lblNote.TabIndex = 8;
            lblNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNote.Text = "Select a grade from the list below to edit";

            panel3.AutoScroll = true;
            panel3.Controls.Add(dgvGrades);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(520, 130);
            panel3.Name = "panel3";
            panel3.Size = new Size(480, 320);
            panel3.TabIndex = 2;

            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.AllowUserToDeleteRows = false;
            dgvGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrades.Dock = DockStyle.Fill;
            dgvGrades.Location = new Point(0, 0);
            dgvGrades.MultiSelect = false;
            dgvGrades.Name = "dgvGrades";
            dgvGrades.ReadOnly = true;
            dgvGrades.RowHeadersWidth = 51;
            dgvGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrades.Size = new Size(480, 320);
            dgvGrades.TabIndex = 0;
            dgvGrades.CellClick += DgvGrades_CellClick;

            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(label7);
            panel4.Controls.Add(txtComments);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(txtGradedBy);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(dtpGradedDate);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(txtGradePoints);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(txtLetterGrade);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(txtNumericGrade);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 130);
            panel4.Name = "panel4";
            panel4.Size = new Size(510, 320);
            panel4.TabIndex = 3;

            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 0;
            label1.Text = "Numeric Grade:";

            txtNumericGrade.Location = new Point(100, 12);
            txtNumericGrade.Name = "txtNumericGrade";
            txtNumericGrade.Size = new Size(180, 23);
            txtNumericGrade.TabIndex = 1;

            label2.AutoSize = true;
            label2.Location = new Point(10, 45);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 2;
            label2.Text = "Letter Grade:";

            txtLetterGrade.Location = new Point(100, 42);
            txtLetterGrade.Name = "txtLetterGrade";
            txtLetterGrade.Size = new Size(180, 23);
            txtLetterGrade.TabIndex = 3;

            label3.AutoSize = true;
            label3.Location = new Point(10, 75);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 4;
            label3.Text = "Grade Points:";

            txtGradePoints.Location = new Point(100, 72);
            txtGradePoints.Name = "txtGradePoints";
            txtGradePoints.Size = new Size(180, 23);
            txtGradePoints.TabIndex = 5;

            label4.AutoSize = true;
            label4.Location = new Point(10, 105);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 6;
            label4.Text = "Graded Date:";

            dtpGradedDate.Location = new Point(100, 102);
            dtpGradedDate.Name = "dtpGradedDate";
            dtpGradedDate.Size = new Size(180, 23);
            dtpGradedDate.TabIndex = 7;

            label5.AutoSize = true;
            label5.Location = new Point(10, 135);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 8;
            label5.Text = "Graded By:";

            txtGradedBy.Location = new Point(100, 132);
            txtGradedBy.Name = "txtGradedBy";
            txtGradedBy.Size = new Size(180, 23);
            txtGradedBy.TabIndex = 9;

            label6.AutoSize = true;
            label6.Location = new Point(10, 165);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 10;
            label6.Text = "Comments:";

            txtComments.Location = new Point(100, 162);
            txtComments.Multiline = true;
            txtComments.Name = "txtComments";
            txtComments.Size = new Size(180, 130);
            txtComments.TabIndex = 11;

            label7.AutoSize = true;
            label7.Location = new Point(300, 15);
            label7.Name = "label7";
            label7.Size = new Size(100, 15);
            label7.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            label7.TabIndex = 12;
            label7.Text = "(double-click to edit)";

            // GradeForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 450);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "GradeForm";
            Text = "Grade Management";
            Load += GradeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panel1;
        private Label lblTitle;
        private Panel panel2;
        private Button btnClose;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel panel3;
        private DataGridView dgvGrades;
        private Panel panel4;
        private Label label7;
        private TextBox txtComments;
        private Label label6;
        private TextBox txtGradedBy;
        private Label label5;
        private DateTimePicker dtpGradedDate;
        private Label label4;
        private TextBox txtGradePoints;
        private Label label3;
        private TextBox txtLetterGrade;
        private Label label2;
        private TextBox txtNumericGrade;
        private Label label1;
        private Label lblNote;
    }
}
