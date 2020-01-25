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
			this.InitExterns = false;
			this.InitExterns = this.InitializeExternals();
			RegistryData registryData = new RegistryData();
			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(registryData.LCID);
			InputConfiguration value = new InputConfiguration();
			this.TabWindow.TabPages[0].Controls.Add(value);
			GraphicsConfiguration value2 = new GraphicsConfiguration();
			this.TabWindow.TabPages[1].Controls.Add(value2);
			StatsConfiguration value3 = new StatsConfiguration();
			this.TabWindow.TabPages[2].Controls.Add(value3);
			AudioConfiguration value4 = new AudioConfiguration();
			this.TabWindow.TabPages[3].Controls.Add(value4);
			AdvancedConfiguration value5 = new AdvancedConfiguration();
			this.TabWindow.TabPages[4].Controls.Add(value5);
			FileHandler fileHandler = new FileHandler();
			fileHandler.LoadGraphicsFile();
			if (!fileHandler.LoadAdvancedConfiguration())
			{
				GlobalDefs.CacheEnabled = 0;
				GlobalDefs.CacheSize = 100;
				GlobalDefs.CacheBlockSize = 100;
				GlobalDefs.StreamingRate = 0;
			}
			if (!fileHandler.LoadAudioConfiguration())
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
			FileHandler fileHandler = new FileHandler();
			fileHandler.LoadFile();
			this.TabWindow.SelectedIndex = 1;
		}

		public bool InitializeExternals()
		{
			IntPtr hinstance = Marshal.GetHINSTANCE(base.GetType().Module);
			IntPtr handle = base.Handle;
			try
			{
				DllExterns.NvAPI_Initialize();
			}
			catch { }
				
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

		private void LaunchButton_Click(object Sender, EventArgs e)
		{
			FileHandler fileHandler = new FileHandler();
			fileHandler.SaveFile();
			Application.Exit();
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			FileHandler fileHandler = new FileHandler();
			fileHandler.SaveFile();
		}

		private bool InitExterns;
	}
}
