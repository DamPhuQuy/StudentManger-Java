namespace WinFormsApp1
{
    partial class StudentForm
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
            dgvStudents = new DataGridView();
            panel4 = new Panel();
            label8 = new Label();
            txtStatus = new TextBox();
            label7 = new Label();
            txtMajor = new TextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtFullName = new TextBox();
            label4 = new Label();
            txtStudentId = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtpEnrollmentDate = new DateTimePicker();
            dtpDateOfBirth = new DateTimePicker();
            label9 = new Label();
            txtPhoneNumber = new TextBox();
            label10 = new Label();
            txtAddress = new TextBox();

            panel1.BackColor = Color.DodgerBlue;
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
            lblTitle.Size = new Size(189, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Student Management";

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
            txtSearch.PlaceholderText = "Enter student ID or name";

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
            panel3.Controls.Add(dgvStudents);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(520, 130);
            panel3.Name = "panel3";
            panel3.Size = new Size(480, 320);
            panel3.TabIndex = 2;

            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(0, 0);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(480, 320);
            dgvStudents.TabIndex = 0;
            dgvStudents.CellClick += DgvStudents_CellClick;

            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(label10);
            panel4.Controls.Add(txtAddress);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(txtPhoneNumber);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(txtStatus);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(txtMajor);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(txtEmail);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(txtFullName);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(txtStudentId);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(dtpEnrollmentDate);
            panel4.Controls.Add(dtpDateOfBirth);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 130);
            panel4.Name = "panel4";
            panel4.Size = new Size(510, 320);
            panel4.TabIndex = 3;

            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Student ID:";

            txtStudentId.Location = new Point(100, 12);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(180, 23);
            txtStudentId.TabIndex = 1;

            label2.AutoSize = true;
            label2.Location = new Point(10, 45);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 2;
            label2.Text = "Full Name:";

            txtFullName.Location = new Point(100, 42);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(180, 23);
            txtFullName.TabIndex = 3;

            label3.AutoSize = true;
            label3.Location = new Point(10, 75);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 4;
            label3.Text = "Email:";

            txtEmail.Location = new Point(100, 72);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(180, 23);
            txtEmail.TabIndex = 5;

            label4.AutoSize = true;
            label4.Location = new Point(10, 105);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 6;
            label4.Text = "Phone Number:";

            txtPhoneNumber.Location = new Point(100, 102);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(180, 23);
            txtPhoneNumber.TabIndex = 7;

            label5.AutoSize = true;
            label5.Location = new Point(10, 135);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 8;
            label5.Text = "Major:";

            txtMajor.Location = new Point(100, 132);
            txtMajor.Name = "txtMajor";
            txtMajor.Size = new Size(180, 23);
            txtMajor.TabIndex = 9;

            label6.AutoSize = true;
            label6.Location = new Point(10, 165);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 10;
            label6.Text = "Date of Birth:";

            dtpDateOfBirth.Location = new Point(100, 162);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(180, 23);
            dtpDateOfBirth.TabIndex = 11;

            label7.AutoSize = true;
            label7.Location = new Point(10, 195);
            label7.Name = "label7";
            label7.Size = new Size(97, 15);
            label7.TabIndex = 12;
            label7.Text = "Enrollment Date:";

            dtpEnrollmentDate.Location = new Point(100, 192);
            dtpEnrollmentDate.Name = "dtpEnrollmentDate";
            dtpEnrollmentDate.Size = new Size(180, 23);
            dtpEnrollmentDate.TabIndex = 13;

            label8.AutoSize = true;
            label8.Location = new Point(10, 225);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 14;
            label8.Text = "Status:";

            txtStatus.Location = new Point(100, 222);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(180, 23);
            txtStatus.TabIndex = 15;

            label9.AutoSize = true;
            label9.Location = new Point(10, 255);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 16;
            label9.Text = "Address:";

            txtAddress.Location = new Point(100, 252);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(180, 50);
            txtAddress.TabIndex = 17;

            label10.AutoSize = true;
            label10.Location = new Point(300, 15);
            label10.Name = "label10";
            label10.Size = new Size(82, 15);
            label10.TabIndex = 18;
            label10.Text = "(double-click to edit)";
            label10.Font = new Font("Segoe UI", 8F, FontStyle.Italic);

            // StudentForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 450);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StudentForm";
            Text = "Student Management";
            Load += StudentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private DataGridView dgvStudents;
        private Panel panel4;
        private Label label8;
        private TextBox txtStatus;
        private Label label7;
        private TextBox txtMajor;
        private Label label6;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtFullName;
        private Label label4;
        private TextBox txtStudentId;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpEnrollmentDate;
        private DateTimePicker dtpDateOfBirth;
        private Label label9;
        private TextBox txtPhoneNumber;
        private Label label10;
        private TextBox txtAddress;
    }
}
