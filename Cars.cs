using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using System.Windows.Forms;
using System.Data;

namespace AutoCarManagementSystem
{
    class cars
    {
        public cars()
        {

        }

        public cars(int Carid)
        {
           
        
                this.CarRegID = Carid;
            
       

        }
        public cars(int RegBy, int TakenFrom, int ModelYear, string ModelName, int Price, string CarDesc, string CarAvailability, string RegistrationDate, string MakeName, string CarCondition)
        {
            
           
                this.RegisteredBy = RegBy;
                this.TakenFrom = TakenFrom;
                this.MakeName = MakeName;
                this.ModelName = ModelName;
                this.ModelYear = ModelYear;
                this.PricePerDay = Convert.ToDouble(Price) * 0.002;
                this.Price = Price;
                this.CarDescription = CarDesc;
                this.CarAvailability = CarAvailability;
                this.RegistrationDate = RegistrationDate;
                this.CarCondition = CarCondition;
            

        }

        public cars(int regid, int RegBy, int TakenFrom, int ModelYear, string ModelName, int Price, string CarDesc, string CarAvailability, string RegistrationDate, string MakeName, string CarCondition)
        {
            this.CarRegID = regid;
            this.RegisteredBy = RegBy;
            this.TakenFrom = TakenFrom;
            this.MakeName = MakeName;
            this.ModelName = ModelName;
            this.ModelYear = ModelYear;
            this.PricePerDay = Convert.ToDouble(Price) * 0.002;
            this.Price = Price;
            this.CarDescription = CarDesc;
            this.CarAvailability = CarAvailability;
            this.RegistrationDate = RegistrationDate;
            this.CarCondition = CarCondition;
        }
        public int CarRegID { get; set; }
        public int RegisteredBy { get; set; }
        public int TakenFrom { get; set; }
        //not sure now either use make id or makename
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public int ModelID { get; set; }
        public int ModelYear { get; set; }
        public string ModelName { get; set; }
        public double PricePerDay { get; set; }
        public int Price { get; set; }
        public string CarDescription { get; set; }
        public string CarCondition { get; set; }

        public string RegistrationDate { get; set; }
        public string CarAvailability { get; set; }


        public void Register()
        {
            Bll_Car c = new Bll_Car();
            DataTable mo = new DataTable();
            mo = c.SelectModel(ModelName, ModelYear);
            ModelID = Convert.ToInt32(mo.Rows[0]["ModelID"]);
            c.AddCar(RegisteredBy, TakenFrom, CarDescription, CarCondition, ModelID, Convert.ToInt32(PricePerDay), Price, RegistrationDate, CarAvailability);


        }

        public void Update()
        {
            Bll_Car c = new Bll_Car();
            DataTable mo = new DataTable();
            mo = c.SelectModel(ModelName, ModelYear);
            ModelID = Convert.ToInt32(mo.Rows[0]["ModelID"]);
            c.UpdateCar(CarRegID, RegisteredBy, TakenFrom, CarDescription, CarCondition, ModelID, Convert.ToInt32(PricePerDay), Price, RegistrationDate, CarAvailability);


        }

        public void Delete()
        {
            Bll_Car c = new Bll_Car();
            c.DeleteCar(CarRegID);

        }

        public void RegMake(string _makename)
        {
            Bll_Car c = new Bll_Car();
            c.AddMake(_makename);
        }

        public void RegModel(string _modeln, string _makename, int modelyear)
        {
            Bll_Car c = new Bll_Car();
            DataTable ma = new DataTable();
            DataTable mo = new DataTable();
            ma = c.SelectMake(_makename);
            MakeID = Convert.ToInt32(ma.Rows[0]["MakeID"]);
            c.AddModel(_modeln, MakeID, modelyear);
        }

        public void ShowMakeincbx(ComboBox cbx)
        {
            cbx.Items.Clear();
            Bll_Car a = new Bll_Car();
            DataTable dt = new DataTable();
            dt = a.SelectAllMakeNames();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbx.Items.Add(dt.Rows[i]["MakeName"].ToString());
            }
        }

        public void ShowModelincbx(ComboBox cbx)
        {
            cbx.Items.Clear();
            Bll_Car a = new Bll_Car();
            DataTable dt = new DataTable();
            dt = a.SelectAllModel();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (!cbx.Items.Contains(dt.Rows[i]["ModelName"].ToString()))
                {
                    cbx.Items.Add(dt.Rows[i]["ModelName"].ToString());
                }

            }

        }
        public void ShowModelyearincbx(ComboBox cbx, string _modelName)
        {
            cbx.Items.Clear();
            Bll_Car a = new Bll_Car();
            DataTable dt = new DataTable();
            dt = a.SelectModelByName(_modelName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbx.Items.Add(dt.Rows[i]["ModelYear"].ToString());
            }
        }
        public void ShowDealerincbx(ComboBox cbx)
        {
            cbx.Items.Clear();
            Bll_Dealer a = new Bll_Dealer();
            DataTable dt = new DataTable();
            dt = a.ShowDealer();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbx.Items.Add(dt.Rows[i]["DealerID"].ToString());
            }

        }

        public void CarsHistory(DataGridView dgv)
        {

            dgv.Rows.Clear();
            Bll_Car c = new Bll_Car();
            DataTable dt = new DataTable();
            dt = c.ShowAllCars();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(dt.Rows[i]["CarRegID"].ToString(), dt.Rows[i]["MakeName"], dt.Rows[i]["ModelName"].ToString(), dt.Rows[i]["ModelYear"].ToString(), dt.Rows[i]["CarDescription"].ToString(), dt.Rows[i]["Condition"].ToString(), dt.Rows[i]["Price"].ToString(), dt.Rows[i]["PricePerDay"].ToString(), dt.Rows[i]["RegistrationDate"].ToString(), dt.Rows[i]["CarAvailability"].ToString(), dt.Rows[i]["RegisteredBy"].ToString(), dt.Rows[i]["TakenFrom"].ToString());
            }

        }


        public int CountCars()
        {

            Bll_Car c = new Bll_Car();
            DataTable dt = new DataTable();
            dt = c.ShowAvailableCars();
            return dt.Rows.Count;

        }

       

        public string insertcarpriceintb()
        {
            Bll_Car c = new Bll_Car();
            DataTable dt = new DataTable();
            dt = c.SelectCarByID(CarRegID);

            return dt.Rows[0]["Price"].ToString();

        }
    }
}

