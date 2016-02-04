using PhoneList.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneList.Models.ViewModels
{
    public class AdressViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Display(Name = "Дом/Квартира")]
        public string HouseNo { get; set; }

        public PersonViewModel person { get; set; }

        public List<PersonViewModel> Persons { get; set; }

        public AdressViewModel(string country, string city, string street, string houseNo)
        {
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.HouseNo = houseNo;
        }

        public AdressViewModel()
        {

        }

        public AdressViewModel(Adress adress)
        {
            this.Country = adress.Country;
            this.City = adress.City;
            this.Street = adress.Street;
            this.HouseNo = adress.HouseNo;
        }
    }
}