using System.ComponentModel.DataAnnotations;

namespace Mac.CarHub.Domain.Enums;

public enum EventType
{
    [Display(Name = "Maintenance")] Maintenance,
    [Display(Name = "Repair")] Repair,
    [Display(Name = "Enter")] Enter,
    [Display(Name = "Release")] Release,
    [Display(Name = "Inspection")] Inspection,
    [Display(Name = "Other")] Other
}
