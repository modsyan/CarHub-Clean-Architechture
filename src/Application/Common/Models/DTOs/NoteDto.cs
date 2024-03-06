using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class NoteDto
{
    public Guid Id { get; set; }

    public string Text { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public Guid CarId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Inspection, NoteDto>();
        }
    }
}
