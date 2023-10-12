namespace widget_api.Models;

public record Widget
{
    public string? Id { get; set; }

    public string? WidgetName { get; set; }

    public decimal WidgetPrice { get; set; }
}