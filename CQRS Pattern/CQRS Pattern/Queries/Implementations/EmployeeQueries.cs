using AutoMapper;
using CQRS_Pattern.DAL.Entities;
using CQRS_Pattern.DAL.Repositories.Interfaces;
using CQRS_Pattern.DTOs;
using CQRS_Pattern.Queries.Interfaces;

namespace CQRS_Pattern.Queries.Implementations
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly IEmployeeQueriesRepository _employeeQueryRepository;
        private readonly IMapper _mapper;

        public EmployeeQueries(IServiceProvider serviceProvider)
        {
            _employeeQueryRepository = serviceProvider.GetRequiredService<IEmployeeQueriesRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            List<Employee> employees = await _employeeQueryRepository.GetAllEmployeesAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            Employee? employee = await _employeeQueryRepository.GetEmployeeByIdAsync(id);
            return employee is null ? throw new Exception("User doesn't exist") : _mapper.Map<EmployeeDTO>(employee);
        }
    }
}
