using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{//ControllerBase because we don't need view support.

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems)); // Return OK 200 success
        }

        //GET api/commands/{id}
        [HttpGet("{id:int}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem is null)
                return NotFound(); // 404 No command was found
            return Ok(_mapper.Map<CommandReadDto>(commandItem)); // Return OK 200 success
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            if(commandCreateDto is null || commandCreateDto.HowTo is null ||
            commandCreateDto.Line is null || commandCreateDto.Platform is null)
                return BadRequest();

            var commandModel =_mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);

            // Return command if save is successful
            if(_repository.SaveChanges())
            {
                var commandReadDto = _mapper.Map<CommandReadDto>(commandModel); // Seems obvious now, but this must happen after save or id=0
                return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
            }               

            // If save failed, return internal server error
            return StatusCode(500);
        }
    }
}