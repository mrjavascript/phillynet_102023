﻿using Google.Cloud.Firestore;
using widget_api.Models;

namespace widget_api.Repositories;

public class WidgetRepository : IWidgetRepository
{
    public async Task<IEnumerable<Widget>> GetWidgets()
    {
        //
        //  call firestore
        var db = await FirestoreDb.CreateAsync("phillynet-widgetdb");
        var collection = db.Collection("widgets");
        var snapshot = await collection.GetSnapshotAsync();

        //
        //  populate
        var widgets = new List<Widget>();
        foreach (var snapshotDocument in snapshot)
        {
            var widget = new Widget() { Id = snapshotDocument.Id };

            //
            //  get the data
            var document = snapshotDocument.ToDictionary();
            widget.WidgetName = document["widgetName"].ToString();
            widget.WidgetPrice = Convert.ToDecimal(document["widgetPrice"].ToString());
            widgets.Add(widget);
        }

        return widgets;
    }

    public async Task CreateWidget(Widget widget)
    {
        var db = await FirestoreDb.CreateAsync("phillynet-widgetdb");
        var collection = db.Collection("widgets");
        await collection.AddAsync(new Dictionary<string, object>
        {
            { "widgetName", widget.WidgetName },
            { "widgetPrice", widget.WidgetPrice },
        });
    }
}