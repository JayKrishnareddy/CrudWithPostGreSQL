using System;

namespace CrudWithPostGreSQL.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string  Department { get; set; }
        public DateTime  DateofJoining { get; set; }
        public string FileName { get; set; }
    }
}
