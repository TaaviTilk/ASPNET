using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Interfaces;
using Interfaces.Repositories;

namespace DAL.MsSql.Repositories
{
    public class ContactRepository: EFRepository<Contact>, IContactRepository
    {
        public ContactRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public Contact GetContactByName(string name)
        {
            return RepositoryDbSet.FirstOrDefault(a => a.ContactValue == "name");
        }
    }
}
