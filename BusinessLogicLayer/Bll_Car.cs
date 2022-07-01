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
    public class Bll_Car
    {
        public void AddCar(int _RegisteredBy, int _TakenFrom ,string _CarDesc, string _Cond, int _MakeID, int _PPerDay, int _Price,string _RegDate, string availability)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_addcar", _RegisteredBy,_TakenFrom, _CarDesc, _Cond, _MakeID, _PPerDay,_Price,_RegDate,availability);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }
        public void UpdateCar(int _RegID ,int _RegisteredBy, int _TakenFrom, string _CarDesc, string _Cond, int _MakeID, int _PPerDay, int _Price, string _RegDate, string availability)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updatecar",_RegID, _RegisteredBy, _TakenFrom, _CarDesc, _Cond, _MakeID, _PPerDay, _Price, _RegDate, availability);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void AddMake(string _Brand)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_addmake", _Brand);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();

        }
        public void AddModel(string _Name,int _MID,int _Year)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_addmodel", _Name,_MID,_Year);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();

        }

      

        public void UpdateAvailability(int _ID, string _Availability)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updatecaravailability", _ID, _Availability);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }


        public void DeleteCar( int _RegID)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_deletecar", _RegID);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }


        public DataTable ShowAllCars()
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_showallcars");
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;   
        }


        public DataTable ShowAvailableCars()
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_showavailablecars");
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }

        public DataTable SelectAllMakeNames()
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectallmakename");
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }

        public DataTable SelectAllModel()
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectallmodel");
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }

        public DataTable SelectModelByName(string _ModelName)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectmodelbyname",_ModelName);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }

        public DataTable SelectMake(string _MakeName)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectamake",_MakeName);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }


        public DataTable SelectModel(string _ModelName,int _ModelYear)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectmodel", _ModelName,_ModelYear);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }


        public DataTable UpdateMake(int _MakeID,string _MakeName)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updatemake", _MakeID, _MakeName);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }


        public DataTable SelectAllCarIDforPurchases()
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_selectallcarsforpurchase");
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }

        public DataTable SelectAllCarIDforRent()
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_selectallcarsforrent");
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }

        public DataTable SelectCarByID(int _CarID)
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_selectcarbyID", _CarID);
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }

        public DataTable SelectModelByID(int _ModelID)
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_selectmodelbyID", _ModelID);
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;
        }
    }
}

