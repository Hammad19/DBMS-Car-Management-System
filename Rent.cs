using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using System.Windows.Forms;
using System.Data;
using Bunifu.UI.WinForms;

namespace AutoCarManagementSystem
{
    class Rent
    {
        public string NoOfDays { get; set; }
        public Rent()
        {

        }

        public Rent(int _PurchaseID)
        {
            this.RentID = _PurchaseID;

        }

        public Rent(int _RegID, int _mployeeID, int _CustomerID, int _Amount, string _Date,string _ReturnDate)
        {
            this.CarRegID = _RegID;
            this.Date = _Date;
            this.EmployeeID = _mployeeID;
            this.CustomerID = _CustomerID;
            this.TotalAmount = _Amount;
            this.ReturnDate = _ReturnDate;
        }

        public Rent(int _PurchaseID, int _RegID, int _mployeeID, int _CustomerID, int _Amount, string _Date,string _ReturnDate)
        {
            this.RentID = _PurchaseID;
            this.CarRegID = _RegID;
            this.Date = _Date;
            this.ReturnDate = _ReturnDate;
            this.EmployeeID = _mployeeID;
            this.CustomerID = _CustomerID;
            this.TotalAmount = _Amount;
        }
        public int RentID { get; set; }
        public int CarRegID { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public int TotalAmount { get; set; }

        public string Date { get; set; }

        public string ReturnDate { get; set; }


        public void AddRent(string noofdays)
        {
            Bll_Rent c = new Bll_Rent();
            Bll_Car car = new Bll_Car();
            TotalAmount = GetTotalAmount(noofdays);
            c.Rent(CarRegID, EmployeeID, CustomerID, Date, ReturnDate, TotalAmount);
            car.UpdateAvailability(CarRegID, "N");

        }

        public int GetTotalAmount(string noofdays)
        {
            Bll_Car car = new Bll_Car();
            DataTable mo = new DataTable();
            mo = car.SelectCarByID(FormControls.CarRegID);
            int pperday = Convert.ToInt32(mo.Rows[0]["PricePerDay"].ToString());
            return pperday * Convert.ToInt32(noofdays); ;
        }



        public void UpdateRent()
        {
            Bll_Rent c = new Bll_Rent();
            DataTable mo = new DataTable();
            mo = c.SelectPurchaseByID(RentID);
            int oldCarRegID = Convert.ToInt32(mo.Rows[0]["CarID"]);
            Bll_Car car = new Bll_Car();
            car.UpdateAvailability(oldCarRegID, "Y");
            car.UpdateAvailability(CarRegID, "N");
            c.UpdateRent(RentID, CarRegID, EmployeeID, CustomerID, Date,ReturnDate, TotalAmount);

        }

        public void DeleteRent()
        {
            Bll_Rent c = new Bll_Rent();
            Bll_Car car = new Bll_Car();
            DataTable mo = new DataTable();
            mo = c.SelectPurchaseByID(RentID);
            CarRegID = Convert.ToInt32(mo.Rows[0]["CarID"]);
            car.UpdateAvailability(CarRegID, "Y");
            c.DeleteRent(RentID);

        }


        public void RentHistory(DataGridView dgv)
        {

            dgv.Rows.Clear();
            Bll_Rent c = new Bll_Rent();
            DataTable dt = new DataTable();
            dt = c.ShowallRent();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(dt.Rows[i]["RentID"].ToString(), dt.Rows[i]["CarID"], dt.Rows[i]["TotalAmount"].ToString(), dt.Rows[i]["DateOfPurchase"].ToString(), dt.Rows[i]["DateOfReturn"].ToString(), dt.Rows[i]["RentedBy"].ToString(), dt.Rows[i]["EmployeeID"].ToString());
            }

        }

        public int CountRent()
        {

            Bll_Rent c = new Bll_Rent();
            DataTable dt = new DataTable();
            dt = c.CountRentedCar();
            return Convert.ToInt32(dt.Rows[0]["Tot_RentCars"].ToString());

        }


        public void ShowCustomerincbx(ComboBox cbx)
        {
            cbx.Items.Clear();
            Bll_Customer a = new Bll_Customer();
            DataTable dt = new DataTable();
            dt = a.ShowCustomer();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbx.Items.Add(dt.Rows[i]["CustomerID"].ToString());
            }
        }

        public void ShowCarIDincbx(ComboBox cbx)
        {
            cbx.Items.Clear();
            Bll_Car a = new Bll_Car();
            DataTable dt = new DataTable();
            dt = a.SelectAllCarIDforRent();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbx.Items.Add(dt.Rows[i]["CarRegID"].ToString());
            }
        }

        public void GenerateInvoice(BunifuLabel name, BunifuLabel date, BunifuLabel address, BunifuLabel empname, DataGridView dgv)
        {
            Bll_Car car = new Bll_Car();
            Bll_Customer cus = new Bll_Customer();
            Bll_Employee emp = new Bll_Employee();
            DataTable dt = new DataTable();
            dt = car.SelectCarByID(FormControls.CarRegID);
            int modelid = Convert.ToInt32(dt.Rows[0]["ModelID"]);
            int price = Convert.ToInt32(dt.Rows[0]["PricePerDay"]); 
            dt = car.SelectModelByID(modelid);
            string description = dt.Rows[0]["ModelName"].ToString() +" "+ dt.Rows[0]["ModelYear"];
            dgv.Rows.Add(description, price.ToString(), FormControls.noofdays.ToString(), GetTotalAmount(FormControls.noofdays.ToString()));
            dt = cus.SelectCustomerByID(FormControls.CusID);
            name.Text = dt.Rows[0]["CustomerName"].ToString();
            address.Text = dt.Rows[0]["CustomerAddress"].ToString();
            dt = emp.Login(Convert.ToInt32(FormControls.ID));
            empname.Text = dt.Rows[0]["EmployeeName"].ToString();
            date.Text = date.Text + " " + FormControls.date;

        }


    }
}
