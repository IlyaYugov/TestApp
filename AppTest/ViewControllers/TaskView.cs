using System;
using System.Collections.Generic;
using AppTest.Tables;
using CoreGraphics;
using UIKit;
namespace AppTest
{
    public sealed class TaskView : UITableView
    {
        #region >>> Private Fields

        private readonly TaskSource _source;
        private string _lastSearchString;

        #endregion <<< Private Fields

        #region >>> Constructors

        public TaskView(CGRect frame, List<TaskViewModel> models)
        {
            Frame = frame;

            RegisterClassForCellReuse(typeof(TaskCell), typeof(TaskCell).Name);

            ShowsHorizontalScrollIndicator = false;
            SeparatorStyle = UITableViewCellSeparatorStyle.None;

            _source = new TaskSource(models);
            _source.ItemSelected += OnItemSelectedHandler;

            Source = _source;

            _lastSearchString = string.Empty;
        }

        #endregion <<< Constructors

        #region >>> Public Events

        public event EventHandler<TaskViewModel> ItemSelected;

        #endregion <<< Public Events

        #region >>> Public Properties

        public List<TaskViewModel> SourceItems
        {
            get { return _source.BaseSource; }
        }

        #endregion <<< Public Properties

        #region >>> Public Methods

        public void PerformSearch(string searchString)
        {
            _lastSearchString = searchString;
            _source.PerformSearch(_lastSearchString);
            ReloadData();
        }

        public void AddItemToTable(TaskViewModel item)
        {
            _source.BaseSource.Add(item);
            PerformSearch(_lastSearchString);
        }

        public void AddItemToTableAt(TaskViewModel item, int index)
        {
            _source.BaseSource.Insert(index, item);
            PerformSearch(_lastSearchString);
        }

        #endregion <<< Public Methods

        #region >>> Private Methods

        private void OnItemSelectedHandler(object sender, TaskViewModel args)
        {
            if (ItemSelected == null) return;
            ItemSelected(this, args);
        }

        #endregion <<< Private Methods

        #region >>> IDisposable Members

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _source.ItemSelected -= OnItemSelectedHandler;
                ItemSelected = null;
                _source.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion <<< IDisposable Members
    }
}
