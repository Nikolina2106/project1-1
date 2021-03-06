﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            CeoService ceoService = new CeoService();
            StrService stService = new StrService();
            PmService pmService = new PmService();
            DsnrService dsnService = new DsnrService();
            DevService devService = new DevService();

            Console.WriteLine("Available commands: Add, Remove, Display, List, Help");
            CommonService commonService = new CommonService();

            string command;
            do
            {
                Console.Write("Command: ");
                command = Console.ReadLine();
                command = command.ToLower();
                if (command != "add" + "remove" + "display" + "list" + "help")
                {
                    Console.WriteLine("Wrong input, try again.\n" +
                        "Options: Add, Remove, Display, List, Help. ");
                }

            }
            while (command != "add" + "remove" + "display" + "list" + "help");

            string role;
            if (command == "add")
            {
                do
                {
                    Console.Write("Role: ");
                    role = Console.ReadLine();
                    role = role.ToLower();

                    if (role != "ceo" + "pm" + "dev" + "dsn" + "st")
                    {
                        Console.WriteLine("Wrong role, try again.\n" +
                            "Options: Ceo, Dev, Dsnr, Pm, Str. ");
                    }
                }
                while (role != "ceo" + "pm" + "dev" + "dsn" + "st");

                switch (role)
                {
                    case "ceo":
                        ceoService.Add();
                        break;
                    case "pm":
                        pmService.Add();
                        break;
                    case "str":
                        stService.Add();
                        break;
                    case "dsn":
                        dsnService.Add();
                        break;
                    case "dev":
                        devService.Add();
                        break;
                }
            }
            else if (command.ToLower() == "help")
            {
                Console.WriteLine("Available commands: \n Add – used for adding new employee \n Remove – used for removing an existing employee \n" +
                    " Display – used to display all employees(including you!) with their basic info\n  List – used to display all employees(excluding you!) with their basic infop");
            }

            else if (command.ToLower() == "remove")
            {
                Console.Write("Enter last name of employee you want to remove from list: ");
                var removelastname = Console.ReadLine();

                commonService.Remove(removelastname);
            }

            else if (command.ToLower() == "display")
            {
                foreach (RoleProperties displaylist in Storage.Instance.MyList)
                {
                    Console.WriteLine("Role: {0}, First name: {1}, Last name: {2}, Age: {3}", displaylist.Role, displaylist.FirstName, displaylist.LastName, displaylist.Age);
                }
            }

            else if (command.ToLower() == "list")
            {
                //foreach (RoleProperties listItem in MyList.Where(item => item.Role != "ceo"))
                //{
                //    Console.WriteLine("Role: {0}, First name: {1}, Last name: {2}, Age: {3}", listItem.Role,
                //        listItem.FirstName, listItem.LastName, listItem.Age);
                //}

            }

            else if (command.ToLower() == "rolenameList")
            {
                // Console.Write("Enter role name of employees you want to display: ");
                //string roleName = Console.ReadLine();

                //foreach (RoleProperties roleNameListItem in MyList.Where(item => item.Role == roleName))
                //{
                //Console.WriteLine("Role: {0}, First name: {1}, Last name: {2}, Age: {3}", roleNameListItem.Role,
                //roleNameListItem.FirstName, roleNameListItem.LastName, roleNameListItem.Age);
                //}

            }
            else if (command.ToLower() == "exit")
            {
                return;
            }
        }

    }

}
}