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
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        IColorService _colorService;
        IBrandService _brandService;
        public CarsController(ICarService carService,IColorService colorService,IBrandService brandService)
        {
            _carService = carService;
            _colorService = colorService;
            _brandService = brandService;
        }

        //https://localhost:44320/api/Cars/GetAll

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllDto")]
        public IActionResult GetAllDto()
        {
            var result = _carService.GetAllDto();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetCarsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            Car car = new Car() { Id = id };
            var result = _carService.delete(car);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result.Success);
        }

        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.update(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByBrandId")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _brandService.GetByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("GetByColorId")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _colorService.GetByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetSearchList")]
        public IActionResult GetSearchList(int brandId, int colorId)
        {
            var result = _carService.GetBySearch(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCarDetails")]
        public IActionResult GetCarDetails(int carId)
        {
            var result = _carService.GetCarsById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
