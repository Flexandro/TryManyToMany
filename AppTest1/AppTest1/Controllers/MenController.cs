using System.Linq;
using AppTest1.DataAccess;
using AppTest1.Models;
using AppTest1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static AppTest1.Infrastructure.Exceptions;

namespace AppTest1.Controllers
{
    public class MenController : Controller
    {
        private readonly IRepository<Men> _repository;
        private readonly IRepository<Women> _womenRepository;
        private readonly IRepository<MormonsPartner> _partnersRepository;

        public MenController(IRepository<Men> repository, IRepository<Women> womenRepository, IRepository<MormonsPartner> partnersRepository)
        {
            _repository = repository;
            _womenRepository = womenRepository;
            _partnersRepository = partnersRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var models = _repository.GetAll();

            var vms = models
                .Select(x => new MenRowModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName
                });

            return View(vms);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                var model = id == null
                    ? new Men()
                    : _repository.Get((int)id);

                return View(model);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Men model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                if (model.Id == 0)
                    _repository.Insert(model);
                else
                    _repository.Update(model);

                return RedirectToAction(nameof(List));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _repository.Get(id);

                return View(model);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                _repository.Delete(id);

                TempData["Message"] = "Man successfully deleted!";

                return RedirectToAction(nameof(List));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}