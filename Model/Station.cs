using AutoFilesAcceptence.Etentions;
using AutoFilesAcceptence.Handlers;
using AutoFilesAcceptence.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

namespace AutoFilesAcceptence.Model
{
    internal class Station
    {        
        protected readonly IQueueHandler _queueHandler;
        protected CheckFile _checker = new CheckFile();

        protected Timer Timer { get; set; }
        public int TimerInterval { get => 10000; protected set { } }        
        public string BaseFolderPath { get; protected set; }


        //public Station() { }
        public Station(string baseFolderPath)
        {
            var dir = new DirectoryInfo(baseFolderPath);
            if (!dir.Exists) return;

            BaseFolderPath = baseFolderPath;

            Timer = new Timer(TimerInterval);
        }

        public Station(string baseFolderPath, IQueueHandler queueHandler) : this(baseFolderPath)
        {
            _queueHandler = queueHandler;
        }

        protected Task AddToQueue(List<FileInfo> list)
        {
            foreach (var file in list)
            {
                var fileLock = new FileInfo(Path.Combine(
                    file.Directory.FullName,
                    Path.GetFileNameWithoutExtension(file.FullName) + ".lock")
                    );

                if (fileLock.Exists) continue;
                if (_checker.IsLocked(file.FullName)) continue;

                _queueHandler.EnQueue(file);

                fileLock.Create().Dispose();
                using (StreamWriter sw = fileLock.CreateText())
                {
                    sw.WriteLine($"{file.CreationTime} | {file.FullName}");
                }
            }

            return Task.CompletedTask;
        }
    }
}
