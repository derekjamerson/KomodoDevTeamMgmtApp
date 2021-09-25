using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Developer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; }
        public bool PluralsightAccess { get; set; }
        public List<DevTeam> Teams { get; set; }
        public Developer(int id, string firstName, string lastName, bool pluralsightAccess)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{FirstName} {LastName}";
            PluralsightAccess = pluralsightAccess;
        }
        


    }
}
