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
    public partial class frmwinner1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmwinner1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtwinner.Text != "")
            {

                int i = 0;
                DataGridView1.Rows.Clear();

                string q = "select * from tbl_streg where tname = '" + txtwinner.Text + "'";
                //string q = "select * from tbl_football ";
                try
                {
                    cn.Open();
                    cmd.CommandText = q;
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataGridView1.Rows.Add();
                        DataGridView1.Rows[i].Cells[0].Value = dr[0];
                        DataGridView1.Rows[i].Cells[1].Value = dr[1];
                        //DataGridView1.Rows[i].Cells[2].Value = dr[0];
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
                //MessageBox.Show("Search Completed");
                cn.Close();

            }
            else
            {
                MessageBox.Show("Enter Team");
            }
        }

        private void frmwinner1_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
        }

        private void txtwinner_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
