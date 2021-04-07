using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingLib
{
    public class BalanceDAL
    {
        public Double GetBalance(long accnum)
        {
            Double amt=0;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select Account_Balance from AccBalance where Account_NO = "+accnum, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                amt = Convert.ToDouble(dr["Account_Balance"]);
            cn.Close();
            return amt;

        }
        public void UpdateBalance(long accnum, Double amt)
        {
            
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update AccBalance set Account_Balance = "+amt+"  where Account_NO = " + accnum, cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

        }
    }
}
