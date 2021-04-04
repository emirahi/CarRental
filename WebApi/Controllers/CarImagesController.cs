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
    public class CarImagesController : ControllerBase
    {
        private ICarImagesServices _carImageService;

        public CarImagesController(ICarImagesServices carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("get")]
        public IActionResult Get(int imageId)
        {
            var result = _carImageService.Get(imageId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcarimages")]
        public IActionResult GetCarImages(int carId)
        {
            var result = _carImageService.GetCarImages(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("ImagePath"))] IFormFile file, [FromForm] CarImages image)
        {
            var result = _carImageService.Add(file, image);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = "Id")] int Id)
        {
            var imageToDelete = _carImageService.Get(Id).Data;
            var result = _carImageService.Delete(imageToDelete);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int id)
        {
            var imageToBeUpdated = _carImageService.Get(id).Data;
            var result = _carImageService.Update(file, imageToBeUpdated);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
