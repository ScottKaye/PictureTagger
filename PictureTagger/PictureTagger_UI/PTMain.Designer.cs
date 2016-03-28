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
			this.pictureFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.mainPTMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPTMenuStrip
			// 
			this.mainPTMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filePTMainStrip,
            this.toolsPTMainStrip,
            this.helpPTMainStrip});
			this.mainPTMenuStrip.Location = new System.Drawing.Point(5, 5);
			this.mainPTMenuStrip.Name = "mainPTMenuStrip";
			this.mainPTMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.mainPTMenuStrip.Size = new System.Drawing.Size(474, 24);
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
			this.filePTMainStrip.Size = new System.Drawing.Size(37, 20);
			this.filePTMainStrip.Text = "&File";
			// 
			// importPTMainStripItem
			// 
			this.importPTMainStripItem.Name = "importPTMainStripItem";
			this.importPTMainStripItem.Size = new System.Drawing.Size(110, 22);
			this.importPTMainStripItem.Text = "&Import";
			this.importPTMainStripItem.Click += new System.EventHandler(this.importPTMainStripItem_Click);
			// 
			// toolPTStripSeparator1
			// 
			this.toolPTStripSeparator1.Name = "toolPTStripSeparator1";
			this.toolPTStripSeparator1.Size = new System.Drawing.Size(107, 6);
			// 
			// exitPTMainStripItem
			// 
			this.exitPTMainStripItem.Name = "exitPTMainStripItem";
			this.exitPTMainStripItem.Size = new System.Drawing.Size(110, 22);
			this.exitPTMainStripItem.Text = "E&xit";
			this.exitPTMainStripItem.Click += new System.EventHandler(this.exitPTMainStripItem_Click);
			// 
			// toolsPTMainStrip
			// 
			this.toolsPTMainStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsPTMainStripItem});
			this.toolsPTMainStrip.Name = "toolsPTMainStrip";
			this.toolsPTMainStrip.Size = new System.Drawing.Size(47, 20);
			this.toolsPTMainStrip.Text = "&Tools";
			// 
			// optionsPTMainStripItem
			// 
			this.optionsPTMainStripItem.Name = "optionsPTMainStripItem";
			this.optionsPTMainStripItem.Size = new System.Drawing.Size(116, 22);
			this.optionsPTMainStripItem.Text = "&Options";
			this.optionsPTMainStripItem.Click += new System.EventHandler(this.optionsPTMainStripItem_Click);
			// 
			// helpPTMainStrip
			// 
			this.helpPTMainStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutPTMainStripItem});
			this.helpPTMainStrip.Name = "helpPTMainStrip";
			this.helpPTMainStrip.Size = new System.Drawing.Size(44, 20);
			this.helpPTMainStrip.Text = "&Help";
			// 
			// aboutPTMainStripItem
			// 
			this.aboutPTMainStripItem.Name = "aboutPTMainStripItem";
			this.aboutPTMainStripItem.Size = new System.Drawing.Size(116, 22);
			this.aboutPTMainStripItem.Text = "&About...";
			// 
			// mainPTStatusStrip
			// 
			this.mainPTStatusStrip.Location = new System.Drawing.Point(5, 434);
			this.mainPTStatusStrip.Name = "mainPTStatusStrip";
			this.mainPTStatusStrip.Size = new System.Drawing.Size(474, 22);
			this.mainPTStatusStrip.TabIndex = 1;
			this.mainPTStatusStrip.Text = "mainPTStatusStrip";
			// 
			// pictureFlowLayout
			// 
			this.pictureFlowLayout.AutoScroll = true;
			this.pictureFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pictureFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureFlowLayout.Location = new System.Drawing.Point(5, 29);
			this.pictureFlowLayout.Name = "pictureFlowLayout";
			this.pictureFlowLayout.Size = new System.Drawing.Size(474, 405);
			this.pictureFlowLayout.TabIndex = 2;
			// 
			// PTMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 461);
			this.Controls.Add(this.pictureFlowLayout);
			this.Controls.Add(this.mainPTStatusStrip);
			this.Controls.Add(this.mainPTMenuStrip);
			this.Name = "PTMain";
			this.Padding = new System.Windows.Forms.Padding(5);
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
        private System.Windows.Forms.FlowLayoutPanel pictureFlowLayout;
    }
}

