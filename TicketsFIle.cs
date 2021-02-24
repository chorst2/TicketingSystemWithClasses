using System;
using System.IO;
using NLog.Web;
using System.Collections.Generic;
using System.Linq;

namespace TicketingSystemWithClasses
{
    class TicketsFile
    {
        public string ticketsFile {get; set;}
        public List<Tickets> Ticket {get; set;}

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


        public TicketsFile(string file)
        {
            ticketsFile = file;
            Ticket = new List<Tickets>();

            try{
                StreamReader sr = new StreamReader(ticketsFile);

                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    Tickets ticket = new Tickets();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    ticket.ticketID = ticketDetails[1];
                    ticket.ticketSummary = ticketDetails[2];
                    ticket.ticketStatus = ticketDetails[3];
                    ticket.ticketPriority = ticketDetails[4];
                    ticket.ticketSubmitter = ticketDetails[5];
                    ticket.ticketAssigned = ticketDetails[6];
                    ticket.ticketWatching = ticketDetails[7].Replace('|',', ');
                    Ticket.Add(ticket);
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", Ticket.Count);
            }catch(Exception ex){
                logger.Error(ex.Message);
            }
        }

        public void AddTicket(Tickets ticket){
            try{
                ticket.ticketID = Ticket.Max(t => t.ticketID) + 1;
            
            }
        }
    }
}