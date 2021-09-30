using DesignPatterASP.Models.ViewModels;
using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = _unitOfWork.Beers.Get().Select(o => new BeerViewModel()
            {
                 Id = o.BeerId,
                 Name = o.Name,
                 Style = o.Style
            });
            return View("Index", beers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormBeerViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var brands = _unitOfWork.Brands.Get();
                ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
                return View("Add", model);
            }

            var beer = new Beer();
            beer.Name = model.Name;
            beer.Style = model.Style;
            beer.BrandId = model.BrandId;
            if (model.BrandId == null)
            {
                var brand = new Brand()
                {
                    Name = model.OtherBrand,
                    BrandId = Guid.NewGuid()
                };

                beer.BrandId = brand.BrandId;

                _unitOfWork.Brands.Add(brand);
              
            }
           

            _unitOfWork.Beers.Add(beer);
            _unitOfWork.Save();
            

            return RedirectToAction("Index");

        }
    }
}
