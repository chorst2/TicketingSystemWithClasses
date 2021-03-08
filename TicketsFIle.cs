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
                    Bug defectTicket = new Bug();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    defectTicket.ticketID = ticketDetails[1];
                    defectTicket.ticketSummary = ticketDetails[2];
                    defectTicket.ticketStatus = ticketDetails[3];
                    defectTicket.ticketPriority = ticketDetails[4];
                    defectTicket.ticketSubmitter = ticketDetails[5];
                    defectTicket.ticketAssigned = ticketDetails[6];
                    defectTicket.ticketWatching = ticketDetails[7].Split('|').ToList();
                    defectTicket.ticketSeverity = ticketDetails[8];
                    Ticket.Add(defectTicket);
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", Ticket.Count);
            }catch(Exception ex){
                logger.Error(ex.Message);
            }
            
        }

        public void AddTicket(Bug ticket){
            try{
                StreamWriter sw = new StreamWriter(ticketsFile, true);
                sw.WriteLine($"{ticket.ticketID},{ticket.ticketSummary},{ticket.ticketStatus},{ticket.ticketPriority},{ticket.ticketSubmitter},{ticket.ticketAssigned},{string.Join("|",ticket.ticketWatching)},{ticket.ticketSeverity}");
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