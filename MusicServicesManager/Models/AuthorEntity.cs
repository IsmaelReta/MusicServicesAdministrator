namespace MusicServicesManager.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public List<Song> Songs { get; } = [];
    }
}