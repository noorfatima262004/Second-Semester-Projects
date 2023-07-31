using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_RAW_.BL;

namespace EMS_RAW_.BL
{
    class TeamLeader:EmployeeBL
    {
        private string Ranks = null;
        private string promote = "not promoted";
        private float salarys = 0F;

        public TeamLeader()
        {
        }

        public TeamLeader(Credential employeeData) : base(employeeData)
        {
        }
        public TeamLeader(string Ranks, Credential employee, string departments) : base(employee, departments)
        {
            this.Ranks = Ranks;
        }
        public TeamLeader(Credential employee, Attendence attendece, RequestLeave Leave, string departments, string promote, string Ranks, float salarys) : base(employee, attendece, Leave, departments)
        {
            this.promote = promote;
            this.Ranks = Ranks;
            this.salarys = salarys;
        }
    
        public override void addinlist(task t)
        {
            TaskAssigned.Add(t);
        }
        public override string getTaskName(int x)
        {
            return TaskAssigned[x].Taskname;
        }
        public override void setBoolOfTaskStatus(int x, bool t)
        {
            this.TaskAssigned[x].TaskStatus = t;
        }
        public override bool getTaskStatus(int x)
        {
            return TaskAssigned[x].TaskStatus;
        }
        public override string getTaskDone(int x)
        {
            return TaskAssigned[x].TaskDoneTime;
        }
        public override void setTaskDoneTime(int x, string t)
        {
            this.TaskAssigned[x].TaskDoneTime = t;
        }
        public override DateTime getTaskTime(int x)
        {
            return TaskAssigned[x].Duration;
        }
        public override string getTaskAssign(int x)
        {
            return TaskAssigned[x].AssignTasks1;
        }
        public override void settask(task t)
        {
            this.TaskAssigned.Add(t);
        }
        public override List<task> getlist()
        {
            return TaskAssigned;
        }
        public override string Ranks1 { get => Ranks; set => Ranks = value; }
        public override string Promote { get => promote; set => promote = value; }
        public override float Salarys1 { get => salarys; set => salarys = value; }

        public override float GiveSalary(EmployeeBL u)
        {
            int Rank = Convert.ToInt32(u.Ranks1);

            if (Rank >= 8 && Rank < 12)
            {
                salarys = u.Attendence.Presents * 8000;
            }
            if (Rank >= 12 && Rank < 19)
            {
                salarys = u.Attendence.Presents * 8000;
            }
            if (Rank >= 19 && Rank < 25)
            {
                salarys = attendence.Days_Of_Month * 10000;
            }
            System.Windows.Forms.MessageBox.Show(salarys.ToString());
            return salarys;
        }
    }
}
