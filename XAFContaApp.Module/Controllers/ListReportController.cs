//using DevExpress.Data.Filtering;
//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.Actions;
//using DevExpress.ExpressApp.Editors;
//using DevExpress.ExpressApp.Layout;
//using DevExpress.ExpressApp.Model.NodeGenerators;
//using DevExpress.ExpressApp.SystemModule;
//using DevExpress.ExpressApp.Templates;
//using DevExpress.ExpressApp.Utils;
//using DevExpress.Persistent.Base;
//using DevExpress.Persistent.Validation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using XAFContaApp.Module.BusinessObjects;

//namespace XAFContaApp.Module.Controllers
//{
//    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ViewController.
//    public partial class ListReportController : ViewController
//    {
//        // Use CodeRush to create Controllers and Actions with a few keystrokes.
//        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
//        public ListReportController()
//        {
//            InitializeComponent();
//            TargetObjectType = typeof(Report);
//            TargetViewType = ViewType.DetailView;
//            // Target required Views (via the TargetXXX properties) and create their Actions.
//            PopupWindowShowAction showReportAction = new PopupWindowShowAction(
//                this,
//                "ShowReportAction",
//                PredefinedCategory.View
//            )
//            {
//                Caption = "Show Report"
//            };

//            showReportAction.CustomizePopupWindowParams += ShowReportAction_CustomizePopupWindowParams;
//            showReportAction.Execute += ShowReportAction_Execute;
//        }

//        private void ShowReportAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
//        {
//            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ReportDetails));
//            string reportList = Application.FindLookupListViewId(typeof(ReportDetails));
//            CollectionSourceBase collectionSource = Application.CreateCollectionSource(
//                objectSpace,
//                typeof(ReportDetails),
//                reportList
//            );

//            Report report = (Report)View.CurrentObject;
//            var popupContent = new StringBuilder();
//            popupContent.AppendLine($"Report - {report.Date:yyyy-MM-dd} - {report.Gestion?.Name}");
//            popupContent.AppendLine("Entries:");

//            // Fetch and list all related entries
//            var entries = ObjectSpace.GetObjects<Entry>().Where(
//                entry => entry.Gestion == report.Gestion
//                && report.StartDate <= entry.Date
//                && entry.Date <= report.EndDate);
//            foreach (var entry in entries)
//            {
//                popupContent.AppendLine($"Entry: {entry.Date:yyyy-MM-dd} {entry.DetailedEntry?.Product?.Name} {entry.DetailedEntry?.Product?.Price:C} {entry.DetailedEntry?.Quantity}");
//            }

//            popupContent.AppendLine("Exits:");

//            // Fetch and list all related exits
//            var exits = ObjectSpace.GetObjects<Exit>().Where(
//                exit => exit.Gestion == report.Gestion
//                && report.StartDate <= exit.Date
//                && exit.Date <= report.EndDate);
//            foreach (var exit in exits)
//            {
//                popupContent.AppendLine($"Exit: {exit.Date:yyyy-MM-dd} {exit.DetailedExit?.Product?.Name} {exit.DetailedExit?.Product?.Price:C} {exit.DetailedExit?.Quantity}");
//            }

//            ReportDetails reportDetails = ObjectSpace.CreateObject<ReportDetails>();
//            if (entries.Any() || exits.Any())
//            {
//                reportDetails.Details = popupContent.ToString();
//                ObjectSpace.CommitChanges();
//            }
//            else
//            {
//                reportDetails.Details = "No entries or exits found";
//                ObjectSpace.CommitChanges();
//            }

//            View.ObjectSpace.CommitChanges();

//            e.View = Application.CreateListView(reportList, collectionSource, true);
//        }

//        private void ShowReportAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
//        {
//            var allReportDetails = ObjectSpace.GetObjects<ReportDetails>();

//            if (allReportDetails.Any())
//            {
//                foreach (var reportDetail in allReportDetails)
//                {
//                    ObjectSpace.Delete(reportDetail);
//                }

//                ObjectSpace.CommitChanges();
//            }
//        }


//        protected override void OnActivated()
//        {
//            base.OnActivated();
//            // Perform various tasks depending on the target View.
//        }
//        protected override void OnViewControlsCreated()
//        {
//            base.OnViewControlsCreated();
//            // Access and customize the target View control.
//        }
//        protected override void OnDeactivated()
//        {
//            // Unsubscribe from previously subscribed events and release other references and resources.
//            base.OnDeactivated();
//        }
//    }
//}
