using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS_RAW_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            customizeDesign();
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            main1.Visible = true;
        }

        private void customizeDesign()
        {
            EmployeeInfoPannel.Visible = false;
            TaskPannel.Visible = false;
            LeavePannel.Visible = false;
        }
        private void HideSubMenu()
        {
            if (EmployeeInfoPannel.Visible == true)
                EmployeeInfoPannel.Visible = false;
            if (TaskPannel.Visible == true)
                TaskPannel.Visible = false;
            if (LeavePannel.Visible == true)
                LeavePannel.Visible = false;
        }
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        // Employee Info Sub Menu
        private void EmployeeInfoButton_Click(object sender, EventArgs e)
        {
           
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            if (addEmployee1.Visible == false || deleteEmployee1.Visible == false || viewEmployee1.Visible == false|| updateEmployee1.Visible == false)
            {
                main1.Visible = true;
            }
            if (addEmployee1.Visible == true || deleteEmployee1.Visible == true || viewEmployee1.Visible == true || updateEmployee1.Visible == true)
            {
                main1.Visible = false;
            }
            ShowSubMenu(EmployeeInfoPannel);
        }
        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            addEmployee1.refresh();
            // Show the user control
            addEmployee1.Visible = true;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            main1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            HideSubMenu();
        }
        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            viewEmployee1.refresh();
            addEmployee1.Visible = false;
            viewEmployee1.Visible = true;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            main1.Visible = false;
            HideSubMenu();

        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = true;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            main1.Visible = false;
            assignTask1.Visible = false;

            HideSubMenu();

        }
        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = true;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            main1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            HideSubMenu();

        }

        // attnendence Button
        private void AttendenceButton_Click(object sender, EventArgs e)
        {
            attendence1.refresh();
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = true;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
                main1.Visible = false;
            HideSubMenu();
        }

        // Task Buttone Pannel
        private void TaskButton_Click(object sender, EventArgs e)
        {
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
           if( assignTask1.Visible !=true || seePerformance1.Visible != true)
            {
                main1.Visible = true;
            }
            if (assignTask1.Visible == true || seePerformance1.Visible == true)
            {
                main1.Visible = false;
            }
            ShowSubMenu(TaskPannel);
        }
        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            assignTask1.refresh();
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            main1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = true;
            HideSubMenu();
        }
        private void guna2GradientButton24_Click(object sender, EventArgs e)
        {
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            main1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = true;
            assignTask1.Visible = false;
            HideSubMenu();
        }

        // Leave Pannel
        private void LeaveButton_Click(object sender, EventArgs e)
        {
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            if (leaveApprove1.Visible != true || leaveControl1.Visible != true)
            {

                main1.Visible = true;
            }
            if (leaveApprove1.Visible == true || leaveControl1.Visible == true)
            
                    {
                main1.Visible = false;
            }
            ShowSubMenu(LeavePannel);
        }
        private void guna2GradientButton27_Click(object sender, EventArgs e)
        {
            leaveControl1.refresh();
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            main1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = true;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            //HideSubMenu();
        }
        private void guna2GradientButton28_Click(object sender, EventArgs e)
        {
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = true;
            leaveControl1.Visible = false;
            main1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            HideSubMenu();
        }

        // Pay Button
        private void PayButton_Click(object sender, EventArgs e)
        {
            pay1.refresh();
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = true;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            main1.Visible = false;

            HideSubMenu();

        }

        // full statuss view button
        private void StatusButton_Click(object sender, EventArgs e)
        {
            fullStatus1.refresh();
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = true;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            main1.Visible = false;

            HideSubMenu();
        }
        
        // Logout Button  
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            addEmployee1.Visible = false;
            viewEmployee1.Visible = false;
            deleteEmployee1.Visible = false;
            updateEmployee1.Visible = false;
            fullStatus1.Visible = false;
            pay1.Visible = false;
            attendence1.Visible = false;
            leaveApprove1.Visible = false;
            leaveControl1.Visible = false;
            seePerformance1.Visible = false;
            assignTask1.Visible = false;
            main1.Visible = true;
            MessageBox.Show("You Will be Going To Sign In Page" , "Message Box with Icon" ,  MessageBoxButtons.OK , MessageBoxIcon.Information);
            this.Hide();
            Form1 f = new Form1();
            f.Show();
            HideSubMenu();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateEmployee1_Load(object sender, EventArgs e)
        {

        }
    }
}
