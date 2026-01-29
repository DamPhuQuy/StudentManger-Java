namespace WinFormsApp1
{
    partial class CourseForm
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
            dgvCourses = new DataGridView();
            panel4 = new Panel();
            label8 = new Label();
            txtDescription = new TextBox();
            label7 = new Label();
            txtMaxCapacity = new TextBox();
            label6 = new Label();
            txtInstructor = new TextBox();
            label5 = new Label();
            txtCredits = new TextBox();
            label4 = new Label();
            txtDepartment = new TextBox();
            label3 = new Label();
            txtCourseName = new TextBox();
            label2 = new Label();
            txtCourseId = new TextBox();
            label1 = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtSemester = new TextBox();

            panel1.BackColor = Color.ForestGreen;
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
            lblTitle.Size = new Size(169, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Course Management";

            panel2.BackColor = SystemColors.Control;
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
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";

            txtSearch.Location = new Point(60, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 1;
            txtSearch.PlaceholderText = "Enter course ID or name";

            btnSearch.Location = new Point(270, 12);
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

            panel3.AutoScroll = true;
            panel3.Controls.Add(dgvCourses);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(520, 130);
            panel3.Name = "panel3";
            panel3.Size = new Size(480, 320);
            panel3.TabIndex = 2;

            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Dock = DockStyle.Fill;
            dgvCourses.Location = new Point(0, 0);
            dgvCourses.MultiSelect = false;
            dgvCourses.Name = "dgvCourses";
            dgvCourses.ReadOnly = true;
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Size = new Size(480, 320);
            dgvCourses.TabIndex = 0;
            dgvCourses.CellClick += DgvCourses_CellClick;

            panel4.BackColor = SystemColors.Control;
            panel4.AutoScroll = true;
            panel4.Controls.Add(label11);
            panel4.Controls.Add(txtSemester);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(dtpEndDate);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(dtpStartDate);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(txtDescription);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(txtMaxCapacity);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(txtInstructor);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(txtCredits);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(txtDepartment);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(txtCourseName);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(txtCourseId);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 130);
            panel4.Name = "panel4";
            panel4.Size = new Size(510, 320);
            panel4.TabIndex = 3;

            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Course ID:";

            txtCourseId.Location = new Point(100, 12);
            txtCourseId.Name = "txtCourseId";
            txtCourseId.Size = new Size(180, 23);
            txtCourseId.TabIndex = 1;

            label2.AutoSize = true;
            label2.Location = new Point(10, 45);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 2;
            label2.Text = "Course Name:";

            txtCourseName.Location = new Point(100, 42);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(180, 23);
            txtCourseName.TabIndex = 3;

            label3.AutoSize = true;
            label3.Location = new Point(10, 75);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 4;
            label3.Text = "Department:";

            txtDepartment.Location = new Point(100, 72);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(180, 23);
            txtDepartment.TabIndex = 5;

            label4.AutoSize = true;
            label4.Location = new Point(10, 105);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 6;
            label4.Text = "Credits:";

            txtCredits.Location = new Point(100, 102);
            txtCredits.Name = "txtCredits";
            txtCredits.Size = new Size(180, 23);
            txtCredits.TabIndex = 7;

            label5.AutoSize = true;
            label5.Location = new Point(10, 135);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 8;
            label5.Text = "Instructor:";

            txtInstructor.Location = new Point(100, 132);
            txtInstructor.Name = "txtInstructor";
            txtInstructor.Size = new Size(180, 23);
            txtInstructor.TabIndex = 9;

            label6.AutoSize = true;
            label6.Location = new Point(10, 165);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 10;
            label6.Text = "Semester:";

            txtSemester.Location = new Point(100, 162);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(180, 23);
            txtSemester.TabIndex = 11;

            label9.AutoSize = true;
            label9.Location = new Point(10, 195);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 12;
            label9.Text = "Start Date:";

            dtpStartDate.Location = new Point(100, 192);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(180, 23);
            dtpStartDate.TabIndex = 13;

            label10.AutoSize = true;
            label10.Location = new Point(10, 225);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 14;
            label10.Text = "End Date:";

            dtpEndDate.Location = new Point(100, 222);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(180, 23);
            dtpEndDate.TabIndex = 15;

            label7.AutoSize = true;
            label7.Location = new Point(10, 255);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 16;
            label7.Text = "Max Capacity:";

            txtMaxCapacity.Location = new Point(100, 252);
            txtMaxCapacity.Name = "txtMaxCapacity";
            txtMaxCapacity.Size = new Size(180, 23);
            txtMaxCapacity.TabIndex = 17;

            label8.AutoSize = true;
            label8.Location = new Point(10, 285);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 18;
            label8.Text = "Description:";

            txtDescription.Location = new Point(100, 280);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(180, 30);
            txtDescription.TabIndex = 19;

            label11.AutoSize = true;
            label11.Location = new Point(300, 15);
            label11.Name = "label11";
            label11.Size = new Size(82, 15);
            label11.TabIndex = 20;
            label11.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            label11.Text = "(double-click to edit)";

            // CourseForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 450);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CourseForm";
            Text = "Course Management";
            Load += CourseForm_Load;
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
        private DataGridView dgvCourses;
        private Panel panel4;
        private Label label8;
        private TextBox txtDescription;
        private Label label7;
        private TextBox txtMaxCapacity;
        private Label label6;
        private TextBox txtInstructor;
        private Label label5;
        private TextBox txtCredits;
        private Label label4;
        private TextBox txtDepartment;
        private Label label3;
        private TextBox txtCourseName;
        private Label label2;
        private TextBox txtCourseId;
        private Label label1;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtSemester;
    }
}
