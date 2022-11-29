using HMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.ViewModels
{
    public class AccomodationTypesListingViewModel
    {
        public List<AccomodationType> AccomodationTypes { get; set; }
        public string SearchTerm { get; set; }
    }
    public class AccomodationTypesActionViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}