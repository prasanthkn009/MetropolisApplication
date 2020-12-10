using Metropolis.Dal.Entities;
using System.Collections.Generic;

namespace Metropolis.Dal
{
    public interface IContactDal
    {
        List<Contact> AllContact();
    }
}
