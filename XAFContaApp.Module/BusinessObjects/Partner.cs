using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFContaApp.Module.BusinessObjects
{
    [NavigationItem("Test")]
    [RuleCriteria("RuleCriteria for Partner", DefaultContexts.Save, "Name is not null", SkipNullOrEmptyValues = false)]
    [DefaultClassOptions]
    public class Partner : BaseObject
    {
        [RuleRegularExpression("", DefaultContexts.Save, @"^[a-zA-Z0-9 ]+$")]
        [RuleRequiredField("Rule RequiredField for Partner.Name", DefaultContexts.Save)]
        public virtual string Name { get; set; }
        [RuleRequiredField("Rule RequiredField for Partner.CUI", DefaultContexts.Save)]
        [RuleRegularExpression("RuleRegularExpression for Partner.CUI", DefaultContexts.Save, @"^\d{2,10}$")]
        public virtual string CUI { get; set; }
        [RuleRequiredField("Rule RequiredField for Partner.Address", DefaultContexts.Save)]
        [RuleRegularExpression("RuleRegularExpression for Partner.Address", DefaultContexts.Save, @"^(str\.|strada) [a-zA-Z0-9 ]+( (ap\.|apartament)[0-9]+)?( corp[0-9]+)?( scara[a-zA-Z0-9 ]+)? nr\.[0-9]+$")]
        public virtual string Address { get; set; }
        public virtual PartnerType Type { get; set; }
    }

    public enum PartnerType
    {
        Client = 0,
        Provider = 1
    }
}
