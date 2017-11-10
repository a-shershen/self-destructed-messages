using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    //Message EF Context
    public class MessageContext : DbContext
    {
        //Localhost fro debug
#if DEBUG
        public MessageContext()
            : base("DefaultConnection")
        {
        }

        //web connection fro release version
#else
        public MessageContext()
            : base("WebConnections")
        {
        }
#endif

        //DB Set represents messages
        public DbSet<Message> Messages { get; set; }
    }
}
