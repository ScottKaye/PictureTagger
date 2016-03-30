namespace PictureTagger_UI
{
	partial class PTTag
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
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.pictureKeyword = new System.Windows.Forms.TextBox();
			this.removeKeyword = new System.Windows.Forms.Button();
			this.addKeyword = new System.Windows.Forms.Button();
			this.pictureKeywrods = new System.Windows.Forms.ListBox();
			this.lblPictureKeywords = new System.Windows.Forms.Label();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 4;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel.Controls.Add(this.pictureKeyword, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.removeKeyword, 3, 1);
			this.tableLayoutPanel.Controls.Add(this.addKeyword, 2, 1);
			this.tableLayoutPanel.Controls.Add(this.pictureKeywrods, 3, 0);
			this.tableLayoutPanel.Controls.Add(this.lblPictureKeywords, 0, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 2;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(484, 461);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// pictureKeyword
			// 
			this.tableLayoutPanel.SetColumnSpan(this.pictureKeyword, 2);
			this.pictureKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureKeyword.Location = new System.Drawing.Point(3, 434);
			this.pictureKeyword.MaxLength = 12;
			this.pictureKeyword.Name = "pictureKeyword";
			this.pictureKeyword.Size = new System.Drawing.Size(236, 20);
			this.pictureKeyword.TabIndex = 1;
			this.pictureKeyword.TextChanged += new System.EventHandler(this.Keyword_TextChanged);
			// 
			// removeKeyword
			// 
			this.removeKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
			this.removeKeyword.Location = new System.Drawing.Point(366, 434);
			this.removeKeyword.Name = "removeKeyword";
			this.removeKeyword.Size = new System.Drawing.Size(115, 24);
			this.removeKeyword.TabIndex = 3;
			this.removeKeyword.Text = "Delete";
			this.removeKeyword.UseVisualStyleBackColor = true;
			this.removeKeyword.Click += new System.EventHandler(this.Delete_Click);
			// 
			// addKeyword
			// 
			this.addKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
			this.addKeyword.Enabled = false;
			this.addKeyword.Location = new System.Drawing.Point(245, 434);
			this.addKeyword.Name = "addKeyword";
			this.addKeyword.Size = new System.Drawing.Size(115, 24);
			this.addKeyword.TabIndex = 2;
			this.addKeyword.Text = "Insert";
			this.addKeyword.UseVisualStyleBackColor = true;
			this.addKeyword.Click += new System.EventHandler(this.Insert_Click);
			// 
			// pictureKeywrods
			// 
			this.tableLayoutPanel.SetColumnSpan(this.pictureKeywrods, 4);
			this.pictureKeywrods.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureKeywrods.FormattingEnabled = true;
			this.pictureKeywrods.Location = new System.Drawing.Point(3, 16);
			this.pictureKeywrods.Name = "pictureKeywrods";
			this.pictureKeywrods.Size = new System.Drawing.Size(478, 412);
			this.pictureKeywrods.Sorted = true;
			this.pictureKeywrods.TabIndex = 4;
			this.pictureKeywrods.SelectedIndexChanged += new System.EventHandler(this.Keywords_SelectedIndexChanged);
			// 
			// lblPictureKeywords
			// 
			this.lblPictureKeywords.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.lblPictureKeywords, 4);
			this.lblPictureKeywords.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblPictureKeywords.Location = new System.Drawing.Point(3, 0);
			this.lblPictureKeywords.Name = "lblPictureKeywords";
			this.lblPictureKeywords.Size = new System.Drawing.Size(478, 13);
			this.lblPictureKeywords.TabIndex = 5;
			this.lblPictureKeywords.Text = "Keywords";
			// 
			// PTTag
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 461);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PTTag";
			this.Text = "Image Tags";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PTTag_Closing);
			this.Load += new System.EventHandler(this.PTTag_Load);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.TextBox pictureKeyword;
		private System.Windows.Forms.Button removeKeyword;
		private System.Windows.Forms.Button addKeyword;
		private System.Windows.Forms.ListBox pictureKeywrods;
		private System.Windows.Forms.Label lblPictureKeywords;
	}
}