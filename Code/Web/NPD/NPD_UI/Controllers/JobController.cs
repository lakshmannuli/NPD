using NPD.DAL;
using NPD.DAL.EntityFramework;
using NPD.DAL.Repositories;
using NPD.ViewModel;
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
            var list = new List<CustomFault>();
            try
            {
                if (TempData["Message"] != null)
                {
                    ViewBag.Message = TempData["Message"];
                    ViewBag.IsError = TempData["IsError"];
                }

                list = FaultRepository.GetFaults(new Fault()).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Failed to get faults";
                ViewBag.IsError = false;
            }

            return View(list);
        }

        public ActionResult Add()
        {
            var model = new FaultDTO();
            try
            {
                ViewBag.Priorities = FaultPrioritiesRepository.GetActivePriorities();
                ViewBag.Complexities = FaultComplexityRepository.GetActiveComplexities();
                ViewBag.Companies = CompanyRepository.GetAllActive();
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(FaultDTO model, List<HttpPostedFileBase> imageFiles)
        {
            ViewBag.Priorities = FaultPrioritiesRepository.GetActivePriorities();
            ViewBag.Complexities = FaultComplexityRepository.GetActiveComplexities();
            ViewBag.Companies = CompanyRepository.GetAllActive();
            try
            {
                if (model.CompanyId == null || model.CompanyId <= 0)
                {
                    ViewBag.Message = "Please select company";
                    ViewBag.IsError = true;
                    return View(model);
                }
                if (string.IsNullOrEmpty(model.Location))
                {
                    ViewBag.Message = "Please enter location name";
                    ViewBag.IsError = true;
                    return View(model);
                }

                var fault = new Fault()
                {
                    CompanyId = model.CompanyId,
                    CreatedDate = DateTime.Now,
                    CreatedBy = this.CurrentSession.LoggedUser.Id,
                    Complexity = model.Complexity,
                    FaultDescription = model.FaultDescription,
                    FaultStatus = model.Priority < 1 ? 0 : 1,
                    Location = model.Location,
                    MachineDescription = model.MachineDescription,
                    ModifiedBy = this.CurrentSession.LoggedUser.Id,
                    ModifiedDate = DateTime.Now,
                    Priority = model.Priority,
                    StartDate = DateTime.Now,
                    Status = 1
                };
                FaultRepository.SaveFault(fault);
                TempData["Message"] = "Job added successfully !!!";
                TempData["IsError"] = false;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Failed to save job details";
                ViewBag.IsError = true;
            }
            return View(model);
        }
    }
}