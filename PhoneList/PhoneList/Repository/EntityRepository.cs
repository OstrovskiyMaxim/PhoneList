using PhoneList.Models.DataModel;
using PhoneList.Models.EntityContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneList.Repository
{
    public class EntityRepository : IRepository<DataUser>, IDisposable
    {
        EntityContext db = new EntityContext();

        public void Create(DataUser item)
        {
            db.Users.Add(item);
            Save();
        }

        public DataCity GetCityById(int id)
        {
            return db.Cities.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            db.Users.Remove(GetById(id));
            Save();
        }

        public IEnumerable<DataPerson> GetPersonsBy_FirstName(int userId, string query)
        {
            return GetAllPersons(userId)
                .Where(p => p.FirstName.Contains(query));
        }

        public IEnumerable<DataPerson> GetPersonsBy_LastName(int userId, string query)
        {
            return GetAllPersons(userId)
                .Where(p => p.LastName.Contains(query));
        }

        public IEnumerable<DataPerson> GetPersonsBy_Age(int userId, int query)
        {
            return GetAllPersons(userId)
                .Where(p => p.LastName == query.ToString());
        }

        public IEnumerable<DataPerson> GetPersonsBy_City(int userId, string query)
        {
            return GetAllPersons(userId)
                .Where(p => p.Adress.Contains(db.Adresses.Where(x => x.City.Name == query)
                .FirstOrDefault()));
        }

        public IEnumerable<DataPerson> GetPersonsBy_Country(int userId, string query)
        {
            return GetAllPersons(userId)
                .Where(p => p.Adress.Contains(db.Adresses.Where(x => x.City.country.Name == query)
                .FirstOrDefault()));
        }

        public IEnumerable<DataPerson> GetPersonsBy_Street(int userId, string query)
        {
            return GetAllPersons(userId)
                .Where(p => p.Adress.Contains(db.Adresses.Where(x => x.Street == query)
                .FirstOrDefault()));
        }

        public IEnumerable<DataPerson> GetPersonsBy_PhoneNumber(int userId, string query)
        {
            return GetAllPersons(userId)
                .Where(p => p.Phones.Contains(db.Phones.Where(x => x.PhoneNumber == query)
                .FirstOrDefault()));
        }

        public IEnumerable<DataPerson> GetPersonsBy_PhoneType(int userId, string query)
        {
            return GetAllPersons(userId)
                .Where(p => p.Phones.Contains(db.Phones.Where(x => x.PhoneType == query)
                .FirstOrDefault()));
        }

        public IEnumerable<DataUser> GetAll()
        {
            return db.Users.ToList();
        }

        public DataUser GetById(int id)
        {
            return db.Users.Find(id);
        }

        public DataUser GetUserByLogin(string login)
        {
            return db.Users.Where(x => x.Login == login).FirstOrDefault();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(DataUser user)
        {
            //var UserDB = db.Users.Where(x => x.Id == user.Id).FirstOrDefault();

            //UserDB.About = user.About;
            //UserDB.Age = user.Age;
            //UserDB.Email = user.Email;
            //UserDB.FirstName = user.FirstName;
            //UserDB.LastName = user.LastName;
            //UserDB.Password = user.Password;
            //UserDB.Persons = user.Persons;
            //UserDB.Photo = user.Photo;
            //UserDB.Role = user.Role;

            db.Users.Where(x => x.Id == user.Id).FirstOrDefault().About = user.About;
            db.Users.Where(x => x.Id == user.Id).FirstOrDefault().Age = user.Age;
            db.Users.Where(x => x.Id == user.Id).FirstOrDefault().Email = user.Email;
            db.Users.Where(x => x.Id == user.Id).FirstOrDefault().FirstName = user.FirstName;
            db.Users.Where(x => x.Id == user.Id).FirstOrDefault().LastName = user.LastName;
            db.Users.Where(x => x.Id == user.Id).FirstOrDefault().Password = user.Password;
            db.Users.Where(x => x.Id == user.Id).FirstOrDefault().Persons = user.Persons;
            db.Users.Where(x => x.Id == user.Id).FirstOrDefault().Photo = user.Photo;
            db.Users.Where(x => x.Id == user.Id).FirstOrDefault().Role = user.Role;

            foreach (var item in db.Users.Where(x => x.Id == user.Id).FirstOrDefault().Persons)
            {
                UpdatePerson(item);
            }

            Save();
        }

        //Person CRUD actions
        public void CreatePerson(DataPerson item)
        {
            db.Persons.Add(item);
            Save();
        }

        public void DeletePerson(int id)
        {
            db.Persons.Remove(GetPersonById(id));
            Save();
        }

        public IEnumerable<DataPerson> GetAllPersons(int id)
        {
            return db.Persons.Where(x => x.UserId == id).ToList();
        }

        public DataPerson GetPersonById(int id)
        {
            return db.Persons.Find(id);
        }

        public void UpdatePerson(DataPerson person)
        {
            //var PersonDB = db.Persons.Where(p => p.Id == person.Id).FirstOrDefault();

            //PersonDB.Age = person.Age;
            //PersonDB.FirstName = person.FirstName;
            //PersonDB.LastName = person.LastName;
            //PersonDB.UserId = person.UserId;

            db.Persons.Where(p => p.Id == person.Id).FirstOrDefault().Age = person.Age;
            db.Persons.Where(p => p.Id == person.Id).FirstOrDefault().FirstName = person.FirstName;
            db.Persons.Where(p => p.Id == person.Id).FirstOrDefault().LastName = person.LastName;
            db.Persons.Where(p => p.Id == person.Id).FirstOrDefault().UserId = person.UserId;

            foreach (var item in db.Persons.Where(x => x.Id == person.Id).FirstOrDefault().Adress)
            {
                UpdateAddress(item);
            }

            foreach (var item in db.Persons.Where(x => x.Id == person.Id).FirstOrDefault().Phones)
            {
                UpdatePhone(item);
            }

            Save();
        }

        public void UpdatePhone(DataPhone phone)
        {
            //var PhoneDB = db.Phones.Where(p => p.Id == phone.Id).FirstOrDefault();

            //PhoneDB.PersonId = phone.PersonId;
            //PhoneDB.PhoneNumber = phone.PhoneNumber;
            //PhoneDB.PhoneType = phone.PhoneType;

            db.Phones.Where(p => p.Id == phone.Id).FirstOrDefault().PersonId = phone.PersonId;
            db.Phones.Where(p => p.Id == phone.Id).FirstOrDefault().PhoneNumber = phone.PhoneNumber;
            db.Phones.Where(p => p.Id == phone.Id).FirstOrDefault().PhoneType = phone.PhoneType;

            Save();
        }

        public void UpdateAddress(DataAdress address)
        {
            //var AddressDB = db.Adresses.Where(a => a.Id == address.Id).FirstOrDefault();

            //AddressDB.City = address.City;
            //AddressDB.CityId = address.CityId;
            //AddressDB.HouseNo = address.HouseNo;
            //AddressDB.Lat = address.Lat;
            //AddressDB.Lng = address.Lng;
            //AddressDB.PersonId = address.PersonId;
            //AddressDB.Street = address.Street;

            db.Adresses.Where(a => a.Id == address.Id).FirstOrDefault().City = address.City;
            db.Adresses.Where(a => a.Id == address.Id).FirstOrDefault().CityId = address.CityId;
            db.Adresses.Where(a => a.Id == address.Id).FirstOrDefault().HouseNo = address.HouseNo;
            db.Adresses.Where(a => a.Id == address.Id).FirstOrDefault().Lat = address.Lat;
            db.Adresses.Where(a => a.Id == address.Id).FirstOrDefault().Lng = address.Lng;
            db.Adresses.Where(a => a.Id == address.Id).FirstOrDefault().PersonId = address.PersonId;
            db.Adresses.Where(a => a.Id == address.Id).FirstOrDefault().Street = address.Street;

            Save();
        }

        //Adress CRUD actions
        public IEnumerable<DataCountry> GetAllCountries()
        {
            return db.Countries.ToList();
        }

        public IEnumerable<DataCity> GetCityByCountryId(int countryId)
        {
            return db.Cities.Where<DataCity>(x => x.CountryId == countryId);
        }

        public void Dispose()
        {
            Save();
            db.Dispose();
        }
    }
}