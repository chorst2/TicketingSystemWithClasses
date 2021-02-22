using System;
using System.IO;

namespace TicketingSystemAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.txt";
            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // TODO: read data from file
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            //split apart string for "Watching" subject by "|" and store in array


                            // display array data
                            //CHANGE THIS
                            Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);
                    for (int i = 0; i < 15; i++)
                    {
                        // ask a question
                        Console.WriteLine("Add a ticket? (Y/N) ");
                        // input the response
                        string resp = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (resp != "Y") { break; }
                        // prompt for ticket ID
                        Console.WriteLine("Enter TicketID: ");
                        // save the ticket ID
                        string ticketID = Console.ReadLine();
                        // prompt for ticket summary
                        Console.WriteLine("Enter the ticket summary: ");
                        // save the ticket summary
                        string ticketSummary = Console.ReadLine();
                        //prompt for ticket status
                        Console.WriteLine("Enter ticket status: ");
                        //save the ticket status 
                        string ticketStatus = Console.ReadLine();
                        //prompt for ticket priority
                        Console.WriteLine("Enter the ticket priority: ");
                        //save the ticket priority
                        string ticketPriority = Console.ReadLine();
                        //prompt for ticket submitter
                        Console.WriteLine("Enter the ticket submitter: ");
                        //save the ticket submitter
                        string ticketSubmitter = Console.ReadLine();
                        //prompt for ticket assigned
                        Console.WriteLine("Enter who the ticket is assigned to: ");
                        //save the ticket assigned
                        string ticketAssigned = Console.ReadLine();
                        //prompt for ticket watching
                        Console.WriteLine("Enter who is watching ticket (seperate names by |): ");
                        //save the ticket watching
                        string ticketWatching = Console.ReadLine();

                        //CHANGE THIS
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketID, ticketSummary, ticketStatus, ticketPriority, 
                                                                    ticketSubmitter, ticketAssigned, ticketWatching);
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
