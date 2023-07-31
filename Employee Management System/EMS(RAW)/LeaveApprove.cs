using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_RAW_.BL;
using EMS_RAW_.DL;
using Guna.UI2.WinForms;

namespace EMS_RAW_
{
    public partial class LeaveApprove : UserControl
    {
        private static string path = "UserData.txt";
        public LeaveApprove()
        {
            InitializeComponent();
            SaveBttn.Enabled = false;
            guna2GradientCircleButton1.Enabled = false;
            guna2CustomCheckBox1.Visible = false;
            guna2CustomCheckBox2.Visible = false;
            label1.Visible = false;
        }

        private void LeaveApprove_Load(object sender, EventArgs e)
        {
            dataBind();
        }
        public void refresh()
        {

            dataBind();
        }
        private void dataBind()
        {
            DataTable.DataSource = null;        // Clear the DataTable to remove existing data
            foreach (var o in EmployeeDL.getList())
            {
                DataTable.DataSource = EmployeeDL.getList().Select(c => new { c.EmployeeData.Name, c.EmployeeData.Role, c.Leave.Reason1, c.Leave.Toleave, c.Leave.Fromleave, c.Leave.LeaveStatus1 }).ToList();
            }
            DataTable.Refresh();
        }

        private Credential takeInputForSignUp() // take input for Sign Up
        {
            string name = employeeName.Text;
            string password = EmployeePassword.Text;
            string Role = RoleEmployee.SelectedItem.ToString();
            Credential c = new Credential(name, password, Role);
            return c;
        }
        private void SearchEmployee_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.Enabled = false;
            Credential c = takeInputForSignUp();
            EmployeeBL emp = EmployeeDL.SignIn(c);
            if (emp != null)
            {
                if (guna2CustomCheckBox2.Checked == true)
                {
                    emp.Leave.LeaveStatus1 = "Approved";
                    emp.Leave.Leavecount = 2;
                    EmployeeDL.updatedata(ref path);
                    MessageBox.Show("Saved");
                    guna2CustomCheckBox1.Checked = false;
                    guna2CustomCheckBox2.Checked = false;
                }
                else if (guna2CustomCheckBox1.Checked == true)
                {
                    emp.Leave.LeaveStatus1 = "DisApproved";
                    emp.Leave.Leavecount = 2;
                    EmployeeDL.updatedata(ref path);
                    MessageBox.Show("Saved");
                    guna2CustomCheckBox1.Checked = false;
                    guna2CustomCheckBox2.Checked = false;
                }
                else if (guna2CustomCheckBox1.Checked == false && guna2CustomCheckBox2.Checked == false)
                {
                    errorProvider1.SetError(guna2CustomCheckBox1, "This checkbox cannot be left empty.");
                }
                else
                {
                    // Clear the error message since the CheckBox is checked
                    errorProvider1.Clear();
                }
                dataBind();
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            Credential c = takeInputForSignUp();
            EmployeeBL emp = EmployeeDL.SignIn(c);
            if (emp != null)
            {
                List<EmployeeBL> emp1 = new List<EmployeeBL>() { emp };

                DataTable.DataSource = null;        // Clear the DataTable to remove existing data
                DataTable.DataSource = emp1.Select(employee => new { emp.EmployeeData.Name, emp.EmployeeData.Role, emp.Leave.Reason1, emp.Leave.Toleave, emp.Leave.Fromleave, emp.Leave.LeaveStatus1 }).ToList();
                DataTable.Refresh();
                if (emp.Leave.LeaveStatus1 != null)
                {
                    SaveBttn.Enabled = true;
                    guna2CustomCheckBox1.Visible = true;
                    guna2CustomCheckBox2.Visible = true;
                    label1.Visible = true;
                    MessageBox.Show("You can Approve Or Disapprove the Leave.\n For Approving check the checkBox \n For disapproving Leave the check box unchecked", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SaveBttn.Enabled = false;
                    guna2CustomCheckBox1.Visible = false;
                    guna2CustomCheckBox2.Visible = false;
                    label1.Visible = false;
                    MessageBox.Show("The Leave is Already Noticed By the Admin", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("Incorect");
            }
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            SaveBttn.Enabled = false;
            guna2GradientCircleButton1.Enabled = false;
            guna2CustomCheckBox1.Visible = false;
            guna2CustomCheckBox2.Visible = false;
            label1.Visible = false;
        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RoleEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void adminCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void employeeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmployeePassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
