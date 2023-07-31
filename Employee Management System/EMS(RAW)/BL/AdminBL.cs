using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_RAW_.BL
{
    class AdminBL
    {
        private Credential adminData;
        internal Credential AdminData { get => adminData; set => adminData = value; }
        public AdminBL()
        {

        }
        public AdminBL(Credential adminData)
        {
            this.adminData = adminData;
        }
    }
}
