using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Generations_Launcher_Front.TextStore;

namespace Generations_Launcher_Front
{
	public class StatsConfiguration : UserControl
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(StatsConfiguration));
			this.AnalyticsGlobalCheck = new CheckBox();
			this.AnalyticsGroup1 = new GroupBox();
			this.checkBox1 = new CheckBox();
			this.Analytics_Label = new Label();
			this.pictureBox1 = new PictureBox();
			this.AnalyticsGroup1.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.AnalyticsGlobalCheck.Checked = true;
			this.AnalyticsGlobalCheck.CheckState = CheckState.Checked;
			this.AnalyticsGlobalCheck.Location = new Point(29, 252);
			this.AnalyticsGlobalCheck.Name = "AnalyticsGlobalCheck";
			this.AnalyticsGlobalCheck.Size = new Size(170, 24);
			this.AnalyticsGlobalCheck.TabIndex = 0;
			this.AnalyticsGlobalCheck.Text = "checkBox1";
			this.AnalyticsGlobalCheck.UseVisualStyleBackColor = true;
			this.AnalyticsGlobalCheck.CheckedChanged += this.CheckChange;
			this.AnalyticsGroup1.Controls.Add(this.checkBox1);
			this.AnalyticsGroup1.Location = new Point(37, 364);
			this.AnalyticsGroup1.Name = "AnalyticsGroup1";
			this.AnalyticsGroup1.Size = new Size(362, 82);
			this.AnalyticsGroup1.TabIndex = 1;
			this.AnalyticsGroup1.TabStop = false;
			this.AnalyticsGroup1.Text = "groupBox1";
			this.AnalyticsGroup1.Visible = false;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new Point(19, 41);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new Size(80, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "checkBox1";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += this.checkBox1_CheckedChanged;
			this.Analytics_Label.Location = new Point(26, 18);
			this.Analytics_Label.Name = "Analytics_Label";
			this.Analytics_Label.Size = new Size(373, 231);
			this.Analytics_Label.TabIndex = 2;
			this.Analytics_Label.Text = "label1";
			this.Analytics_Label.Click += this.Analytics_Label_Click;
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(846, 460);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.Analytics_Label);
			base.Controls.Add(this.AnalyticsGroup1);
			base.Controls.Add(this.AnalyticsGlobalCheck);
			base.Controls.Add(this.pictureBox1);
			base.Name = "StatsConfiguration";
			base.Size = new Size(846, 460);
			base.Load += this.StatsConfiguration_Load;
			this.AnalyticsGroup1.ResumeLayout(false);
			this.AnalyticsGroup1.PerformLayout();
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		public StatsConfiguration()
		{
			this.InitializeComponent();
		}

		private void StatsConfiguration_Load(object sender, EventArgs e)
		{
			this.AnalyticsGroup1.Enabled = false;
			this.DressText();
			this.AnalyticsGlobalCheck.Checked = GlobalDefs.AnalyticsEnabled;
		}

		private void DressText()
		{
			this.AnalyticsGlobalCheck.Text = LocalizedText.AnalyticsGlobalCheck;
			this.Analytics_Label.Text = LocalizedText.Analytics_Label;
		}

		private void CheckChange(object sender, EventArgs e)
		{
			GlobalDefs.AnalyticsEnabled = this.AnalyticsGlobalCheck.Checked;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void Analytics_Label_Click(object sender, EventArgs e)
		{
		}

		private IContainer components;

		private CheckBox AnalyticsGlobalCheck;

		private GroupBox AnalyticsGroup1;

		private CheckBox checkBox1;

		private Label Analytics_Label;

		private PictureBox pictureBox1;
	}
}
