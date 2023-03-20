namespace AutoFilesAcceptence
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListOfDecodingStations = new System.Windows.Forms.CheckedListBox();
            this.ListOfScanStations = new System.Windows.Forms.CheckedListBox();
            this.DeletePathToFolderOfDecodingStation = new System.Windows.Forms.Button();
            this.AddPathToFolderOfDecodingStation = new System.Windows.Forms.Button();
            this.DeletePathToFolderOfScanStation = new System.Windows.Forms.Button();
            this.AddPathToFolderOfScanStation = new System.Windows.Forms.Button();
            this.MoveToDecodingFolders = new System.Windows.Forms.Button();
            this.MoveToScanFolders = new System.Windows.Forms.Button();
            this.AddFilesToQueueFromServer = new System.Windows.Forms.Button();
            this.SwitchAllProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListOfDecodingStations
            // 
            this.ListOfDecodingStations.FormattingEnabled = true;
            this.ListOfDecodingStations.Location = new System.Drawing.Point(12, 161);
            this.ListOfDecodingStations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListOfDecodingStations.Name = "ListOfDecodingStations";
            this.ListOfDecodingStations.Size = new System.Drawing.Size(511, 403);
            this.ListOfDecodingStations.TabIndex = 0;
            // 
            // ListOfScanStations
            // 
            this.ListOfScanStations.FormattingEnabled = true;
            this.ListOfScanStations.Location = new System.Drawing.Point(643, 159);
            this.ListOfScanStations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListOfScanStations.Name = "ListOfScanStations";
            this.ListOfScanStations.Size = new System.Drawing.Size(511, 403);
            this.ListOfScanStations.TabIndex = 1;
            // 
            // DeletePathToFolderOfDecodingStation
            // 
            this.DeletePathToFolderOfDecodingStation.Location = new System.Drawing.Point(10, 573);
            this.DeletePathToFolderOfDecodingStation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeletePathToFolderOfDecodingStation.Name = "DeletePathToFolderOfDecodingStation";
            this.DeletePathToFolderOfDecodingStation.Size = new System.Drawing.Size(112, 35);
            this.DeletePathToFolderOfDecodingStation.TabIndex = 2;
            this.DeletePathToFolderOfDecodingStation.Text = "Delete";
            this.DeletePathToFolderOfDecodingStation.UseVisualStyleBackColor = true;
            this.DeletePathToFolderOfDecodingStation.Click += new System.EventHandler(this.DeletePathToFolderOfDecodingStation_Click);
            // 
            // AddPathToFolderOfDecodingStation
            // 
            this.AddPathToFolderOfDecodingStation.Location = new System.Drawing.Point(410, 573);
            this.AddPathToFolderOfDecodingStation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddPathToFolderOfDecodingStation.Name = "AddPathToFolderOfDecodingStation";
            this.AddPathToFolderOfDecodingStation.Size = new System.Drawing.Size(112, 35);
            this.AddPathToFolderOfDecodingStation.TabIndex = 3;
            this.AddPathToFolderOfDecodingStation.Text = "Add";
            this.AddPathToFolderOfDecodingStation.UseVisualStyleBackColor = true;
            this.AddPathToFolderOfDecodingStation.Click += new System.EventHandler(this.AddPathToFolderOfDecodingStation_Click);
            // 
            // DeletePathToFolderOfScanStation
            // 
            this.DeletePathToFolderOfScanStation.Location = new System.Drawing.Point(641, 572);
            this.DeletePathToFolderOfScanStation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeletePathToFolderOfScanStation.Name = "DeletePathToFolderOfScanStation";
            this.DeletePathToFolderOfScanStation.Size = new System.Drawing.Size(112, 35);
            this.DeletePathToFolderOfScanStation.TabIndex = 4;
            this.DeletePathToFolderOfScanStation.Text = "Delete";
            this.DeletePathToFolderOfScanStation.UseVisualStyleBackColor = true;
            this.DeletePathToFolderOfScanStation.Click += new System.EventHandler(this.DeletePathToFolderOfScanStation_Click);
            // 
            // AddPathToFolderOfScanStation
            // 
            this.AddPathToFolderOfScanStation.Location = new System.Drawing.Point(1042, 572);
            this.AddPathToFolderOfScanStation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddPathToFolderOfScanStation.Name = "AddPathToFolderOfScanStation";
            this.AddPathToFolderOfScanStation.Size = new System.Drawing.Size(112, 35);
            this.AddPathToFolderOfScanStation.TabIndex = 5;
            this.AddPathToFolderOfScanStation.Text = "Add";
            this.AddPathToFolderOfScanStation.UseVisualStyleBackColor = true;
            this.AddPathToFolderOfScanStation.Click += new System.EventHandler(this.AddPathToFolderOfScanStation_Click);
            // 
            // MoveToDecodingFolders
            // 
            this.MoveToDecodingFolders.Location = new System.Drawing.Point(947, 57);
            this.MoveToDecodingFolders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoveToDecodingFolders.Name = "MoveToDecodingFolders";
            this.MoveToDecodingFolders.Size = new System.Drawing.Size(207, 33);
            this.MoveToDecodingFolders.TabIndex = 6;
            this.MoveToDecodingFolders.Text = "Stop decoding handler";
            this.MoveToDecodingFolders.UseVisualStyleBackColor = true;
            this.MoveToDecodingFolders.Click += new System.EventHandler(this.MoveToDecodingFolders_Click);
            // 
            // MoveToScanFolders
            // 
            this.MoveToScanFolders.Location = new System.Drawing.Point(947, 100);
            this.MoveToScanFolders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoveToScanFolders.Name = "MoveToScanFolders";
            this.MoveToScanFolders.Size = new System.Drawing.Size(207, 33);
            this.MoveToScanFolders.TabIndex = 7;
            this.MoveToScanFolders.Text = "Stop scaning handler";
            this.MoveToScanFolders.UseVisualStyleBackColor = true;
            this.MoveToScanFolders.Click += new System.EventHandler(this.MoveToScanFolders_Click);
            // 
            // AddFilesToQueueFromServer
            // 
            this.AddFilesToQueueFromServer.Location = new System.Drawing.Point(947, 14);
            this.AddFilesToQueueFromServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddFilesToQueueFromServer.Name = "AddFilesToQueueFromServer";
            this.AddFilesToQueueFromServer.Size = new System.Drawing.Size(207, 33);
            this.AddFilesToQueueFromServer.TabIndex = 8;
            this.AddFilesToQueueFromServer.Text = "Stop acceptance handler";
            this.AddFilesToQueueFromServer.UseVisualStyleBackColor = true;
            this.AddFilesToQueueFromServer.Click += new System.EventHandler(this.AddFilesToQueueFromServer_Click);
            // 
            // SwitchAllProcess
            // 
            this.SwitchAllProcess.Location = new System.Drawing.Point(13, 14);
            this.SwitchAllProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SwitchAllProcess.Name = "SwitchAllProcess";
            this.SwitchAllProcess.Size = new System.Drawing.Size(207, 73);
            this.SwitchAllProcess.TabIndex = 9;
            this.SwitchAllProcess.Text = "Start All";
            this.SwitchAllProcess.UseVisualStyleBackColor = true;
            this.SwitchAllProcess.Visible = false;
            this.SwitchAllProcess.Click += new System.EventHandler(this.SwitchAllProcess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 619);
            this.Controls.Add(this.SwitchAllProcess);
            this.Controls.Add(this.AddFilesToQueueFromServer);
            this.Controls.Add(this.MoveToScanFolders);
            this.Controls.Add(this.MoveToDecodingFolders);
            this.Controls.Add(this.AddPathToFolderOfScanStation);
            this.Controls.Add(this.DeletePathToFolderOfScanStation);
            this.Controls.Add(this.AddPathToFolderOfDecodingStation);
            this.Controls.Add(this.DeletePathToFolderOfDecodingStation);
            this.Controls.Add(this.ListOfScanStations);
            this.Controls.Add(this.ListOfDecodingStations);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ListOfDecodingStations;
        private System.Windows.Forms.CheckedListBox ListOfScanStations;
        private System.Windows.Forms.Button DeletePathToFolderOfDecodingStation;
        private System.Windows.Forms.Button AddPathToFolderOfDecodingStation;
        private System.Windows.Forms.Button DeletePathToFolderOfScanStation;
        private System.Windows.Forms.Button AddPathToFolderOfScanStation;
        private System.Windows.Forms.Button MoveToDecodingFolders;
        private System.Windows.Forms.Button MoveToScanFolders;
        private System.Windows.Forms.Button AddFilesToQueueFromServer;
        private System.Windows.Forms.Button SwitchAllProcess;
    }
}

