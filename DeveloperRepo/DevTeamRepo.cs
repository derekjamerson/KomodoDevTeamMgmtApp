using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamMgmtRepo
{
    public class DevTeamRepo
    {
        List<DevTeam> _listOfTeams = new List<DevTeam>();

        public DevTeam CreateDevTeam(int id, string name)
        {
            bool uniqueID = CheckUniqueID(id);
            if (uniqueID)
            {
                DevTeam team = new DevTeam(id, name);
                _listOfTeams.Add(team);
                return team;
            }
            return null;
        }
        public bool CheckUniqueID(int id)
        {
            DevTeam team = GetDevTeamByID(id);
            return team == null;
        }
        public DevTeam GetDevTeamByID(int id)
        {
            foreach(DevTeam team in _listOfTeams)
            {
                if(team.ID == id) { return team; }
            }
            return null;
        }
        public List<DevTeam> GetDevTeamByName(string name)
        {
            List<DevTeam> _teamsByName = new List<DevTeam>();

            foreach (DevTeam team in _listOfTeams)
            {
                if (team.Name.ToLower() == name.ToLower())
                {
                    _teamsByName.Add(team);
                }
            }
            return _teamsByName;
        }

        public List<DevTeam> GetListOfDevTeams()
        {
            return _listOfTeams;
        }
        public bool UpdateDevTeam(int id, DevTeam newTeam)
        {
            DevTeam team = GetDevTeamByID(id);
            if(team != null)
            {
                team.Name = newTeam.Name;
                team.Members = newTeam.Members;
                return true;
            }
            return false;
        }
        public bool RemoveDevTeam(int id)
        {
            DevTeam team = GetDevTeamByID(id);
            if(team != null)
            {
                _listOfTeams.Remove(team);
                return true;
            }
            return false;
        }
        public void AddMember(Developer dev, DevTeam team)
        {
            team.Members.Add(dev);
        }
    }
}
