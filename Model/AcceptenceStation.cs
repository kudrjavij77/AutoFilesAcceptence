using System.IO;
using System.Linq;
using System.Timers;
using System.Threading.Tasks;
using AutoFilesAcceptence.Interfaces;

namespace AutoFilesAcceptence.Model
{
    internal class AcceptenceStation : Station, IStation, ITimerRunner
    {        
        private bool _inProcces = false;
        public bool IsLocked { get; set; }
        public bool IsRunning => _inProcces;

        public AcceptenceStation(IQueueHandler handler, string baseFolderPath, bool isLocked = false) 
            : base(baseFolderPath, handler)
        {
            IsLocked = isLocked;

            Timer.Elapsed += (sender, e) => SelectFilesToMove();
            Timer.Start();
        }

        private void SelectFilesToMove()
        {
            var files = new DirectoryInfo(BaseFolderPath)
                .GetFiles("*bnk")
                .OrderByDescending(x => x.CreationTime).ToList();
            if (!files.Any()) return;

            var t = Task.Run(() => AddToQueue(files));
        }

        public void UnLock() { }

        public void Lock() { }

        public void Start()
        {
            if (!Timer.Enabled) Timer.Start();
            _inProcces = true;
        }

        public void Stop()
        {
            if (Timer.Enabled) Timer.Stop();
            _inProcces = false;
        }
    }
}
