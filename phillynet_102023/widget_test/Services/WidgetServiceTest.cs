﻿// using Moq;

using NSubstitute;
using widget_api.Models;
using widget_api.Repositories;
using widget_api.Services;

namespace widget_test.Services;

public class WidgetServiceTest
{
    private readonly IWidgetService _widgetService;
    // private readonly Mock<IWidgetRepository> _widgetRepository;
    private readonly IWidgetRepository _widgetRepository;
    
    public WidgetServiceTest()
    {
        // _widgetService = new WidgetService(new WidgetRepository());

        //  moq
        // _widgetRepository = new Mock<IWidgetRepository>();
        // _widgetService = new WidgetService(_widgetRepository.Object)


        _widgetRepository = Substitute.For<IWidgetRepository>();
        _widgetService = new WidgetService(_widgetRepository);
        
        // _widgetService = new WidgetService(Substitute.For<IWidgetRepository>());
    }


    [Fact]
    public async void GetWidgets()
    {
        var mockWidgets = new List<Widget>
        {
            new Widget
            {
                WidgetName = "Test",
                WidgetPrice = 123m
            }
        };
        
        // _widgetRepository.Setup(m => m.GetWidgets()).ReturnsAsync(mockWidgets);
        _widgetRepository.GetWidgets().Returns(mockWidgets);
        
        var widgets = await _widgetService.GetWidgets();
        Assert.NotNull(widgets);
        Assert.NotEmpty(widgets);
    }

    [Fact]
    public async void CreateWidget()
    {
        //  moq
        var mockDoc = Guid.NewGuid().ToString();
        // _widgetRepository.Setup(m => m.CreateWidget(It.IsAny<Widget>())).ReturnsAsync(mockDoc);
        _widgetRepository.CreateWidget(Arg.Any<Widget>()).Returns(mockDoc);
        
        //  good
        var mockWidget = new Widget { WidgetName = "Test", WidgetPrice = 555.6m };
        var docId = await _widgetService.CreateWidget(mockWidget);
        Assert.NotNull(docId);
        Assert.False(string.IsNullOrWhiteSpace(docId));

        //  bad
        await Assert.ThrowsAsync<ArgumentNullException>(() => _widgetService.CreateWidget(new Widget()));
    }
}