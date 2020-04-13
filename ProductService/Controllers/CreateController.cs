﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
    public class CreateController : Controller
    {
        ApplicationCreator creatorService;
        public CreateController(ApplicationCreator creatorService)
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
            return View("CreateApplication", parameters);
        }
    }
}