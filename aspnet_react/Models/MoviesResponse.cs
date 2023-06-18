namespace aspnet_react.Models
{
    public class MoviesResponse
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public DateTime Created_At { get; set; }
        public int ItemType { get; set; }   
    }
}
