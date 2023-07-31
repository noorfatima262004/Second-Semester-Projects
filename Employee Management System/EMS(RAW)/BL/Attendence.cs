using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_RAW_.BL;
using Guna.UI2.WinForms;

namespace EMS_RAW_.BL
{
    class Attendence
    {
        private int presents = 0;
        private int DaysOfMonth;
        private string AttendeneOfOneDay;
        public Attendence(int presents, int DaysOfMonth, string attendeneOfOneDay)
        {
            this.Presents = presents;
            this.DaysOfMonth = DaysOfMonth;
            AttendeneOfOneDay = attendeneOfOneDay;
        }
        public Attendence(int absents)
        {
            this.DaysOfMonth = absents;
        }
        public Attendence()
        {

        }
        public string today_Attendence { get => AttendeneOfOneDay; set => AttendeneOfOneDay = value; }
        public int Presents { get => presents; set => presents = value; }
        public int Days_Of_Month { get => DaysOfMonth; set => DaysOfMonth = value; }
    }
}
