namespace Application.Dto
{
    public class AnnouncementDto
    {
        public int Id { get; set; }               // ✅ Needed for notification payload
        public string Title { get; set; }
        public string Content { get; set; }       // ✅ Required as per your notification message
        public DateTime CreatedAt { get; set; }
    }
}
