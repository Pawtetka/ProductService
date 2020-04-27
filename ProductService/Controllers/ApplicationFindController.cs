using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Business.Services;
using ProductService.Business.Services.Interfaces;

namespace ProductService.Controllers
{
    public class ApplicationFindController : Controller
    {
        private IApplicationService _applicationService;
        public ApplicationFindController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [HttpGet]
        public IActionResult ApplicationFindWindow()
        {
            return View("ApplicationFindWindow", new List<DeliveryApplication>());
        }
        [HttpPost]
        public IActionResult ApplicationFindWindow(string findType, string findText)
        {
            return View("ApplicationFindWindow", GetApps(findType, findText));
        }

        private ICollection<DeliveryApplication> GetApps(string findType, string findText)
        {
            //I have no choise...
            switch (findType)
            {
                case "Name":
                    return _applicationService.FindByName(findText);
                case "Date":
                    return _applicationService.FindByDate(findText);
                case "Count":
                    return _applicationService.FindByCount(findText);
                default:
                    break;
            }
            return null;
        }
    }
}