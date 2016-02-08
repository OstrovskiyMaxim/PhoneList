using PhoneList.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneList.Models.ViewModels
{
    public class PhoneViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Тип")]
        public string PhoneType { get; set; }

        public int PersonId { get; set; }

        public PhoneViewModel()
        {

        }

        public PhoneViewModel(string type, string number, int personId)
        {
            this.PhoneType = type;
            this.PhoneNumber = number;
            this.PersonId = personId;
        }

        //public PhoneViewModel(Phone phone)
        //{
        //    this.PhoneType = phone.PhoneType;
        //    this.PhoneNumber = phone.PhoneNumber;
        //    this.PersonId = phone.PersonId;
        //}
    }
}