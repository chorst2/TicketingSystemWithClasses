using System;
using NLog.Web;
using System.IO;

namespace TicketingSystemWithClasses
{
    class Program
    {
        
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


        static void Main(string[] args)
        {        
            string bugFile = "tickets.txt";
            string enhancementFile = "enhancements.txt";
            string taskFileString = "tasks.txt";

            logger.Info("Program started");
            
            TicketsFile ticketsFile = new TicketsFile(bugFile);
            EnhancementsFile enhancementsFile = new EnhancementsFile(enhancementFile);
            TaskFile taskFile = new TaskFile(taskFileString);
            
            string choice = "";
            string ticketTypeChoice = "";
            string input = "";
        
            do
            {
                // ask user a question
                Console.WriteLine("1) Read all tickets");
                Console.WriteLine("2) Create a ticket");
                Console.WriteLine("3) Search by Status");
                Console.WriteLine("4) Search by Priority");
                Console.WriteLine("5) Search by Submitter");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if(File.Exists(bugFile)){
                    Console.WriteLine("Bug/Defect Tickets:\n");
                    // read bug/defects tickets from file
                    foreach(Tickets t in ticketsFile.Ticket){
                            Console.WriteLine(t.Display());
                    }
                    }
                    else{Console.WriteLine("Bug/Defect Ticket File does not exist");}
                    if(File.Exists(enhancementFile)){
                    Console.WriteLine("Enhancement Tickets:\n");
                    //read enhancement tickets from file
                    foreach(Tickets t in enhancementsFile.Ticket){
                        Console.WriteLine(t.Display());
                    }}
                    else{Console.WriteLine("Enhancement Ticket File does not exist");}
                    if(File.Exists(taskFileString)){
                    Console.WriteLine("Task Tickets: \n");
                    //read task tickets from file
                    foreach(Tickets t in taskFile.Ticket){
                        Console.WriteLine(t.Display());
                    }}
                    else{Console.WriteLine("Task Ticket File does not exist");}

                }

                else if (choice == "2")
                {
                    // ask user a question
                Console.WriteLine("1) Bug/Defect Ticket");
                Console.WriteLine("2) Enhancement Ticket");
                Console.WriteLine("3) Task Ticket");
                // input response
                ticketTypeChoice = Console.ReadLine();

                    if(ticketTypeChoice == "1"){
                        // create a bug/defect ticket
                        Bug defectTickets = new Bug();
                        Console.WriteLine("Enter Ticket Id: ");
                        defectTickets.ticketID = Console.ReadLine();
                        
                        Console.WriteLine("Enter Ticket Summary: ");
                        defectTickets.ticketSummary = Console.ReadLine();

                        Console.WriteLine("Enter Ticket Status: ");
                        defectTickets.ticketStatus = Console.ReadLine();

                        Console.WriteLine("Enter Ticket Priority: ");
                        defectTickets.ticketPriority = Console.ReadLine();

                        Console.WriteLine("Enter Ticket Submitter: ");
                        defectTickets.ticketSubmitter = Console.ReadLine();

                        Console.WriteLine("Enter who the ticket is assigned to: ");
                        defectTickets.ticketAssigned = Console.ReadLine();

                        do
                        {
                            // ask user to enter ticket watching
                            Console.WriteLine("Enter Ticket Watcher (or done to quit)");
                            // input genre
                            input = Console.ReadLine();
                            // if user enters "done"
                            // or does not enter a genre do not add it to list
                            if (input != "done" && input.Length > 0)
                            {
                                defectTickets.ticketWatching.Add(input);
                            }
                        } while (input != "done");

                        Console.WriteLine("Enter Ticket Severity: ");
                        defectTickets.ticketSeverity = Console.ReadLine();

                        ticketsFile.AddTicket(defectTickets);
                    }
                    else if(ticketTypeChoice == "2"){
                        // create an enhancements ticket
                    Enhancement enhancementTickets = new Enhancement();
                    Console.WriteLine("Enter Ticket Id: ");
                    enhancementTickets.ticketID = Console.ReadLine();
                    
                    Console.WriteLine("Enter Ticket Summary: ");
                    enhancementTickets.ticketSummary = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Status: ");
                    enhancementTickets.ticketStatus = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Priority: ");
                    enhancementTickets.ticketPriority = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Submitter: ");
                    enhancementTickets.ticketSubmitter = Console.ReadLine();

                    Console.WriteLine("Enter who the ticket is assigned to: ");
                    enhancementTickets.ticketAssigned = Console.ReadLine();

                    do
                        {
                            // ask user to enter ticket watching
                            Console.WriteLine("Enter Ticket Watcher (or done to quit)");
                            // input genre
                            input = Console.ReadLine();
                            // if user enters "done"
                            // or does not enter a genre do not add it to list
                            if (input != "done" && input.Length > 0)
                            {
                                enhancementTickets.ticketWatching.Add(input);
                            }
                        } while (input != "done");

                    Console.WriteLine("Enter Ticket Software: ");
                    enhancementTickets.ticketSoftware = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Cost: ");
                    enhancementTickets.ticketCost = Decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Ticket Reason: ");
                    enhancementTickets.ticketReason = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Estimate: ");
                    enhancementTickets.ticketEstimate = Console.ReadLine();

                    enhancementsFile.AddTicket(enhancementTickets);
                    }
                    else if(ticketTypeChoice == "3"){
                        // create a task ticket
                        Task taskTickets = new Task();
                        Console.WriteLine("Enter Ticket Id: ");
                        taskTickets.ticketID = Console.ReadLine();
                        
                        Console.WriteLine("Enter Ticket Summary: ");
                        taskTickets.ticketSummary = Console.ReadLine();

                        Console.WriteLine("Enter Ticket Status: ");
                        taskTickets.ticketStatus = Console.ReadLine();

                        Console.WriteLine("Enter Ticket Priority: ");
                        taskTickets.ticketPriority = Console.ReadLine();

                        Console.WriteLine("Enter Ticket Submitter: ");
                        taskTickets.ticketSubmitter = Console.ReadLine();

                        Console.WriteLine("Enter who the ticket is assigned to: ");
                        taskTickets.ticketAssigned = Console.ReadLine();

                        do
                        {
                            // ask user to enter ticket watching
                            Console.WriteLine("Enter Ticket Watcher (or done to quit)");
                            // input genre
                            input = Console.ReadLine();
                            // if user enters "done"
                            // or does not enter a genre do not add it to list
                            if (input != "done" && input.Length > 0)
                            {
                                taskTickets.ticketWatching.Add(input);
                            }
                        } while (input != "done");

                        Console.WriteLine("Enter Ticket Project Name: ");
                        taskTickets.ticketProjectName = Console.ReadLine();

                        Console.WriteLine("Enter Ticket Due Date Year (YYYY): ");
                        int userYear =  Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Ticket Due Date Month (1-12): ");
                        int userMonth = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Ticket Due Date Day (1-31): ");
                        int userDay = Int32.Parse(Console.ReadLine());
                        
                        taskTickets.ticketDueDate = new DateTime(userYear, userMonth, userDay);

                        taskFile.AddTicket(taskTickets);
                    }
                    

                }
                else if(choice == "3"){

                }
                else if(choice == "4"){

                }
                else if(choice == "5"){
                    
                }
            } while (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5");
            logger.Info("Program ended");
        }
    }
}
