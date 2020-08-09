using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Model;
using Project.Repository.Common;
using Project.Repository;
using Project.Service.Common;
using System.Net;

namespace Project.Service
{
    public class OwnerService : IOwnerService
    {
        private OwnerRepository repository = new OwnerRepository();
        
        public async Task<List<Owner>> GetOwnersAsync()
        {
            return await repository.GetOwnersAsync();
        }


        public async Task<Owner> GetOwnerAsync(int id)
        {
            return await repository.GetOwnerAsync(id);
        }


        public async Task<OwnerNoID> InsertOwnerAsync(OwnerNoID vlasnik)
        {
            return await repository.InsertOwnerAsync(vlasnik);
        }
        
        
        public async Task<Owner> UpdateOwnerAsync(int inptId,Owner vlasnik)
        {
            return await repository.UpdateOwnerAsnyc(inptId, vlasnik);
        }


        public async Task<bool> DeleteOwnerAsync(int id)
        {
            return await repository.DeleteOwnerAsync(id);
        }
    }
}
