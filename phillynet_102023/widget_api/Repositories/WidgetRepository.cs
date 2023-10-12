using Google.Cloud.Firestore;
using widget_api.Models;

namespace widget_api.Repositories;

public class WidgetRepository : IWidgetRepository
{
    public IEnumerable<Widget> GetWidgets()
    {
        //
        //  call firestore
        var db = FirestoreDb.Create("phillynet-widgetdb");
        var collection = db.Collection("widgets");
        var snapshot = collection.GetSnapshotAsync().Result;

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

    public void CreateWidget(Widget widget)
    {
        throw new NotImplementedException();
    }
}