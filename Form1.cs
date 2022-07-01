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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                Admin admin = new Admin(Convert.ToInt32(userIDtextbox.Text), passwordltextbox.Text);
                admin.CheckLogin();

                if (FormControls.adminlogin == "yes")
                {
                    mainForm m = new mainForm();
                    m.Show();
                    this.Hide();
                }
                else if (FormControls.adminlogin == "no")
                {
                    Employeee emp = new Employeee(Convert.ToInt32(userIDtextbox.Text), passwordltextbox.Text);
                    if (emp.CheckLogin() == true)
                    {
                        mainForm m = new mainForm();
                        m.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Incorrect User or Password");


                    }

                };
            }
            catch(Exception Myex) 
            {
                MessageBox.Show(Myex.Message);
            }
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void passwordltextbox_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void userIDtextbox_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
