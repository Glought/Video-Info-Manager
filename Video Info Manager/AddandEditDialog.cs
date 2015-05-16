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