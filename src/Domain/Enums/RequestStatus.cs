using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Mac.CarHub.Domain.Enums;

public enum RequestStatus
{
    [Display(Name = "Pending")] Pending,

    [Display(Name = "Approved")] Approved,

    [Display(Name = "Denied")] Denied,
}
