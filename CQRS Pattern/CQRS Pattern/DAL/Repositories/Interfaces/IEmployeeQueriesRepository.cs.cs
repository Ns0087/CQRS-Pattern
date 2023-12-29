using CQRS_Pattern.DAL.Entities;

namespace CQRS_Pattern.DAL.Repositories.Interfaces
{
    public interface IEmployeeQueriesRepository
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee?> GetEmployeeByIdAsync(int id);
    }
}
