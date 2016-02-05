﻿using PhoneList.Models.DataModel;
using PhoneList.Models.EntityContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneList.Repository
{
    public class EntityRepository : IRepository<DataUser>
    {
        EntityContext db = new EntityContext();

        public void Create(DataUser item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            db.Users.Remove(GetById(id));
        }

        public IEnumerable<DataUser> GetAll()
        {
            return db.Users.ToList();
        }

        public DataUser GetById(int id)
        {
            return db.Users.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(DataUser user)
        {
            throw new NotImplementedException();
        }


        //Person CRUD actions
        public void CreatePerson(DataPerson item)
        {
            db.Persons.Add(item);
        }

        public void DeletePerson(int id)
        {
            db.Persons.Remove(GetByIdPerson(id));
        }

        public IEnumerable<DataPerson> GetAllPersons()
        {
            return db.Persons.ToList();
        }

        public DataPerson GetByIdPerson(int id)
        {
            return db.Persons.Find(id);
        }

        public void UpdatePerson(DataPerson person)
        {
            throw new NotImplementedException();
        }

        //Adress CRUD actions
        public IEnumerable<DataCountry> GetAllCountries()
        {
            return db.Countries.ToList();
        }

        public IEnumerable<DataCity> GetCityByCountry(int countryId)
        {
            return db.Cities.Where<DataCity>(x => x.CountryId == countryId);
        }
    }
}