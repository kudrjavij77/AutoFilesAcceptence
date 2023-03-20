using System;

namespace AutoFilesAcceptence.Events
{
    internal class TimerEventArgs : EventArgs
    {
        public bool IsRunnig { get; set; }
    }
}
