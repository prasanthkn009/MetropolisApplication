using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.DAL
{
    public interface IContactDAL
    {
        List<Contact> AllContact();
    }
}