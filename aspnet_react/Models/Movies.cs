using Postgrest.Attributes;
using Postgrest.Models;

namespace aspnet_react.Models
{
    [Table("movies")]
    public class Movies : BaseModel
    {
        [PrimaryKey("id")]
        public long Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("director")]
        public string Director { get; set; }

        [Column("imageId")]
        public int ImageId {  get; set; }

        [Column("itemtype")]
        public int ItemType { get; set; }

        [Column("date")]
        public DateOnly Date { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
