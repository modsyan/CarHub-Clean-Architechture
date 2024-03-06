using System.Globalization;

namespace Mac.CarHub.Domain.Entities;

public class Color : BaseEntity
{
    public new int Id { get; set; }
    public string ArName { get; set; } = null!;
    public string EnName { get; set; } = null!;

    public ICollection<Car> Cars { get; set; } = null!;

    public string Localized()
    {
        CultureInfo culture = CultureInfo.CurrentCulture;

        return culture.Name == "ar-EG" ? this.ArName : this.EnName;
    }
}
