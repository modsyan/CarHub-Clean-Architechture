using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class OwnerDto
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Owner, OwnerDto>();
        }
    }
}
