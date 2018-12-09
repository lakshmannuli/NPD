using NPD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPD.DAL.EntityFramework;
using NPD.DAL.Repositories;

namespace NPD_UI.Controllers
{
    public class ClientCompanyController : BaseController
    {
        // GET: ClientCompany
        public ActionResult Index()
        {
            var list = new List<company>();
            try
            {
                if (TempData["Message"] != null)
                {
                    ViewBag.Message = TempData["Message"];
                    ViewBag.IsError = TempData["IsError"];
                }

                list = CompanyRepository.GetAllActive().ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Failed to get companies";
                ViewBag.IsError = false;
            }
          
            return View(list);
        }

        public ActionResult Add()
        {
            var model = new CompanyDTO();
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(CompanyDTO model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    ViewBag.Message = "Please enter company name";
                    ViewBag.IsError = true;
                    return View(model);
                }

                var company = new company()
                {
                    Address = model.Address,
                    Name = model.Name,
                    CreatedBy = this.CurrentSession.LoggedUser.Id,
                    CreatedDate = DateTime.Now,
                    Email = model.Email,
                    Fax = model.Fax,
                    ModifiedBy = this.CurrentSession.LoggedUser.Id,
                    ModifiedDate = DateTime.Now,
                    Phone = model.Phone,
                    Status = 1
                };

                CompanyRepository.SaveCompany(company);
                TempData["Message"] = "Company added successfully !!!";
                TempData["IsError"] = false;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Failed to save company";
                ViewBag.IsError = true;
            }
            return View(model);
        }
    }
}