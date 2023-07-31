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
using Guna.UI2.WinForms;

namespace EMS_RAW_
{
    public partial class AttendenceForm : UserControl
    {
        public AttendenceForm()
        {
            InitializeComponent();
        }

        private void Attendence_Load(object sender, EventArgs e)
        {

        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void refresh()
        {

            dataBind();
        }
        private void dataBind()
        {
            DataTable.DataSource = null; // Clear the DataTable to remove existing data
            foreach (var o in EmployeeDL.getList())
            {
                DataTable.DataSource = EmployeeDL.getList().Select(c => new { c.EmployeeData.Name, c.EmployeeData.Role, c.Departments, c.Attendence.Presents, c.Attendence.Days_Of_Month, c.Attendence.today_Attendence }).ToList();

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
                DataTable.DataSource = emp1.Select(employee => new { emp.EmployeeData.Name, emp.EmployeeData.Role, emp.Leave.Reason1, emp.Leave.Toleave, emp.Leave.Fromleave, emp.Leave.LeaveStatus1 }).ToList();
                DataTable.Refresh();
            }
            else
            {
                MessageBox.Show("Incrrect");
            }
        }
    }

}

