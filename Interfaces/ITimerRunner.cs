namespace AutoFilesAcceptence.Interfaces
{
    internal interface ITimerRunner
    {
        bool IsRunning { get; }

        void Start();
        void Stop();
    }
}
