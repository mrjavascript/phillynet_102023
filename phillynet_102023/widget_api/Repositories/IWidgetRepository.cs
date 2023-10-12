using widget_api.Models;

namespace widget_api.Repositories;

public interface IWidgetRepository
{
    IEnumerable<Widget> GetWidgets();
    void CreateWidget(Widget widget);
}