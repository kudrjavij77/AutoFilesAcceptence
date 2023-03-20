using AutoFilesAcceptence.Interfaces;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace AutoFilesAcceptence.Model
{
    internal class DecodingStation : Station, IStation
    {
        private string _warnDoubleFolder;
        private string _errTokenFolder;
        private string _decodedFolder;
        private string _subDirectory;

        public bool HaveUndecodedFiles { get; private set; }
        public bool HaveDuplicates { get; private set; }
        public bool HaveErrToken { get; private set; }
        public bool DecodedFolderHasFiles { get; private set; }
        public bool IsLocked { get; set; }


        public DecodingStation(IQueueHandler handler, string baseFolderPath, bool isLocked = false) 
            : base(baseFolderPath, handler)
        {
            SetFoldersNames();
                        
            IsLocked = isLocked;

            Timer.Elapsed += (sender, e) => 
            {
                CheckUndecodedFiles();
                CheckDuplicates(); 
                CheckErrToken();
                CheckDecodedFolder();
                UnLock();
            };
            Timer.Start();
        }

        public void UnLock()
        {            
            IsLocked = HaveUndecodedFiles 
                || HaveDuplicates 
                || HaveErrToken 
                || DecodedFolderHasFiles;
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

        private void CheckUndecodedFiles()
        {
            var dir = new DirectoryInfo(BaseFolderPath);
            var subDir = new DirectoryInfo(_subDirectory);
            
            HaveUndecodedFiles = (dir.Exists && dir.GetFiles().Any())
                || (subDir.Exists && subDir.GetFiles("*bnk").Any());
        }

        private void CheckDuplicates()
        {
            var dir = new DirectoryInfo(_warnDoubleFolder);
           
            HaveDuplicates = dir.Exists && dir.GetFiles().Any();

            if (!HaveDuplicates || DecodedFolderHasFiles) return;

            var duplcates = dir.GetFiles();
            foreach (var duplc in duplcates)
            {
                if (!duplc.Exists) continue;
                if (_checker.IsLocked(duplc.FullName)) continue;

                duplc.MoveTo(Path.Combine(BaseFolderPath, duplc.Name));
            }
        }

        private void CheckErrToken()
        {
            var dir = new DirectoryInfo(_errTokenFolder);
            HaveErrToken = dir.Exists && dir.GetFiles().Any();
            
            if (!HaveErrToken) return;

            var errToken = dir.GetFiles().ToList();
            var queueItem = new QueueItem(errToken);
            queueItem.MoveErrTokenFiles();
        }

        private void CheckDecodedFolder()
        {
            var dir = new DirectoryInfo(_decodedFolder);

            DecodedFolderHasFiles = dir.Exists 
                && dir.GetFiles("*.*", SearchOption.AllDirectories).Any();

            if (!DecodedFolderHasFiles) return;

            var decodedFiles = dir.GetFiles("*.*", SearchOption.AllDirectories).OrderByDescending(x=>x.CreationTime).ToList();
            if (!decodedFiles.Any()) return;

            var t = Task.Run(() => AddToQueue(decodedFiles));
        }
        
        private void SetFoldersNames()
        {
            var subDir = new DirectoryInfo(BaseFolderPath).GetDirectories().OrderByDescending(x => x.CreationTime).FirstOrDefault();
            if (subDir != null)
            {
                _subDirectory = subDir.FullName;
                _warnDoubleFolder = Path.Combine(_subDirectory, "WARN_DOUBLE");
                _errTokenFolder = Path.Combine(_subDirectory, "ERR_TOKEN");
                _decodedFolder = Path.Combine(_subDirectory, "decoded");
            }
        }

    }
}
