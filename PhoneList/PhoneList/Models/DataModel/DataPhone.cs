using PhoneList.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneList.Models.DataModel
{
    public class DataPhone
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string PhoneType { get; set; }

        [ForeignKey("person")]
        public int PersonId { get; set; }

        public DataPerson person { get; set; }

        public DataPhone()
        {

        }

        public DataPhone(string type, string number, int personId)
        {
            this.PhoneType = type;
            this.PhoneNumber = number;
            this.PersonId = PersonId;
        }

        //public DataPhone(Phone phone)
        //{
        //    this.Id = phone.Id;
        //    this.PhoneType = phone.PhoneType;
        //    this.PhoneNumber = phone.PhoneNumber;
        //    this.PersonId = phone.PersonId;
        //    this.person = new DataPerson(phone.person);
        //}
    }
}