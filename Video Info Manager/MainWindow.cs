/*Video Info Manager for easy storage and copying of Video Descriptions and Tags.
  Copyright 2015 ThoughtsOfGlought

  This file is part of Video Info Manager.
  Video Info Manager is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Video Info Manager is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with Video Info Manager.  If not, see <http://www.gnu.org/licenses/>.
*/

using Newtonsoft.Json;
using SimpleUpdateNotifierLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Video_Info_Manager
{
    public partial class MainWindow : Form
    {
        public List<VideoInfo> fromJson { get; private set; }

        private string changeLogUrl = "http://raw.githubusercontent.com/Glought/Video-Info-Manager/master/Video%20Info%20Manager/CHANGELOG.txt";
        private string DownloadSiteUrl = "http://github.com/Glought/Video-Info-Manager/releases";
        private string installedVersion = "1.0.3.0";
        private string projectUpdateXml = "http://raw.githubusercontent.com/Glought/Video-Info-Manager/master/Video%20Info%20Manager/VideoInfoManager.xml";

        public MainWindow()
        {
            InitializeComponent();
            // It first tries to read from the file but its not found it creates it with dummy data.
            // then reads from the file then sets the list box's datasource

            try
            {
                fromJson = JsonConvert.DeserializeObject<List<VideoInfo>>(File.ReadAllText(@"VideoInfo.json"));
                videoTagsAndDescriptionListBox.DataSource = fromJson;
            }
            catch (FileNotFoundException)
            {
                WriteDummyData();
                fromJson = JsonConvert.DeserializeObject<List<VideoInfo>>(File.ReadAllText(@"VideoInfo.json"));
                videoTagsAndDescriptionListBox.DataSource = fromJson;
            }
        }

        public void rebindData()
        {
            videoTagsAndDescriptionListBox.DataSource = null;
            videoTagsAndDescriptionListBox.DataSource = fromJson;
        }

        public void WriteDummyData()
        {
            string dummy = @"[
                {
                'Description': 'Dummy Descripion.',
                'Name': 'This is Dummy Data Feel free to delete.',
                'Tags': 'Dummy Tags'
                }
               ]";

            File.WriteAllText(@"VideoInfo.json", dummy);

            rebindData();
        }

        public void WriteToJsonFile()
        {
            File.WriteAllText(@"VideoInfo.json", JsonConvert.SerializeObject(fromJson, Formatting.Indented));
            rebindData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddandEditDialog addDialog = new AddandEditDialog(this);
            if (addDialog.Created == false)
            {
                addDialog.ShowDialog();
            }
        }

        private void copyDescriptionButton_Click(object sender, EventArgs e)
        {
            if (videoTagsAndDescriptionListBox.SelectedItem != null)
            {
                VideoInfo videoDescription = (VideoInfo)videoTagsAndDescriptionListBox.SelectedItem;
                Clipboard.SetText(videoDescription.Description.ToString());
            }
        }

        private void copyTagsButton_Click(object sender, EventArgs e)
        {
            if (videoTagsAndDescriptionListBox.SelectedItem != null)
            {
                VideoInfo videoTags = (VideoInfo)videoTagsAndDescriptionListBox.SelectedItem;
                Clipboard.SetText(videoTags.Tags.ToString());
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (videoTagsAndDescriptionListBox.SelectedItem != null)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult areYouSure = MessageBox.Show("Are you want to delete the selected item?", "Are you sure?", buttons);

                if (areYouSure == System.Windows.Forms.DialogResult.Yes)
                {
                    fromJson.Remove((VideoInfo)videoTagsAndDescriptionListBox.SelectedItem);
                    WriteToJsonFile();
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            VideoInfo videoEdit = (VideoInfo)videoTagsAndDescriptionListBox.SelectedItem;

            if (videoTagsAndDescriptionListBox.SelectedItem != null)
            {
                AddandEditDialog editDialog = new AddandEditDialog(this, videoEdit.Name.ToString(), videoEdit.Description.ToString(), videoEdit.Tags.ToString());
                if (editDialog.Created == false)
                {
                    editDialog.ShowDialog();
                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Location = Location;

            WriteToJsonFile();
            Properties.Settings.Default.Save();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Location = Properties.Settings.Default.Location;

            SimpleUpdateNotifier updateCheck = new SimpleUpdateNotifier(projectUpdateXml, changeLogUrl, DownloadSiteUrl, installedVersion);

            Thread oUpdateNotifier = new Thread(new ThreadStart(updateCheck.StartUpdateCheck));

            oUpdateNotifier.Start();

            while (!oUpdateNotifier.IsAlive) ;

            Thread.Sleep(1000);
        }
    }
}