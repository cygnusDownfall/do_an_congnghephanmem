using BLL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI4
{
    public partial class Form1
    {
        private void bĐn_Click(object sender, EventArgs e)
        {
            if (TaikhoanBLL.LOGIN(tTk.Text, tMk.Text,isAdmin))
            {
                logIn = true;
                MessageBox.Show("Dang nhap thanh cong!");
            }
            else
            {
                MessageBox.Show("Dang nhap khong thanh cong!!!");
            }
            groupBox17.Hide();
            txtQCMND.Clear();
            txtQSDT.Clear();
        }
        #region hanche doi tab khi chua dang nhap 
        bool logIn = false, isAdmin = false;
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.Action == TabControlAction.Selecting && e.TabPageIndex != 0)
            {
                if (!logIn)
                {
                    MessageBox.Show("Hey anh bạn!! Đăng nhập đi để mở khóa các tính năng của chúng tôi!!");
                    e.Cancel = !logIn;
                }
            }

        }
        private void tabControl2_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.Action == TabControlAction.Selecting && e.TabPageIndex != 0)
            {
                if (!isAdmin)
                {
                    MessageBox.Show("Hey anh bạn!! Anh bạn đâu phải quản lý đâu !!");
                    e.Cancel = !isAdmin;
                }
            }
        }
        private void tabControl3_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.Action == TabControlAction.Selecting && e.TabPageIndex == 1)
            {
                if (!isAdmin)
                {
                    MessageBox.Show("Hey anh bạn!! Anh bạn đâu phải quản lý đâu !!");
                    e.Cancel = !isAdmin;
                }

            }
        }
        #endregion
    }
}
