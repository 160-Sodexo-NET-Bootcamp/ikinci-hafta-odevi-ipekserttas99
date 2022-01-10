using AutoMapper;
using Data_Homework_.Context;
using Data_Homework_.Models;
using Data_Homework_.Uow;
using Data_Homework_.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectionSystem.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ContainerController> _logger;
        private readonly IMapper _mapper;
        public ContainerController(ILogger<ContainerController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public async Task<IActionResult> CreateContainer([FromBody] CreateContainerViewModel createContainer)
        {
            await unitOfWork.Container.Create(createContainer);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateContainer(int id, [FromBody] UpdateContainerViewModel updatedContainer)
        {
            await unitOfWork.Container.Update(id, updatedContainer);
            return Ok(updatedContainer);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            await unitOfWork.Container.Delete(id);
            return Ok();
        }


    }
}
