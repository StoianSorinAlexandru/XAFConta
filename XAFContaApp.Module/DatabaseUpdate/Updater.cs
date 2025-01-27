using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.EF;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.Extensions.DependencyInjection;
using XAFContaApp.Module.BusinessObjects;

namespace XAFContaApp.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema()
    {
        base.UpdateDatabaseAfterUpdateSchema();
        //string name = "MyName";
        //EntityObject1 theObject = ObjectSpace.FirstOrDefault<EntityObject1>(u => u.Name == name);
        //if(theObject == null) {
        //    theObject = ObjectSpace.CreateObject<EntityObject1>();
        //    theObject.Name = name;
        //}

        //ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).


        Partner partner = ObjectSpace.FirstOrDefault<Partner>(u => u.Name == "Partner A");
        if (partner == null)
        {
            partner = ObjectSpace.CreateObject<Partner>();
            partner.Name = "Partner A";
            partner.Address = "Address A";
            partner.CUI = "123456";
            partner.Type = PartnerType.Provider;
        }

        Gestion gestion = ObjectSpace.FirstOrDefault<Gestion>(u => u.Name == "Gestion A");
        if (gestion == null)
        {
            gestion = ObjectSpace.CreateObject<Gestion>();
            gestion.Name = "Gestion A";
        }

        Product product = ObjectSpace.FirstOrDefault<Product>(u => u.Name == "Product A");
        if (product == null)
        {
            product = ObjectSpace.CreateObject<Product>();
            product.Name = "Product A";
            product.Price = 100;
        }
        Exit exit = ObjectSpace.FirstOrDefault<Exit>(e => e.Gestion.Name == "Gestion A");
        if (exit == null)
        {
            exit = ObjectSpace.CreateObject<Exit>();
            exit.Date = DateTime.Now;
            exit.Partner = partner;
            exit.Gestion = gestion;
        }

        DetailedExit detailedExit = ObjectSpace.FirstOrDefault<DetailedExit>(de => de.Exit.Gestion.Name == "Gestion A");
        if (detailedExit == null)
        {
            detailedExit = ObjectSpace.CreateObject<DetailedExit>();
            detailedExit.Exit = exit;
            detailedExit.Product = product;
            detailedExit.Quantity = 5;
        }



        Entry entry = ObjectSpace.FirstOrDefault<Entry>(e => e.Gestion.Name == "Gestion A");
        if (entry == null)
        {
            entry = ObjectSpace.CreateObject<Entry>();
            entry.Date = DateTime.Now;
            entry.Partner = partner;
            entry.Gestion = gestion;
        }

        DetailedEntry detailedEntry = ObjectSpace.FirstOrDefault<DetailedEntry>(de => de.Entry.Gestion.Name == "Gestion A");
        if (detailedEntry == null)
        {
            detailedEntry = ObjectSpace.CreateObject<DetailedEntry>();
            detailedEntry.Entry = entry;
            detailedEntry.Product = product;
            detailedEntry.Quantity = 10;
        }



        ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
    }
}
