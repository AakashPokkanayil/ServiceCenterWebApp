using System.ComponentModel.DataAnnotations;

namespace ServiceCenterWebApp.API.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime dob { get; set; }
        public int Experience { get; set; }
        public int Role { get; set; }
        public int AdharID { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }
        public byte status { get; set; }

    }
}
