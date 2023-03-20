using AutoFilesAcceptence.Handlers;
using System.Collections.Generic;
using System.IO;

namespace AutoFilesAcceptence.Model
{
    internal class StartConfig
    {
        private readonly string _basePath = "";

        public List<string> FoldersOfDecodingStations { get; private set; }
        public List<string> FoldersOfScanStations { get; private set; }
        public AcceptenceStation Acceptence { get; private set; }
        public DecodingQueueHandler DecodeHandler { get; private set; }
        public ScaningQueueHandler ScanHandler { get; private set; }
        

        public StartConfig()
        {
            FoldersOfDecodingStations = new List<string>();
            FoldersOfScanStations = new List<string>();

            ScanHandler = new ScaningQueueHandler(FoldersOfScanStations);
            DecodeHandler = new DecodingQueueHandler(FoldersOfDecodingStations, ScanHandler);            

            Acceptence = new AcceptenceStation(DecodeHandler, _basePath);
        }
        
        public void AddDecodingStation(string path)
        {
            if (IsPossibleAdding(path)) 
            {
                FoldersOfDecodingStations.Add(path);
                DecodeHandler.AddStation(path);
            } 
        }

        public void AddScanStation(string path)
        {
            if (IsPossibleAdding(path))
            {
                FoldersOfScanStations.Add((path));
                ScanHandler.AddStation(path);
            }
        }

        public void DeleteItemFromList(string path)
        {
            var item = FoldersOfDecodingStations.Find(x=>x == path);
            if (item!=null)
            {
                FoldersOfDecodingStations.Remove(item);
                DecodeHandler.RemoveStation(item);
            }

            item = FoldersOfScanStations.Find(x => x == path);
            if (item!=null)
            {
                FoldersOfScanStations.Remove(item);
                ScanHandler.RemoveStation(item);
            }
        }

        private bool IsPossibleAdding(string path)
        {
            var dir = new DirectoryInfo(path);
            var f1 = dir.Exists;
            var f2 = FoldersOfDecodingStations.Contains(path);
            var f3 = FoldersOfScanStations.Contains(path);
            return f1 & !f2 & !f3;

        }

    }
}
