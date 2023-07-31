using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace EMS_RAW_
{
    public partial class employeeFullStatus : UserControl
    {
        private static employeeFullStatus instance;
        public static employeeFullStatus Instance
        {
            get
            {
                if (instance == null)
                    instance = new employeeFullStatus();
                return instance;
            }


        }
        public employeeFullStatus()
        {
            InitializeComponent();
            //labelRank.Visible = false;
            //labelInternStatus.Visible = false;
            //InternS.Visible = false;
            //.Visible = false;
            showData();
        }
        public void SetNull()
        {
            //EmployeeName.Text = null;
            //Password.Text = null;
            //Dept.Text = null;
            //Role.Text = null;
            //guna2TextBox1.Text = null;
            //Intern.Text = null;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void employeeFullStatus_Load(object sender, EventArgs e)
        {

        }
        public void showData()
        {
            EmployeeName.ReadOnly = true;
            role.ReadOnly = true;
            InternS.ReadOnly = true;
            Pass.ReadOnly = true;
            EmployeeName.ReadOnly = true;
            salary.ReadOnly = true;
            dept.ReadOnly = true;
            Attend.ReadOnly = true; 
            EmployeeName.Text = EmployeeDL.CurrentUser.EmployeeData.Name;
            role.Text = EmployeeDL.CurrentUser.EmployeeData.Role;
            Pass.Text = EmployeeDL.CurrentUser.EmployeeData.Password;
            InternS.Text = EmployeeDL.CurrentUser.InternStatus;
            Attend.Text = EmployeeDL.CurrentUser.Attendence.Presents.ToString();  
            if (role.Text == "TeamLeader")
            {
                salary.Visible = true;
                InternS.Visible = false;
                RankT.Visible = true;
                RankT.Text = EmployeeDL.CurrentUser.Ranks1.ToString();
                salary.Text = EmployeeDL.CurrentUser.Salarys1.ToString();
            }
            else if (role.Text == "Intern")
            {
                InternS.Visible = true; 
                RankT.Visible = false;  
                salary.Visible = false;
                InternS.Text = EmployeeDL.CurrentUser.InternStatus;
                if(InternS.Text == "PaidIntern")
                {
                    salary.Visible = true;
                    salary.Text = EmployeeDL.CurrentUser.Salarys1.ToString();
                }
            }
        }

        private void AdminSignUpPannel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
