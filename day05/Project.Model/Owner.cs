using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;

namespace Project.Model
{
    public class Owner : IOwner
    {
        public int Owner_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Owner(int id, string firstName, string lastName, int age, string town)
        {
            Owner_id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Town = town;
        }
        public Owner() { }
    }
}
