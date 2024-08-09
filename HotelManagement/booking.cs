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
    public partial class booking : Form
    {
        public booking()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            booking_form frm = new booking_form();
            frm.UpdateDisableButton();
            frm.Show();
            this.Hide();
        }

        private void booking_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con; ;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "booking01";

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
