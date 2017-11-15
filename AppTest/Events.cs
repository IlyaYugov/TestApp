using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest
{
    public sealed class EventArgs<TArgument> : EventArgs
    {
        #region >>> Constructors

        public EventArgs(TArgument content)
        {
            Content = content;
        }

        #endregion <<< Constructors

        #region >>> Public Properties

        public TArgument Content { get; set; }

        #endregion <<< Public Properties
    }
}
