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
    public partial class frmbest : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmbest()
        {
            InitializeComponent();
        }

        private void frmbest_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            collegename();
            sport();
        }
        private void collegename()
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
        private void sport()
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

        private void Button1_Click(object sender, EventArgs e)
        {
            if (cmdcollege.Text != "" & cmdsport.Text != "")
            {

                int i = 0;
                dgvpro.Rows.Clear();

                string q = "select sno,name,clgname,age from tbl_streg where clgname='"+ cmdcollege.Text + "' and sport='" + cmdsport.Text + "'";
                try
                {
                    cn.Open();
                    cmd.CommandText = q;
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvpro.Rows.Add();
                        dgvpro.Rows[i].Cells[0].Value = dr[0];
                        dgvpro.Rows[i].Cells[1].Value = dr[1];
                        dgvpro.Rows[i].Cells[2].Value = dr[2];
                        dgvpro.Rows[i].Cells[3].Value = dr[3];
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
        private void dosomething(String q)
        {
            try
            {
                cn.Open();
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e)
            {
                cn.Close();
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for (int a = 0; a <= dgvpro.Rows.Count - 1; a++)
            {

            if (dgvpro.Rows[a].Cells[4].Selected  == true  ) 
            {

                string q= "insert into tbl_best(sport,name,clgname,age) values ('" + cmdsport.Text + "', '" + dgvpro.Rows[a].Cells[1].Value + "','" + dgvpro.Rows[a].Cells[2].Value + "','" + dgvpro.Rows[a].Cells[3].Value + "')";
                dosomething(q);
            }
            }
        MessageBox .Show ("saved successfully");
        }

    }
}
