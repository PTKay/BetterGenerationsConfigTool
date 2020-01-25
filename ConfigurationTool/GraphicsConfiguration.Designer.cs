using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Generations_Launcher_Front.TextStore;

namespace Generations_Launcher_Front
{
	public class GraphicsConfiguration : UserControl
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GraphicsConfiguration));
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.Adapter_Combo = new ComboBox();
			this.Resolution_Combo = new ComboBox();
			this.AA_Combo = new ComboBox();
			this.Adapter_label = new Label();
			this.Res_label = new Label();
			this.AA_label = new Label();
			this.NoAdapterWarning_label = new Label();
			this.DisplayMode_Label = new Label();
			this.DispMode_combo = new ComboBox();
			this.Shadow_Combo = new ComboBox();
			this.Reflection_Combo = new ComboBox();
			this.Shadow_Label = new Label();
			this.Reflection_Label = new Label();
			this.pictureBox1 = new PictureBox();
			this.Vsync_combo = new ComboBox();
			this.vsync_label = new Label();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.Adapter_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Adapter_Combo.FormattingEnabled = true;
			this.Adapter_Combo.Location = new Point(20, 48);
			this.Adapter_Combo.Name = "Adapter_Combo";
			this.Adapter_Combo.Size = new Size(300, 21);
			this.Adapter_Combo.TabIndex = 1;
			this.Adapter_Combo.SelectedIndexChanged += this.Adapter_Combo_SelectedIndexChanged;
			this.Resolution_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Resolution_Combo.FormattingEnabled = true;
			this.Resolution_Combo.Location = new Point(20, 98);
			this.Resolution_Combo.Name = "Resolution_Combo";
			this.Resolution_Combo.Size = new Size(300, 21);
			this.Resolution_Combo.TabIndex = 2;
			this.Resolution_Combo.SelectedIndexChanged += this.Resolution_Combo_SelectedIndexChanged;
			this.AA_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.AA_Combo.FormattingEnabled = true;
			this.AA_Combo.Location = new Point(20, 148);
			this.AA_Combo.Name = "AA_Combo";
			this.AA_Combo.Size = new Size(300, 21);
			this.AA_Combo.TabIndex = 3;
			this.AA_Combo.SelectedIndexChanged += this.AA_Combo_SelectedIndexChanged;
			this.Adapter_label.AutoSize = true;
			this.Adapter_label.Location = new Point(20, 32);
			this.Adapter_label.Name = "Adapter_label";
			this.Adapter_label.Size = new Size(89, 13);
			this.Adapter_label.TabIndex = 4;
			this.Res_label.AutoSize = true;
			this.Res_label.Location = new Point(20, 82);
			this.Res_label.Name = "Res_label";
			this.Res_label.Size = new Size(57, 13);
			this.Res_label.TabIndex = 5;
			this.AA_label.AutoSize = true;
			this.AA_label.Location = new Point(20, 132);
			this.AA_label.Name = "AA_label";
			this.AA_label.Size = new Size(61, 13);
			this.AA_label.TabIndex = 6;
			this.NoAdapterWarning_label.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.NoAdapterWarning_label.ForeColor = Color.DarkRed;
			this.NoAdapterWarning_label.Location = new Point(370, 131);
			this.NoAdapterWarning_label.Name = "NoAdapterWarning_label";
			this.NoAdapterWarning_label.Size = new Size(237, 101);
			this.NoAdapterWarning_label.TabIndex = 9;
			this.NoAdapterWarning_label.TextAlign = ContentAlignment.MiddleCenter;
			this.NoAdapterWarning_label.Visible = false;
			this.DisplayMode_Label.AutoSize = true;
			this.DisplayMode_Label.Location = new Point(20, 182);
			this.DisplayMode_Label.Name = "DisplayMode_Label";
			this.DisplayMode_Label.Size = new Size(71, 13);
			this.DisplayMode_Label.TabIndex = 10;
			this.DispMode_combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DispMode_combo.FormattingEnabled = true;
			this.DispMode_combo.Location = new Point(20, 198);
			this.DispMode_combo.Name = "DispMode_combo";
			this.DispMode_combo.Size = new Size(300, 21);
			this.DispMode_combo.TabIndex = 11;
			this.DispMode_combo.SelectedIndexChanged += this.DispMode_combo_SelectedIndexChanged;
			this.Shadow_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Shadow_Combo.FormattingEnabled = true;
			this.Shadow_Combo.Location = new Point(20, 248);
			this.Shadow_Combo.Name = "Shadow_Combo";
			this.Shadow_Combo.Size = new Size(300, 21);
			this.Shadow_Combo.TabIndex = 14;
			this.Shadow_Combo.SelectedIndexChanged += this.Shadow_Combo_SelectedIndexChanged;
			this.Reflection_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Reflection_Combo.FormattingEnabled = true;
			this.Reflection_Combo.Location = new Point(20, 298);
			this.Reflection_Combo.Name = "Reflection_Combo";
			this.Reflection_Combo.Size = new Size(300, 21);
			this.Reflection_Combo.TabIndex = 15;
			this.Reflection_Combo.SelectedIndexChanged += this.Reflection_Combo_SelectedIndexChanged;
			this.Shadow_Label.Location = new Point(20, 232);
			this.Shadow_Label.Name = "Shadow_Label";
			this.Shadow_Label.Size = new Size(128, 15);
			this.Shadow_Label.TabIndex = 16;
			this.Reflection_Label.Location = new Point(20, 282);
			this.Reflection_Label.Name = "Reflection_Label";
			this.Reflection_Label.Size = new Size(144, 15);
			this.Reflection_Label.TabIndex = 17;
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(846, 460);
			this.pictureBox1.TabIndex = 18;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.Vsync_combo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Vsync_combo.FormattingEnabled = true;
			this.Vsync_combo.Location = new Point(20, 348);
			this.Vsync_combo.Name = "Vsync_combo";
			this.Vsync_combo.Size = new Size(300, 21);
			this.Vsync_combo.TabIndex = 19;
			this.Vsync_combo.SelectedIndexChanged += this.Vsync_combo_SelectedIndexChanged;
			this.vsync_label.AutoSize = true;
			this.vsync_label.Location = new Point(20, 332);
			this.vsync_label.Name = "vsync_label";
			this.vsync_label.Size = new Size(63, 13);
			this.vsync_label.TabIndex = 20;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.vsync_label);
			base.Controls.Add(this.Vsync_combo);
			base.Controls.Add(this.Reflection_Label);
			base.Controls.Add(this.Shadow_Label);
			base.Controls.Add(this.Reflection_Combo);
			base.Controls.Add(this.Shadow_Combo);
			base.Controls.Add(this.DispMode_combo);
			base.Controls.Add(this.DisplayMode_Label);
			base.Controls.Add(this.NoAdapterWarning_label);
			base.Controls.Add(this.AA_label);
			base.Controls.Add(this.Res_label);
			base.Controls.Add(this.Adapter_label);
			base.Controls.Add(this.AA_Combo);
			base.Controls.Add(this.Resolution_Combo);
			base.Controls.Add(this.Adapter_Combo);
			base.Controls.Add(this.pictureBox1);
			base.Name = "GraphicsConfiguration";
			base.Size = new Size(846, 460);
			base.Load += this.GraphicsConfiguration_Load;
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public GraphicsConfiguration()
		{
			this.InitializeComponent();
			this.mGraphicsAdapterList = new List<AdapterInfo>();
			this.mDisplayModesList = new List<DisplayModes>();
			this.mAATypesList = new List<AATypes>();
			this.mShadowList = new List<LowHigh>();
			this.mReflectionList = new List<LowHigh>();
			this.mVsyncList = new List<OnOff>();
		}

		private void GraphicsConfiguration_Load(object sender, EventArgs e)
		{
			int num = DllExterns._GetNumberOfAdapters();
			if (num > 0)
			{
				this.Adapter_Combo.Enabled = true;
				this.Resolution_Combo.Enabled = true;
				this.AA_Combo.Enabled = true;
				this.Vsync_combo.Enabled = true;
				this.NoAdapterWarning_label.Visible = false;
				GlobalDefs.OutputAdapter.ValidAdapter = true;
				DisplayModes item = default(DisplayModes);
				item.modeNo = 0;
				this.mDisplayModesList.Add(item);
				item.modeNo = 1;
				this.mDisplayModesList.Add(item);
				LowHigh item2 = default(LowHigh);
				item2.bIsHigh = true;
				this.mShadowList.Add(item2);
				this.mReflectionList.Add(item2);
				item2.bIsHigh = false;
				this.mShadowList.Add(item2);
				this.mReflectionList.Add(item2);
				OnOff item3 = default(OnOff);
				item3.bIsOn = true;
				this.mVsyncList.Add(item3);
				item3.bIsOn = false;
				this.mVsyncList.Add(item3);
				for (int i = 0; i < num; i++)
				{
					AdapterInfo item4 = default(AdapterInfo);
					DllExterns._GetAdapterData(i, ref item4);
					Array.Resize<Resolution>(ref item4.AResArray, item4.NoOfRes);
					item4.AAList[0] = 0;
					item4.AAList[1] = 1;
					Array.Resize<int>(ref item4.AAList, 2);
					this.mGraphicsAdapterList.Add(item4);
				}
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				foreach (AdapterInfo adapterInfo in this.mGraphicsAdapterList)
				{
					if (adapterInfo.AdapterDescription == GlobalDefs.OutputAdapter.AdapterDescription && adapterInfo.AdapterName == GlobalDefs.OutputAdapter.AdapterName)
					{
						num3 = num2;
						break;
					}
					num2++;
				}
				int selectedIndex = this.mGraphicsAdapterList[num3].DefaultResIndex;
				num2 = 0;
				foreach (Resolution resolution in this.mGraphicsAdapterList[num3].AResArray)
				{
					if (resolution.DisplayName == GlobalDefs.OutputAdapter.OutputRes.DisplayName)
					{
						selectedIndex = num2;
						break;
					}
					num2++;
				}
				num2 = 0;
				foreach (int num5 in this.mGraphicsAdapterList[num3].AAList)
				{
					if (num5 == GlobalDefs.OutputAdapter.AA)
					{
						num4 = num2;
						break;
					}
					num2++;
				}
				this.Adapter_Combo.DataSource = null;
				this.Adapter_Combo.Items.Clear();
				this.Adapter_Combo.DataSource = this.mGraphicsAdapterList;
				this.Adapter_Combo.DisplayMember = "DisplayName";
				this.Adapter_Combo.SelectedIndex = num3;
				this.Resolution_Combo.SelectedIndex = selectedIndex;
				if (this.mAATypesList.Count<AATypes>() > num4)
				{
					this.AA_Combo.SelectedIndex = num4;
				}
				else
				{
					this.AA_Combo.SelectedIndex = 0;
				}
				bool flag;
				bool flag2;
				bool flag3;
				bool flag4;
				if (GlobalDefs.GraphicsConfigFileRead)
				{
					flag = GlobalDefs.OutputAdapter.ShadQuality;
					flag2 = GlobalDefs.OutputAdapter.ReflectQuality;
					flag3 = GlobalDefs.OutputAdapter.DisplayMode;
					flag4 = GlobalDefs.OutputAdapter.bVSync;
				}
				else
				{
					flag = true;
					flag2 = true;
					flag3 = false;
					flag4 = true;
				}
				this.DispMode_combo.DataSource = null;
				this.DispMode_combo.Items.Clear();
				this.DispMode_combo.DataSource = this.mDisplayModesList;
				this.DispMode_combo.DisplayMember = "DisplayName";
				if (flag3)
				{
					this.DispMode_combo.SelectedIndex = 1;
				}
				else
				{
					this.DispMode_combo.SelectedIndex = 0;
				}
				this.Shadow_Combo.DataSource = null;
				this.Shadow_Combo.Items.Clear();
				this.Shadow_Combo.DataSource = this.mShadowList;
				this.Shadow_Combo.DisplayMember = "DisplayName";
				if (flag)
				{
					this.Shadow_Combo.SelectedIndex = 0;
				}
				else
				{
					this.Shadow_Combo.SelectedIndex = 1;
				}
				this.Reflection_Combo.DataSource = null;
				this.Reflection_Combo.Items.Clear();
				this.Reflection_Combo.DataSource = this.mReflectionList;
				this.Reflection_Combo.DisplayMember = "DisplayName";
				if (flag2)
				{
					this.Reflection_Combo.SelectedIndex = 0;
				}
				else
				{
					this.Reflection_Combo.SelectedIndex = 1;
				}
				this.Vsync_combo.DataSource = null;
				this.Vsync_combo.Items.Clear();
				this.Vsync_combo.DataSource = this.mVsyncList;
				this.Vsync_combo.DisplayMember = "DisplayName";
				if (flag4)
				{
					this.Vsync_combo.SelectedIndex = 0;
				}
				else
				{
					this.Vsync_combo.SelectedIndex = 1;
				}
			}
			else
			{
				GlobalDefs globalDefs = new GlobalDefs();
				this.Adapter_Combo.Enabled = false;
				this.Resolution_Combo.Enabled = false;
				this.AA_Combo.Enabled = false;
				this.DispMode_combo.Enabled = false;
				this.Shadow_Combo.Enabled = false;
				this.Reflection_Combo.Enabled = false;
				this.Vsync_combo.Enabled = false;
				this.NoAdapterWarning_label.Visible = true;
				GlobalDefs.OutputAdapter.AdapterDescription = "";
				GlobalDefs.OutputAdapter.AdapterName = "";
				GlobalDefs.OutputAdapter.DeviceGUID = globalDefs.ZERO_GUID;
				GlobalDefs.OutputAdapter.AdapterID = "";
				GlobalDefs.OutputAdapter.OutputRes.Height = 0;
				GlobalDefs.OutputAdapter.OutputRes.Refresh = 0;
				GlobalDefs.OutputAdapter.OutputRes.Width = 0;
				GlobalDefs.OutputAdapter.ValidAdapter = false;
				GlobalDefs.OutputAdapter.DisplayMode = false;
				GlobalDefs.OutputAdapter.ShadQuality = false;
				GlobalDefs.OutputAdapter.ReflectQuality = false;
			}
			this.DressText();
		}

		private void DressText()
		{
			this.Adapter_label.Text = LocalizedText.Adapter_label;
			this.Res_label.Text = LocalizedText.Res_label;
			this.AA_label.Text = LocalizedText.AA_label;
			this.vsync_label.Text = LocalizedText.VSync_Check;
			this.NoAdapterWarning_label.Text = LocalizedText.NoValidAdapter_Label;
			this.Shadow_Label.Text = LocalizedText.Shadow_Check;
			this.Reflection_Label.Text = LocalizedText.Reflection_Check;
			this.DisplayMode_Label.Text = LocalizedText.DisplayMode_Label;
		}

		private void Adapter_Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Resolution_Combo.DataSource = null;
			this.Resolution_Combo.Items.Clear();
			this.Resolution_Combo.DataSource = this.mGraphicsAdapterList[this.Adapter_Combo.SelectedIndex].AResArray;
			this.Resolution_Combo.DisplayMember = "DisplayName";
			this.Resolution_Combo.SelectedIndex = 0;
			this.AA_Combo.DataSource = null;
			this.AA_Combo.Items.Clear();
			this.AA_Combo.DataSource = this.mAATypesList;
			this.AA_Combo.DisplayMember = "DisplayName";
			this.AA_Combo.SelectedIndex = 0;
			int selectedIndex = this.Adapter_Combo.SelectedIndex;
			GlobalDefs.OutputAdapter.AdapterDescription = this.mGraphicsAdapterList[selectedIndex].AdapterDescription;
			GlobalDefs.OutputAdapter.AdapterName = this.mGraphicsAdapterList[selectedIndex].AdapterName;
			GlobalDefs.OutputAdapter.DeviceGUID = this.mGraphicsAdapterList[selectedIndex].DeviceGUID;
			GlobalDefs.OutputAdapter.AdapterID = this.mGraphicsAdapterList[selectedIndex].AdapterID;
			GlobalDefs.OutputAdapter.DepthFormat = this.mGraphicsAdapterList[selectedIndex].DepthFormat;
			if (this.Resolution_Combo.SelectedIndex != -1)
			{
				this.Resolution_Combo.SelectedIndex = this.mGraphicsAdapterList[this.Adapter_Combo.SelectedIndex].DefaultResIndex;
			}
			if (this.AA_Combo.SelectedIndex != -1)
			{
				this.AA_Combo.SelectedIndex = 0;
			}
		}

		private void Resolution_Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.Adapter_Combo.SelectedIndex;
			int selectedIndex2 = this.Resolution_Combo.SelectedIndex;
			int selectedIndex3 = this.AA_Combo.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < this.mGraphicsAdapterList.Count<AdapterInfo>() && selectedIndex2 >= 0 && selectedIndex2 < this.mGraphicsAdapterList[selectedIndex].AResArray.Count<Resolution>())
			{
				this.mAATypesList.Clear();
				AATypes item = default(AATypes);
				item.AA = 0;
				this.mAATypesList.Add(item);
				item.AA = 1;
				this.mAATypesList.Add(item);
				GlobalDefs.OutputAdapter.OutputRes = this.mGraphicsAdapterList[selectedIndex].AResArray[selectedIndex2];
				if (this.mAATypesList.Count<AATypes>() > selectedIndex3)
				{
					this.AA_Combo.SelectedIndex = selectedIndex3;
					return;
				}
				this.AA_Combo.SelectedIndex = 0;
			}
		}

		private void AA_Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.Adapter_Combo.SelectedIndex;
			int selectedIndex2 = this.AA_Combo.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < this.mGraphicsAdapterList.Count<AdapterInfo>() && selectedIndex2 >= 0 && selectedIndex2 < this.mGraphicsAdapterList[selectedIndex].AAList.Count<int>())
			{
				GlobalDefs.OutputAdapter.AA = this.mGraphicsAdapterList[selectedIndex].AAList[selectedIndex2];
			}
		}

		private void DispMode_combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalDefs.OutputAdapter.DisplayMode = (this.DispMode_combo.SelectedIndex == 1);
		}

		private void Shadow_Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalDefs.OutputAdapter.ShadQuality = (this.Shadow_Combo.SelectedIndex == 0);
		}

		private void Reflection_Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalDefs.OutputAdapter.ReflectQuality = (this.Reflection_Combo.SelectedIndex == 0);
		}

		private void Vsync_combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalDefs.OutputAdapter.bVSync = (this.Vsync_combo.SelectedIndex == 0);
		}

		private IContainer components;

		private ComboBox Adapter_Combo;

		private ComboBox Resolution_Combo;

		private ComboBox AA_Combo;

		private Label Adapter_label;

		private Label Res_label;

		private Label AA_label;

		private Label NoAdapterWarning_label;

		private Label DisplayMode_Label;

		private ComboBox DispMode_combo;

		private ComboBox Shadow_Combo;

		private ComboBox Reflection_Combo;

		private Label Shadow_Label;

		private Label Reflection_Label;

		private PictureBox pictureBox1;

		private ComboBox Vsync_combo;

		private Label vsync_label;

		private List<AdapterInfo> mGraphicsAdapterList;

		private List<DisplayModes> mDisplayModesList;

		private List<AATypes> mAATypesList;

		private List<LowHigh> mShadowList;

		private List<LowHigh> mReflectionList;

		private List<OnOff> mVsyncList;
	}
}
