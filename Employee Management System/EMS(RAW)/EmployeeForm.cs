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
using EMS_RAW_.BL;
using EMS_RAW_.DL;

namespace EMS_RAW_
{
    public partial class EmployeeForm : Form
    {

        public EmployeeForm()
        {
            InitializeComponent();

            panel1.Controls.Add(EmployeeMain.Instance);

            ViewData.Instance.Visible = false;
            employeeFullStatus.Instance.Visible = false;
            LeaveByEmployee.Instance.Visible = false;
            UpdateAndDeleteByEmployee.Instance.Visible = false;
            TaskOfEmployee.Instance.Visible = false;
            SeePay.Instance.Visible = false;
            AttendenceFormUser.Instance.Visible = false;
            EmployeeMain.Instance.Visible = true;


        }
        private void guna2ControlBox5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void EmployeeInfoButton_Click(object sender, EventArgs e)
        {
            ViewData.Instance.SetNull();
            ViewData.Instance.Refresh();
            panel1.Controls.Add(ViewData.Instance);
            ViewData.Instance.Visible = true;
            employeeFullStatus.Instance.Visible = false;
            LeaveByEmployee.Instance.Visible = false;
            UpdateAndDeleteByEmployee.Instance.Visible = false;
            TaskOfEmployee.Instance.Visible = false;
            SeePay.Instance.Visible = false;
            AttendenceFormUser.Instance.Visible = false;
            EmployeeMain.Instance.Visible = false;

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateAndDeleteByEmployee.Instance.SetNull();
            UpdateAndDeleteByEmployee.Instance.Refresh();
            panel1.Controls.Add(UpdateAndDeleteByEmployee.Instance);
            ViewData.Instance.Visible = false;
            employeeFullStatus.Instance.Visible = false;
            LeaveByEmployee.Instance.Visible = false;
            UpdateAndDeleteByEmployee.Instance.Visible = true;
            TaskOfEmployee.Instance.Visible = false;
            SeePay.Instance.Visible = false;
            AttendenceFormUser.Instance.Visible = false;
            EmployeeMain.Instance.Visible = false;
        }

        private void AttendenceButton_Click(object sender, EventArgs e)
        {

            panel1.Controls.Add(AttendenceFormUser.Instance);
            ViewData.Instance.Visible = false;
            employeeFullStatus.Instance.Visible = false;
            LeaveByEmployee.Instance.Visible = false;
            UpdateAndDeleteByEmployee.Instance.Visible = false;
            TaskOfEmployee.Instance.Visible = false;
            SeePay.Instance.Visible = false;
            AttendenceFormUser.Instance.Visible = true;
            EmployeeMain.Instance.Visible = false;
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            SeePay.Instance.Refresh();
            panel1.Controls.Add(SeePay.Instance);
            SeePay.Instance.SetNull();
            ViewData.Instance.Visible = false;
            employeeFullStatus.Instance.Visible = false;
            LeaveByEmployee.Instance.Visible = false;
            UpdateAndDeleteByEmployee.Instance.Visible = false;
            TaskOfEmployee.Instance.Visible = false;
            SeePay.Instance.Visible = true;
            AttendenceFormUser.Instance.Visible = false;
            EmployeeMain.Instance.Visible = false;
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {

            panel1.Controls.Add(LeaveByEmployee.Instance);
            ViewData.Instance.Visible = false;
            employeeFullStatus.Instance.Visible = false;
            LeaveByEmployee.Instance.Visible = true;
            UpdateAndDeleteByEmployee.Instance.Visible = false;
            TaskOfEmployee.Instance.Visible = false;
            SeePay.Instance.Visible = false;
            AttendenceFormUser.Instance.Visible = false;
            EmployeeMain.Instance.Visible = false;

        }

        private void TaskButton_Click(object sender, EventArgs e)
        {
            TaskOfEmployee.Instance.refresh();
            panel1.Controls.Add(TaskOfEmployee.Instance);
            ViewData.Instance.Visible = false;
            LeaveByEmployee.Instance.Visible = false;
            employeeFullStatus.Instance.Visible = false;
            UpdateAndDeleteByEmployee.Instance.Visible = false;
            TaskOfEmployee.Instance.Visible = true;
            SeePay.Instance.Visible = false;
            AttendenceFormUser.Instance.Visible = false;
            EmployeeMain.Instance.Visible = false;
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(employeeFullStatus.Instance);
            ViewData.Instance.Visible = false;
            employeeFullStatus.Instance.Visible = true;
            LeaveByEmployee.Instance.Visible = false;
            UpdateAndDeleteByEmployee.Instance.Visible = false;
            TaskOfEmployee.Instance.Visible = false;
            SeePay.Instance.Visible = false;
            AttendenceFormUser.Instance.Visible = false;
            EmployeeMain.Instance.Visible = false;
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {

            ViewData.Instance.Visible = false;
            employeeFullStatus.Instance.Visible = false;
            LeaveByEmployee.Instance.Visible = false;
            UpdateAndDeleteByEmployee.Instance.Visible = false;
            TaskOfEmployee.Instance.Visible = false;
            SeePay.Instance.Visible = false;
            AttendenceFormUser.Instance.Visible = false;
            EmployeeMain.Instance.Visible = true;
            MessageBox.Show("You Will be Going To Sign In Page", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void guna2ControlBox6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
