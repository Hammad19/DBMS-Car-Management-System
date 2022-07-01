using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCarManagementSystem
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        private void bunifuLabel6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void DealerButton_Click(object sender, EventArgs e)
        {
            if (FormControls.adminlogin == "yes")
            {
                dealerForm d1 = new dealerForm();
                d1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry ! you Dont have Access to This Panel");
            }
            
        }

        private void Employeebutton_Click(object sender, EventArgs e)
        {
            if (FormControls.adminlogin == "yes")
            { 
                Employee f1 = new Employee();
                f1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry ! you Dont have Access to This Panel");
            }
        }

        private void customerbutton_Click(object sender, EventArgs e)
        {
            Customer f1 = new Customer();
            f1.Show();
            this.Hide();
        }

        private void purchasedbutton_Click(object sender, EventArgs e)
        {
            purchasedCar f1 = new purchasedCar();
            f1.Show();
            this.Hide();
        }

        private void carmain_Click(object sender, EventArgs e)
        {
            Car f1 = new Car();
            f1.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Rentform f = new Rentform();
            f.Show();
            this.Hide();
        }

        private void dashBoardbutton_Click(object sender, EventArgs e)
        {
            if (FormControls.adminlogin == "yes")
            {
                DashBoard d = new DashBoard();
                d.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry ! you Dont have Access to This Panel");
            }
        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            mainForm m = new mainForm();
            m.Show();
            this.Hide();
        }
    }
}
