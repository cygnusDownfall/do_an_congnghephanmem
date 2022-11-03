using System;
using System.Collections.Generic;
using System.Text;

using DAL4;
using DTO4;

namespace BLL4
{
    public class TaikhoanBLL
    {
        public static void LOGIN(string Name,string Pass)
        {

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
