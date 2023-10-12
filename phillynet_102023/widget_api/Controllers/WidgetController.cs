using Microsoft.AspNetCore.Mvc;
using widget_api.Models;
using widget_api.Services;

namespace widget_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WidgetController
{
    private readonly IWidgetService _widgetService;

    public WidgetController(IWidgetService widgetService)
    {
        _widgetService = widgetService;
    }

    [HttpGet]
    public IEnumerable<Widget> Get()
    {
        return _widgetService.GetWidgets();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Widget widget)
    {
        _widgetService.CreateWidget(widget);
        return new OkResult();
    }
}