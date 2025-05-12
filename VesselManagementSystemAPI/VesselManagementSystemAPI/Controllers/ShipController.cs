using Microsoft.AspNetCore.Mvc;
using VesselManagementSystemAPI.DTOs;
using VesselManagementSystemAPI.Models;
using VesselManagementSystemAPI.Services;

namespace VesselManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly IShipService _service;
        public ShipController(IShipService service) => _service = service;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        [HttpGet("GetWithDetails")] public async Task<IActionResult> GetAllWithDetails() => Ok(await _service.GetAllWithDetailsAsync());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateShipWithDetailsDto dto)
                                => CreatedAtAction(nameof(Get), new { id = (await _service.CreateWithDetailsAsync(dto)).Id }, dto);
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateShipDto dto)
        { await _service.UpdateAsync(id, dto); return NoContent(); }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { await _service.DeleteAsync(id); return NoContent(); }
    }
}
