using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }

        // SAVE BUTTON CLICK EVENT
        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            // STEP 1: Basic validation for empty fields
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbProgramme.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // STEP 2: Validate Age input safely (prevent crash)
            int age;
            if (!int.TryParse(txtAge.Text, out age))
            {
                MessageBox.Show("Please enter a valid numeric age.");
                txtAge.Focus();
                return;
            }

            // STEP 3: Basic email validation
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.");
                txtEmail.Focus();
                return;
            }

            // STEP 4: Create Student object
            Student student = new Student
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Age = age,
                Programme = cmbProgramme.Text
            };

            // STEP 5: Display output using StringBuilder
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Student saved successfully!");
            sb.AppendLine($"Student ID: {student.StudentId}");
            sb.AppendLine($"Full Name: {student.FullName}");
            sb.AppendLine($"Email: {student.Email}");
            sb.AppendLine($"Age: {student.Age}");
            sb.AppendLine($"Programme: {student.Programme}");

            txtStudentOutput.Text = sb.ToString();
        }

        // CLEAR BUTTON CLICK EVENT
        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            // STEP 1: Clear all input fields
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtAge.Clear();


            cmbProgramme.SelectedIndex = -1;


            txtStudentOutput.Clear();

            txtStudentId.Focus();
        }

        // BACK BUTTON CLICK EVENT
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStudentRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
