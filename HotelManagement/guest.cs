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
using CrystalDecisions.CrystalReports.Engine;

namespace HotelManagement
{
    public partial class guest : Form
    {
        public guest()
        {
            InitializeComponent();
        }
        public static string Guest_ID = "";
        public static string Guest_Name = "";
        public static string Age = "";
        public static string Contact_Number = "";

        private void button6_Click(object sender, EventArgs e)
        {
            add_guest frm = new add_guest();
            frm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit(); }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            login frm = new login();
            frm.Show();
            this.Hide();
        }
        public void LoadGrid()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.CommandText = "sp_sel_guest_01";
            cmd.Parameters.AddWithValue("Guest_ID", textBox2.Text);
            cmd.Parameters.AddWithValue("Guest_Name", textBox2.Text);

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

        DataTable dtRecord = new DataTable();
        sqlDataAdap.Fill(dtRecord);
       dataGridView1.DataSource = dtRecord;
}

        private void guest_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {


                int row = dataGridView1.CurrentRow.Index;
                Guest_ID = Convert.ToString(dataGridView1[0, row].Value);
                Guest_Name = Convert.ToString(dataGridView1[1, row].Value);
                Age = Convert.ToString(dataGridView1[2, row].Value);
                Contact_Number = Convert.ToString(dataGridView1[3, row].Value);

                add_guest frm = new add_guest();
                frm.textBox1.Text = Guest_ID;
                frm.textBox5.Text = Guest_Name;
                frm.textBox6.Text = Age;
                frm.textBox7.Text = Contact_Number;
                frm.ShowDialog();
            }
    }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = dataGridView1.CurrentRow.Index;
                    Guest_ID = Convert.ToString(dataGridView1[0, row].Value);

                    Class1 NewConnection = new Class1();
                    NewConnection.open_connection();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Class1.con;

                    cmd.CommandText = "Delete from guest where Guest_ID = @Guest_ID";
                    cmd.Parameters.AddWithValue("@Guest_ID", Guest_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfully deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int row = dataGridView1.CurrentRow.Index;
                Guest_ID = Convert.ToString(dataGridView1[0, row].Value);
                Guest_Name = Convert.ToString(dataGridView1[1, row].Value);
                Age = Convert.ToString(dataGridView1[2, row].Value);
                Contact_Number = Convert.ToString(dataGridView1[3, row].Value);

                add_guest frm = new add_guest();
                frm.textBox1.Text = Guest_ID;
                frm.textBox5.Text = Guest_Name;
                frm.textBox6.Text = Age;
                frm.textBox7.Text = Contact_Number;
                frm.label6.Text = "update";
                frm.DisableButton();
                frm.AddDisableButton();
                frm.ShowDialog();
            }
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = dataGridView1.CurrentRow.Index;
                    Guest_ID = Convert.ToString(dataGridView1[0, row].Value);

                    Class1 NewConnection = new Class1();
                    NewConnection.open_connection();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Class1.con;

                    cmd.CommandText = "Delete from guest where Guest_ID = @Guest_ID";
                    cmd.Parameters.AddWithValue("@Guest_ID", Guest_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfully deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
            }
    }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = dataGridView1.CurrentRow.Index;
                    Guest_ID = Convert.ToString(dataGridView1[0, row].Value);

                    Class1 NewConnection = new Class1();
                    NewConnection.open_connection();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Class1.con;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_del_guest_01";
                    cmd.Parameters.AddWithValue("@Guest_ID", Guest_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfully deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            add_guest frm = new add_guest();
            frm.UpdateDisableButton();
            frm.GetID();
            frm.Show();
            this.Hide ();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {


                int row = dataGridView1.CurrentRow.Index;
                Guest_ID = Convert.ToString(dataGridView1[0, row].Value);
                Guest_Name = Convert.ToString(dataGridView1[1, row].Value);
                Age = Convert.ToString(dataGridView1[2, row].Value);
                Contact_Number = Convert.ToString(dataGridView1[3, row].Value);

                add_guest frm = new add_guest();
                frm.textBox1.Text = Guest_ID;
                frm.textBox5.Text = Guest_Name;
                frm.textBox6.Text = Age;
                frm.textBox7.Text = Contact_Number;
            
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            reports frm = new reports();

            ReportDocument cryRpt = new ReportDocument();
            string strReportPath = Application.StartupPath + @"\guestReports.rpt";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            da.SelectCommand = cmd;
            cmd.Connection = cmd.Connection = Class1.con;
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.CommandText = "sp_sel_rpt_guest";
            cmd.CommandTimeout = 0;
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                cryRpt.Load(strReportPath);
                cryRpt.SetDataSource(dt);
                frm.crystalReportViewer1.ReportSource = cryRpt;
                frm.crystalReportViewer1.Refresh();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("No records found.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            guest frm = new guest();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            room frm = new room();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            booking frm = new booking();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            booking_details frm = new booking_details();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login frm = new login();
            frm.Show();
            this.Hide();
        }
    }
}


