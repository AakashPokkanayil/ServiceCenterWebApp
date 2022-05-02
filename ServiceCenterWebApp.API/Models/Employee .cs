using System.ComponentModel.DataAnnotations;

namespace ServiceCenterWebApp.API.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
    }
}
