using System;
using System.Collections.Generic;
using System.Text;
using DAL4;
using DTO4;

namespace BLL4
{
    public class TaikhoanBLL
    {
        public static bool LOGIN(string Name,string Pass)
        {
            try
            {
                return TaikhoanDAL.LogIN(Name,Pass);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static void LOGOUT()
        {
            try
            {
                TaikhoanDAL.LogOUT();
            }
            catch(Exception e)
            {

            }
        }
    }
}
