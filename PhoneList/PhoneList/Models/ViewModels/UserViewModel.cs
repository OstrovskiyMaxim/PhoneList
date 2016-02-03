using PhoneList.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneList.Models.ViewModels
{
    public class UserViewModel
    {
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

        public List<PersonViewModel> PersonsVM { get; set; }

        public UserViewModel()
        {
            PersonsVM = new List<PersonViewModel>();
        }

        public UserViewModel(string id)
        {
            PersonsVM = new List<PersonViewModel>();
            this.IdentityId = id;
        }

        public UserViewModel(User user)
        {
            this.Id = user.Id;
            this.IdentityId = user.IdentityId;
            this.Photo = user.Photo;
            this.Login = user.Login;
            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Age = user.Age;
            this.About = user.About;

            foreach(var item in user.Persons)
            {
                this.PersonsVM.Add(new PersonViewModel(item));
            }
        }
    }
}