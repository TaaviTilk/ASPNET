using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Interfaces.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Contact GetContactByName(string name);
    }
}
