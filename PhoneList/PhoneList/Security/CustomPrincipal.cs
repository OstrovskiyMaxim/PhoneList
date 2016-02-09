﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PhoneList.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (roles.Any(r=> role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public CustomPrincipal(string userName)
        {
            this.Identity = new GenericIdentity(userName);
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string[] roles { get; set; }
    }
}