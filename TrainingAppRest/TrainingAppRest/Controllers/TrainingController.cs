using Microsoft.AspNetCore.Mvc;
using System;
using TrainingAppBL;
using TrainingAppDAL;
using Microsoft.AspNetCore.Cors;
using TrainingAppBL.Interfaces;
using TrainingAppDAL.Model;

namespace TrainingAppRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("AppOrigin")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingController(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        [HttpGet]
        public ActionResult OfUser(int id)
        {
            try
            {
                var trainings = _trainingRepository.GetTrainingsOfUser(id);
                return Ok(trainings);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult OfTeam(int id)
        {
            try
            {
                var trainings = _trainingRepository.GetTrainingsOfTeam(id);
                return Ok(trainings);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody]Training training)
        {
            try
            {
                _trainingRepository.CreateTraining(training);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult Update([FromBody] Training training)
        {
            try
            {
                _trainingRepository.UpdateTraining(training);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}