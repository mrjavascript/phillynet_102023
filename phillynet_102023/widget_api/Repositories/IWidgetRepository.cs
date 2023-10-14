using widget_api.Models;

namespace widget_api.Repositories;

public interface IWidgetRepository
{
    Task<IEnumerable<Widget>> GetWidgets();
    Task<string> CreateWidget(Widget widget);
}