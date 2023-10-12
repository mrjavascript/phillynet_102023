using Microsoft.AspNetCore.Mvc;
using widget_api.Models;

namespace widget_api.Services;

public class WidgetService : IWidgetService
{
    public IEnumerable<Widget> GetWidgets()
    {
        return new List<Widget>
        {
            new Widget { WidgetName = "Mike", WidgetPrice = 123m, Id = null }
        };
    }

    public void CreateWidget(Widget widget)
    {
        
    }
}