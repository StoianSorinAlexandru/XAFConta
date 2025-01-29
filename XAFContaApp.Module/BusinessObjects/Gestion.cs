using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFContaApp.Module.BusinessObjects
{
    [NavigationItem("Test")]
    [RuleCriteria("RuleCriteria for Gestion", DefaultContexts.Save, "Name is not null", SkipNullOrEmptyValues = false)]
    [DefaultClassOptions]
    public class Gestion : BaseObject
    {
        [RuleRequiredField("RuleRequiredField for Gestion.Name", DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, @"^[a-zA-Z0-9 ]+$")]
        public virtual string Name { get; set; }
    }
}
