using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Uploadify.Models;
using Uploadify.Services;
using Uploadify.ViewModels;

namespace Uploadify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IDocumentRepository _docRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(ILogger<HomeController> logger,IUserRepository userRepository,IDocumentRepository docRepository, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _userRepository = userRepository;
            _docRepository = docRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            TempData.Remove("Message");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Submit(FormDataModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    EmailAddress = model.EmailAddress,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    TransactionRef = Guid.NewGuid().ToString().Substring(0, 10)
                };
                var newUser = _userRepository.CreateUser(user);
                foreach (var file in model.files)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var extension = Path.GetExtension(file.FileName);

                    ////Upload Document to wwwroot folder
                    //string folder = Path.Combine(hostingEnvironment.WebRootPath, "files");
                    //string fullpath = Path.Combine(folder, fileName);
                    //file.CopyTo(new FileStream(fullpath, FileMode.Create));

                    var doc = new Document
                    {
                        FileType = file.ContentType,
                        Extension = extension,
                        Name = fileName,
                        UserId = newUser.UserId,
                        //Fullpath = fullpath
                    };

                    _docRepository.CreateDoc(doc);
                }
                TempData["Message"] = "File successfully uploaded";
                return RedirectToAction("Index");
            }
            return View();
        } 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
