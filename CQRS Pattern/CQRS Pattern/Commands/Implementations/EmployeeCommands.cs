using AutoMapper;
using CQRS_Pattern.Commands.Interfaces;
using CQRS_Pattern.DAL.Entities;
using CQRS_Pattern.DAL.Repositories.Interfaces;
using CQRS_Pattern.DTOs;

namespace CQRS_Pattern.Commands.Implementations
{
    public class EmployeeCommands : IEmployeeCommands
    {
        private readonly IEmployeeCommandsRepository _employeeCommandsRepository;
        private readonly IMapper _mapper;

        public EmployeeCommands(IServiceProvider serviceProvider)
        {
            _employeeCommandsRepository = serviceProvider.GetRequiredService<IEmployeeCommandsRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<int> AddEmployeeAsync(EmployeeDTO employee)
        {
            return await _employeeCommandsRepository.AddEmployeeAsync(_mapper.Map<Employee>(employee));
        }

        public async Task<int> UpdateEmployeeAsync(int id, EmployeeDTO employee)
        {
            return await _employeeCommandsRepository.UpdateEmployeeAsync(id, _mapper.Map<Employee>(employee));
        }

        public async Task<int> DeleteEmployeeByIdAsync(int id)
        {
            return await _employeeCommandsRepository.DeleteEmployeeByIdAsync(id);
        }
    }
}
