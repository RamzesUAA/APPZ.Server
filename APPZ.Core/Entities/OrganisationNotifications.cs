using APPZ.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Core.Entities
{
    public class OrganisationNotifications: BaseEntity
    {
        [Required]
        public OrgNotification Type { get; set; }
        [Required]
        [ForeignKey("Organisation")]
        public Guid OrgId { get; set; }
        public UserEntity Organisation { get; set; }
    }
}
