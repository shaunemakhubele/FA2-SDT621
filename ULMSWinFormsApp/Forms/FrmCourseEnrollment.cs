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
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {
            MarkRecord record = new MarkRecord();

            record.StudentId = txtMarkStudentId.Text;
            record.StudentName = txtMarkStudentName.Text;

            try
            {
                record.Subject1 = Convert.ToDouble(txtSubject1.Text);
                record.Subject2 = Convert.ToDouble(txtSubject2.Text);
                record.Subject3 = Convert.ToDouble(txtSubject3.Text);
            }
            catch
            {
                MessageBox.Show("Please enter valid numeric marks.");
                return;
            }

            // FIXED: improved validation to prevent empty student fields
            if (string.IsNullOrWhiteSpace(record.StudentId) ||
                string.IsNullOrWhiteSpace(record.StudentName))
            {
                MessageBox.Show("Please enter student ID and name.");
                return;
            }

            // FIXED: clearer average calculation (same logic, but explicitly safe formatting)
            record.Average = (record.Subject1 + record.Subject2 + record.Subject3) / 3.0;

            if (record.Average >= 50)
            {
                record.ResultStatus = "PASS";
            }
            else
            {
                record.ResultStatus = "FAIL";
            }

            txtMarksOutput.Text =
                "Marks processed successfully!" + Environment.NewLine +
                "Student ID: " + record.StudentId + Environment.NewLine +
                "Student Name: " + record.StudentName + Environment.NewLine +
                "Subject 1: " + record.Subject1 + Environment.NewLine +
                "Subject 2: " + record.Subject2 + Environment.NewLine +
                "Subject 3: " + record.Subject3 + Environment.NewLine +
                "Average: " + record.Average + Environment.NewLine +
                "Final Result: " + record.ResultStatus;
        }

        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMarksCapture_Load(object sender, EventArgs e)
        {
        }
    }
}
