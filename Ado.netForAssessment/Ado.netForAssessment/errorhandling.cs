using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ado.netForAssessment
{
    class errorhandling
    {
        private string ConnectionString;
        private SqlConnection objConn;
        public errorhandling()
        {
            ConnectionString = "Data Source=ARK-ASUS\\SQLEXPRESS01;Initial Catalog=rgurram;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            objConn = new SqlConnection(ConnectionString);
        }
        public void errorhandlingMethod()
        {
            int DeptId = int.Parse(Console.ReadLine());
            string DeptName = Console.ReadLine();
            objConn.Open();
            var transaction = objConn.BeginTransaction();
            try {

                var sql = "update department set DeptName=@DeptName where DeptId=@DeptId";
                SqlCommand sqlCommand = new SqlCommand(sql, objConn);
                sqlCommand.Parameters.AddWithValue("@DeptId", DeptId);
                sqlCommand.Parameters.AddWithValue("@DeptName", DeptName);
                sqlCommand.Transaction = transaction;
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                objConn.Close();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("an error occured" +ex.Message);
            }
            finally
            {
                transaction.Dispose();
                if (objConn.State == System.Data.ConnectionState.Open)
                    objConn.Close();
            }

         }
    }

}
