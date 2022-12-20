using System;
using System.Collections.Generic;
using System.Data;
using DTO4;
namespace DAL4
{
    public class TaikhoanDAL
    {
        public static bool LogIN(string Name, string Pass,ref bool admin)
        {
            DataTable res = DataBase.dtStore(string.Format("select Chucvu from DANGNHAP  where taikhoan='{0}' and matkhau='{1}'",Name,Pass));
            if(res == null) return false;
            if(res.Rows.Count ==1)
            {
                if (res.Rows[0][0].ToString() == "1") { admin = true; }
                else { admin = false; }
                return true;
            }
            return false;
        }
        public static void LogOUT()
        {

        }
    }
}
