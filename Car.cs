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
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }

        private void Car_Load(object sender, EventArgs e)
        {
            try 
            {
                cars c = new cars();
                c.ShowMakeincbx(brandcbox);
                c.ShowDealerincbx(dealercombobox);
                c.ShowModelincbx(modelcbx);
                empli.Text = FormControls.ID;
                c.CarsHistory(userDataGrid1);
            }
            catch(Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }
            
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            try 
            {
                mainForm m = new mainForm();
                m.Show();
                this.Hide();
            }
            catch (Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }
            
        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void availablityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                cars car = new cars();
                car.RegMake(brandNametextbox.Text);
                car.ShowMakeincbx(brandcbox);
            }
            catch(Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                cars car = new cars(Convert.ToInt32(FormControls.ID), Convert.ToInt32(dealercombobox.SelectedItem.ToString()), Convert.ToInt32(myearcbx.SelectedItem.ToString()), modelcbx.SelectedItem.ToString(), Convert.ToInt32(carPriceTextbox.Text), descriptionTextbox.Text, availablityComboBox.SelectedItem.ToString(), carEntryDateDatepicker.Value.ToString("yyyy-MM-dd"), brandcbox.Text.ToString(), conditionComboBox.SelectedItem.ToString());
                car.Register();
                car.CarsHistory(userDataGrid1);
            }
            catch(Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void modelcbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                cars c = new cars();
                c.ShowModelyearincbx(myearcbx, modelcbx.SelectedItem.ToString());
            }
            catch(Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }
           
        }

        private void modelbutton_Click(object sender, EventArgs e)
        {
            try 
            {
                cars c = new cars();
                c.RegModel(modelnamet.Text, brandcbox.SelectedItem.ToString(), Convert.ToInt32(yeartex.Text));
                modelcbx.Items.Clear();
                c.ShowModelincbx(modelcbx);
            }
            catch (Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }
            
        }

        private void userDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Crud(e);
        }


        public void Crud(DataGridViewCellEventArgs e)
        {

            //Exception Lagni hai
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.userDataGrid1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                regNoDtextbox.Text= row.Cells[0].Value.ToString();
                //textBox5.ReadOnly = true;
                brandcbox.Text = row.Cells[1].Value.ToString();
                modelcbx.Text = row.Cells[2].Value.ToString();
                modelnamet.Text = row.Cells[2].Value.ToString();
                brandNametextbox.Text = row.Cells[1].Value.ToString();
                myearcbx.Text = row.Cells[3].Value.ToString();
                yeartex.Text = row.Cells[3].Value.ToString();
                descriptionTextbox.Text = row.Cells[4].Value.ToString();
                conditionComboBox.Text = row.Cells[5].Value.ToString();
                carPriceTextbox.Text = row.Cells[6].Value.ToString();
                
                carEntryDateDatepicker.Value = Convert.ToDateTime(row.Cells[8].Value.ToString());
                availablityComboBox.Text = row.Cells[9].Value.ToString();
                empID.Text = row.Cells[10].Value.ToString();
                dealercombobox.Text = row.Cells[11].Value.ToString();

            }
        }

        private void userDataGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
           
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            
            
        }

        private void delbuton_Click(object sender, EventArgs e)
        {
            
        }

        private void edbuton_Click(object sender, EventArgs e)
        {
            
        }

        private void delbuton_Click_1(object sender, EventArgs e)
        {

        }

        private void edbtu_Click(object sender, EventArgs e)
        {
            try 
            {
                cars car = new cars(Convert.ToInt32(regNoDtextbox.Text), Convert.ToInt32(FormControls.ID), Convert.ToInt32(dealercombobox.SelectedItem.ToString()), Convert.ToInt32(myearcbx.SelectedItem.ToString()), modelcbx.SelectedItem.ToString(), Convert.ToInt32(carPriceTextbox.Text), descriptionTextbox.Text, availablityComboBox.SelectedItem.ToString(), carEntryDateDatepicker.Value.ToString("yyyy-MM-dd"), brandcbox.Text.ToString(), conditionComboBox.SelectedItem.ToString());
                car.Update();
                car.CarsHistory(userDataGrid1);
            }
            catch(Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }
           
        }
        private void dltbtu_Click(object sender, EventArgs e)
        {
            try 
            {
                cars car = new cars();
                car.CarRegID = Convert.ToInt32(regNoDtextbox.Text);
                car.Delete();
                car.CarsHistory(userDataGrid1);

            }
            catch (Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }
        }
    }
}
