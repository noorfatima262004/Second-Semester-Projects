using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_RAW_.BL;
using System.IO;

namespace EMS_RAW_.DL
{
    class AdminDL
    {
        public static List<AdminBL> ad = new List<AdminBL>();
        public static void storeDataInList(AdminBL c)
        {
            ad.Add(c);
        }
        public static int getcount()
        {
            int num = ad.Count;
            return num;
        }
        public static bool admincheck(Credential u)
        {
            foreach (AdminBL storeduser in ad)
            {
                if  (u.Name  == storeduser.AdminData.Name || u.Password == storeduser.AdminData.Password)
                {
                    return true;
                }
            }
            return false;
        }
        public static AdminBL signIn(Credential u)
        {
            foreach (AdminBL storeduser in ad)
            {
                if (u.Name == storeduser.AdminData.Name && u.Password == storeduser.AdminData.Password)
                {
                    return storeduser;
                }
            }

            return null;
        }
        public static bool readData(ref string adpath)

        {
            if (File.Exists(adpath))
            {
                StreamReader fileVariable = new StreamReader(adpath);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string[] temp = record.Split(',');
                    Credential s = new Credential(temp[0], temp[1], temp[2]);
                    AdminBL ad = new AdminBL(s);
                    storeDataInList(ad);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        
        public static void savedataAdmin(ref string path, AdminBL ad)
        {
            StreamWriter file = new StreamWriter(path, true);

            file.WriteLine(ad.AdminData.Name + "," + ad.AdminData.Password + "," + ad.AdminData.Role);
            file.Flush();
            file.Close();
        }
        public static void updataAdmin(ref string Adpath)
        {
            StreamWriter file = new StreamWriter(Adpath, false);
            for (int x = 0; x < ad.Count; x++)
            {
                file.WriteLine(ad[x].AdminData.Name + "," + ad[x].AdminData.Password + "," + ad[x].AdminData.Role);
            }
            file.Flush();
            file.Close();
        }
        public static void updateAP(AdminBL u, string newpass)
        {
            for (int x = 0; x < ad.Count; x++)
            {
                if (ad[x].AdminData.Password == u.AdminData.Password)
                {
                    ad[x].AdminData.Password = newpass;
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }
    }
}
