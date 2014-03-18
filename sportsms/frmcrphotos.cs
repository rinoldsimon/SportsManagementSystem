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
    public partial class frmcrphotos : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmcrphotos()
        {
            InitializeComponent();
        }
        private void frmcrphotos_Load(object sender, EventArgs e)
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
            cmd.CommandText = "select * from tbl_cricket";
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
                    i = i + 1;
                }
            }
            cn.Close();
        }
      
      
      
        private void clear()
        {
            txtphoto.Text = "";
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtphoto.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            System.IO.StreamReader OpenFile = new System.IO.StreamReader(openFileDialog1.FileName);
            txtphoto.Text = openFileDialog1.FileName;
            OpenFile.Close();
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


        private void txtphoto_TextChanged_1(object sender, EventArgs e)
        {
            PictureBox1.ImageLocation = txtphoto.Text;
        }


        private void Button2_Click_1(object sender, EventArgs e)
        {
            if (txtphoto.Text == "")
            {
                MessageBox.Show("select usertype");
            }
            else
            {
                string q = "insert into tbl_cricket(photo) values('" + txtphoto.Text + "')";
                dosomething(q);
                MessageBox.Show("saved");
                clear();
                loadgrid();
            }
        }
        private void Button3_Click_1(object sender, EventArgs e)
        {
            string q = "delete from tbl_cricket where photo='" + DataGridView1.CurrentRow.Cells[0].Value + "'";
            dosomething(q);
            MessageBox.Show("deleted successfully");
            clear();
            loadgrid();
        }

    }
}
