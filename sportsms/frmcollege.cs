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
    public partial class frmcollege : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmcollege()
        {
            InitializeComponent();
        }

        private void frmcollege_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            collegename();
            sport();
        }
        private void  collegename()
        {
        cmdcollege.Items.Clear();
        cn.Open();
        cmd.CommandText = "select distinct clgname from tbl_streg";
        //sql = "select distinct clgname from tbl_streg "
        //If rs.State = 1 Then rs.Close()
        //rs.Open(sql, conn)
        //Do While rs.EOF = False
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
            cmdcollege.Items.Add(dr[0]);
            //rs.MoveNext()
        //Loop
                     }
            }
            cn.Close();
        }
    private void  sport()
    {
        cmdsport.Items.Clear();
        cn.Open();
        cmd.CommandText = "select distinct sport from tbl_streg";
        //sql = "select distinct sport from tbl_streg "
        //If rs.State = 1 Then rs.Close()
        //rs.Open(sql, conn)
        //Do While rs.EOF = False
        dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
        cmdsport.Items.Add(dr[0]);
          //  rs.MoveNext()
        //Loop
                }
            }
            cn.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmbest f1 = new frmbest ();
            f1.Show ();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
if (cmdcollege .Text != "" & cmdsport .Text != "")
{

            int i = 0;
        DataGridView1.Rows.Clear();

        string q = "select * from tbl_streg where clgname='" + cmdcollege.Text + "' and sport='" + cmdsport.Text + "'";
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
                    DataGridView1.Rows[i].Cells[2].Value = dr[2];
                    DataGridView1.Rows[i].Cells[3].Value = dr[3];
                    DataGridView1.Rows[i].Cells[4].Value = dr[4];
                    DataGridView1.Rows[i].Cells[5].Value = dr[5];
                    DataGridView1.Rows[i].Cells[6].Value = dr[6];
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
                MessageBox.Show("Enter sport");
            }


            
        }
    }
}
