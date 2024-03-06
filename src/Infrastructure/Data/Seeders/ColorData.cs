using Mac.CarHub.Domain.Entities;
using Color = Mac.CarHub.Domain.Entities.Color;

namespace Mac.CarHub.Infrastructure.Data.Seeders;

public static class ColorData
{
    public static List<Color> GetColors()
    {
        var colors = new List<Color>
        {
            new Color { EnName = "Black", ArName = "أسود" },
            new Color { EnName = "White", ArName = "أبيض" },
            new Color { EnName = "Red", ArName = "أحمر" },
            new Color { EnName = "Blue", ArName = "أزرق" },
            new Color { EnName = "Green", ArName = "أخضر" },
            new Color { EnName = "Yellow", ArName = "أصفر" },
            new Color { EnName = "Brown", ArName = "بني" },
            new Color { EnName = "Grey", ArName = "رمادي" },
            new Color { EnName = "Silver", ArName = "فضي" },
            new Color { EnName = "Gold", ArName = "ذهبي" }
        };

        return colors;
    }
}
