using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneList.Models.ViewModels
{
    public class CityViewModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public CityViewModel()
        {

        }

        public CityViewModel(string name, int id)
        {
            this.CityId = id;
            this.Name = name;
        }
    }
}