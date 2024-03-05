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
    [Route("api/[controller]/[action]")]
    [EnableCors("AppOrigin")]
    [ApiController]
    public class TrainingTypeController : ControllerBase
    {
        private readonly ITrainingTypeRepository _trainingTypeRepository;

        public TrainingTypeController(ITrainingTypeRepository trainingTypeRepository)
        {
            _trainingTypeRepository = trainingTypeRepository;
        }
        public ActionResult All()
        {
            var types = _trainingTypeRepository.GetAllTypes();
            return Ok(types);
        }
    }
}