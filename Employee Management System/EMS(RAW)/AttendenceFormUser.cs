using EMS_RAW_.BL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS_RAW_
{
    public partial class AttendenceFormUser : UserControl
    {
        private static AttendenceFormUser instance;
        private static string path = "Userdata.txt";
        public static AttendenceFormUser Instance
        {
            get
            {
                if (instance == null)
                    instance = new AttendenceFormUser();
                return instance;
            }


        }
        public AttendenceFormUser()
        {
            InitializeComponent();
            showData();
        }
        public void showData()
        {

            EmployeeName.ReadOnly = true;
            Role.ReadOnly = true;
            guna2DateTimePicker1.Refresh();
            EmployeeName.Text = EmployeeDL.CurrentUser.EmployeeData.Name;
            Role.Text = EmployeeDL.CurrentUser.EmployeeData.Role;
        }
        private void EmployeeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void PresentCheckBox_Click(object sender, EventArgs e)
        {

        }

        private void datelabel_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {


            DateTime selectedDate = guna2DateTimePicker1.Value;

            // Get the date after changing the month by one day
            DateTime nextDay = selectedDate.AddDays(1);

            if (selectedDate.Day == 1 && nextDay.Day == 2)
            {
                EmployeeDL.CurrentUser.Attendence.Presents = 0;

                // to get total days in the month
                DateTime selectedDate1 = guna2DateTimePicker1.Value;
                int totalDaysInMonth = DateTime.DaysInMonth(selectedDate1.Year, selectedDate1.Month);

                EmployeeDL.CurrentUser.Attendence.Days_Of_Month = totalDaysInMonth;
            }
        }
        private void SearchEmployee_Click(object sender, EventArgs e)
        {
            TimeSpan comparisonTime = new TimeSpan(9, 0, 0); // 9:00 AM
            DateTime selectedDate1 = guna2DateTimePicker1.Value;

            if (guna2CustomCheckBox1.Checked == true)
            {
                if (guna2DateTimePicker1.Value.TimeOfDay < comparisonTime)
                {
                    MessageBox.Show("You Are Late/n The time for Coming in Department is 9", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmployeeDL.CurrentUser.Attendence.Presents = EmployeeDL.CurrentUser.Attendence.Presents + 1;
                    EmployeeDL.CurrentUser.Attendence.today_Attendence = "Late";
                }
                else
                {
                    MessageBox.Show("You Are On TIme.", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmployeeDL.CurrentUser.Attendence.Presents = EmployeeDL.CurrentUser.Attendence.Presents + 1;
                    EmployeeDL.CurrentUser.Attendence.today_Attendence = "On Time";
                }
                EmployeeDL.CurrentUser.Attendence.Days_Of_Month = EmployeeDL.CurrentUser.Attendence.Days_Of_Month - 1;
                guna2CustomCheckBox1.Checked = true;
                guna2CustomCheckBox1.Enabled = false;
                SearchEmployee.Enabled = false;
            }
            if (!guna2CustomCheckBox1.Checked)
            {
                // Set the error message using the ErrorProvider
                errorProvider1.SetError(guna2CustomCheckBox1, "This checkbox cannot be left empty.");
            }
            else
            {
                // Clear the error message since the CheckBox is checked
                errorProvider1.Clear();
            }
            EmployeeDL.updatedata(ref path);
        }

        private void AttendenceFormUser_Load(object sender, EventArgs e)
        {
            if (EmployeeDL.CurrentUser.Attendence.today_Attendence == "Present")
            {
                SearchEmployee.Enabled = false;
                guna2CustomCheckBox1.Checked = true;
                guna2CustomCheckBox1.Enabled = false;
                MessageBox.Show("You attendence is Already Marked", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
