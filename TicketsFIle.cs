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
                    ticket.ticketID = UInt64.Parse(ticketDetails[0]);
                    ticket.ticketSummary = ticketDetails[1];
                    ticket.ticketStatus = ticketDetails[2];
                    ticket.ticketPriority = ticketDetails[3];
                    ticket.ticketSubmitter = ticketDetails[4];
                    ticket.ticketAssigned = ticketDetails[5];
                    ticket.ticketWatching = ticketDetails[6].Replace('|',',');
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
                StreamWriter sw = new StreamWriter(ticketsFile, true);
                sw.WriteLine($"{ticket.ticketID},{ticket.ticketSummary},{ticket.ticketStatus},{ticket.ticketPriority},{ticket.ticketSubmitter},{ticket.ticketAssigned},{ticket.ticketWatching} ");
                sw.Close();
                Ticket.Add(ticket);
                logger.Info("Ticket id {Id} added", ticket.ticketID);
            }catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}