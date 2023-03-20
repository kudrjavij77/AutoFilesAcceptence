using AutoFilesAcceptence.Interfaces;
using AutoFilesAcceptence.Model;
using System.Collections.Generic;
using System.Linq;

namespace AutoFilesAcceptence.Handlers
{
    internal class ScaningQueueHandler : QueueHandler, IStationHandler
    {        
        private List<ScanStation> ScanStations { get; set; }       


        public ScaningQueueHandler(List<string> scanStations) : base()
        {
            CountFilesInQueueItem = 15;
            ScanStations = new List<ScanStation>();
            foreach (var item in scanStations)
            {
                ScanStations.Add(new ScanStation(item, true));
            }            

            QueueItemsTimer.Elapsed += (sender, e) => SendToScaningStation();
            QueueItemsTimer.Start();
        }
        

        private void SendToScaningStation()
        {
            if (!ToStationItems.Any()) return;

            var station = FindUnLockStation();
            if (station == null) return;

            var queueItem = ToStationItems.Dequeue();
            queueItem.SetDestinationStaion(station);
            queueItem.MoveTo();
        }

        private ScanStation FindUnLockStation()
        {
            var station = ScanStations.FirstOrDefault(x => !x.IsLocked);
            if (station == null) return null;
            station.Lock();

            return station;
        }

        public void AddStation(string station)
        {
            var decoder = ScanStations.FirstOrDefault(x => x.BaseFolderPath == station);
            if (decoder != null) return;
            ScanStations.Add(new ScanStation(station, true));
        }

        public void RemoveStation(string station)
        {
            var decoder = ScanStations.FirstOrDefault(x => x.BaseFolderPath == station);
            if (decoder == null) return;
            ScanStations.Remove(decoder);
        }

    }
}
