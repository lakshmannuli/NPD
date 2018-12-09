﻿using NPD.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPD_UI.Controllers
{
    public class JobController : BaseController
    {
        // GET: Job
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            try
            {
                ViewBag.Priorities = FaultPrioritiesRepository.GetActivePriorities();
                ViewBag.Complexities = FaultComplexityRepository.GetActiveComplexities();
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}