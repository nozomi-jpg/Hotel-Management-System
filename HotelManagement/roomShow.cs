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
    public partial class roomShow : Form
    {
        public roomShow()
        {
            InitializeComponent();
        }
        

        private void roomShow_Load(object sender, EventArgs e)
        {
            LoadGrid();
            
        }
        public void LoadGrid()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con; ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Room_No, Room_Type, Room_Class, Max_Occupants, Room_Price from room WHERE Room_No IN (Select Room_No from booking_details WHERE Departure_Date < GetDate()) or Room_No not in (Select Room_No from booking_details)";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                booking_form frm = (booking_form)Application.OpenForms["booking_form"];
                frm.textBox4.Text = dataGridView1.CurrentRow.Cells["Column1"].Value.ToString();
                frm.textBox5.Text = dataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
                frm.textBox6.Text = dataGridView1.CurrentRow.Cells["Column5"].Value.ToString();

                this.Hide();
            }
            
        }
}
}
