using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Ado.netForAssessment
{
    class CRUDEoperations
    {
        private string ConnectionString;
        private SqlConnection objConn;
        public CRUDEoperations()
        {
            ConnectionString = "Data Source=ARK-ASUS\\SQLEXPRESS01;Initial Catalog=rgurram;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            objConn = new SqlConnection(ConnectionString);
        }
        public void RetriveDetails()
        {
            objConn.Open();
            var sql = "select *from employee";
            SqlCommand sqlCommand = new SqlCommand(sql, objConn);
            SqlDataReader sqlData = sqlCommand.ExecuteReader();

            while (sqlData.Read())
            {
                Console.WriteLine(sqlData["EmpId"] + "\t" + sqlData["EmpName"]);
            }
            objConn.Close();
        }
        public void RetrievUsingDataTable()
        {
            objConn.Open();
            DataTable dataTable = new DataTable();
            var sql = "select *from employee";
            SqlCommand sqlCommand = new SqlCommand(sql, objConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["EmpName"]);

            }


        }
        public void RetriveDatabyUSING()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var sql = "select *from employee";
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["EmpName"]);
            }
        }
        public void insertRecords()
        {
            Console.WriteLine("enter details:");

            int DeptId = int.Parse(Console.ReadLine());
            string DeptName = Console.ReadLine();
            objConn.Open();
            var sql = "insert into department values(@DeptId,@DeptName)";
            SqlCommand cmd = new SqlCommand(sql, objConn);

            cmd.Parameters.AddWithValue("@deptid", DeptId);
            cmd.Parameters.AddWithValue("@DeptName", DeptName);
            cmd.ExecuteNonQuery();
            objConn.Close();



        }
        public void updateRecords()
        {
            int DeptId = int.Parse(Console.ReadLine());
            string DeptName = Console.ReadLine();
            objConn.Open();
            var sql = "update department set DeptName=@DeptName where DeptId=@DeptId";
            SqlCommand sqlCommand = new SqlCommand(sql, objConn);
            sqlCommand.Parameters.AddWithValue("@DeptId", DeptId);
            sqlCommand.Parameters.AddWithValue("@DeptName", DeptName);
            sqlCommand.ExecuteNonQuery();
            objConn.Close();
        }
        public void deleterecords()
        {
            try
            {
                int DeptId = int.Parse(Console.ReadLine());
                objConn.Open();
                var sql = "delete from department where DeptId=@DeptId";

                SqlCommand sqlCommand = new SqlCommand(sql, objConn);
                sqlCommand.Parameters.AddWithValue("@DeptId", DeptId);
                sqlCommand.ExecuteNonQuery();
                objConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occured" + ex.Message);
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                    objConn.Close();
                Console.WriteLine("connection closed");
            }
        }
    }
}
         
