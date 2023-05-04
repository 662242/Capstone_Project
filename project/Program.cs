

using project;
//Project p = new Project(1);
//p.AddTransaction(100, p.Id, 1);
//Console.WriteLine($"{p.Transactions[0].Proj_Id},{p.Id}");
//p.SaveData();

Project_Handler project_Handler = new Project_Handler();
Utilities.LoadData(project_Handler._portfolio);

Console.WriteLine("WELCOME TO THE LAND MANAGEMENT SYSTEM ..!", "\n \n");
Console.WriteLine(Project_Transaction.count);
Console.WriteLine("----------MENU----------", "\n\n");
while (true)
{
    Console.WriteLine(Project_Transaction.count);
    Console.WriteLine(">>> Please select any of the following choices...");



    //Console.WriteLine("You entered : "+ option);


    Console.WriteLine("1- ADD A NEW PROJECT TO THE PORTFOLIO");
    Console.WriteLine("2- SHOW LIST OF ALL EXISTING PROJECTS");//FURTHER MENU TO BE CREATED
    Console.WriteLine("3- REMOVE AN EXISTING PROJECT FROM THE PORTFOLIO");
    Console.WriteLine("4- SHOW SUMMARY FOR THE PORTFOLIO");
    Console.WriteLine("5- ENTER THE PROJECTS MENU");
    Console.WriteLine("6- EXIT");


    int option = Convert.ToInt32(Console.ReadLine());

    while (option <= 0 || option > 6)
    {
        Console.WriteLine(">>> Please select any of the given choices...");
        option = Convert.ToInt32(Console.ReadLine());

    }
    if (option == 6)
    {
        Console.WriteLine(">>> PROGRAM EXITED WITH CODE 0");
        break;
    }
    // Implementing the switch statement

    switch (option)
    {
        case 1:
            Console.WriteLine(">>>You selected 1");
            Console.WriteLine("Please Enter the type of Project => 1-Build Project 0-Renovation");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(project_Handler.AddProject(type));
            Console.WriteLine(Project_Transaction.count);
            Utilities.Save(project_Handler._portfolio);
            Console.WriteLine(Project_Transaction.count);
            break;
        case 2:
            Console.WriteLine(">>>You selected 2");
            project_Handler.AllProjects();
            Console.WriteLine(Project_Transaction.count);

            break;
        case 3:
            Console.WriteLine(">>>You selected 3");
            Console.WriteLine("Please Enter the Id of Project You want to Remove");
            int rem_Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(project_Handler.RemoveProject(rem_Id));
            Console.WriteLine(Project_Transaction.count);
            Utilities.Save(project_Handler._portfolio);
            Console.WriteLine(Project_Transaction.count);
            Utilities.LoadData(project_Handler._portfolio);
            Console.WriteLine(Project_Transaction.count);
            break;
        case 4:
            Console.WriteLine(">>>You selected 4");
            project_Handler.Portfolio_summary();
            break;
        case 5:

            Console.WriteLine("----WELCOME TO THE PROJECTS MENU ----");

            while (true)
            {
                Console.WriteLine("----HERE IS THE LIST OF ALL PROJECTS----");
                project_Handler.AllProjects();
                Console.WriteLine(Project_Transaction.count);
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("TO SELECT A PROJECT, ENTER ITS ID OR ENTER -1 TO EXIT");
                int pid = Convert.ToInt32(Console.ReadLine());
                //Get project By its id
                if (pid >= 0)
                {
                    Project p = project_Handler.GetProjectById(pid);
                    Console.WriteLine(Project_Transaction.count);
                    if (p != null)
                    {
                        while (true)
                        {

                            Console.WriteLine(">>>1- Add Transaction");
                            Console.WriteLine(">>>2- Show Project Summary");
                            Console.WriteLine(">>>3- Show Sales Transaction");
                            Console.WriteLine(">>>4- Show Purchase Transaction");
                            Console.WriteLine(">>>5- Return to Previous Menu");
                            int opt = Convert.ToInt32(Console.ReadLine());
                            if (opt == 5) break;
                            switch (opt)
                            {
                                case 1:
                                    Console.WriteLine("You have selected 1-Add Transaction");
                                    Console.WriteLine("PLEASE ENTER THE AMOUNT FOR TRANSACTION" +
                                        "\n NOTE : NEGATIVE VALUE WILL COUNT 0");
                                    float tAmount = Convert.ToInt32(Console.ReadLine());
                                    if (tAmount < 0)
                                    {
                                        tAmount = 0;
                                    }
                                    Console.WriteLine("PLEASE ENTER THE TYPE OF TRANSACTION \n 1 FOR SALES 0 FOR PURCHASE" +
                                        "\n >>> NOTE ANY WRONG INPUT WILL ASSIGN A DEFAULT VALUE OF 0");
                                    int tType = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine(p.AddTransaction(tAmount, p.Id, tType));
                                    Utilities.Save(project_Handler._portfolio);
                                    Console.WriteLine(Project_Transaction.count);
                                    break;
                                case 2:
                                    Console.WriteLine("You have selected 2-Show Project Summary");
                                    Console.WriteLine("--------------------------");
                                    Console.WriteLine(p.Summary());
                                    Console.WriteLine("--------------------------");
                                    

                                    break;
                                case 3:
                                    Console.WriteLine("You have selected 3-Show Sales Transaction");
                                    p.AllSalesTransactions();
                                    break;
                                case 4:
                                    Console.WriteLine("You have selected 4-Show Purchase Transaction");
                                    p.AllPurchaseTransactions();
                                    break;

                            }
                        }
                        Utilities.Save(project_Handler._portfolio);
                        Utilities.LoadData(project_Handler._portfolio);

                    }
                    else
                    {
                        Console.WriteLine("You entered an invalid Id");
                    }
                    Utilities.Save(project_Handler._portfolio);
                    Utilities.LoadData(project_Handler._portfolio);
                }

                else
                {
                    break;
                }
            }
            break;

        default:
            Console.WriteLine("YOU HAVE ENTERED AN INVALID INPUT");
            break;
    }



}


Console.ReadKey();
