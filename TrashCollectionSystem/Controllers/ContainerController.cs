﻿using Data_Homework_.Context;
using Data_Homework_.Models;
using Data_Homework_.Operations;
using Data_Homework_.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Data_Homework_.Operations.CreateContainerCommand;

namespace TrashCollectionSystem.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ContainerController> _logger;
        private readonly TrashSystemDbContext _dbContext;
        public ContainerController(ILogger<ContainerController> logger, IUnitOfWork unitOfWork, TrashSystemDbContext dbContext)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IQueryable<Container> GetAllContainers()
        {
            return unitOfWork.Container.GetAll();

        }


        [HttpGet("{vehicleId}")]
        public IQueryable<Container> GetAllByVehicleId(int vehicleId)
        {
            return unitOfWork.Container.GetAll().Where(x => x.VehicleId == vehicleId);
        }


        [HttpGet("{vehicleId}/{N}")]
        public List<List<Container>> GetClusteredContainers(int vehicleId, int N)
        {
            var containers = unitOfWork.Container.GetAll().Where(x => x.VehicleId == vehicleId).ToList();
            var result = unitOfWork.Container.GetClusteredContainers(containers, N);
            return result;
               
        }


        [HttpPost]
        public async Task<IActionResult> CreateContainer([FromBody] CreateContainerModel createContainer)
        {
            CreateContainerCommand command = new CreateContainerCommand(_dbContext);
            try
            {
                command.Model = createContainer;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateContainer(int id, [FromBody] ContainerUpdateDto updateDto)
        {
            var i = await unitOfWork.Container.GetById(id);
            i.ContainerName = updateDto.ContainerName;
            i.Latitude = updateDto.Latitude;
            i.Longitude = updateDto.Longitude;
            await unitOfWork.Container.Update(id, i);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            await unitOfWork.Container.Delete(id);
            return Ok();
        }


    }
}
