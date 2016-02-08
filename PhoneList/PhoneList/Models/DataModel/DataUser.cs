using PhoneList.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneList.Models.DataModel
{
    public class DataUser 
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

        public List<DataPerson> Persons { get; set; }

        public DataUser()
        {
            Persons = new List<DataPerson>();
        }

        public DataUser(string id)
        {
            Persons = new List<DataPerson>();
            this.IdentityId = id;
        }

        //public DataUser(User user)
        //{
        //    this.Id = user.Id;
        //    this.IdentityId = user.IdentityId;
        //    this.Photo = user.Photo;
        //    this.Login = user.Login;
        //    this.Email = user.Email;
        //    this.FirstName = user.FirstName;
        //    this.LastName = user.LastName;
        //    this.Age = user.Age;
        //    this.About = user.About;

        //    foreach (var item in user.Persons)
        //    {
        //        this.Persons.Add(new DataPerson(item));
        //    }
        //}
    }
}