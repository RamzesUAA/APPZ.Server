using APPZ.Core.Constants;

namespace APPZ.Core.DTO
{
    public class RequestReadDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? City { get; set; }
        public string? Priority { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
