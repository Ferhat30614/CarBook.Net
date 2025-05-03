using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.MessageDtos
{
    public class ResultMessageByCurrentUserDto
    {
        public int CurrentUserID { get; set; }
        public int OtherUserID { get; set; }
        public string OtherUserName { get; set; }
        public DateTime LastMessageDate { get; set; }
        public string LastMessageContent { get; set; }
    }
}
