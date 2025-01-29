using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFContaApp.Module.BusinessObjects
{
    [NavigationItem("Test")]
    [DefaultClassOptions]
    public class Product : BaseObject
    {
        [RuleRequiredField("Rule RequiredField for Product.Name", DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, @"^[a-zA-Z0-9 ]+$")]
        public virtual string Name { get; set; }

        [FieldSize(FieldSizeAttribute.Unlimited)]
        [RuleRequiredField("Rule RequiredField for Product.Description", DefaultContexts.Save)]

        public virtual string Description { get; set; }
        public virtual float? Price { get; set; }
    }
}
