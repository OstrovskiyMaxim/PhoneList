using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneList.Models.IdentityModels
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        public List<Phone> Phones { get; set; }

        public List<Adress> Adress { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }

        public User user { get; set; }

        public Person()
        {
            Phones = new List<Phone>();
        }
    }
}