using APPZ.Core.Constants;

namespace APPZ.Core.DTO
{
    public class ProcessRequestDto
    {
        public Status Status { get; init; }
        public Guid FromOrgId { get; init; }
    }
}
