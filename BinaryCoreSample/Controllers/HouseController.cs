using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BinaryCoreSample.Services;
using BinaryCoreSample.Models;
using Microsoft.Extensions.Logging;
using System.IO;
using BinaryCoreSample.Logger;

namespace BinaryCoreSample.Controllers
{
    [Route("api/House")]
    public class HouseController : Controller
    {
        IHouseService service;
        ILoggerFactory loggerfactory;
        ILogger logger;
      //  CustomService customservice;
        public HouseController(IHouseService service)
        {
            this.service = service;
            loggerfactory = new LoggerFactory().AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logs.txt"));
            logger = loggerfactory.CreateLogger("FileLogger");
            logger.LogInformation("\n\n");
        }

        //GET api/House 
        [HttpGet]
        public async Task<List<House>> Get()
        {
            logger.LogInformation($"{DateTime.Now.ToString()} GET request to Houses db");

            return await service.GetAllAsync();
        }

        //// GET api/House/?floors=[]
       /* [HttpGet]
        public  List<House> GetHousesByFloors(int floors)
        {
            var result = customservice.GetHousesWithLessFloorsThenParam(floors);
            logger.LogInformation($"{DateTime.Now.ToString()} GET request GetHousesByFloors returned {result.Count} houses");
            return result;
        }*/

        // GET api/House/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            House house = await service.GetByIdAsync(id);
            if (house == null)
            {
                logger.LogInformation($"{DateTime.Now.ToString()} GET request returned BadRequest");
                return BadRequest();
            }
            logger.LogInformation($"{DateTime.Now.ToString()} GET request returned House with id={id}");
            return Ok(house);
        }

        // POST api/Home/?adress=[]&homemates=[]&floors=[]
        [HttpPost]
        public async Task<IActionResult> Post(string adress, int homemates, int floors)
        {
            House house = null;
            if (!string.IsNullOrWhiteSpace(adress))
                house = new House()
                {
                    Adress = adress,
                    NumberOfHomemates = homemates,
                    Floors = floors
                };

            if (house == null)
            {
                logger.LogInformation($"{DateTime.Now.ToString()} POST request returned BadRequest");
                return BadRequest();
            }

            logger.LogInformation($"{DateTime.Now.ToString()} POST request. House with name={adress}, NumberOfHomemates={homemates}, Floors = {floors} was successfully created");
            await service.AddAsync(house);
            return Ok(house);
        }

        // DELETE api/Home/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            House house = await service.GetByIdAsync(id);
            if (house == null)
            {
                logger.LogInformation($"{DateTime.Now.ToString()} DELETE request returned NotFound");
                return NotFound();
            }
            logger.LogInformation($"{DateTime.Now.ToString()} DELETE request successfully deleted House with id={id}");
            await service.DeleteAsync(id);
            return Ok(house);
        }
        
    }
}