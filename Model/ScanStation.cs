using AutoFilesAcceptence.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace AutoFilesAcceptence.Model
{
    internal class ScanStation : Station, IStation
    {        
        public bool IsLocked { get; set; }


        public ScanStation(string baseFolderPath, bool isLocked = false) 
            : base(baseFolderPath)
        {
            IsLocked = isLocked;

            Timer.Elapsed += (sender, e) => UnLock();
            Timer.Start();
        }

        public void UnLock()
        {
            var files = new DirectoryInfo(BaseFolderPath)
                .GetFiles("*.*", SearchOption.AllDirectories);
            IsLocked = files.Any();
        }

        public void Lock()
        {
            if (IsLocked) return;

            IsLocked = true;
            if (Timer.Enabled)
            {
                Timer.Stop();
            }

            Task.Run(() =>
            {
                Task.Delay(3000);
                TimerRestart();
            });

        }
        private void TimerRestart()
        {
            if (!Timer.Enabled) Timer.Start();
        }
    }
}
