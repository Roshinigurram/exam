using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LinqForAssesement
{
    public class class1
    {
        private static string _ConnStr;
        public void method()
        {
            string ConnStr = "Data Source=ARK-ASUS\\SQLEXPRESS01;Initial Catalog=rgurram;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
             _ConnStr = ConnStr;

            var empdetails = GetEmployees();

            var data1 = empdetails.Where(d => d.EmpName.StartsWith("r"));
            var data2 = empdetails.Last();
            Console.WriteLine(data2.DeptId);

            foreach (var item in data1)

            {
                Console.WriteLine(item.EmpId + "|" + item.EmpName + "|" + item.City + "|" + item.Salary + "|" + item.DeptId);
            }

        }
        static IList<Employee> GetEmployees()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_ConnStr))
            {
                var sql = "select *from employee";
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand))
                    {
                        sqlData.Fill(data);

                    }
                }
            }
            IList<Employee> employees = new List<Employee>();
            foreach (DataRow i in data.Rows)
            {
                var emp = new Employee()
                {
                    EmpId = int.Parse(i["empid"].ToString()),
                    EmpName = i["empname"].ToString(),
                    Salary = decimal.Parse(i["salary"].ToString()),
                    City = i["city"].ToString(),
                    DeptId = int.Parse(i["deptid"].ToString())


                };

                employees.Add(emp);
            }

            return employees;

        }


    }
}