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

        public bool SaveAccomodationType(AccomodationType accomodationType)
        {
            using (var Context = new HMSContext())
            {
                Context.AccomodationTypes.Add(accomodationType);
                return Context.SaveChanges() > 0;
            }
        }
    }
}
