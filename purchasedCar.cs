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
    public partial class purchasedCar : Form
    {
        public purchasedCar()
        {
            InitializeComponent();
        }

        private void carPriceTextbox_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void purchasedCar_Load(object sender, EventArgs e)
        {
            empIDTextbox.Text = FormControls.ID;
            Purchases p = new Purchases();
            p.ShowCarIDincbx(regcbx);
            p.ShowCustomerincbx(cuscbx);
            p.PurchaseHistory(dataGridView1);
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                FormControls.ispurchased = "yes";
                FormControls.CarRegID = Convert.ToInt32(regcbx.SelectedItem.ToString());
                Purchases p = new Purchases(Convert.ToInt32(regcbx.SelectedItem.ToString()), Convert.ToInt32(FormControls.ID), Convert.ToInt32(cuscbx.SelectedItem.ToString()), Convert.ToInt32(carPriceTextbox.Text), PurchasedEntryDateDatepicker.Value.ToString("yyyy-MM-dd"));
                p.Addpurchase();
                p.PurchaseHistory(dataGridView1);
                p.ShowCarIDincbx(regcbx);
                FormControls.CusID = Convert.ToInt32(cuscbx.SelectedItem.ToString());
                FormControls.date = PurchasedEntryDateDatepicker.Value.ToString("yyyy-MM-dd");
                Invoice inv = new Invoice();
                inv.Show();
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }
            
        }

        private void regcbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Purchases p = new Purchases();
            cars c = new cars(Convert.ToInt32(regcbx.SelectedItem.ToString()));
            carPriceTextbox.Text = c.insertcarpriceintb();
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                Purchases p = new Purchases(Convert.ToInt32(purchasetext.Text), Convert.ToInt32(regcbx.Text), Convert.ToInt32(FormControls.ID), Convert.ToInt32(cuscbx.SelectedItem.ToString()), Convert.ToInt32(carPriceTextbox.Text), PurchasedEntryDateDatepicker.Value.ToString("yyyy-MM-dd"));
                p.UpdatePurchase();
                p.PurchaseHistory(dataGridView1);
                p.ShowCarIDincbx(regcbx);
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Purchases p = new Purchases(Convert.ToInt32(purchasetext.Text));
                p.DeletePurchase();
                p.PurchaseHistory(dataGridView1);
                p.ShowCarIDincbx(regcbx);
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }

        }

        public void Crud(DataGridViewCellEventArgs e)
        {

            //Exception Lagni hai
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                purchasetext.Text = row.Cells[0].Value.ToString();
                //textBox5.ReadOnly = true;
                regcbx.Text = row.Cells[1].Value.ToString();
                carPriceTextbox.Text = row.Cells[2].Value.ToString();
                PurchasedEntryDateDatepicker.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
                cuscbx.Text = row.Cells[4].Value.ToString();
                empIDTextbox.Text = row.Cells[5].Value.ToString();
              
         

            }
        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainForm m = new mainForm();
            m.Show();
            this.Hide();
        }
    }
}
