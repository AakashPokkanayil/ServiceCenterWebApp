using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceCenterWebApp.API.Data;
using ServiceCenterWebApp.API.Models;

namespace ServiceCenterWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ServiceCenterDbContext _employeeDbContext;

        public EmployeeController(ServiceCenterDbContext EmployeeDbContext)
        {
            this._employeeDbContext = EmployeeDbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var employees = await _employeeDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [Route("{id:guid}")]
        [HttpGet]
        [ActionName("GetEmployee")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (employee!=null)
            {
                return Ok(employee);
            }
            return NotFound("Employee Not Found.");
            
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();
            await _employeeDbContext.Employees.AddAsync(employee);  
            await _employeeDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddEmployee), employee.EmployeeId,employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,[FromBody] Employee employee)
        {
            var currentEmployee = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (currentEmployee!=null)
            {
                currentEmployee.EmployeeName = employee.EmployeeName;
                currentEmployee.dob = employee.dob;
                currentEmployee.Experience = employee.Experience;
                currentEmployee.Role=employee.Role;
                currentEmployee.AdharID = employee.AdharID;
                currentEmployee.Qualification = employee.Qualification;
                currentEmployee.Address = employee.Address;
                await _employeeDbContext.SaveChangesAsync();
                return Ok(currentEmployee);
            }
            return NotFound("Employee Not Found");
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var currentEmployee = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (currentEmployee != null)
            {
                _employeeDbContext.Remove(currentEmployee);
                await _employeeDbContext.SaveChangesAsync();
                return Ok(currentEmployee);
            }
            return NotFound("Employee Not Fount");
            
        }

    }
}
