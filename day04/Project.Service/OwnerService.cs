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

namespace Project.Service
{
    public class OwnerService : IOwnerService
    {
        private OwnerRepository repository = new OwnerRepository();
        
        public List<Owner> GetOwners()
        {
            return repository.GetOwners();
        }


        public bool InsertOwner(Owner vlasnik)
        {
            return repository.InsertOwner(vlasnik);
        }
        
        
        public bool UpdateOwner(int inptId,Owner vlasnik)
        {
            return repository.UpdateOwner(inptId,vlasnik);
        }

        public bool DeleteOwner(Owner vlasnik)
        {
            return repository.DeleteOwner(vlasnik);
        }
    }
}
