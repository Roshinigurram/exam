using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Ado.netForAssessment
{
    class datasetAnddataADAPTER
    {
        private string ConnectionString;
        private DataSet dataSet;
        private SqlDataAdapter sqlDataAdapter;
        public datasetAnddataADAPTER()
        {
            ConnectionString = "Data Source=ARK-ASUS\\SQLEXPRESS01;Initial Catalog=rgurram;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            dataSet = new DataSet();
        }
        public void Execute()
        {
            sqlDataAdapter = new SqlDataAdapter("select *from employee", ConnectionString);
            sqlDataAdapter.Fill(dataSet, "employee");
            foreach (DataRow row in dataSet.Tables["employee"].Rows)

            {
                Console.WriteLine(row["EmpId"] + "|" + row["EmpName"]);
            }
            sqlDataAdapter = new SqlDataAdapter("select *from department", ConnectionString);
            sqlDataAdapter.Fill(dataSet, "department");
            foreach (DataRow row in dataSet.Tables["department"].Rows)

            {
                Console.WriteLine(row["DeptId"] + "|" + row["DeptName"]);
            }
        }
    }
}
