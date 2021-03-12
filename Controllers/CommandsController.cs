using System.Collections.Generic;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{//ControllerBase because we don't need view support.

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {

        }

        [HttpGet]
        public ActionResult <Command> GetCommandById(int id)
        {

        }
    }
}