using widget_api.Models;

namespace widget_api.Services;

public interface IWidgetService
{
    IEnumerable<Widget> GetWidgets();
    void CreateWidget(Widget widget);
}