using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;

[DefaultClassOptions]
public class ReportDetails : BaseObject
{
    public virtual string Details { get; set; }

    public ReportDetails() : base() { }
}
