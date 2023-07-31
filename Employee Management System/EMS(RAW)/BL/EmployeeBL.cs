using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_RAW_.BL
{
    class EmployeeBL
    {
        protected Credential employeeData = new Credential();
        protected Attendence attendence = new Attendence();
        protected RequestLeave leave = new RequestLeave();
        protected string departments;
        protected int count = 0;
        protected EmployeeBL e;
        protected DateTime tasktime;
        protected List<task> TaskAssigned = new List<task>();   

        public virtual EmployeeBL Employee { get => e; set => e = value; }
        public virtual Credential EmployeeData { get => employeeData; set => employeeData = value; }
        public virtual Attendence Attendence { get => attendence; set => attendence = value; }
        public virtual RequestLeave Leave { get => leave; set => leave = value; }
        public   virtual string Departments { get => departments; set => departments = value; }
        public virtual DateTime Tasktime { get => tasktime; set => tasktime = value; }
        public virtual List<task> Taskassigned { get => TaskAssigned; set => TaskAssigned = value; }
        public virtual float Salarys1 { get ; set  ; }
        public virtual string Ranks1 { get ; set ; }
        public virtual string Promote { get ; set ; }
        public virtual string InternStatus { get ; set ; }
        protected EmployeeBL E { get => e; set => e = value; }

        public virtual float GiveSalary(EmployeeBL u)
        {
            return 0F;
        }
        public virtual void addinlist(task t)
        {
            TaskAssigned.Add(t);
        }
        public virtual string getTaskName(int x)
        {
            return TaskAssigned[x].Taskname;
        }
        public virtual void setBoolOfTaskStatus(int x, bool t)
        {
            this.TaskAssigned[x].TaskStatus = t;
        }
        public virtual bool getTaskStatus(int x)
        {
            return TaskAssigned[x].TaskStatus;
        }
        public virtual string getTaskDone(int x)
        {
            return TaskAssigned[x].TaskDoneTime;
        }
        public virtual void setTaskDoneTime(int x, string t)
        {
            this.TaskAssigned[x].TaskDoneTime = t;
        }
        public virtual DateTime getTaskTime(int x)
        {
            return TaskAssigned[x].Duration;
        }
        public virtual string getTaskAssign(int x) => TaskAssigned[x].AssignTasks1;
        public virtual void settask(task t) => TaskAssigned.Add(t);
        public virtual List<task> getlist()
        {
            return TaskAssigned;
        }
        public EmployeeBL()
        {

        }
        public EmployeeBL(Credential employeeData)
        {
            this.employeeData = employeeData;
        }
        public EmployeeBL(Credential employeeData, string departments)
        {
            this.employeeData = employeeData;
            this.departments = departments;
        }
        public EmployeeBL(Credential employeeData, Attendence attendence, RequestLeave Leave, string departments)
        {
            this.employeeData = employeeData;
            this.departments = departments;
            this.Leave = Leave;
            this.attendence = attendence;
        }



    }
}
