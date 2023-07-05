using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shafiee.Models.Entities;
using Shafiee.Models.Infrastructure.Contracts;
using Shafiee.Models.Infrastructure.Repository;

namespace Shafiee.Controllers
{
    public class ActivityTypeController : Controller
    {
        private readonly ActivityTypeRepository _repository;
        private readonly ActivityTypeContracts _contracts;
        public ActivityTypeController()
        {
            _repository = new ActivityTypeRepository();
            _contracts = new ActivityTypeContracts();
        }
        public IActionResult Index()
        {
            var activityTypes = _repository.ActivityTypes();
            return View(activityTypes);
        }
        public IActionResult Delete(int id) 
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(ActivityType activityType)
        {
            if (_contracts.EnsureNameNotExist(activityType.Name, activityType.Id) && _contracts.EnsureCodeNotExist(activityType.Code, activityType.Id))
            {
                _repository.Add(activityType);
                return RedirectToAction("Index");
            }
            else if (_contracts.EnsureNameNotExist(activityType.Name, activityType.Id) && !_contracts.EnsureCodeNotExist(activityType.Code, activityType.Id))
            {
                return BadRequest($"there is already an ActivityType with Code = {activityType.Code}");
            }
            else if (!_contracts.EnsureNameNotExist(activityType.Name, activityType.Id) && _contracts.EnsureCodeNotExist(activityType.Code, activityType.Id))
            {
                return BadRequest($"there is already an ActivityType with Name = {activityType.Name}");
            }
            else return BadRequest($"there is already an ActivityType with Name = {activityType.Name} , and with Code = {activityType.Code}");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var activityType = _repository.GetById(id);
            return View(activityType);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(ActivityType activityType)
        {
            if (_contracts.EnsureNameNotExist(activityType.Name, activityType.Id) && _contracts.EnsureCodeNotExist(activityType.Code, activityType.Id))
            {
                _repository.Update(activityType);
                return RedirectToAction("Index");
            }
            else if (_contracts.EnsureNameNotExist(activityType.Name, activityType.Id) && !_contracts.EnsureCodeNotExist(activityType.Code, activityType.Id))
            {
                return BadRequest($"there is already an ActivityType with Code = {activityType.Code}");
            }
            else if (!_contracts.EnsureNameNotExist(activityType.Name, activityType.Id) && _contracts.EnsureCodeNotExist(activityType.Code, activityType.Id))
            {
                return BadRequest($"there is already an ActivityType with Name = {activityType.Name}");
            }
            else return BadRequest($"there is already an ActivityType with Name = {activityType.Name} , and with Code = {activityType.Code}");
        }
        public IActionResult Details(int id)
        {
            var activityType = _repository.GetById(id);
            return View(activityType);
        }
    }
}
