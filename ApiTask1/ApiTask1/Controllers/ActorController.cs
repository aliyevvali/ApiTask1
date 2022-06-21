using ApiTask1.DAL;
using ApiTask1.Dtos.ActorDtos;
using ApiTask1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ActorController(AppDbContext con)
        {
            _context = con;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllActor()
        {
            List<Actor> actor = await _context.Actors.ToListAsync();
            return Ok(actor);
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> GetById(int id)
        {
            Actor actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actor == null) return BadRequest();
            return Ok(actor);
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(ActorDto actorDto)
        {
            Actor actor = new Actor()
            {
                Age = actorDto.Age,
                Name = actorDto.Name,
                Image = actorDto.Image
                
            };
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
            return Ok(actorDto);
        }
    }
}
