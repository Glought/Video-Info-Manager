namespace Video_Info_Manager
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.videoTagsAndDescriptionListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copyDescriptionButton = new System.Windows.Forms.Button();
            this.copyTagsButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoTagsAndDescriptionListBox
            // 
            this.videoTagsAndDescriptionListBox.FormattingEnabled = true;
            this.videoTagsAndDescriptionListBox.Location = new System.Drawing.Point(1, 3);
            this.videoTagsAndDescriptionListBox.Name = "videoTagsAndDescriptionListBox";
            this.videoTagsAndDescriptionListBox.Size = new System.Drawing.Size(438, 368);
            this.videoTagsAndDescriptionListBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 16);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.toolTip1.SetToolTip(this.addButton, "Click to open the \"Add New Video Info Dialog\"");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.copyDescriptionButton);
            this.groupBox1.Controls.Add(this.copyTagsButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Location = new System.Drawing.Point(2, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 45);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // copyDescriptionButton
            // 
            this.copyDescriptionButton.Location = new System.Drawing.Point(330, 16);
            this.copyDescriptionButton.Name = "copyDescriptionButton";
            this.copyDescriptionButton.Size = new System.Drawing.Size(99, 23);
            this.copyDescriptionButton.TabIndex = 2;
            this.copyDescriptionButton.Text = "Copy Description";
            this.toolTip1.SetToolTip(this.copyDescriptionButton, "Copies the Selected Item\'s description to the clipboard");
            this.copyDescriptionButton.UseVisualStyleBackColor = true;
            this.copyDescriptionButton.Click += new System.EventHandler(this.copyDescriptionButton_Click);
            // 
            // copyTagsButton
            // 
            this.copyTagsButton.Location = new System.Drawing.Point(249, 16);
            this.copyTagsButton.Name = "copyTagsButton";
            this.copyTagsButton.Size = new System.Drawing.Size(75, 23);
            this.copyTagsButton.TabIndex = 2;
            this.copyTagsButton.Text = "Copy Tags";
            this.toolTip1.SetToolTip(this.copyTagsButton, "Copies the Selected Item\'s Tags to the clipboard");
            this.copyTagsButton.UseVisualStyleBackColor = true;
            this.copyTagsButton.Click += new System.EventHandler(this.copyTagsButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(168, 16);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.toolTip1.SetToolTip(this.deleteButton, "Deletes the Selected Item.");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(87, 16);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.toolTip1.SetToolTip(this.editButton, "Click to open the \"Edit Existing Video Info Dialog\"");
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 426);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.videoTagsAndDescriptionListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Video Info Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button copyDescriptionButton;
        private System.Windows.Forms.Button copyTagsButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        public System.Windows.Forms.ListBox videoTagsAndDescriptionListBox;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}

