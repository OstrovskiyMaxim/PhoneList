using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneList.Models.IdentityModels
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string PhoneType { get; set; }

        [ForeignKey("person")]
        public int PersonId { get; set; }

        public Person person { get; set; }

        public Phone()
        {

        }

        public Phone(string type, string number, int personId)
        {
            this.PhoneType = type;
            this.PhoneNumber = number;
            this.PersonId = PersonId;
        }
    }
}