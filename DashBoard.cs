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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            cars c = new cars();
            bunifuLabel8.Text = c.CountCars().ToString();

            customer cus = new customer();
            bunifuLabel4.Text = cus.CountCustomer().ToString();

            Dealer d = new Dealer();
            bunifuLabel10.Text = d.CountDealer().ToString();

            Employeee emp = new Employeee();
            bunifuLabel3.Text = emp.CountEmployee().ToString();

            Rent r = new Rent();
            bunifuLabel14.Text = r.CountRent().ToString();

            Purchases p = new Purchases();
            bunifuLabel6.Text = p.Countpurchase().ToString();


            /*  string query1 = "select count(*) from Customer";
              SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
              DataTable dt1 = new DataTable();
              da.Fill(dt1);
              bunifuLabel4.Text = dt1.Rows[0][0].ToString();

              string query2 = "select count(*) from Dealer";
              SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
              DataTable dt2 = new DataTable();
              da.Fill(dt2);
              bunifuLabel10.Text = dt2.Rows[0][0].ToString();

              string query3 = "select count(*) from Employee";
              SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
              DataTable dt3 = new DataTable();
              da.Fill(dt3);
              bunifuLabel3.Text = dt3.Rows[0][0].ToString();*/
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
