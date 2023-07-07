using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Company;
using Service.DTOs.Employee;
using Service.Services.Interfaces;

namespace ApiOnion.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateDto request)
        {
            await _service.CreateAsync(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EmployeeUpdateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.UpdateAsync(id, request);
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromBody] EmployeeGetByIdDto request, [FromRoute] int id)
        {

            await _service.GetByIdAsync(id, request);
            return Ok();

        }
             [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _service.DeleteAsync(id);

        }

    }
}
