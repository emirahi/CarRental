﻿using Business.Abstract;
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
    public class FindeksScoreController : ControllerBase
    {
        IFindeksScoreService _findeksScoreService;

        public FindeksScoreController(IFindeksScoreService findeksScoreService)
        {
            _findeksScoreService = findeksScoreService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _findeksScoreService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _findeksScoreService.GetByCustomerId(customerId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _findeksScoreService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(FindeksScore findeksScore)
        {
            var result = _findeksScoreService.Add(findeksScore);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(FindeksScore findeksScore)
        {
            var result = _findeksScoreService.Update(findeksScore);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(FindeksScore findeksScore)
        {
            var result = _findeksScoreService.Delete(findeksScore);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

    }
}
