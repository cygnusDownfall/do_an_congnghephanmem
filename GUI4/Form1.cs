using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using BLL4;
using DAL4;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI4
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }


        //----------------------hamgomgon--------------------------
        #region Ham de lam gon
      /*  public void dgvDP(int i, string a)
        { dgvDatphong.Columns[i].HeaderText = a; }*/
        public void notifi()
        {
            tabPage10.Text = "Thông báo mới 🔴 ";
        }
        #endregion
        
        
        
        private void loadNd ()
        {
            DataTable Nd = DataBase.dt("select * from DANGNHAP");
            dgvNguoidung.DataSource = Nd;
          
        }
        private void loadKh ()
        {
            DataTable Kh = DataBase.dt("select * from KHACHHANG");
            dgvKhachhang.DataSource = Kh;
           
        }
        private void loadDV()
        {
            DataTable dv = DataBase.dt("select * from DICHVU");
            dgvDichvu.DataSource = dv;

        }

        private void loadFPhong()
        {
             DataTable dt = DataBase.dt("select * from PHIEUDATPHONG");
            dgvDatphong.DataSource = dt;
           
        }
        private void loadPhong()
        {
            DataTable dt = DataBase.dt("select * from PHONG");
            advancedDataGridView1.DataSource = dt;
        }
        private void loadLPhong()
        {
            DataTable dt = DataBase.dt("select * from LOAIPHONG");
            advancedDataGridView2.DataSource = dt;
        }
        private void loadDichvu()
        {
            DataTable dv = DataBase.dt("select * from LOAIDICHVU");
           
            foreach (DataRow d in dv.Rows)
            {
                string a = "";
                string b = "";
                a += d[1].ToString() + " - " + d[2].ToString();
                b += d[2].ToString();
                clbdichvu.Items.Add(a);
               
            }
        }
        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.pHONGBindingSource.Sort = this.advancedDataGridView1.SortString;
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.pHONGBindingSource.Filter = this.advancedDataGridView1.FilterString;
        }

        private void dgvNguoidung_SortStringChanged(object sender, EventArgs e)
        {
            this.dANGNHAPBindingSource.Sort = this.dgvNguoidung.SortString;
        }

        private void dgvNguoidung_FilterStringChanged(object sender, EventArgs e)
        {
            this.dANGNHAPBindingSource.Filter = this.dgvNguoidung.FilterString;
        }

        private void dgvKhachhang_SortStringChanged(object sender, EventArgs e)
        {
            this.kHACHHANGBindingSource.Sort = this.dgvKhachhang.SortString;
        }

        private void dgvKhachhang_FilterStringChanged(object sender, EventArgs e)
        {
            this.kHACHHANGBindingSource.Filter = this.dgvKhachhang.FilterString;
        }

        private void advancedDataGridView2_SortStringChanged(object sender, EventArgs e)
        {
            this.lOAIPHONGBindingSource.Sort = this.advancedDataGridView2.SortString;
        }

        private void advancedDataGridView2_FilterStringChanged(object sender, EventArgs e)
        {
            this.lOAIPHONGBindingSource.Filter = this.advancedDataGridView2.FilterString;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKSDataSet3.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter1.Fill(this.qLKSDataSet3.KHACHHANG);
            // TODO: This line of code loads data into the 'qLKSDataSet3.DICHVU' table. You can move, or remove it, as needed.
            this.dICHVUTableAdapter1.Fill(this.qLKSDataSet3.DICHVU);
            // TODO: This line of code loads data into the 'qLKSDataSet3.PHONG' table. You can move, or remove it, as needed.
            this.pHONGTableAdapter1.Fill(this.qLKSDataSet3.PHONG);
            // TODO: This line of code loads data into the 'qLKSDataSet3.LOAIPHONG' table. You can move, or remove it, as needed.
            this.lOAIPHONGTableAdapter1.Fill(this.qLKSDataSet3.LOAIPHONG);
            // TODO: This line of code loads data into the 'qLKSDataSet3.PHIEUDATPHONG' table. You can move, or remove it, as needed.
            this.pHIEUDATPHONGTableAdapter1.Fill(this.qLKSDataSet3.PHIEUDATPHONG);
            // TODO: This line of code loads data into the 'qLKSDataSet3.DANGNHAP' table. You can move, or remove it, as needed.
            this.dANGNHAPTableAdapter1.Fill(this.qLKSDataSet3.DANGNHAP);
            // TODO: This line of code loads data into the 'qLKSDataSet2.PHIEUDATPHONG' table. You can move, or remove it, as needed.
            /*this.pHIEUDATPHONGTableAdapter.Fill(this.qLKSDataSet2.PHIEUDATPHONG);
            // TODO: This line of code loads data into the 'qLKSDataSet1.DICHVU' table. You can move, or remove it, as needed.
            this.dICHVUTableAdapter.Fill(this.qLKSDataSet1.DICHVU);


            // TODO: This line of code loads data into the 'qLKSDataSet.LOAIPHONG' table. You can move, or remove it, as needed.
            this.lOAIPHONGTableAdapter.Fill(this.qLKSDataSet.LOAIPHONG);
            // TODO: This line of code loads data into the 'qLKSDataSet.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.qLKSDataSet.KHACHHANG);
            // TODO: This line of code loads data into the 'qLKSDataSet.DANGNHAP' table. You can move, or remove it, as needed.
            this.dANGNHAPTableAdapter.Fill(this.qLKSDataSet.DANGNHAP);
            // TODO: This line of code loads data into the 'qLKSDataSet.PHONG' table. You can move, or remove it, as needed.
            this.pHONGTableAdapter.Fill(this.qLKSDataSet.PHONG);
            // TODO: This line of code loads data into the 'qLKSDataSet.PHIEUDATPHONG' table. You can move, or remove it, as needed.
            this.pHIEUDATPHONGTableAdapter.Fill(this.qLKSDataSet.PHIEUDATPHONG);*/


            #region Tạo mặc định cho toolbox
            pMat0.Hide();
            bĐx.Hide();
            bĐx.Hide();
            btnthuephong.Hide();
            btnHuyPhong.Hide();
            
            btnHuyPhong.Visible = true;
            groupBox17.Hide();
            cbCvu.Items.Add("Quản lý");
            cbCvu.Items.Add("Nhân viên");
            cbreset.Items.Add("Bảng Người Dùng");
            cbreset.Items.Add("Bảng Đặt Phòng");
            cbreset.Items.Add("Bảng Khách Hàng");
            cbreset.Items.Add("Bảng Mã Phòng");
            cbreset.Items.Add("Bảng Loại Phòng");
            #endregion

            DataTable t = DataBase.dt("select * from PHIEUDATPHONG where day(ngaythue) < day(GETDATE()) and maphong in (select maphong from PHONG where trangthai = 1)");
            
            foreach(DataRow d in t.Rows)
            {
                string a = "";
                a += d[0].ToString();
                lbhethandat.Items.Add(a);
            }
            DataTable k = DataBase.dt("select * from PHIEUDATPHONG where day(ngaytra) <= day(GETDATE()) and maphong in (select maphong from PHONG where trangthai = 2)");

            foreach (DataRow d in k.Rows)
            {
                string a = "";
                a += d[0].ToString();
                lbhethanthue.Items.Add(a);
            }


            loadDichvu();



        }

        private void dgvDatphong_SortStringChanged(object sender, EventArgs e)
        {
            this.pHIEUDATPHONGBindingSource.Sort = this.dgvDatphong.SortString;
        }

        private void dgvDatphong_FilterStringChanged(object sender, EventArgs e)
        {
            this.pHIEUDATPHONGBindingSource.Filter = this.dgvDatphong.FilterString;

        }

        //-------------------------------tab1-------------------------------------
        #region tab1
       
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (pMat1.Enabled)
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

        private void dgvNguoidung_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            


        }
        private void bQuen_Click(object sender, EventArgs e)
        {
            groupBox17.Show();
        }
        #endregion
        //-------------------------------tab2-------------------------------------------
        #region tab2
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (txtDenDg.ReadOnly == true) { txtDenDg.ReadOnly = false; }
        }
        private void pTuDen_Click(object sender, EventArgs e)
        {
            txtDenDg.ReadOnly = false;
        }
        private void dgvDatphong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                
        }
       
         private void bĐx_Click(object sender, EventArgs e)
        {
            notifi();
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl7.Visible = false;
            tabControl4.Visible = false;

        }
        #endregion
        //-------------------------------tab3---------------------------------------------------

        //=======================================================================================
       

        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
     
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            
                string c = "";

            if (radNam.Checked)
            {
                c = @"Nam";
            }
            else
            {
                c = @"Nữ";
            }
            SqlCommand cmd = DataBase.Store("ThemKH");
            
                cmd.Parameters.Add("@makh", SqlDbType.NVarChar).Value = txtMKH.Text;
                cmd.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = txtTKH.Text;
                cmd.Parameters.Add("@cmnd", SqlDbType.Int).Value = int.Parse(txtCMND.Text);
                cmd.Parameters.Add("@sinh", SqlDbType.Date).Value = datebirth.Value;
                cmd.Parameters.Add("@tuoi", SqlDbType.Int).Value = int.Parse(txttuoi.Text);
                cmd.Parameters.Add("@gitinh", SqlDbType.NVarChar).Value = c.ToString();
                cmd.Parameters.Add("@sdt", SqlDbType.Int).Value = int.Parse(txtphone.Text);
                cmd.Parameters.Add("@dchi", SqlDbType.NVarChar).Value = txtDiachi.Text;
                cmd.ExecuteNonQuery();
                loadKh();
            listBox1.Items.Add(txtMKH.Text);
            listBox1.Text = txtMKH.Text;
        }
        private void btnSuaKH_Click(object sender, EventArgs e)
        {
              
                    string c = "";

                    if (radNam.Checked)
                    {
                        c = @"Nam";
                    }
                    else
                    {
                        c = @"Nu";
                    }
                    SqlCommand cmd = DataBase.Store("SuaKH");

                    cmd.Parameters.Add("@makh", SqlDbType.NVarChar).Value = txtMKH.Text;
                    cmd.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = txtTKH.Text;
                    cmd.Parameters.Add("@cmnd", SqlDbType.Int).Value = int.Parse(txtCMND.Text);
                    cmd.Parameters.Add("@sinh", SqlDbType.Date).Value = datebirth.Value;
                    cmd.Parameters.Add("@tuoi", SqlDbType.Int).Value = int.Parse(txttuoi.Text);
                    cmd.Parameters.Add("@gitinh", SqlDbType.NVarChar).Value = c.ToString();
                    cmd.Parameters.Add("@sdt", SqlDbType.Int).Value = int.Parse(txtphone.Text);
                    cmd.Parameters.Add("@dchi", SqlDbType.NVarChar).Value = txtDiachi.Text;
                    cmd.ExecuteNonQuery();

                  loadKh();
            //listBox1.Items
                
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
                
                SqlCommand cmd = DataBase.Store("XoaKH");
            
                cmd.Parameters.Add("@makh", SqlDbType.NVarChar).Value = txtMKH.Text;

                cmd.ExecuteNonQuery();
                loadKh();
            
           
        }

       

      

        private void btnThemNd_Click(object sender, EventArgs e)
        {
            string b = cbCvu.Text;
            if (b == "Nhân viên")
            {
                b = "False";
            }
            else
            {
                b = "True";
            }
            
            SqlCommand cmd = DataBase.Store("ThemNd");
            cmd.Parameters.Add("@tk", SqlDbType.NVarChar).Value = tTenTK.Text;
                cmd.Parameters.Add("@mk", SqlDbType.NVarChar).Value = tMkNd.Text;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tTenNd.Text;
                cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = tSĐTNd.Text;
                cmd.Parameters.Add("@cmnd", SqlDbType.NVarChar).Value = tCMNDNd.Text;
            cmd.Parameters.Add("@Cvu", SqlDbType.Bit).Value = b.ToString();
            
            cmd.ExecuteNonQuery();
           loadNd();

        }

        private void btnXoaNd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = DataBase.Store("XoaNd");
            cmd.Parameters.Add("@tk", dgvNguoidung.SelectedRows[0].Cells[0].Value);
            cmd.ExecuteNonQuery();
            loadNd();
        }

        private void dgvDatphong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        
        }

     

        private void btndatphieu_Click(object sender, EventArgs e)
        {
            DataTable dt = DataBase.dt("select maphieudatphong from PHIEUDATPHONG");
            foreach(DataRow i in dt.Rows)
            {
                
                if (txtdatphieu.Text == i[0].ToString())
                {
                    MessageBox.Show("mã trùng", "Thông báo", MessageBoxButtons.OK);
                    break;
                }
                else
                {
                    txtMaPhieu.Text = txtdatphieu.Text;
                    txtMaKH.Text = listBox1.SelectedItem.ToString();
                    tabControl1.SelectedTab = tabPage2;
                    tabControl3.SelectedTab = tabPage6;


                }

            }
           

        }
        private void btnXN_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = "";
            try
            {
                DataTable t = DataBase.dt("select taikhoan,matkhau from DANGNHAP where DANGNHAP.SĐT = " + txtQSDT.Text + " AND DANGNHAP.CMND =" + txtQCMND.Text + "");
                DataRow data = t.Rows[0];
                a += "Tài khoản là : " + data[0].ToString() + "\n";
                a += "Mật khẩu là : " + data[1].ToString();
                MessageBox.Show(a.ToString(), "thong bao", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                DataTable k = DataBase.dt("select SĐT from DANGNHAP where DANGNHAP.Chucvu = 1");
                foreach (DataRow row in k.Rows)
                {
                    b += "\n SĐT : " + row[0].ToString();
                }
                MessageBox.Show("Không tìm thấy, hãy liên hệ với quản lý, " + b.ToString() + "", "Thong bao", MessageBoxButtons.OK);
            }
        }

       
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.advancedDataGridView1.Rows[e.RowIndex];
                txtMP.Text = row.Cells[0].Value.ToString();
                //txtMLP.Text = row.Cells[4].Value.ToString();
            }
        }
       
        private void dgvDatphong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = " ";
            if (e.RowIndex >= 0)
            {
                
                
                DataGridViewRow row = this.dgvDatphong.Rows[e.RowIndex];
                txtMaPhieu.Text = row.Cells[0].Value.ToString();
                txtMaKH.Text = row.Cells[1].Value.ToString();
                txtMaPhong.Text = row.Cells[2].Value.ToString();
                dateĐP.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                nmNgayO.Value = int.Parse(row.Cells[5].Value.ToString());
                cbDatcoc.Text = row.Cells[6].Value.ToString();
              
                
                DataTable t = DataBase.dt("select trangthai from PHONG where maphong = '" + txtMaPhong.Text + "'");
                DataRow d = t.Rows[0];

                if (d[0].ToString() == "1")
                {
                    btnthuephong.Show();
                   
                }
                else
                {
                    btnthuephong.Hide();
                }
            }
        }

        private void dgvNguoidung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string b;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvNguoidung.Rows[e.RowIndex];
                tTenTK.Text = row.Cells[0].Value.ToString();
                tMkNd.Text = row.Cells[1].Value.ToString();
                tTenNd.Text = row.Cells[2].Value.ToString();
                tSĐTNd.Text = row.Cells[3].Value.ToString();
                tCMNDNd.Text = row.Cells[4].Value.ToString();
                b = row.Cells[5].Value.ToString();
                if (b == "False")
                {
                    b = "Nhân viên";
                }
                else
                {
                    b = "Quản lý";
                }
                cbCvu.Text = b.ToString();
            }
        }

      
       
        private void dgvKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string c = "";
   
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvKhachhang.Rows[e.RowIndex];
                txtMKH.Text = row.Cells[0].Value.ToString();
                txtTKH.Text = row.Cells[1].Value.ToString();
                txttuoi.Text = row.Cells[4].Value.ToString();
                txtCMND.Text = row.Cells[2].Value.ToString();
                datebirth.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                c = row.Cells[5].Value.ToString();
                if (c == "Nam")
                {
                    radNam.Checked = true;
                    radNữ.Checked = false;
                }
                else
                {
                    radNữ.Checked = true;
                    radNam.Checked = false;
                }
                txtphone.Text = row.Cells[6].Value.ToString();
                txtDiachi.Text = row.Cells[7].Value.ToString();
                
            }

        }

        private void advancedDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.advancedDataGridView2.Rows[e.RowIndex];
                DataTable dt = DataBase.dt("Select * from PHONG where maloaiphong = '" + row.Cells[0].Value.ToString() + "'");
                advancedDataGridView1.DataSource= dt;
                txtMLP.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = DataBase.dt("select * from PHONG where maloaiphong = '" + txtMLP.Text + "'");
            advancedDataGridView1.DataSource = dt;
            DataTable td = DataBase.dt("select * from LOAIPHONG where maloaiphong = '" + txtMLP.Text + "'");
            advancedDataGridView2.DataSource = td;
            txtMP.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMP.Text == "")
            {
                MessageBox.Show(" - Click chọn loại phòng ở bảng 1 để tìm mã phòng \n - Click chọn để lấy mã phòng ở bảng 2", "Gợi ý", MessageBoxButtons.OK);
            }
            else
            {
                txtMaPhong.Text = txtMP.Text;
                tabControl3.SelectedTab = tabPage6;
            }
        }
        //********************************************************************************************************************************
        
        private void btnĐatPhong_Click(object sender, EventArgs e)
        {
            //                             insert into PHIEUDATPHONG(maphieudatphong, makhachhang, maphong, ngaythue, ngaytra, songayo, datcoc) values('FP02', 'MK011', 'MO05', '2022-12-05', dateadd(day, 1, '2022-12-06'), 1, 3123, 4324, 3123)
            SqlCommand cmd = DataBase.Cmd("insert into PHIEUDATPHONG(maphieudatphong,makhachhang,maphong,ngaythue,ngaytra,songayo,datcoc) values ('"+txtMaPhieu.Text+"','"+txtMaKH.Text+"','"+txtMaPhong.Text+"','"+dateĐP.Value+"',dateadd(day,"+nmNgayO.Value+",'"+dateĐP.Value+"'),"+nmNgayO.Value.ToString()+","+cbDatcoc.Text.ToString()+")");
            cmd.ExecuteNonQuery();
            loadFPhong();
        }

        private void btnSuaNd_Click(object sender, EventArgs e)
        {

        }

        private void dgvKhachhang_KeyUp(object sender, KeyEventArgs e)
        {
            
                foreach(DataGridViewRow dt in dgvKhachhang.SelectedRows) 
                {
                    dgvKhachhang.Rows.Remove(dt);
                }
            
        }

        private void btnthuephong_Click(object sender, EventArgs e)
        {
             SqlCommand cmd = DataBase.Cmd("update PHONG set trangthai = 2 where maphong = '" +txtMaPhong.Text + "'");
                   cmd.ExecuteNonQuery();
            loadPhong();
            
            
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void btnHetHanThue_Click(object sender, EventArgs e)
        {
            DataTable t = DataBase.dt("select * from PHIEUDATPHONG where day(ngaythue) < day(GETDATE()) and maphong in (select maphong from PHONG where trangthai = 1)");
            dgvDatphong.DataSource= t;
        }

        private void lbhethandat_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DataBase.dt("select * from PHIEUDATPHONG where maphieudatphong = '" + lbhethandat.SelectedItem.ToString() + " '");
                dgvDatphong.DataSource= dt;
        }

        private void lbhethanthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DataBase.dt("select * from PHIEUDATPHONG where maphieudatphong = '" + lbhethanthue.SelectedItem.ToString() + " '");
            dgvDatphong.DataSource = dt;
        }

        private void btnHuyphieuQH_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = DataBase.Cmd("delete from PHIEUDATPHONG where day(ngaythue) < day(GETDATE()) and maphong in (select maphong from PHONG where trangthai = 1)");
            cmd.ExecuteNonQuery();
            
            /*SqlCommand cmd1 = DataBase.Cmd("delete from KHACHHANG where makhachhang not in (select makhachhang from PHIEUDATPHONG)");
            cmd1.ExecuteNonQuery();
            loadKh();*/

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
        }

        private void txtdatphieu_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtdatphieu_Click(object sender, EventArgs e)
        {

            
        }

        private void txtdatphieu_Leave(object sender, EventArgs e)
        {
            if(txtdatphieu.Text == "")
           txtdatphieu.Text = "Mã Phiếu ";
        }

        private void txtdatphieu_Enter(object sender, EventArgs e)
        {
            if (txtdatphieu.Text != "")
            {
                txtdatphieu.Clear();
            }
        }

        private void cbreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbreset.SelectedIndex == 0) 
            {
                loadNd();
            }
            else if(cbreset.SelectedIndex == 1) 
            {
                loadFPhong();
            }
            else if (cbreset.SelectedIndex == 2)
            {
                loadKh();
            }
            else if (cbreset.SelectedIndex == 3)
            {
                loadPhong();
            }
            else if (cbreset.SelectedIndex == 4)
            {
                loadLPhong();
            }
        }
        private void btnDatDichvu_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            tabControl4.SelectedTab = tabPage24;
        }

        private void btnĐDV_Click(object sender, EventArgs e)
        {
            
            string a = "";
            float kq = 0;
                for (int i = 0; i < clbdichvu.CheckedItems.Count; i++)
                {
                a += clbdichvu.CheckedIndices[i] + " ";
                DataTable dt = DataBase.dt("select * from LOAIDICHVU");
                DataRow row = dt.Rows[clbdichvu.CheckedIndices[i]];
                kq += int.Parse(row[2].ToString()) + 0;

                }
                SqlCommand cmd = DataBase.Cmd("Insert into DICHVU(maphieudatphong,makhachhang,dichvu,tongtien) values ('" + txtMaPhieu.Text + "','" + txtMaKH.Text + "','" + a.ToString() + "',"+ kq.ToString() +")");
                cmd.ExecuteNonQuery();
                loadDV();
        }
        
        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = DataBase.Cmd("delete from DICHVU where maphieudatphong = '" + dgvDichvu.CurrentRow.Cells[0].Value.ToString() + "'");
            cmd.ExecuteNonQuery();
            loadDV();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            
        }

     

        private void dgvDichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            lbDichVu.Items.Clear();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDichvu.Rows[e.RowIndex];

                string[] s = row.Cells[2].Value.ToString().Split(' ');
                for (int i = 0; i < s.Length - 1; i++)
                {

                    lbDichVu.Items.Add(clbdichvu.Items[int.Parse(s[i])]);
                }

            }
           
        }
        private void tabPage12_Click(object sender, EventArgs e)
        {

        }

        private void lbDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage24_Click(object sender, EventArgs e)
        {

        }

        private void clbdichvu_Click(object sender, EventArgs e)
        {
            int kq = 0;
            string a = clbdichvu.SelectedItem.ToString().Trim();
            string[] s = a.Split('-');
            txtdsdv.Text= s[0];
            txtgdv.Text= s[1];
            for (int i = 0; i < clbdichvu.CheckedItems.Count; i++)
            {
               
                DataTable dt = DataBase.dt("select * from LOAIDICHVU");
                DataRow row = dt.Rows[clbdichvu.CheckedIndices[i]];
                kq += int.Parse(row[2].ToString()) + 0;

            }
            label38.Text = "Tổng tiền là : " + kq.ToString();
        }

        private void lbgiadichvu_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnsuadvvagia_Click(object sender, EventArgs e)
        {
            int s = 0;
            for (int i = 0; i < clbdichvu.SelectedItems.Count; i++)
            {
                s = clbdichvu.SelectedIndices[i];
                
                DataTable dt = DataBase.dt("select * from LOAIDICHVU");
                 DataRow row = dt.Rows[s];
                 SqlCommand gdv = DataBase.Cmd("update LOAIDICHVU set giadichvu = " + txtgdv.Text + " where madichvu = '" + row[0].ToString() + "'");
                 gdv.ExecuteNonQuery();
                
            }
            clbdichvu.Items.Clear();
            loadDichvu();
        }

        private void lbgiadichvu_Click(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsuadvu_Click(object sender, EventArgs e)
        {
            
            
            int s = 0;
            for (int i = 0; i < clbdichvu.SelectedItems.Count; i++)
            {
                s = clbdichvu.SelectedIndices[i];
                DataTable dt = DataBase.dt("select * from LOAIDICHVU");
                DataRow row = dt.Rows[s];

                SqlCommand gdv = DataBase.Cmd("update LOAIDICHVU set giadichvu = " + txtgdv.Text + " where madichvu = '" + row[0].ToString() + "'");
                gdv.ExecuteNonQuery();
            }
            clbdichvu.Items.Clear();
            loadDichvu();
        }

        private void btnHuyPhong_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = DataBase.Cmd("delete FROM PHIEUDATPHONG WHere maphieudatphong = '" + txtMaPhieu.Text + "'");
            cmd.ExecuteNonQuery();
            loadFPhong();
        }

        private void btnTimphong_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage12;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = DataBase.Cmd("update PHIEUDATPHONG set maphieudatphong = '"+txtMaPhieu.Text+"',makhachhang ='"+txtMaKH.Text+"' ,maphong = '"+txtMaPhong.Text+"',ngaythue = '"+dateĐP.Value+"',ngaytra = DATEADD(day,"+nmNgayO.Value+",'"+dateĐP.Value+"') , songayo = "+nmNgayO.Value+" where maphieudatphong = '"+txtMaPhieu.Text+"'");
            cmd.ExecuteNonQuery();
            loadFPhong();
        }

        private void btnThemP_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = DataBase.Cmd("insert into ");
        }

        
    }
}
