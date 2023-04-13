using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GYMSYS
{
    public partial class ViewAttendance : MetroFramework.Forms.MetroForm
    {
        public ViewAttendance()
        {
            InitializeComponent();
        }

        private void ViewAttendance_Load(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            con1.Open();
            cmd1.CommandText = "Select Att_Date from record";
            SqlDataReader rd22 = cmd1.ExecuteReader();
            while (rd22.Read())
            {
                comboBox1.Items.Add(rd22.GetValue(0));
            }
            rd22.Close();


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from record";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            record_grid.DataSource = DS.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
