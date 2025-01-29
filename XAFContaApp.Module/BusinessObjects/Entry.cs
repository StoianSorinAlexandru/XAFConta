using Aqua.EnumerableExtensions;
using DevExpress.Blazor.Legacy.Internal;
using DevExpress.ExpressApp.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    [DefaultClassOptions]
    public class Entry : BaseObject
    {
        private static int _nextAutoincrementedValue = 0;
        public virtual int Nr { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual Gestion Gestion { get; set; }
        [RuleRequiredField("Rule RequiredField for Entry.DetailEntryList", DefaultContexts.Save)]
        public virtual IList<DetailedEntry> DetailedEntryList { get; set; } = new ObservableCollection<DetailedEntry>();
        public static String EntryNameFormat = "Entry: {Date} {Partner.Name}";
        [SearchMemberOptions(SearchMemberMode.Exclude)]
        public String EntryName
        {
            get { return ObjectFormatter.Format(EntryNameFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }

        public override void OnCreated()
        {
            base.OnCreated();
            Nr = _nextAutoincrementedValue;
            ++_nextAutoincrementedValue;
            
        }

    }
}