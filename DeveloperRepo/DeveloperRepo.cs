using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamMgmtRepo
{
    public class DeveloperRepo
    {
        DevTeamRepo teamRepo = new DevTeamRepo();
        List<Developer> _listOfDevs = new List<Developer>();

        public Developer CreateDev(int id, string firstName, string lastName, bool pluralsight)
        {
            bool uniqueID = CheckUniqueID(id);
            if (uniqueID)
            {
                Developer dev = new Developer(id, firstName, lastName, pluralsight);
                _listOfDevs.Add(dev);
                return dev;
            }
            return null;
        }
        public bool CheckUniqueID(int id)
        {
            Developer dev = GetDevByID(id);
            return dev == null;
        }
        public Developer GetDevByID(int id)
        {
            foreach(Developer dev in _listOfDevs)
            {
                if(dev.ID == id) { return dev; }
            }
            return null;
        }
        public List<Developer> GetDevByName(string name)
        {
            List<Developer> _devsByName = new List<Developer>();

            foreach (Developer dev in _listOfDevs)
            {
                if (dev.FullName.ToLower() == name.ToLower()) 
                {
                    _devsByName.Add(dev);
                }
            }
            return _devsByName;
        }
        public List<Developer> GetListOfDevs()
        {
            return _listOfDevs;
        }
        public bool UpdateDev(int id, Developer newDev)
        {
            Developer dev = GetDevByID(id);
            if(dev != null)
            {
                dev.FirstName = newDev.FirstName;
                dev.LastName = newDev.LastName;
                dev.PluralsightAccess = newDev.PluralsightAccess;
                return true;
            }
            return false;
        }
        public bool RemoveDev(int id)
        {
            Developer dev = GetDevByID(id);
            if(dev != null)
            {
                foreach(DevTeam team in teamRepo.GetListOfDevTeams())
                {
                    foreach(Developer d in team.Members)
                    {
                        if(d.ID == id) { team.Members.Remove(d); }
                    }
                }
                _listOfDevs.Remove(dev);
                return true;
            }
            return false;
        }
        public List<Developer> GetNoAccessReport()
        {
            List<Developer> _accessList = new List<Developer>();
            foreach(Developer dev in _listOfDevs)
            {
                if (!dev.PluralsightAccess) { _accessList.Add(dev); }
            }
            return _accessList;
        }
    }
}
