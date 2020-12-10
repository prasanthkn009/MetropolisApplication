using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.DAL
{
    public interface IContactDal
    {
        List<Contact> AllContact();
    }
}
