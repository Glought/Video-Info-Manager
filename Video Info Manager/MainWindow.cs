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
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Video_Info_Manager
{
    public partial class MainWindow : Form
    {
        public List<VideoInfo> fromJson;

        public MainWindow()
        {
            InitializeComponent();

            if (Properties.Settings.Default.FirstRun)
            {
                List<VideoInfo> dummyJson;
                WriteToJsonFile();
                dummyJson = new List<VideoInfo> { };

                VideoInfo newDummyData = new VideoInfo();
                newDummyData.Name = "This is Dummy Data Feel free to delete.";
                newDummyData.Description = "Dummy Descripion.";
                newDummyData.Tags = "Dummy Tags";

                dummyJson.Add(newDummyData);
                File.WriteAllText(@"VideoInfo.json", JsonConvert.SerializeObject(dummyJson, Formatting.Indented));
                rebindData();
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
            }

            fromJson = JsonConvert.DeserializeObject<List<VideoInfo>>(File.ReadAllText(@"VideoInfo.json"));

            videoTagsAndDescriptionListBox.DataSource = fromJson;
        }

        public void rebindData()
        {
            videoTagsAndDescriptionListBox.DataSource = null;
            videoTagsAndDescriptionListBox.DataSource = fromJson;
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
            VideoInfo videoDescription = (VideoInfo)videoTagsAndDescriptionListBox.SelectedItem;
            Clipboard.SetText(videoDescription.Description.ToString());
        }

        private void copyTagsButton_Click(object sender, EventArgs e)
        {
            VideoInfo videoTags = (VideoInfo)videoTagsAndDescriptionListBox.SelectedItem;
            Clipboard.SetText(videoTags.Tags.ToString());
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult areYouSure = MessageBox.Show("Are you want to delete the selected item?", "Are you sure?", buttons);

            if (areYouSure == System.Windows.Forms.DialogResult.Yes)
            {
                fromJson.Remove((VideoInfo)videoTagsAndDescriptionListBox.SelectedItem);
                WriteToJsonFile();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            VideoInfo videoEdit = (VideoInfo)videoTagsAndDescriptionListBox.SelectedItem;
            AddandEditDialog editDialog = new AddandEditDialog(this, videoEdit.Name.ToString(), videoEdit.Description.ToString(), videoEdit.Tags.ToString());
            if (editDialog.Created == false)
            {
                editDialog.ShowDialog();
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
        }
    }
}