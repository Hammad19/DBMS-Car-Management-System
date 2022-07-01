using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AutoCarManagementSystem
{
    public partial class dealerForm : Form
    {
        public dealerForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-BB1J6R8;Initial Catalog=CarPalaceSystem;Integrated Security=True");
        private void dealerForm_Load(object sender, EventArgs e)
        {
            Dealer dealer = new Dealer();
            userDataGrid1.Rows.Clear();
            dealer.DealerHistory(userDataGrid1);
        }
        private void bunifuLabel11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
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
                Dealer dealer = new Dealer(0, dealeNametextbox.Text, gender(), dealerAddressTextbox.Text, Convert.ToInt64(dealerContTextbox.Text), dealerEmailTextbox.Text, compNameTextbox.Text, entryDateDatepicker.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(FormControls.ID));
                dealer.Register();
                dealer.DealerHistory(userDataGrid1);
            }
            catch(Exception Myex) { MessageBox.Show(Myex.Message); }
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainForm m = new mainForm();
            m.Show();
            this.Hide();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try 
            {
                Dealer dealer = new Dealer(Convert.ToInt32(dealerIDtextbox.Text), dealeNametextbox.Text, gender(), dealerAddressTextbox.Text, Convert.ToInt64(dealerContTextbox.Text), dealerEmailTextbox.Text, compNameTextbox.Text, entryDateDatepicker.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(adminIDTextbox.Text));
                dealer.Update();
                dealer.DealerHistory(userDataGrid1);
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try 
            {
                Dealer dealer = new Dealer(Convert.ToInt32(dealerIDtextbox.Text));
                dealer.Delete();
                dealer.DealerHistory(userDataGrid1);
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
                dealerIDtextbox.Text = row.Cells[0].Value.ToString();
                //textBox5.ReadOnly = true;
                dealeNametextbox.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString() == "M")
                {
                    maleRadioButton1.Checked = true;
                }
                else if (row.Cells[2].Value.ToString() == "F")
                {
                    femaleRadioButton1.Checked = true;

                }
                dealerAddressTextbox.Text = row.Cells[3].Value.ToString();
                dealerContTextbox.Text = row.Cells[4].Value.ToString();
                dealerEmailTextbox.Text = row.Cells[5].Value.ToString();
                compNameTextbox.Text = row.Cells[6].Value.ToString();
                entryDateDatepicker.Value = Convert.ToDateTime(row.Cells[7].Value.ToString());
                adminIDTextbox.Text = row.Cells[8].Value.ToString();
                
                
            }
        }

        private void userDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        private void userDataGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }
    }
}
