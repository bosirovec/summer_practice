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
        Task<List<Owner>> GetOwners();
        Task<bool> InsertOwner(Owner owner);
        Task<bool> UpdateOwner(int id, Owner owner);
        Task<bool> DeleteOwner(Owner owner);
    }
}
