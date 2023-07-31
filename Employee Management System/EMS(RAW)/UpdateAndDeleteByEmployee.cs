using EMS_RAW_.BL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS_RAW_
{
    public partial class UpdateAndDeleteByEmployee : UserControl
    {
        string path = "UserData.txt";
        private static UpdateAndDeleteByEmployee instance;
        private bool isButtonClicked;
        public static UpdateAndDeleteByEmployee Instance
        {
            get
            {
                if (instance == null)
                    instance = new UpdateAndDeleteByEmployee();
                return instance;
            }


        }
        public UpdateAndDeleteByEmployee()
        {
            InitializeComponent();
            SaveButton.Enabled = false;
            BackButton.Enabled = false;
            NewPassTextBox.Visible = false;
            label5.Visible = false;
            showData();
        }
        public void SetNull()
        {
            EmployeeName.Text = null;
            OldPassword.Text = null;
            NewPassTextBox.Text = null;
            Role.Text = null;
        }
        public void showData()
        {
            EmployeeName.ReadOnly = true;
            OldPassword.ReadOnly = true;
            Role.ReadOnly = true;
            EmployeeName.Text = EmployeeDL.CurrentUser.EmployeeData.Name;
            OldPassword.Text = EmployeeDL.CurrentUser.EmployeeData.Password;
            Role.Text = EmployeeDL.CurrentUser.EmployeeData.Role;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private string takeInputForNewPass() // take input for Sign Up
        {
            string password = NewPassTextBox.Text;
            return password;
        }
        private void SearchEmployee_Click(object sender, EventArgs e)
        {
            RemoveEmployee.Enabled = false;
            EditEmployee.Enabled = false;
            OldPassword.Visible = false;
            label1.Visible = false;
            if (OldPassword.Visible == false)
            {
                label5.Visible = true;
                NewPassTextBox.Visible = true;
                isButtonClicked = false;
            }
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewPassTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            BackButton.Enabled = true;
            RemoveEmployee.Enabled = false;

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Chose to go Back/nYour Data Will not be Saved.", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NewPassTextBox.Visible = false;
            OldPassword.Text = EmployeeDL.CurrentUser.EmployeeData.Password;
            OldPassword.ReadOnly = true;
            RemoveEmployee.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Your New Editing is Saved.", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (isButtonClicked == false)
            {
                string c = takeInputForNewPass();
                bool valid = EmployeeDL.passwordcheck(c);
                if (valid == false)
                {
                    EmployeeDL.updateUserPass(EmployeeDL.CurrentUser, c);
                }
                else
                {
                    MessageBox.Show("Same Password");
                }
                NewPassTextBox.Visible = false;
                label5.Visible = false;
                label1.Visible = true;
                OldPassword.Visible = true;
                OldPassword.Text = EmployeeDL.CurrentUser.EmployeeData.Password;
                OldPassword.ReadOnly = true;
            }
            else if(isButtonClicked)
            {
                SetNull();
            }
            else
            {
                MessageBox.Show("NO");
            }
            BackButton.Enabled = false;
            SaveButton.Enabled = false;
            RemoveEmployee.Enabled = true;
            EditEmployee.Enabled = true;
            EmployeeDL.updatedata(ref path);
        }

        private void RemoveEmployee_Click(object sender, EventArgs e)
        {
            EditEmployee.Enabled = false;
            RemoveEmployee.Enabled = false;
            EmployeeDL.delete(EmployeeDL.CurrentUser.EmployeeData);
            isButtonClicked = true;
            SaveButton.Enabled = true;
            BackButton.Enabled = true;
        }

        private void UpdateAndDeleteByEmployee_Load(object sender, EventArgs e)
        {
            showData();
        }
    }
}
