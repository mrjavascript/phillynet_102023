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
    public async Task<IEnumerable<Widget>> Get()
    {
        return await _widgetService.GetWidgets();
    }

    [HttpPost]
    public async Task<string> Create([FromBody] Widget widget)
    {
        return await _widgetService.CreateWidget(widget);
    }
}