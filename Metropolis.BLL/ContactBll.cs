using Metropolis.DAL;
using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.BLL
{

    /// <summary>
    ///This class orders the contact details.
    /// </summary>
  
    public class ContactBll : IContactBll
    {
        private readonly IContactDal _contactDal;
        public ContactBll(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> GetContact()

        {
            List<Contact> Contacts = new List<Contact>();
            Contacts = _contactDal.AllContact();
            return Contacts.ToList();
        }














    }
}
