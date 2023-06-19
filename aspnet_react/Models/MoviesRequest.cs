namespace aspnet_react.Models
{
    public class MoviesRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ItemType { get; set; }
        public int ImageId { get; set; }
        public DateOnly Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public IFormFile CoverImage { get; set; }
    }
}
