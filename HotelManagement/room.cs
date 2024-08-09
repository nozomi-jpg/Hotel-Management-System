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
    public partial class room : Form
    {
        public room()
        {
            InitializeComponent();
        }
        public static string Room_No = "";
        public static string Room_Type = "";
        public static string Room_Class = "";
        public static string Max_Occupants = "";
        public static string Room_Price = "";

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            add_room frm = new add_room();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int row = dataGridView1.CurrentRow.Index;
                Room_No = Convert.ToString(dataGridView1[0, row].Value);
                Room_Type = Convert.ToString(dataGridView1[1, row].Value);
                Room_Class = Convert.ToString(dataGridView1[2, row].Value);
                Max_Occupants = Convert.ToString(dataGridView1[3, row].Value);
                Room_Price = Convert.ToString(dataGridView1[4, row].Value);

                add_room frm = new add_room();
                frm.comboBox1.Text = Room_Type;
                frm.textBox1.Text = Room_No;
                
                frm.textBox6.Text = Room_Class;
                frm.numericUpDown1.Text = Max_Occupants;
                frm.textBox2.Text = Room_Price;
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
                    Room_No = Convert.ToString(dataGridView1[0, row].Value);

                    Class1 NewConnection = new Class1();
                    NewConnection.open_connection();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Class1.con;

                    cmd.CommandText = "Delete from guest where Room_No = @Room_No";
                    cmd.Parameters.AddWithValue("@Room_No", Room_No);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfully deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {


                int row = dataGridView1.CurrentRow.Index;
                Room_No = Convert.ToString(dataGridView1[0, row].Value);
               Room_Type = Convert.ToString(dataGridView1[1, row].Value);
                Room_Class = Convert.ToString(dataGridView1[2, row].Value);
                Max_Occupants = Convert.ToString(dataGridView1[3, row].Value);
                Room_Price = Convert.ToString(dataGridView1[4, row].Value);

                add_room frm = new add_room();
                frm.textBox1.Text = Room_No;
                frm.comboBox1.Text = Room_Type;
                frm.textBox6.Text = Room_Class;
                frm.numericUpDown1.Text = Max_Occupants;
                frm.textBox2.Text = Room_Price;
               

            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        public void LoadGrid()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con; ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_sel_room_02";
            cmd.Parameters.AddWithValue("Room_No", textBox1.Text);
            cmd.Parameters.AddWithValue("Room_Type", textBox1.Text);
            cmd.Parameters.AddWithValue("Room_Class", textBox1.Text);

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void room_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            add_room frm = new add_room();
            frm.UpdateDisableButton();
            frm.GetID();
            frm.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int row = dataGridView1.CurrentRow.Index;
                Room_No = Convert.ToString(dataGridView1[0, row].Value);
                Room_Type = Convert.ToString(dataGridView1[1, row].Value);
                Room_Class = Convert.ToString(dataGridView1[2, row].Value);
                Max_Occupants = Convert.ToString(dataGridView1[3, row].Value);
                Room_Price = Convert.ToString(dataGridView1[4, row].Value);

                add_room frm = new add_room();
                frm.label7.Text = "update";

                frm.textBox1.Text = Room_No;
                frm.comboBox1.Text = Room_Type;
                frm.textBox6.Text = Room_Class;
                frm.numericUpDown1.Text = Max_Occupants;
                frm.textBox2.Text = Room_Price;
                frm.label8.Text = "update";
                frm.DisableComboBox();
                frm.DisableButton();
                frm.UpdateDisableButton();
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
                    Room_No = Convert.ToString(dataGridView1[0, row].Value);

                    Class1 NewConnection = new Class1();
                    NewConnection.open_connection();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Class1.con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "sp_del_room_02";
                    cmd.Parameters.AddWithValue("@Room_No", Room_No);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfully deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
            }
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

        private void button9_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con; ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_sort_room_02";
            cmd.Parameters.AddWithValue("Room_Type", button9.Enabled);
            

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con; ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_sort_room_03";
            cmd.Parameters.AddWithValue("Room_No", button12.Enabled);


            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            reports frm = new reports();

            ReportDocument cryRpt = new ReportDocument();
            string strReportPath = Application.StartupPath + @"\roomReports.rpt";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            da.SelectCommand = cmd;
            cmd.Connection = cmd.Connection = Class1.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_sel_rpt_room";
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
