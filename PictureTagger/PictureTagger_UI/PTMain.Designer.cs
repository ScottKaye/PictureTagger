namespace PictureTagger_UI
{
    partial class PTMain
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
            this.mainPTMenuStrip = new System.Windows.Forms.MenuStrip();
            this.filePTMainStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.importPTMainStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPTStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitPTMainStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsPTMainStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsPTMainStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpPTMainStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutPTMainStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPTStatusStrip = new System.Windows.Forms.StatusStrip();
            this.pictureLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialogImageImport = new System.Windows.Forms.OpenFileDialog();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.mainPTMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPTMenuStrip
            // 
            this.mainPTMenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.mainPTMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filePTMainStrip,
            this.toolsPTMainStrip,
            this.helpPTMainStrip});
            this.mainPTMenuStrip.Location = new System.Drawing.Point(7, 6);
            this.mainPTMenuStrip.Name = "mainPTMenuStrip";
            this.mainPTMenuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.mainPTMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainPTMenuStrip.Size = new System.Drawing.Size(631, 30);
            this.mainPTMenuStrip.TabIndex = 0;
            this.mainPTMenuStrip.Text = "Menu";
            // 
            // filePTMainStrip
            // 
            this.filePTMainStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPTMainStripItem,
            this.toolPTStripSeparator1,
            this.exitPTMainStripItem});
            this.filePTMainStrip.Name = "filePTMainStrip";
            this.filePTMainStrip.Size = new System.Drawing.Size(44, 24);
            this.filePTMainStrip.Text = "&File";
            // 
            // importPTMainStripItem
            // 
            this.importPTMainStripItem.Name = "importPTMainStripItem";
            this.importPTMainStripItem.Size = new System.Drawing.Size(129, 26);
            this.importPTMainStripItem.Text = "&Import";
            this.importPTMainStripItem.Click += new System.EventHandler(this.importPTMainStripItem_Click);
            // 
            // toolPTStripSeparator1
            // 
            this.toolPTStripSeparator1.Name = "toolPTStripSeparator1";
            this.toolPTStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // exitPTMainStripItem
            // 
            this.exitPTMainStripItem.Name = "exitPTMainStripItem";
            this.exitPTMainStripItem.Size = new System.Drawing.Size(129, 26);
            this.exitPTMainStripItem.Text = "E&xit";
            this.exitPTMainStripItem.Click += new System.EventHandler(this.exitPTMainStripItem_Click);
            // 
            // toolsPTMainStrip
            // 
            this.toolsPTMainStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsPTMainStripItem});
            this.toolsPTMainStrip.Name = "toolsPTMainStrip";
            this.toolsPTMainStrip.Size = new System.Drawing.Size(57, 24);
            this.toolsPTMainStrip.Text = "&Tools";
            // 
            // optionsPTMainStripItem
            // 
            this.optionsPTMainStripItem.Name = "optionsPTMainStripItem";
            this.optionsPTMainStripItem.Size = new System.Drawing.Size(136, 26);
            this.optionsPTMainStripItem.Text = "&Options";
            this.optionsPTMainStripItem.Click += new System.EventHandler(this.optionsPTMainStripItem_Click);
            // 
            // helpPTMainStrip
            // 
            this.helpPTMainStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutPTMainStripItem});
            this.helpPTMainStrip.Name = "helpPTMainStrip";
            this.helpPTMainStrip.Size = new System.Drawing.Size(53, 24);
            this.helpPTMainStrip.Text = "&Help";
            // 
            // aboutPTMainStripItem
            // 
            this.aboutPTMainStripItem.Name = "aboutPTMainStripItem";
            this.aboutPTMainStripItem.Size = new System.Drawing.Size(134, 26);
            this.aboutPTMainStripItem.Text = "&About...";
            // 
            // mainPTStatusStrip
            // 
            this.mainPTStatusStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.mainPTStatusStrip.Location = new System.Drawing.Point(7, 539);
            this.mainPTStatusStrip.Name = "mainPTStatusStrip";
            this.mainPTStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.mainPTStatusStrip.Size = new System.Drawing.Size(631, 22);
            this.mainPTStatusStrip.TabIndex = 1;
            this.mainPTStatusStrip.Text = "mainPTStatusStrip";
            // 
            // pictureLayout
            // 
            this.pictureLayout.AutoScroll = true;
            this.pictureLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pictureLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureLayout.Location = new System.Drawing.Point(7, 36);
            this.pictureLayout.Margin = new System.Windows.Forms.Padding(4);
            this.pictureLayout.Name = "pictureLayout";
            this.pictureLayout.Size = new System.Drawing.Size(631, 503);
            this.pictureLayout.TabIndex = 2;
            // 
            // openFileDialogImageImport
            // 
            this.openFileDialogImageImport.Filter = "Image files (*.jpg, *.jpeg, *.gif, *.png) | *.jpg; *.jpeg; *.gif; *.png";
            this.openFileDialogImageImport.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogImageImport_FileOk);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(412, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(226, 22);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(356, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(57, 17);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search:";
            // 
            // PTMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 567);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pictureLayout);
            this.Controls.Add(this.mainPTStatusStrip);
            this.Controls.Add(this.mainPTMenuStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PTMain";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Text = "Picture Tagger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PTMain_Closing);
            this.Load += new System.EventHandler(this.PTMain_Load);
            this.mainPTMenuStrip.ResumeLayout(false);
            this.mainPTMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainPTMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem filePTMainStrip;
        private System.Windows.Forms.ToolStripMenuItem exitPTMainStripItem;
        private System.Windows.Forms.ToolStripMenuItem toolsPTMainStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsPTMainStripItem;
        private System.Windows.Forms.ToolStripMenuItem helpPTMainStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutPTMainStripItem;
        private System.Windows.Forms.ToolStripMenuItem importPTMainStripItem;
        private System.Windows.Forms.ToolStripSeparator toolPTStripSeparator1;
        private System.Windows.Forms.StatusStrip mainPTStatusStrip;
        private System.Windows.Forms.FlowLayoutPanel pictureLayout;
		private System.Windows.Forms.OpenFileDialog openFileDialogImageImport;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
	}
}

