using AutoFilesAcceptence.Etentions;
using AutoFilesAcceptence.Model;
using System;
using System.Windows.Forms;

namespace AutoFilesAcceptence
{
    public partial class Form1 : Form
    {
        private StartConfig _config;

        public Form1()
        {
            _config = new StartConfig();
            InitializeComponent();
            this.ListOfDecodingStations.Items.AddRange(_config.FoldersOfDecodingStations.ToArray());
            this.ListOfScanStations.Items.AddRange(_config.FoldersOfScanStations.ToArray());
        }

        private void DeletePathToFolderOfDecodingStation_Click(object sender, EventArgs e)
        {
            var list = ListOfDecodingStations.CheckedItems;
            foreach (var item in list)
            {
                _config.DeleteItemFromList(item.ToString());
            }

            ListBoxUpdate.UpdateItemsOfCheckedListBox(ListOfDecodingStations, _config.FoldersOfDecodingStations);
        }

        private void DeletePathToFolderOfScanStation_Click(object sender, EventArgs e)
        {
            var list = ListOfScanStations.CheckedItems;
            foreach (var item in list)
            {
                _config.DeleteItemFromList(item.ToString());
            }

            ListBoxUpdate.UpdateItemsOfCheckedListBox(ListOfScanStations, _config.FoldersOfScanStations);
        }

        private void AddPathToFolderOfDecodingStation_Click(object sender, EventArgs e)
        {
            var path = FolderBrowser.GetSelectedPath();
            if (path == null) return;
                
            _config.AddDecodingStation(path);

            ListBoxUpdate.UpdateItemsOfCheckedListBox(ListOfDecodingStations, _config.FoldersOfDecodingStations);
        }

        private void AddPathToFolderOfScanStation_Click(object sender, EventArgs e)
        {
            var path = FolderBrowser.GetSelectedPath();
            if (path == null) return;

            _config.AddScanStation(path);

            ListBoxUpdate.UpdateItemsOfCheckedListBox(ListOfScanStations, _config.FoldersOfScanStations);
        }

        private void SwitchAllProcess_Click(object sender, EventArgs e)
        {
            //var accTimer = _config.Acceptence.IsRunning;
            //var decTimer = _config.DecodeHandler.IsRunning;
            //var scanTimer = _config.ScanHandler.IsRunning;

            //var switchInRun = accTimer || decTimer || scanTimer;

            //var button = sender as Button;

            //if (switchInRun)
            //{
            //    if (accTimer) AddFilesToQueueFromServer_Click(AddFilesToQueueFromServer, e);
            //    if (decTimer) MoveToDecodingFolders_Click(MoveToDecodingFolders, e);
            //    if (scanTimer) MoveToScanFolders_Click(MoveToScanFolders, e);

            //    button.Text = "Start All";
            //}
                        
        }

        private void AddFilesToQueueFromServer_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (_config.Acceptence.IsRunning) 
            { 
                _config.Acceptence.Stop();                
                button.Text = "Start acceptance handler";
            }
            else
            {
                _config.Acceptence.Start();
                button.Text = "Stop acceptance handler";
            }
        }

        private void MoveToDecodingFolders_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (_config.DecodeHandler.IsRunning)
            {
                _config.DecodeHandler.Stop();
                button.Text = "Start decoding handler";
            }
            else
            {
                _config.DecodeHandler.Start();
                button.Text = "Stop decoding handler";
            }
        }

        private void MoveToScanFolders_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (_config.ScanHandler.IsRunning)
            {
                _config.ScanHandler.Stop();
                button.Text = "Start scaning handler";
            }
            else
            {
                _config.ScanHandler.Start();
                button.Text = "Stop scaning handler";
            }
        }
    }
}
