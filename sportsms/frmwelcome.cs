using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sportsms
{
    public partial class frmwelcome : Form
    {
        public frmwelcome()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlgames.Hide();
        }

        private void LOGINREGISTRATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmloginreg f1 = new frmloginreg();
            f1.Show ();
        }

        private void STUDENTREGISTRATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmstudentreg f1 = new frmstudentreg();
            f1.Show();
        }

        private void TOURNAMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtour f1 = new frmtour();
            f1.Show();
        }

        private void GAMESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlgames.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            pnlgames.Hide();
        }

        private void LEVELToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void COLLEGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcollege f1 = new frmcollege();
            f1.Show();
        }

        private void STATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmstate f1 = new frmstate();
            f1.Show();
        }

        private void LOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("DO YOU WANT TO LOGOUT?", "Logout", MessageBoxButtons.OKCancel) == DialogResult.OK )
            {
                frmlogin1 f1 = new frmlogin1();
                f1.Show();
            }

        
        
        }

        private void EXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO EXIT?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void PLAYERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmfplyr f1 = new frmfplyr();
            f1.Show();
        }

        private void TOURNAMENTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmfttour f1 = new frmfttour();
            f1.Show();
        }

        private void PHOTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmfootballphotos f1 = new frmfootballphotos();
            f1.Show();
        }

        private void PLAYERSToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmcplyr f1 = new frmcplyr();
            f1.Show();
        }

        private void TOURNAMENTToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmcrtour f1 = new frmcrtour();
            f1.Show();
        }

        private void PHOTOSToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmcrphotos f1 = new frmcrphotos();
            f1.Show();
        }

        private void PLAYERSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmhockeyplyr f1 = new frmhockeyplyr();
            f1.Show();
        }

        private void TOURNAMENTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmhtour f1 = new frmhtour();
            f1.Show();
        }

        private void PHOTOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmhopho f1 = new frmhopho();
            f1.Show();
        }

        private void PLAYERSToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmvolleyplr f1 = new frmvolleyplr();
            f1.Show();
        }

        private void TOURNAMENTToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmvltour f1 = new frmvltour();
            f1.Show();
        }

        private void PHOTOSToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmvophotos f1 = new frmvophotos();
            f1.Show();
        }

        private void PLAYERSToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmbad f1 = new frmbad();
            f1.Show();
        }

        private void TOURNAMENTToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmbadtour f1 = new frmbadtour();
            f1.Show();
        }

        private void PHOTOSToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmbadphoto f1 = new frmbadphoto();
            f1.Show();
        }

        private void PLAYERSToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmbasket f1 = new frmbasket();
            f1.Show();
        }

        private void TOURNAMENTToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmbaskettour f1 = new frmbaskettour();
            f1.Show();
        }

        private void PHOTOSToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmbasketphotos f1 = new frmbasketphotos();
            f1.Show();
        }

        private void wINNERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmwinner f1 = new frmwinner();
            f1.Show();
        }

        private void wINNERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmwinner1 f1 = new frmwinner1();
            f1.Show();
        }

        private void wINNERToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmwinner2 f1 = new frmwinner2();
            f1.Show();
        }

        private void wINNERToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmwinner3 f1 = new frmwinner3();
            f1.Show();
        }

        private void wINNERToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmwinner4 f1 = new frmwinner4();
            f1.Show();
        }

        private void wINNERToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmwinner5 f1 = new frmwinner5();
            f1.Show();

        }
    }
}
