using PhoneList.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneList.Models.DataModel
{
    public class DataAdress
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Display(Name = "Дом/Квартира")]
        public string HouseNo { get; set; }

        public DataPerson person { get; set; }

        public List<DataPerson> Persons { get; set; }

        public DataAdress()
        {

        }

        public DataAdress(Adress adress)
        {
            this.Id = adress.Id;
            this.Country = adress.Country;
            this.City = adress.City;
            this.Street = adress.Street;
            this.HouseNo = adress.HouseNo;
            this.person = new DataPerson(adress.person);

            foreach (var item in adress.Persons)
            {
                this.Persons.Add(new DataPerson(item));
            }
        }
    }
}