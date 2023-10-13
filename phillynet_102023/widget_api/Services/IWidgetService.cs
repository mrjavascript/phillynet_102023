using widget_api.Models;

namespace widget_api.Services;

public interface IWidgetService
{
    Task<IEnumerable<Widget>> GetWidgets();
    Task CreateWidget(Widget widget);
}