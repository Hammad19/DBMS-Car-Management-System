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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            try 
            {
                customer d = new customer();
                d.CustomerHistory(userDataGrid1);
                cusEntryDateDatepicker.Value = DateTime.Now;
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }
        }

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainForm m = new mainForm();
            m.Show();
            this.Hide();
        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public char gender()
        {
            char g = 'F';
            if (femaleRadioButton1.Checked == true)
            {
                g = 'F';

            }
            else if (maleRadioButton1.Checked == true)
            {
                g = 'M';
            }

            return g;
        }
        private void Addbutton_Click(object sender, EventArgs e)
        {
            try 
            {
                customer cos = new customer(Convert.ToInt32(FormControls.ID), cusNametextbox.Text, gender(), cusAddressTextbox.Text, Convert.ToInt64(cusContTextbox.Text), cusCNICTextbox.Text, cusEmailTextbox.Text, cusEntryDateDatepicker.Value.ToString("yyyy-MM-dd"));
                cos.Register();
                cos.CustomerHistory(userDataGrid1);

            }
            catch (Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try 
            {
                customer cos = new customer(Convert.ToInt32(cusIDtextbox.Text), Convert.ToInt32(FormControls.ID), cusNametextbox.Text, gender(), cusAddressTextbox.Text, Convert.ToInt64(cusContTextbox.Text), cusCNICTextbox.Text, cusEmailTextbox.Text, cusEntryDateDatepicker.Value.ToString("yyyy-MM-dd"));
                cos.Update();
                cos.CustomerHistory(userDataGrid1);
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try 
            {
                customer cos = new customer(Convert.ToInt32(cusIDtextbox.Text));
                cos.Delete();

                cos.CustomerHistory(userDataGrid1);
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }
        }

        public void Crud(DataGridViewCellEventArgs e)
        {

            //Exception Lagni hai
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.userDataGrid1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                cusIDtextbox.Text = row.Cells[0].Value.ToString();
                //textBox5.ReadOnly = true;
                empIDTextbox.Text = row.Cells[1].Value.ToString();
                cusNametextbox.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString() == "M")
                {
                    maleRadioButton1.Checked = true;
                }
                else if (row.Cells[2].Value.ToString() == "F")
                {
                    femaleRadioButton1.Checked = true;

                }
                cusAddressTextbox.Text = row.Cells[4].Value.ToString();
                cusContTextbox.Text = row.Cells[5].Value.ToString();
                cusCNICTextbox.Text = row.Cells[6].Value.ToString();
                cusEmailTextbox.Text = row.Cells[7].Value.ToString();
                cusEntryDateDatepicker.Value = Convert.ToDateTime(row.Cells[8].Value.ToString());
                
            }
        }

        private void userDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        private void userDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        private void userDataGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }
    }
}
