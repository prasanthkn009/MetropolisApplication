using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.DAL
{
    public class ContactDAL : IContactDAL
    {
        private readonly ApplicationDbContext _dbcontext;

        public ContactDAL(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public List<Contact> AllContact()
        {
            return _dbcontext.Contacts.ToList();

        }
    }
}
