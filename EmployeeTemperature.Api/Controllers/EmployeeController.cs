using EmployeeTemperature.Domain.Dtos;
using EmployeeTemperature.Domain.Entitties;
using EmployeeTemperature.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeTemperature.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }


        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var list = await _employeeService.GetAll();
            return list;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDto> Get(int id)
        {
            var employee = await _employeeService.Get(id);
            return employee;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmployeeDto model)
        {
            await _employeeService.Add(model);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDto model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }

            await _employeeService.Update(model);

            return Ok();
        }

    }
}
