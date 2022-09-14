using AutoMapper;
using EmployeeTemperature.Domain.Dtos;
using EmployeeTemperature.Domain.Entitties;
using EmployeeTemperature.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Services.Services
{
    public class TemperatureService : ITemperatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TemperatureService> _logger;
        private readonly IMapper _mapper;

        public TemperatureService(IUnitOfWork unitOfWork, ILogger<TemperatureService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemperatureDto>> GetAll()
        {
            var records = await _unitOfWork.TemperatureRepository.GetAll();
            return _mapper.Map<IEnumerable<TemperatureDto>>(records);
        }

        public async Task<IEnumerable<TemperatureDto>> GetAllByEmployeeId(int employeeId)
        {
            var records = await _unitOfWork.TemperatureRepository.GetAllByEmployeeId(employeeId);

            return _mapper.Map<IEnumerable<TemperatureDto>>(records.ToList());
        }

        public async Task<TemperatureDto> Get(int id)
        {
            var record = await _unitOfWork.TemperatureRepository.Get(id);
            return _mapper.Map<TemperatureDto>(record);
        }

        public async Task Update(TemperatureDto temperatureInput)
        {
            try
            {
                var model = _mapper.Map<TemperatureDto>(temperatureInput);

                var temperature = await _unitOfWork.TemperatureRepository.Get(model.Id);
                if (temperature == null)
                    throw new KeyNotFoundException();

                temperature.Value = model.Value;
                temperature.RecordDate = model.RecordDate;
                _unitOfWork.TemperatureRepository.Update(temperature);
                _unitOfWork.Complete();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task Add(TemperatureDto temperatureInput)
        {
            try
            {
                var model = _mapper.Map<Temperature>(temperatureInput);

                await _unitOfWork.TemperatureRepository.Add(model);
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

        public async Task<IEnumerable<EmployeeTemperatureDto>> Search(FilterInput input)
        {            
            var list = await _unitOfWork.TemperatureRepository.Search(input.Search, input.RecordFrom, input.RecordTo, input.TempFrom, input.TempTo);
            return _mapper.Map<IEnumerable<EmployeeTemperatureDto>>(list);
        }
    }
}
