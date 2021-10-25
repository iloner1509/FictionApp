using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using User.Domain.Common;

namespace User.Domain.Entities
{
    [Table("UserAddress")]
    public class Address : BaseEntity<int>
    {
        [Required] [StringLength(50)] public string Ward { get; set; }

        [Required] [StringLength(50)] public string District { get; set; }

        [Required] [StringLength(50)] public string ProvinceOrCity { get; set; }

        [StringLength(250)] public string DetailAddress { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}