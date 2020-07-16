using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Model;

namespace Project.Repository.Common
{
    public interface IOwnerRepository
    {
        List<Owner> GetOwners();
        bool InsertOwner(Owner owner);
        bool UpdateOwner(int id, Owner owner);
        bool DeleteOwner(Owner owner);
    }
}
