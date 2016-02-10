using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneList.Models.ViewModels
{
    public class CountriesViewModel
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public CountriesViewModel()
        {

        }

        public CountriesViewModel(string name, int id)
        {
            this.CountryId = id;
            this.Name = name;
        }
    }
}