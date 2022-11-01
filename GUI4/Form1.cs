using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace GUI4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(pMat1.Enabled)
            {
                pMat1.Hide();
                pMat0.Show();
            }
            if (tMk.PasswordChar == '●')
            {
                tMk.PasswordChar = '\0';
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pMat0.Enabled)
            {
                pMat0.Hide();
                pMat1.Show();
            }
            if (tMk.PasswordChar == '\0')
            {
                tMk.PasswordChar = '●';
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Tạo mặc định cho toolbox
            pMat0.Hide();
            bĐx.Hide();
            bĐx.Hide();
            txtDenDg.ReadOnly = true;
            btnHuyPhong.Hide();
            groupBox13.Text = "đã đặt";
            btnHuyPhong.Visible = true;
            #endregion 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if(tTk.Text == "1" && tMk.Text == "1")
            {
                MessageBox.Show("thanh cong","đã đăng nhập",MessageBoxButtons.OK);
                
                bĐx.Show();
                bĐn.Hide();
                bQuen.Hide();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(txtDenDg.ReadOnly== true) { txtDenDg.ReadOnly = false; }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tTk_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {

        }

        private void pTuDen_Click(object sender, EventArgs e)
        {
            txtDenDg.ReadOnly = false;
        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }
    }
}
