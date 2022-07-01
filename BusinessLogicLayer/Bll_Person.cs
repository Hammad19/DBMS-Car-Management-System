using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public  class Bll_Person
    {

        //public void Register(string _Name, string _Gender, string _Address, string _Password, string _PhoneNo, string _Email, string _RegDate, int _AddedBy)
        //{

        //    DAL obj = new DAL();
        //    obj.OpenConnection();
        //    obj.LoadSpParameters("sp_insertemp", _Name, _Gender, _Address, _Password, _PhoneNo, _Email, _RegDate, _AddedBy);
        //    obj.ExecuteQuery();
        //    obj.UnLoadSpParameters();
        //    obj.CloseConnection();
        //}

        public void UpdateCustomer(string _ID, string _Fname, string _Lname, string _Gender, string _City, string _Country, string _PhoneNo, string _Email, string _DOB, string _Bal)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updateCust", _ID, _Fname, _Lname, _Gender, _City, _Country, _PhoneNo, _Email, _DOB, _Bal);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }


        public DataTable ShowDetailsForAdmin()
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectallCust");
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }
    }

    public class Bll_Admin
        {
        public  DataTable Login(int _ID)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectadmin", _ID);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }

    }

    public class Bll_Employee
    {
        public  DataTable Login(int _ID)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectemp", _ID);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }

        

        public  void Register(string _Name, char _Gender, string _Address, string _Password, string _PhoneNo, string _Email, string _RegDate, int _AddedBy)
        {

            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_insertemp", _Name, _Gender, _Address, _Password, _PhoneNo, _Email, _RegDate, _AddedBy);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void Update(int _ID ,string _Name, char _Gender, string _Address, string _Password, string _PhoneNo, string _Email, string _RegDate, int _AddedBy)
        {

            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updateemp",_ID, _Name, _Gender, _Address, _Password, _PhoneNo, _Email, _RegDate, _AddedBy);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void Delete(int _ID)
        {

            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_deleteemp", _ID);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public  DataTable ShowEmployee()
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectallemp");
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;

        }







    }

    public class Bll_Customer
    {

        public void Register(int _AddedBy, string _Name, char _Gender, string _Address, string _PhoneNo, string _cnic, string _Email, string _RegDate)
        {

            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_insertcustomer", _AddedBy, _Name, _Gender, _Address, _PhoneNo, _cnic, _Email, _RegDate);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void Update(int _ID, int _AddedBy, string _Name, char _Gender, string _Address, string _PhoneNo, string _cnic, string _Email, string _RegDate)
        {

            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updatecustomer", _ID, _AddedBy, _Name, _Gender, _Address, _PhoneNo, _cnic, _Email, _RegDate);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void Delete(int _ID)
        {

            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_deletecustomer", _ID);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public DataTable ShowCustomer()
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectallcustomer");
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;

        }

        public DataTable SelectCustomerByID(int _ID)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectcustomerbyid",_ID);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;

        }
    }


    public class Bll_Dealer
    {

        public void Register(string _Name, char _Gender, string _Address, string _PhoneNo, string _Email,string _CompanyName, string _RegDate, int _DealedBy)
        {

            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_insertdealer", _Name, _Gender, _Address, _PhoneNo, _Email,_CompanyName, _RegDate, _DealedBy);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void Update(int _ID,string _Name, char _Gender, string _Address, string _PhoneNo, string _Email, string _CompanyName, string _RegDate, int _DealedBy)
        {

            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updatedealer",_ID, _Name, _Gender, _Address, _PhoneNo, _Email, _CompanyName, _RegDate, _DealedBy);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void Delete(int _ID)
        {

            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_deletedealer", _ID);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public DataTable ShowDealer()
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectalldealer");
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;

        }







    }
}
