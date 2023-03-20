using AutoFilesAcceptence.Model;
using System.IO;

namespace AutoFilesAcceptence.Interfaces
{
    internal interface IQueueHandler
    {
        void DeQueue();
        void EnQueue(FileInfo file);
        void EnQueue(QueueItem item);
        
    }
}
