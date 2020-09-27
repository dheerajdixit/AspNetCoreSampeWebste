using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Practice.Model;
using Practice.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practice
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        IPhotoRepository photoRepository;
        public HomeController(IPhotoRepository employee)
        {
            photoRepository = employee;
        }
        [Route("~/")]
        public ViewResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel
            {
                PageTitle = "Employee List",
                Photo = photoRepository.GetAllPhoto()
            };
            return View(homeIndexViewModel);
        }

        [Route("{id?}")]
        public ViewResult Details(int? id)
        {

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                PageTitle = "Employee Detail",
                Photo = photoRepository.GetPhoto(id ?? 1)
            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Photo myphoto)
        {
            if (ModelState.IsValid)
            {
                var p = photoRepository.Add(myphoto);
                return RedirectToAction("index", p);
            }
            else
            {
                return View();
            }
        }
    }
}

