using System;
using System.Reflection.Metadata.Ecma335;
using Fleet.Domain.Common;
using Fleet.Domain.Common.Interfaces;

namespace Fleet.Domain.Entities
{
    public class ShipType : BaseEntity<string>, IAuditable
    {
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}