using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Company;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ApiOnion.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class CompanyController: ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyCreateDto request)
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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CompanyUpdateDto request)
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
        public async Task<IActionResult> GetById([FromBody] CompanyGetByIdDto request, [FromRoute] int id)
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
