using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;

namespace AppTest
{
    public sealed class TaskSource : UITableViewSource
    {
        #region >>> Constructors

        public TaskSource(List<TaskViewModel> source)
        {
            BaseSource = source ?? new List<TaskViewModel>();
            FilteredSource = BaseSource;
        }

        #endregion <<< Constructors

        #region >>> Public Properties

        public List<TaskViewModel> BaseSource { get; set; }

        public List<TaskViewModel> FilteredSource { get; set; }

        #endregion <<< Public Properties

        #region >>> Events

        public event EventHandler<TaskViewModel> ItemSelected;

        #endregion <<< Events

        #region >>> Public Methods

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (TaskCell)tableView.DequeueReusableCell(typeof(TaskCell).Name, indexPath);

            TaskViewModel viewModel = FilteredSource[indexPath.Row];

            cell.LeftLabel.Text = viewModel.Date.ToString("d", CultureInfo.GetCultureInfo("ru-RU")) + " / ";
            cell.RightLabel.Text = viewModel.Name;
            cell.MiddleLabel.Text = viewModel.Description;
            cell.BottomLabel.Text = viewModel.ID.ToString();

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return FilteredSource.Count;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return InterfaceHelper.FridgeRequestControlHeight;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, false);

            var item = FilteredSource[indexPath.Row];

            if (ItemSelected == null) return;

            ItemSelected(this, item);
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public void PerformSearch(string searchString)
        {
            FilteredSource = BaseSource.Where(w => w.IsMatchForSearch(searchString)).ToList();
        }

        #endregion <<< Public Methods

        #region >>> IDisposable Members

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ItemSelected = null;
            }

            base.Dispose(disposing);
        }

        #endregion <<< IDisposable Members
    }
}
