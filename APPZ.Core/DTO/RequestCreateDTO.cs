using APPZ.Core.Constants;

namespace APPZ.Core.DTO
{
    public class RequestCreateDTO
    {
        public string? Name { get; set; }
        public Status Status { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
    }
}
