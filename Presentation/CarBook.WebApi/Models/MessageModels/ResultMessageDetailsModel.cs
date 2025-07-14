namespace CarBook.WebApi.Models.MessageModels
{
    public class ResultMessageDetailsModel
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
