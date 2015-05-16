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

using System;
using System.Windows.Forms;

namespace Video_Info_Manager
{
    public partial class AddandEditDialog : Form
    {
        public bool IsEdit;
        private MainWindow main;

        public AddandEditDialog(MainWindow mainForm)
        {
            InitializeComponent();
            this.main = mainForm;
            IsEdit = false;
            this.Text = "Add New Video Info Dialog";
        }

        public AddandEditDialog(MainWindow mainForm, string name, string description, string tags)
        {
            InitializeComponent();
            this.main = mainForm;

            this.Text = "Edit Existing Video Info Dialog";

            this.nameTextBox.Text = name;
            this.descriptionTextBox.Text = description;
            this.tagsTextBox.Text = tags;

            IsEdit = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                if (nameTextBox.Text != "" && descriptionTextBox.Text != "" && tagsTextBox.Text != "")
                {
                    VideoInfo editVideo = (VideoInfo)main.videoTagsAndDescriptionListBox.SelectedItem;
                    editVideo.Name = this.nameTextBox.Text;
                    editVideo.Description = this.descriptionTextBox.Text;
                    editVideo.Tags = this.tagsTextBox.Text;

                    main.WriteToJsonFile();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Empty Textboxes not allowed.", "Error");
                }
            }
            else
            {
                if (nameTextBox.Text != "" && descriptionTextBox.Text != "" && tagsTextBox.Text != "")
                {
                    VideoInfo newVideo = new VideoInfo();
                    newVideo.Name = this.nameTextBox.Text;
                    newVideo.Description = this.descriptionTextBox.Text;
                    newVideo.Tags = this.tagsTextBox.Text;

                    main.fromJson.Add(newVideo);
                    main.WriteToJsonFile();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Empty Textboxes not allowed.", "Error");
                }
            }
        }
    }
}