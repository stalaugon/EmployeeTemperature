using EmployeeTemperature.Domain.Dtos;
using EmployeeTemperature.Domain.Entitties;
using EmployeeTemperature.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTemperature.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ILogger<TemperatureController> _logger;
        private readonly ITemperatureService _temperatureService;

        public TemperatureController(ILogger<TemperatureController> logger, ITemperatureService temperatureService)
        {
            _logger = logger;
            _temperatureService = temperatureService;
        }

        [HttpGet]
        public async Task<IEnumerable<TemperatureDto>> GetAll()
        {
            var list = await _temperatureService.GetAll();
            return list;
        }

        [HttpGet("{id}")]
        public async Task<TemperatureDto> Get(int id)
        {
            var temperature = await _temperatureService.Get(id);
            return temperature;
        }

        [HttpGet("Employee/{id}")]
        public async Task<IEnumerable<TemperatureDto>> GetByEmployeeId(int id)
        {
            var list = await _temperatureService.GetAllByEmployeeId(id);
            return list;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TemperatureDto model)
        {
            await _temperatureService.Add(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TemperatureDto model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            await _temperatureService.Update(model);
            return Ok();
        }

        [HttpGet("Search")]
        public async Task<IEnumerable<EmployeeTemperatureDto>> GetByEmployeeId([FromQuery] FilterInput input)
        {
            var list = await _temperatureService.Search(input);
            return list;
        }
    }
}
