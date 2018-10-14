using System.Linq;
using AppTest1.DataAccess;
using AppTest1.Models;
using AppTest1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static AppTest1.Infrastructure.Exceptions;

namespace AppTest1.Controllers
{
    public class PartnersController : Controller
    {
        private readonly IRepository<MormonsPartner> _repository;
        private readonly IRepository<Men> _menRepository;
        private readonly IRepository<Women> _womenRepository;

        public PartnersController(IRepository<MormonsPartner> repository, IRepository<Men> menRepository, IRepository<Women> womenRepository)
        {
            _repository = repository;
            _menRepository = menRepository;
            _womenRepository = womenRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var models = _repository.GetAll();

            var vms = models
               .Select(x => new PartnersRowModel
               {
                   Id = x.Id,
                   ManId = x.ManId,
                   ManName = x.Man.Name + " " + x.Man.LastName,
                   WomanId = x.WomanId,
                   WomanName = x.Woman.Name + " " + x.Woman.LastName
               });

            return View(vms);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                var model = id == null
                    ? new MormonsPartner()
                    : _repository.Get((int)id);

                var partnerMen = _menRepository
                    .GetAll()
                    .Select(x => new MenPartnersOptionModel
                    {
                        Id = x.Id,
                        Name = $"{x.Name}"
                    });

                var partnerWomen = _womenRepository
                    .GetAll()
                    .Select(x => new WomenPartnersOptionModel
                    {
                        Id = x.Id,
                        Name = $"{x.Name}"
                    });

                ViewData["partnerMen"] = partnerMen;
                ViewData["partnerWomen"] = partnerWomen;

                return View(model);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(MormonsPartner model)
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

                TempData["Message"] = "Couple successfully deleted!";

                return RedirectToAction(nameof(List));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}