using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_RAW_.UI
{
    class validation
    {
        public static bool checkname(string name)
        {
            if (name.Length >= 5 && System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }
        public static bool checkpassword(string password)
        {
            if (password.Length >= 8 && System.Text.RegularExpressions.Regex.IsMatch(password, @"^[a-zA-Z1-9@#$%^&*]+$"))
            {
                return true;
            }
            return false;
        }
        public static string checkroleuser(string role)
        {
            if (role.ToLower() == "supervisor")
            {
                return "sp";
            }
            else if (role.ToLower() == "teamleader")
            {
                return "tl";
            }
            else if (role.ToLower() == "intern")
            {
                return "in";
            }
            return null;
        }
        public static string CheckIntershipStatus(string intenn)
        {
            if (intenn.ToLower() == "paid")
            {
                return "p";
            }
            if (intenn.ToLower() == "unpaid")
            {
                return "unp";
            }

            return null;
        }
        public static bool checkroleadmin(string role)
        {
            if (role.ToLower() == "admin")
            {
                return true;
            }
            return false;
        }
        public static bool checkDepatment(string dept)
        {
            if (dept.Length >= 5 && System.Text.RegularExpressions.Regex.IsMatch(dept, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }
        public static bool check_rank(string rank)
        {

            if (rank.Length <= 2)
            {
                int numericRank;
                if (int.TryParse(rank, out numericRank))
                {
                    if (numericRank > 8 && numericRank < 25)
                    {
                        return true;
                    }
                }
            }

            return false;

        }
        public static string promotestatus(string option)
        {
            if (option.ToLower() == "not promoted")
            {
                return "np";
            }
            else if (option.ToLower() == "promoted")
            {
                return "p";
            }
            return null;
        }
        public static bool checkLeave(string l)
        {
            if (l.Length >= 5 && System.Text.RegularExpressions.Regex.IsMatch(l, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }
        public static bool timecheck(string time)
        {
            if (time.Length <= 2 && System.Text.RegularExpressions.Regex.IsMatch(time, @"^[1-9]+$"))
            {
                return true;
            }
            return false;

        }
        public static string leavestatus(string option)
        {
            if (option.ToLower() == "approved")
            {
                return "ap";
            }
            else if (option.ToLower() == "not approved")
            {
                return "np";
            }
            return null;
        }
        public static bool taskcheck(string time)
        {
            if (time.Length >= 7 && System.Text.RegularExpressions.Regex.IsMatch(time, @"^[a-zA-Z1-9]+$"))
            {
                return true;
            }
            return false;

        }
    }
}

