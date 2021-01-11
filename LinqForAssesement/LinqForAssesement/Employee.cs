using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinqForAssesement
{
    class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public string City { get; set; }
        public int DeptId { get; set; }
    }
}
