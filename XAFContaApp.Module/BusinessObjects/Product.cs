using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFContaApp.Module.BusinessObjects
{
    [NavigationItem("Test")]
    public class Product : BaseObject
    {
        public virtual string Name { get; set; }

        [FieldSize(FieldSizeAttribute.Unlimited)]
        public virtual string Description { get; set; }
        public virtual float? Price { get; set; }
    }
}
