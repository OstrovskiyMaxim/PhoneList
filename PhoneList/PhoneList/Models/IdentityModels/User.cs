using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneList.Models.IdentityModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string IdentityId { get; set; }

        public string Photo { get; set; }

        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Display(Name = "О себе")]
        public string About { get; set; }

        public List<Person> Persons { get; set; }

        public User()
        {
            Persons = new List<Person>();
        }

        public User(string id)
        {
            Persons = new List<Person>();
            this.IdentityId = id;
        }
    }
}