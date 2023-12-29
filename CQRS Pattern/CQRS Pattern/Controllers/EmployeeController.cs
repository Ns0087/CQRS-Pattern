using CQRS_Pattern.Commands.Interfaces;
using CQRS_Pattern.DAL.DBContext;
using CQRS_Pattern.DTOs;
using CQRS_Pattern.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeCommands _employeeCommands;
        private readonly IEmployeeQueries _employeeQueries;

        public EmployeeController(IServiceProvider serviceProvider)
        {
            _employeeCommands = serviceProvider.GetRequiredService<IEmployeeCommands>();
            _employeeQueries = serviceProvider.GetRequiredService<IEmployeeQueries>();
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            return await _employeeQueries.GetAllEmployeesAsync();
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            return await _employeeQueries.GetEmployeeByIdAsync(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<string> AddEmployeeAsync(EmployeeDTO employee)
        {
            int res = await _employeeCommands.AddEmployeeAsync(employee);
            return res > 0 ? "Success" : "Please Try again later!!";
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateEmployeeAsync(int id, EmployeeDTO employee)
        {
            int res = await _employeeCommands.UpdateEmployeeAsync(id, employee);
            return res > 0 ? "Success" : "Please Try again later!!";
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteEmployeeByIdAsync(int id)
        {
            int res = await _employeeCommands.DeleteEmployeeByIdAsync(id);
            return res > 0 ? "Success" : "Please Try again later!!";
        }
    }
}
