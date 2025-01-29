using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
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

        public static String DetailedExitFormat = "Details: {Quantity} {Product.Name}";
        [SearchMemberOptions(SearchMemberMode.Exclude)]

        public String DetailedExitName
        {
            get { return ObjectFormatter.Format(DetailedExitFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }

        public override void OnSaving()
        {
            base.OnSaving();

            if (Exit != null && Exit.DetailedExitList != null)
            {
                var exitList = ObjectSpace.GetObjects<Exit>().Where(e => e.Gestion == Exit.Gestion);
                var entryist = ObjectSpace.GetObjects<Entry>().Where(e => e.Gestion == Exit.Gestion);
           
                var totalIn = entryist.Sum(e => e.DetailedEntryList.Where(de => de.Product == Product).Sum(de => de.Quantity));
                var totalOut = exitList.Sum(e => e.DetailedExitList.Where(de => de.Product == Product).Sum(de => de.Quantity));
                if (totalOut + Quantity > totalIn)
                {
                    throw new UserFriendlyException("The quantity of the product in the exit cannot be greater than the quantity of the product in the entries.");
                }
            }
        }

    }
}