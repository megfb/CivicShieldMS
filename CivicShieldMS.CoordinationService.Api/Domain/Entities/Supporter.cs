using CivicShieldMS.Shared.Common.Domain;

namespace CivicShieldMS.CoordinationService.Api.Domain.Entities
{
    public class Supporter : Entity<string>
    {
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Expertise { get; set; } = null!; // Doctor, Lawyer, Volunteer, etc.

        public string City { get; set; } = null!;
        public string District { get; set; } = null!;

        public SupporterStatus Status { get; set; } = SupporterStatus.Available;
    }

    public enum SupporterStatus
    {
        Available,
        Assigned,
        Busy,
        Unavailable
    }
}
