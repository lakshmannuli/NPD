using NPD.DAL;
using NPD.DAL.EntityFramework;
using NPD.DAL.Repositories;
using NPD.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
                ViewBag.Enigineers = UsersinfoRepository.GetAllActiveEngineers();
            }
            catch (Exception ex)
            {

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
                if (model.Priority == null )
                {
                    ViewBag.Message = "Please select priority";
                    ViewBag.IsError = true;
                    return View(model);
                }
                if (model.Complexity == null )
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