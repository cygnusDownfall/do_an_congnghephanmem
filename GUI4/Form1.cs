using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DAL4;

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
        #region LOAD BANG
        private void loadNd()
        {
            DataTable Nd = DataBase.dt("select * from DANGNHAP");
            dgvNguoidung.DataSource = Nd;

        }
        private void loadKh()
        {
            DataTable Kh = DataBase.dt("select * from KHACHHANG");
            dgvKhachhang.DataSource = Kh;

        }
        private void loadThBi() 
        {
            DataTable dt = DataBase.dt("select * from THIETBI");
            dgvThietbi.DataSource = dt;
        }
        private void loadDV()
        {
            DataTable dv = DataBase.dt("select * from DICHVU");
            dgvDichvu.DataSource = dv;

        }
        private void loadThongketheoQuy()
        {
           
            DataTable dt = DataBase.dt("select DATEPART(QUARTER,ngaylaphoadon) as quy,sum(tongtien1ngay) as tongtien from THONGKE group by DATEPART(QUARTER,ngaylaphoadon)");
            
            dgvTTQuy.DataSource = dt;
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
        private void loadThietbi()
        {
            lstthietbi.Items.Clear();
            DataTable tb = DataBase.dt("select * from LOAITHIETBI");

            string a = "";
            foreach (DataRow d in tb.Rows)
            {
                a = d[1].ToString();
                lstthietbi.Items.Add(a);
            }
        }
        private void loadHoadon()
        {
            DataTable dt = DataBase.dt("select * from hoadon");
            dgvhoadon.DataSource = dt;
        }
        private void loadThongketheoThang() 
        {

            DataTable dt = DataBase.dt("select * from thongke");
            dgvTTthang.DataSource = dt;
        }


        #endregion
        #region Sort Filt
        private void dgvDatphong_SortStringChanged(object sender, EventArgs e)
        {
            this.pHIEUDATPHONGBindingSource.Sort = this.dgvDatphong.SortString;
        }

        private void dgvDatphong_FilterStringChanged(object sender, EventArgs e)
        {
            this.pHIEUDATPHONGBindingSource.Filter = this.dgvDatphong.FilterString;

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
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            try { this.dANGNHAPTableAdapter1.Fill(this.qLKSDataSet3.DANGNHAP);
                this.kHACHHANGTableAdapter1.Fill(this.qLKSDataSet3.KHACHHANG);
                this.dICHVUTableAdapter1.Fill(this.qLKSDataSet3.DICHVU);
                this.pHONGTableAdapter1.Fill(this.qLKSDataSet3.PHONG);
                this.lOAIPHONGTableAdapter1.Fill(this.qLKSDataSet3.LOAIPHONG);
                this.pHIEUDATPHONGTableAdapter1.Fill(this.qLKSDataSet3.PHIEUDATPHONG);
                #region Tạo mặc định cho toolbox
                pMat0.Hide();
                bĐx.Hide();
                bĐx.Hide();
                btnthuephong.Hide();
                btnHuyPhong.Hide();

                btnHuyPhong.Visible = true;
                groupBox17.Hide();
                cbCvu.Items.AddRange(new object[] { "Nhân Viên", "Quản lý" });
                cbQuy.Items.AddRange(new string[] { "Theo Quý", "Theo Tháng" });
                cbreset.Items.AddRange(new object[] { "Bảng Người Dùng", "Bảng Đặt Phòng", "Bảng Khách Hàng", "Bảng Mã Phòng", "Bảng Loại Phòng" });
                
                #endregion
                DataTable t = DataBase.dt("select * from PHIEUDATPHONG where day(ngaythue) < day(GETDATE()) and maphong in (select maphong from PHONG where trangthai = 1)");
                foreach (DataRow d in t.Rows)
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
                loadThietbi();
                loadThBi();
                loadHoadon();
                loadThongketheoThang();
                loadThongketheoQuy();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi ở form load", MessageBoxButtons.OK); }

        }
        //-------------------------------tab1-------------------------------------
        #region tab1
        private void bĐn_Click(object sender, EventArgs e)
        {
            DataTable t = DataBase.dt("select taikhoan,matkhau,chucvu from dangnhap where taikhoan = '"+tTk.Text+"' and matkhau ='"+tMk.Text+"'");
            
            if ( tTk.Text ==t.Rows[0][0].ToString() && tMk.Text == t.Rows[0][1].ToString())
            
            {
                MessageBox.Show("thanh cong", "đã đăng nhập", MessageBoxButtons.OK);
                if (t.Rows[0][2].ToString() == "1")
                {
                    label35.Text = "Cap quyen Quan ly";
                }
                else
                {
                    label35.Text = "Cap quyen Nhan vien";
                    
                }
                bĐx.Show();
                bĐn.Hide();
                bQuen.Hide();
            }
            else
            {
                MessageBox.Show("dang  nhap that bai", "đã đăng nhập", MessageBoxButtons.OK);
            }
            groupBox17.Hide();
            txtQCMND.Clear();
            txtQSDT.Clear();
        }
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
            if (groupBox17.Visible == false) 
            groupBox17.Show();
            else 
                groupBox17.Hide();
        }
        #endregion
        //-------------------------------tab2-------------------------------------------
        #region tab2

        /* public void ShowThucDon()
         {
             DataTable dt = DataBase.dt("select * from LOAITHIETBI");
             //lvthietbi.Items.Clear();
             ListViewItem dong;
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 DataRow dr = dt.Rows[i];
                 ListViewItem item = new ListViewItem(dr[0].ToString());
                 ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, dt.Rows[i][0].ToString());
                 item.SubItems.Add(dr[1].ToString());
                 item.SubItems.Add(dr[2].ToString());
                 //item.SubItems.Add(dr[4].ToString());
                 item.SubItems.Add(subitem);
                 lvthietbi.Items.Add(item);
             }
             lvthietbi.View = View.Details;
             lvthietbi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
             lvthietbi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
         }*/

        private void dgvDatphong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void bĐx_Click(object sender, EventArgs e)
        {


        }
        #endregion
        //-------------------------------tab3---------------------------------------------------

        //=======================================================================================

        #region tabKHACHHANG
        //---------------------------------------tabKHACHHANG-------------------------------------
        private void txtdatphieu_Leave(object sender, EventArgs e)
        {
            try {
                if (txtdatphieu.Text == "")
                    txtdatphieu.Text = "Mã Phiếu "; }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }

        }

        private void txtdatphieu_Enter(object sender, EventArgs e)
        {
            try { if (txtdatphieu.Text != "")
                {
                    txtdatphieu.Clear();
                } }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        private void dgvKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { string c = "";

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

                } }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }



        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            try { string c = "";

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
                listBox1.Text = txtMKH.Text; }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            try { string c = "";

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

                loadKh(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }



            //listBox1.Items

        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try { SqlCommand cmd = DataBase.Store("XoaKH");

                cmd.Parameters.Add("@makh", SqlDbType.NVarChar).Value = txtMKH.Text;

                cmd.ExecuteNonQuery();
                loadKh(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }




        }
        #endregion
        #region tabTAIKHOAN
        private void btnSuaNd_Click(object sender, EventArgs e)
        {
           
        }
        private void btnThemNd_Click(object sender, EventArgs e)
        {
            



        }

        private void btnXoaNd_Click(object sender, EventArgs e)
        {
            

        }
        private void btnXN_Click(object sender, EventArgs e)
        {
            try { string a = "";
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
                    

                } }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }
            txtQSDT.Clear();
            txtQCMND.Clear();

        }
        private void dgvNguoidung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { string b;

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
                } }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        #endregion
        #region tabPHIEUDATPHONG
        private void btnthuephong_Click(object sender, EventArgs e)
        {
            try { SqlCommand cmd = DataBase.Cmd("update PHONG set trangthai = 2 where maphong = '" + txtMaPhong.Text + "'");
                cmd.ExecuteNonQuery();
                loadPhong(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }




        }
        private void btnĐatPhong_Click(object sender, EventArgs e)
        {
            try {
                DataTable t = DataBase.dt("select maphong from PHONG where maphong in (select maphong from Phong where trangthai = 1)");
                foreach (DataRow dr in t.Rows)
                {
                    if (txtMaPhong.Text == dr[0].ToString())
                    {
                        SqlCommand cmd = DataBase.Cmd("insert into PHIEUDATPHONG(maphieudatphong,makhachhang,maphong,ngaythue,ngaytra,songayo,datcoc) values ('" + txtMaPhieu.Text + "','" + txtMaKH.Text + "','" + txtMaPhong.Text + "','" + dateĐP.Value + "',dateadd(day," + (nmNgayO.Value - 1).ToString() + ",'" + dateĐP.Value + "')," + nmNgayO.Value.ToString() + "," + cbDatcoc.Text.ToString() + ")");
                        cmd.ExecuteNonQuery();
                        loadFPhong();
                    }
                    else
                    {
                        break;
                    }
                }
                MessageBox.Show("da dat hoac da thue phong", "thong bao", MessageBoxButtons.OK);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }

        }
        private void btnHuyphieuQH_Click(object sender, EventArgs e)
        {
            try {
                SqlCommand cmd = DataBase.Cmd("delete from PHIEUDATPHONG where day(ngaythue) < day(GETDATE()) and maphong in (select maphong from PHONG where trangthai = 1)");
                cmd.ExecuteNonQuery(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }

        }

        private void dgvDatphong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { string a = " ";
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
                    
                   
                } }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        private void btndatphieu_Click(object sender, EventArgs e)
        {
            DataTable dt = DataBase.dt("select maphieudatphong from PHIEUDATPHONG");
            try
            {

                foreach (DataRow i in dt.Rows)
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
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        private void btnHetHanThue_Click(object sender, EventArgs e)
        {
            try {
                DataTable t = DataBase.dt("select * from PHIEUDATPHONG where day(ngaythue) < day(GETDATE()) and maphong in (select maphong from PHONG where trangthai = 1)");
                dgvDatphong.DataSource = t; }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }

        }

        private void lbhethandat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { DataTable dt = DataBase.dt("select * from PHIEUDATPHONG where maphieudatphong = '" + lbhethandat.SelectedItem.ToString() + " '");
                dgvDatphong.DataSource = dt; }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }

        private void lbhethanthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { DataTable dt = DataBase.dt("select * from PHIEUDATPHONG where maphieudatphong = '" + lbhethanthue.SelectedItem.ToString() + " '");
                dgvDatphong.DataSource = dt; }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        #endregion
        #region tabPHONG
        private void button1_Click(object sender, EventArgs e)
        {
            try { DataTable dt = DataBase.dt("select * from PHONG where maloaiphong = '" + txtMLP.Text + "'");
                advancedDataGridView1.DataSource = dt;
                DataTable td = DataBase.dt("select * from LOAIPHONG where maloaiphong = '" + txtMLP.Text + "'");
                advancedDataGridView2.DataSource = td;
                txtMP.Clear(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            try { if (txtMP.Text == "")
                {
                    MessageBox.Show(" - Click chọn loại phòng ở bảng 1 để tìm mã phòng \n - Click chọn để lấy mã phòng ở bảng 2", "Gợi ý", MessageBoxButtons.OK);
                }
                else
                {
                    txtMaPhong.Text = txtMP.Text;
                    tabControl3.SelectedTab = tabPage6;
                } }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try { if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.advancedDataGridView1.Rows[e.RowIndex];
                    txtMP.Text = row.Cells[0].Value.ToString();
                    cbDientich.Text = row.Cells[2].Value.ToString();
                    nmTang.Value = int.Parse(row.Cells[3].Value.ToString());
                    int a = 0;
                    a = int.Parse(row.Cells[4].Value.ToString());
                    if (a == 1)
                        radTrong.Checked = true;
                    else if (a == 2)
                        radDat.Checked = true;
                    else
                        radThue.Checked = true;
                } }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        private void advancedDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.advancedDataGridView2.Rows[e.RowIndex];
                    DataTable dt = DataBase.dt("Select * from PHONG where maloaiphong = '" + row.Cells[0].Value.ToString() + "'");
                    advancedDataGridView1.DataSource = dt;
                    txtMLP.Text = row.Cells[0].Value.ToString();
                    txtTenloaiPhong.Text = row.Cells[1].Value.ToString();
                    txtGiaPhong.Text = row.Cells[2].Value.ToString();
                } }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        #endregion
        #region tabDICHVU
        private void btnDatDichvu_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            tabControl4.SelectedTab = tabPage24;
        }

        private void btnĐDV_Click(object sender, EventArgs e)
        {
            try { string a = "";
                float kq = 0;
                for (int i = 0; i < clbdichvu.CheckedItems.Count; i++)
                {
                    a += clbdichvu.CheckedIndices[i] + " ";
                    DataTable dt = DataBase.dt("select * from LOAIDICHVU");
                    DataRow row = dt.Rows[clbdichvu.CheckedIndices[i]];
                    kq += int.Parse(row[2].ToString()) + 0;

                }
                SqlCommand cmd = DataBase.Cmd("Insert into DICHVU(maphieudatphong,makhachhang,dichvu,tongtien) values ('" + txtMaPhieu.Text + "','" + txtMaKH.Text + "','" + a.ToString() + "'," + kq.ToString() + ")");
                cmd.ExecuteNonQuery();
                loadDV(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi ở nút đặt dịch vụ", MessageBoxButtons.OK); }


        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            

        }
        private void dgvDichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { lbDichVu.Items.Clear();
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgvDichvu.Rows[e.RowIndex];

                    string[] s = row.Cells[2].Value.ToString().Split(' ');
                    for (int i = 0; i < s.Length - 1; i++)
                    {

                        lbDichVu.Items.Add(clbdichvu.Items[int.Parse(s[i])]);
                    }

                } }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }



        }
        private void clbdichvu_Click(object sender, EventArgs e)
        {
            try { int kq = 0;
                string a = clbdichvu.SelectedItem.ToString().Trim();
                string[] s = a.Split('-');
                txtdsdv.Text = s[0];
                txtgdv.Text = s[1];
                for (int i = 0; i < clbdichvu.CheckedItems.Count; i++)
                {

                    DataTable dt = DataBase.dt("select * from LOAIDICHVU");
                    DataRow row = dt.Rows[clbdichvu.CheckedIndices[i]];
                    kq += int.Parse(row[2].ToString()) + 0;

                }
                label38.Text = "Tổng tiền là : " + kq.ToString(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }
        private void btnsuadvvagia_Click(object sender, EventArgs e)
        {
            try { int s = 0;
                for (int i = 0; i < clbdichvu.SelectedItems.Count; i++)
                {
                    s = clbdichvu.SelectedIndices[i];

                    DataTable dt = DataBase.dt("select * from LOAIDICHVU");
                    DataRow row = dt.Rows[s];
                    SqlCommand gdv = DataBase.Cmd("update LOAIDICHVU set giadichvu = " + txtgdv.Text + " where madichvu = '" + row[0].ToString() + "'");
                    gdv.ExecuteNonQuery();

                }
                clbdichvu.Items.Clear();
                loadDichvu(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }



        private void btnsuadvu_Click(object sender, EventArgs e)
        {

            try { int s = 0;
                for (int i = 0; i < clbdichvu.SelectedItems.Count; i++)
                {
                    s = clbdichvu.SelectedIndices[i];
                    DataTable dt = DataBase.dt("select * from LOAIDICHVU");
                    DataRow row = dt.Rows[s];

                    SqlCommand gdv = DataBase.Cmd("update LOAIDICHVU set giadichvu = " + txtgdv.Text + " where madichvu = '" + row[0].ToString() + "'");
                    gdv.ExecuteNonQuery();
                }
                clbdichvu.Items.Clear();
                loadDichvu(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }

        private void btnHuyPhong_Click(object sender, EventArgs e)
        {
            try { SqlCommand cmd = DataBase.Cmd("delete FROM PHIEUDATPHONG WHere maphieudatphong = '" + txtMaPhieu.Text + "'");
                cmd.ExecuteNonQuery();
                loadFPhong(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }

        private void btnTimphong_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage12;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try { SqlCommand cmd = DataBase.Cmd("update PHIEUDATPHONG set maphieudatphong = '" + txtMaPhieu.Text + "',makhachhang ='" + txtMaKH.Text + "' ,maphong = '" + txtMaPhong.Text + "',ngaythue = '" + dateĐP.Value + "',ngaytra = DATEADD(day," + nmNgayO.Value + ",'" + dateĐP.Value + "') , songayo = " + nmNgayO.Value + " where maphieudatphong = '" + txtMaPhieu.Text + "'");
                cmd.ExecuteNonQuery();
                loadFPhong(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }

        private void btnThemP_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = DataBase.Cmd("insert into PHONG (maphong,maloaiphong,dientich,tang,trangthai) values ('"+txtMP.Text+"','"+txtMLP.Text+"','"+ cbDientich.Text + "',"+ nmTang.Value + ",1)  ");
            cmd.ExecuteNonQuery();
            loadPhong();
        }
        #endregion
        private void cbreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { if (cbreset.SelectedIndex == 0)
                {
                    loadNd();
                }
                else if (cbreset.SelectedIndex == 1)
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
                else if (cbreset.SelectedIndex == 5)
                {
                    loadHoadon();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi ở comboReset", MessageBoxButtons.OK); }


        }
        private void dgvKhachhang_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (DataGridViewRow dt in dgvKhachhang.SelectedRows)
            {
                dgvKhachhang.Rows.Remove(dt);
            }
        }
        #region TRỐNG
        private void tabPage5_Click(object sender, EventArgs e)
        {

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

        private void dgvDatphong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

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

        private void lbgiadichvu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void lbgiadichvu_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void dgvThietbi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                string a = "";


                lvthietbi.Items.Clear();
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvThietbi.Rows[e.RowIndex];
                    {
                        a = row.Cells[2].Value.ToString();
                    }
                }
                string[] s = a.Split('-', ' ');
                string k = "";
                int j = 0;
                
                for (int i = 0; i < s.Length - 1; i += 2)
                {
                        
                            DataTable tb = DataBase.dt("select tenthietbi from LOAITHIETBI where mathietbi = '" + s[i].ToString().Trim() + "'");
                            DataRow r = tb.Rows[0];
                            lvthietbi.Items.Add(s[i].ToString().Trim());
                            lvthietbi.Items[j].SubItems.Add(r[0].ToString());
                            lvthietbi.Items[j].SubItems.Add(s[i + 1].ToString().Trim());
                    j++;

                   
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK); }
            MessageBox.Show("Nhấn nút Xóa danh sách ngay để không gặp lỗi", "Việc phải làm", MessageBoxButtons.OK);
        }

        private void lstthietbi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttenthietbi.Text = lstthietbi.SelectedItem.ToString();
            
            DataTable t = DataBase.dt("select mathietbi from LOAITHIETBI where tenthietbi = N'"+ lstthietbi.SelectedItem.ToString() + "'");
            txtmathietbi.Text = t.Rows[0][0].ToString();
            
        }
        int kiemtra(string thietbi)
        {
            for (int i = 0; i < lvthietbi.Items.Count; i++)
                if (thietbi == lvthietbi.Items[i].SubItems[1].Text)
                    return i;
            return -1;
        }
        private void btnthemsl_Click(object sender, EventArgs e)
        {
            /*try            ***tang so luong
            {
                int soluong = 0;
                int vt = 0;
                int donglv = lvthietbi.Items.Count;
                int donglb = lstthietbi.SelectedItems.Count;
                DataTable tb = DataBase.dt("select * from LOAITHIETBI where tenthietbi = N'" + lstthietbi.SelectedItem.ToString() + "'");
                DataRow d = tb.Rows[0];
                for(int i = 0; i < donglb;i++)
                {
                    vt = lstthietbi.SelectedIndices[i];
                }
                string thietbi = lstthietbi.Items[vt].ToString();
                if(kiemtra(thietbi)==-1) 
                {
                    soluong= 1;
                    lvthietbi.Items.Add(d[0].ToString());
                    lvthietbi.Items[donglv].SubItems.Add(thietbi.ToString());
                    lvthietbi.Items[donglv].SubItems.Add(soluong.ToString());
                }
                else
                {
                    int i = kiemtra(thietbi);
                    soluong = int.Parse(lvthietbi.Items[i].SubItems[2].Text);
                    soluong++;
                    lvthietbi.Items[i].SubItems[2].Text = soluong.ToString();
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); };*/

            /*int j;                                ***giam so luong
            int k = 0 ;
            int dong = lvthietbi.SelectedItems.Count;
            for (j = 0; j < dong; j ++)
            {
                k = lvthietbi.SelectedIndices[j];
            }
            int soluong = int.Parse(lvthietbi.Items[k].SubItems[2].Text);
            if (soluong > 0)
                soluong--;
            else
                MessageBox.Show("giam gi giam quai", "bot nhan lai di", MessageBoxButtons.OK);
            lvthietbi.Items[k].SubItems[2].Text = soluong.ToString();*/

            try
            {
                
                int soluong = 0;
                int vt = 0;
                int donglv = lvthietbi.Items.Count;
                int donglb = lstthietbi.SelectedItems.Count;
                DataTable tb = DataBase.dt("select * from LOAITHIETBI where tenthietbi = N'" + lstthietbi.SelectedItem.ToString() + "'");
                DataRow d = tb.Rows[0];
                for (int i = 0; i < donglb; i++)
                {
                    vt = lstthietbi.SelectedIndices[i];
                }
                string thietbi = lstthietbi.Items[vt].ToString();
                if (kiemtra(thietbi) == -1)
                {
                    soluong = int.Parse(nmsoluongtb.Value.ToString());
                    lvthietbi.Items.Add(d[0].ToString());
                    lvthietbi.Items[donglv].SubItems.Add(thietbi.ToString());
                    lvthietbi.Items[donglv].SubItems.Add(soluong.ToString());
                }
                else
                {
                    int i = kiemtra(thietbi);
                    soluong = soluong = int.Parse(nmsoluongtb.Value.ToString());

                    lvthietbi.Items[i].SubItems[2].Text = soluong.ToString();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); };
        }


        private void btngiamsl_Click(object sender, EventArgs e)
        {
        }
        private void btnCapnhatthietbi_Click(object sender, EventArgs e)
        {
            string a = "";
            for(int i = 0; i < lvthietbi.Items.Count;i++)
            {
                a += lvthietbi.Items[i].SubItems[0].Text.Trim()+"-"+ lvthietbi.Items[i].SubItems[2].Text.Trim()+ " ";

            }
            SqlCommand cmd = DataBase.Cmd("Insert into THIETBI(maphieudatphong,maphong,thietbi) values ('" + txtMaPhieu.Text + "','" + txtMaPhong.Text + "','"+a.ToString()+"')");
            cmd.ExecuteNonQuery();
            loadThBi();
        }

        private void tabPage25_Click(object sender, EventArgs e)
        {

        }

        
        private void btnThemthietbi_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = DataBase.Cmd("Insert into LOAITHIETBI(mathietbi,tenthietbi) values (N'" + txtmathietbi.Text + "',N'" + txttenthietbi.Text + "')");
                cmd.ExecuteNonQuery();
                loadThietbi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK);
            }
        }

        private void btnSuathietbi_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = DataBase.Cmd("update from LOAITHIETBI set mathietbi = '"+txtmathietbi.Text+"',tenthietbi = '"+txttenthietbi.Text+"' where mathietbi = '" + txtmathietbi.Text + "'");
            cmd.ExecuteNonQuery();
            loadThietbi();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK); }
        }

        private void btnXoaThietbi_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = DataBase.Cmd("delete from LOAITHIETBI where mathietbi = '"+txtmathietbi.Text+"'");
            cmd.ExecuteNonQuery();
            loadThietbi();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK); }
        }

        private void btnclearlvtb_Click(object sender, EventArgs e)
        {
            lvthietbi.Items.Clear();
        }

        private void btnThietbi_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            tabControl4.SelectedTab = tabPage25;
        }

        private void btnThemtb_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = DataBase.Cmd("Insert into LOAITHIETBI(mathietbi,tenthietbi) values (N'" + txtmathietbi.Text + "',N'" + txttenthietbi.Text + "')");
                cmd.ExecuteNonQuery();
                loadThietbi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK);
            }
        }

        private void btnXoatb_Click(object sender, EventArgs e)
        {
            try
            {
                
                    SqlCommand cmd = DataBase.Cmd("delete from THIETBI where maphieudatphong = '" + dgvThietbi.CurrentRow.Cells[0].Value.ToString() + "'");
                    cmd.ExecuteNonQuery();
                    loadThBi();
                
                
            }
            catch (Exception ex) {
                
                MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK); }
        }
       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public string Random()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
       

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "H-" + Random();
            DataTable t = DataBase.dt("select giailoai from LOAIPHONG where maloaiphong = (select maloaiphong from PHONG where maphong = '"+txtMaPhong.Text+"')");
            DataTable k = DataBase.dt("select Tongtien from DICHVU where maphieudatphong = '" + txtMaPhieu.Text + "'");
                if (k == null)
            {
                k.Rows[0][0] = "0";
            }
            float b = float.Parse(t.Rows[0][0].ToString()) + float.Parse(k.Rows[0][0].ToString());
            SqlCommand cmd = DataBase.Cmd("insert into HOADON(mahoadon,maphieudatphong,makhachhang,ngaylaphoadon,Trigia) values ('" + a + "','" + txtMaPhieu.Text + "','" + txtMaKH.Text + "',GETDATE()," + b + ")");
            cmd.ExecuteNonQuery();
            loadHoadon();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK); }
        }

        private void picrdmaphieu_Click(object sender, EventArgs e)
        {
            txtdatphieu.Text = "F-" + Random();
        }

        private void picrdmakhachhang_Click(object sender, EventArgs e)
        {
            txtMKH.Text = "K-"+Random();
        }

        private void picXoadsdichvu_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = DataBase.Cmd("delete from DICHVU where maphieudatphong = '" + dgvDichvu.CurrentRow.Cells[0].Value.ToString() + "'");
                cmd.ExecuteNonQuery();
                loadDV();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }

        }

        private void picThemNd_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }
        }

        private void picSuaNd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = DataBase.Cmd("update dangnhap set taikhoan = '" + tTenNd.Text + "' ,matkhau ='" + tMk.Text + "',TenND = '" + tTenNd.Text + "',SĐT = '" + tSĐTNd.Text + "',CMND = '" + tCMNDNd.Text + "',Chucvu = " + cbCvu.Text + " where SĐT = '" + tSĐTNd.Text + "'");
                cmd.ExecuteNonQuery();
                loadNd();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }


        }

        private void picXoaNd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = DataBase.Store("XoaNd");
                cmd.Parameters.Add("@tk", dgvNguoidung.SelectedRows[0].Cells[0].Value);
                cmd.ExecuteNonQuery();
                loadNd();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }
        }
        private void picInhoadon_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = DataBase.Cmd("insert into THONGKE(mahoadon,ngaylaphoadon,tongtien1ngay) values ('" + dgvhoadon.CurrentRow.Cells[0].Value.ToString() + "','" + dgvhoadon.CurrentRow.Cells[3].Value.ToString() + "'," + dgvhoadon.CurrentRow.Cells[4].Value.ToString() + ")");
            cmd.ExecuteNonQuery();
            loadThongketheoThang();
        }

        private void cbQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQuy.SelectedIndex == 0)
            {
                loadThongketheoThang();
            }
            else
            {
               loadThongketheoQuy();
            }
        }

        private void picXoahoadon_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = DataBase.Cmd("delete from HOADON where mahoadon = '" + dgvhoadon.CurrentRow.Cells[0].Value.ToString() + "'");
                cmd.ExecuteNonQuery();
                loadHoadon();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK); }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnSuaP_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "";
            if(radTrong.Checked) 
            {
                a = "1";
            }
            else if (radDat.Checked)
            {
                a = "2";
            }
            else { a= "3"; }
            SqlCommand cmd = DataBase.Cmd("update PHONG set maphong = '"+txtMP.Text+"', maloaiphong = '"+txtMLP.Text+"',dientich = '"+cbDientich.Text+"',tang = "+nmTang.Value+",trangthai = "+a+" where maphong = '"+txtMP.Text+"'");
            cmd.ExecuteNonQuery();
            loadPhong();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK); }
        }

        private void btnXuaP_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = DataBase.Cmd("delete from phong where maphong = '" + txtMP.Text + "'");
            cmd.ExecuteNonQuery();
            loadPhong();
        }

        private void cbDientich_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
//try{
//}catch (Exception ex){MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK);}