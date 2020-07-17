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
        
        public async Task<List<Owner>> GetOwners()
        {
            return await repository.GetOwners();
        }


        public async Task<bool> InsertOwner(Owner vlasnik)
        {
            var ownerList = new List<Owner>;
            ownerList = await repository.GetOwners();
            vlasnik.Owner_id = ownerList.Count() + 1;
            //vlasnik.Owner_id = (repository.GetOwners().Count() + 1);
            return await repository.InsertOwner(vlasnik);
        }
        
        
        public async Task<bool> UpdateOwner(int inptId,Owner vlasnik)
        {
            return await repository.UpdateOwner(inptId,vlasnik);
        }

        public async Task<bool> DeleteOwner(Owner vlasnik)
        {
            return await repository.DeleteOwner(vlasnik);
        }
    }
}
