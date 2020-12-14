using Metropolis.DAL;
using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.BLL
{
    public class ContactBll : IContactBll
    {
        private readonly IContactDal _contactDal;
        private readonly ApplicationDbContext _db;
        public ContactBll(IContactDal contactDal, ApplicationDbContext db)
        {
            _contactDal = contactDal;
            _db = db;
        }

        public List<Contact> GetContact()

        {
            List<Contact> Contacts = new List<Contact>();
            Contacts = _contactDal.AllContact();
            return Contacts.ToList();
        }














    }
}
