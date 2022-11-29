using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationPackagesService
    {

        public List<AccomodationPackage> GetAllAccomodationPackages()
        {
            using (var Context = new HMSContext())
            {
                return Context.AccomodationPackages.ToList();
            }
        }
        public List<AccomodationPackage> SearchAccomodationPackages(string SearchTerm)
        {
            using (var Context = new HMSContext())
            {
                var accomodationPackages = Context.AccomodationPackages.ToList();
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    accomodationPackages = accomodationPackages.Where(x => x.Name.ToLower().Contains(SearchTerm.ToLower())).ToList();
                }
                return accomodationPackages.ToList();
            }
        }

        public bool SaveAccomodationPackage(AccomodationPackage accomodationPackage)
        {
            using (var Context = new HMSContext())
            {
                Context.AccomodationPackages.Add(accomodationPackage);
                return Context.SaveChanges() > 0;
            }
        }

        public AccomodationPackage GetAccomodationPackageByID(int ID)
        {
            using (var Context = new HMSContext())
            {
                return Context.AccomodationPackages.FirstOrDefault(x => x.ID == ID);
            }
        }

        public bool UpdateAccomodationPackage(AccomodationPackage accomodationPackage)
        {
            using (var Context = new HMSContext())
            {
                 Context.Entry(accomodationPackage).State = System.Data.Entity.EntityState.Modified;
                return Context.SaveChanges() > 0;
            }
        }

        public bool DeleteAccomodationPackage(AccomodationPackage accomodationPackage)
        {
            using (var Context = new HMSContext())
            {
                Context.Entry(accomodationPackage).State = System.Data.Entity.EntityState.Deleted;
                return Context.SaveChanges() > 0;
            }
        }
    }
}
