using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace AppTest
{
    public class BackgroundTaskHelper : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundTaskHelper"/> class.
        /// </summary>
        public BackgroundTaskHelper()
        {
            _backgroundTaskId = (int)UIApplication.SharedApplication.BeginBackgroundTask(() => { });
        }


        public void Dispose()
        {
            UIApplication.SharedApplication.EndBackgroundTask((nint)_backgroundTaskId);

            GC.SuppressFinalize(this);
        }

        private readonly int _backgroundTaskId;
    }
}
