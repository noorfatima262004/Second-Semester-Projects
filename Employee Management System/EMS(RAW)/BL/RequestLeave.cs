using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_RAW_.BL
{
    class RequestLeave
    {

        private string time = null;
        private string Reason = null;
        private bool leavetrue = false;
        private string LeaveStatus = null;
        private int leavecount = 0;
        private string fromleave = null;
        private string toleave = null;

        public RequestLeave()
        {
        }
        public RequestLeave( string Reason, string toleave , string fromleave)
        {
            this.toleave = toleave;
            this.fromleave = fromleave;
            this.Reason = Reason;
        }
        public RequestLeave(string time, string Reason, bool leavetrue, string status, int leavecount, string fromleave, string toleave)
        {
            this.time = time;
            this.Reason = Reason;
            this.leavetrue = leavetrue;
            this.LeaveStatus = status;
            this.leavecount = leavecount;
            this.fromleave = fromleave;
            this.toleave = toleave;
        }
        public string Time { get => time; set => time = value; }
        public string Reason1 { get => Reason; set => Reason = value; }
        public bool Leavetrue { get => leavetrue; set => leavetrue = value; }
        public string LeaveStatus1 { get => LeaveStatus; set => LeaveStatus = value; }
        public int Leavecount { get => leavecount; set => leavecount = value; }
        public string Fromleave { get => fromleave; set => fromleave = value; }
        public string Toleave { get => toleave; set => toleave = value; }
    }
}
