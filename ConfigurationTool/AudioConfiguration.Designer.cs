using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Generations_Launcher_Front.TextStore;

namespace Generations_Launcher_Front
{
    public class AudioConfiguration : UserControl
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
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AudioConfiguration));
            this.Audio_Combo = new ComboBox();
            this.RefreshList_timer = new Timer(this.components);
            this.AudioDevice_label = new Label();
            this.pictureBox1 = new PictureBox();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.Audio_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Audio_Combo.FormattingEnabled = true;
            this.Audio_Combo.Location = new Point(39, 41);
            this.Audio_Combo.Name = "Audio_Combo";
            this.Audio_Combo.Size = new Size(446, 21);
            this.Audio_Combo.TabIndex = 0;
            this.Audio_Combo.SelectedIndexChanged += this.Audio_Combo_SelectedIndexChanged;
            this.RefreshList_timer.Interval = 500;
            this.RefreshList_timer.Tick += this.RefreshList_timer_Tick;
            this.AudioDevice_label.Location = new Point(39, 22);
            this.AudioDevice_label.Name = "AudioDevice_label";
            this.AudioDevice_label.Size = new Size(119, 16);
            this.AudioDevice_label.TabIndex = 1;
            this.AudioDevice_label.Text = "label1";
            this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(846, 460);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.AudioDevice_label);
            base.Controls.Add(this.Audio_Combo);
            base.Controls.Add(this.pictureBox1);
            base.Name = "AudioConfiguration";
            base.Size = new Size(846, 460);
            base.Load += this.AudioConfiguration_Load;
            ((ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        public AudioConfiguration()
        {
            this.InitializeComponent();
            this.mAudiosAdapterList = new List<AudioInfo>();
        }

        private void AudioConfiguration_Load(object sender, EventArgs e)
        {
            this.PopulateDeviceList();
            this.DressText();
        }

        private void DressText()
        {
            this.AudioDevice_label.Text = LocalizedText.AudioDevice_label;
        }

        private void PopulateDeviceList()
        {
            string description = GlobalDefs.OutputAudio.description;
            this.mAudiosAdapterList.Clear();
            int num = DllExterns._PopulateDeviceList();
            if (num > 0)
            {
                this.Audio_Combo.Enabled = true;
                AudioInfo item = default(AudioInfo);
                item.description = LocalizedText.None_Combo;
                item.AudioGuid = new Guid("00000000-0000-0000-0000-000000000000");
                this.mAudiosAdapterList.Add(item);
                switch (num)
                {
                    case 1:
                        this.Audio_Combo.Enabled = false;
                        break;
                    case 2:
                        DllExterns._GetAudioData(1, ref item);
                        this.mAudiosAdapterList.Add(item);
                        break;
                    default:
                        item.description = LocalizedText.Default_combo;
                        item.AudioGuid = new Guid("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF");
                        this.mAudiosAdapterList.Add(item);
                        for (int i = 1; i < num; i++)
                        {
                            AudioInfo item2 = default(AudioInfo);
                            DllExterns._GetAudioData(i, ref item2);
                            this.mAudiosAdapterList.Add(item2);
                        }
                        break;
                }
                this.DeviceList = new BindingList<AudioInfo>(this.mAudiosAdapterList);
                this.Audio_Combo.DataSource = this.DeviceList;
                this.Audio_Combo.DisplayMember = "DisplayName";
                if (this.mAudiosAdapterList.Count >= 2)
                {
                    this.Audio_Combo.SelectedIndex = 1;
                }
                else
                {
                    this.Audio_Combo.SelectedIndex = 0;
                }
                int num2 = 0;

                IEnumerator enumerator = this.Audio_Combo.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object obj = enumerator.Current;
                    if (((AudioInfo)obj).description == description)
                    {
                        this.Audio_Combo.SelectedIndex = num2;
                        break;
                    }
                    num2++;
                }
                return;

            }
            this.Audio_Combo.Enabled = false;
        }

        private void Audio_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalDefs.OutputAudio = this.mAudiosAdapterList[this.Audio_Combo.SelectedIndex];
        }

        public void ResetAudioListData()
        {
            this.RefreshList_timer.Start();
        }

        private void RefreshList_timer_Tick(object sender, EventArgs e)
        {
            this.RefreshList_timer.Stop();
            this.PopulateDeviceList();
        }

        private IContainer components;

        private ComboBox Audio_Combo;

        private Timer RefreshList_timer;

        private Label AudioDevice_label;

        private PictureBox pictureBox1;

        private List<AudioInfo> mAudiosAdapterList;

        private BindingList<AudioInfo> DeviceList;
    }
}
