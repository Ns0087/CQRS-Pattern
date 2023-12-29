using CQRS_Pattern.DAL.Entities;

namespace CQRS_Pattern.DAL.Repositories.Interfaces
{
    public interface IEmployeeCommandsRepository
    {
        public Task<int> AddEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(int id, Employee employee);
        public Task<int> DeleteEmployeeByIdAsync(int id);
    }
}
