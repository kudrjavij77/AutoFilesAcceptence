using AutoFilesAcceptence.Interfaces;
using AutoFilesAcceptence.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

namespace AutoFilesAcceptence.Handlers
{
    internal class QueueHandler : IQueueHandler, ITimerRunner
    {
        protected bool _inProcces;

        public int FilesTimerInterval { get => 5000; protected set { } }
        public int ItemsTimerInterval { get => 10000; protected set { } }
        public bool IsRunning => _inProcces;
        public int CountFilesInQueueItem { get => 5; protected set { } }

        protected Timer QueueFilesTimer { get; set; }
        protected Timer QueueItemsTimer { get; set; }

        public Queue<QueueItem> ToStationItems { get; protected set; }
        public Queue<FileInfo> InCommingFiles { get; protected set; }

        public QueueHandler()
        {
            InCommingFiles = new Queue<FileInfo>();
            ToStationItems = new Queue<QueueItem>();            

            QueueFilesTimer = new Timer(FilesTimerInterval);
            QueueFilesTimer.Elapsed += (sender, e) => DeQueue();
            QueueFilesTimer.Start();

            QueueItemsTimer = new Timer(ItemsTimerInterval);

            _inProcces = true;
        }


        public void EnQueue(FileInfo file)
        {
            if (file.Exists) InCommingFiles.Enqueue(file);
        }

        public void DeQueue()
        {
            var package = InCommingFiles.Take(CountFilesInQueueItem).ToList();
            if (!package.Any()) return;

            var queueItem = new QueueItem(package);
            EnQueue(queueItem);

            foreach (var item in package)
            {
                InCommingFiles.Dequeue();
            }
        }

        public void EnQueue(QueueItem item)
        {
            if (item == null || !item.Files.Any()) return;

            ToStationItems.Enqueue(item);
        }

        public void Start()
        {
            if (!QueueFilesTimer.Enabled) QueueFilesTimer.Start();
            if (!QueueItemsTimer.Enabled) QueueItemsTimer.Start();
            _inProcces = true;
        }

        public void Stop()
        {
            if (QueueFilesTimer.Enabled) QueueFilesTimer.Stop();
            if (QueueItemsTimer.Enabled) QueueItemsTimer.Stop();
            _inProcces = false;
        }

    }
}
