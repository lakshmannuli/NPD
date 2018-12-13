using NPD.DAL;
using NPD.DAL.EntityFramework;
using NPD.DAL.Repositories;
using NPD.ViewModel;
using NPD_UI.Custom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPD_UI.Controllers
{
    [CustomAuthorization]
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
                ViewBag.IsError = true;
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
                ViewBag.Enigineers = UsersinfoRepository.GetAllActiveEngineers();
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new FaultDTO();

            try
            {
                if (TempData["Message"] != null)
                {
                    ViewBag.Message = TempData["Message"];
                    ViewBag.IsError = TempData["IsError"];
                }

                ViewBag.Priorities = FaultPrioritiesRepository.GetActivePriorities();
                ViewBag.Complexities = FaultComplexityRepository.GetActiveComplexities();
                ViewBag.Companies = CompanyRepository.GetAllActive();
                ViewBag.Enigineers = UsersinfoRepository.GetAllActiveEngineers();

                var fault = FaultRepository.GetFaultById(id);
                if (fault != null)
                {
                    model.AssignedTo = fault.AssignedTo;
                    model.CompanyId = fault.CompanyId;
                    model.Complexity = fault.Complexity;
                    model.FaultDescription = fault.FaultDescription;
                    model.FaultStatus = fault.FaultStatus;
                    model.Id = fault.Id;
                    model.Location = fault.Location;
                    model.MachineDescription = fault.MachineDescription;
                    model.Priority = fault.Priority;
                    model.StartDate = fault.StartDate;
                    return View(model);
                }
                TempData["Message"] = "No job exists with this Id.";
                TempData["IsError"] = true;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FaultDTO model)
        {
            ViewBag.Priorities = FaultPrioritiesRepository.GetActivePriorities();
            ViewBag.Complexities = FaultComplexityRepository.GetActiveComplexities();
            ViewBag.Companies = CompanyRepository.GetAllActive();
            ViewBag.Enigineers = UsersinfoRepository.GetAllActiveEngineers();
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
                if (model.Priority == null)
                {
                    ViewBag.Message = "Please select priority";
                    ViewBag.IsError = true;
                    return View(model);
                }
                if (model.Complexity == null)
                {
                    ViewBag.Message = "Please select complexity";
                    ViewBag.IsError = true;
                    return View(model);
                }
                if (model.AssignedTo == null || model.AssignedTo <= 0)
                {
                    ViewBag.Message = "Please select an engineer";
                    ViewBag.IsError = true;
                    return View(model);
                }
                var imageLibrary = new FaultLibrary();

                var fault = FaultRepository.GetFaultById(model.Id);

                fault.CompanyId = model.CompanyId;
                fault.Complexity = model.Complexity;
                fault.FaultDescription = model.FaultDescription;
                fault.FaultStatus = model.Priority < 1 ? 0 : 1;
                fault.Location = model.Location;
                fault.MachineDescription = model.MachineDescription;
                fault.ModifiedBy = this.CurrentSession.LoggedUser.Id;
                fault.ModifiedDate = DateTime.Now;
                fault.Priority = model.Priority;
                fault.StartDate = DateTime.Now;
                fault.AssignedTo = model.AssignedTo;

                FaultRepository.UpdateFault(fault);
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

        [HttpPost]
        public ActionResult Add(FaultDTO model, HttpPostedFileBase postedfile)
        {
            ViewBag.Priorities = FaultPrioritiesRepository.GetActivePriorities();
            ViewBag.Complexities = FaultComplexityRepository.GetActiveComplexities();
            ViewBag.Companies = CompanyRepository.GetAllActive();
            ViewBag.Enigineers = UsersinfoRepository.GetAllActiveEngineers();
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
                if (model.Priority == null)
                {
                    ViewBag.Message = "Please select priority";
                    ViewBag.IsError = true;
                    return View(model);
                }
                if (model.Complexity == null)
                {
                    ViewBag.Message = "Please select complexity";
                    ViewBag.IsError = true;
                    return View(model);
                }
                if (model.AssignedTo == null || model.AssignedTo <= 0)
                {
                    ViewBag.Message = "Please select an engineer";
                    ViewBag.IsError = true;
                    return View(model);
                }
                var imageLibrary = new FaultLibrary();
                if (postedfile != null)
                {
                    var filePath = SaveImage(postedfile);
                    imageLibrary.FileName = postedfile.FileName;
                    imageLibrary.Url = filePath;
                    imageLibrary.ModifiedBy = this.CurrentSession.LoggedUser.Id;
                    imageLibrary.ModifiedDate = DateTime.Now;
                    imageLibrary.CreatedDate = DateTime.Now;
                    imageLibrary.CreatedBy = this.CurrentSession.LoggedUser.Id;
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
                    Status = 1,
                    AssignedTo = model.AssignedTo,
                    FaultLibraries = new List<FaultLibrary>()
                };
                if (!string.IsNullOrEmpty(imageLibrary.Url))
                {
                    imageLibrary.FaultId = fault.Id;
                    fault.FaultLibraries.Add(imageLibrary);
                }

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

        [HttpPost]
        public ActionResult UploadFiles(FaultDTO model, HttpPostedFileBase postedfile)
        {
            ViewBag.Priorities = FaultPrioritiesRepository.GetActivePriorities();
            ViewBag.Complexities = FaultComplexityRepository.GetActiveComplexities();
            ViewBag.Companies = CompanyRepository.GetAllActive();
            ViewBag.Enigineers = UsersinfoRepository.GetAllActiveEngineers();
            try
            {

                var imageLibrary = new FaultLibrary();
                if (postedfile != null)
                {
                    var filePath = SaveImage(postedfile);
                    imageLibrary.FileName = postedfile.FileName;
                    imageLibrary.Url = filePath;
                    imageLibrary.FaultId = model.Id;
                    imageLibrary.ModifiedBy = this.CurrentSession.LoggedUser.Id;
                    imageLibrary.ModifiedDate = DateTime.Now;
                    imageLibrary.CreatedDate = DateTime.Now;
                    imageLibrary.CreatedBy = this.CurrentSession.LoggedUser.Id;
                }

                FaultRepository.SaveFile(imageLibrary);
                TempData["Message"] = "Files uploaded successfully !!!";
                TempData["IsError"] = false;
                return RedirectToAction("Edit", new { id = model.Id });
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Files uploaded successfully !!!";
                TempData["IsError"] = false;
            }
            return RedirectToAction("Edit", new { id = model.Id });
        }

        private string SaveImage(HttpPostedFileBase fpUpload)
        {
            var ext = Path.GetExtension(fpUpload.FileName);
            var modifiedPath = Guid.NewGuid().ToString();
            var filepath = Server.MapPath("~") + "\\LibraryImages\\" + modifiedPath + ext;
            fpUpload.SaveAs(filepath);
            return modifiedPath + ext;
        }
    }
}