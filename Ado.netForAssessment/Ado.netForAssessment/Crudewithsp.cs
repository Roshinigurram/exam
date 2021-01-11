using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ado.netForAssessment
{
    class Crudewithsp
    {
        private string ConnectionString;
        private SqlConnection objConn;
        public Crudewithsp()
        {
            ConnectionString = "Data Source=ARK-ASUS\\SQLEXPRESS01;Initial Catalog=rgurram;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            objConn = new SqlConnection(ConnectionString);

        }
        public void InsrtUSINGsp()
        {
            int DeptId = int.Parse(Console.ReadLine());
            string DeptName = Console.ReadLine();
            objConn.Open();
           
            SqlCommand cmd = new SqlCommand("usp_department", objConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@deptid", DeptId);
            cmd.Parameters.AddWithValue("@DeptName", DeptName);
            cmd.ExecuteNonQuery();
            objConn.Close();
        }

    }
}
