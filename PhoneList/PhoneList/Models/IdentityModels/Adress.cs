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

        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Улица")]
        public string Street { get; set; }
    
        [Display(Name = "Дом/Квартира")]
        public string HouseNo { get; set; }
    }
}