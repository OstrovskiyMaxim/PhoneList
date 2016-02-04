using PhoneList.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneList.Models.EntityContexts
{
    public class EntityContext : DbContext
    {
        public virtual DbSet<DataUser> Users { get; set; }
        public virtual DbSet<DataPerson> Persons { get; set; }
        public virtual DbSet<DataPhone> Phones { get; set; }
        public virtual DbSet<DataAdress> Adresses { get; set; }
        public virtual DbSet<DataCountry> Countries { get; set; }
        public virtual DbSet<DataCity> Cities { get; set; }

    }
}