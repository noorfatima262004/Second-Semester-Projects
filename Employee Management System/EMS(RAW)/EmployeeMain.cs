using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS_RAW_
{
    public partial class EmployeeMain : UserControl
    {
        private static EmployeeMain instance;
        public static EmployeeMain Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeMain();
                    return instance;
            }


        }
        public EmployeeMain()
        {
            InitializeComponent();
        }
    }
}
