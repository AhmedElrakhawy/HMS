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
        public ActionResult Index(string SearchTerm)
        {
            var Model = new AccomodationTypesListingViewModel();
            Model.SearchTerm = SearchTerm;
            Model.AccomodationTypes = accomodationTypesService.SearchAccomodationTypes(SearchTerm);
            return View(Model);
        }
        public ActionResult Action(int? ID)
        {
            var Model = new AccomodationTypesActionViewModel();
            if (ID.HasValue)
            {
                var accomodationTypeModel = accomodationTypesService.GetAccomodationTypeByID(ID.Value);
                Model.ID = accomodationTypeModel.ID;
                Model.Name = accomodationTypeModel.Name;
                Model.Description = accomodationTypeModel.Description;
            }

            return PartialView("_Action", Model);
        }
        [HttpPost]
        public JsonResult Action(AccomodationType Model)
        {
            var Json = new JsonResult();
            var Result = false;
            if (Model.ID > 0)
            {
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(Model.ID);
                accomodationType.Name = Model.Name;
                accomodationType.Description = Model.Description;
                Result = accomodationTypesService.UpdateAccomodationType(accomodationType);
            }
            else
            {
                var accomodationType = new AccomodationType();
                accomodationType.Name = Model.Name;
                accomodationType.Description = Model.Description;
                Result = accomodationTypesService.SaveAccomodationType(accomodationType);
            }


            if (Result)
            {
                Json.Data = new { Success = true };
            }
            else
            {
                Json.Data = new { Success = false, Message = "Failed To Perform Action on Accomodation Type" };
            }

            return Json;
        }
        public ActionResult Delete(int Id)
        {
            var accomodationtype = new AccomodationType();
            accomodationtype.ID = Id;
            return PartialView("_Delete", accomodationtype);
        }
        [HttpPost]
        public JsonResult Delete(AccomodationType Model)
        {
            var Json = new JsonResult();
            var Result = false;
            Model = accomodationTypesService.GetAccomodationTypeByID(Model.ID);
            Result = accomodationTypesService.DeleteAccomodationType(Model);

            if (Result)
            {
                Json.Data = new { Success = true };
            }
            else
            {
                Json.Data = new { Success = false, Message = "Failed To Delete this Accomodation Type" };
            }

            return Json;
        }
    }
}