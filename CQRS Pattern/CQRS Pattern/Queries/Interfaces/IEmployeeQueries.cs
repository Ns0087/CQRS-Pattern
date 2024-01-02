using CQRS_Pattern.DTOs;

namespace CQRS_Pattern.Queries.Interfaces
{
    public interface IEmployeeQueries
    {
        public Task<List<EmployeeDTO>> GetAllEmployeesAsync();
        public Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
    }
}
