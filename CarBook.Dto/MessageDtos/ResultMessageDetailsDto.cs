using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.MessageDtos
{
    public class ResultMessageDetailsDto
    {
        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string? Content { get; set; }
        public string OtherUserName { get; set; }
        public bool ReadStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
