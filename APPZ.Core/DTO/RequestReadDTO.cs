namespace APPZ.Core.DTO
{
    public class RequestReadDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
