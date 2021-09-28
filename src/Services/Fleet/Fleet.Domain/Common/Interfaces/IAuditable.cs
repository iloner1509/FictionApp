using System;

namespace Fleet.Domain.Common.Interfaces
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime DateCreated { get; set; }
        string ModifiedBy { get; set; }
        DateTime? DateModified { get; set; }
    }
}