using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class Accomodation : BaseEntity
    {
        public string Description { get; set; }
        public int AccomodationPackageID { get; set; }
        public AccomodationPackage AccomodationPackage { get; set; }
    }
}
