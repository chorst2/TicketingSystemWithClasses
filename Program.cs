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
        
            do
            {
                // ask user a question
                Console.WriteLine("1) Read all tickets");
                Console.WriteLine("2) Create a ticket");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Bug/Defect Tickets:\n");
                    // read bug/defects tickets from file
                    foreach(Tickets t in ticketsFile.Ticket){
                            Console.WriteLine(t.Display());
                    }
                    Console.WriteLine("Enhancement Tickets:\n");
                    //read enhancement tickets from file
                    foreach(Tickets t in enhancementsFile.Ticket){
                        Console.WriteLine(t.Display());
                    }
                    Console.WriteLine("Task Tickets: \n");
                    //read task tickets from file
                    foreach(Tickets t in taskFile.Ticket){
                        Console.WriteLine(t.Display());
                    }

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

                        Console.WriteLine("Enter who is watching the ticket: (Separate names with '|') ");
                        defectTickets.ticketWatching = Console.ReadLine();

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

                    Console.WriteLine("Enter who is watching the ticket: (Separate names with '|') ");
                    enhancementTickets.ticketWatching = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Software: ");
                    enhancementTickets.ticketSoftware = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Cost: ");
                    enhancementTickets.ticketCost = Decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Ticket Reason: ");
                    enhancementTickets.ticketReason = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Estimate: ");
                    enhancementTickets.ticketEstimate = Console.ReadLine();

                    ticketsFile.AddTicket(enhancementTickets);
                    }
                    

                }
            } while (choice == "1" || choice == "2");
            logger.Info("Program ended");
        }
    }
}
