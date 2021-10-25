using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using User.Domain.Enums;
using User.Domain.Interfaces;

namespace User.Domain.Entities
{
    [Table("Users")]
    public class AppUser : IdentityUser<Guid>, IAuditable, IIpTracking, ISwitchable
    {
        [StringLength(150)] [Required] public string FullName { get; set; }

        public DateTime? BirthDay { get; set; }
        public string Avatar { get; set; }
      
        [Column(TypeName = "varchar(50)")] public string IdentityCard { get; set; }
        [StringLength(30)] public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        [StringLength(30)] public string ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }

        [StringLength(30)] public string IpAddress { get; set; }

        public Status Status { get; set; } = Status.Active;
        public Address Address { get; set; }
        public Guid RoleId { get; set; }
    }
}