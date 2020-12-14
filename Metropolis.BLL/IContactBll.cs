using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    /// <summary>
    ///  Defines the interface for the ContactBLL.
    /// </summary>
    public interface IContactBll
    {
        List<Contact> GetContact();
    }
}
