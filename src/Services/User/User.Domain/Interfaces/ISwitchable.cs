using User.Domain.Enums;

namespace User.Domain.Interfaces
{
    public interface ISwitchable
    {
        public Status Status { get; set; }
    }
}