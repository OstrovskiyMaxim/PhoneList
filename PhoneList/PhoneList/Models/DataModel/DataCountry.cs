using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneList.Models.DataModel
{
    public class DataCountry
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<DataCity> Cities { get; set; }

        public DataCountry()
        {

        }

        public DataCountry(string name)
        {
            this.Name = name;
            this.Cities = new List<DataCity>();
        }
    }
}