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

    public class DetailedExit : BaseObject
    {
        [ForeignKey("Exit.Id")]
        public virtual Exit Exit { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }

        [PersistentAlias("Quantity * Product.Price")]
        public virtual decimal Value 
        {
            get { return EvaluateAlias<decimal>(); }
        }

        public String DetailedExitFormat = "Details: {Quantity} {Product.Name}";
        [SearchMemberOptions(SearchMemberMode.Exclude)]

        public String DetailedExitName
        {
            get { return ObjectFormatter.Format(DetailedExitFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }
    }
}
