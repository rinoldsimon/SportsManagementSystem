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
    public partial class frmstate : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmstate()
        {
            InitializeComponent();
        }

        private void frmstate_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            loadgrid();
            sport();
        }
        private void sport()
        {
            cmdstate.Items.Clear();
            cn.Open();
            cmd.CommandText = "select distinct sport from tbl_best";
            //sql = "select distinct sport from tbl_streg "
            //If rs.State = 1 Then rs.Close()
            //rs.Open(sql, conn)
            //Do While rs.EOF = False
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cmdstate.Items.Add(dr[0]);
                    //  rs.MoveNext()
                    //Loop
                }
            }
            cn.Close();
        }
        private void loadgrid()
        {
            //sql = "select * from tbl_reg"
            //If rs.State = 1 Then rs.Close()
            //rs.Open(sql, conn)
            DataGridView1.Rows.Clear();
            cn.Open();
            cmd.CommandText = "select * from tbl_best where (sport ='" + cmdstate.Text + "')";
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
                   // DataGridView1.Rows[i].Cells[3].Value = dr[3];
                    i = i + 1;
                }
            }
            cn.Close();
        }

        private void cmdstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdstate.Text != "" )
            {

                int i = 0;
                DataGridView1.Rows.Clear();

                string q = "select * from tbl_best where sport='" + cmdstate.Text + "'";
                try
                {
                    cn.Open();
                    cmd.CommandText = q;
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataGridView1.Rows.Add();
                        DataGridView1.Rows[i].Cells[0].Value = dr[1];
                        DataGridView1.Rows[i].Cells[1].Value = dr[2];
                        DataGridView1.Rows[i].Cells[2].Value = dr[3];
                        //DataGridView1.Rows[i].Cells[3].Value = dr[3];
                        //DataGridView1.Rows[i].Cells[4].Value = dr[4];
                        //DataGridView1.Rows[i].Cells[5].Value = dr[5];
                        //DataGridView1.Rows[i].Cells[6].Value = dr[6];
                        i = i + 1;
                    }
                }
                catch (Exception e1)
                {
                    cn.Close();
                    MessageBox.Show(e1.Message.ToString());
                }
                MessageBox.Show("Search Completed");
                cn.Close();

            }
            else
            {
                MessageBox.Show("Enter college name and sports to Search Record");
            }
        }
    }
}
