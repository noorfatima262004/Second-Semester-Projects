using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_RAW_.BL;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace EMS_RAW_
{
    class EmployeeDL
    {
        public static List<EmployeeBL> employee = new List<EmployeeBL>();
        static EmployeeBL currentUser;

        public static EmployeeBL CurrentUser { get => currentUser; set => currentUser = value; }

        public static void addinlist(EmployeeBL e)
        {
            employee.Add(e);
        }
        public static List<EmployeeBL> getList()
        {
            return employee;
        }
        public static EmployeeBL SignIn(Credential u)
        {
            foreach (EmployeeBL storeduser in employee)
            {
                if (u.Name == storeduser.EmployeeData.Name && u.Password == storeduser.EmployeeData.Password)
                {
                    return storeduser;
                    //currentUser = storeduser;
                }
            }
            return null;
        }
        public static bool UserCheck(Credential u)
        {
            foreach (EmployeeBL storeduser in employee)
            {
                if (u.Name == storeduser.EmployeeData.Name || u.Password == storeduser.EmployeeData.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool passwordcheck(string p)
        {
            foreach (EmployeeBL storeduser in employee)
            {
                if (storeduser.EmployeeData.Password == p)
                {

                    return true;

                }
            }
            return false;
        }
        public static void savedata(ref string path1, EmployeeBL e)
        {
            StreamWriter file = new StreamWriter(path1, true);

            if (e.EmployeeData.Role.ToLower() != "intern")
            {
                file.Write(e.EmployeeData.Name + "," + e.EmployeeData.Password + "," + e.EmployeeData.Role + "," + e.Attendence.Presents + "," +e.Attendence.Days_Of_Month + "," + e.Attendence.today_Attendence + "," + e.Leave.Reason1 + "," + e.Leave.Time + "," + e.Leave.Leavetrue + "," + e.Leave.LeaveStatus1 + "," + e.Leave.Leavecount + "," + e.Leave.Fromleave + "," + e.Leave.Toleave + "," + e.Departments + "," + e.Promote + "," + e.Ranks1 + "," + e.Salarys1 + ",");
            }
            else if (e.InternStatus.ToLower() == "paidintern" && e.EmployeeData.Role.ToLower() == "intern")
            {
                file.Write(e.EmployeeData.Name + "," + e.EmployeeData.Password + "," + e.EmployeeData.Role + "," + e.Attendence.Presents + "," + e.Attendence.Days_Of_Month + "," + e.Attendence.today_Attendence  + "," + e.Leave.Reason1 + "," + e.Leave.Time + "," + e.Leave.Leavetrue + "," + e.Leave.LeaveStatus1 + "," + e.Leave.Leavecount + "," + e.Leave.Fromleave + "," + e.Leave.Toleave + "," + e.Departments + "," + e.InternStatus + "," + e.Salarys1 + ",");
            }
            else if (e.EmployeeData.Role.ToLower() == "intern" && e.InternStatus.ToLower() == "unpaidintern")
            {
                file.Write(e.EmployeeData.Name + "," + e.EmployeeData.Password + "," + e.EmployeeData.Role + "," + e.Attendence.Presents + "," + e.Attendence.Days_Of_Month + "," + e.Attendence.today_Attendence + "," + e.Leave.Reason1 + "," + e.Leave.Time + "," + e.Leave.Leavetrue + "," + e.Leave.LeaveStatus1 + "," + e.Leave.Leavecount + "," + e.Leave.Fromleave + "," + e.Leave.Toleave + "," + e.Departments + "," + e.InternStatus + ",");
            }
            if (e.getlist().Count != 0)
            {
                for (int x = 0; x < e.getlist().Count; x++)
                {
                    file.Write(e.getTaskName(x) + ";" + e.getTaskTime(x) + ";" + e.getTaskAssign(x) + ";" + e.getTaskStatus(x) + ";" + e.getTaskDone(x) + ";");
                }
            }
            file.WriteLine();
            file.Flush();
            file.Close();
        }
        public static void updatedata(ref string path1)
        {
            StreamWriter file = new StreamWriter(path1, false);
            foreach (EmployeeBL e in employee)
            {
                if (e.EmployeeData.Role.ToLower() != "intern")
                {
                    file.Write(e.EmployeeData.Name + "," + e.EmployeeData.Password + "," + e.EmployeeData.Role + "," + e.Attendence.Presents + "," + e.Attendence.Days_Of_Month + "," + e.Attendence.today_Attendence + "," + e.Leave.Reason1 + "," + e.Leave.Time + "," + e.Leave.Leavetrue + "," + e.Leave.LeaveStatus1 + "," + e.Leave.Leavecount + "," + e.Leave.Fromleave + "," + e.Leave.Toleave + "," + e.Departments + "," + e.Promote + "," + e.Ranks1 + "," + e.Salarys1 + ",");
                }
                else if (e.InternStatus.ToLower() == "paidintern" && e.EmployeeData.Role.ToLower() == "intern")
                {
                    file.Write(e.EmployeeData.Name + "," + e.EmployeeData.Password + "," + e.EmployeeData.Role + "," + e.Attendence.Presents + "," + e.Attendence.Days_Of_Month + "," + e.Attendence.today_Attendence + "," + e.Leave.Reason1 + "," + e.Leave.Time + "," + e.Leave.Leavetrue + "," + e.Leave.LeaveStatus1 + "," + e.Leave.Leavecount + "," + e.Leave.Fromleave + "," + e.Leave.Toleave + "," + e.Departments + "," + e.InternStatus + "," + e.Salarys1 + ",");
                }
                else if (e.EmployeeData.Role.ToLower() == "intern" && e.InternStatus.ToLower() == "unpaidintern")
                {
                    file.Write(e.EmployeeData.Name + "," + e.EmployeeData.Password + "," + e.EmployeeData.Role + "," + e.Attendence.Presents + "," + e.Attendence.Days_Of_Month + "," + e.Attendence.today_Attendence + "," + e.Leave.Reason1 + "," + e.Leave.Time + "," + e.Leave.Leavetrue + "," + e.Leave.LeaveStatus1 + "," + e.Leave.Leavecount + "," + e.Leave.Fromleave + "," + e.Leave.Toleave + "," + e.Departments + "," + e.InternStatus + ",");
                }
                if (e.getlist().Count != 0)
                {
                    for (int x = 0; x < e.getlist().Count; x++)
                    {
                        file.Write(e.getTaskName(x) + ";" + e.getTaskTime(x) + ";" + e.getTaskAssign(x) + ";" + e.getTaskStatus(x) + ";" + e.getTaskDone(x) + ";");
                    }
                }
                file.WriteLine();
            }
            file.Flush();
            file.Close();
        }
        public static bool loaddata(ref string path1)
        {

            if (File.Exists(path1) == true)
            {
                StreamReader filevariable = new StreamReader(path1);
                string record;
                while ((record = filevariable.ReadLine()) != null)
                {
                    string[] temp = record.Split(',');
                    EmployeeBL u = new EmployeeBL();
                    Credential s = new Credential(temp[0], temp[1], temp[2]);
                    RequestLeave r = new RequestLeave(temp[6], temp[7], bool.Parse(temp[8].Trim()), temp[9], Convert.ToInt32(temp[10]), temp[11], temp[12]);
                    Attendence at = new Attendence(Convert.ToInt32(temp[3]), Convert.ToInt32(temp[4]) , temp[5]);
                    if (s.Role.ToLower() == "teamleader")
                    {
                        TeamLeader tl = new TeamLeader(s, at, r, temp[13], temp[14], temp[15], Convert.ToInt32(temp[16]));
                        string[] temp1 = temp[17].Split(';');
                        for (int x = 0; x < temp1.Length - 1; x += 5)
                        { 
                            task t1 = new task(temp1[x], DateTime.Parse(temp1[x + 1].Trim()), temp1[x + 2], bool.Parse(temp1[x + 3]), temp1[x + 4]);
                            u.addinlist(t1);
                            System.Windows.Forms.MessageBox.Show(u.Taskassigned.Count.ToString()+"pppppp");
                        }
                        addinlist(tl);
                       
                    }
                    else if (temp[14].ToLower() == "paidintern")
                    {
                        PaidIntern p = new PaidIntern(s, at, r, temp[13], temp[14], Convert.ToInt32(temp[15]));
                        string[] temp1 = temp[16].Split(';');
                        for (int x = 0; x < temp1.Length - 1; x += 5)
                        {
                            task t1 = new task(temp1[x], DateTime.Parse(temp1[x + 1]), temp1[x + 2], bool.Parse(temp1[x + 3]), temp1[x + 4]);
                            u.addinlist(t1);
                            System.Windows.Forms.MessageBox.Show(u.Taskassigned.Count.ToString());
                        }
                        addinlist(p);
                    }

                    else if (temp[14].ToLower() == "unpaidintern")
                    {
                        UnpaidIntern unp = new UnpaidIntern(s, at, r, temp[13], temp[14]);
                        string[] temp1 = temp[1].Split(';');
                        for (int x = 0; x < temp1.Length - 1; x += 5)
                        {
                            task t1 = new task(temp1[x], DateTime.Parse(temp1[x + 1]), temp1[x + 2], bool.Parse(temp1[x + 3]), temp1[x + 4]);
                            u.addinlist(t1);
                        }
                        addinlist(unp);
                    }

                }
                filevariable.Close();
                return true;
            }
            else
            {
                Console.WriteLine("File Not found");
            }
            return false;

        }
        public static void delete(Credential u)
        {
            for (int x = 0; x < employee.Count; x++)
            {
                if (employee[x].EmployeeData.Name == u.Name && employee[x].EmployeeData.Password == u.Password)
                {
                    employee.RemoveAt(x);
                }

            }
        }
        public static void updateUserPass(EmployeeBL u, string newpass)
        {
            for (int x = 0; x < employee.Count; x++)
            {
                if (employee[x].EmployeeData.Password == u.EmployeeData.Password)
                {
                    employee[x].EmployeeData.Password = newpass;
                  
                }
            }
        }

    }
}

