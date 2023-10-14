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

    public async Task<IEnumerable<Widget>> GetWidgets()
    {
        return await _widgetRepository.GetWidgets();
    }

    public async Task<string> CreateWidget(Widget widget)
    {
        if (widget == null || string.IsNullOrWhiteSpace(widget.WidgetName) || widget.WidgetPrice == null)
        {
            throw new ArgumentNullException("widget");
        }

        return await _widgetRepository.CreateWidget(widget);
    }
}