using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TrainingAppBL.Interfaces;

namespace TrainingAppRest.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AppOrigin")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet("{id}")]
        public ActionResult ById(int id)
        {
            var team = _teamRepository.GetTeamById(id);
            return Ok(team);
        }
    }
}