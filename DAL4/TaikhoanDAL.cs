using System;
using System.Collections.Generic;
using System.Data;
using DTO4;
namespace DAL4
{
    public class TaikhoanDAL
    {
        public static bool LogIN(string Name, string Pass)
        {
            DataTable res = DataBase.dtStore(string.Format("select * where taikhoan='{0}' and matkhau='{1}'",Name,Pass));
            if(res == null) return false;
            if(res.Rows.Count ==1)
            {
                return true;
            }
            return false;
        }
        public static void LogOUT()
        {

        }
    }
}
