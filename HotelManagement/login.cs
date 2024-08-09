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

namespace HotelManagement
{
    public partial class login : Form
    {
        public login()
        {

            InitializeComponent();
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "select count(*) from User_Accounts where Username=@Username and Password=@Password";
            cmd.Parameters.AddWithValue("Username", textBox1.Text);
            cmd.Parameters.AddWithValue("Password", textBox2.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read() == true)
            {
                guest frm = new guest();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username and Password");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
