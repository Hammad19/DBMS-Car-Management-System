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
    class Purchases
    {
        public Purchases()
        {

        }

        public Purchases(int _PurchaseID)
        {
            this.PurchaseID = _PurchaseID;

        }

        public Purchases(int _RegID, int _mployeeID, int _CustomerID, int _Amount, string _Date)
        {   
            this.CarRegID = _RegID;
            this.Date = _Date;
            this.EmployeeID = _mployeeID;
            this.CustomerID = _CustomerID;
            this.TotalAmount = _Amount;
        }

        public Purchases(int _PurchaseID, int _RegID, int _mployeeID,int _CustomerID, int _Amount, string _Date)
        {
            this.PurchaseID = _PurchaseID;
            this.CarRegID = _RegID;
            this.Date = _Date;
            this.EmployeeID = _mployeeID;
            this.CustomerID = _CustomerID;
            this.TotalAmount = _Amount;
        }
        public int PurchaseID  { get; set; }
        public int CarRegID { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public int TotalAmount { get; set; }

        public string Date { get; set; }


        public void Addpurchase()
        {
            Bll_Purchase c = new Bll_Purchase();
            DataTable mo = new DataTable();
            c.Purchase(CarRegID, EmployeeID, CustomerID, Date, TotalAmount);
            Bll_Car car = new Bll_Car();
            car.UpdateAvailability(CarRegID, "N");

        }

        public void UpdatePurchase()
        {
            Bll_Purchase c = new Bll_Purchase();
            

            DataTable mo = new DataTable();
            mo = c.SelectPurchaseByID(PurchaseID);
            int oldCarRegID = Convert.ToInt32(mo.Rows[0]["CarID"]);
            Bll_Car car = new Bll_Car();
            car.UpdateAvailability(oldCarRegID, "Y" );
            car.UpdateAvailability(CarRegID, "N");
            c.UpdatePurchase(PurchaseID, CarRegID, EmployeeID, CustomerID, Date, TotalAmount);

        }

        public void DeletePurchase()
        {
            Bll_Purchase c = new Bll_Purchase();
            Bll_Car car = new Bll_Car();
            DataTable mo = new DataTable();
            mo = c.SelectPurchaseByID(PurchaseID);
            CarRegID = Convert.ToInt32(mo.Rows[0]["CarID"]);
            car.UpdateAvailability(CarRegID, "Y");
            c.DeletePurchase(PurchaseID);

        }


        public void PurchaseHistory(DataGridView dgv)
        {

            dgv.Rows.Clear();
            Bll_Purchase c = new Bll_Purchase();
            DataTable dt = new DataTable();
            dt = c.ShowallPurchases();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(dt.Rows[i]["PurchaseID"].ToString(), dt.Rows[i]["CarID"], dt.Rows[i]["PurchaseAmount"].ToString(), dt.Rows[i]["DateOfPurchase"].ToString(), dt.Rows[i]["PurchasedBy"].ToString(), dt.Rows[i]["EmployeeID"].ToString());
            }

        }

        public int Countpurchase()
        {
  
            Bll_Purchase c = new Bll_Purchase();
            DataTable dt = new DataTable();
            dt = c.CountPurchasedCar();
            return dt.Rows.Count;

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
            dt = a.SelectAllCarIDforPurchases();
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
            int modelid =Convert.ToInt32(dt.Rows[0]["ModelID"]);
            int price = Convert.ToInt32(dt.Rows[0]["Price"]);
            dt = car.SelectModelByID(modelid);
            string description = dt.Rows[0]["ModelName"].ToString() +" " + dt.Rows[0]["ModelYear"];
            dgv.Rows.Add(description, price.ToString(), Convert.ToString(1), price.ToString());
            dt = cus.SelectCustomerByID(FormControls.CusID);
            name.Text = dt.Rows[0]["CustomerName"].ToString();
            address.Text = dt.Rows[0]["CustomerAddress"].ToString();
            dt = emp.Login(Convert.ToInt32(FormControls.ID));
            empname.Text = dt.Rows[0]["EmployeeName"].ToString();
            date.Text = date.Text + " " + FormControls.date;

        }
    }
}
