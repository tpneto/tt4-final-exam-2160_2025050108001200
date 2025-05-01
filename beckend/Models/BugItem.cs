namespace beckend.Models
{
    public class BugItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Priority { get; set; }
        public bool IsResolved { get; set; }
    }
}