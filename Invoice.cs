using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace AutoCarManagementSystem
{
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            if(FormControls.ispurchased == "yes")
            {
                dataGridView2.Hide();
                Purchases p = new Purchases();
                p.GenerateInvoice(customerlabel, datelabel, customeraddress, empname, dataGridView1);

            }
            else
            {
                dataGridView1.Hide();
                Rent r = new Rent();
                r.GenerateInvoice(customerlabel, datelabel, customeraddress, empname, dataGridView2);
            }
        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
