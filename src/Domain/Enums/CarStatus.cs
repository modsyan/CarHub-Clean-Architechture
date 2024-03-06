using System.ComponentModel.DataAnnotations;

namespace Mac.CarHub.Domain.Enums;

public enum CarStatus
{
    [Display(Name = "Pending")] Pending,

    [Display(Name = "Approved")] Completed,

    [Display(Name = "Denied")] Rejected
}
