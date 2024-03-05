using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAppBL;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;

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