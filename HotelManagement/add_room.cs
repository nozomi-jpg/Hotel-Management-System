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
    public partial class add_room : Form
    {
        public add_room()
        {
            InitializeComponent();
        }

        private void add_room_Load(object sender, EventArgs e)
        {
            if (label8.Text != "update")
            {
                GetID();
            }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
           
    }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Room Number is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
            }

            else if (comboBox1.SelectedText == null)
            {
                MessageBox.Show("Room Type is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBox1.Focus();
            }
            else if (textBox6.Text == string.Empty)
            {
                MessageBox.Show("Room Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox6.Focus();
            }
            else if (numericUpDown1.Text == null)
            {
                MessageBox.Show("Number of occupants is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numericUpDown1.Focus();
            }
            else if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Room Price is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox2.Focus();
            }
            else
            {
                Class1 NewConnection = new Class1();
                NewConnection.open_connection();
                SqlCommand cmd = new SqlCommand();

                NewConnection.open_connection();

                cmd.Connection = Class1.con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_ins_room_02";
                cmd.Parameters.AddWithValue("@Room_No", textBox1.Text);
                cmd.Parameters.AddWithValue("@Room_Type", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Room_Class", textBox6.Text);
                cmd.Parameters.AddWithValue("@Max_Occupants", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@Room_Price", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                clear();
                GetID();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
            textBox6.Text = string.Empty;
            numericUpDown1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.Focus();
        }
        public void GetID()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            if (comboBox1.Text == "Standard 1B") 
            {

                //cmd.CommandText = "select case when max(Room_No) is null then 'S1-1' else 'S1-' + cast(max(Room_No) + 1 as varchar(30)) end as Room_No from room";
                cmd.CommandText = "select case when max(cast(replace(Room_No, 'S1-', '') as int)) is null then 'S1-001'when max(cast(replace(Room_No, 'S1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'S1-', '') as int))) = 1 then 'S1-00' + cast(max(cast(replace(Room_No, 'S1-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'S1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'S1-', '') as int))) = 2 then 'S1-0' + cast(max(cast(replace(Room_No, 'S1-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'S1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'S1-', '') as int))) > 2 then 'S1-' + cast(max(cast(replace(Room_No, 'S1-', '') as int)) + 1 as varchar(30)) end as Room_No from room where Room_No like '%' + 'S1-' + '%'";
                SqlDataReader rdr1 = cmd.ExecuteReader();

                if (rdr1.Read() == true)
                {
                    textBox1.Text = rdr1.GetValue(0).ToString();
                }
            }

            else if (comboBox1.Text == "Standard 2B")
                {

                  
                    cmd.CommandText = "select case when max(cast(replace(Room_No, 'S2-', '') as int)) is null then 'S2-001' when max(cast(replace(Room_No, 'S2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'S2-', '') as int))) = 1 then 'S2-00' + cast(max(cast(replace(Room_No, 'S2-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'S2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'S2-', '') as int))) = 2 then 'S2-0' + cast(max(cast(replace(Room_No, 'S2-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'S2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'S2-', '') as int))) > 2 then 'S2-' + cast(max(cast(replace(Room_No, 'S2-', '') as int)) + 1 as varchar(30)) end as Room_No from room where Room_No like '%' + 'S2-' + '%'";
                    SqlDataReader rdr2 = cmd.ExecuteReader();

                    if (rdr2.Read() == true)
                    {
                        textBox1.Text = rdr2.GetValue(0).ToString();
                    }
                }
            else if (comboBox1.Text == "Deluxe 1BR")
            {

                cmd.CommandText = "select case when max(cast(replace(Room_No, 'D1-', '') as int)) is null then 'D1-001' when max(cast(replace(Room_No, 'D1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'D1-', '') as int))) = 1 then 'D1-00' + cast(max(cast(replace(Room_No, 'D1-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'D1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'D1-', '') as int))) = 2 then 'D1-0' + cast(max(cast(replace(Room_No, 'D1-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'D1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'D1-', '') as int))) > 2 then 'D1-' + cast(max(cast(replace(Room_No, 'D1-', '') as int)) + 1 as varchar(30)) end as Room_No from room where Room_No like '%' + 'D1-' + '%'";
                SqlDataReader rdr2 = cmd.ExecuteReader();

                if (rdr2.Read() == true)
                {
                    textBox1.Text = rdr2.GetValue(0).ToString();
                }


            }
            else if (comboBox1.Text == "Deluxe 2BR")
            {
                cmd.CommandText = "select case when max(cast(replace(Room_No, 'D2-', '') as int)) is null then 'D2-001' when max(cast(replace(Room_No, 'D2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'D2-', '') as int))) = 1 then 'D2-00' + cast(max(cast(replace(Room_No, 'D2-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'D2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'D2-', '') as int))) = 2 then 'D2-0' + cast(max(cast(replace(Room_No, 'D2-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'D2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'D2-', '') as int))) > 2 then 'D2-' + cast(max(cast(replace(Room_No, 'D2-', '') as int)) + 1 as varchar(30)) end as Room_No from room where Room_No like '%' + 'D2-' + '%'";
                SqlDataReader rdr2 = cmd.ExecuteReader();

                if (rdr2.Read() == true)
                {
                    textBox1.Text = rdr2.GetValue(0).ToString();
                }
            }
            else if (comboBox1.Text == "Junior Suite 1BR")
            {
                cmd.CommandText = "select case when max(cast(replace(Room_No, 'JS1-', '') as int)) is null then 'JS1-001' when max(cast(replace(Room_No, 'JS1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'JS1-', '') as int))) = 1 then 'JS1-00' + cast(max(cast(replace(Room_No, 'JS1-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'JS1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'JS1-', '') as int))) = 2 then 'JS1-0' + cast(max(cast(replace(Room_No, 'JS1-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'JS1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'JS1-', '') as int))) > 2 then 'JS1-' + cast(max(cast(replace(Room_No, 'JS1-', '') as int)) + 1 as varchar(30)) end as Room_No from room where Room_No like '%' + 'JS1-' + '%'";
                SqlDataReader rdr2 = cmd.ExecuteReader();

                if (rdr2.Read() == true)
                {
                    textBox1.Text = rdr2.GetValue(0).ToString();
                }
            }
            else if (comboBox1.Text == "Junior Suite 2BR")
            {
                cmd.CommandText = "select case when max(cast(replace(Room_No, 'JS2-', '') as int)) is null then 'JS2-001' when max(cast(replace(Room_No, 'JS2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'JS2-', '') as int))) = 1 then 'JS2-00' + cast(max(cast(replace(Room_No, 'JS2-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'JS2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'JS2-', '') as int))) = 2 then 'JS2-0' + cast(max(cast(replace(Room_No, 'JS2-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'JS2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'JS2-', '') as int))) > 2 then 'JS2-' + cast(max(cast(replace(Room_No, 'JS2-', '') as int)) + 1 as varchar(30)) end as Room_No from room where Room_No like '%' + 'JS2-' + '%'";
                SqlDataReader rdr2 = cmd.ExecuteReader();

                if (rdr2.Read() == true)
                {
                    textBox1.Text = rdr2.GetValue(0).ToString();
                }
            }
            else if (comboBox1.Text == "Presidential Suite 1BR")
            {
                cmd.CommandText = "select case when max(cast(replace(Room_No, 'PS1-', '') as int)) is null then 'PS1-001' when max(cast(replace(Room_No, 'PS1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'PS1-', '') as int))) = 1 then 'PS1-00' + cast(max(cast(replace(Room_No, 'PS1-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'PS1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'PS1-', '') as int))) = 2 then 'PS1-0' + cast(max(cast(replace(Room_No, 'PS1-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'PS1-', '') as int)) is not null and len(max(cast(replace(Room_No, 'PS1-', '') as int))) > 2 then 'PS1-' + cast(max(cast(replace(Room_No, 'PS1-', '') as int)) + 1 as varchar(30)) end as Room_No from room where Room_No like '%' + 'PS1-' + '%'";
                SqlDataReader rdr2 = cmd.ExecuteReader();

                if (rdr2.Read() == true)
                {
                    textBox1.Text = rdr2.GetValue(0).ToString();
                }
            }
            else if(comboBox1.Text == "Presidential Suite 2BR")
            {
                cmd.CommandText = "select case when max(cast(replace(Room_No, 'PS2-', '') as int)) is null then 'PS2-001' when max(cast(replace(Room_No, 'PS2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'PS2-', '') as int))) = 1 then 'PS2-00' + cast(max(cast(replace(Room_No, 'PS2-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'PS2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'PS2-', '') as int))) = 2 then 'PS2-0' + cast(max(cast(replace(Room_No, 'PS2-', '') as int)) + 1 as varchar(30)) when max(cast(replace(Room_No, 'PS2-', '') as int)) is not null and len(max(cast(replace(Room_No, 'PS2-', '') as int))) > 2 then 'PS2-' + cast(max(cast(replace(Room_No, 'PS2-', '') as int)) + 1 as varchar(30)) end as Room_No from room where Room_No like '%' + 'PS2-' + '%'";
                SqlDataReader rdr2 = cmd.ExecuteReader();

                if (rdr2.Read() == true)
                {
                    textBox1.Text = rdr2.GetValue(0).ToString();
                }
            }
        }
        public void clear()
        {
            textBox1.Text = string.Empty;
            comboBox1.Text = string.Empty;
            textBox6.Text = string.Empty;
            numericUpDown1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Room Number is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Class1 NewConnection = new Class1();
                NewConnection.open_connection();

                SqlCommand cmd = new SqlCommand();

                NewConnection.open_connection();

                cmd.Connection = Class1.con;


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_upd_room_02";
                cmd.Parameters.AddWithValue("@Room_No", textBox1.Text);
                cmd.Parameters.AddWithValue("@Room_Type", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Room_Class", textBox6.Text);
                cmd.Parameters.AddWithValue("@Max_Occupants", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@Room_Price", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Parameters.Clear();
                
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (label7.Text != "update")
            {
                GetID();

            }
        }
        public void DisableComboBox()
        {
            comboBox1.Enabled = false;
          
        }

        private void label9_Click(object sender, EventArgs e)
        {
            room frm = new room();
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
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
        }
    }
}
