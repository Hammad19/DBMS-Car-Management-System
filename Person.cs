
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace AutoCarManagementSystem
{
    class Person
    {
        public Person()
        {

        }

        public Person(int id)
        {
            this.ID = id;

        }
        public Person(int ID, string Name, char Gender, string Address,long ContactNumber,string Email )
        {
            this.ID = ID;
            this.Name = Name;
            this.Gender = Gender;
            this.Address = Address;
            this.ContactNumber = ContactNumber;
            this.Email = Email;


        }

        public Person(string Name, char Gender, string Address, long ContactNumber, string Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Gender = Gender;
            this.Address = Address;
            this.ContactNumber = ContactNumber;
            this.Email = Email;


        }
        public int ID { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }



    }

    class Admin:Person
    {
        public Admin(int id ,string password) : base(id)
        {
            this.Password = password;

        }

        public Admin(int ID, string Name, char Gender, string Address, long ContactNumber, string Email,string Password) : base(ID, Name, Gender, Address, ContactNumber, Email)
        {
            this.Password = Password;
        }
        public string Password { get; set; }

        public void CheckLogin()
        {
            Bll_Admin login = new Bll_Admin();
            DataTable dt = new DataTable();
            dt = login.Login(ID);
            if (dt.Rows.Count > 0)
            {
                if (ID.ToString() == dt.Rows[0]["AdminID"].ToString())
                {
                    if (Password == dt.Rows[0]["AdminPassword"].ToString())
                    {
                        FormControls.ID = dt.Rows[0]["AdminID"].ToString();
                        FormControls.Username = dt.Rows[0]["AdminName"].ToString();
                        FormControls.adminlogin = "yes";
                    }
                }
            }

        }
    }

    class Dealer : Person
    {
        public Dealer() : base()
        {

        }

        public Dealer(int id) : base(id)
        {

        }
        public Dealer(int ID, string Name, char Gender, string Address, long ContactNumber, string Email, string DealerCompanyName, string DealerRegistrationDate, int DealedBy) : base(ID, Name, Gender, Address, ContactNumber, Email)
        {
            this.DealerCompanyName = DealerCompanyName;
            this.DealerRegistrationDate = DealerRegistrationDate;
            this.DealedBy = DealedBy;
        }
        public string DealerCompanyName { get; set; }
        public string DealerRegistrationDate { get; set; }
        public int DealedBy { get; set; }


        public void Register()
        {
            Bll_Dealer dealer = new Bll_Dealer();
            dealer.Register(Name, Gender, Address, ContactNumber.ToString(), Email, DealerCompanyName, DealerRegistrationDate, DealedBy);

        }

        public void Update()
        {
            Bll_Dealer dealer = new Bll_Dealer();
            dealer.Update(ID, Name, Gender, Address, ContactNumber.ToString(), Email, DealerCompanyName, DealerRegistrationDate, DealedBy);

        }

        public void Delete()
        {
            Bll_Dealer dealer = new Bll_Dealer();
            dealer.Delete(ID);

        }


        public void DealerHistory(DataGridView dgv)
        {
            dgv.Rows.Clear();
            Bll_Dealer dealer = new Bll_Dealer();
            DataTable dt = new DataTable();
            dt = dealer.ShowDealer();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(dt.Rows[i]["DealerID"].ToString(), dt.Rows[i]["DealerName"].ToString(), dt.Rows[i]["DealerGender"].ToString(), dt.Rows[i]["DealerAddress"].ToString(), dt.Rows[i]["DealerPhone"].ToString(), dt.Rows[i]["DealerEmail"].ToString(), dt.Rows[i]["CompanyName"].ToString(), dt.Rows[i]["DealerRegistrationDate"].ToString(), dt.Rows[i]["DealedBy"].ToString());
            }

        }

        public int CountDealer()
        {
            
            Bll_Dealer dealer = new Bll_Dealer();
            DataTable dt = new DataTable();
            dt = dealer.ShowDealer();
            return dt.Rows.Count;

        }


    }
    class Employeee : Person
    {

        public Employeee(int id, string password) : base(id)
        {
            this.Password = password;
        }

        public Employeee(int id) : base(id)
        {

        }
        public Employeee() : base()
        {

        }
        public Employeee(int ID, string Name, char Gender, string Address, long ContactNumber, string Email, string EmpRegDate, int AddedBy ,string Password) : base(ID, Name, Gender, Address, ContactNumber, Email)
        {
            this.EmpRegDate = EmpRegDate ;
            this.AddedBy = AddedBy;
            this.Password = Password;
        }


        public string  EmpRegDate { get; set; }
        public int AddedBy { get; set; }
        public string Password { get; set; }

        public bool CheckLogin()
        {
            Bll_Employee login = new Bll_Employee();
            DataTable dt = new DataTable();
            dt = login.Login(ID);
            if (dt.Rows.Count > 0)
            {
                if (ID.ToString() == dt.Rows[0]["EmployeeID"].ToString())
                {
                    if (Password == dt.Rows[0]["EmployeePassword"].ToString())
                    {
                        FormControls.ID = dt.Rows[0]["EmployeeID"].ToString();
                        FormControls.Username = dt.Rows[0]["EmployeeName"].ToString();
                        FormControls.adminlogin = "no";
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Incorrect User or Password");
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Incorrect User or Password");
                return false;

            }
            return false;
        }

        public void Register()
        {
            Bll_Employee employee = new Bll_Employee();
            employee.Register(Name,Gender,Address,Password,ContactNumber.ToString(),Email,EmpRegDate,AddedBy);

        }

        public void Update()
        {
            Bll_Employee employee = new Bll_Employee();
            employee.Update(ID,Name, Gender, Address, Password, ContactNumber.ToString(), Email, EmpRegDate, AddedBy);

        }

        public void Delete()
        {
            Bll_Employee employee = new Bll_Employee();
            employee.Delete(ID);

        }


        public void EmployeeHistory(DataGridView dgv)
        {
            dgv.Rows.Clear();
            Bll_Employee emp = new Bll_Employee();
            DataTable dt = new DataTable();
            dt = emp.ShowEmployee();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(dt.Rows[i]["EmployeeID"].ToString(), dt.Rows[i]["EmployeeName"].ToString(), dt.Rows[i]["EmployeeGender"].ToString(), dt.Rows[i]["EmployeeAddress"].ToString(), dt.Rows[i]["EmployeePassword"].ToString(), dt.Rows[i]["EmployeeRegistrationDate"].ToString(), dt.Rows[i]["AddedBy"].ToString(),dt.Rows[i]["EmployeePhone"].ToString(), dt.Rows[i]["EmployeeEmail"].ToString());
            }

        }

        public int CountEmployee()
        {
            Bll_Employee emp = new Bll_Employee();
            DataTable dt = new DataTable();
            dt = emp.ShowEmployee();
            return dt.Rows.Count;  
        }



    }
    
    class customer:Person
    {
        public customer() : base()
        {

        }

        public customer(int id) : base(id)
        {

        }

        public customer(int AddedBy, string Name, char Gender, string Address, long ContactNumber, string cnic, string email, string CustomerRegDate) : base(Name, Gender, Address, ContactNumber, email)
        {
            this.CustomerRegDate = CustomerRegDate;
            this.AddedBy = AddedBy;
            this.CNIC = cnic;
        }
        public customer(int ID, int AddedBy, string Name, char Gender, string Address,  long ContactNumber, string cnic,string email, string CustomerRegDate) : base(ID, Name, Gender, Address, ContactNumber, email)
        {
            this.CustomerRegDate = CustomerRegDate;       
            this.AddedBy = AddedBy;
            this.CNIC = cnic ;
        }
        public string CNIC { get; set; }
        public int AddedBy { get; set; }
        public string CustomerRegDate { get; set; }
       



        public void Register()
        {
            Bll_Customer employee = new Bll_Customer();
            employee.Register(AddedBy, Name, Gender, Address, ContactNumber.ToString(), CNIC, Email, CustomerRegDate);

        }

        public void Update()
        {
            Bll_Customer employee = new Bll_Customer();
            employee.Update(ID, AddedBy, Name, Gender, Address, ContactNumber.ToString(), CNIC, Email,CustomerRegDate);

        }

        public void Delete()
        {
            Bll_Customer employee = new Bll_Customer();
            employee.Delete(ID);

        }


        public void CustomerHistory(DataGridView dgv)
        {


            dgv.Rows.Clear();
            Bll_Customer customer = new Bll_Customer();
            DataTable dt = new DataTable();
            dt = customer.ShowCustomer();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(dt.Rows[i]["CustomerID"].ToString(),dt.Rows[i]["AddedBy"], dt.Rows[i]["CustomerName"].ToString(), dt.Rows[i]["CustomerGender"].ToString(), dt.Rows[i]["CustomerAddress"].ToString(), dt.Rows[i]["CustomerPhone"].ToString(), dt.Rows[i]["CustomerCNIC"].ToString(), dt.Rows[i]["CustomerEmail"].ToString(), dt.Rows[i]["CustomerRegistrationDate"].ToString());
            }

        }

        public int CountCustomer( )
        {
            Bll_Customer customer = new Bll_Customer();
            DataTable dt = new DataTable();
            dt = customer.ShowCustomer();
            return dt.Rows.Count;

        }


    }


}
