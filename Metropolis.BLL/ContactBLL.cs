using Metropolis.DAL;
using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.BLL
{
    public class ContactBLL : IContactBLL
    {
        private readonly IContactDAL _contactDAL;
        public ContactBLL(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public List<Contact> AllContact()
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContact()

        {
            List<Contact> contacts = new List<Contact>();
            contacts = _contactDAL.AllContact();
            return contacts.ToList();
        }














    }
}
