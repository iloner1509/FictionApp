using Fleet.Domain.Common;
using Fleet.Domain.Common.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Fleet.Domain.Entities
{
    public class Ship : BaseEntity<string>
    {
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Builder { get; set; }
        public DateTime LaidDown { get; set; }
        public DateTime Launched { get; set; }
        public DateTime Commissioned { get; set; }
        public Status Status { get; set; }
        public string ClassId { get; set; }
        public string Armament { get; set; }
    }
}