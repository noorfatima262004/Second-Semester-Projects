using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_RAW_.BL;

namespace EMS_RAW_.BL
{
    class PaidIntern:internMainClass,InternInterface
    {
        private float salarys = 0F;
        public PaidIntern(string InternStatus, Credential employee, string departments) : base(InternStatus, employee, departments)
        {
        }
        public PaidIntern(Credential employee, Attendence attendece, RequestLeave Leave, string departments, string InterStatus, float salarys) : base(employee, departments, attendece, Leave, InterStatus)
        {
            this.salarys = salarys;
        }
        public override float Salarys1 { get =>  giveSalary(); set => salarys = value; }
        public override EmployeeBL Employee { get => e; set => e = value; }
        public override string InternStatus { get => internStatus; set => internStatus = value; }
        public override Credential EmployeeData { get => employeeData; set => employeeData = value; }
        public override Attendence Attendence { get => attendence; set => attendence = value; }
        public override RequestLeave Leave { get => leave; set => leave = value; }
        public override string Departments { get => departments; set => departments = value; }
        public override DateTime Tasktime { get => tasktime; set => tasktime = value; }
        public override List<task> Taskassigned { get => TaskAssigned; set => TaskAssigned = value; }
        public float giveSalary()
        {
            salarys = attendence.Presents * 3000;
            return salarys;
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
