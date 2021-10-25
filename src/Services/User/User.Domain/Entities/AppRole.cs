using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using User.Domain.Enums;
using User.Domain.Interfaces;

namespace User.Domain.Entities
{
    [Table("Roles")]
    public class AppRole : IdentityRole<Guid>, IAuditable, IIpTracking, ISwitchable
    {
        [StringLength(30)] public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(30)] public string ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }

        [StringLength(30)] public string IpAddress { get; set; }

        public Status Status { get; set; } = Status.Active;
    }
}