using System;
using System.IO;
using NLog.Web;
using System.Collections.Generic;
using System.Linq;

namespace TicketingSystemWithClasses
{
    class EnhancementsFile
    {
        public string enhancementsFile {get; set;}
        public List<Tickets> Ticket {get; set;}

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


        public EnhancementsFile(string file)
        {
            enhancementsFile = file;
            Ticket = new List<Tickets>();

            try{
                StreamReader sr = new StreamReader(enhancementsFile);

                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    Enhancement enhancementTicket = new Enhancement();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    enhancementTicket.ticketID = ticketDetails[1];
                    enhancementTicket.ticketSummary = ticketDetails[2];
                    enhancementTicket.ticketStatus = ticketDetails[3];
                    enhancementTicket.ticketPriority = ticketDetails[4];
                    enhancementTicket.ticketSubmitter = ticketDetails[5];
                    enhancementTicket.ticketAssigned = ticketDetails[6];
                    enhancementTicket.ticketWatching = ticketDetails[7].Split('|').ToList();
                    enhancementTicket.ticketSoftware = ticketDetails[8];
                    enhancementTicket.ticketCost = Decimal.Parse(ticketDetails[9]);
                    enhancementTicket.ticketReason = ticketDetails[10];
                    enhancementTicket.ticketEstimate = ticketDetails[11];
                    Ticket.Add(enhancementTicket);
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", Ticket.Count);
            }catch(Exception ex){
                logger.Error(ex.Message);
            }
            
        }

        public void AddTicket(Enhancement ticket){
            try{
                StreamWriter sw = new StreamWriter(enhancementsFile, true);
                sw.WriteLine($"{ticket.ticketID},{ticket.ticketSummary},{ticket.ticketStatus},{ticket.ticketPriority},{ticket.ticketSubmitter},{ticket.ticketAssigned},{string.Join("|",ticket.ticketWatching)},{ticket.ticketSoftware},{ticket.ticketCost},{ticket.ticketReason},{ticket.ticketEstimate}");
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