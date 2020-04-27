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
    public class CreateController : Controller
    {
        IApplicationCreator creatorService;
        public CreateController(IApplicationCreator creatorService)
        {
            this.creatorService = creatorService;
        }
        [HttpGet]
        public ActionResult CreateApplication()
        {
            ApplicationParameters parameters = new ApplicationParameters();
            return View("CreateApplication", parameters);
        }
        [HttpPost]
        public ActionResult CreateApplication(string products, ApplicationParameters parameters)
        {
            products.Trim();
            parameters.ProductNames = products.Split(",").ToList();
            creatorService.Create(parameters);
            return RedirectToAction("CreateApplication");
        }
    }
}