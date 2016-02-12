using PhoneList.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneList.Models.DataModel
{
    public class DataPerson
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        public List<DataPhone> Phones { get; set; }

        public List<DataAdress> Adress { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }

        public DataUser user { get; set; }

        public DataPerson()
        {
            Phones = new List<DataPhone>();
            Adress = new List<DataAdress>();
        }

        //public DataPerson(Person person)
        //{
        //    this.Id = person.Id;
        //    this.FirstName = person.FirstName;
        //    this.LastName = person.LastName;
        //    this.Age = person.Age;

        //    foreach (var item in person.Phones)
        //    {
        //        this.Phones.Add(new DataPhone(item));
        //    }

        //    foreach (var itemA in person.Adress)
        //    {
        //        this.Adress.Add(new DataAdress(itemA));
        //    }

        //    this.user = new DataUser(person.user);

        //}
    }
}