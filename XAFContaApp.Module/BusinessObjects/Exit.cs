using Azure.Core;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFContaApp.Module.BusinessObjects
{
    [NavigationItem("Accounting")]
    [ObjectCaptionFormat("{0:ExitName}")]
    [DefaultProperty(nameof(ExitName))]
    public class Exit : BaseObject
    {
        public virtual DateTime Date { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual Gestion Gestion { get; set; }
        public virtual DetailedExit DetailedExit{ get; set; }
        public static String ExitNameFormat = "Exit: {Date} {Partner.Name}";
        [SearchMemberOptions(SearchMemberMode.Exclude)]

        public String ExitName
        {
            get { return ObjectFormatter.Format(ExitNameFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }

        public override void OnCreated()
        {
            base.OnCreated();

            if (DetailedExit == null)
            {
                DetailedExit = ObjectSpace.CreateObject<DetailedExit>();
                DetailedExit.Exit = this;
                DetailedExit.Quantity = 1;
                DetailedExit.Product = ObjectSpace.GetObjects<Product>().FirstOrDefault();
            }
        }

        public override void OnSaving()
        {
            base.OnSaving();
            var mostRecentExit = ObjectSpace.GetObjects<Exit>().OrderByDescending(e => e.Date).FirstOrDefault();
            if (mostRecentExit != null && Date < mostRecentExit.Date)
            {
                throw new UserFriendlyException("The date of the exit cannot be earlier than the date of the most recent exit.");
            }
        }
    }
}
