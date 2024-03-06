using System.Drawing;

namespace Mac.CarHub.Application.Common.Interfaces;

public interface ILocalizationExtenstionService
{
    string CarLocalizer(string carName);
    string LocalizerColor(Color color);
}
