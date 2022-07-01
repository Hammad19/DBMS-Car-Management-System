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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {


        }

        private void Employee_Load(object sender, EventArgs e)
        {
            Employeee emp = new Employeee();
            userDataGrid1.Rows.Clear();
            emp.EmployeeHistory(userDataGrid1);
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

        public char gender()
        {
            char g = 'F';
            if (femaleRadioButton1.Checked == true) 
            {
                g = 'F';

            }
            else if(maleRadioButton1.Checked == true)
            {
                g = 'M';
            }

            return g;
        }
        private void Addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Employeee emp = new Employeee(0, empNametextbox.Text, gender(), empAddressTextbox.Text, Convert.ToInt64(empContTextbox.Text), empEmailTextbox.Text, empEntryDateDatepicker.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(FormControls.ID), enpassword.Text);
                emp.Register();
                //userDataGrid1.Columns.Clear();
                userDataGrid1.Rows.Clear();
                emp.EmployeeHistory(userDataGrid1);
            }
            catch(Exception Myex) { MessageBox.Show(Myex.Message); }
           
        }

        public void Crud(DataGridViewCellEventArgs e)
        {
            
            //Exception Lagni hai
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.userDataGrid1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                employeeIDtextbox.Text = row.Cells[0].Value.ToString();
                //textBox5.ReadOnly = true;
                empNametextbox.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString() == "M")
                {
                    maleRadioButton1.Checked = true;
                }
                else if(row.Cells[2].Value.ToString() == "F")
                {
                    femaleRadioButton1.Checked = true;

                }
                empAddressTextbox.Text = row.Cells[3].Value.ToString();
                enpassword.Text = row.Cells[4].Value.ToString();
                empEntryDateDatepicker.Value = Convert.ToDateTime(row.Cells[5].Value.ToString());
                adminIDTextbox.Text = row.Cells[6].Value.ToString();
                empContTextbox.Text = row.Cells[7].Value.ToString();
                empEmailTextbox.Text = row.Cells[8].Value.ToString();
            }
        }

        private void userDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Crud(e);

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Employeee emp = new Employeee(Convert.ToInt32(employeeIDtextbox.Text));
                emp.Delete();
                userDataGrid1.Rows.Clear();
                emp.EmployeeHistory(userDataGrid1);
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                Employeee emp = new Employeee(Convert.ToInt32(employeeIDtextbox.Text), empNametextbox.Text, gender(), empAddressTextbox.Text, Convert.ToInt64(empContTextbox.Text), empEmailTextbox.Text, empEntryDateDatepicker.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(adminIDTextbox.Text), enpassword.Text);
                emp.Update();
                userDataGrid1.Rows.Clear();
                emp.EmployeeHistory(userDataGrid1);
            }
            catch (Exception Myex) { MessageBox.Show(Myex.Message); }
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
