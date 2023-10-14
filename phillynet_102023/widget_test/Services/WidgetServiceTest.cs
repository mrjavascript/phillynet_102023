using widget_api.Models;
using widget_api.Repositories;
using widget_api.Services;

namespace widget_test.Services;

public class WidgetServiceTest
{
    private readonly IWidgetService _widgetService;

    public WidgetServiceTest()
    {
        _widgetService = new WidgetService(new WidgetRepository());
    }


    [Fact]
    public void GetWidgets()
    {
        var widgets = _widgetService.GetWidgets().Result;
        Assert.NotNull(widgets);
        Assert.NotEmpty(widgets);
    }

    [Fact]
    public void CreateWidget()
    {
        //  good
        var mockWidget = new Widget { WidgetName = "Test", WidgetPrice = 555.6m };
        var docId = _widgetService.CreateWidget(mockWidget).Result;
        Assert.NotNull(docId);
        Assert.False(string.IsNullOrWhiteSpace(docId));

        //  bad
        Assert.ThrowsAsync<ArgumentNullException>(() => _widgetService.CreateWidget(new Widget()));
    }
}