using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneList.Models
{
    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string[] roles { get; set; }

        public CustomPrincipalSerializeModel(int Id,string UserName, string[] roles)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.roles = roles;
        }
    }
}