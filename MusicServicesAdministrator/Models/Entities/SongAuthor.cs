namespace MusicServicesAdministrator.Models.Entities
{
    public class SongAuthor
    {
        public Guid Id { get; set; }
        public int SongId { get; set; }
        public int AuthorId { get; set; }
        public Song Song { get; set; } = null!;
        public Author Author { get; set; } = null!;
    }
}
// https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many