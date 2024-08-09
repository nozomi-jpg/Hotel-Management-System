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
    public partial class add_guest : Form
    {
        public add_guest()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Guest ID is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
            }

            else if (textBox5.Text == string.Empty)
            {
                MessageBox.Show("Guest Name is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox5.Focus();
            }
            else if (textBox6.Text == string.Empty)
            {
                MessageBox.Show("Age is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox6.Focus();
            }
            else if (textBox7.Text == string.Empty)
            {
                MessageBox.Show("Contact Number is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox7.Focus();
            }
            else
            {
                Class1 NewConnection = new Class1();
                NewConnection.open_connection();
                SqlCommand cmd = new SqlCommand();

                NewConnection.open_connection();

                cmd.Connection = Class1.con;

                cmd.CommandText = "sp_ins_guest_01";
                cmd.CommandType = CommandType.StoredProcedure; 

                cmd.Parameters.AddWithValue("@Guest_Name", textBox5.Text);
                cmd.Parameters.AddWithValue("@Age", textBox6.Text);
                cmd.Parameters.AddWithValue("@Contact_Number", textBox7.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                clear();
                GetID();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox5.Focus();
        }

        public void GetID()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "select case when max(Guest_ID) is null then 1 else max(Guest_ID) + 1 end as Guest_ID from guest";
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {
                textBox1.Text = rdr.GetValue(0).ToString();
            }
        }
        public void clear()
        {
            textBox1.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
    }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Guest ID is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Class1 NewConnection = new Class1();
                NewConnection.open_connection();

                SqlCommand cmd = new SqlCommand();

                NewConnection.open_connection();

                cmd.Connection = Class1.con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_upd_guest_01";

                cmd.Parameters.AddWithValue("@Guest_ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Guest_Name", textBox5.Text);
                cmd.Parameters.AddWithValue("@Age", textBox6.Text);
                cmd.Parameters.AddWithValue("@Contact_Number", textBox7.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Parameters.Clear();
                DisableButton();
                UpdateDisableButton();
                clear();
            }
    }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void add_guest_Load(object sender, EventArgs e)
        {
            if (label6.Text != "update")
            {
                GetID();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            guest frm = new guest();
            frm.Show();
            this.Hide();
        }
        public void AddDisableButton()
        {
            button3.Enabled = false;
            button3.BackColor = Color.Gray;
        }
        public void UpdateDisableButton()
        {
            button1.Enabled = false;
            button1.BackColor = Color.Gray;
        }
        public void DisableButton()
        {
            button4.Enabled = false;
            button4.BackColor = Color.Gray;
        }
    }
}

