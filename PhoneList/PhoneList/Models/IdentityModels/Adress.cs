using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneList.Models.IdentityModels
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        [Display(Name = "Улица")]
        public string Street { get; set; }
   
        [Display(Name = "Дом/Квартира")]
        public string HouseNo { get; set; }

        public double Lng { get; set; }

        public double Lat { get; set; }

        public Person person { get; set; }

        public List<Person> Persons { get; set; }
    }
}