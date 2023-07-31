using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_RAW_.BL;

namespace EMS_RAW_.BL
{
    class UnpaidIntern : internMainClass
    {
      
        public UnpaidIntern() : base()
        {

        }
        public UnpaidIntern(Credential employee, Attendence attendece, RequestLeave Leave, string departments, string InterStatus) : base(employee, departments, attendece, Leave, InterStatus)
        {

        }
        public UnpaidIntern(Credential employee, string InternStatus, string departments) : base(InternStatus, employee, departments)
        {
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
        public override void settask(task t)
        {
            this.TaskAssigned.Add(t);
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

        public override List<task> getlist()
        {
            return TaskAssigned;
        }
        public override string InternStatus { get => internStatus; set => internStatus = value; }
       public override Credential EmployeeData { get => employeeData; set => employeeData = value; }
        public override EmployeeBL Employee { get => e; set => e = value; }
        public override Attendence Attendence { get => attendence; set => attendence = value; }
        public override RequestLeave Leave { get => leave; set => leave = value; }
        public override string Departments { get => departments; set => departments = value; }
        public override DateTime Tasktime { get => tasktime; set => tasktime = value; }
        public override List<task> Taskassigned { get => TaskAssigned; set => TaskAssigned = value; }

    }
}
