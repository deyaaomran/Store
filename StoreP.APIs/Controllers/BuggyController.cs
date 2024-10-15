﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreP.Repository.Data.Contexts;

namespace StoreP.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public BuggyController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")] // Get: /api/Buggy/notfound
        public async Task<IActionResult> GetNotFoundRequest()
        {
            var brand = await _context.Brands.FindAsync(100);
            if (brand is null) return NotFound();
            return Ok(brand);
        }

        [HttpGet("servererror")] // Get: /api/Buggy/servererror
        public async Task<IActionResult> GetServerError()
        {
            var brand = await _context.Brands.FindAsync(100);
            
            var brabdToString = brand.ToString(); // will throw (NullReferenceException)

            return Ok(brand);
        }

        [HttpGet("badrequest")] // Get: /api/Buggy/badrequest
        public async Task<IActionResult> GetBadRequestError()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")] // Get: /api/Buggy/badrequest/ahmed
        public async Task<IActionResult> GetBadRequestError(int id) // Validation Error
        {
            return Ok();
        }


        [HttpGet("unauthorized")] // Get: /api/Buggy/unauthorized
        public async Task<IActionResult> GetError() 
        {
            return Unauthorized();
        }



    }
}