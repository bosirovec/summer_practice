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
        Task<List<Owner>> GetOwnersAsync();
        Task<Owner> GetOwnerAsync(int id);
        Task<OwnerNoID> InsertOwnerAsync(OwnerNoID owner);
        Task<Owner> UpdateOwnerAsync(int inptID, Owner owner);
        Task<bool> DeleteOwnerAsync(int id);
    }
}
