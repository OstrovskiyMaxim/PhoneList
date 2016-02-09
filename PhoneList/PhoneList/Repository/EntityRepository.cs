using PhoneList.Models.DataModel;
using PhoneList.Models.EntityContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneList.Repository
{
    public class EntityRepository : IRepository<DataUser>,IDisposable
    {
        EntityContext db = new EntityContext();

        public void Create(DataUser item)
        {
            db.Users.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            db.Users.Remove(GetById(id));
            Save();

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
            Save();

            throw new NotImplementedException();

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
            return db.Persons.Where(x=>x.UserId == id).ToList();
        }

        public DataPerson GetPersonById(int id)
        {
            return db.Persons.Find(id);
        }

        public void UpdatePerson(DataPerson person)
        {
            Save();

            throw new NotImplementedException();
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