namespace CarBook.WebApi.Models
{
    public class CreateBlogLikeModel
    {
        public int AppUserID { get; set; }
        public int BlogID { get; set; }
        public bool IsLike { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
