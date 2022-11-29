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
    public class AccomodationPackagesController : Controller
    {
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        AccomodationPackagesService accomodationPackageServices = new AccomodationPackagesService();
        public ActionResult Index(string SearchTerm)
        {
            var Model = new AccomodationPackagesListingViewModel();
            Model.SearchTerm = SearchTerm;
            Model.AccomodationPackages = accomodationPackageServices.SearchAccomodationPackages(SearchTerm);
            Model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
            return View(Model);
        }
        public ActionResult Action(int? ID)
        {
            var Model = new AccomodationPackagesActionViewModel();
            if (ID.HasValue)
            {
                var accomodationPackageModel = accomodationPackageServices.GetAccomodationPackageByID(ID.Value);
                Model.ID = accomodationPackageModel.ID;
                Model.Name = accomodationPackageModel.Name;
                Model.NumOfRoom = accomodationPackageModel.NumOfRoom;
                Model.FeePerNight = accomodationPackageModel.FeePerNight;
                Model.AccomodationTypeID = accomodationPackageModel.AccomodationTypeID;
                Model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
            }
            else
            {
            Model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
            }
            return PartialView("_Action", Model);
        }
        [HttpPost]
        public JsonResult Action(AccomodationPackage Model)
        {
            var Json = new JsonResult();
            var Result = false;
            if (Model.ID > 0)
            {
                var accomodationPackage = accomodationPackageServices.GetAccomodationPackageByID(Model.ID);
                accomodationPackage.Name = Model.Name;
                accomodationPackage.NumOfRoom = Model.NumOfRoom;
                accomodationPackage.FeePerNight = Model.FeePerNight;
                accomodationPackage.AccomodationTypeID = Model.AccomodationTypeID;
                Result = accomodationPackageServices.UpdateAccomodationPackage(accomodationPackage);
            }
            else
            {
                var accomodationPackage = new AccomodationPackage();
                accomodationPackage.Name = Model.Name;
                accomodationPackage.NumOfRoom = Model.NumOfRoom;
                accomodationPackage.FeePerNight = Model.FeePerNight;
                accomodationPackage.AccomodationTypeID = Model.AccomodationTypeID;
                Result = accomodationPackageServices.SaveAccomodationPackage(accomodationPackage);
            }


            if (Result)
            {
                Json.Data = new { Success = true };
            }
            else
            {
                Json.Data = new { Success = false, Message = "Failed To Perform Action on Accomodation Package" };
            }

            return Json;
        }
        public ActionResult Delete(int Id)
        {
            var accomodationPackage = new AccomodationPackage();
            accomodationPackage.ID = Id;
            return PartialView("_Delete", accomodationPackage);
        }
        [HttpPost]
        public JsonResult Delete(AccomodationPackage Model)
        {
            var Json = new JsonResult();
            var Result = false;
            Model = accomodationPackageServices.GetAccomodationPackageByID(Model.ID);
            Result = accomodationPackageServices.DeleteAccomodationPackage(Model);

            if (Result)
            {
                Json.Data = new { Success = true };
            }
            else
            {
                Json.Data = new { Success = false, Message = "Failed To Delete this Accomodation Package" };
            }

            return Json;
        }
    }
}