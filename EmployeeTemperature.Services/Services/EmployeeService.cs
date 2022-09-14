using EmployeeTemperature.Domain.Entitties;
using EmployeeTemperature.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeTemperature.Domain.Dtos;

namespace EmployeeTemperature.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, ILogger<EmployeeService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IList<EmployeeDto>> GetAll()
        {
            var records = await _unitOfWork.EmployeeRepository.GetAll();
            return _mapper.Map<IList<EmployeeDto>>(records);
            
        }

        public async Task<EmployeeDto> Get(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.Get(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task Update(EmployeeDto employeeInput)
        {
            try
            {
                var model = _mapper.Map<Employee>(employeeInput);

                var employee = await _unitOfWork.EmployeeRepository.Get(model.Id);
                if (employee == null)
                    throw new KeyNotFoundException();

                employee.EmployeeNumber = model.EmployeeNumber;
                employee.FirstName = model.FirstName;
                employee.LastName  = model.LastName;
                _unitOfWork.EmployeeRepository.Update(employee);
                _unitOfWork.Complete();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task Add(EmployeeDto employeeInput)
        {
            try
            {
                var model = _mapper.Map<Employee>(employeeInput);

                await _unitOfWork.EmployeeRepository.Add(model);
                _unitOfWork.Complete();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
