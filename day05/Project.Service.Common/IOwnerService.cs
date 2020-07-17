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
        Task<List<Owner>> GetOwners();
        Task<bool> InsertOwner(Owner owner);
        Task<bool> UpdateOwner(int inptID, Owner owner);
        Task<bool> DeleteOwner(Owner owner);
    }
}
