using CQRS_Pattern.DTOs;

namespace CQRS_Pattern.Commands.Interfaces
{
    public interface IEmployeeCommands
    {
        public Task<int> AddEmployeeAsync(EmployeeDTO employee);
        public Task<int> UpdateEmployeeAsync(int id, EmployeeDTO employee);
        public Task<int> DeleteEmployeeByIdAsync(int id);
    }
}
