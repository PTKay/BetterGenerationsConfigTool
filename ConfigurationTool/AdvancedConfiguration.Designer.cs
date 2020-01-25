using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Generations_Launcher_Front.TextStore;

namespace Generations_Launcher_Front
{
	public class AdvancedConfiguration : UserControl
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AdvancedConfiguration));
			this.pictureBox1 = new PictureBox();
			this.EnableCachingGroup = new GroupBox();
			this.EnableCachingCheck = new CheckBox();
			this.CacheSizeScroll = new TrackBar();
			this.CacheBlockSizeScroll = new TrackBar();
			this.CacheSizeScrollAmount = new Label();
			this.CacheBlockSizeScrollAmount = new Label();
			this.CacheSizeScroll_Label = new Label();
			this.CacheBlockSizeScroll_Label = new Label();
			this.StreamingRate_Label = new Label();
			this.StreamingRateCombo = new ComboBox();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.EnableCachingGroup.SuspendLayout();
			((ISupportInitialize)this.CacheSizeScroll).BeginInit();
			((ISupportInitialize)this.CacheBlockSizeScroll).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(846, 460);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.EnableCachingGroup.Controls.Add(this.StreamingRateCombo);
			this.EnableCachingGroup.Controls.Add(this.StreamingRate_Label);
			this.EnableCachingGroup.Controls.Add(this.CacheBlockSizeScroll_Label);
			this.EnableCachingGroup.Controls.Add(this.CacheSizeScroll_Label);
			this.EnableCachingGroup.Controls.Add(this.CacheBlockSizeScrollAmount);
			this.EnableCachingGroup.Controls.Add(this.CacheSizeScrollAmount);
			this.EnableCachingGroup.Controls.Add(this.CacheBlockSizeScroll);
			this.EnableCachingGroup.Controls.Add(this.CacheSizeScroll);
			this.EnableCachingGroup.Location = new Point(40, 38);
			this.EnableCachingGroup.Name = "EnableCachingGroup";
			this.EnableCachingGroup.Size = new Size(480, 287);
			this.EnableCachingGroup.TabIndex = 1;
			this.EnableCachingGroup.TabStop = false;
			this.EnableCachingGroup.Text = "groupBox1";
			this.EnableCachingCheck.AutoSize = true;
			this.EnableCachingCheck.Location = new Point(40, 15);
			this.EnableCachingCheck.Name = "EnableCachingCheck";
			this.EnableCachingCheck.Size = new Size(80, 17);
			this.EnableCachingCheck.TabIndex = 2;
			this.EnableCachingCheck.Text = "checkBox1";
			this.EnableCachingCheck.UseVisualStyleBackColor = true;
			this.EnableCachingCheck.CheckedChanged += this.EnableCachingCheck_CheckedChanged;
			this.CacheSizeScroll.LargeChange = 50;
			this.CacheSizeScroll.Location = new Point(16, 51);
			this.CacheSizeScroll.Maximum = 800;
			this.CacheSizeScroll.Minimum = 100;
			this.CacheSizeScroll.Name = "CacheSizeScroll";
			this.CacheSizeScroll.Size = new Size(355, 45);
			this.CacheSizeScroll.SmallChange = 50;
			this.CacheSizeScroll.TabIndex = 0;
			this.CacheSizeScroll.TickFrequency = 50;
			this.CacheSizeScroll.Value = 100;
			this.CacheBlockSizeScroll.LargeChange = 50;
			this.CacheBlockSizeScroll.Location = new Point(16, 122);
			this.CacheBlockSizeScroll.Maximum = 800;
			this.CacheBlockSizeScroll.Minimum = 100;
			this.CacheBlockSizeScroll.Name = "CacheBlockSizeScroll";
			this.CacheBlockSizeScroll.Size = new Size(355, 45);
			this.CacheBlockSizeScroll.SmallChange = 50;
			this.CacheBlockSizeScroll.TabIndex = 1;
			this.CacheBlockSizeScroll.TickFrequency = 50;
			this.CacheBlockSizeScroll.Value = 100;
			this.CacheSizeScrollAmount.Location = new Point(372, 51);
			this.CacheSizeScrollAmount.Name = "CacheSizeScrollAmount";
			this.CacheSizeScrollAmount.Size = new Size(100, 45);
			this.CacheSizeScrollAmount.TabIndex = 2;
			this.CacheSizeScrollAmount.Text = "label1";
			this.CacheSizeScrollAmount.TextAlign = ContentAlignment.MiddleCenter;
			this.CacheBlockSizeScrollAmount.Location = new Point(372, 122);
			this.CacheBlockSizeScrollAmount.Name = "CacheBlockSizeScrollAmount";
			this.CacheBlockSizeScrollAmount.Size = new Size(100, 45);
			this.CacheBlockSizeScrollAmount.TabIndex = 3;
			this.CacheBlockSizeScrollAmount.Text = "label2";
			this.CacheBlockSizeScrollAmount.TextAlign = ContentAlignment.MiddleCenter;
			this.CacheSizeScroll_Label.Location = new Point(13, 21);
			this.CacheSizeScroll_Label.Name = "CacheSizeScroll_Label";
			this.CacheSizeScroll_Label.Size = new Size(358, 27);
			this.CacheSizeScroll_Label.TabIndex = 4;
			this.CacheSizeScroll_Label.Text = "label3";
			this.CacheSizeScroll_Label.TextAlign = ContentAlignment.MiddleLeft;
			this.CacheBlockSizeScroll_Label.Location = new Point(13, 92);
			this.CacheBlockSizeScroll_Label.Name = "CacheBlockSizeScroll_Label";
			this.CacheBlockSizeScroll_Label.Size = new Size(358, 27);
			this.CacheBlockSizeScroll_Label.TabIndex = 5;
			this.CacheBlockSizeScroll_Label.Text = "label4";
			this.CacheBlockSizeScroll_Label.TextAlign = ContentAlignment.MiddleLeft;
			this.StreamingRate_Label.Location = new Point(13, 168);
			this.StreamingRate_Label.Name = "StreamingRate_Label";
			this.StreamingRate_Label.Size = new Size(358, 27);
			this.StreamingRate_Label.TabIndex = 8;
			this.StreamingRate_Label.Text = "label4";
			this.StreamingRate_Label.TextAlign = ContentAlignment.MiddleLeft;
			this.StreamingRateCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StreamingRateCombo.FormattingEnabled = true;
			this.StreamingRateCombo.Location = new Point(16, 199);
			this.StreamingRateCombo.Name = "StreamingRateCombo";
			this.StreamingRateCombo.Size = new Size(355, 21);
			this.StreamingRateCombo.TabIndex = 9;
			this.StreamingRateCombo.SelectedIndexChanged += this.StreamingRateCombo_SelectedIndexChanged;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.EnableCachingCheck);
			base.Controls.Add(this.EnableCachingGroup);
			base.Controls.Add(this.pictureBox1);
			base.Name = "AdvancedConfiguration";
			base.Size = new Size(846, 460);
			base.Load += this.AdvancedConfiguration_Load;
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.EnableCachingGroup.ResumeLayout(false);
			this.EnableCachingGroup.PerformLayout();
			((ISupportInitialize)this.CacheSizeScroll).EndInit();
			((ISupportInitialize)this.CacheBlockSizeScroll).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public AdvancedConfiguration()
		{
			this.InitializeComponent();
			this.CacheSizeScroll.Scroll += this.CacheSizeScroll_Scroll;
			this.CacheBlockSizeScroll.Scroll += this.CacheBlockSizeScroll_Scroll;
		}

		private void AdvancedConfiguration_Load(object sender, EventArgs e)
		{
			this.DressText();
			this.EnableCachingGroup.Enabled = this.EnableCachingCheck.Checked;
		}

		private void DressText()
		{
			this.StreamingRateCombo.Items.Clear();
			this.StreamingRateCombo.Items.Add(LocalizedText.Low_Combo);
			this.StreamingRateCombo.Items.Add(LocalizedText.Medium_Combo);
			this.StreamingRateCombo.Items.Add(LocalizedText.High_Combo);
			this.StreamingRate_Label.Text = LocalizedText.StreamingRate;
			this.EnableCachingGroup.Text = LocalizedText.AdvancedLevelCachingOptions;
			this.EnableCachingCheck.Text = LocalizedText.EnableAdvancedLevelCaching;
			this.CacheBlockSizeScroll_Label.Text = LocalizedText.CacheBlockSize;
			this.CacheSizeScroll_Label.Text = LocalizedText.CacheSize;
			if (!GlobalDefs.bFirstRun)
			{
				if (GlobalDefs.CacheEnabled == 1)
				{
					this.EnableCachingCheck.Checked = true;
				}
				else
				{
					this.EnableCachingCheck.Checked = false;
				}
				this.CacheSizeScroll.Value = GlobalDefs.CacheSize;
				this.CacheBlockSizeScroll.Value = GlobalDefs.CacheBlockSize;
				this.StreamingRateCombo.SelectedIndex = GlobalDefs.StreamingRate;
			}
			else
			{
				this.StreamingRateCombo.SelectedIndex = 0;
			}
			this.CacheSizeScrollAmount.Text = this.CacheSizeScroll.Value.ToString() + " MB";
			this.CacheBlockSizeScrollAmount.Text = this.CacheBlockSizeScroll.Value.ToString() + " MB";
		}

		private void CacheSizeScroll_Scroll(object sender, EventArgs e)
		{
			this.CacheSizeScrollAmount.Text = this.CacheSizeScroll.Value.ToString() + " MB";
			GlobalDefs.CacheSize = this.CacheSizeScroll.Value;
		}

		private void CacheBlockSizeScroll_Scroll(object sender, EventArgs e)
		{
			this.CacheBlockSizeScrollAmount.Text = this.CacheBlockSizeScroll.Value.ToString() + " MB";
			GlobalDefs.CacheBlockSize = this.CacheBlockSizeScroll.Value;
		}

		private void EnableCachingCheck_CheckedChanged(object sender, EventArgs e)
		{
			this.EnableCachingGroup.Enabled = this.EnableCachingCheck.Checked;
			GlobalDefs.CacheEnabled = (this.EnableCachingCheck.Checked ? 1 : 0);
		}

		private void StreamingRateCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalDefs.StreamingRate = this.StreamingRateCombo.SelectedIndex;
		}

		private IContainer components;

		private PictureBox pictureBox1;

		private GroupBox EnableCachingGroup;

		private CheckBox EnableCachingCheck;

		private TrackBar CacheSizeScroll;

		private TrackBar CacheBlockSizeScroll;

		private Label CacheBlockSizeScroll_Label;

		private Label CacheSizeScroll_Label;

		private Label CacheBlockSizeScrollAmount;

		private Label CacheSizeScrollAmount;

		private Label StreamingRate_Label;

		private ComboBox StreamingRateCombo;
	}
}
