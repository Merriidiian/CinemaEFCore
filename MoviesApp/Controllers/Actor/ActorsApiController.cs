using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Services;
using MoviesApp.Services.Actor.Dto;
using MoviesApp.ViewModels.Actor;

namespace MoviesApp.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsApiController:ControllerBase
    {
        private readonly IActorService _service;

        public ActorsApiController(IActorService service)
        {
            _service = service;
        }
        [HttpGet] // GET: /api/actors
        [ProducesResponseType(200, Type = typeof(IEnumerable<ActorDto>))]  
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ActorDto>> GetActors()
        {
            return Ok(_service.GetAllActors());
        }
        [HttpGet("{id}")] // GET: /api/actors/5
        [ProducesResponseType(200, Type = typeof(ActorDto))]  
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var actor = _service.GetActor(id);
            if (actor == null) return NotFound();  
            return Ok(actor);
        }
        [HttpPost] // POST: api/actors
        public ActionResult<ActorDto> PostActor(ActorDto inputDto)
        {

            var actor = _service.AddActor(inputDto);
            return CreatedAtAction("GetById", new { id = actor.Id }, actor);
        }
        [HttpPut("{id}")] // PUT: api/actors/5
        public IActionResult UpdateActor(int id, ActorDto editDto)
        {
            var actor = _service.UpdateActor(editDto);
            
            if (actor==null)
            {
                return BadRequest();
            }

            return Ok(actor);
        }
        [HttpDelete("{id}")] // DELETE: api/actor/5
        public ActionResult<ActorDto> DeleteActor(int id)
        {
            var actor = _service.DeleteActor(id);
            if (actor == null) return NotFound();  
                
            return Ok(actor);
        }
    }
}