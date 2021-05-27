using Business.Abstract;
using Entity.ConCreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private IRentalService _rantalService;
        public RentalController(IRentalService rentalService)
        {
            _rantalService = rentalService;
        }

        //  

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _rantalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAllRentalOfCars")]
        public IActionResult GetAllRentalOfCars()
        {
            var result = _rantalService.GetAllRentalOfCars();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _rantalService.GetById(new Rental() { RentalsId = id });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("Add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rantalService.Add(rental);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _rantalService.delete(new Rental() { RentalsId = id});
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("Update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rantalService.update(rental);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
