using System;
using System.IO;
using NLog.Web;
using System.Collections.Generic;

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

            
        }
    }
}