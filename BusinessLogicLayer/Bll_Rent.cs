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
    public class Bll_Rent
    {
        public void Rent(int _RegID ,int _EmpID ,int _CustomerID, string _Date,string _RetDate, int _Amount)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_addrent", _RegID,_EmpID, _CustomerID, _Date, _RetDate, _Amount);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }
        public void UpdateRent(int _RentID, int _RegID, int _EmpID, int _CustomerID, string _Date,string _RetDate, int _Amount)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updaterent", _RentID, _RegID, _EmpID, _CustomerID, _Date, _RetDate, _Amount); 
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void DeleteRent(int _RentID)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_deleterent", _RentID);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();

        }

        public DataTable ShowallRent()
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_showallrent");
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }

        public DataTable CountRentedCar()
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_CountRentedCar");
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }
        public DataTable SelectPurchaseByID(int _RentID)
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_selectrentbyid", _RentID);
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }

        




    }
}

