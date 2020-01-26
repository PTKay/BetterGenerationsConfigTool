using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Generations_Launcher_Front.TextStore;

namespace Generations_Launcher_Front
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			this.InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.MaximizeBox = false;
			this.InitExterns = this.InitializeExternals();
			RegistryData registryData = new RegistryData();
			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(registryData.LCID);
			
			this.TabWindow.TabPages[0].Controls.Add(new InputConfiguration());
			this.TabWindow.TabPages[1].Controls.Add(new GraphicsConfiguration());
			this.TabWindow.TabPages[2].Controls.Add(new StatsConfiguration());
			this.TabWindow.TabPages[3].Controls.Add(new AudioConfiguration());
			this.TabWindow.TabPages[4].Controls.Add(new AdvancedConfiguration());
			
			FileHandler.LoadGraphicsFile();
			if (!FileHandler.LoadAdvancedConfiguration())
			{
				GlobalDefs.CacheEnabled = 0;
				GlobalDefs.CacheSize = 100;
				GlobalDefs.CacheBlockSize = 100;
				GlobalDefs.StreamingRate = 0;
			}
			if (!FileHandler.LoadAudioConfiguration())
			{
				GlobalDefs.OutputAudio.description = "Default";
				GlobalDefs.OutputAudio.AudioGuid = new Guid("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF");
			}
			this.TabWindow.SelectedIndex = 3;
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 537)
			{
				IntPtr value = new IntPtr(7);
				if (m.WParam == value)
				{
					InputConfiguration inputConfiguration = (InputConfiguration)this.TabWindow.TabPages[0].Controls[0];
					inputConfiguration.ResetPadListData();
					AudioConfiguration audioConfiguration = (AudioConfiguration)this.TabWindow.TabPages[3].Controls[0];
					audioConfiguration.ResetAudioListData();
				}
			}
			base.WndProc(ref m);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (!this.InitExterns)
			{
				MessageBox.Show(LocalizedText.DXFailed, LocalizedText.CriticalError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
			}
			this.SetFormText();
			FileHandler.LoadFile();
			this.TabWindow.SelectedIndex = 1;
		}

		public bool InitializeExternals()
		{
			IntPtr hinstance = Marshal.GetHINSTANCE(base.GetType().Module);
			IntPtr handle = base.Handle;
			return DllExterns._InitialiseDirectXInput(hinstance, handle) && DllExterns._InitialiseDirectX() && DllExterns._InitialiseDirectSound();
		}

		public void SetFormText()
		{
			this.Text = LocalizedText.Main_App_Title;
			this.TabWindow.TabPages[0].Text = LocalizedText.InputConfiguration;
			this.TabWindow.TabPages[1].Text = LocalizedText.GraphicsConfiguration;
			this.TabWindow.TabPages[2].Text = LocalizedText.StatsConfiguration;
			this.TabWindow.TabPages[3].Text = LocalizedText.AudioConfiguration;
			this.TabWindow.TabPages[4].Text = LocalizedText.AdvancedConfiguration;
			this.SaveButton.Text = LocalizedText.Save_Button;
			this.LaunchButton.Text = LocalizedText.SaveQuit_Button;
			this.QuitConfigButton.Text = LocalizedText.Cancel_Button;
		}

		private void LaunchButton_Click(object sender, EventArgs e)
		{
			FileHandler.SaveFile();
			Application.Exit();
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			FileHandler.SaveFile();
		}

		private bool InitExterns;
	}
}
