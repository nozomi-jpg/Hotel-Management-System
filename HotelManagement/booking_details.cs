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
    public partial class booking_details : Form
    {
        public booking_details()
        {
            InitializeComponent();
        }
        public static string Booking_ID = "";
        public static string Guest_ID = "";
        public static string Room_Type = "";
        public static string Room_No = "";
        public static string Room_Price = "";
        public static string Occupants = "";
        public static string Booking_Date = "";
        public static string Arrival_Date = "";
        public static string Departure_Date = "";
        public static string Total_Amount = "";

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

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = dataGridView1.CurrentRow.Index;
                    Booking_ID = Convert.ToString(dataGridView1[0, row].Value);

                    Class1 NewConnection = new Class1();
                    NewConnection.open_connection();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Class1.con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "sp_del_booking_03";
                    cmd.Parameters.AddWithValue("@Booking_ID", Booking_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfully deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
            }
        }

        private void booking_details_Load(object sender, EventArgs e)
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
            cmd.CommandText = "BookingSearch02";
            cmd.Parameters.AddWithValue("@Booking_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Room_Type", textBox1.Text);
            cmd.Parameters.AddWithValue("@Room_No", textBox1.Text);

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int row = dataGridView1.CurrentRow.Index;
                Booking_ID = Convert.ToString(dataGridView1[0, row].Value);
                Guest_ID = Convert.ToString(dataGridView1[1, row].Value);
                Room_Type = Convert.ToString(dataGridView1[2, row].Value);
                Room_No = Convert.ToString(dataGridView1[3, row].Value);
                Room_Price = Convert.ToString(dataGridView1[4, row].Value);
                Occupants = Convert.ToString(dataGridView1[5, row].Value);
                Booking_Date = Convert.ToString(dataGridView1[6, row].Value);
                Arrival_Date = Convert.ToString(dataGridView1[7, row].Value);
                Departure_Date = Convert.ToString(dataGridView1[8, row].Value);
                Total_Amount = Convert.ToString(dataGridView1[9, row].Value);

                booking_form frm = new booking_form();

                frm.textBox1.Text = Booking_ID;
                frm.textBox2.Text = Guest_ID;
                frm.textBox4.Text = Room_No;
                frm.textBox5.Text = Room_Type;
                frm.textBox6.Text = Room_Price;
                frm.numericUpDown1.Text = Occupants;
                frm.label10.Text = Booking_Date;
                frm.dateTimePicker1.Text = Arrival_Date;
                frm.dateTimePicker2.Text = Departure_Date;
                frm.label13.Text = "update";
                frm.AddDisableButton();
                frm.ShowDialog();


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            reports frm = new reports();

            ReportDocument cryRpt = new ReportDocument();
            string strReportPath = Application.StartupPath + @"\bookingdetailsReports.rpt";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            da.SelectCommand = cmd;
            cmd.Connection = cmd.Connection = Class1.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_sel_rpt_booking";
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
    }
    }
