using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DevTeam
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Developer> Members { get; set; }
        public DevTeam(int id, string name)
        {
            List<Developer> _members = new List<Developer>();

            ID = id;
            Name = name;
            Members = _members;
        }
    }
}
