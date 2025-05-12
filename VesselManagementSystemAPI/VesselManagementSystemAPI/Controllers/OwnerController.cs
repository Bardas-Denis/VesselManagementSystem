using Autofac.Features.OwnedInstances;
using Microsoft.AspNetCore.Mvc;
using VesselManagementSystemAPI.DTOs;
using VesselManagementSystemAPI.Models;
using VesselManagementSystemAPI.Services;

namespace VesselManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController: ControllerBase
    {
        private readonly IOwnerService _service;
        public OwnerController(IOwnerService service) => _service = service;

        /// <summary>
        /// This is a method used to delete an owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id); return NoContent(); }
    }
}
