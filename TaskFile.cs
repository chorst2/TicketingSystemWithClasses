using System;
using System.IO;
using NLog.Web;
using System.Collections.Generic;
using System.Linq;

namespace TicketingSystemWithClasses
{
    class TaskFile
    {
        public string taskFile {get; set;}
        public List<Tickets> Ticket {get; set;}

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


        public TaskFile(string file)
        {
            taskFile = file;
            Ticket = new List<Tickets>();

            try{
                StreamReader sr = new StreamReader(taskFile);

                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    Task taskTicket = new Task();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    taskTicket.ticketID = ticketDetails[1];
                    taskTicket.ticketSummary = ticketDetails[2];
                    taskTicket.ticketStatus = ticketDetails[3];
                    taskTicket.ticketPriority = ticketDetails[4];
                    taskTicket.ticketSubmitter = ticketDetails[5];
                    taskTicket.ticketAssigned = ticketDetails[6];
                    taskTicket.ticketWatching = ticketDetails[7].Split('|').ToList();
                    taskTicket.ticketProjectName = ticketDetails[8];
                    taskTicket.ticketDueDate = DateTime.Parse(ticketDetails[9]);
                    Ticket.Add(taskTicket);
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", Ticket.Count);
            }catch(Exception ex){
                logger.Error(ex.Message);
            }
            
        }

        public void AddTicket(Task ticket){
            try{
                StreamWriter sw = new StreamWriter(taskFile, true);
                sw.WriteLine($"{ticket.ticketID},{ticket.ticketSummary},{ticket.ticketStatus},{ticket.ticketPriority},{ticket.ticketSubmitter},{ticket.ticketAssigned},{string.Join("|",ticket.ticketWatching)},{ticket.ticketProjectName},{ticket.ticketDueDate}");
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