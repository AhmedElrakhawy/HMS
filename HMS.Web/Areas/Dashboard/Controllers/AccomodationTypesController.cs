using HMS.Entities;
using HMS.Services;
using HMS.Web.Areas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listing()
        {
            var Model = new AccomodationTypesListingViewModel();
            Model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
            return PartialView("_Listing",Model);
        }
        public ActionResult Action()
        {
            var Model = new AccomodationTypesActionViewModel();
            return PartialView("_Action",Model);
        }
        [HttpPost]
        public JsonResult Action(AccomodationType Model)
        {
            var Json = new JsonResult();
            var accomodationType = new AccomodationType();
            accomodationType.Name = Model.Name;
            accomodationType.Description = Model.Description;
            var Result = accomodationTypesService.SaveAccomodationType(accomodationType);

            if (Result)
            {
                Json.Data = new { Success = true };
            }
            else
            {
                Json.Data = new { Success = false, Message = "Failed To Add New Accomodation Type" };
            }

            return Json;
        }
    }
}