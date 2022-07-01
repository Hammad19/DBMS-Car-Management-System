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
    public partial class Rentform : Form
    {

        int noofdays;
        public Rentform()
        {
            InitializeComponent();
        }

        private void Rentform_Load(object sender, EventArgs e)
        {
            empIDTextbox.Text = FormControls.ID;
            Rent p = new Rent();
            p.ShowCarIDincbx(regcbx);
            p.ShowCustomerincbx(cuscbx);
            p.RentHistory(dataGridView1);
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                FormControls.ispurchased = "No";
                FormControls.CarRegID = Convert.ToInt32(regcbx.SelectedItem.ToString());
                Rent r = new Rent(Convert.ToInt32(regcbx.SelectedItem.ToString()), Convert.ToInt32(FormControls.ID), Convert.ToInt32(cuscbx.SelectedItem.ToString()), Convert.ToInt32(carPriceTextbox.Text), PurchasedEntryDateDatepicker.Value.ToString("yyyy-MM-dd"), retentrydatepicker.Value.ToString("yyyy-MM-dd"));
                r.AddRent(noofdays.ToString());
                r.RentHistory(dataGridView1);
                r.ShowCarIDincbx(regcbx);
                FormControls.CusID = Convert.ToInt32(cuscbx.SelectedItem.ToString());
                FormControls.date = PurchasedEntryDateDatepicker.Value.ToString("yyyy-MM-dd");
                Invoice inv = new Invoice();
                inv.Show();
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
                retentrydatepicker.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
                cuscbx.Text = row.Cells[5].Value.ToString();
                empIDTextbox.Text = row.Cells[6].Value.ToString();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                Rent r = new Rent(Convert.ToInt32(purchasetext.Text), Convert.ToInt32(regcbx.SelectedItem.ToString()), Convert.ToInt32(FormControls.ID), Convert.ToInt32(cuscbx.SelectedItem.ToString()), Convert.ToInt32(carPriceTextbox.Text), PurchasedEntryDateDatepicker.Value.ToString("yyyy-MM-dd"), retentrydatepicker.Value.ToString("yyyy-MM-dd"));
                r.UpdateRent();
                r.RentHistory(dataGridView1);
                r.ShowCarIDincbx(regcbx);
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }


        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Rent r = new Rent(Convert.ToInt32(purchasetext.Text));
                r.DeleteRent();
                r.RentHistory(dataGridView1);
                r.ShowCarIDincbx(regcbx);
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }


        }

        private void retentrydatepicker_onValueChanged(object sender, EventArgs e)
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

        private void getprice_Click(object sender, EventArgs e)
        {
            try
            {
                Rent r = new Rent();
                FormControls.CarRegID = Convert.ToInt32(regcbx.SelectedItem.ToString());
                DateTime dt1 = PurchasedEntryDateDatepicker.Value;
                DateTime dt2 = retentrydatepicker.Value;
                TimeSpan t = dt2 - dt1;
                FormControls.noofdays = Convert.ToInt32(t.TotalDays);
                noofdays = Convert.ToInt32(t.TotalDays);
                carPriceTextbox.Text = Convert.ToString(r.GetTotalAmount(noofdays.ToString()));
            }
            catch(Exception Myex) { MessageBox.Show(Myex.Message); }
           
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainForm m = new mainForm();
            m.Show();
            this.Hide();
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
