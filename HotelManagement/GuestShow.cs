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
    public partial class GuestShow : Form
    {
        public GuestShow()
        {
            InitializeComponent();
        }
       

        public void LoadGrid()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con; ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Guest_ID, Guest_Name, Age, Contact_Number from guest";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void GuestShow_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                booking_form frm = (booking_form)Application.OpenForms["booking_form"];
                frm.textBox2.Text = dataGridView1.CurrentRow.Cells["Column1"].Value.ToString();
                frm.textBox3.Text = dataGridView1.CurrentRow.Cells["Column2"].Value.ToString();

                this.Close();
            }
        }
    }
}
