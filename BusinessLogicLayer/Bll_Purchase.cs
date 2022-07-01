using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLogicLayer
{
    public class Bll_Purchase
    {
        public void Purchase(int _RegID ,int _EmpID ,int _CustomerID, string _Date, int _Amount)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_addpurchase", _RegID,_EmpID, _CustomerID, _Date,_Amount);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }
        public void UpdatePurchase(int _PurchaseID, int _RegID, int _EmpID, int _CustomerID, string _Date, int _Amount)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updatepurchase", _PurchaseID, _RegID, _EmpID, _CustomerID, _Date, _Amount); 
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void DeletePurchase(int _PurchaseID)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_deletepurchase", _PurchaseID);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();

        }

        public DataTable ShowallPurchases()
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_showallpurchases");
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }

        public DataTable CountPurchasedCar()
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_CountPurchasedCar");
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }
        public DataTable SelectPurchaseByID(int _PurchaseID)
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_selectpurchasebyid", _PurchaseID);
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }

        




    }
}

