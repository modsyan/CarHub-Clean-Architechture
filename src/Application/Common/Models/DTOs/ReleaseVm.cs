using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class ReleaseVm
{
    public List<ReleaseDto> Releases { get; set; } = [];
}
