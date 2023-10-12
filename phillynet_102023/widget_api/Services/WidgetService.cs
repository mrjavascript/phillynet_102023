using Google.Cloud.Firestore;
using widget_api.Models;
using widget_api.Repositories;

namespace widget_api.Services;

public class WidgetService : IWidgetService
{
    private readonly IWidgetRepository _widgetRepository;

    public WidgetService(IWidgetRepository widgetRepository)
    {
        _widgetRepository = widgetRepository;
    }

    public IEnumerable<Widget> GetWidgets()
    {
        return _widgetRepository.GetWidgets();
    }

    public void CreateWidget(Widget widget)
    {
        _widgetRepository.CreateWidget(widget);
    }
}