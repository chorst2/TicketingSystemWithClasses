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
            string file = "tickets.txt";

            logger.Info("Program started");
            
            TicketsFile ticketsFile = new TicketsFile(file);
            
            string choice = "";
        
            do
            {
                // ask user a question
                Console.WriteLine("1) Read tickets from file.");
                Console.WriteLine("2) Create a ticket.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // TODO: read tciekts from file
                    // read tickets from file
                    foreach(Tickets t in ticketsFile.Ticket){
                            Console.WriteLine(t.Display());
                    }
                }

                else if (choice == "2")
                {
                    // create a ticket
                    Tickets tickets = new Tickets();
                    Console.WriteLine("Enter Ticket Id: ");
                    tickets.ticketID = Console.ReadLine();
                    
                    Console.WriteLine("Enter Ticket Summary: ");
                    tickets.ticketSummary = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Status: ");
                    tickets.ticketStatus = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Priority: ");
                    tickets.ticketPriority = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Submitter: ");
                    tickets.ticketSubmitter = Console.ReadLine();

                    Console.WriteLine("Enter who the ticket is assigned to: ");
                    tickets.ticketAssigned = Console.ReadLine();

                    Console.WriteLine("Enter who is watching the ticket: (Separate names with '|') ");
                    tickets.ticketWatching = Console.ReadLine();

                    ticketsFile.AddTicket(tickets);

                }
            } while (choice == "1" || choice == "2");
            logger.Info("Program ended");
        }
    }
}
