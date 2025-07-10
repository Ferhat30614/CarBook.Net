namespace CarBook.WebApi.Models
{
    public class ResultBlogLikeModel
    {

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int BlogID { get; set; }
        public int UserID { get; set; }
        public bool? UserVote { get; set; }


    }
}
