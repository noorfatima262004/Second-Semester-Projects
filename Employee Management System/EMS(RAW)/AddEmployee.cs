using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_RAW_.BL;
using EMS_RAW_.DL;
using EMS_RAW_.UI;

namespace EMS_RAW_
{
    public partial class AddEmployee : UserControl
    {
        string path = "UserData.txt";
        public AddEmployee()
        {
            InitializeComponent();
            Intern.Visible = false;
            Rank.Visible = false;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {


        }
        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch2.Checked == true)
            {
                EmployeePassword.UseSystemPasswordChar = false;
            }
            if (guna2ToggleSwitch2.Checked == false)
            {
                EmployeePassword.UseSystemPasswordChar = true;
            }
        }

        private Credential takeInputForSignUp() // take input for Sign Up
        {
            string name = employeeName.Text;
            string password = EmployeePassword.Text;
            string Role = RoleEmployee.SelectedItem.ToString();
            Credential c = new Credential(name, password, Role);
            return c;
        }
        private void restPannels() // reset  form
        {
            employeeCheckBox.Checked = false;
            employeeName.Text = null;
            EmployeePassword.Text = null;
            RoleEmployee.Text = null;
            Intern.Text = null;
            Dept.Text = null;
        }
        private EmployeeBL furtherInput(Credential c)
        {
            string department = Dept.Text;
            bool valid = EmployeeDL.UserCheck(c);
            bool valid1 = AdminDL.admincheck(c);
            if (valid == false && valid1 == false)
            {
                if (RoleEmployee.SelectedItem.ToString().ToLower() != "intern")
                {
                    string rank = Rank.SelectedItem.ToString();
                    TeamLeader t = new TeamLeader(rank, c, department);
                    return t;
                }
                else
                {
                    string internRole = Intern.SelectedItem.ToString();
                    if (Intern.SelectedItem.ToString().ToLower() == "paidintern")
                    {
                        PaidIntern p = new PaidIntern(internRole, c, department);
                        return p;
                    }
                    else
                    {
                        UnpaidIntern unp = new UnpaidIntern(c, internRole, department);
                        return unp;
                    }
                }
            }
            else
            {
                MessageBox.Show("Account Already Exited");
            }
            return null;
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void RoleOfEmployeeCheck()
        {
            if (RoleEmployee.SelectedItem.ToString().ToLower() == "intern")
            {
                Rank.Visible = false;
                Intern.Visible = true;
            }
            else
            {
                Rank.Visible = true;
                Intern.Visible = false;
            }
        }
        private bool validationaForAdminSignUpEmty() //  valiadation for empty at sign up form
        {
            if (string.IsNullOrEmpty(employeeName.Text.Trim()))
            {
                errorProvider1.SetError(employeeName, "User name is required");
                return false;
            }
            else
            {
                errorProvider4.SetError(employeeName, string.Empty);
            }
            if (string.IsNullOrEmpty(EmployeePassword.Text.Trim()))
            {
                errorProvider5.SetError(EmployeePassword, "Role is required");
                return false;
            }
            else
            {
                errorProvider5.SetError(EmployeePassword, string.Empty);
            }
            if (string.IsNullOrEmpty(RoleEmployee.Text.Trim()))
            {
                errorProvider6.SetError(RoleEmployee, "Password is required");
                return false;
            }
            else
            {
                errorProvider6.SetError(RoleEmployee, string.Empty);
            }
            if (string.IsNullOrEmpty(Dept.Text.Trim()))
            {
                errorProvider6.SetError(Dept, "Password is required");
                return false;
            }
            else
            {
                errorProvider6.SetError(Dept, string.Empty);
            }
            if (string.IsNullOrEmpty(Rank.Text.Trim()))
            {
                errorProvider6.SetError(Rank, "Password is required");
                return false;
            }
            else
            {
                errorProvider6.SetError(Rank, string.Empty);
            }
            if (string.IsNullOrEmpty(Intern.Text.Trim()))
            {
                errorProvider6.SetError(Intern, "Password is required");
                return false;
            }
            else
            {
                errorProvider6.SetError(Intern, string.Empty);
            }
            if (employeeCheckBox.Checked == false)
            {
                errorProvider7.SetError(employeeCheckBox, "Agreeing to all is necessary");
                return false;
            }
            else
            {
                errorProvider7.SetError(employeeCheckBox, string.Empty);
            }
            return true;
        }
        private void SignUpEmployee_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            int totalDaysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
         
            if (validationaForAdminSignUpEmty() == true)
            {

                Credential c = takeInputForSignUp();
                EmployeeBL emp = furtherInput(c);
                if (emp != null)
                {
                    emp.Attendence.Days_Of_Month = totalDaysInMonth;
                    EmployeeDL.addinlist(emp);
                    EmployeeDL.savedata(ref path, emp);
                    MessageBox.Show("Added");
                    dataBind();
                    // restPannels();
                }
                else
                {
                    MessageBox.Show("Alreay Have account");
                }
            }
        }

        private void RoleEmployee_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            RoleOfEmployeeCheck();
        }
        private void dataBind()
        {
            DataTable.DataSource = null; // Clear the DataTable to remove existing data
            foreach (var o in EmployeeDL.getList())
            {
                DataTable.DataSource = EmployeeDL.getList().Select(c => new { c.EmployeeData.Name, c.EmployeeData.Password, c.EmployeeData.Role, c.Departments, c.Ranks1, c.InternStatus }).ToList();
            }
            DataTable.Refresh();

        }
        public void refresh()
        {
            dataBind();
        }
        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataTable.Columns["Update"].Index)
            {
                /*MUser usr = dataGridView1.CurrentRow.DataBoundItem as MUser;
                MessageBox.Show(usr.Surname.Name);*/
                Credential c = new Credential();
                // manual values getting
                int rowIndex = e.RowIndex;
                int usernameIndex = DataTable.Columns["Name"].Index;
                int passwordIndex = DataTable.Columns["Password"].Index;
                int roleIndex = DataTable.Columns["Role"].Index;
                int deptIndex = DataTable.Columns["Department"].Index;
                int internTypeIndex = DataTable.Columns["InternStatus"].Index;
                int RankIndex = DataTable.Columns["Rank1"].Index;

                // getting the values
                string Name = DataTable[usernameIndex, rowIndex].Value.ToString();
                string Password = DataTable[passwordIndex, rowIndex].Value.ToString();
                string Role = DataTable[roleIndex, rowIndex].Value.ToString();
                string departments = DataTable[deptIndex, rowIndex].Value.ToString();
                if (c.Role.ToLower() != "intern")
                {
                    string Rank1 = DataTable[RankIndex, rowIndex].Value.ToString();
                }
                else if (c.Role.ToLower() == "intern")
                {
                    string interStatus = DataTable[internTypeIndex, rowIndex].Value.ToString();
                }

            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

