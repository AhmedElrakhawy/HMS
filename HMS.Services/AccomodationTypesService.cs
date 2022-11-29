using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationTypesService
    {

        public List<AccomodationType> GetAllAccomodationTypes()
        {
            using (var Context = new HMSContext())
            {
                return Context.AccomodationTypes.ToList();
            }
        }
        public List<AccomodationType> SearchAccomodationTypes(string SearchTerm)
        {
            using (var Context = new HMSContext())
            {
                var accomodationTypes = Context.AccomodationTypes.ToList();
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                   accomodationTypes = accomodationTypes.Where(x => x.Name.ToLower().Contains(SearchTerm.ToLower())).ToList();
                }
                return accomodationTypes.ToList();
            }
        }

        public bool SaveAccomodationType(AccomodationType accomodationType)
        {
            using (var Context = new HMSContext())
            {
                Context.AccomodationTypes.Add(accomodationType);
                return Context.SaveChanges() > 0;
            }
        }

        public AccomodationType GetAccomodationTypeByID(int ID)
        {
            using (var Context = new HMSContext())
            {
                return Context.AccomodationTypes.FirstOrDefault(x => x.ID == ID);
            }
        }

        public bool UpdateAccomodationType(AccomodationType accomodationType)
        {
            using (var Context = new HMSContext())
            {
                 Context.Entry(accomodationType).State = System.Data.Entity.EntityState.Modified;
                return Context.SaveChanges() > 0;
            }
        }

        public bool DeleteAccomodationType(AccomodationType accomodationType)
        {
            using (var Context = new HMSContext())
            {
                Context.Entry(accomodationType).State = System.Data.Entity.EntityState.Deleted;
                return Context.SaveChanges() > 0;
            }
        }
    }
}
