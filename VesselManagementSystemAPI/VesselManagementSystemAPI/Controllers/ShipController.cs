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

        /// <summary>
        /// This is a method used to get all ships
        /// </summary>
        /// <returns></returns>
        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        /// <summary>
        /// This is a method used to get all ships with all their details
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetWithDetails")] public async Task<IActionResult> GetAllWithDetails() => Ok(await _service.GetAllWithDetailsAsync());
        /// <summary>
        /// This is method used to get ship by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));

        /// <summary>
        /// This is a method used to add a ship
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateShipWithDetailsDto dto)
                                => CreatedAtAction(nameof(Get), new { id = (await _service.CreateWithDetailsAsync(dto)).Id }, dto);

        /// <summary>
        /// This is a method used to update a ship
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateShipDto dto)
        { await _service.UpdateAsync(id, dto); return NoContent(); }

        /// <summary>
        /// This is a method used to delete a ship
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { await _service.DeleteAsync(id); return NoContent(); }
    }
}
