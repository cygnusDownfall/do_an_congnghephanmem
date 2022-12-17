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
            if (TaikhoanBLL.LOGIN(tTk.Text, tMk.Text))
            {
                logIn=true;
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
                e.Cancel = !logIn;
            if (e.Action == TabControlAction.Selecting && e.TabPageIndex != 0)
            {
                e.Cancel = !isAdmin;
            }
        }
        #endregion
    }
}
