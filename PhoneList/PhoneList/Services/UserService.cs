using Newtonsoft.Json.Linq;
using PhoneList.Models.DataModel;
using PhoneList.Models.IdentityModels;
using PhoneList.Models.ViewModels;
using PhoneList.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PhoneList.Services
{
    public class UserService
    {
        public void Create(UserViewModel user)
        {
            using (EntityRepository db = new EntityRepository())
            {
                db.Create(UserVMToDataUser(user));
            }
        }

        public void CreatePerson(PersonViewModel person)
        {
            using (EntityRepository db = new EntityRepository())
            {
                db.CreatePerson(PersonVMToDataPerson(person));
            }
        }

        public List<UserViewModel> GetAllUsers()
        {
            using (EntityRepository db = new EntityRepository())
            {
                List<UserViewModel> UsersVM = new List<UserViewModel>();
                foreach (var item in db.GetAll())
                {
                    UsersVM.Add(DataUserToUserVM(item));
                }
                return UsersVM;
            }
        }

        public List<PersonViewModel> GetAllPersons(int userId)
        {
            using (EntityRepository db = new EntityRepository())
            {
                List<PersonViewModel> personsVM = new List<PersonViewModel>();
                foreach (var item in db.GetAllPersons(userId))
                {
                    personsVM.Add(DataPersonToPersonVM(item));
                }
                return personsVM;
            }
        }

        public UserViewModel GetUserByLogin(string login)
        {
            using (EntityRepository db = new EntityRepository())
            {
                return DataUserToUserVM(db.GetUserByLogin(login));
            }
        }

        public UserViewModel GetUserById(int id)
        {
            using (EntityRepository db = new EntityRepository())
            {
                return DataUserToUserVM(db.GetById(id));
            }
        }

        public PersonViewModel GetPersonById(int id)
        {
            using (EntityRepository db = new EntityRepository())
            {
                return DataPersonToPersonVM(db.GetPersonById(id));
            }
        }

        public List<CountriesViewModel> GetAllCountries()
        {
            List<DataCountry> counties = new EntityRepository().GetAllCountries().ToList();
            List<CountriesViewModel> countriesVM = new List<CountriesViewModel>();
            foreach (var item in counties)
            {
                countriesVM.Add(new CountriesViewModel(item.Name, item.Id));
            }
            return countriesVM;
        }

        public List<CityViewModel> GetCitiesByCountryId(int id)
        {
            List<DataCity> Cities = new List<DataCity>();
            List<CityViewModel> CitiesVM = new List<CityViewModel>();
            using (EntityRepository db = new EntityRepository())
            {
                Cities = db.GetCityByCountryId(id).ToList();
            }

            foreach (var item in Cities)
            {
                CitiesVM.Add(new CityViewModel(item.Name, item.Id));
            }

            return CitiesVM;
        }

        public void DeleteUser(int id)
        {
            using (EntityRepository db = new EntityRepository())
            {
                db.Delete(id);
            }
        }

        public void DeletePerson(int id)
        {
            using (EntityRepository db = new EntityRepository())
            {
                db.DeletePerson(id);
            }
        }

        public void UpdateUser(int id,UserViewModel userVM)
        {
            using (EntityRepository db = new EntityRepository())
            {
                db.Update(UserVMToDataUser(userVM));
            }
        }

        //View Model to Data User
        public DataUser UserVMToDataUser(UserViewModel userVM)
        {
            DataUser dataUser = new DataUser();
            dataUser.Id = userVM.Id;
            dataUser.IdentityId = userVM.IdentityId;
            dataUser.Photo = userVM.Photo;
            dataUser.Login = userVM.Login;
            dataUser.Password = userVM.Password;
            dataUser.Role = userVM.Role;
            dataUser.Email = userVM.Email;
            dataUser.FirstName = userVM.FirstName;
            dataUser.LastName = userVM.LastName;
            dataUser.Age = userVM.Age;
            dataUser.About = userVM.About;

            foreach (var item in userVM.PersonsVM)
            {
                dataUser.Persons.Add(PersonVMToDataPerson(item));
            }
            return dataUser;
        }

        public DataPerson PersonVMToDataPerson(PersonViewModel personVM)
        {
            DataPerson dataPerson = new DataPerson();

            dataPerson.Id = personVM.Id;
            dataPerson.Age = personVM.Age;
            dataPerson.FirstName = personVM.FirstName;
            dataPerson.LastName = personVM.LastName;
            dataPerson.UserId = personVM.UserId;
            //using (EntityRepository db = new EntityRepository())
            //{
            //    dataPerson.user = db.GetById(personVM.UserId);
            //}

            foreach (var item in personVM.PhonesVM)
            {
                dataPerson.Phones.Add(PhoneVMToDataPhone(item));
            }

            foreach (var item in personVM.AdressesVM)
            {
                
                dataPerson.Adress.Add(AdressVMToDataAdress(item));
            }

            return dataPerson;
        }




        private DataAdress AdressVMToDataAdress(AdressViewModel adressVM)
        {
            DataAdress dataAdress = new DataAdress();

            dataAdress.CityId = adressVM.CityId;
            dataAdress.HouseNo = adressVM.HouseNo;
            dataAdress.Lat = adressVM.Lat;
            dataAdress.Lng = adressVM.Lng;
            dataAdress.City = new EntityRepository().GetCityById(adressVM.CityId);
            //dataAdress.person = PersonVMToDataPerson( adressVM.person);
            dataAdress.Street = adressVM.Street;

            return dataAdress;
        }

        public DataPhone PhoneVMToDataPhone(PhoneViewModel phoneVM)
        {
            DataPhone dataPhone = new DataPhone();

            dataPhone.Id = phoneVM.Id;
            dataPhone.PersonId = phoneVM.PersonId;
            dataPhone.PhoneNumber = phoneVM.PhoneNumber;
            dataPhone.PhoneType = phoneVM.PhoneType;

            return dataPhone;
        }

        //Data User to View Model
        public UserViewModel DataUserToUserVM(DataUser dataUser)
        {
            UserViewModel userVM = new UserViewModel();
            userVM.Id = dataUser.Id;
            userVM.IdentityId = dataUser.IdentityId;
            userVM.Photo = dataUser.Photo;
            userVM.Login = dataUser.Login;
            userVM.Password = dataUser.Password;
            userVM.Role = dataUser.Role;
            userVM.Email = dataUser.Email;
            userVM.FirstName = dataUser.FirstName;
            userVM.LastName = dataUser.LastName;
            userVM.Age = dataUser.Age;
            userVM.About = dataUser.About;

            foreach (var item in dataUser.Persons)
            {
                userVM.PersonsVM.Add(DataPersonToPersonVM(item));
            }
            return userVM;
        }

        public PersonViewModel DataPersonToPersonVM(DataPerson dataPerson)
        {
            PersonViewModel personVM = new PersonViewModel();

            personVM.Id = dataPerson.Id;
            personVM.Age = dataPerson.Age;
            personVM.FirstName = dataPerson.FirstName;
            personVM.LastName = dataPerson.LastName;
            personVM.UserId = dataPerson.UserId;

            //foreach (var item in dataPerson.Phones)
            //{
            //    personVM.PhonesVM.Add(DataPhoneToPhoneVM(item));
            //}

            //foreach (var item in dataPerson.Adress)
            //{
            //    personVM.AdressesVM.Add(DataAdressToAdressVM(item));
            //}

            return personVM;
        }

        private AdressViewModel DataAdressToAdressVM(DataAdress dataAdress)
        {
            AdressViewModel adressVM = new AdressViewModel();

            adressVM.Id = dataAdress.Id;
            adressVM.CityId = dataAdress.CityId;
            adressVM.City = dataAdress.City.Name;
            adressVM.HouseNo = dataAdress.HouseNo;
            adressVM.Lat = dataAdress.Lat;
            adressVM.Lng = dataAdress.Lng;
            adressVM.person.Id = dataAdress.PersonId;
            adressVM.Street = dataAdress.Street;

            return adressVM;
        }

        public PhoneViewModel DataPhoneToPhoneVM(DataPhone dataPhone)
        {
            PhoneViewModel phoneVM = new PhoneViewModel();

            phoneVM.Id = dataPhone.Id;
            phoneVM.PersonId = dataPhone.PersonId;
            phoneVM.PhoneNumber = dataPhone.PhoneNumber;
            phoneVM.PhoneType = dataPhone.PhoneType;

            return phoneVM;
        }
    }
}