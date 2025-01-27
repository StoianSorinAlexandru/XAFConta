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
    [NavigationItem("Test")]
    public class Partner : BaseObject
    {
        public virtual string Name { get; set; }
        public virtual string CUI { get; set; }
        public virtual string Address { get; set; }
        public virtual PartnerType Type { get; set; }
    }

    public enum PartnerType
    {
        Client = 0,
        Provider = 1
    }
}
