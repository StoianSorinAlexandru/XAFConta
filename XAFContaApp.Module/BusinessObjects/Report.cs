using DevExpress.ExpressApp.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFContaApp.Module.BusinessObjects
{
    [NavigationItem("Accounting")]
    [ObjectCaptionFormat("{0:ReportName}")]
    [DefaultProperty(nameof(ReportName))]
    public class Report : BaseObject
    {
        public virtual DateTime Date { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual Gestion Gestion { get; set; }

        public String ReportNameFormater = "Report: {Date} {Gestion.Name}";
        [SearchMemberOptions(SearchMemberMode.Exclude)]
        public String ReportName
        {
            get { return ObjectFormatter.Format(ReportNameFormater, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }

        public override void OnCreated()
        {
            base.OnCreated();
            this.Date = DateTime.Now;
            this.StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.EndDate = this.StartDate.AddMonths(1).AddDays(-1);
        }
    }
}
