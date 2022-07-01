using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarManagementSystem
{
    public class FormControls
    {
        private static string username, id;
        public static string ispurchased = "No";
        public static string adminlogin = "no";
        public static string date = "no";
        public static int PurchaseID = 0;
        public static int CusID = 0;
        public static int CarRegID = 0;
        public static int noofdays = 0;


        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        public static string ID
        {
            get { return id; }
            set { id = value; }
        }


    }
}
