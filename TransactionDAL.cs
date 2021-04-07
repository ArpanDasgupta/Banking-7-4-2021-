using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingLib
{
    public class TransactionDAL
    {
        public void UpdateTranDetails(Transaction tr)
        {
            //@Sender_Acc,@Receiver_Acc,@Rec_IFSC, @Amount,@Transaction_time
            //UpdateEmployee
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString);
            SqlCommand cmd = new SqlCommand("UpdateTranDetails", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sender_Acc", tr.Sender_Acc);
            cmd.Parameters.AddWithValue("@Receiver_Acc", tr.Receiver_Acc);
            cmd.Parameters.AddWithValue("@Rec_IFSC", tr.Rec_IFSC);
            cmd.Parameters.AddWithValue("@Amount", tr.Amount);
            cmd.Parameters.AddWithValue("@Transaction_time", tr.Transaction_time);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
