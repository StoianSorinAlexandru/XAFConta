using DevExpress.ExpressApp.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFContaApp.Module.BusinessObjects
{
    [NavigationItem("Accounting")]
    [ObjectCaptionFormat("{0:EntryName}")]
    [DefaultProperty(nameof(EntryName))]
    public class Entry : BaseObject
    {
        public virtual DateTime Date { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual Gestion Gestion { get; set; }
        public virtual DetailedEntry DetailedEntry { get; set; }
        public static String EntryNameFormat = "Entry: {Date} {Partner.Name}";
        [SearchMemberOptions(SearchMemberMode.Exclude)]
        public String EntryName
        {
            get { return ObjectFormatter.Format(EntryNameFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }

        public override void OnCreated()
        {
            base.OnCreated();

            if(DetailedEntry == null)
            {
                DetailedEntry = ObjectSpace.CreateObject<DetailedEntry>();
                DetailedEntry.Entry = this;
                DetailedEntry.Quantity = 1;
                DetailedEntry.Product = ObjectSpace.GetObjects<Product>().FirstOrDefault();
            }
        }
    }
}
