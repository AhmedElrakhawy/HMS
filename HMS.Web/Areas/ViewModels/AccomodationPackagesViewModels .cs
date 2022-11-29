using HMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.ViewModels
{
    public class AccomodationPackagesListingViewModel
    {
        public List<AccomodationPackage> AccomodationPackages { get; set; }
        public List<AccomodationType> AccomodationTypes { get; set; }
        public string SearchTerm { get; set; }
    }
    public class AccomodationPackagesActionViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AccomodationTypeID { get; set; }
        public List<AccomodationType> AccomodationTypes { get; set; }
        public AccomodationType AccomodationType { get; set; }
        public int NumOfRoom { get; set; }
        public decimal FeePerNight { get; set; }
    }
}