using KomodoInsurance_POCOs;
using KomodoInsurance_Repository1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamsRepo _devTeamsRepo = new DevTeamsRepo();
        public void Run()
        {
            SeedDeveloperList();
            SeedDevTeamList();
            Menu();

        }
        private void Menu()

        {
            bool isTrue = true;

            while (isTrue)
            {


                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a Developer\n" +
                    "2. View All Developers\n" +
                    "3. Remove a Developer\n" +
                    "4. Add a DevTeam\n" +
                    "5. View A DevTeam\n" +
                    "6. Remove a DevTeam\n" +
                    "7. Add Existing Developer To a DevTeam\n" +
                    "8. Remove Existing Developer From a DevTeam\n" +
                    "9. View list of Developers who still need Pluarlsight license\n"+
                    "10. Exit Application");

                int input = Int32.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        AddADeveloper();
                        break;
                    case 2:
                        ViewAllDevelopers();
                        break;
                    case 3:
                        DeleteDeveloper();
                        break;
                    case 4:
                        AddADevTeam();
                        break;
                    case 5:
                        ViewADevTeams();
                        break;
                    case 6:
                        DeleteADevTeam();
                        break;
                    case 7:
                        AddDeveloperToExistingDevTeam();
                        break;
                    case 8:
                        DeleteADeveloper();
                        break;
                    case 9:
                        ViewAllDevelopersWithoutPluralSight();
                        break;
                    case 10:
                        Console.WriteLine("Goodbye!");
                        isTrue = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddADeveloper()
        {
            Console.Clear();
            Developers developer = new Developers();

            Console.WriteLine("Enter the first name of the new developer:");
            developer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the last name of the new developer:");
            developer.LastName = Console.ReadLine();
            Console.WriteLine("Enter the Identification Number (ID) of the new developer");
            developer.IdentificationNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Does this new developer have a Pluralsight license? (y/n)");
            string hasPluralSightAccess = Console.ReadLine().ToLower();
            if (hasPluralSightAccess == "y")
            {
                developer.HasAcessToPluralsight = true;
            }
            else
            {
                developer.HasAcessToPluralsight = false;
            }

            _developerRepo.AddDeveloperToList(developer);

        }
        private void AddADevTeam()
        {
            Console.Clear();
            ViewAllDevTeams();

            DevTeams newDevTeams = new DevTeams();


            Console.WriteLine("Enter a team name for this new DevTeam");
            newDevTeams.TeamName = Console.ReadLine();
            Console.WriteLine("Enter the identification number for this new DevTeam");
            newDevTeams.TeamIdentificationNumber = Convert.ToInt32(Console.ReadLine());

            _devTeamsRepo.AddDevelopertoDevTeamToList(newDevTeams);

        }
        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developers> listOfDevelopers = _developerRepo.GetDevelopersList();

            foreach (Developers developers in listOfDevelopers)
            {
                Console.WriteLine($"{developers.FirstName}  {developers.LastName}.\n" +
                    $"Identification number:{developers.IdentificationNumber}\n" +
                    $"Access to Pluralsight: {developers.HasAcessToPluralsight}\n");
            }
        }
        private void ViewAllDevelopersWithoutPluralSight()
        {
            Console.Clear();
            List<Developers> listOfDevelopers = _developerRepo.GetDevelopersList();

            foreach (Developers developers in listOfDevelopers)
            {
                if (developers.HasAcessToPluralsight == false)
                {
                    Console.WriteLine($"{developers.FirstName}  {developers.LastName}.\n" +
                        $"Identification number:{developers.IdentificationNumber}\n" +
                        $"Access to Pluralsight: {developers.HasAcessToPluralsight}\n");
                }
            }
        }
        private void ViewADevTeams()
        {
            Console.Clear();
            ViewAllDevTeams();
            Console.WriteLine("Enter the ID of the DevTeam you would like to view:");
            int input = Convert.ToInt32(Console.ReadLine());

            DevTeams devTeam = _devTeamsRepo.GetDevTeamByIdentificationNumber(input);

            foreach (Developers developer in devTeam.Developer)
            {
                Console.WriteLine($"{developer.FirstName} {developer.LastName}\n" +
                   $"Developer ID: {developer.IdentificationNumber}\n" +
                   $"Access to Pluarlsight:{developer.HasAcessToPluralsight}\n");
            }
        }

        private void DeleteADeveloper()
        {
            Console.Clear();

            ViewAllDevTeams();
            Console.WriteLine("Enter the Identification Number of the DevTeam you would like to remove a member from:");
            int devTeamID = Convert.ToInt32(Console.ReadLine());

            ViewAllDevelopers();
            Console.WriteLine("Enter the Identification Number of the developer you would like to remove:");
            int input = Convert.ToInt32(Console.ReadLine());


            _devTeamsRepo.RemoveDevFromTeam(devTeamID, input);

        }
        private void DeleteADevTeam()
        {
            Console.Clear();
            ViewAllDevTeams();
            Console.WriteLine("Enter the Identification Number of the DevTeam you would like to remove:");
            int devTeamID = Convert.ToInt32(Console.ReadLine());


            bool wasDeleted = _devTeamsRepo.RemoveDeveloperFromDevTeamsList(devTeamID);

            if (wasDeleted == true)
            {
                Console.WriteLine("The DevTeam was successfully deleted.");
            }
            else
            {
                Console.WriteLine("DeveTeam could not be successfully deleted.");
            }
        }

        private void AddDeveloperToExistingDevTeam()
        {

            ViewAllDevelopers();
            bool isTrue = true;

            while (isTrue)
            {
                Console.WriteLine("Enter the Identification Number of the developer you would like to add to an existing DevTeam:");
                int developerID = Convert.ToInt32(Console.ReadLine());
                ViewAllDevTeams();
                Console.WriteLine("Enter the Identification Number of the DevTeam you would like to add the developer to:");
                int devTeamID = Convert.ToInt32(Console.ReadLine());

                Developers developer = _developerRepo.GetDeveloperByIdentificationNumber(developerID);
                DevTeams devTeam = _devTeamsRepo.GetDevTeamByIdentificationNumber(devTeamID);
                devTeam.Developer.Add(developer);
                _devTeamsRepo.UpdateExistingDevelopersOnDevTeamsList(devTeamID, devTeam);

                Console.WriteLine("Would you like to add another developer to a DevTeam? (y/n)");
                string input = Console.ReadLine().ToLower();

                if(input == "n")
                {
                   isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }

        }
        private void DeleteDeveloper()
        {
            ViewAllDevelopers();
            Console.WriteLine("Enter the ID of the developer you would like to delete:");
            int input = Convert.ToInt32(Console.ReadLine());


            bool wasDeleted = _developerRepo.RemoveDevTeamFromList(input);
            if (wasDeleted == true)
            {
                Console.WriteLine("The developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Could not successfully delete developer.");
            }
        }



        private void SeedDeveloperList()
        {
            Developers newDeveloper1 = new Developers("Scott", "Sharp", 1990, true);
            Developers newDeveloper2 = new Developers("Tom", "Smith", 1991, false);
            Developers newDeveloper3 = new Developers("Christina", "Thompson", 1992, true);
            Developers newDeveloper4 = new Developers("Katie", "Williams", 1993, true);
            Developers newDeveloper5 = new Developers("Colin", "Choi", 1994, false);

            _developerRepo.AddDeveloperToList(newDeveloper1);
            _developerRepo.AddDeveloperToList(newDeveloper2);
            _developerRepo.AddDeveloperToList(newDeveloper3);
            _developerRepo.AddDeveloperToList(newDeveloper4);
            _developerRepo.AddDeveloperToList(newDeveloper5);

        }
        private void SeedDevTeamList()
        {

            Developers newDeveloper = new Developers("Chadwick", "Allen", 1995, true);
            Developers newDeveloper2 = new Developers("Ashley", "LeStoll", 1996, false);
            Developers newDeveloper3 = new Developers("Bryson", "Dechambeau", 1997, true);



            DevTeams newDevTeams2 = new DevTeams(new List<Developers> { newDeveloper }, "Backend Team", 101);
            DevTeams newDevTeams3 = new DevTeams(new List<Developers> { newDeveloper2 }, "Cloud Deployment", 102);
            DevTeams newDevTeams4 = new DevTeams(new List<Developers> { newDeveloper3 }, "Mobile Team", 103);

            _devTeamsRepo.AddDevelopertoDevTeamToList(newDevTeams2);
            _devTeamsRepo.AddDevelopertoDevTeamToList(newDevTeams3);
            _devTeamsRepo.AddDevelopertoDevTeamToList(newDevTeams4);

        }
        private void ViewAllDevTeams()
        {
            Console.Clear();
            List<DevTeams> listOfDevTeams = _devTeamsRepo.GetListOfDevTeams();

            foreach (DevTeams devTeams in listOfDevTeams)
            {
                Console.WriteLine($"{devTeams.TeamName}\n" +
                    $"Team ID:{devTeams.TeamIdentificationNumber}\n");

                foreach (Developers developer in devTeams.Developer)
                {
                    Console.WriteLine($"{developer.FirstName} {developer.LastName}\n" +
                       $"Developer ID: {developer.IdentificationNumber}\n" +
                       $"Access to Pluarlsight:{developer.HasAcessToPluralsight}\n");
                 }

            }

        }
    }
}
