using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repository;


namespace Project.Service.Common
{
    public interface IOwnerService
    {
        List<Owner> GetOwners();
        bool InsertOwner(Owner owner);
        bool UpdateOwner(int inptID, Owner owner);
        bool DeleteOwner(Owner owner);
    }
}
