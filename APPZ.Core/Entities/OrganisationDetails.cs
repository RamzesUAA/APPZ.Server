using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPZ.Core.Entities
{
    public class OrganisationDetails: BaseEntity
    {
        [Required]

        [ForeignKey("Organisation")]
        public Guid OrganisationId { get; set; }
        public UserEntity Organisation { get; set; }
        public string SlackHook { get; set; }
    }
}
