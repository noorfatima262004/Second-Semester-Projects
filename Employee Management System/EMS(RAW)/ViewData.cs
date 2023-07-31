using EMS_RAW_.BL;
using EMS_RAW_.DL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace EMS_RAW_
{
    partial class ViewData : UserControl
    {
        private static ViewData instance;
        public static ViewData Instance
        {
            get
            {
                if (instance == null)
                    instance = new ViewData();
                return instance;
            }

        }
        public ViewData()
        {
            InitializeComponent();
            labelRank.Visible = false;
            labelInternStatus.Visible = false;
            Intern.Visible = false;
            guna2TextBox1.Visible = false;
            showData();
        }
        public void SetNull()
        {
            EmployeeName.Text = null;
            Password.Text = null;
            Dept.Text = null;
            Role.Text = null;
            guna2TextBox1.Text = null;
            Intern.Text = null;
        }
        public void showData()
        {
            EmployeeName.ReadOnly = true;
            Password.ReadOnly = true;
            Role.ReadOnly = true;
            Dept.ReadOnly = true;
            Intern.ReadOnly = true;
            guna2TextBox1.ReadOnly = true;
            EmployeeName.Text = EmployeeDL.CurrentUser.EmployeeData.Name;
            Password.Text = EmployeeDL.CurrentUser.EmployeeData.Password;
            Dept.Text = EmployeeDL.CurrentUser.Departments;
            Role.Text = EmployeeDL.CurrentUser.EmployeeData.Role;
            if (Role.Text == "TeamLeader")
            {
                guna2TextBox1.Visible = true;
                labelRank.Visible = true;
                guna2TextBox1.Text = EmployeeDL.CurrentUser.Ranks1;
            }
            else if (Role.Text == "Intern")
            {
                Intern.Visible = true;
                labelInternStatus.Visible = true;
                Intern.Text = EmployeeDL.CurrentUser.InternStatus;
            }
        }

        private void ViewData_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void AdminSignUpPannel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
