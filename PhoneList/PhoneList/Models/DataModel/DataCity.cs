using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneList.Models.DataModel
{
    public class DataCity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("country")]
        public int CountryId { get; set; }

        public DataCountry country { get; set; }
    }
}