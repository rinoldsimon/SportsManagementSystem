using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace sportsms
{
    public partial class frmbadtour : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmbadtour()
        {
            InitializeComponent();
        }

        private void frmbadtour_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            loadgrid();
        }
        private void loadgrid()
        {
            //sql = "select * from tbl_reg"
            //If rs.State = 1 Then rs.Close()
            //rs.Open(sql, conn)
            DataGridView1.Rows.Clear();
            cn.Open();
            cmd.CommandText = "select * from tbl_tour where (tournament = N'BADMINTON')";
            int i;
            i = 0;
            //Do While Not rs.EOF
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataGridView1.Rows.Add();
                    DataGridView1.Rows[i].Cells[0].Value = dr[0];
                    DataGridView1.Rows[i].Cells[1].Value = dr[1];
                    DataGridView1.Rows[i].Cells[2].Value = dr[2];
                    DataGridView1.Rows[i].Cells[3].Value = dr[3];
                    i = i + 1;
                }
            }
            cn.Close();
        }
    }
}
