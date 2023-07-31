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

namespace EMS_RAW_
{
    public partial class DeleteEmployee : UserControl
    {
        string path = "UserData.txt";
        public DeleteEmployee()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        private void DeleteEmployee_Load(object sender, EventArgs e)
        {
            dataBind();
            SearchEmployee.Enabled = false;
        }
        private Credential takeInputForSignUp() // take input for Sign Up
        {
            string name = employeeName.Text;
            string password = EmployeePassword.Text;
            string Role = RoleEmployee.SelectedItem.ToString();
            Credential c = new Credential(name, password, Role);
            return c;
        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataTable.Columns["Update"].Index)
            {

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
        private void dataBind()
        {
            DataTable.DataSource = null;   // Clear the DataTable to remove existing data
            foreach (var o in EmployeeDL.getList())
            {
                DataTable.DataSource = EmployeeDL.getList().Select(c => new { c.EmployeeData.Name, c.EmployeeData.Password, c.EmployeeData.Role, c.Departments, c.Ranks1, c.InternStatus }).ToList();
            }
            DataTable.Refresh();
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            Credential c = takeInputForSignUp();

            EmployeeBL emp = EmployeeDL.SignIn(c);
            if (emp != null)
            {
                List<EmployeeBL> emp1 = new List<EmployeeBL>() { emp };

                DataTable.DataSource = null;        // Clear the DataTable to remove existing data
                DataTable.DataSource = emp1.Select(employee => new { emp.EmployeeData.Name, emp.EmployeeData.Role, emp.EmployeeData.Password, emp.Departments, emp.Ranks1, emp.InternStatus }).ToList();
                DataTable.Refresh();

            }
            if (emp != null)
            {
                SearchEmployee.Enabled = true;  
                EmployeeDL.delete(c);
                MessageBox.Show("Press Save to Delete", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                MessageBox.Show("Incorrect");
            }
        }

        private void SearchEmployee_Click(object sender, EventArgs e)
        {
            EmployeeDL.updatedata(ref path);
            MessageBox.Show("The Employee is deleted", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            dataBind();
        }
    }
}
