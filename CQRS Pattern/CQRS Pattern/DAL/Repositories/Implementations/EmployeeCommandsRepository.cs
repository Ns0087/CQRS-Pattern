using CQRS_Pattern.DAL.DBContext;
using CQRS_Pattern.DAL.Entities;
using CQRS_Pattern.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Pattern.DAL.Repositories.Implementations
{
    public class EmployeeCommandsRepository : IEmployeeCommandsRepository
    {
        private readonly ApplicationDBContext _employee;
        private readonly IEmployeeQueriesRepository _employeeQueriesRepository;

        public EmployeeCommandsRepository(IServiceProvider serviceProvider)
        {
            _employee = serviceProvider.GetRequiredService<ApplicationDBContext>();
            _employeeQueriesRepository = serviceProvider.GetRequiredService<IEmployeeQueriesRepository>();
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            int result = 0;

            try
            {
                await _employee.Employees.AddAsync(employee);
                result = await _employee.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public async Task<int> UpdateEmployeeAsync(int id, Employee employee)
        {
            int result = 0;

            try
            {
                var employee1 = await _employeeQueriesRepository.GetEmployeeByIdAsync(id) ?? throw new Exception("User dosen't exist");

                employee1.Id = id;
                employee1.FirstName = employee.FirstName;
                employee1.LastName = employee.LastName;
                employee1.Address = employee.Address;

                result = await _employee.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public async Task<int> DeleteEmployeeByIdAsync(int id)
        {
            int result = 0;

            try
            {
                var employee = await _employeeQueriesRepository.GetEmployeeByIdAsync(id) ?? throw new Exception("User dosen't exist");
                
                _employee.Employees.Remove(employee);
                result = await _employee.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
    }
}
