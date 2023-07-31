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
    public partial class fullStatus : UserControl
    {
        public fullStatus()
        {
            InitializeComponent();
        }
        private void fullStatus_Load(object sender, EventArgs e)
        {
           
        }
        public void refresh()
        {
            dataBind();
        }
        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataBind();
        }
        private void dataBind()
        {
            DataTable.DataSource = null; // Clear the DataTable to remove existing data
            foreach (var o in EmployeeDL.getList())
            {
                DataTable.DataSource = EmployeeDL.getList().Select(c => new { c.EmployeeData.Name, c.EmployeeData.Password, c.EmployeeData.Role, c.Departments, c.Ranks1, c.InternStatus , c.Attendence.Presents , c.Salarys1 }).ToList();
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

            Credential c = takeInputForSignUp();
            EmployeeBL emp = EmployeeDL.SignIn(c);
            if (emp != null)
            {
                List<EmployeeBL> emp1 = new List<EmployeeBL>() { emp };

                DataTable.DataSource = null;        // Clear the DataTable to remove existing data
                DataTable.DataSource = emp1.Select(employee => new { emp.EmployeeData.Name, emp.EmployeeData.Role, emp.EmployeeData.Password, emp.Departments, emp.Ranks1, emp.InternStatus }).ToList();
                DataTable.Refresh();

            }
        }
    }
}
