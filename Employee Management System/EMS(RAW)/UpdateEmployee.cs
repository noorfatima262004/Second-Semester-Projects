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
    public partial class UpdateEmployee : UserControl
    {
        string path = "UserData.txt";
        public UpdateEmployee()
        {
            InitializeComponent();
            SaveEmployee.Visible = false;
            guna2TextBox1.Enabled = false;

        }

        private void SearchEmployee_Click(object sender, EventArgs e)
        {
            Credential c = takeInputForSignUp();
            EmployeeBL emp = EmployeeDL.SignIn(c);
            if (emp != null)
            {
                string pass = guna2TextBox1.Text;
                EmployeeDL.updateUserPass(emp, pass);
                MessageBox.Show("Click save to Store your Data.");
                EmployeeDL.updatedata(ref path);
                dataBind();
            }
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            dataBind();
        }


        private Credential takeInputForSignUp() // take input for Sign Up
        {
            string name = employeeName.Text;
            string password = EmployeePassword.Text;
            string Role = RoleEmployee.SelectedItem.ToString();
            Credential c = new Credential(name, password, Role);
            return c;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Update Your password");
                guna2TextBox1.Enabled = true;
                EmployeePassword.Enabled = false;

                guna2GradientButton1.Visible = false;
                SaveEmployee.Visible = true;
            }
            else
            {
                MessageBox.Show("Incorrect");
            }
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

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
