using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {        
        public CommandsProfile()
        {
            // Source -> Destination
            CreateMap<Command, CommandReadDto>();

            // Destination -> Source
            CreateMap<CommandCreateDto, Command>();

            CreateMap<CommandUpdateDto, Command>();
        }
    }
}