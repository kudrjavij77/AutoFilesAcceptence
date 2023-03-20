using AutoFilesAcceptence.Interfaces;
using AutoFilesAcceptence.Model;
using System.Collections.Generic;
using System.Linq;

namespace AutoFilesAcceptence.Handlers
{
    internal class DecodingQueueHandler : QueueHandler, IStationHandler
    {
        private IQueueHandler _scanHandler;

        private List<DecodingStation> DecodingStations { get; set; }        


        public DecodingQueueHandler(List<string> decoderFolders, IQueueHandler handler) : base()
        {
            _scanHandler = handler;

            DecodingStations = new List<DecodingStation>();
            foreach (var decoderFolder in decoderFolders)
            {
                DecodingStations.Add(new DecodingStation(_scanHandler, decoderFolder, true));
            }

            QueueItemsTimer.Elapsed += (sender, e) => SendToDecodingStation();
            QueueItemsTimer.Start();
        }

        
        private void SendToDecodingStation()
        {
            if (!ToStationItems.Any()) return;

            var station = FindUnLockStation();
            if (station == null) return;

            var queueItem = ToStationItems.Dequeue();
            queueItem.SetDestinationStaion(station);
            queueItem.MoveTo();
        }

        private DecodingStation FindUnLockStation()
        {
            var station = DecodingStations.FirstOrDefault(x=>!x.IsLocked);
            if (station == null) return null;
            station.Lock();

            return station;
        }                  

        public void AddStation(string station)
        {
            var decoder = DecodingStations.FirstOrDefault(x => x.BaseFolderPath == station);
            if(decoder!=null) return;
            DecodingStations.Add(new DecodingStation(_scanHandler, station, true));
        }

        public void RemoveStation(string station)
        {
            var decoder = DecodingStations.FirstOrDefault(x => x.BaseFolderPath == station);
            if (decoder == null) return;
            DecodingStations.Remove(decoder);
        }
    }
}
