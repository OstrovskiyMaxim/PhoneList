using PhoneList.Models.DataModel;
using PhoneList.Models.EntityContexts;
using PhoneList.Models.IdentityModels;
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
            // db.Phones.RemoveRange(db.Phones.Where(p => p.UserId == id));
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

        public void Update(DataUser item)
        {
            db.Entry<DataUser>(item).State = System.Data.Entity.EntityState.Modified;

            foreach (DataPerson itemP in item.Persons)
            {
                UpdatePhone(itemP);
            }

            int Id = item.Id;
            DataUser user = GetById(Id);

            user.FirstName = item.FirstName;
            user.LastName = item.LastName;
            user.Age = item.Age;

            db.SaveChanges();
        }

        private void UpdatePhone(DataPhone phone)
        {
            db.Entry<DataPhone>(phone).State = System.Data.Entity.EntityState.Modified;
            try
            {
                DataPhone ph = db.Phones.Find(phone.Id);
                ph.PhoneNumber = phone.PhoneNumber;
                ph.PhoneType = phone.PhoneType;
            }
            catch
            {
                db.Phones.Add(phone);
            }
        }
    }
}