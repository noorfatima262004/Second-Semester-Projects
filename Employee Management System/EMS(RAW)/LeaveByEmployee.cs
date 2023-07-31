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
using EMS_RAW_.BL;
using System.IO;

namespace EMS_RAW_
{
    public partial class LeaveByEmployee : UserControl
    {
        private static string path = "UserData.txt";
        private static LeaveByEmployee instance;
        public static LeaveByEmployee Instance
        {
            get
            {
                if (instance == null)
                    instance = new LeaveByEmployee();
                return instance;
            }


        }
        public LeaveByEmployee()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LeaveByEmployee_Load(object sender, EventArgs e)
        {
            showData();
        }
        public void showData()
        {
            guna2TextBox1.ReadOnly = true;
            if ( EmployeeDL.CurrentUser.Leave.Leavecount == 2)
            {
                label7.Visible = true;
                guna2TextBox1.Visible = true;
                guna2TextBox1.ReadOnly = true;
                guna2TextBox2.ReadOnly = true;
                Status.Enabled = true;
                Apply.Enabled = false;
            }
            else
            {
                Status.Enabled = false;
                label7.Visible = false;
                guna2TextBox1.Visible = false;
            }
            Name.Text = EmployeeDL.CurrentUser.EmployeeData.Name;
            Password.Text = EmployeeDL.CurrentUser.EmployeeData.Password;
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            if (EmployeeDL.CurrentUser.Leave.Leavecount == 0)
            {
                DateTime to = guna2DateTimePicker1.Value;
                DateTime from = guna2DateTimePicker2.Value;
                string reason = guna2TextBox2.Text;
                EmployeeDL.CurrentUser.Leave.Reason1 = reason;
                EmployeeDL.CurrentUser.Leave.Toleave = to.ToString();
                EmployeeDL.CurrentUser.Leave.Fromleave = from.ToString();
                EmployeeDL.CurrentUser.Leave.Leavecount = 1;
                EmployeeDL.updatedata(ref path);
            }
            else
            {

            MessageBox.Show("You have Already Appliead");

            }
        }

        private void Status_Click(object sender, EventArgs e)
        {
            
            guna2TextBox1.Text = EmployeeDL.CurrentUser.Leave.LeaveStatus1;
            guna2TextBox2.Text = EmployeeDL.CurrentUser.Leave.Reason1;
            guna2DateTimePicker1.Text = EmployeeDL.CurrentUser.Leave.Toleave.ToString();    
            guna2DateTimePicker2.Text = EmployeeDL.CurrentUser.Leave.Fromleave.ToString();
            EmployeeDL.CurrentUser.Leave.Leavecount = 0;
            EmployeeDL.CurrentUser.Leave.LeaveStatus1 = null;
            EmployeeDL.updatedata(ref path);    
        }
    }
}
