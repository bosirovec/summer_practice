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
        Task<List<Owner>> GetOwnersAsync();
        Task<Owner> GetOwnerAsync(int id);
        Task<OwnerNoID> InsertOwnerAsync(OwnerNoID owner);
        Task<Owner> UpdateOwnerAsnyc(int id, Owner owner);
        Task<bool> DeleteOwnerAsync(int id);
    }
}
