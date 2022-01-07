using Dapper;
using Data_Homework_.ContainerRepo;
using Data_Homework_.Context;
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
using static Data_Homework_.Models.CreateVehicleCommand;

namespace TrashCollectionSystem.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<VehicleController> _logger;

        private readonly TrashSystemDbContext _dbContext;

        public VehicleController(ILogger<VehicleController> logger, IUnitOfWork unitOfWork, TrashSystemDbContext dbContext)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IQueryable<Vehicle> GetAllVehicles()
        {
            return unitOfWork.Vehicle.GetAll();
            
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] CreateVehicleModel createVehicle)
        {
            CreateVehicleCommand command = new CreateVehicleCommand(_dbContext);
            try
            {
                command.Model = createVehicle;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] VehicleUpdateModel updateDto)
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
