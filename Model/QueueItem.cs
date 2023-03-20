using AutoFilesAcceptence.Etentions;
using AutoFilesAcceptence.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFilesAcceptence.Model
{
    internal class QueueItem : IMoving
    {
        private readonly string _errTokenBase = "H:\\ERR_TOKEN";
        private CheckFile Checker = new CheckFile();

        public List<FileInfo> Files { get; private set; }
        public Station DestinationStation { get; private set; }


        public QueueItem(List<FileInfo> files)
        {
            Files = files;
        }

        public void SetDestinationStaion(Station station)
        {
            DestinationStation = DestinationStation ?? station;
        }

        public void MoveTo()
        {
            if (!Files.Any()) return;

            if (DestinationStation == null) return;

            foreach (var file in Files)
            {
                if (!file.Exists) continue;                

                ////TODO: можем объебаться в перемещении из-за занятости файла
                Task.Run(() =>
                {
                    var path = Path.Combine(DestinationStation.BaseFolderPath, file.Name);
                    var oldFullName = new FileInfo(file.FullName);
                    if (!Checker.IsLocked(file.FullName))
                        file.MoveTo(path);

                    DeleteLockFile(oldFullName);
                });                                
            }
        }

        public void MoveErrTokenFiles()
        {
            if (!Files.Any()) return;

            foreach (var file in Files)
            {
                if (!file.Exists) continue;

                Task.Run(() =>
                {
                    if (!Checker.IsLocked(file.FullName)) 
                    {
                        var path = Path.Combine(_errTokenBase, file.Name);

                        CreateErrLockFile(file);
                        
                        file.MoveTo(path);
                    }
                });
            }
        }

        public void CreateErrLockFile(FileInfo file)
        {
            var fileLock = new FileInfo(Path.Combine(
                    _errTokenBase,
                    Path.GetFileNameWithoutExtension(file.FullName) + ".lock")
                    );

            fileLock.Create().Dispose();
            using (StreamWriter sw = fileLock.CreateText())
            {
                sw.WriteLine($"{file.CreationTime} | {file.FullName} | {file.Directory}");
            }
        }

        public void DeleteLockFile(FileInfo file)
        {
            var lockFile = new FileInfo(Path.Combine(
                        file.Directory.FullName,
                        Path.GetFileNameWithoutExtension(file.FullName) + ".lock")
                        );
            if (lockFile.Exists) lockFile.Delete();
        }
    }
}
