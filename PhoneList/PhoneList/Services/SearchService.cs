using PhoneList.Models.DataModel;
using PhoneList.Models.ViewModels;
using PhoneList.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneList.Services
{
    public class SearchService
    {
        public SearchService()
        {
            PersonsVM = new List<PersonViewModel>();
        }

        private List<PersonViewModel> PersonsVM { get; set; }

        public List<PersonViewModel> Search(int id, string query, string searchBy)
        {
            switch (searchBy)
            {
                case "byName":
                    SearchByName(id, query);
                    break;
                case "byAddress":
                    SearchByAddress(id, query);
                    break;
                case "byPhone":
                    SearchByPhone(id, query);
                    break;
                case "byAll":
                    SearchByAllFields(id, query);
                    break;
                default:
                    SearchByAllFields(id, query);
                    break;
            }
            return PersonsVM;
        }

        private void SearchByAllFields(int id, string query)
        {
            using (EntityRepository db = new EntityRepository())
            {
                List<DataPerson> listByFirstName = db.GetPersonsBy_FirstName(id, query).ToList();
                AddToSingleListToShow(listByFirstName);

                List<DataPerson> listByLastName = db.GetPersonsBy_LastName(id, query).ToList();
                AddToSingleListToShow(listByLastName);

                List<DataPerson> listByCity = db.GetPersonsBy_City(id, query).ToList();
                AddToSingleListToShow(listByCity);

                List<DataPerson> listByCountry = db.GetPersonsBy_Country(id, query).ToList();
                AddToSingleListToShow(listByCountry);

                List<DataPerson> listByStreet = db.GetPersonsBy_Street(id, query).ToList();
                AddToSingleListToShow(listByStreet);

                List<DataPerson> listByPhone = db.GetPersonsBy_PhoneNumber(id, query).ToList();
                AddToSingleListToShow(listByPhone);

                List<DataPerson> listByPhoneType = db.GetPersonsBy_PhoneType(id, query).ToList();
                AddToSingleListToShow(listByPhoneType);
            }
        }

        private void SearchByName(int id, string query)
        {
            using (EntityRepository db = new EntityRepository())
            {
                List<DataPerson> listByFirstName = db.GetPersonsBy_FirstName(id, query).ToList();
                AddToSingleListToShow(listByFirstName);

                List<DataPerson> listByLastName = db.GetPersonsBy_LastName(id, query).ToList();
                AddToSingleListToShow(listByLastName);
            }
        }

        private void SearchByPhone(int id, string query)
        {
            using (EntityRepository db = new EntityRepository())
            {
                List<DataPerson> listByPhone = db.GetPersonsBy_PhoneNumber(id, query).ToList();
                AddToSingleListToShow(listByPhone);

                List<DataPerson> listByPhoneType = db.GetPersonsBy_PhoneType(id, query).ToList();
                AddToSingleListToShow(listByPhoneType);
            }
        }

        private void SearchByAddress(int id, string query)
        {
            using (EntityRepository db = new EntityRepository())
            {
                List<DataPerson> listByCity = db.GetPersonsBy_City(id, query).ToList();
                AddToSingleListToShow(listByCity);

                List<DataPerson> listByCountry = db.GetPersonsBy_Country(id, query).ToList();
                AddToSingleListToShow(listByCountry);

                List<DataPerson> listByStreet = db.GetPersonsBy_Street(id, query).ToList();
                AddToSingleListToShow(listByStreet);
            }
        }

        private void AddToSingleListToShow(List<DataPerson> dataPersons)
        {
            UserService service = new UserService();
            foreach (var item in dataPersons)
            {
                if (PersonsVM.Where(p => p.Id == item.Id).Count() == 0)
                {
                    PersonsVM.Add(service.DataPersonToPersonVM(item));
                }
            }
        }
    }
}