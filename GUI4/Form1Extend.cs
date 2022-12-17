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
                var tab = tabControl1.TabPages;
                for (int i = 1, length = tab.Count; i < length; i++)
                {
                    tab[i].Show();
                }
            }
            else
            {
                MessageBox.Show("Dang nhap khong thanh cong!!!");
            }
            groupBox17.Hide();
            txtQCMND.Clear();
            txtQSDT.Clear();
        }

    }
}
