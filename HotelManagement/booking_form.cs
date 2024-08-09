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
    public partial class booking_form : Form
    {
        public booking_form()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void booking_form_Load(object sender, EventArgs e)
        {
            if (label13.Text != "update")
            {
                GetID();
            }
        }
        public void GetID()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "select case when max(Booking_ID) is null then 1 else max(Booking_ID) + 1 end as Booking_ID from booking_details";
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {
                textBox1.Text = rdr.GetValue(0).ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            GuestShow frm = new GuestShow();
            frm.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            roomShow frm = new roomShow();
            frm.ShowDialog();
         

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Guest ID is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox2.Focus();
            }

            else if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("Room Number is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox4.Focus();
            }
            else if (Convert.ToInt32(numericUpDown1.Text) == 0)
            {
                MessageBox.Show("Number of occupant is empty!", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if ((dateTimePicker2.Value.Date == dateTimePicker1.Value.Date) || (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date) || (dateTimePicker1.Value.Date < DateTime.Now.Date))
            {
                MessageBox.Show("Inappropriate date!", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Class1 NewConnection = new Class1();
                NewConnection.open_connection();
                SqlCommand cmd = new SqlCommand();

                NewConnection.open_connection();

                cmd.Connection = Class1.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ins_booking_03";
                cmd.Parameters.AddWithValue("@Guest_ID", textBox2.Text);
                cmd.Parameters.AddWithValue("@Room_No", textBox4.Text);
                cmd.Parameters.AddWithValue("@Room_Type", textBox5.Text);
                cmd.Parameters.AddWithValue("@Room_Price", textBox6.Text);
                cmd.Parameters.AddWithValue("@Occupants", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@Booking_Date", label10.Text);
                cmd.Parameters.AddWithValue("@Arrival_Date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Departure_Date", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@Price", textBox6.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clear();
                GetID();
                
            }
        }

        public void clear()
        {
            textBox2.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            numericUpDown1.Text = string.Empty;
            label10.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;
            dateTimePicker2.Text = string.Empty;
            textBox2.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(textBox5.Text == "Standard 1B")
            {

                numericUpDown1.Maximum = 1;
        }
            else if(textBox5.Text == "Standard 2B")
            {
                numericUpDown1.Maximum = 2;
        }
            else if (textBox5.Text == "Deluxe 1BR")
            {
                numericUpDown1.Maximum = 2;
            }
            else if (textBox5.Text == "Deluxe 2BR")
            {
                numericUpDown1.Maximum = 4;
            }
            else if (textBox5.Text == "Junior Suite 1BR")
            {
                numericUpDown1.Maximum = 3;
            }
            else if (textBox5.Text == "Junior Suite 2BR")
            {
                numericUpDown1.Maximum = 4;
            }
            else if (textBox5.Text == "Presidential Suite 1BR")
            {
                numericUpDown1.Maximum = 4;
            }
            else if (textBox5.Text == "Presidential Suite 2BR")
            {
                numericUpDown1.Maximum = 6;
            }
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Booking ID is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Class1 NewConnection = new Class1();
                NewConnection.open_connection();

                SqlCommand cmd = new SqlCommand();

                NewConnection.open_connection();

                cmd.Connection = Class1.con;


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_upd_booking_03";
                cmd.Parameters.AddWithValue("@Booking_ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Guest_ID", textBox2.Text);
                cmd.Parameters.AddWithValue("@Room_No", textBox4.Text);
                cmd.Parameters.AddWithValue("@Room_Type", textBox5.Text);
                cmd.Parameters.AddWithValue("@Room_Price", textBox6.Text);
                cmd.Parameters.AddWithValue("@Occupants", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@Booking_Date", label10.Text);
                cmd.Parameters.AddWithValue("@Arrival_Date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Departure_Date", dateTimePicker2.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Parameters.Clear();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            booking frm = new booking();
            frm.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            booking_details frm = new booking_details();
            frm.Show();
            this.Hide();
        }
        public void AddDisableButton()
        {
            button8.Enabled = false;
            button8.BackColor = Color.Gray;
        }
        public void UpdateDisableButton()
        {
            button6.Enabled = false;
            button6.BackColor = Color.Gray;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
    }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
