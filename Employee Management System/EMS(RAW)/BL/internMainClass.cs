using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_RAW_.BL;

namespace EMS_RAW_.BL
{
    class internMainClass:EmployeeBL
    {
        protected string internStatus;

        public internMainClass()
        {
        }

        public internMainClass(Credential employeeData) : base(employeeData)
        {
        }
        public internMainClass(string InternStatus, Credential employee, string departments) : base(employee, departments)
        {
            this.InternStatus = InternStatus;
        }
        public internMainClass(Credential employee, string departments, Attendence attendece, RequestLeave Leave, string InternStatus) : base(employee, attendece, Leave, departments)
        {
            this.InternStatus = InternStatus;
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
        public override void settask(task t)
        {
           this.TaskAssigned.Add(t);
        }
        public override DateTime getTaskTime(int x)
        {
            return TaskAssigned[x].Duration;
        }
        public override string getTaskAssign(int x)
        {
            return TaskAssigned[x].AssignTasks1;
        }

        public override List<task> getlist()
        {
            return TaskAssigned;
        }
        public override string InternStatus { get => internStatus; set => internStatus = value; }
    }
}
