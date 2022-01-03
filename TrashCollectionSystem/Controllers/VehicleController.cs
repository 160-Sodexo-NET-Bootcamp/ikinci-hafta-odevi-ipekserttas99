using Dapper;
using Data_Homework_.ContainerRepo;
using Data_Homework_.Models;
using Data_Homework_.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectionSystem.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<VehicleController> _logger;
        

        public VehicleController(ILogger<VehicleController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IQueryable<Vehicle> GetAllVehicles()
        {
            return unitOfWork.Vehicle.GetAll();
            
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetVehicleById(int id)
        //{
        //    var vehicle = await unitOfWork.Vehicle.GetById(id);

        //    if (vehicle is null)
        //        return NotFound();

        //    return Ok(vehicle);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] Vehicle vehicle)
        {
            await unitOfWork.Vehicle.Create(vehicle);
            unitOfWork.Complete();
            CreatedAtAction("GetById", new {   }, vehicle);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] VehicleUpdateDto updateDto)
        {
            var i = await unitOfWork.Vehicle.GetById(id);
            i.VehicleName = updateDto.VehicleName;
            i.VehiclePlate = updateDto.VehiclePlate;
            await unitOfWork.Vehicle.Update(id, i);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await unitOfWork.Vehicle.Delete(id);
            return Ok();
        }

    }
}
