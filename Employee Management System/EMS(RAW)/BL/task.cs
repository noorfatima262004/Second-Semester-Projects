using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_RAW_.BL
{
    class task
    {
      
        private string taskname = "";
        private string AssignTasks = "";   // tell if the task is assigned or not
        private DateTime duration;
        private bool taskStatus;  // tell if the task is completed or not
        private string taskDoneTime = "";  // tells if task is done late or on time

        public task()
        {
        }

        public string Taskname 
        
        { get => taskname; 
            set => taskname = value;
        }
        public string AssignTasks1 { get => AssignTasks; set => AssignTasks = value; }
        public DateTime Duration { get => duration; set => duration = value; }
        public bool TaskStatus { get => taskStatus; set => taskStatus = value; }
        public string TaskDoneTime { get => taskDoneTime; set => taskDoneTime = value; }
        public task(string taskname, DateTime duration, string AssignTasks)
        {
            this.taskname = taskname;
            this.duration = duration;
            this.AssignTasks = AssignTasks;
        }
        public task( string AssignTasks)
        {
            this.AssignTasks = AssignTasks;
        }
        public task(string taskname, DateTime duration, string AssignTasks, bool taskstatus, string taskDoneTime)
        {
            this.taskname = taskname;
            this.duration = duration;
            this.AssignTasks = AssignTasks;
            this.taskStatus = taskstatus;
            this.taskDoneTime = taskDoneTime;
        }
    }
}
