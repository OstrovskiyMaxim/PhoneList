using PhoneList.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneList.Models.DataModel
{
    public class DataAdress
    {
        [Key]
        public int Id { get; set; }

        public DataCity City { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public string Street { get; set; }

        public string HouseNo { get; set; }

        public double Lng { get; set; }

        public double Lat { get; set; }

        [ForeignKey("person")]
        public int PersonId { get; set; }

        public DataPerson person { get; set; }

        public List<DataPerson> Persons { get; set; }

        public DataAdress()
        {

        }

        //public DataAdress(Adress adress)
        //{
        //    this.Id = adress.Id;
         
        //    this.CityId = adress.CityId;
        //    this.Street = adress.Street;
        //    this.HouseNo = adress.HouseNo;
        //    this.person = new DataPerson(adress.person);
        //    this.Lng = adress.Lng;
        //    this.Lat = adress.Lat;

        //    foreach (var item in adress.Persons)
        //    {
        //        this.Persons.Add(new DataPerson(item));
        //    }
        //}
    }
}