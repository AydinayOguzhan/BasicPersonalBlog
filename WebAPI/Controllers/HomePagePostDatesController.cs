using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePagePostDatesController : ControllerBase
    {
        IHomePagePostDateService _homePagePostDateService;

        public HomePagePostDatesController(IHomePagePostDateService homePagePostDateService)
        {
            _homePagePostDateService = homePagePostDateService;
        }


        [HttpGet("get")]
        public IActionResult Get()
        {
            var result = _homePagePostDateService.Get();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(HomePagePostDate postDate)
        {
            var result = _homePagePostDateService.Update(postDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
