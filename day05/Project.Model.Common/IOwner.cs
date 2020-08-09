using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
    public interface IOwner
    {
        int OwnerID{ get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        string Town { get; set; }
    }

    public interface IOwnerNoID
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        string Town { get; set; }
    }
}
