using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TrainingAppBL.Interfaces;

namespace TrainingAppRest.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AppOrigin")]
    [ApiController]
    public class TeamMembershipController : ControllerBase
    {
        private readonly ITeamMembershipRepository _teamMembershipRepository;

        public TeamMembershipController(ITeamMembershipRepository teamMembershipRepository)
        {
            _teamMembershipRepository = teamMembershipRepository;
        }

        public ActionResult OfUser(int id)
        {
            var memberships = _teamMembershipRepository.GetTeamMembershipsOfUser(id);
            return Ok(memberships);
        }
    }
}