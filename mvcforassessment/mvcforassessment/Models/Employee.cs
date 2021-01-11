using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mvcforassessment.Models
{
    public class Employee
    {
        [Key]
        public int  EmpId{ get; set; }
        public  string EmpName { get; set; }
        public string City { get; set; }
        public decimal Salary{ get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department department { get; set; }
    }
}
