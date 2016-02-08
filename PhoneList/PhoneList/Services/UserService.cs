﻿using PhoneList.Models.DataModel;
using PhoneList.Models.IdentityModels;
using PhoneList.Models.ViewModels;
using PhoneList.Repository;
using System;
using System.Collections.Generic;
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

        public List<PersonViewModel> GetAllPersons(int userId)
        {
            List<PersonViewModel> personsVM = new List<PersonViewModel>();

            using (EntityRepository db = new EntityRepository())
            {
                foreach (var item in db.GetAllPersons(userId))
                {
                    personsVM.Add(DataPersonToPersonVM(item));
                }
            }

            return personsVM;
        }

        public UserViewModel GetUserById(int id)
        {
            using (EntityRepository db = new EntityRepository())
            {
                return DataUserToDataUserVM(db.GetById(id));
            }
        }

        public PersonViewModel GetPersonById(int id)
        {
            using (EntityRepository db = new EntityRepository())
            {
                return DataPersonToPersonVM(db.GetPersonById(id));
            }
        }

        public List<DataCountry> GetAllCountries()
        {
            return new EntityRepository().GetAllCountries().ToList();
        }

        public List<DataCity> GetCitiesByCountryId(int id)
        {
            using (EntityRepository db = new EntityRepository())
            {
                return db.GetCityByCountryId(id).ToList();
            }
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



        //View Model to Data User
        public DataUser UserVMToDataUser(UserViewModel userVM)
        {
            DataUser dataUser = new DataUser();
            dataUser.Id = userVM.Id;
            dataUser.IdentityId = userVM.IdentityId;
            dataUser.Photo = userVM.Photo;
            dataUser.Login = userVM.Login;
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

            dataAdress.Id = adressVM.Id;
            dataAdress.CityId = adressVM.CityId;
            dataAdress.HouseNo = adressVM.HouseNo;
            dataAdress.Lat = adressVM.Lat;
            dataAdress.Lng = adressVM.Lng;
            dataAdress.PersonId = adressVM.person.Id;
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
        public UserViewModel DataUserToDataUserVM(DataUser dataUser)
        {
            UserViewModel userVM = new UserViewModel();
            userVM.Id = dataUser.Id;
            userVM.IdentityId = dataUser.IdentityId;
            userVM.Photo = dataUser.Photo;
            userVM.Login = dataUser.Login;
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

            foreach (var item in dataPerson.Phones)
            {
                personVM.PhonesVM.Add(DataPhoneToPhoneVM(item));
            }

            foreach (var item in dataPerson.Adress)
            {
                personVM.AdressesVM.Add(DataAdressToAdressVM(item));
            }

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