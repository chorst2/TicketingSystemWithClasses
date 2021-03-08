using System;
using System.IO;

namespace TicketingSystemWithClasses
{
    public abstract class Tickets
    {
         public string ticketID {get; set;}                  
         public string ticketSummary {get; set;}
                     
        public string ticketStatus {get;set;}
        public string ticketPriority {get; set;}
        public string ticketSubmitter {get; set;}
        public string ticketAssigned {get; set;}
        public List<string> ticketWatching {get; set;}

        public Tickets()
        {
            ticketWatching = new List<string>();
        }

        public virtual string Display(){
            return $"Ticket Id: {ticketID}\nTIcket Summary: {ticketSummary}\nTicket Status: {ticketStatus}\nTicket Priority: {ticketPriority}\nTicket Submitter: {ticketSubmitter}\nTicket Assigned: {ticketAssigned}\nTicket Watching: {string.Join(", ", ticketWatching)}\n";
        }
    }

    public class Bug : Tickets{
        public string ticketSeverity {get; set;}

        public override string Display(){
            return $"Ticket Id: {ticketID}\nTIcket Summary: {ticketSummary}\nTicket Status: {ticketStatus}\nTicket Priority: {ticketPriority}\nTicket Submitter: {ticketSubmitter}\nTicket Assigned: {ticketAssigned}\nTicket Watching: {string.Join(", ", ticketWatching)}\nTicket Severity: {ticketSeverity}\n";
        }
    }

    public class Enhancement : Tickets{
        public string ticketSoftware {get; set;}
        public decimal ticketCost {get; set;}
        public string ticketReason {get; set;}
        public string ticketEstimate {get; set;}
    }
}