using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    public interface IContactBLL
    {
        List<Contact> GetContact();
    }
}