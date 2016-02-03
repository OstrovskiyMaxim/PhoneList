using PhoneList.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneList.Models.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        public List<PhoneViewModel> PhonesVM { get; set; }

        public int UserId { get; set; }

        public PersonViewModel()
        {
            PhonesVM = new List<PhoneViewModel>();
        }

        public PersonViewModel(Person person)
        {
            this.Id = person.Id;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.Age = person.Age;
            this.UserId = person.UserId;
            
            foreach(var item in person.Phones)
            {
                this.PhonesVM.Add(new PhoneViewModel(item));
            }
        }
    }
}