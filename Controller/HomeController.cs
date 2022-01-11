using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using PhotoManager;
using PhotoManager.Services;
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
        IHostingEnvironment environment;
        AzureBlobService blobService;
        public HomeController(IPhotoRepository employee, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            photoRepository = employee;
            environment= hostingEnvironment;
            blobService = new AzureBlobService(configuration);
        }
        [Route("~/")]
        public ViewResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel
            {
                PageTitle = "Family Album",
                Photo = photoRepository.GetAllPhoto()
            };
            return View(homeIndexViewModel);
        }

        [Route("{id?}")]
        public ViewResult Details(int? id)
        {

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                PageTitle = "Photo Detail",
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
        public async Task<IActionResult> Create(PhotoViewModel myphoto)
        {
            if (ModelState.IsValid)
            {
                Stream filestream = null;
                try
                {
                    Photo p1 = new Photo();
                    p1.UniquePhotoName = Guid.NewGuid().ToString() + "_" + myphoto.Photo.FileName;
                    p1.Story = myphoto.Story;
                    p1.Location = myphoto.Location;
                    p1.PhotoLead = myphoto.PhotoLead;

                    myphoto.Photo.CopyTo(new FileStream(Path.Combine(environment.WebRootPath, "images", p1.UniquePhotoName), FileMode.OpenOrCreate, FileAccess.Write));
                    filestream = myphoto.Photo.OpenReadStream();
                  var path=  await blobService.UploadBlobAsync(p1.UniquePhotoName, filestream);

                    p1.AZ_Photo_Uri = path;

                    var p = photoRepository.Add(p1);
                    return RedirectToAction("index", p);

                }
                catch(Exception ex)
                {
                    return View();
                }
                finally
                {
                    if(filestream != null)
                    {
                        filestream.Close();
                        filestream.Dispose();
                    }

                   
                }
            }
            else
            {
                return View();
            }
        }
    }
}

