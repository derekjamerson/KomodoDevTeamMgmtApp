using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using KomodoDevTeamMgmtRepo;

namespace Program
{
    public class ProgramUI
    {
        KomodoDevTeamMgmtRepo.DeveloperRepo developerRepo = new KomodoDevTeamMgmtRepo.DeveloperRepo();
        KomodoDevTeamMgmtRepo.DevTeamRepo teamRepo = new KomodoDevTeamMgmtRepo.DevTeamRepo();

        public void Run()
        {
            while (true)
            {
                switch (MainMenu())
                {
                    case 1:
                        int viewMenu = ViewMenu();
                        if (viewMenu != 0) { DoViewMenu(viewMenu); }
                        break;
                    case 2:
                        int manageMenu = ManageMenu();
                        if(manageMenu != 0) { DoManageMenu(manageMenu); }
                        break;
                }
            }
        }
        public void PrintTitle()
        {
            Console.Clear();
            string title = "Komodo Insurance Developer Team Management Application";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title + "\n\n\n"));
        }
        public int MainMenu()
        {
            Console.CursorVisible = false;
            List<string> _options = GetMainMenuOptions();

            PrintTitle();
            PrintMenu(_options, 2, 1);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                    case ConsoleKey.D3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        public List<string> GetMainMenuOptions()
        {
            List<string> _options = new List<string>();
            _options.Add("View");
            _options.Add("Manage");
            _options.Add("Exit");
            return _options;
        }
        public int ViewMenu()
        {
            List<string> _devOptions = GetViewDevMenuOptions();
            List<string> _teamOptions = GetViewTeamMenuOptions();
            List<string> _extras = new List<string> { "View All Developers", "Pluralsight Access Report","Go Back" };


            PrintTitle();
            Console.WriteLine("  View Developers\n");
            PrintMenu(_devOptions, 5, 1);
            Console.WriteLine("\n  View Development Teams\n");
            PrintMenu(_teamOptions, 5, _devOptions.Count + 1);
            PrintMenu(_extras, 2, (_devOptions.Count + _teamOptions.Count + 1) );
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                    case ConsoleKey.D3:
                        return 3;
                    case ConsoleKey.D4:
                        return 4;
                    case ConsoleKey.D5:
                        return 5;
                    case ConsoleKey.D6:
                        return 0;
                    default:
                        break;
                }
            }
        }
        public List<string> GetViewDevMenuOptions()
        {
            List<string> _options = new List<string>();
            _options.Add("By ID");
            _options.Add("By Name");
            return _options;
        }
        public List<string> GetViewTeamMenuOptions()
        {
            List<string> _options = new List<string>();
            _options.Add("View All");
            return _options;
        }
        public void DoViewMenu(int option)
        {
            switch (option)
            {
                case 1:
                    while (true)
                    {
                        PrintTitle();
                        Console.Write("  ");
                        int id = AskID(false);
                        Console.CursorVisible = false;
                        Library.Developer dev = developerRepo.GetDevByID(id);
                        if (dev != null)
                        {
                            DisplayDev(dev);
                            Console.ReadKey(true);
                        }
                        else
                        {
                            PrintTitle();
                            Console.WriteLine("  Developer not found.");
                            System.Threading.Thread.Sleep(3000);
                        }
                        PrintTitle();
                        Console.Write("\n\n  View another Developer?  ");
                        bool another = AskYesNo();
                        if (!another) { break; }
                    }
                    break;
                case 2:
                    while (true)
                    {
                        PrintTitle();
                        Console.Write("  Name: ");
                        List<Library.Developer> _listOfDevs = developerRepo.GetDevByName(Console.ReadLine());
                        if(_listOfDevs.Any())
                        {
                            foreach(Library.Developer dev in _listOfDevs)
                            {
                                PrintTitle();
                                DisplayDev(dev);
                                Console.WriteLine("\n");
                            }
                        }
                        else
                        {
                            PrintTitle();
                            Console.WriteLine("  Developer not found.");
                            System.Threading.Thread.Sleep(3000);
                        }
                        PrintTitle();
                        Console.CursorVisible = false;
                        Console.Write("  View another Developer?  ");
                        bool another = AskYesNo();
                        if (!another) { break; }
                    }
                    break;
                case 3:
                    Console.CursorVisible = false;
                    PrintTitle();
                    PrintTeams(teamRepo.GetListOfDevTeams());
                    break;
                case 4:
                    Console.CursorVisible = false;
                    PrintTitle();
                    DisplayAllDevs(developerRepo.GetListOfDevs());
                    Console.ReadKey(true);
                    break;
                case 5:
                    PrintTitle();
                    Console.CursorVisible = false;
                    Console.WriteLine("  Developers without Pluralsight Access\n");
                    foreach(Library.Developer dev in developerRepo.GetNoAccessReport())
                    {
                        DisplayDev(dev);
                        Console.WriteLine("\n");
                    }
                    Console.ReadKey(true);
                    break;
            }
        }
        public int ManageMenu()
        {
            List<string> _devOptions = GetManageDevMenuOptions();
            List<string> _teamOptions = GetManageTeamMenuOptions();
            List<string> _back = new List<string> { "Go Back" };

            PrintTitle();
            Console.WriteLine("  Manage Developers\n");
            PrintMenu(_devOptions, 5, 1);
            Console.WriteLine("  Manage Teams\n");
            PrintMenu(_teamOptions, 5, (_devOptions.Count + 1));
            PrintMenu(_back, 2, (_devOptions.Count + _teamOptions.Count + 1) );
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                    case ConsoleKey.D3:
                        return 3;
                    case ConsoleKey.D4:
                        return 4;
                    case ConsoleKey.D5:
                        return 5;
                    case ConsoleKey.D6:
                        return 6;
                    case ConsoleKey.D7:
                        return 0;
                    default:
                        break;
                }
            }
        }
        public List<string> GetManageDevMenuOptions()
        {
            List<string> _options = new List<string>();
            _options.Add("Add New");
            _options.Add("Update Existing");
            _options.Add("Remove Existing");
            return _options;
        }
        public List<string> GetManageTeamMenuOptions()
        {
            List<string> _options = new List<string>();
            _options.Add("Add New");
            _options.Add("Update Existing");
            _options.Add("Delete Existing");
            return _options;
        }
        public void DoManageMenu(int option)  
        {
            switch (option)
            {
                case 1:
                    while (true)
                    {
                        Library.Developer dev = AskToCreateDev();
                        if(dev != null)
                        {
                            PrintTitle();
                            Console.Write("\n\n Add another Developer? ");
                            bool another = AskYesNo();
                            if (!another)
                            {
                                break;
                            }
                        }
                        else { break; }
                    }
                    break;
                case 2:
                    while (true)
                    {
                        AskToUpdateDev();
                        PrintTitle();
                        Console.Write("\n\n Update another Developer? ");
                        bool another = AskYesNo();
                        if (!another)
                        {
                            break;
                        }
                    }
                    break;
                case 3:
                    while (true)
                    {
                        AskToRemoveDev();
                        PrintTitle();
                        Console.Write("\n\n Remove another Developer? ");
                        bool another = AskYesNo();
                        if (!another)
                        {
                            break;
                        }
                    }
                    break;
                case 4:
                    while (true)
                    {
                        Library.DevTeam team = AskCreateTeam();
                        if (team != null)
                        {
                            PrintTitle();
                            AskAddMembersToTeam(team);

                            PrintTitle();
                            Console.Write("\n\n Add another Team? ");
                            bool another = AskYesNo();
                            if (!another)
                            {
                                break;
                            }
                        }
                        else { break; }
                    }
                    break;
                case 5:
                    while (true)
                    {
                        AskToUpdateTeam();
                        PrintTitle();
                        Console.Write("\n\n Update another Team? ");
                        bool another = AskYesNo();
                        if (!another)
                        {
                            break;
                        }
                    }
                    break;
                case 6:
                    while (true)
                    {
                        AskToRemoveTeam();
                        PrintTitle();
                        Console.Write("\n\n Delete another Team? ");
                        bool another = AskYesNo();
                        if (!another)
                        {
                            break;
                        }
                    }
                    break;
            }
        }
        public void PrintMenu(List<string> _options, int indent, int start)
        {
            for (int i = 0; i < _options.Count; i++)
            {
                for(int x = 0; x < indent; x++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine($"{i + start}. {_options[i]} \n\n");
            }
        }
        public Library.Developer AskToCreateDev()
        {
            Library.Developer dev = null;
            Library.Developer tempDev;
            while (true)
            {
                Console.CursorVisible = true;
                PrintTitle();
                Console.WriteLine("  Add New Developer\n");
                tempDev = AskDevInfo(false);
                Console.WriteLine("\n\n\n");
                Console.Write("  Add this developer?  ");
                bool addDev = AskYesNo();
                if (addDev)
                {
                    dev = developerRepo.CreateDev(tempDev.ID, tempDev.FirstName, tempDev.LastName, tempDev.PluralsightAccess);
                    if(dev != null)
                    {
                        PrintTitle();
                        Console.WriteLine("\n\n  Developer successfully added.");
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        PrintTitle();
                        Console.WriteLine("\n\n  ERROR. Developer NOT added.");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
                else
                {
                    PrintTitle();
                    Console.WriteLine("\n\n  Developer NOT added.");
                    System.Threading.Thread.Sleep(3000);
                }
                return dev;
            }
        }
        public void AskToUpdateDev()
        {
            PrintTitle();
            Console.WriteLine("Update Developer\n");
            Library.Developer dev = ChooseDev();
            if(dev != null)
            {
                PrintTitle();
                Console.Write($"  Update ID#{dev.ID} ({dev.FullName})?  ");
                bool searchConfirm = AskYesNo();
                if(searchConfirm == true)
                {
                    PrintTitle();
                    Console.WriteLine($"  Update ID#{dev.ID}\n");
                    Library.Developer tempDev = AskDevInfo(true);
                    Library.Developer newDev = ConvertTempToDev(dev, tempDev);
                    PrintTitle();
                    Console.Write("  Update Developer? ");
                    int updateToLeft = Console.CursorLeft;
                    int updateToTop = Console.CursorTop;
                    Console.WriteLine("\n\n  Old");
                    DisplayDev(dev);
                    Console.WriteLine("\n\n  New");
                    DisplayDev(newDev);
                    Console.SetCursorPosition(updateToLeft, updateToTop);
                    bool updateConfirm = AskYesNo();
                    if (updateConfirm)
                    {
                        bool updateSuccess = developerRepo.UpdateDev(dev.ID, newDev);
                        if (updateSuccess) 
                        {
                            PrintTitle();
                            Console.WriteLine("\n\n  Developer successfully updated.");
                            System.Threading.Thread.Sleep(3000);
                        }
                        else
                        {
                            PrintTitle();
                            Console.WriteLine("\n\n  ERROR Developer NOT updated.. ");
                            System.Threading.Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        PrintTitle();
                        Console.WriteLine("\n\n  Developer NOT updated.");
                        System.Threading.Thread.Sleep(3000);
                    }

                }
            }
        }
        public void AskToRemoveDev()
        {
            PrintTitle();
            Console.WriteLine("  Remove Developer\n");
            Library.Developer dev = ChooseDev();
            if (dev != null)
            {
                PrintTitle();
                Console.Write($"  Remove ID#{dev.ID} ({dev.FullName})?  ");
                bool firstConfirm = AskYesNo();
                if (firstConfirm == true)
                {
                    PrintTitle();
                    Console.Write($"  This cannot be undone. Are you sure you want to Remove ID#{dev.ID} ({dev.FullName}) ");
                    bool secondConfirm = AskYesNo();
                    if (secondConfirm)
                    {
                        developerRepo.RemoveDev(dev.ID);
                        System.Console.CursorVisible = false;

                        PrintTitle();
                        Console.WriteLine("Developer successfully removed.");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
            }
        }
        public Library.Developer AskDevInfo(bool updating)
        {
            Console.CursorVisible = true;
            int id = -1;
            string firstName;
            string lastName;
            bool pluralsight;

            if (!updating)
            {
                Console.Write("     ");
                id = AskID(false);
                if (id == -1) { return null; }
                Console.WriteLine("");
            }
            Console.Write("     First Name: ");
            firstName = Console.ReadLine();
            Console.Write("\n     Last Name: ");
            lastName = Console.ReadLine();
            Console.CursorVisible = false;
            Console.Write("\n     Pluralsight Access: ");
            pluralsight = AskYesNo();
            Library.Developer dev = new Library.Developer(id, firstName, lastName, pluralsight);
            return dev;
        }
        public int AskID(bool devTeam)
        {
            Console.Write("ID: ");
            while (true)
            {
                int toLeft = Console.CursorLeft;
                int toTop = Console.CursorTop;
                string response = Console.ReadLine();
                if (string.IsNullOrEmpty(response)) { return -1; }
                int id = StringToInt(response);
                if (id < 1)
                {
                    ClearText(toLeft, toTop);
                }
                else 
                {
                    bool uniqueID = default;
                    if (devTeam) { uniqueID = teamRepo.CheckUniqueID(id); }
                    else { uniqueID = developerRepo.CheckUniqueID(id); }
                    if (uniqueID)
                    {
                        return id; 
                    }
                    else
                    {
                        Console.Write("  DUPLICATE ID ERROR");
                        System.Threading.Thread.Sleep(2000);
                        ClearText(toLeft, toTop);
                    }
                }
            }
        }
        public bool AskYesNo()
        {
            bool answered = false;
            int toLeft = Console.CursorLeft;
            int toTop = Console.CursorTop;
            bool selectedOption = false;
            Console.CursorVisible = true;
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.Y:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                        selectedOption = true;
                        Console.SetCursorPosition(toLeft, toTop);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" Yes ");
                        Console.CursorVisible = false;
                        Console.ResetColor();
                        answered = true;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.N:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                        selectedOption = false;
                        Console.SetCursorPosition(toLeft, toTop);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" No ");
                        Console.CursorVisible = false;
                        Console.ResetColor();
                        answered = true;
                        break;
                    case ConsoleKey.Enter:
                        if (answered)
                        {
                            if (selectedOption)
                            {
                                Console.SetCursorPosition(toLeft, toTop);
                                ClearText(toLeft, toTop);
                                Console.Write(" Yes ");
                            }
                            else
                            {
                                Console.SetCursorPosition(toLeft, toTop);
                                ClearText(toLeft, toTop);
                                Console.Write(" No ");
                            }
                            return selectedOption;
                        }
                        break;
                    default:
                        break;

                }
            }
        }
        public int StringToInt(string input)
        {
            int output = -1;
            if (int.TryParse(input, out output))
            {
                if(output > 0) { return output; }
            }
            return output;
        }
        public void ClearText(int toLeft, int toTop)
        {
            Console.SetCursorPosition(toLeft, toTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(toLeft, toTop);
        }
        public Library.Developer ChooseDev()
        {
            int startLeft = Console.CursorLeft;
            int startTop = Console.CursorTop;
            Library.Developer dev;
            int id;

            Console.SetCursorPosition(startLeft, startTop);
            Console.Write("     Developer ID or Name: ");
            int toLeft = Console.CursorLeft;
            int toTop = Console.CursorTop;
            while (true)
            {
                Console.CursorVisible = true;

                string response = Console.ReadLine();
                if(int.TryParse(response, out id))
                {
                    dev = developerRepo.GetDevByID(id);
                    if(dev != null)
                    {
                        return dev;
                    }
                    else
                    {
                        Console.CursorVisible = false;

                        Console.SetCursorPosition(toLeft, toTop);
                        Console.Write($"{response}   DEVELOPER NOT FOUND");
                        System.Threading.Thread.Sleep(3000);
                        Console.SetCursorPosition(toLeft, toTop);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(toLeft, toTop);
                    }
                }
                else if(string.IsNullOrEmpty(response)){ return null; }
                else
                {
                    List<Library.Developer> _listOfDevs = developerRepo.GetDevByName(response);
                    if(_listOfDevs.Count != 0)
                    {
                        if(_listOfDevs.Count == 1)
                        {
                            return _listOfDevs[0];
                        }
                        else
                        {
                            Console.CursorVisible = false;
                            Console.SetCursorPosition(startLeft, startTop);
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(startLeft, startTop);

                            Console.WriteLine($"  Results for '{response}'. Select a Developer.\n");
                            for (int i = 0; i < _listOfDevs.Count; i++)
                            {
                                Console.WriteLine($"     {i+1}.");
                                DisplayDev(_listOfDevs[i]);
                                Console.WriteLine("\n");
                            }
                            while (true)
                            {
                                ConsoleKeyInfo key = Console.ReadKey(true);
                                if (char.IsDigit(key.KeyChar)) 
                                {
                                    int choice = (int.Parse(key.KeyChar.ToString())) - 1;
                                    if(choice < _listOfDevs.Count) { return _listOfDevs[choice]; }
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        Console.CursorVisible = false;

                        Console.SetCursorPosition(toLeft, toTop);
                        Console.Write($"{response}   DEVELOPER NOT FOUND");
                        System.Threading.Thread.Sleep(3000);
                        Console.SetCursorPosition(toLeft, toTop);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(toLeft, toTop);
                    }
                }
            }
        }
        public void DisplayDev(Library.Developer dev)
        {
            Console.WriteLine($"     ID: {dev.ID}");
            Console.WriteLine($"     Name: {dev.FullName}");
            if (dev.Teams != null) { Console.WriteLine($"     Teams: {ListTeams(dev)}"); }
            else { Console.WriteLine("     Team: None"); }
        }
        public void DisplayAllDevs(List<Library.Developer> _listOfDevs)
        {
            foreach(Library.Developer dev in _listOfDevs)
            {
                Console.WriteLine($"  ({dev.ID}) {dev.FullName} - {ListTeams(dev)}");
            }
        }
        public Library.Developer ConvertTempToDev(Library.Developer oldDev, Library.Developer temp)
        {
            int id = oldDev.ID;
            string firstName;
            string lastName;
            bool pluralsight;

            if (string.IsNullOrEmpty(temp.FirstName)) { firstName = oldDev.FirstName; }
            else { firstName = temp.FirstName; }

            if (string.IsNullOrEmpty(temp.LastName)) { lastName = oldDev.LastName; }
            else { lastName = temp.LastName; }

            pluralsight = temp.PluralsightAccess;

            Library.Developer newDev = new Library.Developer(id, firstName, lastName, pluralsight);
            return newDev;
        }
        public Library.DevTeam AskCreateTeam()
        {
            Console.CursorVisible = true;
            Library.DevTeam team = null;
            Library.DevTeam tempTeam;

            while (true)
            {
                PrintTitle();
                Console.WriteLine("  Add Team\n");
                tempTeam = AskTeamInfo(false);
                Console.WriteLine("\n\n\n");
                Console.Write("  Add this Team?  ");
                bool addTeam = AskYesNo();
                if (addTeam)
                {
                    team = teamRepo.CreateDevTeam(tempTeam.ID, tempTeam.Name);
                    if (team != null)
                    {
                        PrintTitle();
                        Console.WriteLine("\n\n  Developer successfully added.");
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        PrintTitle();
                        Console.WriteLine("\n\n  ERROR. Developer NOT added.");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
                else
                {
                    PrintTitle();
                    Console.WriteLine("\n\n  Developer NOT added.");
                    System.Threading.Thread.Sleep(3000);
                }
                return team;
            }

        }
        public Library.DevTeam AskTeamInfo(bool updating)
        {
            Console.CursorVisible = true;
            int id = -1;
            string Name;

            if (!updating)
            {
                Console.Write("     ");
                id = AskID(true);
                if (id == -1) { return null; }
                Console.WriteLine("");
            }
            Console.Write("     Name: ");
            Name = Console.ReadLine();
            Console.CursorVisible = false;
            Library.DevTeam team = new Library.DevTeam(id, Name);
            return team;
        }
        public void AskAddMembersToTeam(Library.DevTeam team)
        {
            int tracker = 0;
            while (true)
            {
                PrintTitle();
                Console.Write($"  Add members to {team.Name}?  ");
                bool start = AskYesNo();
                if (start)
                {
                    PrintTitle();
                    Console.WriteLine($"  Add to {team.Name}: ");
                    int toLeft = Console.CursorLeft;
                    int toTop = Console.CursorTop;
                    Console.WriteLine("");
                    PrintAllDevs();
                    while (true)
                    {
                        string selectionString = Console.ReadLine();
                        if (string.IsNullOrEmpty(selectionString))
                        {
                            if(tracker > 0)
                            {
                                PrintTitle();
                                Console.WriteLine($"  {tracker} members successfully added.");
                                System.Threading.Thread.Sleep(3000);
                            }
                            break; 
                        }
                        int selectionInt = StringToInt(selectionString);
                        if(selectionInt != -1)
                        {
                            teamRepo.AddMember(developerRepo.GetListOfDevs()[selectionInt - 1], team);
                            ClearText(toLeft, toTop);
                            tracker++;
                        }

                    }

                }

            }
        }
        public void PrintAllDevs()
        {
            int i = 0;
            foreach (Library.Developer dev in developerRepo.GetListOfDevs())
            {
                Console.WriteLine($"     {i}. ({dev.ID}) {dev.FullName} - {ListTeams(dev)}\n");
                i++;
            }
        }
        public string ListTeams(Library.Developer dev)
        {
            List<string> _teams = new List<string>();
            foreach (Library.DevTeam team in dev.Teams)
            {
                _teams.Add(team.Name);
            }
            return string.Join(", ", _teams);
        }
        public void AskToUpdateTeam()
        {
            PrintTitle();
            Console.WriteLine("Update Team\n");
            Library.DevTeam team = ChooseTeam();
            if (team != null)
            {
                PrintTitle();
                Console.Write($"  Update ID#{team.ID} ({team.Name})?  ");
                bool searchConfirm = AskYesNo();
                if (searchConfirm == true)
                {
                    PrintTitle();
                    Console.WriteLine("  Update Team name?  ");
                    bool updateName = AskYesNo();
                    if (updateName)
                    {
                        PrintTitle();
                        Console.WriteLine($"  Update ID#{team.ID}\n");
                        Library.DevTeam tempTeam = AskTeamInfo(true);
                        if (!string.IsNullOrEmpty(tempTeam.Name))
                        {
                            PrintTitle();
                            Console.WriteLine($"\n     Change Team name from '{team.Name}' to {tempTeam.Name}?  ");
                            bool nameChange = AskYesNo();
                            if (nameChange)
                            {
                                Console.CursorVisible = false;
                                PrintTitle();
                                Console.WriteLine("  Name successfully changed.");
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                PrintTitle();
                                Console.WriteLine("  Team name was NOT changed.");
                                System.Threading.Thread.Sleep(3000);
                            }
                        }
                    }
                    AskAddMembersToTeam(team);
                }
                
            }
            
        }
        public Library.DevTeam ChooseTeam()
        {
            int startLeft = Console.CursorLeft;
            int startTop = Console.CursorTop;
            Library.DevTeam team;
            int id;

            Console.SetCursorPosition(startLeft, startTop);
            Console.Write("     Team ID or Name: ");
            int toLeft = Console.CursorLeft;
            int toTop = Console.CursorTop;
            while (true)
            {
                Console.CursorVisible = true;

                string response = Console.ReadLine();
                if (int.TryParse(response, out id))
                {
                    team = teamRepo.GetDevTeamByID(id);
                    if (team != null)
                    {
                        return team;
                    }
                    else
                    {
                        Console.CursorVisible = false;

                        Console.SetCursorPosition(toLeft, toTop);
                        Console.Write($"{response}   TEAM NOT FOUND");
                        System.Threading.Thread.Sleep(3000);
                        Console.SetCursorPosition(toLeft, toTop);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(toLeft, toTop);
                    }
                }
                else if (string.IsNullOrEmpty(response)) { return null; }
                else
                {
                    List<Library.DevTeam> _listOfTeams = teamRepo.GetDevTeamByName(response);
                    if (_listOfTeams.Count != 0)
                    {
                        if (_listOfTeams.Count == 1)
                        {
                            return _listOfTeams[0];
                        }
                        else
                        {
                            Console.CursorVisible = false;
                            Console.SetCursorPosition(startLeft, startTop);
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(startLeft, startTop);

                            Console.WriteLine($"  Results for '{response}'. Select a Team.\n");
                            PrintTeams(_listOfTeams);
                            while (true)
                            {
                                ConsoleKeyInfo key = Console.ReadKey(true);
                                if (char.IsDigit(key.KeyChar))
                                {
                                    int choice = (int.Parse(key.KeyChar.ToString())) - 1;
                                    if (choice < _listOfTeams.Count) { return _listOfTeams[choice]; }
                                }

                            }
                        }
                    }
                    else
                    {
                        Console.CursorVisible = false;

                        Console.SetCursorPosition(toLeft, toTop);
                        Console.Write($"{response}   TEAM NOT FOUND");
                        System.Threading.Thread.Sleep(3000);
                        Console.SetCursorPosition(toLeft, toTop);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(toLeft, toTop);
                    }
                }
            }
        }
        public void AskToRemoveTeam()
        {
            PrintTitle();
            Console.WriteLine("  Delete Team\n");
            Library.DevTeam team = ChooseTeam();
            if (team != null)
            {
                PrintTitle();
                Console.Write($"  Delete ID#{team.ID} ({team.Name})?  ");
                bool firstConfirm = AskYesNo();
                if (firstConfirm == true)
                {
                    PrintTitle();
                    Console.Write($"  This cannot be undone. Are you sure you want to Delete ID#{team.ID} ({team.Name}) ");
                    bool secondConfirm = AskYesNo();
                    if (secondConfirm)
                    {
                        developerRepo.RemoveDev(team.ID);
                        System.Console.CursorVisible = false;

                        PrintTitle();
                        Console.WriteLine("Team successfully deleted.");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
            }
        }
        public void PrintTeams(List<Library.DevTeam> _listOfTeams)
        {
            for (int i = 0; i < _listOfTeams.Count; i++)
            {
                Console.WriteLine($"     {i + 1}. ({_listOfTeams[i].ID}) {_listOfTeams[i].Name}\n        {ListMembers(_listOfTeams[i])}");
            }
        }
        public string ListMembers(Library.DevTeam team)
        {
            List<string> _members = new List<string>();

            foreach (Library.Developer dev in team.Members)
            {
                _members.Add(dev.FullName);
            }
            return string.Join(", ", _members);
        }

    }
}
