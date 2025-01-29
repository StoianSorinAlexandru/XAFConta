using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFContaApp.Module.BusinessObjects
{
    //[NavigationItem("Accounting")]
    [DefaultClassOptions]
    public class DetailedEntry : BaseObject
    {


        [ForeignKey("Entry.Id")]
        public virtual Entry Entry { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }

        [PersistentAlias("Quantity * Product.Price")]
        public virtual decimal Value
        {
            get { return EvaluateAlias<decimal>(); }
        }

        public static String DetailedEntryNameFormater = "Details: {Quantity} {Product.Name}";
        [SearchMemberOptions(SearchMemberMode.Exclude)]

        public String DetailedEntryName
        {
            get { return ObjectFormatter.Format(DetailedEntryNameFormater, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }
    }
}