using Azure.Core;
using DevExpress.Blazor.Legacy.Internal;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    [DefaultClassOptions]

    public class Exit : BaseObject
    {

        private static int _nextAutoincrementedValue = 0;

        public virtual int Nr { get; set; }

        public virtual DateTime Date { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual Gestion Gestion { get; set; }
        [RuleRequiredField("Rule RequiredField for Exit.DetailEntryList", DefaultContexts.Save)]
        public virtual IList<DetailedExit> DetailedExitList { get; set; } = new ObservableCollection<DetailedExit>();
        public static String ExitNameFormat = "Exit: {Date} {Partner.Name}";
        [SearchMemberOptions(SearchMemberMode.Exclude)]

        public String ExitName
        {
            get { return ObjectFormatter.Format(ExitNameFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }

        public override void OnCreated()
        {
            base.OnCreated();
            Nr = _nextAutoincrementedValue;
            ++_nextAutoincrementedValue;
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