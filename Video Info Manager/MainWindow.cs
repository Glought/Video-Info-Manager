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
            fromJson.Remove((VideoInfo)videoTagsAndDescriptionListBox.SelectedItem);
            WriteToJsonFile();
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
            WriteToJsonFile();
            Properties.Settings.Default.Save();
        }
    }
}