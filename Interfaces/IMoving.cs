using AutoFilesAcceptence.Model;
using System.IO;

namespace AutoFilesAcceptence.Interfaces
{
    internal interface IMoving
    {
        void MoveTo();
        void MoveErrTokenFiles();
        void SetDestinationStaion(Station station);
        void CreateErrLockFile(FileInfo file);
        void DeleteLockFile(FileInfo file);
    }
}
