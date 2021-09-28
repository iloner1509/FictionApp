using System;
using System.Reflection.Metadata.Ecma335;
using Fleet.Domain.Common;
using Fleet.Domain.Common.Enums;
using Fleet.Domain.Common.Interfaces;

namespace Fleet.Domain.Entities
{
    public class Class : BaseEntity<string>, IAuditable
    {
        public string Name { get; set; }
        public string Builder { get; set; }
        public string Operator { get; set; }
        public string PrecededBy { get; set; }
        public string BuildTime { get; set; }
        public string InCommission { get; set; }
        public Status Status { get; set; }
        public string TypeId { get; set; }
        public string StandardDisplacement { get; set; }
        public string FullDisplacement { get; set; }
        public long Speed { get; set; }
        public long Complement { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}