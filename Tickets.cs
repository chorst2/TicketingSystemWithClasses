using System;
using System.IO;

namespace TicketingSystemWithClasses
{
    class Tickets
    {
         public string ticketID;                  
         public string ticketSummary;
                     
        public string ticketStatus;
        public string ticketPriority;
        public string ticketSubmitter;
        public string ticketAssigned;
        public string ticketWatching;

        public string Display(){
            return $"Ticket Id: {ticketID}\nTIcket Summary: {ticketSummary}\nTicket Status: {ticketStatus}\nTicket Priority: {ticketPriority}\nTicket Submitter: {ticketSubmitter}\nTicket Assigned: {ticketAssigned}\nTicket Watching: {ticketWatching}";
        }
    }
}