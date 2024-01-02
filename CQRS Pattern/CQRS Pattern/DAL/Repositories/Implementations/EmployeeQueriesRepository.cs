using CQRS_Pattern.DAL.DBContext;
using CQRS_Pattern.DAL.Entities;
using CQRS_Pattern.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Pattern.DAL.Repositories.Implementations
{
    public class EmployeeQueriesRepository : IEmployeeQueriesRepository
    {
        private readonly ApplicationDBContext _employee;

        public EmployeeQueriesRepository(IServiceProvider serviceProvider)
        {
            _employee = serviceProvider.GetRequiredService<ApplicationDBContext>();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employee.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _employee.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
        }
    }
}
