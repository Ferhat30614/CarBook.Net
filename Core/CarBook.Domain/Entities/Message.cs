using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Message
    {

        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public AppUser Sender{ get; set; }
        public int ReceiverID { get; set; }
        public AppUser Receiver { get; set; }
        public string Content { get; set; }
        public bool ReadStatus { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
